IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_BindingISO' AND type = 'P')
    DROP PROCEDURE dbo.Pr_BindingISO
GO
CREATE PROCEDURE dbo.Pr_BindingISO
/*
	=============================================
	|	Привязка по ТУ с ИСУ места установки ПУ	|
	=============================================
*/
		
	@CounterTypeId 	VARCHAR(MAX) 	= NULL, 	-- ИД ПУ
	@CounterPlaceId	INT 			= 8,		-- Место установки ПУ (8-нет данных)
	@DeleteLesses	INT 			= 0,		-- 1-удалять потери; 0-не удалять потери
	@Function		INT 			= 1,		-- 1 - SELECT
												-- 2 - INSERT
												-- 3 - UPDATE
												-- 4 - DELETE
	@SelectNumber	INT 			= 0			-- номер селекта
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Сounter INT = 0 -- Счетчик обработанных строк
-- Выборка все типов ПУ
IF @Function = 1 BEGIN
	-- 1-ой селект (ПУшки из Квазара)
	IF @SelectNumber = 1 BEGIN
		CREATE TABLE #tmpCounterList(
									SignsGroupName VARCHAR(50), 
									CounterTypeId SMALLINT, 
									CounterName VARCHAR(114),
									Signs TINYINT
									)
		INSERT INTO #tmpCounterList
		SELECT 	* FROM vPr_cmbCountersType

		-- удаляем те ПУ которые уже добавлены в справочник как ИСУ
		DELETE FROM #tmpCounterList
		WHERE CounterTypeId IN (SELECT pil.CounterTypeId FROM Pr_ISUCounterList pil)
		SELECT * FROM #tmpCounterList cl
		DROP TABLE #tmpCounterList
	END
	-- 2-ой селект (ПУшки из Припять ИСУ)
	IF @SelectNumber = 2 BEGIN
		SELECT 		isu.CounterTypeId,
	   				CAST(ct.OldTypeId AS VARCHAR) + ' - ' + ct.Name AS Name,
			   		ct.Signs,
			   		ct.IntervalVerify,
			   		ct.Amper,
					ct.Voltage,
					ct.Accuracy,
					dbo.Pr_fnsGetShortFNS('', isu.CreaterId, 1) AS Author
		FROM 		dbo.Pr_ISUCounterList isu
		INNER JOIN 	dbo.vCounterTypes ct ON isu.CounterTypeId = ct.CounterTypeId
		WHERE 		ct.EnergyTypeId = 1
		ORDER BY  	isu.CreateDt 
	END 
	-- 3-ий селект (Перечень лицевых счетов с ИСУ)
	IF @SelectNumber = 3 BEGIN
		SELECT * FROM  vPr_ISUPointsList
	END
END

-- добавление выносного ПУ в справочник
IF @Function = 2 BEGIN
	INSERT INTO Pr_ISUCounterList
	SELECT	pgtfs.[Values], 
			dbo.Kernel_GetPerformer(), 
			GETDATE() 
	FROM 	dbo.Pr_fntGetTableFromString(@CounterTypeId, ',') pgtfs
END

-- процесс привязки места установки ПУ
IF @Function = 3 BEGIN
	-- считаем строки к обработке
	SELECT 		@Сounter = COUNT(chM.PointId)
	FROM		vPr_HistoryMaxCounters chM
	INNER JOIN 	CountersHistory ch ON chM.PointId = ch.PointId AND chM.DtCountSetup = ch.DtCountSetup
	INNER JOIN	Points p ON ch.PointId = p.PointId
	WHERE 		ch.CounterTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@CounterTypeId, ',')) AND 
				p.EnergyTypeId = 1 -- только электроэнергия
	-- привязка ...
	UPDATE		CountersHistory
	SET      	CounterPlaceId = @CounterPlaceId
	FROM		vPr_HistoryMaxCounters chM
	INNER JOIN 	CountersHistory ch ON chM.PointId = ch.PointId AND chM.DtCountSetup = ch.DtCountSetup
	INNER JOIN	Points p ON chM.PointId = p.PointId
	WHERE 		chM.CounterTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@CounterTypeId, ',')) AND 
				p.EnergyTypeId = 1 -- только электроэнергия
	--удаление потерь если требуется c периода след за расчетным
	IF @DeleteLesses = 1 BEGIN
		DELETE FROM PointsLossesLineHistory 
		WHERE 	PointId IN	(
							SELECT 		ch.PointId
							FROM		vPr_HistoryMaxCounters chM
							INNER JOIN 	CountersHistory ch ON chM.PointId = ch.PointId AND chM.DtCountSetup = ch.DtCountSetup
							WHERE 		chM.CounterTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@CounterTypeId, ','))
							) AND 
				PeriodNumber > (SELECT * FROM vCurrentMonthNumber cmn)
	END
	--откат если есть ошибки
	IF @@error <> 0 BEGIN
		ROLLBACK TRANSACTION
	END
	-- показываем пользователю сколько обработано строк
	SELECT @Сounter
END

-- удаление ПУ из справочника ИСУ
IF @Function = 4 BEGIN
	DELETE FROM Pr_ISUCounterList 
	WHERE CounterTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@CounterTypeId, ',') pgtfs)
END
GO
GRANT EXECUTE ON dbo.Pr_BindingISO TO KvzWorker
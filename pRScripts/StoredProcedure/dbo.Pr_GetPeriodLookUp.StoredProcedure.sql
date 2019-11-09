IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetPeriodLookUp' AND type = 'P')
    DROP PROCEDURE dbo.Pr_GetPeriodLookUp
GO
CREATE PROCEDURE dbo.Pr_GetPeriodLookUp
/*
	=================================
	|	Получение дерева периодов	|
	|	из выбранной таблицы		|
	=================================
*/
	
	
	@TableName	VARCHAR(70) = ''		-- Pr_PointsPublicSectionsCharges
										-- ...
										-- ...
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

IF @TableName = 'Pr_PointsPublicSectionsCharges' BEGIN 
	DECLARE @tPeriods AS TABLE (Id INT, ParentId INT, Name VARCHAR(20), Year VARCHAR(15), Month VARCHAR(15)) 
	INSERT INTO @tPeriods
	SELECT 99999 AS Id, NULL AS ParentId, 'Все периоды' AS Name, 'NULL' AS Year, 'NULL' AS Month

	INSERT INTO @tPeriods -- года
	SELECT DISTINCT	FLOOR(pppsc.PeriodNumber / 100) AS Id,
			99999 AS ParentId,
			CAST(FLOOR(pppsc.PeriodNumber / 100) AS VARCHAR) + ' год' AS Name,
			FLOOR(pppsc.PeriodNumber / 100) AS Year,
			'NULL' AS Month
	FROM Pr_PointsPublicSectionsCharges AS pppsc
	GROUP BY pppsc.PeriodNumber
	ORDER BY Id

	INSERT INTO @tPeriods -- месяца
	SELECT DISTINCT	pppsc.PeriodNumber AS Id,
			FLOOR(pppsc.PeriodNumber / 100) AS ParentId,
			lm.Name AS Name,
			FLOOR(pppsc.PeriodNumber/100) AS Year,
			pppsc.PeriodNumber - (FLOOR(pppsc.PeriodNumber / 100) * 100) AS Month
	FROM Pr_PointsPublicSectionsCharges AS pppsc
	INNER JOIN vPr_ListOfMonth AS lm ON lm.MonthId = pppsc.PeriodNumber - (FLOOR(pppsc.PeriodNumber / 100) * 100)
	GROUP BY pppsc.PeriodNumber, lm.Name
	ORDER BY ParentId, Id
	/*
	-- добавляем расчетный период, если требуется
	DECLARE @ActivePeriod INT = (SELECT ap.PeriodNumber FROM AccountingPeriods AS ap WHERE ap.ActiveStatusId = 1)
	-- если в таблице макс период не равен расчетному
	IF @ActivePeriod != (SELECT MAX(pppsc.PeriodNumber) FROM Pr_PointsPublicSectionsCharges AS pppsc) BEGIN 
		INSERT INTO @tPeriods
		SELECT 	@ActivePeriod AS Id,
				FLOOR(@ActivePeriod/100) AS ParentId,
				lm.Name,
				FLOOR(@ActivePeriod / 100) AS Year,
				@ActivePeriod - (FLOOR(@ActivePeriod / 100) * 100) AS Month
		FROM vPr_ListOfMonth AS lm WHERE lm.MonthId = @ActivePeriod - (FLOOR(@ActivePeriod / 100) * 100)
	END */
    SELECT * FROM @tPeriods
END 

GO
GRANT EXECUTE ON dbo.Pr_GetPeriodLookUp TO KvzWorker
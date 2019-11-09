IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PointsPublicPrepareDistribution' AND type = 'P')
    DROP PROCEDURE dbo.Pr_PointsPublicPrepareDistribution
GO
CREATE PROCEDURE dbo.Pr_PointsPublicPrepareDistribution
/*
	=============================================
	|	Подготовка секций к распределению ОДН	|
	=============================================
*/		
	@SectionId		INT = 0,
	@PeriodNumber 	INT = 0		

AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Message VARCHAR(MAX)
DECLARE @SectionName VARCHAR(25)
DECLARE @SchemesId INT 

SELECT 	@SchemesId = ppps.SchemesId, 
		@SectionName = '№ ' + CAST(ppps.SectionRoomNumber AS VARCHAR) + ' (№л/с ' + ppps.SectionNumber + ')' 
FROM 	Pr_PointsPublicSections AS ppps 
WHERE 	ppps.SectionId = @SectionId

-- Проверка реализованных схем распределения
IF @SchemesId IN (1, 2, 3, 4) BEGIN 
	SET @Message = 'Выбранная схема для распределения, на данный момент не реализована!' + CHAR(10) + 
				   'Обратитесь руководителю отдела !' + CHAR(10) + 
				   'Распределение невозможно!' 
	RAISERROR (@Message, 16, 2)
	RETURN
END 

-- проверка периода на "Закрыт"
IF (SELECT ap.MonthStatus FROM AccountingPeriods AS ap WHERE ap.PeriodNumber = @PeriodNumber) = 2 BEGIN
	SET @Message = 'Выбранный период относится к закрытому месяцу!' + CHAR(10) + 
				   'Распределение невозможно!' 
	RAISERROR (@Message, 16, 2)
	RETURN
END 

-- Проверяем есть ли закрытые ту
IF EXISTS (	SELECT ph.PointId 
			FROM PointsHistory AS ph 
			INNER JOIN (
						SELECT PointId, MAX(DtChange) AS DtChange
						FROM PointsHistory AS ph
						GROUP BY PointId
						HAVING MAX(DtChange) BETWEEN
                             		(SELECT dbo.Pr_fnsGetFirstDayPeriod(@PeriodNumber)) AND
                             		(SELECT dbo.Pr_fnsGetLastDayPeriod(@PeriodNumber))
						) AS pm ON pm.PointId = ph.PointId AND pm.DtChange = ph.DtChange
			INNER JOIN Pr_PointsPublicSectionsConn AS pppsc ON ph.PointId = pppsc.PointId 
			WHERE ph.AccountStatusId = 2 AND pppsc.SectionId = @SectionId
			) BEGIN 
	SET @Message = 'В секции <b>' + @SectionName + '</b> обнаружены закрытые ТУ!' + CHAR(10) + 
				   'Требуется изменить подключение к сеции!' + CHAR(10) +
				   'Распределение невозможно!'
	RAISERROR (@Message, 16, 2)
	RETURN
END 

-- Проверяем есть ли закрытие абоненты
IF EXISTS  (SELECT ah.AbonentId
			FROM AbonentsHistory AS ah 
			INNER JOIN (
						SELECT ah.AbonentId, MAX(DtChange) AS DtChange
						FROM AbonentsHistory AS ah
						GROUP BY ah.AbonentId
						HAVING MAX(DtChange) BETWEEN
                             		(SELECT dbo.Pr_fnsGetFirstDayPeriod(@PeriodNumber)) AND
                             		(SELECT dbo.Pr_fnsGetLastDayPeriod(@PeriodNumber))
						) AS am ON ah.AbonentId = am.AbonentId AND ah.DtChange = am.DtChange
			INNER JOIN Points AS p ON ah.AbonentId = p.AbonentId
			INNER JOIN Pr_PointsPublicSectionsConn AS pppsc ON p.PointId = pppsc.PointId
			WHERE ah.AbonentStatusId != 1 AND pppsc.SectionId = @SectionId) BEGIN 
	SET @Message = 'В секции <b>' + @SectionName + '</b> обнаружены снятые с учета абоненты!' + CHAR(10) + 
				   'Требуется изменить подключение к сеции!' + CHAR(10) +
				   'Распределение невозможно!'
	RAISERROR (@Message, 16, 2)
	RETURN
END 

-- Проверяем по всем ли ТУ есть начисления в указанном периоде
IF EXISTS(SELECT pppsc.SectionId, pppsc.PointId, mos.DocumentId
		  FROM Pr_PointsPublicSectionsConn AS pppsc
		  LEFT JOIN vMemoOrdersShort AS mos ON pppsc.PointId = mos.PointId AND 
		  			mos.PeriodNumber = @PeriodNumber AND 
					mos.EnergyTypeId = 1 AND 
					mos.DocumentTypeId IN(2, 3, 5, 7, 9) AND 
					mos.StateId = 5 AND 
					mos.PackStateId = 5
		  WHERE mos.DocumentId IS NULL AND pppsc.SectionId = @SectionId) BEGIN
	SET @Message = 'В секции <b>' + @SectionName + '</b> обнаружены ТУ без начислений в указанном периоде!' + CHAR(10) +
				   'Или начисления находятся в неразнесенных пачках' + CHAR(10) + 
				   'Распределение невозможно!'
	RAISERROR (@Message, 16, 2)
	RETURN
END 

-- Проверяем выставлен ли расход по выбранной секции
IF NOT EXISTS(SELECT * FROM Pr_PointsPublicSectionsCharges AS pppsc WHERE pppsc.SectionId = @SectionId AND pppsc.PeriodNumber = @PeriodNumber) BEGIN
	SET @Message = 'В секции <b>' + @SectionName + '</b> невыставлен расход по секционному ПУ в указанном периоде!' + CHAR(10) + 
				   'Распределение невозможно!'
	RAISERROR (@Message, 16, 2)
	RETURN
END 

-- Проверяем наличие уже проделанных коррекций (NumControl = 'ОСН') и удаляем их
	SELECT d.DocumentId 
	INTO #RemovedDocuments
	FROM Pr_PointsPublicSectionsConn AS pppsc
	INNER JOIN MemoOrders AS mo ON pppsc.PointId = mo.PointId
	INNER JOIN MemoOrdersReasonCorrect AS morc ON mo.DocumentId = morc.DocumentId
	INNER JOIN Documents AS d ON mo.DocumentId = d.DocumentId
	WHERE d.PeriodNumber = @PeriodNumber AND d.DocumentTypeId = 7 AND mo.WiringTypeId = 3
			AND morc.NumControl = 'ОСН' AND pppsc.SectionId = @SectionId

-- если есть докуметны для удаления
IF EXISTS (SELECT * FROM #RemovedDocuments AS rd) BEGIN 
	DECLARE @DocumentId INT 
	DECLARE cur CURSOR FAST_FORWARD READ_ONLY LOCAL FOR
	SELECT * FROM #RemovedDocuments AS rd
		OPEN cur
		FETCH NEXT FROM cur INTO @DocumentId
			WHILE @@FETCH_STATUS = 0 BEGIN
				EXEC Documents_MiscFunctions25 @DocumentId = @DocumentId
				FETCH NEXT FROM cur INTO @DocumentId
			END
		CLOSE cur
	DEALLOCATE cur
END 

-- запуск распределения в зависимости от активной схемы
IF @SchemesId = 1 BEGIN -- 1. Пропорционально кол-ву проживающих 
	SET @Message = 'Схема <b><u>1. Пропорционально кол-ву проживающих</b></u> на данный момент не реализована!' + CHAR(10) + 
				   'Обратитесь руководителю отдела !' + CHAR(10) + 
				   'Распределение невозможно!' 
	RAISERROR (@Message, 16, 2)
	RETURN

END 
IF @SchemesId = 2 BEGIN -- 2. Пропорционально кол-ву зарегистрированных 
	SET @Message = 'Схема <b><u>2. Пропорционально кол-ву зарегистрированных</b></u> на данный момент не реализована!' + CHAR(10) + 
				   'Обратитесь руководителю отдела !' + CHAR(10) + 
				   'Распределение невозможно!' 
	RAISERROR (@Message, 16, 2)
	RETURN

END 
IF @SchemesId = 3 BEGIN -- 3. Пропорционально занимаемой площади 
	SET @Message = 'Схема <b><u>3. Пропорционально занимаемой площади</b></u> на данный момент не реализована!' + CHAR(10) + 
				   'Обратитесь руководителю отдела !' + CHAR(10) + 
				   'Распределение невозможно!' 
	RAISERROR (@Message, 16, 2)
	RETURN

END 
IF @SchemesId = 4 BEGIN -- 4. Пропорционально расходу в комнате 
	SET @Message = 'Схема <b><u>4. Пропорционально расходу в комнате</b></u> на данный момент не реализована!' + CHAR(10) +  
				   'Обратитесь руководителю отдела !' + CHAR(10) + 
				   'Распределение невозможно!' 
	RAISERROR (@Message, 16, 2)
	RETURN

END 
IF @SchemesId = 5 BEGIN -- 5. Схема при отсутствии соглашения
	EXEC Pr_PointsPublicRunDistribution_0 @SectionId, @PeriodNumber
END 
GO
GRANT EXECUTE ON dbo.Pr_PointsPublicPrepareDistribution TO KvzWorker
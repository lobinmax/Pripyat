IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OioInsertCountMonth' AND type = 'P')
    DROP PROCEDURE Pr_OioInsertCountMonth
GO
CREATE PROCEDURE dbo.Pr_OioInsertCountMonth
-- Заполнение накопителя лицевых 
-- с периодами образования задолдженности
	(
	@PeriodNumber	INT = 201601,
	@Function		INT = 2
	)
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке
/*
SET @PeriodNumber = (SELECT		MAX(PeriodNumber) AS PeriodNumber
                     FROM		AccountingPeriods AS ap
                     WHERE		(MonthStatus = 2))
*//*
---------------------------------------------------------------------+
|                                   Заполнение накопителя кредитеров |
|                       и дебиторов точками учата с периодом ДЗ / КЗ |
---------------------------------------------------------------------+
*/
IF @Function = 1 BEGIN
	BEGIN TRANSACTION
		DELETE FROM Pr_OioCountMonthPoint WHERE PeriodNumber = @PeriodNumber 

		IF (OBJECT_ID('tempdb..#MonthDebitors') IS NOT NULL) DROP TABLE #MonthDebitors
			CREATE TABLE #MonthDebitors (PointId INT, CountMonth INT, SumBalance MONEY, PeriodNumber INT)

		EXECUTE dbo.Reports_Report30_05points  -- ТУ дебиторов
				@MaxSumBalance = 0, @iPeriodNumber = @PeriodNumber, @Function = 3, @Flag15_10 = 0 , @AgentSubjectId = -1 , @CompanySubjectId = 0, @EnergyTypeFunction = 1

			INSERT INTO 	Pr_OioCountMonthPoint
			SELECT			MonthDebitors_m.PointId, 
							MonthDebitors_m.CountMonth_m, 
							MonthDebitors.SumBalance, 
							@PeriodNumber, 
							1 AS DebtTypeId
			FROM            (
							SELECT   	PointId, MAX(CountMonth) AS CountMonth_m
                          	FROM		#MonthDebitors AS MonthDebitors_1
                          	GROUP BY 	PointId
							) AS MonthDebitors_m 
			LEFT OUTER JOIN #MonthDebitors AS MonthDebitors ON MonthDebitors_m.PointId = MonthDebitors.PointId AND 
							MonthDebitors_m.CountMonth_m = MonthDebitors.CountMonth

		DELETE FROM #MonthDebitors
		EXECUTE dbo.Reports_Report30_05points -- ТУ кредиторов
				@MaxSumBalance = 0, @iPeriodNumber = @PeriodNumber, @Function = 4, @Flag15_10 = 0 , @AgentSubjectId = -1 , @CompanySubjectId = 0, @EnergyTypeFunction = 1
		-- удаляем если переоткрытие месяца
		IF (SELECT		MAX(PeriodNumber) AS Period
					FROM		Pr_OioCountMonthPoint
					GROUP BY	DebtTypeId
					HAVING		DebtTypeId = 2) != @PeriodNumber BEGIN
			DELETE FROM Pr_OioCountMonthPoint WHERE PeriodNumber = @PeriodNumber AND DebtTypeId = 2
		END
			INSERT INTO Pr_OioCountMonthPoint  
			SELECT			MonthDebitors_m.PointId, 
							MonthDebitors_m.CountMonth_m, 
							MonthDebitors.SumBalance, 
							@PeriodNumber, 
							2 AS DebtTypeId
			FROM            (
							SELECT   	PointId, MAX(CountMonth) AS CountMonth_m
                          	FROM		#MonthDebitors AS MonthDebitors_1
                          	GROUP BY 	PointId
							) AS MonthDebitors_m 
			LEFT OUTER JOIN #MonthDebitors AS MonthDebitors ON MonthDebitors_m.PointId = MonthDebitors.PointId AND 
							MonthDebitors_m.CountMonth_m = MonthDebitors.CountMonth

		DROP TABLE #MonthDebitors

	IF (@@error <> 0)
    ROLLBACK
	COMMIT TRANSACTION

END

/*
---------------------------------------------------------------------+
|                                    Заполнение накопителя дебиторов |
|                   по абонентно для фильтров при печати уведомлений |
---------------------------------------------------------------------+
*/
IF @Function = 2 BEGIN
	BEGIN TRANSACTION
		DELETE FROM Pr_OioCountMonthAbonent WHERE PeriodNumber = @PeriodNumber

		IF (OBJECT_ID('tempdb..#OIO') IS NOT NULL) DROP TABLE #OIO
			CREATE TABLE #OIO (AbonentId INT, CountMonth INT, SumBalance MONEY, GroupCount INT, GroupName VARCHAR(25))
		EXEC dbo.Reports_Report30_05 @MaxSumBalance = 0 , @PeriodNumber = @PeriodNumber , @ReportType = 4 , @AgentSubjectId = -1

			INSERT INTO 		Pr_OioCountMonthAbonent
			SELECT				OIO_m.AbonentId, OIO_m.CountMonth_m, OIO.SumBalance, @PeriodNumber
			FROM            	#OIO AS OIO 
			RIGHT OUTER JOIN 	(
								SELECT	AbonentId, MAX(CountMonth) AS CountMonth_m
                               	FROM	#OIO AS OIO_1
                               	GROUP BY AbonentId
								) AS OIO_m ON OIO.AbonentId = OIO_m.AbonentId AND OIO.CountMonth = OIO_m.CountMonth_m
			DROP TABLE #OIO
	IF (@@error <> 0)
    ROLLBACK
	COMMIT TRANSACTION
END
GO
GRANT EXECUTE ON Pr_OioInsertCountMonth TO KvzWorker
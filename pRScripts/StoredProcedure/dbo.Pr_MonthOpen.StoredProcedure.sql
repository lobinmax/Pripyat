IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_MonthOpen' AND type = 'P')
    DROP PROCEDURE Pr_MonthOpen
GO
CREATE PROCEDURE dbo.Pr_MonthOpen
	/*	Набор процедур для открытия месяца
											*/
								
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Period int =	(	
						SELECT		MAX(PeriodNumber) AS PeriodNumber
						FROM		AccountingPeriods
						GROUP BY	MonthStatus
						HAVING		MonthStatus = 2
						)

EXEC Pr_OioInsertCountMonth @PeriodNumber = @Period, @Function = 1
EXEC Pr_OioInsertCountMonth @PeriodNumber = @Period, @Function = 2


-- обновляем таблицу периодов
INSERT INTO Pr_AccountingPeriods	(
									PeriodNumber, 
									MonthStatus, 
									DtOpened, 
									DtClosed, 
									ActiveStatusId
									)
SELECT	PeriodNumber, 
		MonthStatus, 
		DtOpened, 
		DtClosed, 
		ActiveStatusId 
FROM	AccountingPeriods
GO
GRANT EXECUTE ON Pr_MonthOpen TO KvzWorker

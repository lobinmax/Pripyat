IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ValidationStatusMonth' AND type = 'P')
    DROP PROCEDURE Pr_ValidationStatusMonth
GO
CREATE PROCEDURE dbo.Pr_ValidationStatusMonth
	/*	Процедура проверки статуса периодов
		ПК Припять и ПК Квазар				*/
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @MaxCloseMonth		INT			-- Максимальный открытый период
DECLARE @ActiveMonth		INT 		-- Расчетный период
DECLARE @Pr_MaxCloseMonth	INT
DECLARE @Pr_ActiveMonth		INT
DECLARE @TimeCloseMonth		DATETIME
DECLARE @Pr_@TimeCloseMonth	DATETIME

SET @TimeCloseMonth = (SELECT MAX(ap.DtClosed) FROM AccountingPeriods ap WHERE ap.MonthStatus = 2)
SET @Pr_@TimeCloseMonth = (SELECT MAX(pap.DtClosed) FROM Pr_AccountingPeriods pap WHERE pap.MonthStatus = 2)

SET @ActiveMonth =		(
						SELECT		MAX(PeriodNumber) AS PeriodNumber
						FROM		AccountingPeriods
						WHERE		ActiveStatusId = 1 
						)
SET @Pr_ActiveMonth =	(
						SELECT		MAX(PeriodNumber) AS PeriodNumber
						FROM		Pr_AccountingPeriods
						WHERE		ActiveStatusId = 1   
						)
SET @MaxCloseMonth =		(
						SELECT		MAX(PeriodNumber) AS PeriodNumber
						FROM		AccountingPeriods
						WHERE		MonthStatus = 2
						)
SET @Pr_MaxCloseMonth =	(
						SELECT		MAX(PeriodNumber) AS PeriodNumber
						FROM		Pr_AccountingPeriods
						WHERE		MonthStatus = 2
						)

IF @MaxCloseMonth != ISNULL(@Pr_MaxCloseMonth, 0) /*OR  @ActiveMonth != ISNULL(@Pr_ActiveMonth, 0)*/ OR @TimeCloseMonth != ISNULL(@Pr_@TimeCloseMonth, 0)
	SELECT 1 as v
ELSE BEGIN
	SELECT 0 as v
END
GO
GRANT EXECUTE ON Pr_ValidationStatusMonth TO KvzWorker

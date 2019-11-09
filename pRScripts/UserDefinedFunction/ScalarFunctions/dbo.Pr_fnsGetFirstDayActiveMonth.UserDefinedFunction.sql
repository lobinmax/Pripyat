IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetFirstDayActiveMonth' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetFirstDayActiveMonth
GO
CREATE FUNCTION dbo.Pr_fnsGetFirstDayActiveMonth
/*
	=================================================
	|	Определение первого дня расчетного периода	|
	=================================================
*/
(
-- парметры
)
RETURNS DATETIME 
AS
BEGIN
DECLARE @ActivePeriod INT = (SELECT ap.PeriodNumber FROM AccountingPeriods AS ap WHERE ap.ActiveStatusId = 1)
RETURN 	CAST('01.' + 
		CAST(@ActivePeriod - (FLOOR(@ActivePeriod/100) * 100) AS VARCHAR) + '.' + 
		CAST(FLOOR(@ActivePeriod/100) AS VARCHAR) AS DATETIME)
END 
GO
GRANT EXECUTE ON Pr_fnsGetFirstDayActiveMonth TO KvzWorker	-- для скалярных
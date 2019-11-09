IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetFirstDayPeriod' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetFirstDayPeriod
GO
CREATE FUNCTION dbo.Pr_fnsGetFirstDayPeriod
/*
	=====================================
	|	Определение первого дня периода	|
	=====================================
*/
(
	@PeriodNumber INT 
)
RETURNS DATETIME 
AS
BEGIN 
RETURN 	CAST('01.' + 
		CAST(@PeriodNumber - (FLOOR(@PeriodNumber/100) * 100) AS VARCHAR) + '.' + 
		CAST(FLOOR(@PeriodNumber/100) AS VARCHAR) AS DATETIME)
END 
GO
GRANT EXECUTE ON Pr_fnsGetFirstDayPeriod TO KvzWorker	-- для скалярных
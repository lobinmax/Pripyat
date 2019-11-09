IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetLastDayPeriod' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetLastDayPeriod
GO
CREATE FUNCTION dbo.Pr_fnsGetLastDayPeriod
/*
	=========================================
	|	Определение последнего дня периода	|
	=========================================
*/
(
	@PeriodNumber INT 
)
RETURNS DATETIME 
AS
BEGIN 
DECLARE @FirstDate DATETIME

SELECT @FirstDate = CAST('01.' + 
					CAST(@PeriodNumber - (FLOOR(@PeriodNumber/100) * 100) AS VARCHAR) + '.' + 
					CAST(FLOOR(@PeriodNumber/100) AS VARCHAR) AS DATETIME)
RETURN DATEADD(DAY, -1 , (DATEADD(MONTH, 1, @FirstDate)))
END 
GO
GRANT EXECUTE ON Pr_fnsGetLastDayPeriod TO KvzWorker	-- для скалярных
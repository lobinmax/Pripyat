IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_OioCountMonthAbonent' AND type = 'V')
    DROP VIEW vPr_OioCountMonthAbonent
GO

CREATE VIEW dbo.vPr_OioCountMonthAbonent
AS
SELECT
	AbonentId
   ,CountMonth
   ,SumBalance
   ,PeriodNumber
   ,CASE
		WHEN ISNULL(CountMonth, 0) < 1 THEN 1
		WHEN CountMonth BETWEEN 1 AND
			2 THEN 2
		WHEN CountMonth BETWEEN 3 AND 6 THEN 3
		WHEN CountMonth BETWEEN 7 AND 12 THEN 4
		WHEN CountMonth BETWEEN 13 AND
			18 THEN 5
		WHEN CountMonth BETWEEN 19 AND 24 THEN 6
		WHEN CountMonth BETWEEN 25 AND 30 THEN 7
		WHEN CountMonth BETWEEN 31 AND
			36 THEN 8
		WHEN CountMonth BETWEEN 37 AND 999 THEN 9
		ELSE 0
	END AS GroupCount
FROM dbo.Pr_OioCountMonthAbonent
GO

GRANT SELECT ON vPr_OioCountMonthAbonent TO KvzWorker
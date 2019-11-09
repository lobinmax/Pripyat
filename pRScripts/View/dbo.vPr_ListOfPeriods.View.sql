IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_ListOfPeriods' AND type = 'V')
    DROP VIEW vPr_ListOfPeriods
GO

CREATE VIEW dbo.vPr_ListOfPeriods 
AS 
SELECT 		top(100) PERCENT YEAR(ld.Date) * 100 + MONTH(ld.Date) AS PeriodNumber
FROM 		dbo.Pr_ListOfDate ld
GROUP BY 	YEAR(ld.Date) * 100 + MONTH(ld.Date)
ORDER BY 	PeriodNumber
GO

GRANT SELECT ON vPr_ListOfPeriods TO KvzWorker
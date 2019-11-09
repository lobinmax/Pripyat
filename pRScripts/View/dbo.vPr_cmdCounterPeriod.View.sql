IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmdCounterPeriod' AND type = 'V')
    DROP VIEW vPr_cmdCounterPeriod
GO
--
CREATE VIEW dbo.vPr_cmdCounterPeriod 
AS SELECT 	0 AS GroupCount, 
		'Все периоды' AS GroupName, 
		-1 AS CountMin, 
		1000 AS CountMax
UNION ALL
SELECT 	pocp.GroupCount, 
		pocp.GroupName, 
		pocp.CountMin, 
		pocp.CountMax 
FROM 	Pr_OioCounterPeriod pocp
GO
GRANT SELECT ON vPr_cmdCounterPeriod TO KvzWorker
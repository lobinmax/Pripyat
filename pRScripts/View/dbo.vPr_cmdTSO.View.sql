IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmbTSO' AND type = 'V')
    DROP VIEW vPr_cmbTSO
GO
--
CREATE VIEW dbo.vPr_cmbTSO 
AS SELECT 	'NULL' AS TSOId, 
			'Все Сетевые организации' AS TSOName
UNION ALL
SELECT 	CAST(pt.TSOId AS VARCHAR),
		pt.TSOName
FROM 	Pr_TSO pt
GO
GRANT SELECT ON vPr_cmbTSO TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmbGKO' AND type = 'V')
    DROP VIEW vPr_cmbGKO
GO
--
CREATE VIEW dbo.vPr_cmbGKO 
AS SELECT 'Все Управляющие компании' as GKOName
UNION all
SELECT * FROM 	(SELECT TOP (100) PERCENT
	ISNULL(REPLACE(e2.Name, ' - Выгрузка ДРЮЛ', ''), '') AS GKOName
FROM dbo.GKO a1
LEFT OUTER JOIN dbo.GKO a2
	ON a1.GkoId = a2.ParentId
LEFT OUTER JOIN dbo.Elements e2
	ON e2.ElementId = a2.GkoId
		AND e2.StateId <> 8
GROUP BY ISNULL(REPLACE(e2.Name, ' - Выгрузка ДРЮЛ', ''), '')
HAVING ISNULL(REPLACE(e2.Name, ' - Выгрузка ДРЮЛ', ''), '') <> ''
ORDER BY GKOName
) AS g
GO
GRANT SELECT ON vPr_cmbGKO TO KvzWorker
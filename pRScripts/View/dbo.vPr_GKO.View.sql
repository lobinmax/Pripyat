IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_GKO' AND type = 'V')
    DROP VIEW vPr_GKO
GO

CREATE VIEW [dbo].[vPr_GKO]
AS
SELECT TOP (100) PERCENT
	ISNULL(REPLACE(e2.Name, ' - Выгрузка ДРЮЛ', ''), '') AS GKOName
FROM dbo.GKO AS a1
LEFT OUTER JOIN dbo.GKO AS a2
	ON a1.GkoId = a2.ParentId
LEFT OUTER JOIN dbo.Elements AS e2
	ON e2.ElementId = a2.GkoId
		AND e2.StateId <> 8
GROUP BY ISNULL(REPLACE(e2.Name, ' - Выгрузка ДРЮЛ', ''), '')
HAVING (ISNULL(REPLACE(e2.Name, ' - Выгрузка ДРЮЛ', ''), '') <> '')
ORDER BY GKOName
GO

GRANT SELECT ON vPr_GKO TO KvzWorker


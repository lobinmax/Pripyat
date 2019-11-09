IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmbRouters' AND type = 'V')
    DROP VIEW vPr_cmbRouters
GO
--
CREATE VIEW dbo.vPr_cmbRouters 
AS
SELECT
	'NULL' AS RouterId,
	'Все маршруты' AS Router
UNION ALL
SELECT TOP(200)
	 CAST(pr.RouterId AS VARCHAR), 
	 pr.Name
FROM Pr_Routers AS pr
ORDER BY pr.RouterId
GO
GRANT SELECT ON vPr_cmbRouters TO KvzWorker
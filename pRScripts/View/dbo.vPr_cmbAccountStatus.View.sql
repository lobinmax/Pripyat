IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmbAccountStatus' AND type = 'V')
    DROP VIEW vPr_cmbAccountStatus
GO
--
CREATE VIEW dbo.vPr_cmbAccountStatus
AS 
SELECT	'NULL' AS AccountStatusId, 
		'Все состояния' AS Name
UNION ALL
SELECT 	CAST(ast.AccountStatusId AS VARCHAR), 
		ast.Name
FROM   	AccountStatus ast
GO
GRANT SELECT ON vPr_cmbAccountStatus TO KvzWorker
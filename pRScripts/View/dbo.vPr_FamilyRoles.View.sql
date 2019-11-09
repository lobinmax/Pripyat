IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_FamilyRoles' AND type = 'V')
    DROP VIEW vPr_FamilyRoles
GO
--
CREATE VIEW [dbo].[vPr_FamilyRoles]
AS
SELECT
	dbo.FamilyRoles.*
FROM dbo.FamilyRoles
GO

GRANT SELECT ON vPr_FamilyRoles TO KvzWorker

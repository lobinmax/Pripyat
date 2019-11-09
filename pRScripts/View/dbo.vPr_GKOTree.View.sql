IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_GKOTree' AND type = 'V')
    DROP VIEW vPr_GKOTree
GO
CREATE VIEW dbo.vPr_GKOTree 
AS 
SELECT
	dbo.Pr_GKStructure.Id
   ,dbo.Pr_GKStructure.ParentId
   ,GKlist.GKHName AS GKName
   ,GKlist.GKHAddress AS GKAddress
   ,GKlist.GKHEmail AS GKEmail
   ,GKlist.GKHPhone AS GKPhone
   ,GKlist.GKHPhoneMobile AS GKPhoneMobile
   ,GKlist.CreaterName
   ,GKlist.CreateDt
   ,GKlist.UpdaterName
   ,GKlist.UpdateDt
FROM dbo.Pr_GKStructure
INNER JOIN (SELECT
		GKHid
	   ,GKHName
	   ,GKHAddress
	   ,GKHEmail
	   ,GKHPhone
	   ,GKHPhoneMobile
	   ,dbo.Pr_fnsGetShortFNS('', CreaterId, 1) AS CreaterName
	   ,CreateDt
	   ,dbo.Pr_fnsGetShortFNS('', UpdaterId, 1) AS UpdaterName
	   ,UpdateDt
	FROM dbo.Pr_GKH
	UNION ALL
	SELECT
		GKOid
	   ,GKOName
	   ,GKOAddress
	   ,GKOEmail
	   ,GKOPhone
	   ,GKOPhoneMobile
	   ,dbo.Pr_fnsGetShortFNS('', CreaterId, 1) AS Creater
	   ,CreateDt
	   ,dbo.Pr_fnsGetShortFNS('', UpdaterId, 1) AS UpdaterName
	   ,UpdateDt
	FROM dbo.Pr_GKO) AS GKlist
	ON dbo.Pr_GKStructure.Id = GKlist.GKHid
GO
GRANT SELECT ON vPr_GKOTree TO KvzWorker
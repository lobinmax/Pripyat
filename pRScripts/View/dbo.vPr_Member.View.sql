IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_Member' AND type = 'V')
    DROP VIEW vPr_Member
GO

CREATE VIEW dbo.vPr_Member
AS
SELECT TOP (100) PERCENT
	Members.MemberId
   ,Members.AbonentId
   ,Members.SurName
   ,Members.Name
   ,Members.Patronymic
   ,dbo.FamilyRoles.Name AS FamilyRoles
   ,Members.FamilyRoleId
   ,Members.DtResidence
   ,Members.DtUnResidence
   ,Members.DtCreate
   ,vPerfCreater.Name AS PerfCreater
   ,Members.CreatePerformerId
   ,dbo.Pr_SexMembers.Name AS SexMembers
   ,Members.SexMembersId
   ,Members.ShareOwner
   ,Members.Residence
   ,Members.PDDateOfBirth
   ,Members.PDSeries
   ,Members.PDNumber
   ,Members.PDDateOfIssue
   ,Members.PDSubunit
   ,Members.PDSubunitCode
   ,Members.Phone
   ,Members.email
   ,Members.AddressOfLive
   ,Members.PlaceOfWork
   ,Members.DtUpdate
   ,vPerfUpdater.Name AS PerfUpdater
   ,Members.UpdatePerformerId
   ,Members.Note
FROM dbo.Pr_Members AS Members
INNER JOIN dbo.Pr_SexMembers
	ON Members.SexMembersId = dbo.Pr_SexMembers.SexMembersId
INNER JOIN dbo.FamilyRoles
	ON Members.FamilyRoleId = dbo.FamilyRoles.FamilyRoleId
INNER JOIN dbo.vPerformersName AS vPerfCreater
	ON Members.CreatePerformerId = vPerfCreater.PerformerId
INNER JOIN dbo.vPerformersName AS vPerfUpdater
	ON Members.UpdatePerformerId = vPerfUpdater.PerformerId
ORDER BY Members.AbonentId, Members.FamilyRoleId
GO

GRANT SELECT ON vPr_Member TO KvzWorker
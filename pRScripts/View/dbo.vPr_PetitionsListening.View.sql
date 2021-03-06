IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PetitionsListening' AND type = 'V')
    DROP VIEW vPr_PetitionsListening
GO

CREATE VIEW dbo.vPr_PetitionsListening
AS
SELECT TOP (100) PERCENT
	dbo.Pr_PetitionsListening.AbonentId
   ,dbo.Pr_PetitionsListening.MemberId
   ,dbo.Pr_PetitionsListening.DtPeriodStart
   ,dbo.Pr_PetitionsListening.DtPeriodEnd
   ,dbo.Pr_PetitionsListening.EnergyTypeId
   ,dbo.Pr_PetitionsListening.DtListening
   ,dbo.Pr_PetitionsListening.ListeningTypeId
   ,dbo.Pr_ListeningType.Name AS ListeningType
   ,dbo.Pr_PetitionsListening.DtPostpone
   ,dbo.Pr_PetitionsListening.PostponeReasonId
   ,dbo.Pr_PetitionsListening.DtCreate
   ,dbo.Pr_PetitionsListening.CratePerformerId
   ,dbo.Pr_PetitionsListening.DtUpdate
   ,dbo.Pr_PetitionsListening.UpdatePerformerId
FROM dbo.Pr_PetitionsListening
LEFT OUTER JOIN dbo.Pr_ListeningType
	ON dbo.Pr_PetitionsListening.ListeningTypeId = dbo.Pr_ListeningType.ListeningTypeId
ORDER BY dbo.Pr_PetitionsListening.DtListening
GO

GRANT SELECT ON vPr_PetitionsListening TO KvzWorker
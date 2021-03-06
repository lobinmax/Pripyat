IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_Petitions' AND type = 'V')
    DROP VIEW vPr_Petitions
GO

CREATE VIEW dbo.vPr_Petitions
AS
SELECT
	dbo.Pr_Petitions.AbonentId
   ,dbo.Pr_Petitions.MemberId
   ,dbo.Pr_Petitions.DtPeriodStart
   ,dbo.Pr_Petitions.DtPeriodEnd
   ,dbo.Pr_Petitions.EnergyTypeId
   ,dbo.Pr_Petitions.SerialNumberPetit
   ,dbo.Pr_Petitions.ExecutiveNumber
   ,dbo.Pr_Petitions.ExcitementDt
   ,dbo.Pr_Petitions.CopPerformerId
   ,dbo.Pr_CopPerformers.Name AS CopPerformers
   ,dbo.Pr_Petitions.DebtSumm
   ,dbo.Pr_Petitions.DtActImpossibleRecovery
   ,dbo.Pr_Petitions.ActImpossibleRecoveryId
   ,dbo.Pr_ActImpossibleRecovery.Name AS ActImpossibleRecovery
   ,dbo.Pr_Petitions.DtCompletion
   ,dbo.Pr_Petitions.Note
   ,dbo.Pr_Petitions.PeriodCreate
   ,dbo.Pr_Petitions.DtCreate
   ,dbo.Pr_Petitions.DtUpdade
   ,dbo.Pr_Petitions.CreatePerformerId
   ,dbo.vPerformers.Name AS CreatePerformer
   ,dbo.Pr_Petitions.UpdatePerformerId
   ,vPerformers_1.Name AS UpdatePerformer
FROM dbo.Pr_Petitions
INNER JOIN dbo.vPerformers
	ON dbo.Pr_Petitions.CreatePerformerId = dbo.vPerformers.PerformerId
INNER JOIN dbo.vPerformers AS vPerformers_1
	ON dbo.Pr_Petitions.UpdatePerformerId = vPerformers_1.PerformerId
LEFT OUTER JOIN dbo.Pr_ActImpossibleRecovery
	ON dbo.Pr_Petitions.ActImpossibleRecoveryId = dbo.Pr_ActImpossibleRecovery.ActImpossibleRecoveryId
LEFT OUTER JOIN dbo.Pr_CopPerformers
	ON dbo.Pr_Petitions.CopPerformerId = dbo.Pr_CopPerformers.CopPerformerId
GO

GRANT SELECT ON vPr_Petitions TO KvzWorker
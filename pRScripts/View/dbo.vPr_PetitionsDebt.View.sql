IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PetitionsDebt' AND type = 'V')
    DROP VIEW vPr_PetitionsDebt
GO

CREATE VIEW dbo.vPr_PetitionsDebt
AS
SELECT
	dbo.Pr_PetitionsDebt.AbonentId
   ,dbo.Pr_PetitionsDebt.MemberId
   ,dbo.Pr_PetitionsDebt.DtPeriodStart
   ,dbo.Pr_PetitionsDebt.DtPeriodEnd
   ,dbo.Pr_Members.Surname + ' ' + dbo.Pr_Members.Name + ' ' + dbo.Pr_Members.Patronymic AS FIO
   ,dbo.Pr_PetitionsDebt.DebtSumm
   ,dbo.Pr_PetitionsDebt.GovTax
   ,dbo.Pr_PetitionsDebt.DebtSummAfterDecision
   ,dbo.Pr_EnergyTypes.Name AS EnergyType
   ,dbo.Pr_PetitionsDebt.EnergyTypeId
   ,dbo.Pr_PetitionsDebt.DtPetitions
   ,dbo.Pr_PetitionsDebt.NumberPetitions
   ,dbo.Pr_PetitionsDebt.CourtTypeId
   ,dbo.Pr_CourtType.Name AS CourtType
   ,dbo.Pr_PetitionsDebt.PetitionTypeId
   ,dbo.Pr_PetitionType.Name AS PetitionType
   ,dbo.Pr_PetitionsDebt.DtDispatch
   ,dbo.Pr_PetitionsDebt.DtDecision
   ,dbo.Pr_PetitionsDebt.DealNumber
   ,dbo.Pr_PetitionsDebt.JudicialAreaId
   ,CAST(dbo.Pr_JudicialArea.JudicialAreaName + ' ' + dbo.Pr_JudicialArea.Number AS VARCHAR) AS JudicialNumber
   ,dbo.Pr_PetitionsDebt.DecisionNumber
   ,dbo.Pr_PetitionsDebt.DecisionTypeId
   ,dbo.Pr_DecisionType.Name AS DecisionType
   ,dbo.Pr_PetitionsDebt.DecisionTypeExtId
   ,dbo.Pr_DecisionTypeExt.Name AS DecisionTypeExt
   ,dbo.Pr_PetitionsDebt.DecisionDirectionId
   ,dbo.Pr_DecisionDirections.Name AS DecisionDirection
   ,dbo.Pr_PetitionsDebt.DtJudicialOrder
   ,dbo.Pr_PetitionsDebt.DtDecisionDirection
   ,dbo.Pr_PetitionsDebt.DtClose
   ,dbo.Pr_PetitionsDebt.ReasonForEndId
   ,dbo.Pr_ReasonForEnd.Name AS ReasonForEnd
   ,dbo.Pr_PetitionsDebt.DtUpdate
   ,dbo.Pr_PetitionsDebt.UpdatePerformerId
   ,dbo.Pr_PetitionsDebt.PeriodCreate
   ,dbo.Pr_PetitionsDebt.Note
   ,'Хранилище № "' + CAST(dbo.Pr_PetitionsPacks.PackNumber AS VARCHAR) + '" за ' + CONVERT(VARCHAR(10), dbo.Pr_PetitionsPacks.DtCreate, 104)
	+ ' (' + dbo.Pr_EnergyTypes.NameShort + ' )' AS PackName
   ,dbo.Pr_PetitionsDebt.PetitionsPacksId
FROM dbo.Pr_PetitionsDebt
INNER JOIN dbo.Pr_CourtType
	ON dbo.Pr_PetitionsDebt.CourtTypeId = dbo.Pr_CourtType.CourtTypeId
INNER JOIN dbo.Pr_PetitionType
	ON dbo.Pr_PetitionsDebt.PetitionTypeId = dbo.Pr_PetitionType.PetitionTypeId
INNER JOIN dbo.Pr_PetitionsPacks
	ON dbo.Pr_PetitionsDebt.PetitionsPacksId = dbo.Pr_PetitionsPacks.PetitionsPacksId
INNER JOIN dbo.Pr_EnergyTypes
	ON dbo.Pr_PetitionsDebt.EnergyTypeId = dbo.Pr_EnergyTypes.EnergyTypeId
LEFT OUTER JOIN dbo.Pr_DecisionTypeExt
	ON dbo.Pr_PetitionsDebt.DecisionTypeExtId = dbo.Pr_DecisionTypeExt.DecisionTypeExtId
LEFT OUTER JOIN dbo.Pr_DecisionType
	ON dbo.Pr_PetitionsDebt.DecisionTypeId = dbo.Pr_DecisionType.DecisionTypeId
LEFT OUTER JOIN dbo.Pr_ReasonForEnd
	ON dbo.Pr_PetitionsDebt.ReasonForEndId = dbo.Pr_ReasonForEnd.ReasonForEndId
LEFT OUTER JOIN dbo.Pr_DecisionDirections
	ON dbo.Pr_PetitionsDebt.DecisionDirectionId = dbo.Pr_DecisionDirections.DecisionDirectionId
LEFT OUTER JOIN dbo.Pr_JudicialArea
	ON dbo.Pr_PetitionsDebt.JudicialAreaId = dbo.Pr_JudicialArea.JudicialAreaId
LEFT OUTER JOIN dbo.Pr_Members
	ON dbo.Pr_PetitionsDebt.MemberId = dbo.Pr_Members.MemberId
		AND dbo.Pr_PetitionsDebt.AbonentId = dbo.Pr_Members.AbonentId
GO

GRANT SELECT ON vPr_PetitionsDebt TO KvzWorker
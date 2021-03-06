IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_JudicialArea' AND type = 'V')
    DROP VIEW vPr_JudicialArea
GO

CREATE VIEW dbo.vPr_JudicialArea
AS
SELECT
	dbo.Pr_JudicialArea.JudicialAreaId
   ,dbo.Pr_JudicialArea.CourtTypeId
   ,dbo.Pr_CourtType.Name AS CourtType
   ,CAST(dbo.Pr_JudicialArea.Postal AS VARCHAR(6))
	+ ', ' + dbo.Pr_JudicialArea.Adress + ' д. ' + dbo.Pr_JudicialArea.HouseNumber AS Adress
   ,dbo.Pr_JudicialArea.JudicialAreaName + ' ' + ISNULL(dbo.Pr_JudicialArea.Number, '') AS NameString
   ,dbo.Pr_JudicialArea.ZoneOfServiceId
   ,dbo.Pr_ZoneOfService.Name AS ZoneOfService
   ,dbo.Pr_JudicialArea.Number
   ,dbo.Pr_JudicialArea.CurrentJudgeId
   ,dbo.Pr_Judges.Name AS CurrentJudge
   ,dbo.Pr_JudicialArea.Phone
   ,dbo.Pr_JudicialArea.PhoneMobile
   ,dbo.Pr_JudicialArea.email
   ,dbo.Pr_JudicialArea.Site
   ,dbo.Pr_JudicialArea.Postal
   ,dbo.Pr_JudicialArea.HouseNumber
   ,dbo.Pr_JudicialArea.JudicialAreaName
   ,dbo.Pr_JudicialArea.Adress AS AdressStreet
FROM dbo.Pr_CourtType
INNER JOIN dbo.Pr_JudicialArea
	ON dbo.Pr_CourtType.CourtTypeId = dbo.Pr_JudicialArea.CourtTypeId
INNER JOIN dbo.Pr_Judges
	ON dbo.Pr_JudicialArea.CurrentJudgeId = dbo.Pr_Judges.JudgeId
INNER JOIN dbo.Pr_ZoneOfService
	ON dbo.Pr_JudicialArea.ZoneOfServiceId = dbo.Pr_ZoneOfService.ZoneOfServiceId
GO

GRANT SELECT ON vPr_JudicialArea TO KvzWorker
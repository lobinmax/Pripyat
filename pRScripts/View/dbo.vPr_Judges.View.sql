IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_Judges' AND type = 'V')
    DROP VIEW vPr_Judges
GO

CREATE VIEW dbo.vPr_Judges
AS
SELECT
	pj.JudgeId
   ,pj.CourtTypeId
   ,pj.Name
   ,pj.Phone
   ,pj.PhoneMobile
   ,pj.email
FROM dbo.Pr_Judges AS pj
GO

GRANT SELECT ON vPr_Judges TO KvzWorker
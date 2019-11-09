IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_JournalTaskSheets' AND type = 'V')
    DROP VIEW vPr_JournalTaskSheets
GO
CREATE VIEW vPr_JournalTaskSheets
AS
SELECT TOP (100) PERCENT
	   pjts.TaskSheetId, 
       pjts.CodJournalId, 
	   pjts.CodJournalDocsId,
	   pjts.JournalNumber, 
	   CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + pjts.CodJournalId + '-' + CAST(pjts.JournalNumber AS VARCHAR) AS JournalNumberLong,  
	   pjts.DocNumber,
	   CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + pjts.CodJournalDocsId + '-' + CAST(pjts.DocNumber AS VARCHAR) AS DocNumberLong,  
	   pjts.DtDocument, 
	   pjts.DtPerformance, 
	   CAST(dbo.Pr_fnsGetTaskSheetAttributes(pjts.TaskSheetId, 1) AS INT) AS DocsCount, 
	   dbo.Pr_fnsGetTaskSheetAttributes(pjts.TaskSheetId, 2) AS DocsSum, 
	   CAST(dbo.Pr_fnsGetTaskSheetAttributes(pjts.TaskSheetId, 3) AS INT) AS PrintSessionCount, 
	   dbo.Pr_fnsGetShortFNS('', (SELECT pops.AuthorId FROM Pr_OioPrintSessions AS pops WHERE pops.TaskSheetId = pjts.TaskSheetId GROUP BY pops.AuthorId), 1) AS Author,
	   dbo.Pr_fnsGetShortFNS('', pjts.AuthorId, 1) AS Giving,
	   (SELECT pops.AuthorId FROM Pr_OioPrintSessions AS pops WHERE pops.TaskSheetId = pjts.TaskSheetId GROUP BY pops.AuthorId) AS AuthorId,
	   pjts.AuthorId AS GivingId,
	   'Исполнитель(ли) задания: ' + dbo.Pr_fnsGetTaskPerformersString(pjts.TaskSheetId) AS Performers
FROM Pr_JournalTaskSheets AS pjts
ORDER BY pjts.DtDocument DESC, pjts.DocNumber
GO
GRANT SELECT ON vPr_JournalTaskSheets TO KvzWorker

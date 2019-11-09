IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_JournalBooks' AND type = 'V')
    DROP VIEW vPr_JournalBooks
GO
CREATE VIEW vPr_JournalBooks
AS
SELECT TOP (100) PERCENT
       pjb.CodJournalId, 
       CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + pjb.CodJournalId + '-' + CAST(pjb.JournalNumber AS VARCHAR) AS JournalNumberLong,
	   pjb.JournalNumber, 
	   pjt.Name, 
       pjb.JournalStatusId, 
       pjs.Name AS JournalStatus, 
       pjb.DtOpen,
       dbo.Pr_fnsGetShortFNS('', pjb.OpenPerformerId, 1) AS OpenPerformer, 
       pjb.DtClose,
       dbo.Pr_fnsGetShortFNS('', pjb.ClosePerformerId, 1) AS ClosePerformer, 
       pjb.OpenPerformerId, 
       pjb.ClosePerformerId, 
	   CAST(dbo.Pr_fnsGetJournalAttributes(pjb.CodJournalId, pjb.JournalNumber, 1) AS INT) AS DocsCount,
	   dbo.Pr_fnsGetJournalAttributes(pjb.CodJournalId, pjb.JournalNumber, 2) AS DocsSum,
	   'Примечание: ' + pjb.Notes AS Notes,
	   YEAR(pjb.DtOpen) AS Year
FROM Pr_JournalBooks AS pjb
INNER JOIN Pr_JournalStatus AS pjs ON pjb.JournalStatusId = pjs.StatusId
INNER JOIN Pr_JournaType AS pjt ON pjb.CodJournalId = pjt.CodJournalId
ORDER BY pjb.CodJournalId, pjb.DtOpen 
GO
GRANT SELECT ON vPr_JournalBooks TO KvzWorker
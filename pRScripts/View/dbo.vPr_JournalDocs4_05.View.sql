IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_JournalDocs4_05' AND type = 'V')
    DROP VIEW vPr_JournalDocs4_05
GO
CREATE VIEW vPr_JournalDocs4_05
AS
SELECT TOP (100) PERCENT
		pjd.DocId, 
		pjd.CodJournalId, 
		pjd.CodJournalDocsId, 
		pjd.JournalNumber, 
		pjd.DocNumber,
		pjd.SessionId,
		pjts.TaskSheetId,
		CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + pjts.CodJournalDocsId + '-' + CAST(pjts.DocNumber AS VARCHAR) AS TaskSheetNumberLong,
		CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + pjd.CodJournalId + '-' + CAST(pjd.JournalNumber AS VARCHAR) AS JournalNumberLong, 
		CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + pjd.CodJournalDocsId + '-' + CAST(pjd.DocNumber AS VARCHAR) AS DocNumberLong, 
		pjd.DtDocument, 
		pjd.AbonentId, 
		pjd.FamilyMemberId, 
		pjd.AbonentNumber, 
		pjd.SNP_short, 
		pjd.AddressString, 
		pjd.SumDoc, 
		pjd.DocumentTypeId,
		ISNULL(oet.prEventNameShort, 'Тип неопределен') AS DocumentType,
		pjd.ControllerId,
		dbo.Pr_fnsGetShortFNS('', pjd.ControllerId, 1) AS Controller, 
		pjd.PeriodNumber, 
		pjd.DtDoc, 
		pjd.DtBeginOio, 
		pjd.AuthorId,
		dbo.Pr_fnsGetShortFNS('', pjd.AuthorId, 1) AS Author 
FROM Pr_JournalDocs4_05 AS pjd
LEFT JOIN Abonents AS a ON pjd.AbonentId = a.AbonentId
LEFT JOIN (SELECT DISTINCT poet.KVZ_EventTypeId, poet.prEventNameShort, poet.prHouseTypeId FROM vPr_OioEventsTypes AS poet) AS oet ON pjd.DocumentTypeId = oet.KVZ_EventTypeId AND oet.prHouseTypeId = a.HousingOptionId
LEFT JOIN Pr_OioPrintSessions AS pops ON pjd.SessionId = pops.SessionId
LEFT JOIN Pr_JournalTaskSheets AS pjts ON pops.TaskSheetId = pjts.TaskSheetId
ORDER BY pjd.DtDocument, pjd.DocNumber
GO
GRANT SELECT ON vPr_JournalDocs4_05 TO KvzWorker

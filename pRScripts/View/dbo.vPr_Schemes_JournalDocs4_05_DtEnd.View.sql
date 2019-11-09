IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_Schemes_JournalDocs4_05_DtEnd' AND type = 'V')
    DROP VIEW vPr_Schemes_JournalDocs4_05_DtEnd
GO
--
CREATE VIEW vPr_Schemes_JournalDocs4_05_DtEnd
AS
SELECT			j4_05.DocId, 
				j4_05.CodJournalId, 
				j4_05.CodJournalDocsId, 
				j4_05.JournalNumber, 
				j4_05.DocNumber, 
				j4_05.SessionId, 
				jm.DtDocumentMax, 
				jm.AbonentId, 
				j4_05.FamilyMemberId, 
				j4_05.AbonentNumber, 
				j4_05.SNP_short, 
				j4_05.AddressString, 
				j4_05.SumDoc, 
				j4_05.DocumentTypeId, 
				j4_05.ControllerId, 
				j4_05.PeriodNumber, 
				j4_05.DtDoc, 
				j4_05.DtBeginOio
FROM			(
				SELECT		AbonentId, 
							MAX(DtDocument) AS DtDocumentMax
				FROM		Pr_JournalDocs4_05
				GROUP BY 	AbonentId
				) AS jm 
LEFT OUTER JOIN	Pr_JournalDocs4_05 AS j4_05 ON 	jm.AbonentId = j4_05.AbonentId AND 
												jm.DtDocumentMax = j4_05.DtDocument
--
GO
GRANT SELECT ON vPr_Schemes_JournalDocs4_05_DtEnd TO KvzWorker
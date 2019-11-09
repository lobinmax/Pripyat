IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_JournalsList' AND type = 'V')
    DROP VIEW vPr_JournalsList
GO
CREATE VIEW dbo.vPr_JournalsList
AS
-- Перечень журналов и хранимых в них документов
SELECT TOP (100) PERCENT 	d.CodJournalId + '. ' + d.Name AS JournalName, 
							ISNULL(j.CodJournalId + '. ' + jdt.Name, '0-00. Тип документа не назначен') AS DocumentsName, 
							d.CodJournalId AS ParentCodJournalId, 
							j.CodJournalId, 
							jdt.DocumentTypeId
FROM            			Pr_JournalDocumentsType AS jdt 
INNER JOIN 					Pr_JournaTypeDocs AS j ON jdt.DocumentTypeId = j.DocumentTypeId 
RIGHT OUTER JOIN 			Pr_JournaType AS d ON j.ParentCodJournalId = d.CodJournalId
ORDER BY 					ParentCodJournalId, j.CodJournalId
GO
GRANT SELECT ON vPr_JournalsList TO KvzWorker
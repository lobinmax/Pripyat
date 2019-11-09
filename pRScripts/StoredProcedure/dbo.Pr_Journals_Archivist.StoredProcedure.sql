IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Journals_Archivist' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Journals_Archivist
GO
CREATE PROCEDURE dbo.Pr_Journals_Archivist
/*
	=========================================
	|	Селекты для формы Архива документов	|
	=========================================
*/	
	@CodJournalId VARCHAR(10) = NULL,	-- Код журнала
	@CodDocsId VARCHAR(10) = NULL,		-- Код документов
	@JournalNumber INT = NULL,  
	@Function INT = 1		-- 1 - Перечень журналов
							-- 2 - Перечень документов в журнале
							-- 3 - ...
							-- 4 - ...
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- 1 - Перечень журналов
IF @Function = 1 BEGIN
	SELECT * INTO #t
	FROM vPr_JournalBooks jb
	WHERE jb.CodJournalId = ISNULL(@CodJournalId, jb.CodJournalId)
	ALTER TABLE #t ADD id INT IDENTITY
	SELECT * FROM #t 
END 

-- 2 - Перечень документов в журнале
IF @Function = 2 BEGIN 
	-- 4-03. Журнал выдачи заданий линейному контролеру
	IF @CodJournalId = '4-03' BEGIN 
		SELECT * FROM vPr_JournalTaskSheets jts 
		WHERE jts.JournalNumber = ISNULL(@JournalNumber, jts.JournalNumber) AND 
			  jts.CodJournalId = ISNULL(@CodJournalId, jts.CodJournalId) AND 
			  jts.CodJournalDocsId = ISNULL(@CodDocsId, jts.CodJournalDocsId)
	END
	-- 4-05. Журнал регистрации уведомлений и извещений о задолженности
	-- 4-09. Журнал регистрации актов об ограничении (отключении), проверки ограничений (отключений) электроэнергии
	IF @CodJournalId IN ('4-05', '4-09') BEGIN 
		SELECT * FROM vPr_JournalDocs4_05 jd 
		WHERE jd.JournalNumber = ISNULL(@JournalNumber, jd.JournalNumber) AND 
		   	  jd.CodJournalId = ISNULL(@CodJournalId, jd.CodJournalId) AND 
			  jd.CodJournalDocsId = ISNULL(@CodDocsId, jd.CodJournalDocsId)
	END
END  

-- 2 - Перечень документов в журнале (для экспорта в Excel)
IF @Function = 3 BEGIN 
	-- 4-03. Журнал выдачи заданий линейному контролеру
	IF @CodJournalId = '4-03' BEGIN 
		SELECT jts.JournalNumberLong AS [Номер журнала], 
		       jts.DocNumberLong AS [Номер листа-задания], 
			   jts.DtDocument AS [Дата листа-задания], 
			   jts.DtPerformance AS [Дата исполнения], 
			   jts.DocsCount AS [Кол-во док-тов], 
			   jts.DocsSum AS [Сумма док-тов], 
			   jts.PrintSessionCount AS [Кол-во сеансов печати], 
			   jts.Author AS [Подготовил],
			   jts.Giving AS [Выдал], 
			   jts.Performers AS [Исполнитель] 
		FROM vPr_JournalTaskSheets jts 
		WHERE jts.JournalNumber = ISNULL(@JournalNumber, jts.JournalNumber) AND 
			  jts.CodJournalId = ISNULL(@CodJournalId, jts.CodJournalId) 
	END
	-- 4-05. Журнал регистрации уведомлений и извещений о задолженности
	-- 4-09. Журнал регистрации актов об ограничении (отключении), проверки ограничений (отключений) электроэнергии
	IF @CodJournalId IN ('4-05', '4-09') BEGIN 
		SELECT jd.JournalNumberLong AS [Номер журнала], 
			   jd.DocNumberLong AS [Номер документа], 
			   jd.DtDocument AS [Дата документа], 
			   CHAR(39) + jd.AbonentNumber AS [Номер абонента], 
			   jd.SNP_short AS [ФИО], 
			   jd.AddressString AS [Адрес], 
			   jd.SumDoc AS [Сумма], 
			   jd.DocumentType AS [Мероприятие], 
			   jd.Controller AS [Контролер], 
			   jd.Author AS [Автор]
		FROM vPr_JournalDocs4_05 jd 
		WHERE jd.JournalNumber = ISNULL(@JournalNumber, jd.JournalNumber) AND 
		   	  jd.CodJournalId = ISNULL(@CodJournalId, jd.CodJournalId)
	END
END 
--DROP TABLE #t
GO
GRANT EXECUTE ON dbo.Pr_Journals_Archivist TO KvzWorker
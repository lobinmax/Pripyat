IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_Journal' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_Journal
GO

CREATE PROCEDURE [dbo].[Pr_Books_Journal]
	/*	Управление номенклатурой дел 
		в справочниках				*/
	@CodJournalId			VARCHAR(10) 	= NULL,		-- Код типа документов
	@ParentCodJournalId		VARCHAR(10) 	= NULL,		-- Код родительского журнала
	@Name					VARCHAR(200)	= NULL,		-- Наименование документов
	@DocumentTypeId			INT     		= NULL,		-- ИД документов принадлежащих журналу
	@SaveTimeYear			INT				= NULL,		-- Срок хранени, лет
	@ArticleNumber			INT				= NULL,		-- № статьи
	@Notes					VARCHAR(300)	= NULL,		-- Комментарий
	@Nodelevel				INT				= NULL,		-- 0 - Создание типа журнала
														-- 1 - Создание типов документов принадлежащих журналу
	@Function				INT				= 1	-- 1 - SELECT
												-- 2 - INSERT
												-- 3 - UPDATE
												-- 4 - DELETE

AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- Выборка
IF @Function = 1 BEGIN
SELECT			d.ParentCodJournalId, 
				d.CodJournalId, 
				d.DocumentTypeId, 
				t.Name, 
				dt.Name AS NameDocs
FROM            Pr_JournaTypeDocs AS d 
INNER JOIN		Pr_JournaType AS t ON d.ParentCodJournalId = t.CodJournalId 
INNER JOIN		Pr_JournalDocumentsType AS dt ON d.DocumentTypeId = dt.DocumentTypeId
ORDER BY		d.CodJournalId, d.ParentCodJournalId
END

-- Вставка 
IF @Function = 2 BEGIN
	-- если добавляется тип журнала
	IF @Nodelevel = 0 BEGIN
		INSERT INTO Pr_JournaType	(
									CodJournalId, 
									Name,
									SaveTimeYear, 
									ArticleNumber, 
									Notes
									)
		VALUES		(
					@CodJournalId,
					@Name,
					@SaveTimeYear,
					@ArticleNumber,
					@Notes
					)
	END
		-- если добавляется тип документа принадлежащий типу журнала
	IF @Nodelevel = 1 BEGIN
		INSERT INTO Pr_JournaTypeDocs	(
										CodJournalId, 
										ParentCodJournalId, 
										DocumentTypeId, 
										SaveTimeYear, 
										ArticleNumber, 
										Notes
										)
		VALUES		(
					@CodJournalId,
					@ParentCodJournalId,
					@DocumentTypeId,
					@SaveTimeYear,
					@ArticleNumber,
					@Notes
					)
	END
END

-- Обновление 
IF @Function = 3 BEGIN
	-- если обновляется тип журнала
	IF @Nodelevel = 0 BEGIN
		UPDATE	Pr_JournaType
		SET		CodJournalId = @CodJournalId, 
				Name = @Name, 
				SaveTimeYear = @SaveTimeYear, 
				ArticleNumber = @ArticleNumber, 
				Notes = @Notes
		WHERE   (CodJournalId = @CodJournalId)
	END
	-- если обновляется тип документа принадлежащий типу журнала
	IF @Nodelevel = 1 BEGIN
		UPDATE		Pr_JournaTypeDocs
		SET			CodJournalId = @CodJournalId, 
					ParentCodJournalId = @ParentCodJournalId, 
					DocumentTypeId = @DocumentTypeId, 
					SaveTimeYear = @SaveTimeYear, 
					ArticleNumber = @ArticleNumber, 
					Notes = @Notes
		WHERE       (CodJournalId = @CodJournalId)
	END
END

-- Удаление 
IF @Function = 4 BEGIN
	-- если выбран тип журнала
	IF @Nodelevel = 0 BEGIN
	-- сначала удаляем дочерние типы документов принадлежащих журналу
		DELETE FROM Pr_JournaTypeDocs
		WHERE		(ParentCodJournalId = @CodJournalId)
	-- Затем и тип журнала
		DELETE FROM Pr_JournaType
		WHERE        (CodJournalId = @CodJournalId)
	END	
	-- если выбран тип документа принадлежащий типу журнала
	IF @Nodelevel = 1 BEGIN
	-- сначала удаляем дочерние документы принадлежащие журналу
		DELETE FROM Pr_JournaTypeDocs
		WHERE		(CodJournalId = @CodJournalId)
	END
END
GO

GRANT EXECUTE ON dbo.Pr_Books_Journal TO KvzWorker

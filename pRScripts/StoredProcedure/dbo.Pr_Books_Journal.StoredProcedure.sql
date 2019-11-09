IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_Journal' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_Journal
GO

CREATE PROCEDURE [dbo].[Pr_Books_Journal]
	/*	���������� ������������� ��� 
		� ������������				*/
	@CodJournalId			VARCHAR(10) 	= NULL,		-- ��� ���� ����������
	@ParentCodJournalId		VARCHAR(10) 	= NULL,		-- ��� ������������� �������
	@Name					VARCHAR(200)	= NULL,		-- ������������ ����������
	@DocumentTypeId			INT     		= NULL,		-- �� ���������� ������������� �������
	@SaveTimeYear			INT				= NULL,		-- ���� �������, ���
	@ArticleNumber			INT				= NULL,		-- � ������
	@Notes					VARCHAR(300)	= NULL,		-- �����������
	@Nodelevel				INT				= NULL,		-- 0 - �������� ���� �������
														-- 1 - �������� ����� ���������� ������������� �������
	@Function				INT				= 1	-- 1 - SELECT
												-- 2 - INSERT
												-- 3 - UPDATE
												-- 4 - DELETE

AS
SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

-- �������
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

-- ������� 
IF @Function = 2 BEGIN
	-- ���� ����������� ��� �������
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
		-- ���� ����������� ��� ��������� ������������� ���� �������
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

-- ���������� 
IF @Function = 3 BEGIN
	-- ���� ����������� ��� �������
	IF @Nodelevel = 0 BEGIN
		UPDATE	Pr_JournaType
		SET		CodJournalId = @CodJournalId, 
				Name = @Name, 
				SaveTimeYear = @SaveTimeYear, 
				ArticleNumber = @ArticleNumber, 
				Notes = @Notes
		WHERE   (CodJournalId = @CodJournalId)
	END
	-- ���� ����������� ��� ��������� ������������� ���� �������
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

-- �������� 
IF @Function = 4 BEGIN
	-- ���� ������ ��� �������
	IF @Nodelevel = 0 BEGIN
	-- ������� ������� �������� ���� ���������� ������������� �������
		DELETE FROM Pr_JournaTypeDocs
		WHERE		(ParentCodJournalId = @CodJournalId)
	-- ����� � ��� �������
		DELETE FROM Pr_JournaType
		WHERE        (CodJournalId = @CodJournalId)
	END	
	-- ���� ������ ��� ��������� ������������� ���� �������
	IF @Nodelevel = 1 BEGIN
	-- ������� ������� �������� ��������� ������������� �������
		DELETE FROM Pr_JournaTypeDocs
		WHERE		(CodJournalId = @CodJournalId)
	END
END
GO

GRANT EXECUTE ON dbo.Pr_Books_Journal TO KvzWorker

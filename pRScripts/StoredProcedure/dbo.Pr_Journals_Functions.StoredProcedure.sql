IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Journals_Functions' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Journals_Functions
GO

CREATE PROCEDURE [dbo].[Pr_Journals_Functions]
	--��������� ���������� ��������� (������� �����������)

	@CodJournalId		NVARCHAR(10)	= NULL,	-- ��� ������� �����������
	@JournalNumber		INT				= NULL, -- ����� ������� �� �������
	@JournalStatus		INT				= NULL, -- ������ �������
	@Notes				VARCHAR(300)	= NULL, -- �����������
	@Function			INT	= 1			-- 1 - SELECT (�������� �������)
										-- 2 - INSERT
										-- 3 - UPDATE
										-- 4 - DELETE
AS
SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

-- �������
IF @Function = 1 BEGIN
	SELECT			jb.CodJournalId, 
					jb.DtOpen, 
					jb.JournalNumber, 
					jt.Name, 
					js.Name AS Status, 
					jb.DtClose, 
					jb.Notes, 
					jb.OpenPerformerId, 
					jb.ClosePerformerId, 
					e0.Name AS OpenPerformer, 
					e1.Name AS ClosePerformer, 
					js.StatusId
	FROM            Elements AS e0 
	INNER JOIN		Pr_JournalBooks AS jb ON e0.ElementId = jb.OpenPerformerId 
	INNER JOIN		Elements AS e1 ON jb.ClosePerformerId = e1.ElementId 
	INNER JOIN		Pr_JournaType AS jt ON jb.CodJournalId = jt.CodJournalId 
	INNER JOIN		Pr_JournalStatus AS js ON jb.JournalStatusId = js.StatusId
END

-- ��������
IF @Function = 2 BEGIN
-- ������� ����� ������
DECLARE @CountJournals INT =	(-- ��������� ���������� ����� �������� �������
								SELECT		COUNT(CodJournalId) + 1 AS CountBooks
								FROM		Pr_JournalBooks
								WHERE		(CodJournalId = @CodJournalId)
								)

	INSERT INTO Pr_JournalBooks		(
									CodJournalId,
									JournalNumber, 
									JournalStatusId, 
									DtOpen, 
									DtClose, 
									OpenPerformerId, 
									ClosePerformerId, 
									Notes
									)
	VALUES		(
				@CodJournalId,
				@CountJournals,
				1,
				GETDATE(),
				NULL,
				dbo.Kernel_GetPerformer(), -- �������� �������
				NULL,
				@Notes
				)

/* ��������� ������ ��������, 
��� ��������� ������ �� ���� ������ �� ���������
� ��������� ��*/
	UPDATE	Pr_JournalBooks 
	SET		JournalStatusId = 2, 
			DtClose =GETDATE(), 
			ClosePerformerId = dbo.Kernel_GetPerformer()
	WHERE	CodJournalId = @CodJournalId AND 
			JournalStatusId =1 AND 
			JournalNumber != @CountJournals
END

-- ����������
IF @Function = 3 BEGIN
	UPDATE	Pr_JournalBooks
	SET		Notes = @Notes
END

-- ��������
IF @Function = 4 BEGIN
	DELETE FROM		Pr_JournalBooks
	WHERE			(CodJournalId = @CodJournalId) AND 
					(JournalNumber = @JournalNumber)

	UPDATE	Pr_JournalBooks 
	SET		JournalNumber = JournalNumber - 1  
	WHERE	CodJournalId = @CodJournalId AND
			JournalNumber > @JournalNumber

--RAISERROR('�� �������� ������� ������!', 12, 1)
END
GO

GRANT EXECUTE ON dbo.Pr_Journals_Functions TO KvzWorker
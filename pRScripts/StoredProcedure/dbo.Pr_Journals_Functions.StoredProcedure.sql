IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Journals_Functions' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Journals_Functions
GO

CREATE PROCEDURE [dbo].[Pr_Journals_Functions]
	--Процедура управления журналами (книгами регистрации)

	@CodJournalId		NVARCHAR(10)	= NULL,	-- Код журнала регистрации
	@JournalNumber		INT				= NULL, -- Номер журнала по порядку
	@JournalStatus		INT				= NULL, -- Статус журнала
	@Notes				VARCHAR(300)	= NULL, -- Комментарий
	@Function			INT	= 1			-- 1 - SELECT (Создание журнала)
										-- 2 - INSERT
										-- 3 - UPDATE
										-- 4 - DELETE
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- Выборка
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

-- Создание
IF @Function = 2 BEGIN
-- создаем новый журнал
DECLARE @CountJournals INT =	(-- вычисляем порядковый номер будущего журнала
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
				dbo.Kernel_GetPerformer(), -- владелец журнала
				NULL,
				@Notes
				)

/* Созданный журнал активный, 
все остальные такого же типа делаем не активными
и завершаем их*/
	UPDATE	Pr_JournalBooks 
	SET		JournalStatusId = 2, 
			DtClose =GETDATE(), 
			ClosePerformerId = dbo.Kernel_GetPerformer()
	WHERE	CodJournalId = @CodJournalId AND 
			JournalStatusId =1 AND 
			JournalNumber != @CountJournals
END

-- Обновление
IF @Function = 3 BEGIN
	UPDATE	Pr_JournalBooks
	SET		Notes = @Notes
END

-- Удаление
IF @Function = 4 BEGIN
	DELETE FROM		Pr_JournalBooks
	WHERE			(CodJournalId = @CodJournalId) AND 
					(JournalNumber = @JournalNumber)

	UPDATE	Pr_JournalBooks 
	SET		JournalNumber = JournalNumber - 1  
	WHERE	CodJournalId = @CodJournalId AND
			JournalNumber > @JournalNumber

--RAISERROR('Не возможно удалить журнал!', 12, 1)
END
GO

GRANT EXECUTE ON dbo.Pr_Journals_Functions TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_Judges' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_Judges
GO

CREATE PROCEDURE [dbo].[Pr_Books_Judges] 
@JudgeId		INT,			-- Ид судьи
@CourtTypeId	INT,			-- ИД инстанции
@Name			VARCHAR(50),	-- ФИО судьи
@Phone			CHAR(20),		-- Телефон судьи
@PhoneMobile	VARCHAR(20),	-- Мобильный судьи
@email			VARCHAR(50),	-- Mail судьи
@Function		INT				-- 1 - SELECT
								-- 2 - INSERT
								-- 3 - UPDATE
								-- 4 - DELETE
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

IF @Function = 1 BEGIN	-- Выборка
  SELECT	Pr_Judges.*
  FROM		Pr_Judges
  WHERE     (CourtTypeId = @CourtTypeId)
  RETURN 0
END

IF @Function = 2 BEGIN			-- Новая запись
  INSERT INTO Pr_Judges
                        (
						 CourtTypeId, 
						 Name, 
						 Phone, 
						 PhoneMobile, 
						 email
						 )
  VALUES     (
			  @CourtTypeId,
			  @Name,
			  @Phone,
			  @PhoneMobile,
			  @email)
  RETURN 0
END

IF @Function = 3 BEGIN			-- Обновление записи
  UPDATE    Pr_Judges
  SET              
		CourtTypeId = @CourtTypeId, 
		Name = @Name, 
		Phone = @Phone, 
		PhoneMobile = @PhoneMobile, 
		email = @email

  WHERE (JudgeId = @JudgeId) 
   RETURN 0
END

IF @Function = 4 BEGIN			-- Удаление записи
  DELETE FROM Pr_Judges
  WHERE     (JudgeId = @JudgeId)
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_Judges TO KvzWorker

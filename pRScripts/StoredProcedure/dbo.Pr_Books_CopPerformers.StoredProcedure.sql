IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_CopPerformers' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_CopPerformers
GO

CREATE PROCEDURE [dbo].[Pr_Books_CopPerformers]
@CopPerformerId			INT = NULL,				-- Ид пристава
@Name					VARCHAR(50) = NULL,		-- ФИО пристава
@Phone					VARCHAR(20) = NULL,		-- Телефон
@PhoneMobile  			VARCHAR(20) = NULL,		-- Мобильный
@email					VARCHAR(50) = NULL,		-- Эл.почта
@Function				INT = 1		-- 1 - SELECT
									-- 2 - INSERT
									-- 3 - UPDATE
									-- 4 - DELETE
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

IF @Function = 1 BEGIN	-- Выборка
  SELECT		*
  FROM			Pr_CopPerformers
  ORDER BY		Name
END

IF @Function = 2 BEGIN			-- Новая запись
/*-- @CopPerformersId = порядковый номер
DECLARE @CountCops INT = (SELECT     COUNT(CopPerformerId) + 1 AS COUNT
                       FROM         Pr_CopPerformers)*/

  INSERT INTO Pr_CopPerformers 
              (
			   Name, 
			   Phone, 
			   PhoneMobile, 
			   Email
			  )
  VALUES       (
				@Name,
				@Phone,
				@PhoneMobile,
				@Email
			    )
END

IF @Function = 3 BEGIN			-- Обновление записи
  UPDATE    Pr_CopPerformers
  SET       Name = @Name, 
			Phone = @Phone, 
			PhoneMobile = @PhoneMobile, 
			Email = @Email
  WHERE     (CopPerformerId = @CopPerformerId) 

END

IF @Function = 4 BEGIN			-- Удаление записи
  DELETE FROM Pr_CopPerformers
  WHERE			(CopPerformerId = @CopPerformerId)
END

IF @Function = 5 BEGIN	-- Выборка для Комбов
  SELECT     CopPerformerId AS id, Name AS name
  FROM         Pr_CopPerformers
  UNION
  SELECT     NULL, ''	-- Пустая запись в начале списка
  ORDER BY Name
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_CopPerformers TO KvzWorker

IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_ActImpossible' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_ActImpossible
GO
CREATE PROCEDURE [dbo].[Pr_Books_ActImpossible]
@ActImpossibleRecoveryId	INT = NULL,			-- Ид причины акта о НВ
@Name						VARCHAR(30) = NULL,	-- Причина акта о НВ
@Function					INT = 1				-- 1 - SELECT
												-- 2 - INSERT
												-- 3 - UPDATE
												-- 4 - DELETE
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

/*IF @Function = 1 BEGIN	-- Выборка
 

END*/

/*IF @Function = 2 BEGIN			-- Новая запись


END*/

/*IF @Function = 3 BEGIN			-- Обновление записи
 

END*/

/*IF @Function = 4 BEGIN			-- Удаление записи


END*/

IF @Function = 5 BEGIN	-- Выборка для Комбов
  SELECT     ActImpossibleRecoveryId AS id, Name AS name
  FROM         Pr_ActImpossibleRecovery
  UNION all
  SELECT     NULL, ''	-- Пустая запись в начале списка
  ORDER BY Name
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_ActImpossible TO KvzWorker

IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Rms_FunctionMisc' AND type = 'P')
    DROP PROCEDURE Rms_FunctionMisc
GO
CREATE PROCEDURE dbo.Rms_FunctionMisc
/*
	=====================================
	|	Запуск задач кибер ассистента	|
	=====================================
*/

AS 
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

DECLARE @ProcedureName 	VARCHAR(70)
DECLARE @NextRumTime 	DATETIME

-- курсор для..
DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
SELECT rtl.ProcedureName FROM Rms_TaskList rtl
	OPEN  iCursor
	FETCH NEXT FROM iCursor INTO @ProcedureName
		-- пока есть след строка
	WHILE @@FETCH_STATUS = 0 BEGIN 
		-- определяем дату и время следующего запуска процедуры
		SELECT 		@NextRumTime = MAX(au.NextRumTime) 
		FROM 		dbo.Rms_AuditTasks au
		INNER JOIN 	dbo.Rms_TaskList tl ON au.TaskId = tl.TaskId
		WHERE 		tl.ProcedureName = @ProcedureName
		-- если дата и время меньше текущего или пусто
		IF @NextRumTime <= GETDATE() OR @NextRumTime IS NULL BEGIN
			EXEC @ProcedureName
		END
	-- след строка курсора	
	FETCH NEXT FROM iCursor INTO @ProcedureName
	END  
	CLOSE iCursor
DEALLOCATE iCursor
GO
GRANT EXECUTE ON Rms_FunctionMisc TO KvzWorker

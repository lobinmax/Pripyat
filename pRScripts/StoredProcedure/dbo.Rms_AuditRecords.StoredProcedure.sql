IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Rms_AuditRecords' AND type = 'P')
    DROP PROCEDURE Rms_AuditRecords
GO
CREATE PROCEDURE dbo.Rms_AuditRecords
/*
	=========================================================
	|	Запись в аудит выполненных задач кибар ассистентом	|
	=========================================================
*/
	@ProcedureName	VARCHAR(70),		-- Имя выполненной процедуры
	@TaskStatusId 	INT 				-- Статус задачи
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка
 
DECLARE @TaskId 		INT			-- Ид задачи ассистента
DECLARE @NextRumTime 	DATETIME	-- Время следующего запуска задачи
DECLARE @MinuteCount 	INT 		-- Переодичность запуска задачи, в минутах
DECLARE @TimeBreak	 	INT 		-- Кол-во минут перерыва между задачами

-- определяем Ид задачи
SELECT 	@TaskId = rtl.TaskId, 
		@MinuteCount = rtl.RunTimeMinute 
FROM 	Rms_TaskList rtl 
WHERE 	rtl.ProcedureName = @ProcedureName

-- Определяем кол-во часов с последнего запуска
SELECT @TimeBreak = DATEDIFF(MINUTE, (SELECT MAX(rat.RunTime) FROM Rms_AuditTasks rat),GETDATE())

-- определяем время следующего запуска
-- если был перерыв или это первый запуск
IF @TimeBreak > @MinuteCount OR @TimeBreak IS NULL BEGIN
	SET @NextRumTime = DATEADD(MINUTE, @MinuteCount, GETDATE())
END

-- если нет, прибавляем к последнему запуску двойную переодичность
ELSE BEGIN
	SELECT 	@NextRumTime = DATEADD(MINUTE, @MinuteCount * 2, MAX(rat.RunTime))  
	FROM 	Rms_AuditTasks rat 
	WHERE 	rat.TaskId = @TaskId
END

-- запись аудита
INSERT INTO Rms_AuditTasks
SELECT 		@TaskId, GETDATE(), @NextRumTime, @TaskStatusId
GO
GRANT EXECUTE ON Rms_AuditRecords TO KvzWorker
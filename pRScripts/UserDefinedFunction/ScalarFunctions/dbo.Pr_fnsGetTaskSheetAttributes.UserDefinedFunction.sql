IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetTaskSheetAttributes' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetTaskSheetAttributes
GO
CREATE FUNCTION dbo.Pr_fnsGetTaskSheetAttributes
/*
	=============================================================
	|	Получение атрибутов по коду листа выдачи задания		|
	=============================================================
*/
(
	@TaskSheetId 	INT, 		-- ИД листа задания
	@Parameter 		INT			-- 1 - Кол-во документов
								-- 2 - Сумма документов в листе задания
								-- 3 - Кол-во сеансов печати
)
RETURNS NUMERIC(12, 2) 
AS
BEGIN
DECLARE @Value NUMERIC(12, 2) = 0

-- 1 - Кол-во документов
IF @Parameter = 1 BEGIN 
	SELECT @Value = COUNT(pjd.DocId)
	FROM Pr_JournalDocs4_05 AS pjd 
	WHERE pjd.SessionId IN (
							SELECT pops.SessionId 
							FROM Pr_OioPrintSessions AS pops 
							WHERE pops.TaskSheetId = @TaskSheetId
							)
END 

-- 2 - Сумма документов в листе задания
IF @Parameter = 2 BEGIN 
	SELECT @Value = SUM(pjd.SumDoc)
	FROM Pr_JournalDocs4_05 AS pjd 
	WHERE pjd.SessionId IN (
							SELECT pops.SessionId 
							FROM Pr_OioPrintSessions AS pops 
							WHERE pops.TaskSheetId = @TaskSheetId
							)
END 

-- 3 - Кол-во сеансов печати
IF @Parameter = 3 BEGIN 
	SELECT @Value = COUNT(pops.SessionId) 
	FROM Pr_OioPrintSessions AS pops 
	WHERE pops.TaskSheetId = @TaskSheetId
END 
RETURN @Value
END
GO
GRANT EXECUTE ON Pr_fnsGetTaskSheetAttributes TO KvzWorker
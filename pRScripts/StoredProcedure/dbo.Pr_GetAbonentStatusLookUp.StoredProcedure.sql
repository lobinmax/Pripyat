IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetAbonentStatusLookUp' AND type = 'P')
    DROP PROCEDURE Pr_GetAbonentStatusLookUp
GO
CREATE PROCEDURE dbo.Pr_GetAbonentStatusLookUp
/*
	=============================================
	|	Выгрузка Статусов и причин абонентов	|
	|	для элементов TreeListLokkUpEdit		|
	=============================================
*/
	@IsRoot		BIT = 0			-- 1 - первый узел "Все Управляющие"; 0 - Первый узел УК
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

DECLARE @IsRootId INT = 99999
IF @IsRoot = 0 BEGIN SET @IsRootId = @IsRoot END

CREATE TABLE #AbonentStatus	(
							 Id INT, 
							 ParentId INT, 
							 Name VARCHAR(100), 			
							 StatusString VARCHAR(100),		
							 AbonentStatusId VARCHAR(10),
							 ExtAbonentStatusId VARCHAR(10),	
							 AbonentStatus VARCHAR(100),
							 ExtAbonentStatus VARCHAR(100)
							)
IF @IsRoot = 1 BEGIN
	INSERT INTO #AbonentStatus
	SELECT @IsRootId, NULL, 'Все состояния', 'Все состояния', 'NULL', 'NULL', 'NULL', 'NULL'
END

-- Состояния
INSERT INTO #AbonentStatus
SELECT		ast.AbonentStatusId, 
			@IsRootId, 
			ast.Name, 
			ast.Name + ' (Все причины)',
			ast.AbonentStatusId, 
			'NULL', 
			ast.Name, 
			'NULL'
FROM 		AbonentStatus ast 
ORDER BY  	ast.AbonentStatusId

-- Причины
INSERT INTO #AbonentStatus
SELECT 	 eas.ExtAbonentStatusId, eas.AbonentStatusId, eas.Name, ast.Name + ' (' + eas.Name + ')', ast.AbonentStatusId, eas.ExtAbonentStatusId, ast.Name, eas.Name 
FROM ExtAbonentStatus eas
INNER JOIN AbonentStatus ast ON eas.AbonentStatusId = ast.AbonentStatusId
ORDER BY eas.AbonentStatusId, eas.ExtAbonentStatusId

SELECT * FROM #AbonentStatus 
GO
GRANT EXECUTE ON Pr_GetAbonentStatusLookUp TO KvzWorker
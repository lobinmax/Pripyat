IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetLookUp_JournalTypes' AND type = 'P')
    DROP PROCEDURE dbo.Pr_GetLookUp_JournalTypes
GO
CREATE PROCEDURE dbo.Pr_GetLookUp_JournalTypes
/*
	=========================================
	|	Выгрузка Типов журналов				|
	|	для элементов TreeListLokkUpEdit	|
	=========================================
*/	
	@IsRoot  			BIT = 0, 	-- 1 - первый узел "Все журналы"; 0 - Только журналы
	@DelWithoutChild 	BIT = 0, 	-- Удаление узлов без дочерних элементов
	@IsExpandedRoot		BIT = 1, 	-- Развоворот Root узла
	@IsExpandedJournal 	BIT = 0,	-- Разворот узла журналами
	@IsExpandedDocumets BIT = 0, 	-- Разворот узла с типами документов
	@ExpandedAll		BIT = 0		-- Развернуть все узлы

AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @IsRootId INT = 99999
IF @IsRoot = 0 BEGIN SET @IsRootId = @IsRoot END
IF @ExpandedAll = 1 BEGIN 
	SET @IsExpandedRoot = 1
	SET @IsExpandedJournal = 1
	SET @IsExpandedDocumets = 1
END 

-- Root запись 
IF @IsRoot = 1 BEGIN
	CREATE TABLE #RootRecord
	(
	Id INT,
	ParentId INT,
	Code VARCHAR(5),
	Name VARCHAR(300),
	TypeName VARCHAR(300),
	JournalCode VARCHAR(10),
	DocumentCode VARCHAR(10),
	JournalName VARCHAR(300),
	DocumentName VARCHAR(300),
	DocumentTypeId INT, 
	IsExpanded BIT
	)
	INSERT INTO #RootRecord
	SELECT @IsRootId, NULL, NULL, 'Все журналы', 'NULL', 'NULL', 'NULL', NULL, NULL, NULL, @IsExpandedRoot
END

-- Типы журналов
CREATE TABLE #JournalTypes
(
Id INT IDENTITY (100, 10),
ParentId INT,
Code VARCHAR(5),
Name VARCHAR(300),
TypeName VARCHAR(300),
JournalCode VARCHAR(10),
DocumentCode VARCHAR(10),
JournalName VARCHAR(300),
DocumentName VARCHAR(300),
DocumentTypeId INT, 
IsExpanded BIT
)
INSERT INTO #JournalTypes
SELECT @IsRootId, pjt.CodJournalId, pjt.CodJournalId + '. ' + pjt.Name, pjt.Name, '''' + pjt.CodJournalId + '''', 'NULL', pjt.Name, NULL, NULL, @IsExpandedJournal
FROM Pr_JournaType AS pjt
ORDER BY pjt.CodJournalId

-- Типы документов
CREATE TABLE #DocsTypes
(
Id INT IDENTITY (1000, 110),
ParentId INT,
Code VARCHAR(5),
Name VARCHAR(300),
TypeName VARCHAR(300),
JournalCode VARCHAR(10),
DocumentCode VARCHAR(10),
JournalName VARCHAR(300),
DocumentName VARCHAR(300),
DocumentTypeId INT, 
IsExpanded BIT
)
INSERT INTO #DocsTypes
SELECT jt.Id, pjtd.CodJournalId, pjtd.CodJournalId + '. ' + pjdt.Name, pjdt.Name, '''' + jt.Code + '''', '''' + pjtd.CodJournalId + '''', jt.Name, pjdt.Name, pjtd.DocumentTypeId, @IsExpandedDocumets
FROM Pr_JournaTypeDocs AS pjtd
INNER JOIN #JournalTypes AS jt ON pjtd.ParentCodJournalId = jt.Code
INNER JOIN Pr_JournalDocumentsType AS pjdt ON pjtd.DocumentTypeId = pjdt.DocumentTypeId
ORDER BY pjtd.CodJournalId

-- удаление узлов без дочерних элементов
IF @DelWithoutChild = 1 BEGIN  
	DELETE FROM #JournalTypes WHERE Id NOT IN 
	( 
	SELECT jt.Id
	FROM Pr_JournaTypeDocs AS pjtd
	INNER JOIN #JournalTypes AS jt ON pjtd.ParentCodJournalId = jt.Code
	INNER JOIN Pr_JournalDocumentsType AS pjdt ON pjtd.DocumentTypeId = pjdt.DocumentTypeId
	)
END  

-- Конечная выборка
IF @IsRoot = 1 BEGIN
	SELECT * FROM #RootRecord AS rr
	UNION
	SELECT * FROM #JournalTypes AS jt
	UNION
	SELECT * FROM #DocsTypes AS dt
	ORDER BY rr.ParentId, rr.Id
END 
ELSE BEGIN
	SELECT * FROM #JournalTypes AS jt
	UNION
	SELECT * FROM #DocsTypes AS dt
	ORDER BY jt.ParentId, jt.Id
END
GO
GRANT EXECUTE ON dbo.Pr_GetLookUp_JournalTypes TO KvzWorker
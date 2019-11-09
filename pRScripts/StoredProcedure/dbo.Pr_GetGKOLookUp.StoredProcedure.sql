IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetGKOLookUp' AND type = 'P')
    DROP PROCEDURE Pr_GetGKOLookUp
GO
CREATE PROCEDURE dbo.Pr_GetGKOLookUp
/*
	=========================================
	|	Выгрузка Управляющих организаций	|
	|	для элементов TreeListLokkUpEdit	|
	=========================================
*/
	-- Выгрузка Управляющих организаций
	@IsRoot	BIT = 0	-- 1 - первый узел "Все Управляющие"; 0 - Первый узел УК
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

DECLARE @IsRootId INT = 99999
IF @IsRoot = 0 BEGIN SET @IsRootId = @IsRoot END

CREATE TABLE #GKO(
				  Id INT, 
				  ParentId INT, 
				  Name VARCHAR(100), 			-- имя организации
				  Address VARCHAR(100),			-- адрес организации
				  CreaterName VARCHAR(100),
				  CreateDt SMALLDATETIME,
				  UpdaterName VARCHAR(100),
				  UpdateDt SMALLDATETIME,
				  GKType VARCHAR(50), 			-- тип выбранного узла
				  GKString VARCHAR(200), 		-- выбранный узел одной строкой
				  GKOId VARCHAR(50), 
				  GKHId VARCHAR(50), 
				  GKOName VARCHAR(100), 
				  GKHName VARCHAR(100), 
				 )
IF @IsRoot = 1 BEGIN
	INSERT INTO #GKO
	SELECT @IsRootId, NULL, 'Все Управляющие', 'Все Управляющие', NULL, NULL, NULL, NULL, 'NULL', 'Все Управляющие', 'NULL', 'NULL', 'NULL', 'NULL' 
END

-- Управляющие
INSERT INTO #GKO
SELECT		pg.GKOId, 
			@IsRootId, 
			pg.GKOName,
			pg.GKOAddress,
			dbo.Pr_fnsGetShortFNS('',pg.CreaterId, 1),
			pg.CreateDt,
			dbo.Pr_fnsGetShortFNS('',pg.UpdaterId, 1),
			pg.UpdateDt,
			'GKO',
			'УК: ' + pg.GKOName + ' | ОК: Все',
			pg.GKOId,
			CAST('NULL' AS VARCHAR),
			pg.GKOName,
			'NULL'
FROM 		Pr_GKO pg 
ORDER BY 	pg.GKOName

-- Обслуживающие
INSERT INTO #GKO
SELECT 	pg.GKHid,
		pg1.ParentId,
		pg.GKHName,
		pg.GKHAddress,
		dbo.Pr_fnsGetShortFNS('',pg.CreaterId, 1),
		pg.CreateDt,
		dbo.Pr_fnsGetShortFNS('',pg.UpdaterId, 1),
		pg.UpdateDt,
		'GKH',
		'УК: ' + pg2.GKOName + ' | ОК: ' + pg.GKHName,
		pg2.GKOId,
		pg.GKHid,
		pg2.GKOName,
		pg.GKHName
FROM Pr_GKH pg
INNER JOIN Pr_GKStructure pg1 ON pg.GKHid = pg1.Id
INNER JOIN Pr_GKO pg2 ON pg1.ParentId = pg2.GKOId

SELECT * FROM #GKO g
GO
GRANT EXECUTE ON Pr_GetGKOLookUp TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetInspectorsLookUp' AND type = 'P')
    DROP PROCEDURE Pr_GetInspectorsLookUp
GO
CREATE PROCEDURE dbo.Pr_GetInspectorsLookUp
/*
	=============================================
	|	Выгрузка иерархии контролеров			|
	|	для элементов TreeListLokkUpEdit		|
	=============================================
*/
	@IsExpManager		BIT = 1,	-- развернуть узел Руководитель
	@IsExpChief			BIT = 0,	-- развернуть узел Ст. контролеры
	@IsExpController	BIT = 0,	-- развернуть узел Лин. контролеры
	@IsExpRouter		BIT = 0		-- развернуть узел Маршруты
AS
  
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

DECLARE @tManager TABLE (Id INT, ParentId INT, Name VARCHAR(200))		-- Руководитель
DECLARE @tChief TABLE (Id INT, ParentId INT, Name VARCHAR(200))			-- Старший контролер
DECLARE @tController TABLE (Id INT, ParentId INT, Name VARCHAR(200))	-- Линейный контролер
DECLARE @tRouter TABLE (Id INT, ParentId INT, Name VARCHAR(200))		-- Маршрут

-- Руководитель
INSERT INTO @tManager
SELECT e.ElementId AS Id, 0 AS ParentId, e.Name
FROM Elements e 
WHERE e.ElementId = (SELECT ppc.Value FROM Pr_PripyatConstants ppc WHERE ppc.Id = 1) AND e.ElemTypeId = 4

-- Старший контролер
INSERT INTO @tChief
SELECT e.ElementId, ig.ChiefInspectorId, e.Name
FROM InspectorGroups AS ig 
INNER JOIN Elements AS e ON e.ElementId = ig.InspectorId
WHERE (ig.ChiefInspectorId IN (SELECT Id FROM @tManager))
GROUP BY e.ElementId, e.Name, ig.ChiefInspectorId
ORDER BY e.Name

-- Линейный контролер
INSERT INTO @tController
SELECT e.ElementId, ig.ChiefInspectorId, e.Name
FROM InspectorGroups AS ig 
INNER JOIN Elements AS e ON e.ElementId = ig.InspectorId 
WHERE (ig.ChiefInspectorId IN (SELECT Id FROM @tChief))
GROUP BY e.ElementId, e.Name, ig.ChiefInspectorId
ORDER BY e.Name

-- Маршрут
INSERT INTO @tRouter
SELECT ISNULL(r.RouterId, 0) AS RouterId, e.ElementId, ISNULL(r.Name, 'Без маршрута') AS Name 
FROM Pr_Abonents AS pa
INNER JOIN Abonents AS a ON pa.AbonentId = a.AbonentId 
INNER JOIN InspectorGroups AS ig 
INNER JOIN Elements AS e ON e.ElementId = ig.InspectorId ON a.ControllerId = e.ElementId 
LEFT OUTER JOIN Pr_Routers AS r ON pa.RouterId = r.RouterId
GROUP BY r.RouterId, e.ElementId, r.Name
HAVING (e.ElementId IN (SELECT Id FROM @tController))
ORDER BY e.ElementId, r.Name

-- проверяем есть ли реальные маршруты
-- если только БМ то очищаем таблицу маршрутов
IF (SELECT COUNT(r.Name) FROM (SELECT DISTINCT Name FROM @tRouter) AS r) <= 1 BEGIN 
	DELETE FROM @tRouter
END 

-- Руководитель
SELECT 	tM.Id, 
		tM.ParentId, 
		tM.Name, 
		dbo.Pr_fnsGetShortFNS('', tM.id, 1) AS ShortName, 
		'Manager' AS Type, 
		'Рук-ль: ' + dbo.Pr_fnsGetShortFNS('', tM.id, 1) AS Role,
		CAST(tM.Id AS VARCHAR) AS ManagerId,
		'NULL' AS ChiefId,
		'NULL' AS ControllerId,
		'NULL' AS RouterId,
		tM.Name AS ManagerName,
		'NULL' AS ChiefName,
		'NULL' AS ControllerName,
		'NULL' AS RouterName,
		dbo.Pr_fnsGetShortFNS('', tM.id, 1) AS ManagerShortName,
		'NULL' AS ChiefShortName,
		'NULL' AS ControllerShortName,
		'NULL' AS RouterShortName,
		@IsExpManager AS IsExpanded
FROM @tManager AS tM
UNION ALL

-- Старший контролер
SELECT 	tCh.Id, 
		tCh.ParentId, 
		tCh.Name,
		dbo.Pr_fnsGetShortFNS('', tCh.id, 1) AS ShortName,
		'Chief' AS Type, 
		'Кон-р IIIр: ' + dbo.Pr_fnsGetShortFNS('', tCh.id, 1) AS Role,
		CAST(tm.Id AS VARCHAR) AS ManagerId,
		CAST(tCh.Id AS VARCHAR) AS ChiefId,
		'NULL' AS ControllerId,
		'NULL' AS RouterId,
		tM.Name AS ManagerName,
		tch.Name AS ChiefName,
		'NULL' AS ControllerName,
		'NULL' AS RouterName,
		dbo.Pr_fnsGetShortFNS('', tM.id, 1) AS ManagerShortName,
		dbo.Pr_fnsGetShortFNS('', tCh.id, 1) AS ChiefShortName,
		'NULL' AS ControllerShortName,
		'NULL' AS RouterShortName,
		@IsExpChief AS IsExpanded
FROM @tChief AS tCh
LEFT JOIN @tManager tM ON tCh.ParentId = tM.Id
UNION ALL

-- Линейный контролер
SELECT 	tC.Id, 
		tC.ParentId, 
		tC.Name,
		dbo.Pr_fnsGetShortFNS('', tC.id, 1) AS ShortName,
		'Controller' AS Type, 
		'Кон-р IIр: ' + dbo.Pr_fnsGetShortFNS('', tC.id, 1) AS Role,
		CAST(tm.Id AS VARCHAR) AS ManagerId,
		CAST(tCh.Id AS VARCHAR) AS ChiefId,
		CAST(tc.Id AS VARCHAR) AS ControllerId,
		'NULL' AS RouterId,
		tM.Name AS ManagerName,
		tch.Name AS ChiefName,
		tc.Name AS ControllerName,
		'NULL' AS RouterName,
		dbo.Pr_fnsGetShortFNS('', tM.id, 1) AS ManagerShortName,
		dbo.Pr_fnsGetShortFNS('', tCh.id, 1) AS ChiefShortName,
		dbo.Pr_fnsGetShortFNS('', tc.id, 1) AS ControllerShortName,
		'NULL' AS RouterShortName,
		@IsExpController AS IsExpanded
FROM @tController AS tC
INNER JOIN @tChief tCh
INNER JOIN @tManager tM ON tCh.ParentId = tM.Id ON tc.ParentId = tCh.Id	
UNION ALL

-- Маршрут
SELECT 	(tc.Id + 10000) - tR.Id,
		tR.ParentId, 
		tR.Name,
		CASE WHEN tr.Name = 'Без маршрута' THEN 'БМ' ELSE LEFT(tR.Name, 1) + RIGHT(tR.Name, 1) END AS ShortName,
		'Router' AS Type, 
		'Кон-р IIр: ' + dbo.Pr_fnsGetShortFNS('', tC.id, 1) + ' | ' + tR.Name AS Role,
		CAST(tm.Id AS VARCHAR) AS ManagerId,
		CAST(tCh.Id AS VARCHAR) AS ChiefId,
		CAST(tc.Id AS VARCHAR) AS ControllerId,
		CAST((tc.Id + 10000) - tR.Id AS VARCHAR) AS RouterId,
		tM.Name AS ManagerName,
		tch.Name AS ChiefName,
		tc.Name AS ControllerName,
		tR.Name AS RouterName,
		dbo.Pr_fnsGetShortFNS('', tM.id, 1) AS ManagerShortName,
		dbo.Pr_fnsGetShortFNS('', tCh.id, 1) AS ChiefShortName,
		dbo.Pr_fnsGetShortFNS('', tc.id, 1) AS ControllerShortName,
		tR.Name AS RouterShortName,
		@IsExpRouter AS IsExpanded
FROM @tRouter AS tR
INNER JOIN @tController AS tC 
INNER JOIN @tChief tCh ON tc.ParentId = tCh.Id
INNER JOIN @tManager tM ON tCh.ParentId = tM.Id ON tR.ParentId = tC.Id
GO
GRANT EXECUTE ON Pr_GetInspectorsLookUp TO KvzWorker
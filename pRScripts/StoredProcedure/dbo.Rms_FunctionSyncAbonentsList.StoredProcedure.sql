IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Rms_FunctionSyncAbonentsList' AND type = 'P')
    DROP PROCEDURE Rms_FunctionSyncAbonentsList
GO
CREATE PROCEDURE dbo.Rms_FunctionSyncAbonentsList
/*
	=========================================================================
	|	Синхронизация кол-ва абонентов и ТУ базы Квазар с базой Припять		|
	=========================================================================
*/

AS 
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

BEGIN TRANSACTION
	DECLARE @TaskStatusId INT 						-- Статус задачи
	DECLARE @ProcedureName VARCHAR(70) 				-- имя выполняемой процедуры
	SELECT 	@ProcedureName = object_name(@@procid)	-- имя самой процедуры

	-- Удаление несуществующих ТУ
	DELETE FROM Pr_Points
	WHERE PointId IN 	(
						SELECT 	pP.PointId
						FROM 	dbo.Pr_Points pP
						LEFT OUTER JOIN dbo.Points pQ ON pP.PointId = pQ.PointId
						WHERE	pQ.PointId IS NULL
						)

	-- Удаление несуществующих абонентов
	DELETE FROM	Pr_Abonents 
	WHERE 		AbonentId IN 	(
								SELECT 	aP.AbonentId
								FROM 	dbo.Pr_Abonents aP
								LEFT OUTER JOIN dbo.Abonents aQ ON aP.AbonentId = aQ.AbonentId
								WHERE	aQ.AbonentId IS NULL
								)

	-- Добавление новых абонентов
	INSERT INTO 	Pr_Abonents
	SELECT			aQ.AbonentId, NULL AS GKHid, NULL AS CityPartsId, NULL AS RouterId
	FROM			Abonents AS aQ 
	LEFT OUTER JOIN Pr_Abonents AS aP ON aQ.AbonentId = aP.AbonentId
	WHERE        	aP.AbonentId IS NULL
	
	-- Добавление новых ТУ
	INSERT INTO Pr_Points
	SELECT		pQ.PointId, pQ.AbonentId, NULL AS TSOId
	FROM		Points AS pQ 
	LEFT OUTER JOIN Pr_Points AS pP ON pQ.PointId = pP.PointId
	WHERE		pQ.AbonentId IS NOT NULL AND pP.PointId IS NULL

	-- если есть ошибки отменяем все манипуляции
	IF @@error != 0 BEGIN 
		ROLLBACK TRANSACTION 
		SET @TaskStatusId = 2
	END 
	ELSE BEGIN 
		COMMIT TRANSACTION 
		SET @TaskStatusId = 1
	END

	-- Запись удита по Рамзи
	EXEC Rms_AuditRecords @ProcedureName, @TaskStatusId
GO
GRANT EXECUTE ON Rms_FunctionSyncAbonentsList TO KvzWorker
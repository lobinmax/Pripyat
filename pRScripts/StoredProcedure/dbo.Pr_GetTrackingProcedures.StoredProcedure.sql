IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetTrackingProcedures' AND type = 'P')
    DROP PROCEDURE Pr_GetTrackingProcedures
GO
CREATE PROCEDURE dbo.Pr_GetTrackingProcedures
	/*
	=================================================================	
	|	Функция для обработки отслеживаемых процедур ПК Припять	    |
	=================================================================		
	*/
	@ProcedureName 		VARCHAR(100), 			-- Имя отслеживаемой процедуры
	@Notes				TEXT 			= NULL,	-- Комментарий к процедуре
	@Function			INT  			= 0, 	-- Параметр
												-- 0 - проверка на изменение
												-- 1 - изменение данных о процедуре
	@Result 			INT = 0 				-- Для записи кодов ошибок							
AS 
SET NOCOUNT ON
SET XACT_ABORT ON -- Всегда откатывать по ошибке
/* Коды ошибок (Реторнов)
	0 - холстая
	1 - процедура была модифицирована
	2 - процедура не изменялась
	3 - процедура не добывлена в реестр отслеживаний
*/
DECLARE @DtLastUpdate DATETIME = (SELECT o.modify_date FROM sys.objects o WHERE o.name = @ProcedureName AND o.type = 'P') 			-- дата изменения оригинала
DECLARE @DtTreckingUpdate DATETIME = (SELECT ptp.DtUpdate FROM Pr_TrackingProcedures ptp WHERE ptp.ProcedureName = @ProcedureName) 	-- дата изменения в dbo.Pr_TrackingProcedures

	-- 0 - проверка на изменение
	IF @Function = 0 BEGIN
		IF 	EXISTS(SELECT * FROM Pr_TrackingProcedures ptp WHERE ptp.ProcedureName = @ProcedureName) BEGIN 
			IF @DtLastUpdate != @DtTreckingUpdate BEGIN
				SET @Result = 1
			END
			ELSE BEGIN
				SET @Result = 2
			END 
		END
		ELSE BEGIN
				SET @Result = 3
		END 
	END

	-- 1 - изменение или добавление данных о процедуре 
	IF @Function = 1 BEGIN
		-- если отслеживаемая таблица занесена в реестр
		IF EXISTS(SELECT * FROM Pr_TrackingProcedures ptp WHERE ptp.ProcedureName = @ProcedureName) BEGIN
			UPDATE dbo.Pr_TrackingProcedures SET DtUpdate = @DtLastUpdate WHERE ProcedureName = @ProcedureName
		END
		ELSE BEGIN
			INSERT dbo.Pr_TrackingProcedures (ProcedureName, DtUpdate, Note) VALUES (@ProcedureName, @DtLastUpdate, @Notes)
		END  
	END
SELECT  @Result
GO
GRANT EXECUTE ON Pr_GetTrackingProcedures TO KvzWorker
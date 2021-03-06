IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PrintSessions' AND type = 'P')
    DROP PROCEDURE Pr_PrintSessions
GO
CREATE PROCEDURE dbo.Pr_PrintSessions
	/*
	=================================	
	|	Процедура для обработки		|
	|	сеансов печати уведомлений	|
	=================================
	*/
	@SessionId				INT				= NULL, -- ИД сеанса печати
	@DtSession				SMALLDATETIME	= NULL, -- Дата сеанса
	@AuthorId				INT				= NULL, -- Автор печати
	@UserName				VARCHAR(20)		= NULL, -- Имя автора сеанса
	@HostName				VARCHAR(20)		= NULL, -- Имя компьютера автора сеанса
	@PrinterName			VARCHAR(100)	= NULL, -- Имя печатающего принтера
	@Copies					TINYINT			= NULL, -- Количество копий
	@fltr_ControllerId		INT				= NULL, -- Фильтр по контролеру
	@fltr_Gko				VARCHAR(200)	= NULL, -- Фильтр по УК
	@fltr_RouterId			INT				= NULL, -- Фильтр по маршруту
	@fltr_ArealId			INT				= NULL, -- Фильтр по Админ единице
	@fltr_CityVillageId		INT				= NULL, -- Фильтр по району
	@fltr_AddressPartId		int				= NULL, -- Фильтр по улице
	@fltr_BalanceMin		NUMERIC(10, 2)	= NULL, -- Фильтр по сальдо мин
	@fltr_BalanceMax		NUMERIC(10, 2)	= NULL, -- Фильтр по сальдо макс
	@fltr_CountMonthMin		INT				= NULL, -- Фильтр по периоду ДЗ мин
	@fltr_CountMonthMax		INT				= NULL, -- Фильтр по периоду ДЗ макс
	@fltr_prHouseTypeId		TINYINT			= NULL, -- Фильтр по типу жилья
	@fltr_DocTypeNotice		VARCHAR(100)	= NULL, -- Фильтр по типу документа

	@Function				INT				= 1,	-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
	@Parameter				INT				= 1    	-- Параметр селекта
													-- 1 - обычный перечень сеансов печати
													-- 2 - кол - во документов в сеансе печати	
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- 1 - SELECT
IF @Function = 1 BEGIN
	-- 1 - обычный перечень сеансов печати
	/*IF @Parameter = 1 BEGIN

	END*/
	-- 2 - кол - во документов в сеансе печати
	IF @Parameter = 2 BEGIN
		SELECT	COUNT(j.DocId) AS iCount
		FROM 	dbo.Pr_JournalDocs4_05 AS j
		WHERE 	j.SessionId = @SessionId	
	END
END

-- Создание сессии печати
IF @function = 2 BEGIN
	BEGIN TRANSACTION 
		INSERT INTO Pr_OioPrintSessions (
										DtSession, 
										AuthorId,
										UserName, 
										HostName, 
										PrinterName, 
										Copies, 
										fltr_ControllerId, 
										fltr_Gko, 
										fltr_RouterId, 
										fltr_ArealId, 
										fltr_CityVillageId, 
										fltr_AddressPartId, 
										fltr_BalanceMin, 
										fltr_BalanceMax, 
										fltr_CountMonthMin, 
										fltr_CountMonthMax, 
										fltr_prHouseTypeId, 
										fltr_DocTypeNotice
										)
		VALUES		(
					GETDATE(),
					dbo.Kernel_GetPerformer(),
					@UserName,
					@HostName,
					@PrinterName,
					@Copies,
					@fltr_ControllerId,
					@fltr_Gko,
					@fltr_RouterId,
					@fltr_ArealId,
					@fltr_CityVillageId,
					@fltr_AddressPartId,
					@fltr_BalanceMin,
					@fltr_BalanceMax,
					@fltr_CountMonthMin,
					@fltr_CountMonthMax,
					@fltr_prHouseTypeId,
					@fltr_DocTypeNotice
					)

SELECT @@identity AS SessionId
COMMIT TRANSACTION
END

-- Удаление сеанса печати
IF @Function = 4 BEGIN 
	-- удаляем документы из журнала
	DELETE FROM Pr_JournalDocs4_05 WHERE SessionId = @SessionId
	-- удаляем сеанс печати
	DELETE FROM Pr_OioPrintSessions WHERE SessionId =@SessionId

		-- получаем листы задания оставшиеся без сеансов печати
		DECLARE @TS TABLE (tsId INT)
		INSERT INTO @TS
		SELECT			ts.TaskSheetId
		FROM 			dbo.Pr_JournalTaskSheets ts
		LEFT OUTER JOIN dbo.Pr_OioPrintSessions s ON ts.TaskSheetId = s.TaskSheetId
		WHERE 			s.SessionId IS NULL

	-- удаляем эти маршрутки
	DELETE FROM Pr_JournalTaskSheetPerformers WHERE TaskSheetId IN (SELECT * FROM @TS)
	DELETE FROM Pr_JournalTaskSheets WHERE TaskSheetId IN (SELECT * FROM @TS)
END
GO
GRANT EXECUTE ON Pr_PrintSessions TO KvzWorker
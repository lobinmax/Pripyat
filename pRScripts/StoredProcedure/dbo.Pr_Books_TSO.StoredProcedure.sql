IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_TSO' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_TSO
GO
CREATE PROCEDURE dbo.Pr_Books_TSO
/*
	=========================================
	|	Обработка справочника с ТСО			|
	=========================================
*/
	@TSOid			INT	= NULL,				-- Ид ТСО
   	@TSOName 		VARCHAR(100) = NULL,	-- Наименование ТСО
   	@TSOAddress 	VARCHAR(200) = NULL,	-- Адрес ТСО
   	@TSOEmail 		VARCHAR(50) = NULL,		-- Эл. почта ТСО
   	@TSOPhone 		VARCHAR(50) = NULL,		-- Телефон ТСО
   	@TSOPhoneMobile VARCHAR(50) = NULL,		-- Мобильный ТСО
	@Function		INT = 1					-- 1 - SELECT
											-- 2 - INSERT
											-- 3 - UPDATE
											-- 4 - DELETE
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Message VARCHAR(300)
-- информация о выбранной УК
IF @Function = 1 BEGIN
	SELECT * FROM vPr_TSO WHERE TSOId = @TSOid
END

-- Запись информации о ТСО
IF @Function = 2 BEGIN
BEGIN TRANSACTION
	INSERT 	INTO Pr_TSO
	SELECT 	@TSOName, @TSOAddress, @TSOEmail, @TSOPhone, @TSOPhoneMobile, 
			dbo.Kernel_GetPerformer(), GETDATE(), dbo.Kernel_GetPerformer(), GETDATE()
	COMMIT TRANSACTION
END

-- Обновление информации о ТСО
IF @Function = 3 BEGIN
	UPDATE 	Pr_TSO 
	SET 	TSOName = @TSOName, 
			TSOAddress = @TSOAddress, 
			TSOEmail = @TSOEmail, 
			TSOPhone = @TSOPhone, 
			TSOPhoneMobile = @TSOPhoneMobile,
			UpdaterId = dbo.Kernel_GetPerformer(),
			UpdateDt = GETDATE()
	WHERE 	TSOid = @TSOid
END

-- Удаление УК
IF @Function = 4 BEGIN
	-- проверка привязана ли TCО к абонентам
	IF EXISTS(SELECT * FROM Pr_Points pp WHERE pp.TSOId = @TSOid) BEGIN
		SET  @Message = 'Сетевая организация <u><b>' + (SELECT pt.TSOName FROM Pr_TSO pt WHERE pt.TSOId = @TSOid) + 
						'</u></b> привязана к абонентам!' + CHAR(10) + 
						'Удаление не возможно!'
		RAISERROR(@Message, 12, 1)
		RETURN 0
	END
	DELETE FROM Pr_TSO WHERE TSOid = @TSOid
END

GO
GRANT EXECUTE ON dbo.Pr_Books_TSO TO KvzWorker
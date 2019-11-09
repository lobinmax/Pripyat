IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_GKH' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_GKH
GO
CREATE PROCEDURE dbo.Pr_Books_GKH
/*
	=============================================
	|	Обработка справочника с Обслуживающими	|
	=============================================
*/
	@GKHid			INT	= NULL,				-- Ид обслуживающей организации
	@ParentId		INT	= NULL,				-- Ид родителя записи
   	@GKHName 		VARCHAR(100) = NULL,	-- Наименование УК
   	@GKHAddress		VARCHAR(200) = NULL,	-- Адрес УК
   	@GKHEmail 		VARCHAR(50) = NULL,		-- Эл. почта УК
   	@GKHPhone 		VARCHAR(50) = NULL,		-- Телефон УК
   	@GKHPhoneMobile VARCHAR(50) = NULL,		-- Мобильный УК
	@Function		INT = 1					-- 1 - SELECT
											-- 2 - INSERT
											-- 3 - UPDATE
											-- 4 - DELETE
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Message VARCHAR(300)
-- информация о выбранной ОК
IF @Function = 1 BEGIN
	SELECT * FROM Pr_GKH pg WHERE pg.GKHid = @GKHid
END

-- Запись информации об ОК
IF @Function = 2 BEGIN
BEGIN TRANSACTION
	INSERT INTO Pr_GKH
	SELECT @GKHName, @GKHAddress, @GKHEmail, @GKHPhone, @GKHPhoneMobile, dbo.Kernel_GetPerformer(), GETDATE(), dbo.Kernel_GetPerformer(), GETDATE()
	INSERT INTO Pr_GKStructure
	SELECT (SELECT pg.GKHid FROM Pr_GKH pg WHERE pg.GKHid = @@identity), @ParentId
COMMIT TRANSACTION
END

-- Обновление информации об ОК
IF @Function = 3 BEGIN
	UPDATE 	Pr_GKH 
	SET  	GKHName = @GKHName, 
			GKHAddress = @GKHAddress, 
			GKHEmail = @GKHEmail, 
			GKHPhone = @GKHPhone, 
			GKHPhoneMobile = @GKHPhoneMobile,
			UpdaterId = dbo.Kernel_GetPerformer(),
			UpdateDt = GETDATE()
	WHERE 	GKHid = @GKHid
END

-- Удаление ОК
IF @Function = 4 BEGIN
	-- проверка привязана ли ЖКХ к абонентам
	IF EXISTS(SELECT * FROM Pr_Abonents pa WHERE pa.GKHid = @GKHid) BEGIN
		SET  @Message = 'Обслуживающая организация <u><b>' + (SELECT pg.GKHName FROM Pr_GKH pg WHERE pg.GKHid = @GKHid) + 
						'</u></b> привязана к абонентам!' + CHAR(10) + 
						'Удаление не возможно!'
		RAISERROR(@Message, 12, 1)
		RETURN
	END
	DELETE FROM Pr_GKH WHERE GKHid = @GKHid
	DELETE FROM Pr_GKStructure WHERE Id = @GKHid
END

GO
GRANT EXECUTE ON dbo.Pr_Books_GKH TO KvzWorker
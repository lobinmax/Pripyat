IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_GKO' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_GKO
GO
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_GKH' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_GKH
GO
CREATE PROCEDURE dbo.Pr_Books_GKO
/*
	=========================================================
	|	Обработка справочника с УКашками и Обслуживающими	|
	=========================================================
*/
	@GKid			INT	= NULL,				-- Ид управляющей организации
	@ParentId		INT	= NULL,				-- Ид родителя записи
   	@GKName 		VARCHAR(100) = NULL,	-- Наименование УК
   	@GKAddress 		VARCHAR(200) = NULL,	-- Адрес УК
   	@GKEmail 		VARCHAR(50) = NULL,		-- Эл. почта УК
   	@GKPhone 		VARCHAR(50) = NULL,		-- Телефон УК
   	@GKPhoneMobile 	VARCHAR(50) = NULL,		-- Мобильный УК
	@Function		INT = 1,				-- 1 - SELECT
											-- 2 - INSERT
											-- 3 - UPDATE
											-- 4 - DELETE
	@GKType			VARCHAR(5) = 'GKO'		-- Тип организации 	GKO - управляющая
											--					GKH - обслуживающая
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Message VARCHAR(300)
-- информация о выбранной орг.
IF @Function = 1 BEGIN

	IF @GKType = 'GKO' BEGIN
		SELECT 	pg.GKOName AS GKName, pg.GKOAddress AS GKAddress, pg.GKOEmail AS GKEmail, 
				pg.GKOPhone AS GKPhone, pg.GKOPhoneMobile AS GKPhoneMobile
		FROM 	Pr_GKO pg WHERE pg.GKOid = @GKid
	END

	IF @GKType = 'GKH' BEGIN
		SELECT 	pg.GKHName AS GKName, pg.GKHAddress AS GKAddress, pg.GKHEmail AS GKEmail, 
				pg.GKHPhone AS GKPhone, pg.GKHPhoneMobile AS GKPhoneMobile 
		FROM 	Pr_GKH pg WHERE pg.GKHid = @GKid
	END
END

-- Запись информации об ОК
IF @Function = 2 BEGIN
BEGIN TRANSACTION

	IF @GKType = 'GKO' BEGIN
		INSERT INTO Pr_GKO
		SELECT @GKName, @GKAddress, @GKEmail, @GKPhone, @GKPhoneMobile, dbo.Kernel_GetPerformer(), GETDATE(), dbo.Kernel_GetPerformer(), GETDATE()
		INSERT INTO Pr_GKStructure
		SELECT (SELECT pg.GKOid FROM Pr_GKO pg WHERE pg.GKOid = @@identity), @ParentId
	END

	IF @GKType = 'GKH' BEGIN
		INSERT INTO Pr_GKH
		SELECT @GKName, @GKAddress, @GKEmail, @GKPhone, @GKPhoneMobile, dbo.Kernel_GetPerformer(), GETDATE(), dbo.Kernel_GetPerformer(), GETDATE()
		INSERT INTO Pr_GKStructure
		SELECT (SELECT pg.GKHid FROM Pr_GKH pg WHERE pg.GKHid = @@identity), @ParentId
	END
COMMIT TRANSACTION
END

-- Обновление информации об УК
IF @Function = 3 BEGIN

	IF @GKType = 'GKO' BEGIN
		UPDATE 	Pr_GKO 
		SET 	GKOName = @GKName, 
				GKOAddress = @GKAddress, 
				GKOEmail = @GKEmail, 
				GKOPhone = @GKPhone, 
				GKOPhoneMobile = @GKPhoneMobile,
				UpdaterId = dbo.Kernel_GetPerformer(),
				UpdateDt = GETDATE()
		WHERE 	GKOid = @GKid
	END

	IF @GKType = 'GKH' BEGIN
		UPDATE 	Pr_GKH 
		SET  	GKHName = @GKName, 
				GKHAddress = @GKAddress, 
				GKHEmail = @GKEmail, 
				GKHPhone = @GKPhone, 
				GKHPhoneMobile = @GKPhoneMobile,
				UpdaterId = dbo.Kernel_GetPerformer(),
				UpdateDt = GETDATE()
		WHERE 	GKHid = @GKid
	END
END

-- Удаление УК
IF @Function = 4 BEGIN

	IF @GKType = 'GKO' BEGIN
		-- проверка привязана ли ЖКО к абонентам через свои ЖКХ
		IF EXISTS(SELECT * FROM Pr_Abonents pa WHERE pa.GKHid IN (SELECT pg.Id FROM vPr_GKOTree pg WHERE pg.ParentId = @GKid)) BEGIN
			SET  @Message = 'Управляющая организация <u><b>' + (SELECT pg.GKOName FROM Pr_GKO pg WHERE pg.GKOid = @GKid) + 
							'</u></b> привязана к абонентам!' + CHAR(10) + 
							'Удаление не возможно!'
			RAISERROR(@Message, 12, 1)
			RETURN 0
		END
		-- проверяем есть ли привязанные GKH
		IF EXISTS (SELECT * FROM Pr_GKStructure pg WHERE pg.ParentId = @GKid) BEGIN
			DELETE FROM Pr_GKH WHERE GKHid IN (SELECT pg.Id FROM Pr_GKStructure pg WHERE pg.ParentId = @GKid)
			DELETE FROM Pr_GKStructure WHERE ParentId = @GKid
		END
		DELETE FROM Pr_GKO WHERE GKOid = @GKid
		DELETE FROM Pr_GKStructure WHERE Id = @GKid
	END

	IF @GKType = 'GKH' BEGIN
		-- проверка привязана ли ЖКХ к абонентам
		IF EXISTS(SELECT * FROM Pr_Abonents pa WHERE pa.GKHid = @GKid) BEGIN
			SET  @Message = 'Обслуживающая организация <u><b>' + (SELECT pg.GKHName FROM Pr_GKH pg WHERE pg.GKHid = @GKid) + 
							'</u></b> привязана к абонентам!' + CHAR(10) + 
							'Удаление не возможно!'
			RAISERROR(@Message, 12, 1)
			RETURN
		END
		DELETE FROM Pr_GKH WHERE GKHid = @GKid
		DELETE FROM Pr_GKStructure WHERE Id = @GKid
	END
END
GO
GRANT EXECUTE ON dbo.Pr_Books_GKO TO KvzWorker
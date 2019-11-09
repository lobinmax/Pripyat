IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_JudicialArea' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_JudicialArea
GO

CREATE PROCEDURE [dbo].[Pr_Books_JudicialArea] 
@JudicialAreaId			INT,			-- Ид судебного участка
@CourtTypeId		    INT,			-- ИД инстанции
@Postal					INT,			-- Почтовый индекс участка
@Adress  				VARCHAR(100),	-- Адрес судебного участка
@HouseNumber			NCHAR(4),		-- Номер дома судебного участка
@ZoneOfServiceId		INT,			-- Зона обслуживания судебного участка
@JudicialAreaName		VARCHAR(30),	-- Название судебного участка
@Number					VARCHAR(10),	-- Номер судебного участка
@CurrentJudgeId			INT,			-- Ид текущего мирового судьи участка
@Phone					VARCHAR(20),	-- Телефон судебного участка
@PhoneMobile			VARCHAR(20),	-- Моб телефон судебного участка
@email					VARCHAR(50),	-- Mail судебного участка
@Site					VARCHAR(50),	-- Сайт судебного участка
@Function				INT				-- 1 - SELECT
										-- 2 - INSERT
										-- 3 - UPDATE
										-- 4 - DELETE
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

IF @Function = 1 BEGIN	-- Выборка
  SELECT * FROM vPr_JudicialArea as vPr_
           WHERE CourtTypeId = @CourtTypeId
  RETURN 0
END

IF @Function = 2 BEGIN			-- Новая запись
  INSERT INTO Pr_JudicialArea
                        (CourtTypeId,
						 Postal, 
						 Adress,
						 HouseNumber, 
						 ZoneOfServiceId,
						 JudicialAreaName, 
						 Number, 
						 CurrentJudgeId, 
						 Phone, 
						 PhoneMobile, 
						 email, 
						 Site)
  VALUES				(@CourtTypeId, 
						 @Postal,
						 @Adress,
						 @HouseNumber, 
						 @ZoneOfServiceId, 
						 @JudicialAreaName,
						 @Number, 
						 @CurrentJudgeId, 
						 @Phone, 
						 @PhoneMobile, 
						 @email, 
						 @Site)
--EXEC Pr_Books_JudicialArea @CourtTypeId = @CourtTypeId, @Function = 1
  RETURN 0
END

IF @Function = 3 BEGIN			-- Обновление записи
  UPDATE Pr_JudicialArea SET    CourtTypeId = @CourtTypeId, 
								Postal = @Postal, 
								Adress = @Adress,
								HouseNumber = @HouseNumber,
								ZoneOfServiceId = @ZoneOfServiceId, 
								JudicialAreaName = @JudicialAreaName,
								Number = @Number, 
								CurrentJudgeId = @CurrentJudgeId, 
								Phone = @Phone, 
								PhoneMobile = @PhoneMobile, 
								email = @email, 
								Site = @Site
 WHERE JudicialAreaId = @JudicialAreaId 

--EXEC Pr_Books_JudicialArea @CourtTypeId = @CourtTypeId, @Function = 1
  RETURN 0
END

IF @Function = 4 BEGIN			-- Удаление записи
  DELETE Pr_JudicialArea WHERE JudicialAreaId = @JudicialAreaId
--EXEC Pr_Books_JudicialArea @CourtTypeId = @CourtTypeId, @Function = 1
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_JudicialArea TO KvzWorker

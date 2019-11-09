IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PointsPublicAddSection' AND type = 'P')
    DROP PROCEDURE dbo.Pr_PointsPublicAddSection
GO
CREATE PROCEDURE dbo.Pr_PointsPublicAddSection
/*
	=============================================
	|	Создание новой секции и всех ее данных	|
	=============================================
*/
	@SectionId 			INT = NULL,
	@PublicPointId 		INT = NULL,
	@SectionRoomNumber 	INT = NULL,
	@DtCounterSetup 	SMALLDATETIME = NULL,
	@CounterTypeId 		SMALLINT = NULL,
	@CounterNumber 		VARCHAR(20) = NULL,
	@IndicationSetup 	INT = NULL,
	@SchemesId 			INT = NULL,
	@PointId 			INT = NULL,
    @LodgersCount 		INT = NULL,
	@Function 			INT = 0	-- 1 - Новая секция и ПУ
								-- 2 - Подключение ТУ (Циклом)
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @SectionId_New INT 				-- Ид новой секции
DECLARE @SectionNumber VARCHAR(12)		-- Номер лицевого секции
DECLARE @DtCounterSetupPeriod INT = ((YEAR(@DtCounterSetup) * 100) + MONTH(@DtCounterSetup))

-- проверка периода
IF (SELECT ap.MonthStatus FROM AccountingPeriods AS ap WHERE ap.PeriodNumber = @DtCounterSetupPeriod) = 2 BEGIN
	RAISERROR ('Указанная дата принадлежит закрытому периоду!', 12, 2)
	RETURN
END 

-- Создание секции и ПУ
IF @Function = 1 BEGIN
	-- проверка наличия секции
	IF EXISTS(SELECT * FROM Pr_PointsPublicSections AS ppps 
				WHERE ppps.PublicPointId = @PublicPointId AND SectionRoomNumber = @SectionRoomNumber) BEGIN
		RAISERROR ('В доме с ОДПУ уже присутствует секция с указанным номером!', 12, 2)
		RETURN	
	END 
	-- проверка наличия пускового наряда
	IF EXISTS(SELECT * FROM Pr_PointsPublicSectionsCharges AS pppsc WHERE pppsc.SectionId = @SectionId AND pppsc.OldIndication < 0) BEGIN
		RAISERROR ('В создаваемая секция уже присутствует в работе!', 12, 2)
		RETURN
	END 

	-- Генерируем номер лицевого для секции
	SELECT @SectionNumber = CAST(CAST(dbo.Pr_fnsGetConstants(9, 0) + '000' AS INT) + (SELECT COUNT(ppps.SectionId) FROM Pr_PointsPublicSections AS ppps) AS VARCHAR)
 	-- Создание секции
	INSERT Pr_PointsPublicSections ( PublicPointId, SectionNumber, SectionRoomNumber, SchemesId,  DtCreate, CreaterId)
	VALUES (@PublicPointId, @SectionNumber, @SectionRoomNumber, @SchemesId, GETDATE(), dbo.Kernel_GetPerformer())
	SELECT @SectionId_New = @@identity FROM Pr_PointsPublicSections AS ppps WHERE ppps.SectionId = @@identity 
	-- Создание ПУ в секции
	INSERT Pr_CountersSectionHistory 
	(SectionId, DtCounterSetup, CounterTypeId, CounterNumber, IndicationSetup, 
	DtCreate, CreaterId, DtUpdate, UpdaterId, PeriodNumber, IsActive)
	VALUES 
	(@SectionId_New, @DtCounterSetup, @CounterTypeId, @CounterNumber, @IndicationSetup, GETDATE(), dbo.Kernel_GetPerformer(), 
	GETDATE(), dbo.Kernel_GetPerformer(), @DtCounterSetupPeriod, 1)
	-- создание проводки
	INSERT Pr_PointsPublicSectionsCharges (DtDoc, SectionId, OldIndication, NewIndication, Consumption, SourceId, CreaterId, DtCreate, UpdaterId, DtUpdate, PeriodNumber)
	VALUES (@DtCounterSetup, @SectionId_New, -1, @IndicationSetup, 0, 2, dbo.Kernel_GetPerformer(), GETDATE(), dbo.Kernel_GetPerformer(), GETDATE(), @DtCounterSetupPeriod)
	-- возвращаеи ИД новой секции
	SELECT @SectionId_New
END 

-- Подключение ТУ (Циклом)
IF @Function = 2 BEGIN
	INSERT Pr_PointsPublicSectionsConn (SectionId, PointId, LodgersCount, DtCreate, CreaterId)
	VALUES (@SectionId, @PointId, @LodgersCount, GETDATE(), dbo.Kernel_GetPerformer())
	-- меняем жильцов в Квазаре
	UPDATE Lodgers SET CountLodgers = @LodgersCount 
	WHERE AbonentId = (	SELECT p.AbonentId FROM Points AS p WHERE p.PointId = @PointId)
						AND DtEnd > GETDATE()
END
GO
GRANT EXECUTE ON dbo.Pr_PointsPublicAddSection TO KvzWorker
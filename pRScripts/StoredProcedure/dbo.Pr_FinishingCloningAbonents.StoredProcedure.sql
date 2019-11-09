IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_FinishingCloningAbonents' AND type = 'P')
    DROP PROCEDURE dbo.Pr_FinishingCloningAbonents
GO

CREATE PROCEDURE [dbo].[Pr_FinishingCloningAbonents]

/* Процедура завершения клонированных гаражей
(Разноска необходимых параметров в лицевом гаража)*/ 
@AbonentNum varchar(20),	-- Номер абонента гаража
@TariffId int = 2004101288

AS
SET NOCOUNT ON
SET XACT_ABORT ON           -- Всегда откатывать по ошибке

DECLARE @AbonentId INT 
SELECT @AbonentId = ElementId FROM dbo.Elements WHERE Num = @AbonentNum				-- Определяем Id абонента гаража

DECLARE @PointId INT 
SELECT @PointId = PointId FROM Points WHERE AbonentId = @AbonentId				-- Определяем Id точки учета гаража											
																		 				
DECLARE @AbonentNumClone varchar(12) 
SELECT @AbonentNumClone = Num FROM dbo.Elements WHERE ElementId =						-- Определяем номер абонента от которого выделен гараж	
																		(SELECT ParentId 
																		FROM Abonents 
																		WHERE AbonentId = @AbonentId)

-- Обновление истории абонента
UPDATE	dbo.AbonentsHistory 
SET		ExtAbonentStatusId = 110,
		Notes = 'Абонент выделен из ' + @AbonentNumClone,
		HouseOwnerId = 4,
		CookerId = 3,
		JuricticFacesId=NULL 
WHERE	AbonentId = @AbonentId and DtChange = CAST((SELECT DtChange 
													FROM	vSchemes_AbonentsHistory_DtEnd1 
													WHERE	AbonentId = @AbonentId and 
													DtEnd = CAST('01.01.2079' AS DATE)) AS DATE)
		
-- Разноска необходимых параметров жилья 
UPDATE	dbo.Abonents 
SET		HouseTypeId = 8,
		BuildTypeId = 1, 
		Floors = 1,
		SquareTotal = 20,
		RoomCount = 1,
		CalcTypeId = 2, 
		BoxPostal = 0,
		ParentId = NULL
WHERE	AbonentId = @AbonentId

-- Удаление ID капремонта
DELETE FROM HouseFondOverhaul
WHERE		AbonentId = @AbonentId


-- Настройка расчетных параметров жилья
EXECUTE dbo.Abonents_HousePropHistoryFunctions @AbonentId, '2016-03-01T00:00:00.000', '2016-03-01T00:00:00.000', 11, 1

-- Нулевое число прописанных 
UPDATE	dbo.Lodgers 
SET		CountLodgers = 0, 
		CountMembers = 0,
		CountDependants = 0,
		CountRegistered = 0
WHERE	AbonentId = @AbonentId and DtChange = CAST((SELECT	DtChange 
													FROM	vSchemes_LodgersHistory_DtEnd  
													WHERE	AbonentId = @AbonentId and 
		DtEnd = CAST('01.01.2079' AS DATE)) AS DATE)

-- Установка параметров расчета по мощности
EXECUTE dbo.Points_PointsHistoryPowerValueFunctions @PointId,'2016-03-01T00:00:00.000', DEFAULT, 5, 
													DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT, 
													DEFAULT, DEFAULT, DEFAULT, DEFAULT, 
													'2016-03-01T00:00:00.000', 
													DEFAULT, DEFAULT, 
													DEFAULT

-- Место установки счетчика
UPDATE	dbo.CountersHistory 
SET		CounterPlaceId = 5
WHERE	PointId= @PointId and DtCountSetup = CAST(( SELECT	DtCountSetup  
													FROM	vSchemes_CountersHistory_DtEnd 
													WHERE	PointId= @PointId and 
															DtEnd = CAST('01.01.2079' AS DATE)) AS DATE) 

-- Изменение тарифа в истории точки учета
UPDATE	dbo.PointsHistory 
SET		TariffId = @TariffId
WHERE	PointId= @PointId and DtChange = CAST((	SELECT	DtChange 
												FROM	vSchemes_PointsHistory_DtEnd_3  
												WHERE	PointId= @PointId and 
														DtEnd = CAST('01.01.2079' AS DATE)) AS DATE)
GO

GRANT EXECUTE ON dbo.Pr_FinishingCloningAbonents TO KvzWorker

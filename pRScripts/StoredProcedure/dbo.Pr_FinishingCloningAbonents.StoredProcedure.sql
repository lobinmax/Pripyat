IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_FinishingCloningAbonents' AND type = 'P')
    DROP PROCEDURE dbo.Pr_FinishingCloningAbonents
GO

CREATE PROCEDURE [dbo].[Pr_FinishingCloningAbonents]

/* ��������� ���������� ������������� �������
(�������� ����������� ���������� � ������� ������)*/ 
@AbonentNum varchar(20),	-- ����� �������� ������
@TariffId int = 2004101288

AS
SET NOCOUNT ON
SET XACT_ABORT ON           -- ������ ���������� �� ������

DECLARE @AbonentId INT 
SELECT @AbonentId = ElementId FROM dbo.Elements WHERE Num = @AbonentNum				-- ���������� Id �������� ������

DECLARE @PointId INT 
SELECT @PointId = PointId FROM Points WHERE AbonentId = @AbonentId				-- ���������� Id ����� ����� ������											
																		 				
DECLARE @AbonentNumClone varchar(12) 
SELECT @AbonentNumClone = Num FROM dbo.Elements WHERE ElementId =						-- ���������� ����� �������� �� �������� ������� �����	
																		(SELECT ParentId 
																		FROM Abonents 
																		WHERE AbonentId = @AbonentId)

-- ���������� ������� ��������
UPDATE	dbo.AbonentsHistory 
SET		ExtAbonentStatusId = 110,
		Notes = '������� ������� �� ' + @AbonentNumClone,
		HouseOwnerId = 4,
		CookerId = 3,
		JuricticFacesId=NULL 
WHERE	AbonentId = @AbonentId and DtChange = CAST((SELECT DtChange 
													FROM	vSchemes_AbonentsHistory_DtEnd1 
													WHERE	AbonentId = @AbonentId and 
													DtEnd = CAST('01.01.2079' AS DATE)) AS DATE)
		
-- �������� ����������� ���������� ����� 
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

-- �������� ID ����������
DELETE FROM HouseFondOverhaul
WHERE		AbonentId = @AbonentId


-- ��������� ��������� ���������� �����
EXECUTE dbo.Abonents_HousePropHistoryFunctions @AbonentId, '2016-03-01T00:00:00.000', '2016-03-01T00:00:00.000', 11, 1

-- ������� ����� ����������� 
UPDATE	dbo.Lodgers 
SET		CountLodgers = 0, 
		CountMembers = 0,
		CountDependants = 0,
		CountRegistered = 0
WHERE	AbonentId = @AbonentId and DtChange = CAST((SELECT	DtChange 
													FROM	vSchemes_LodgersHistory_DtEnd  
													WHERE	AbonentId = @AbonentId and 
		DtEnd = CAST('01.01.2079' AS DATE)) AS DATE)

-- ��������� ���������� ������� �� ��������
EXECUTE dbo.Points_PointsHistoryPowerValueFunctions @PointId,'2016-03-01T00:00:00.000', DEFAULT, 5, 
													DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT, 
													DEFAULT, DEFAULT, DEFAULT, DEFAULT, 
													'2016-03-01T00:00:00.000', 
													DEFAULT, DEFAULT, 
													DEFAULT

-- ����� ��������� ��������
UPDATE	dbo.CountersHistory 
SET		CounterPlaceId = 5
WHERE	PointId= @PointId and DtCountSetup = CAST(( SELECT	DtCountSetup  
													FROM	vSchemes_CountersHistory_DtEnd 
													WHERE	PointId= @PointId and 
															DtEnd = CAST('01.01.2079' AS DATE)) AS DATE) 

-- ��������� ������ � ������� ����� �����
UPDATE	dbo.PointsHistory 
SET		TariffId = @TariffId
WHERE	PointId= @PointId and DtChange = CAST((	SELECT	DtChange 
												FROM	vSchemes_PointsHistory_DtEnd_3  
												WHERE	PointId= @PointId and 
														DtEnd = CAST('01.01.2079' AS DATE)) AS DATE)
GO

GRANT EXECUTE ON dbo.Pr_FinishingCloningAbonents TO KvzWorker

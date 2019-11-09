IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_CountAbonentsController' AND type = 'P')
    DROP PROCEDURE dbo.Pr_CountAbonentsController
GO

CREATE PROCEDURE [dbo].[Pr_CountAbonentsController]
-- ���������� ���������
@Function	INT = 1		--  �� ������ � ������� �����������
						--  �� �����c� �������� � ������� ����������� � ���� �����
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

-- �� ������
IF @Function = 1 BEGIN
SELECT      vtAddressDict.Areal, 
			vtAddressDict.CityVillage, 
			vtAddressDict.Street, 
			COUNT(vAbonents.AbonentId) AS AbonentCount, 
			Elements.Name AS ControllerName

FROM		vtAddressDict 
INNER JOIN vAbonents ON vtAddressDict.AddressPartId = vAbonents.AddressPartId AND 
									vtAddressDict.Areal = vAbonents.Areal AND 
									vtAddressDict.CityVillage = vAbonents.CityVillage AND 
									vtAddressDict.Street = vAbonents.Street AND 
									vAbonents.LastSurName <> '�����������' 
INNER JOIN Elements ON vAbonents.ControllerId = Elements.ElementId

GROUP BY vtAddressDict.Areal, vtAddressDict.CityVillage, vtAddressDict.Street, Elements.Name
ORDER BY ControllerName, vtAddressDict.Street, vtAddressDict.CityVillage, vtAddressDict.Areal
end

-- �� ������� �������� � ���� �����
IF @Function = 2 BEGIN
SELECT		dbo.Elements.Name AS ControllerName, 
			dbo.AbonentStatus.Name AS AbonentStatus, 
			dbo.ExtAbonentStatus.Name AS ExtAbonentStatus, 
			CASE 
				WHEN vOiohp.housepropid IN (1, 2, 3, 13, 14, 15, 16) THEN '��������������� ���' 
				WHEN vOiohp.housepropid IN (4, 11, 12) THEN '������� ������' 
			END AS HouseType, 
			COUNT(vOiohp.abonentid) AS AbonentsCount

FROM		dbo.vOiohouseproperties AS vOiohp 
INNER JOIN  (
			SELECT	AbonNumber, 
					AbonentId, 
					DtChange, 
					DtEnd, 
					FamilyMemberId, 
					AbonentStatusId, 
					HouseStatusId, 
					HouseOwnerId, 
					CookerId, 
					PerformerId, 
					DtUpdate,
					MasterName, 
					NotPlaneAccounts, 
					JuricticFacesId, 
					ExtAbonentStatusId, 
					Notes, 
					PeriodNumber
			FROM	dbo.vSchemes_AbonentsHistory_DtEnd
			WHERE	(DtEnd > GETDATE())) AS [as] 
						ON vOiohp.abonentid = [as].AbonentId 
 INNER JOIN
                         dbo.AbonentStatus ON [as].AbonentStatusId = dbo.AbonentStatus.AbonentStatusId INNER JOIN
                         dbo.ExtAbonentStatus ON [as].ExtAbonentStatusId = dbo.ExtAbonentStatus.ExtAbonentStatusId INNER JOIN
                         dbo.vAbonents ON vOiohp.abonentid = dbo.vAbonents.AbonentId INNER JOIN
                         dbo.Elements ON dbo.vAbonents.ControllerId = dbo.Elements.ElementId


GROUP BY    CASE 
				WHEN vOiohp.housepropid IN (1, 2, 3, 13, 14, 15, 16) THEN '��������������� ���' 
				WHEN vOiohp.housepropid IN (4, 11, 12) THEN '������� ������' 
			END, 
			dbo.ExtAbonentStatus.Name, 
			dbo.AbonentStatus.Name, 
			dbo.Elements.Name

ORDER BY	ControllerName, 
			AbonentStatus, 
			ExtAbonentStatus, 
			HouseType
END
GO

GRANT EXECUTE ON dbo.Pr_CountAbonentsController TO KvzWorker

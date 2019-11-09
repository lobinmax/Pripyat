IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetAddressArealPerformer' AND type = 'P')
    DROP PROCEDURE Pr_GetAddressArealPerformer
GO
CREATE PROCEDURE dbo.Pr_GetAddressArealPerformer
	-- �������� ���� (�� ������� ����������)
	@ControlerId 	INT = NULL,
	@IsRoot			BIT = 0			-- 1 - ������ ���� "��� �����"; 0 - ������ ���� ������
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� ���� ������

DECLARE @IsRootId INT = 99999
IF @IsRoot = 0 BEGIN SET @IsRootId = @IsRoot END

CREATE TABLE #AddressList(
						 Id INT, 
						 ParentId INT, 
						 Name VARCHAR(100), 			-- ��� ���� � ������
						 AddressPartType VARCHAR(50), 	-- ��� ���������� ����
						 AddressString VARCHAR(100), 	-- ��������� ���� ����� �������
						 ArealId VARCHAR(50), 
						 CityVillageId VARCHAR(50), 
						 StreetId VARCHAR(50), 
						 Areal VARCHAR(100), 
						 CityVillage VARCHAR(100), 
						 Street VARCHAR(100)
						 )
IF @IsRoot = 1 BEGIN
	INSERT INTO #AddressList
	SELECT @IsRootId, NULL, '��� �����', 'NULL', '��� �����', 'NULL', 'NULL', 'NULL', 'NULL', 'NULL', 'NULL' 
END

INSERT INTO #AddressList
-- ������
SELECT		ta.ArealId, 
			@IsRootId, 
			ta.Areal,
			'Areal',
			ta.Areal,
			ta.ArealId,
			CAST('NULL' AS VARCHAR),
			'NULL',
			ta.Areal,
			'NULL',
			'NULL'
FROM 		TAddressDict AS ta 
WHERE  		ta.ArealId != 2000000002     
GROUP BY 	ta.ArealId, ta.Areal
ORDER BY 	ta.Areal

INSERT INTO #AddressList
-- �������
SELECT		ta.CityVillageId, 
			CASE WHEN taP.ArealId = 2000000002 THEN @IsRootId ELSE taP.ArealId END, 
			taP.CityVillage, 
			'CityVillage', 
   			RTRIM(LTRIM(taP.Areal + ' ' + taP.CityVillage)), 
			CASE WHEN taP.ArealId = 2000000002 THEN 'NULL' ELSE taP.ArealId END, 
   			CAST(taP.CityVillageId AS VARCHAR) , 
			'NULL', 
			CASE WHEN taP.Areal = ' ' THEN 'NULL' ELSE taP.Areal END, 
			taP.CityVillage, 
			'NULL'
FROM     	TAddressDict AS ta 
INNER JOIN 	TAddressDict AS taP ON ta.AddressPartId = taP.AddressPartId
GROUP BY 	ta.CityVillageId, taP.CityVillage, ta.Areal + ' ' + ta.CityVillage, taP.CityVillageId, taP.ArealId, taP.Areal
ORDER BY	taP.CityVillage

INSERT INTO #AddressList
-- �����
SELECT   	ta.StreetId, 
			taP.CityVillageId, 
			taP.Street, 
			'Street', 
			RTRIM(LTRIM(taP.Areal + ' ' + taP.CityVillage + ' ' + tap.Street)), 
  			CASE WHEN taP.ArealId = 2000000002 THEN 'NULL' ELSE taP.ArealId END, 
			CAST(taP.CityVillageId AS VARCHAR), 
			CAST(taP.StreetId AS VARCHAR), 
  			CASE WHEN taP.Areal = ' ' THEN 'NULL' ELSE taP.Areal END, 
			taP.CityVillage, 
			taP.Street
FROM    	TAddressDict AS ta 
INNER JOIN 	TAddressDict AS taP ON ta.AddressPartId = taP.AddressPartId
GROUP BY 	ta.StreetId, taP.CityVillageId, taP.Street, taP.StreetId, taP.CityVillage, taP.Areal, taP.ArealId
ORDER BY	taP.Street

-- ���� ����� ��������� ������� �� ��� �����
IF @ControlerId IS NOT NULL BEGIN
	DELETE FROM #AddressList WHERE Id NOT IN(
											SELECT 	a.AddressPartId 
											FROM 	Abonents a 
											WHERE 	a.ControllerId = @ControlerId
											)
END
SELECT * FROM #AddressList al
GO
GRANT EXECUTE ON Pr_GetAddressArealPerformer TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_ChekingHouseType' AND type = 'V')
    DROP VIEW vPr_ChekingHouseType
GO

CREATE VIEW vPr_ChekingHouseType
AS
SELECT
	a.AbonentId
   ,a.HouseTypeId
   ,a.HousingOptionId
   ,a.AbonNumber
   ,a.LastSurName
   ,a.CommAddressString +
	CASE
		WHEN a.HouseTypeId = 8 THEN ' (Гараж)'
		ELSE ''
	END AS Address
   ,dbo.Pr_fsnGetCountRoom(a.AbonentId) AS CountRoom
   ,HouseTypes.Name AS HouseType
   ,CASE
		WHEN a.HousingOptionId = 1 THEN 'Индивидуальные жилые дома'
		ELSE 'Многоквартирные дома'
	END AS HousingOption
   ,Elements.Name AS GKO
   ,a.AddressString + ' д.' + a.House + a.LetterHouse +
	CASE
		WHEN a.Build IS NOT NULL THEN a.Build
	END AS HouseAddress
FROM dbo.vAbonents a
LEFT OUTER JOIN dbo.Elements
	ON a.GkoId = Elements.ElementId
LEFT OUTER JOIN dbo.HouseTypes
	ON a.HouseTypeId = HouseTypes.HouseTypeId
GO

GRANT SELECT ON vPr_ChekingHouseType TO KvzWorker



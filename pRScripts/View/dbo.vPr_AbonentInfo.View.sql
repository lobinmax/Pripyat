IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_AbonentInfo' AND type = 'V')
    DROP VIEW vPr_AbonentInfo
GO
/*Таблица основной информации по абонентам для ПК Припять*/
CREATE VIEW [dbo].[vPr_AbonentInfo]
AS
SELECT     TOP (100) PERCENT dbo.Abonents.AbonentId, dbo.vAbonents.AbonNumber, Pr_fnGetAbonentsFIO_1.Fio, dbo.vMainFamilyMembers.SurName, 
                      dbo.vMainFamilyMembers.Name, dbo.vMainFamilyMembers.Patronymic, dbo.vAbonents.CommAddressString AS Address, 
                      dbo.vAddressArealVillage.ArealName, dbo.vAddressArealVillage.VillageName, dbo.vAddressArealVillage.StreetName, 
                      dbo.vAddressArealVillage.ArealName + ' ' + dbo.vAbonents.CommAddressString AS ArealString, dbo.vAbonents.CommAltAddressString AS AltAddress, 
                      Pr_fnGetCountAbonentPoints_1.CountTY, dbo.vAbonents.AddressString, dbo.vAbonents.House, dbo.vAbonents.LetterHouse, dbo.vAbonents.Build, 
                      dbo.vAbonents.Section, dbo.vAbonents.Room, dbo.vAbonents.LetterRoom, dbo.RoomTypes.Name AS RoomTypes, dbo.vAbonents.RoomNumber, 
                      dbo.vInspectorGroups.InspectorName AS Controler, dbo.vChiefControllers.Name AS ChiefControler, Pr_GetAbonentGKO_1.GKO, 
                      fnGetCounterLodgers_1.countregistered AS LodgersCount, dbo.ManagerHouses.Name AS ManagerHouses, dbo.BuildTypes.Name AS BuildTypes, 
                      dbo.HouseTypes.Name AS HouseTypes, dbo.vAbonents.email, dbo.vAbonents.Phone, dbo.vAbonents.PhoneMobile, dbo.vAbonents.HotNotes, 
                      dbo.vAbonents.SpecDepart AS Route, dbo.vAbonents.Floors, dbo.Abonents.SquareTotal, dbo.Abonents.PostIndex, 
                      dbo.vOiohouseproperties.housepropid, dbo.vOiohouseproperties.housepropname
FROM         dbo.Abonents INNER JOIN
                      dbo.Pr_GetAbonentGKO() AS Pr_GetAbonentGKO_1 ON dbo.Abonents.AbonentId = Pr_GetAbonentGKO_1.AbonentId INNER JOIN
                      dbo.vAbonents ON dbo.Abonents.AbonentId = dbo.vAbonents.AbonentId INNER JOIN
                      dbo.HouseTypes ON dbo.Abonents.HouseTypeId = dbo.HouseTypes.HouseTypeId INNER JOIN
                      dbo.vAddressArealVillage ON dbo.Abonents.AddressPartId = dbo.vAddressArealVillage.AddressPartId LEFT OUTER JOIN
                      dbo.vMainFamilyMembers ON dbo.Abonents.AbonentId = dbo.vMainFamilyMembers.AbonentId LEFT OUTER JOIN
                      dbo.vOiohouseproperties ON dbo.Abonents.AbonentId = dbo.vOiohouseproperties.abonentid LEFT OUTER JOIN
                      dbo.BuildTypes ON dbo.Abonents.BuildTypeId = dbo.BuildTypes.BuildTypeId LEFT OUTER JOIN
                      dbo.ManagerHouses ON dbo.Abonents.ManagerHouseId = dbo.ManagerHouses.ManagerHouseId LEFT OUTER JOIN
                      dbo.fnGetCounterLodgers() AS fnGetCounterLodgers_1 ON dbo.Abonents.AbonentId = fnGetCounterLodgers_1.AbonentId LEFT OUTER JOIN
                      dbo.RoomTypes ON dbo.Abonents.RoomTypeId = dbo.RoomTypes.RoomTypeId LEFT OUTER JOIN
                      dbo.vInspectorGroups INNER JOIN
                      dbo.vChiefControllers ON dbo.vInspectorGroups.ChiefInspectorId = dbo.vChiefControllers.PerformerId ON 
                      dbo.Abonents.ControllerId = dbo.vInspectorGroups.InspectorId LEFT OUTER JOIN
                      dbo.Pr_fnGetCountAbonentPoints() AS Pr_fnGetCountAbonentPoints_1 ON 
                      dbo.Abonents.AbonentId = Pr_fnGetCountAbonentPoints_1.AbonentId LEFT OUTER JOIN
                      dbo.Pr_fnGetAbonentsFIO() AS Pr_fnGetAbonentsFIO_1 ON dbo.Abonents.AbonentId = Pr_fnGetAbonentsFIO_1.abonentid
WHERE     (Pr_fnGetAbonentsFIO_1.Fio <> 'Собственник помещения')
ORDER BY dbo.Abonents.AbonentId
GO
GRANT SELECT ON vPr_AbonentInfo TO KvzWorker
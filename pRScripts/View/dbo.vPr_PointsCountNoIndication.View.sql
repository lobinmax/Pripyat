IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PointsCountNoIndication' AND type = 'V')
    DROP VIEW vPr_PointsCountNoIndication
GO

CREATE VIEW vPr_PointsCountNoIndication
AS
SELECT				a.AbonentId, 
					vPr_PointsLastIndication.PointId, 
					a.AbonNumber, 
					p.PointNumber, 
					a.LastSurName, 
					a.CommAddressString AS Address, 
					vPr_PointsLastIndication.DtBegin, 
					vPr_PointsLastIndication.OldIndication, 
					vPr_PointsLastIndication.DtDoc, 
					vPr_PointsLastIndication.LastIndication, 
					vPr_PointsLastIndication.Consumption, 
					vPr_PointsLastIndication.CountNoIndication, 
					e.Name AS TariffName, 
					n.Name AS PowerNetwork, 
					ct.Name AS CounterType, 
					chMax.CounterNumber, 
					ht.Name AS HouseType, 
					hp.HousePropName AS HouseProperties, 
					ast.Name AS AbonentStatus, 
					eas.Name AS AbonentReason, 
					ps.Name AS PointStatus,
					dbo.Pr_fnsGetShortFNS('', a.ControllerId, 1) AS ControllerName
FROM    			HouseProperties AS hp 
INNER JOIN 			vPr_HistoryMaxHouseProperties AS hpm ON hp.HousePropId = hpm.HousePropId 
RIGHT OUTER JOIN 	vPoints_ListPointsStatus AS pls 
INNER JOIN 			AbonentStatus AS ast ON pls.AbonentStatusId = ast.AbonentStatusId 
INNER JOIN 			AccountStatus AS ps ON pls.PointStatusId = ps.AccountStatusId 
INNER JOIN 			ExtAbonentStatus AS eas ON pls.ExtAbonentStatusId = eas.ExtAbonentStatusId 
RIGHT OUTER JOIN	Elements AS e 
INNER JOIN 			vPr_HistoryMaxPoints AS phMax ON e.ElementId = phMax.TariffId 
RIGHT OUTER JOIN 	PowerNetworks AS n 
INNER JOIN 			Points AS p ON n.PowerNetworkId = p.PowerNetworkId 
INNER JOIN 			HouseTypes AS ht 
INNER JOIN 			vAbonents AS a ON ht.HouseTypeId = a.HouseTypeId ON p.AbonentId = a.AbonentId ON 
					phMax.PointId = p.PointId ON pls.AbonentId = p.AbonentId AND pls.PointId = p.PointId ON hpm.AbonentId = p.AbonentId 
RIGHT OUTER JOIN 	vPr_PointsLastIndication 
LEFT OUTER JOIN 	vPr_HistoryMaxCounters AS chMax 
INNER JOIN 			CounterTypes AS ct ON chMax.CounterTypeId = ct.CounterTypeId ON 
					vPr_PointsLastIndication.PointId = chMax.PointId ON p.PointId = vPr_PointsLastIndication.PointId
GO
GRANT SELECT ON vPr_PointsCountNoIndication TO KvzWorker
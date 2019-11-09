IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_Garages' AND type = 'V')
    DROP VIEW vPr_Garages
GO
CREATE VIEW vPr_Garages
AS
-- Гаражи и заодно проверка привязки их к ОДУ
SELECT p.AbonentId, p.PointNumber, a.CommAddressString AS AddressString, a.LastSurName, e.Name AS TariffName, ppa.CommAddressString, ppc.AccountStatusName,
'UPDATE AbonentsHistory SET JuricticFacesId = NULL WHERE AbonentId = ' + CAST(a.AbonentId AS VARCHAR) + 
' AND DtChange = ''' + CONVERT(VARCHAR, (SELECT MAX(ah.DtChange) FROM AbonentsHistory AS ah WHERE ah.AbonentId = a.AbonentId), 104) + '''' 
AS QueryString
FROM vPr_HistoryMaxPoints AS phmp 
INNER JOIN Points AS p ON phmp.PointId = p.PointId
INNER JOIN Elements AS e ON phmp.TariffId = e.ElementId
INNER JOIN vAbonents AS a ON p.AbonentId = a.AbonentId
INNER JOIN vPoints_ListPointsStatus AS plps ON p.PointId = plps.PointId AND p.AbonentId = plps.AbonentId
LEFT JOIN vSchemes_PointsPublicCommunication_DtEnd AS ppc ON p.PointId = ppc.PointId AND ppc.DtEnd > GETDATE() 
LEFT JOIN vPointsPublicAccount AS ppa ON ppc.PublicPointId = ppa.PublicPointId
WHERE a.CalcTypeId = 2 AND plps.AccountStatusId != 2 AND plps.AbonentStatusId = 1 AND p.EnergyTypeId = 1
GO
GRANT SELECT ON vPr_Garages TO KvzWorker
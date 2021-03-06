IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PointsTariff' AND type = 'V')
    DROP VIEW vPr_PointsTariff
GO

CREATE VIEW dbo.vPr_PointsTariff
AS
SELECT
	p.PointId
   ,p.DtChange
   ,p.PointNumber
   ,dbo.vAbonents.LastSurName
   ,dbo.vAbonents.CommAddressString
   ,dbo.Elements.Name AS TariffName
   ,dbo.PointsHistory.TariffId
   ,fnGetPointLastIndication_1.DtDoc AS DtLastIndication
   ,fnGetPointLastIndication_1.NewIndication AS LastIndication
FROM (SELECT
		dbo.Points.PointId
	   ,(SELECT
				MAX(DtChange) AS DtChange
			FROM dbo.PointsHistory AS ph
			WHERE (PointId = dbo.Points.PointId))
		AS DtChange
	   ,dbo.Points.PointNumber
	   ,dbo.Points.AbonentId
	FROM dbo.Points
	INNER JOIN (SELECT
			a.AbonentId
		   ,a.DtChange
		   ,ah.AbonentStatusId
		FROM (SELECT
				AbonentId
			   ,(SELECT
						MAX(DtChange) AS d
					FROM dbo.AbonentsHistory
					WHERE (AbonentId = Abonents_1.AbonentId))
				AS DtChange
			FROM dbo.Abonents AS Abonents_1) AS a
		INNER JOIN dbo.AbonentsHistory AS ah
			ON a.AbonentId = ah.AbonentId
			AND a.DtChange = ah.DtChange) AS Abonents
		ON dbo.Points.AbonentId = Abonents.AbonentId
	WHERE (dbo.Points.EnergyTypeId = 1)
	AND (Abonents.AbonentStatusId = 1)) AS p
INNER JOIN dbo.PointsHistory
	ON p.PointId = dbo.PointsHistory.PointId
		AND p.DtChange = dbo.PointsHistory.DtChange
INNER JOIN dbo.Elements
	ON dbo.PointsHistory.TariffId = dbo.Elements.ElementId
INNER JOIN dbo.vAbonents
	ON p.AbonentId = dbo.vAbonents.AbonentId
LEFT OUTER JOIN dbo.fnGetPointLastIndication() AS fnGetPointLastIndication_1
	ON p.PointId = fnGetPointLastIndication_1.PointId
WHERE (dbo.PointsHistory.AccountStatusId = 1)
GO

GRANT SELECT ON vPr_PointsTariff TO KvzWorker
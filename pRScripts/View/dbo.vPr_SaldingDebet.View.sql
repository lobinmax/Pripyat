IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_SaldingDebet' AND type = 'V')
    DROP VIEW vPr_SaldingDebet
GO

CREATE VIEW dbo.vPr_SaldingDebet
AS
SELECT
	e2.Num
   ,ISNULL(PointDebet.SumDebet, 0.00) AS SumDebet
   ,ISNULL(PointCredet.SumCredet, 0.00) AS SumCredet
   ,CAST(ISNULL(PointDebet.SumDebet, 0.00)
	AS MONEY) + CAST(ISNULL(PointCredet.SumCredet, 0.00) AS MONEY) AS SaldingDebet
   ,Pr_fnGetCountAbonentPoints_1.CountTY
   ,vAbonentsShort.LastSurName
   ,vAbonentsShort.CommAddressString AS AddressString
   ,e1.Name AS InspectorName
FROM Abonents
LEFT OUTER JOIN Elements AS e1
	ON Abonents.ControllerId = e1.ElementId
LEFT OUTER JOIN vAbonentsShort
	ON Abonents.AbonentId = vAbonentsShort.AbonentId
LEFT OUTER JOIN dbo.Pr_fnGetCountAbonentPoints() AS Pr_fnGetCountAbonentPoints_1
	ON Abonents.AbonentId = Pr_fnGetCountAbonentPoints_1.AbonentId
LEFT OUTER JOIN (SELECT
		Points_1.AbonentId
	   ,SUM(PointCredet_1.Balans) AS SumCredet
	FROM Points AS Points_1
	INNER JOIN (SELECT
			PointId
		   ,Balans
		FROM vPointBalansedTm AS vPointBalansedTm_1
		WHERE (Balans > 0)) AS PointCredet_1
		ON Points_1.PointId = PointCredet_1.PointId
	GROUP BY Points_1.AbonentId
			,Points_1.EnergyTypeId
	HAVING (Points_1.EnergyTypeId = 1)) AS PointCredet
	ON Abonents.AbonentId = PointCredet.AbonentId
LEFT OUTER JOIN (SELECT
		Points.AbonentId
	   ,SUM(PointDebet_1.Balans) AS SumDebet
	FROM (SELECT
			PointId
		   ,Balans
		FROM vPointBalansedTm
		WHERE (Balans < 0)) AS PointDebet_1
	INNER JOIN Points
		ON PointDebet_1.PointId = Points.PointId
	GROUP BY Points.AbonentId
			,Points.EnergyTypeId
	HAVING (Points.EnergyTypeId = 1)) AS PointDebet
	ON Abonents.AbonentId = PointDebet.AbonentId
LEFT OUTER JOIN Elements AS e2
	ON Abonents.AbonentId = e2.ElementId
WHERE (NOT (Pr_fnGetCountAbonentPoints_1.CountTY IS NULL))
AND (Pr_fnGetCountAbonentPoints_1.CountTY > 1)
GO

GRANT SELECT ON vPr_SaldingDebet TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_ISUPointsList' AND type = 'V')
    DROP VIEW vPr_ISUPointsList
GO
CREATE VIEW dbo.vPr_ISUPointsList
AS
SELECT TOP 3000000 
	 			pi.PointId, 
				pi.AbonentId, 
				pi.AbonNumber, 
				pi.PointNumber, 
				dbo.Pr_fnsGetShortFNS(pi.AbonentName, 0, 0) AS FNP, 
				pi.Address, 
				cp.CounterPlaceId, 
				cp.Name AS CounterPlace, 
				CAST(ct.OldTypeId AS varchar) + ' - ' + pi.CounterName AS CounterName, 
				pi.CounterNumber, 
				pi.NetworkName, 
				ISNULL(plOnCloseMonth.LossesLine, 0.0000) AS LossesLine, 
				ast.Name AS AbonentStatus, 
				eas.Name AS AbonentReason, 
				ps_1.Name AS PointStatus
FROM 			Pr_ISUCounterList AS ISU 
INNER JOIN 		CounterTypes AS ct ON ISU.CounterTypeId = ct.CounterTypeId 
INNER JOIN 		vPoints_ListPointsInformation AS pi ON ISU.CounterTypeId = pi.CounterTypeId 
INNER JOIN 		AbonentStatus AS ast 
INNER JOIN 		vPoints_ListPointsStatus AS ps ON ast.AbonentStatusId = ps.AbonentStatusId 
INNER JOIN 		AccountStatus AS ps_1 ON ps.PointStatusId = ps_1.AccountStatusId 
INNER JOIN 		ExtAbonentStatus AS eas ON ps.ExtAbonentStatusId = eas.ExtAbonentStatusId ON pi.PointId = ps.PointId 
INNER JOIN 		CounterPlace AS cp ON pi.CounterPlaceId = cp.CounterPlaceId 
LEFT OUTER JOIN (
				SELECT	PointId, 
						PeriodNumber, 
						LossesLine, 
						DtUpdate, 
						PerformerId
   				FROM 	PointsLossesLineHistory AS pl
          		WHERE	PeriodNumber = 	(
										SELECT	Closed
                                    	FROM	vMaxClosedPeriod
										)
				) AS plOnCloseMonth ON pi.PointId = plOnCloseMonth.PointId
ORDER BY 		pi.Areal, pi.CityVillage, pi.Street, pi.House, pi.LetterHouse, pi.Room
GO
GRANT SELECT ON vPr_ISUPointsList TO KvzWorker
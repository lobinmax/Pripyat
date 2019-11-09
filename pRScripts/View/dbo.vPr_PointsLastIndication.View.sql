IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PointsLastIndication' AND type = 'V')
    DROP VIEW vPr_PointsLastIndication
GO

CREATE VIEW dbo.vPr_PointsLastIndication
AS
SELECT DISTINCT 	m.DocumentId, 
					m.PointId, 
					Points.PointNumber, 
					m.DtBegin, 
					m.OldIndication, 
					m.DtDoc, 
					m.NewIndication AS LastIndication, 
					m.Consumption, 
					DATEDIFF(month, m.DtDoc, (SELECT DtBegin FROM vKernel_PeriodNumberOpenMin)) - 1 AS CountNoIndication, 
					m.PeriodNumber, 
					m.MonthDtDoc
FROM            	vMemoOrdersShort AS m 
INNER JOIN 			(
					SELECT		m.PointId, 
								MAX(d.DtDoc) AS DtDoc
             		FROM		Documents AS d 
					INNER JOIN 	MemoOrders AS m ON m.DocumentId = d.DocumentId 
					INNER JOIN 	Articles AS a ON a.ArticleId = m.ArticleId 
					INNER JOIN	ChargePacks AS p ON m.PackId = p.PackId
           			WHERE       d.StateId = 5 AND p.PackTypeId IN (0, 2)
                 	GROUP BY 	m.PointId
					) AS c ON c.PointId = m.PointId AND c.DtDoc = m.DtDoc AND m.DocumentTypeId IN (3, 4, 5) AND m.StateId = 5 AND m.PackTypeId IN (0, 2) 
INNER JOIN 			Points ON m.PointId = Points.PointId
GO

GRANT SELECT ON vPr_PointsLastIndication TO KvzWorker
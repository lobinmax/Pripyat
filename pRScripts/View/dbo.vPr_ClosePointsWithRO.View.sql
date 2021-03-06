IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_ClosePointsWithRO' AND type = 'V')
    DROP VIEW dbo.vPr_ClosePointsWithRO
GO
-- ТУ закрытые с РО
CREATE VIEW dbo.vPr_ClosePointsWithRO
AS
SELECT
	dbo.vSchemes_PointsHistory_DtEnd.PointNumber
   ,dbo.vSchemes_PointsHistory_DtEnd.DtChange AS DtClose
   ,dbo.vSchemes_PointsHistory_DtEnd.AccountStatusName
   ,dbo.vPoints_ListPointsInformation.Address
   ,dbo.vPoints_ListPointsInformation.PointName
   ,dbo.vPoints_ListPointsInformation.CounterName
   ,dbo.vPoints_ListPointsInformation.CounterNumber
   ,dbo.vPoints_ListPointsInformation.NetworkName
FROM dbo.vSchemes_PointsHistory_DtEnd
INNER JOIN (SELECT
		MAX(DocumentId) AS MaxDocumentId
	   ,PointId
	FROM dbo.vMemoOrders
	GROUP BY PointId) AS MaxMemoOrders
	ON dbo.vSchemes_PointsHistory_DtEnd.PointId = MaxMemoOrders.PointId
INNER JOIN dbo.vPoints_ListPointsInformation
	ON dbo.vSchemes_PointsHistory_DtEnd.PointId = dbo.vPoints_ListPointsInformation.PointId
LEFT OUTER JOIN dbo.vMemoOrders AS vMemoOrders_1
	ON MaxMemoOrders.MaxDocumentId = vMemoOrders_1.DocumentId
GROUP BY dbo.vSchemes_PointsHistory_DtEnd.DtEnd
		,dbo.vSchemes_PointsHistory_DtEnd.PointNumber
		,dbo.vSchemes_PointsHistory_DtEnd.EnergyTypeId
		,dbo.vSchemes_PointsHistory_DtEnd.AccountStatusId
		,vMemoOrders_1.PackTypeId
		,vMemoOrders_1.DocumentTypeId
		,dbo.vSchemes_PointsHistory_DtEnd.DtChange
		,dbo.vSchemes_PointsHistory_DtEnd.AccountStatusName
		,dbo.vPoints_ListPointsInformation.Address
		,dbo.vPoints_ListPointsInformation.PointName
		,dbo.vPoints_ListPointsInformation.CounterName
		,dbo.vPoints_ListPointsInformation.CounterNumber
		,dbo.vPoints_ListPointsInformation.NetworkName
		,vMemoOrders_1.ArticleNumber
HAVING (dbo.vSchemes_PointsHistory_DtEnd.DtEnd = CAST('01.01.2079' AS DATE))
AND (dbo.vSchemes_PointsHistory_DtEnd.EnergyTypeId = 1)
AND (dbo.vSchemes_PointsHistory_DtEnd.AccountStatusId = 2)
AND (vMemoOrders_1.PackTypeId = 1)
AND (vMemoOrders_1.DocumentTypeId <> 8
AND vMemoOrders_1.DocumentTypeId <> 2)
AND (vMemoOrders_1.ArticleNumber <> '92')
AND (dbo.vPoints_ListPointsInformation.CounterName <> 'Бесприборный учёт')
GO

GRANT SELECT ON dbo.vPr_ClosePointsWithRO TO KvzWorker
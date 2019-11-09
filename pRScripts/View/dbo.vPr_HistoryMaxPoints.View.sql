IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_HistoryMaxPoints' AND type = 'V')
    DROP VIEW vPr_HistoryMaxPoints
GO

CREATE VIEW dbo.vPr_HistoryMaxPoints
AS
SELECT
	pMaxDt.PointId
   ,pMaxDt.DtChange
   ,p.TariffId
   ,p.NormId
   ,p.AccountTypeId
   ,p.PerformerId
   ,p.AccountStatusId
   ,p.Indication
   ,p.ConsumMIddle
   ,p.LossesLine
   ,p.DtUpdate
   ,p.LossesTran
   ,p.AccountDay
   ,p.SchemeExhAccountsId
   ,p.ConsumptionFactor
   ,p.CondPermLoss
   ,p.PeriodNumber
   ,p.PossibilityDevice
   ,p.DtEnd
FROM (SELECT
		PointId
	   ,MAX(DtChange) AS DtChange
	FROM dbo.PointsHistory
	GROUP BY PointId) AS pMaxDt
LEFT OUTER JOIN dbo.PointsHistory AS p
	ON pMaxDt.DtChange = p.DtChange
		AND pMaxDt.PointId = p.PointId
GROUP BY pMaxDt.PointId
		,pMaxDt.DtChange
		,p.TariffId
		,p.NormId
		,p.AccountTypeId
		,p.PerformerId
		,p.AccountStatusId
		,p.Indication
		,p.ConsumMIddle
		,p.LossesLine
		,p.DtUpdate
		,p.LossesTran
		,p.AccountDay
		,p.SchemeExhAccountsId
		,p.ConsumptionFactor
		,p.CondPermLoss
		,p.PeriodNumber
		,p.DtEnd
		,p.PossibilityDevice
GO

GRANT SELECT ON vPr_HistoryMaxPoints TO KvzWorker
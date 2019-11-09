IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_HistoryMaxCounters' AND type = 'V')
    DROP VIEW vPr_HistoryMaxCounters
GO

CREATE VIEW dbo.vPr_HistoryMaxCounters
AS
SELECT
	chMax.PointId
   ,chMax.DtCountSetup
   ,ch.CounterTypeId
   ,ch.PerformerId
   ,ch.CounterStatusId
   ,ch.ReplaceReasonId
   ,ch.CounterPlaceId
   ,ch.CounterNumber
   ,ch.TransFactor
   ,ch.IndicationSetup
   ,ch.DtCountRemove
   ,ch.IndicationRemove
   ,ch.DtCountVerify
   ,ch.DtUpdate
   ,ch.DocumentId
   ,ch.VoltageCalculate
   ,ch.PeriodNumber
   ,ch.DtEnd
FROM dbo.CountersHistory ch
INNER JOIN (SELECT
		CountersHistory.PointId
	   ,MAX(CountersHistory.DtCountSetup) AS DtCountSetup
	FROM dbo.CountersHistory
	GROUP BY CountersHistory.PointId) chMax
	ON ch.PointId = chMax.PointId
		AND ch.DtCountSetup = chMax.DtCountSetup
GROUP BY ch.CounterTypeId
		,ch.PerformerId
		,ch.CounterStatusId
		,ch.ReplaceReasonId
		,ch.CounterPlaceId
		,ch.CounterNumber
		,ch.TransFactor
		,ch.IndicationSetup
		,ch.DtCountRemove
		,ch.IndicationRemove
		,ch.DtCountVerify
		,ch.DtUpdate
		,ch.DocumentId
		,ch.VoltageCalculate
		,ch.PeriodNumber
		,ch.DtEnd
		,chMax.PointId
		,chMax.DtCountSetup
GO

GRANT SELECT ON vPr_HistoryMaxCounters TO KvzWorker
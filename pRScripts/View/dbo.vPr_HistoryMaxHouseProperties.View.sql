IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_HistoryMaxHouseProperties' AND type = 'V')
    DROP VIEW vPr_HistoryMaxHouseProperties
GO

CREATE VIEW dbo.vPr_HistoryMaxHouseProperties 
AS SELECT
	hpMax.AbonentId
   ,hpMax.DtChange
   ,hp.HousePropId
   ,hp.PerformerId
   ,hp.DtUpdate
   ,hp.DtEnd
FROM HousePropertiesHistory AS hp
INNER JOIN (SELECT
		AbonentId
	   ,MAX(DtChange) AS DtChange
	FROM HousePropertiesHistory
	GROUP BY AbonentId) AS hpMax
	ON hp.AbonentId = hpMax.AbonentId
		AND hp.DtChange = hpMax.DtChange
GROUP BY hpMax.AbonentId
		,hpMax.DtChange
		,hp.HousePropId
		,hp.PerformerId
		,hp.DtUpdate
		,hp.DtEnd
GO

GRANT SELECT ON vPr_HistoryMaxHouseProperties TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_HistoryMaxAbonents' AND type = 'V')
    DROP VIEW vPr_HistoryMaxAbonents
GO

CREATE VIEW dbo.vPr_HistoryMaxAbonents
AS
SELECT
	ahMax.AbonentId
   ,ahMax.DtChange
   ,ah.FamilyMemberId
   ,ah.PerformerId
   ,ah.AbonentStatusId
   ,ah.HouseStatusId
   ,ah.HouseOwnerId
   ,ah.DtUpdate
   ,ah.CookerId
   ,ah.NotPlaneAccounts
   ,ah.JuricticFacesId
   ,ah.ExtAbonentStatusId
   ,ah.Notes
   ,ah.PeriodNumber
   ,ah.DtEnd
FROM AbonentsHistory AS ah
RIGHT OUTER JOIN (SELECT
		AbonentId
	   ,MAX(DtChange) AS DtChange
	FROM AbonentsHistory
	GROUP BY AbonentId) AS ahMax
	ON ah.AbonentId = ahMax.AbonentId
		AND ah.DtChange = ahMax.DtChange
GROUP BY ahMax.AbonentId
		,ahMax.DtChange
		,ah.FamilyMemberId
		,ah.PerformerId
		,ah.AbonentStatusId
		,ah.HouseStatusId
		,ah.HouseOwnerId
		,ah.DtUpdate
		,ah.CookerId
		,ah.NotPlaneAccounts
		,ah.JuricticFacesId
		,ah.ExtAbonentStatusId
		,ah.Notes
		,ah.PeriodNumber
		,ah.DtEnd
GO

GRANT SELECT ON vPr_HistoryMaxAbonents TO KvzWorker
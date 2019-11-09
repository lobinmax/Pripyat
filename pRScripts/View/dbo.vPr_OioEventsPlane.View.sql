IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_OioEventsPlane' AND type = 'V')
    DROP VIEW vPr_OioEventsPlane
GO

CREATE VIEW dbo.vPr_OioEventsPlane
AS
SELECT
	e.Num
   ,ev.AbonentId
   ,ev.DtBeginOio
   ,ev.DtDoc
   ,ev.KVZ_EventTypeId
   ,ev.DtFact1
   ,ev.DtFact3
   ,CAST(CAST(CASE
		WHEN ev.KVZ_EventTypeId IN (1, 2, 5) THEN 1
		ELSE 0
	END AS VARCHAR) + CAST(CASE
		WHEN ev.KVZ_EventTypeId IN (2, 5) THEN 1
		ELSE 0
	END AS VARCHAR) + CAST(CASE
		WHEN ev.KVZ_EventTypeId IN (3,
			6, 8) THEN 1
		ELSE 0
	END AS VARCHAR) AS INT) AS prEventGroup
   ,dbo.vPr_OioEventsTypes.prEventTypeId
   ,dbo.vPr_OioEventsTypes.prEventName
   ,dbo.vOiohouseproperties.HousePropId
   ,ev.OioResolutionTypeId
FROM (SELECT
		OioA.AbonentId
	   ,OioA.DtBeginOio
	   ,dbo.Pr_fsnOiOGetNextEventDate(OioA.AbonentId) AS DtDoc
	   ,dbo.Pr_fsnOiOGetNextEventType(OioA.AbonentId)
		AS KVZ_EventTypeId
	   ,OioEv1.DtFact AS DtFact1
	   ,OioEv3.DtFact AS DtFact3
	   ,dbo.Pr_fnsGetCurentResolutionType(vA.CalcTypeId, OioA.DtBeginOio)
		AS OioResolutionTypeId
	FROM dbo.OioAbonents AS OioA
	LEFT OUTER JOIN dbo.vAbonents AS vA
		ON OioA.AbonentId = vA.AbonentId
	LEFT OUTER JOIN dbo.OioEvents AS OioEv3
		ON OioA.AbonentId = OioEv3.AbonentId
		AND OioA.DtBeginOio = OioEv3.DtBeginOio
		AND OioEv3.EventTypeId = 3
	LEFT OUTER JOIN dbo.OioEvents AS OioEv6
		ON OioA.AbonentId = OioEv6.AbonentId
		AND OioA.DtBeginOio = OioEv6.DtBeginOio
		AND OioEv6.EventTypeId = 6
	LEFT OUTER JOIN dbo.OioEvents AS OioEv1
		ON OioA.AbonentId = OioEv1.AbonentId
		AND OioA.DtBeginOio = OioEv1.DtBeginOio
		AND OioEv1.EventTypeId = 1
	LEFT OUTER JOIN dbo.OioEvents AS OioEv2
		ON OioA.AbonentId = OioEv2.AbonentId
		AND OioA.DtBeginOio = OioEv2.DtBeginOio
		AND OioEv2.EventTypeId = 2
	LEFT OUTER JOIN dbo.OioEvents AS OioEv5
		ON OioA.AbonentId = OioEv5.AbonentId
		AND OioA.DtBeginOio = OioEv5.DtBeginOio
		AND OioEv5.EventTypeId = 5
	WHERE (OioA.DtEndOio > GETDATE())) AS ev
INNER JOIN dbo.Abonents
	ON ev.AbonentId = dbo.Abonents.AbonentId
INNER JOIN dbo.vPr_OioEventsTypes
	ON ev.KVZ_EventTypeId = dbo.vPr_OioEventsTypes.KVZ_EventTypeId
		AND dbo.vPr_OioEventsTypes.prHouseTypeId = dbo.Abonents.HousingOptionId
INNER JOIN dbo.Elements AS e
	ON dbo.Abonents.AbonentId = e.ElementId
LEFT OUTER JOIN (SELECT TOP (100) PERCENT
		vGA.AbonentId
	   ,vGA.DtBeginAgreement
	   ,GA.DtEndAgreement
	   ,vGA.StateId
	FROM dbo.vSchemes_GuaranteeAgreements_DtEnd AS vGA
	LEFT OUTER JOIN dbo.GuaranteeAgreements AS GA
		ON vGA.DtBeginAgreement = GA.DtBeginAgreement
		AND vGA.AbonentId = GA.AbonentId
	WHERE (vGA.AgreementTypeId = 1)
	AND (vGA.DtEnd > GETDATE())
	AND (GA.DtEndAgreement > GETDATE())
	AND (vGA.StateId <> 1)
	ORDER BY vGA.AbonentId) AS GA1
	ON dbo.Abonents.AbonentId = GA1.AbonentId
LEFT OUTER JOIN dbo.vOiohouseproperties
	ON dbo.Abonents.AbonentId = dbo.vOiohouseproperties.AbonentId
GO

GRANT SELECT ON vPr_OioEventsPlane TO KvzWorker
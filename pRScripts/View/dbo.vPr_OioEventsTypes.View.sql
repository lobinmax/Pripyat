IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_OioEventsTypes' AND type = 'V')
    DROP VIEW vPr_OioEventsTypes
GO

CREATE VIEW dbo.vPr_OioEventsTypes
AS
SELECT DISTINCT
	dbo.Pr_OioEventsTypes.prEventTypeId
   ,dbo.Pr_OioEventsTypes.prEventName + ' ' + dbo.Pr_HouseType.ShortName AS prEventName
   ,dbo.OioEventsTypes.EventTypeId AS KVZ_EventTypeId
   ,dbo.Pr_HouseType.prHouseTypeId
   ,dbo.Pr_OioEventsTypes.prEventNameShort + ' ' + dbo.Pr_HouseType.ShortName AS prEventNameShort
FROM dbo.Pr_HouseType
INNER JOIN dbo.Pr_OioEventsTypes
	ON dbo.Pr_HouseType.prHouseTypeId = dbo.Pr_OioEventsTypes.prHouseTypeId
INNER JOIN dbo.OioEventsTypes
	ON dbo.Pr_OioEventsTypes.KVZ_EventTypeId = dbo.OioEventsTypes.EventTypeId
GO

GRANT SELECT ON vPr_OioEventsTypes TO KvzWorker
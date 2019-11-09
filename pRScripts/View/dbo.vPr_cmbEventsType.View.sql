IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmbEventsType' AND type = 'V')
    DROP VIEW vPr_cmbEventsType
GO
--
CREATE VIEW dbo.vPr_cmbEventsType 
AS SELECT TOP 100 
	e.KVZ_EventTypeId AS EventTypeId
   ,e.prEventName AS EventName
FROM dbo.Pr_OioEventsTypes e
WHERE e.KVZ_EventTypeId NOT IN (4, 7)
GROUP BY e.KVZ_EventTypeId, e.prEventName
ORDER BY EventTypeId
GO
GRANT SELECT ON vPr_cmbEventsType TO KvzWorker
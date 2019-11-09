IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmbCountersType' AND type = 'V')
    DROP VIEW vPr_cmbCountersType
GO
CREATE VIEW vPr_cmbCountersType
AS
SELECT 	CAST(ct.Signs AS VARCHAR) + ' - значные приборы учета' AS RootNodeName,
	  	ct.CounterTypeId,
	  	ct.FullCounterName,
		ct.Signs
FROM 	dbo.vCounterTypes AS ct
WHERE 	ct.EnergyTypeId = 1
GO
GRANT SELECT ON vPr_cmbCountersType TO KvzWorker
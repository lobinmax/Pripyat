IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_TSO' AND type = 'V')
    DROP VIEW vPr_TSO
GO
--
CREATE VIEW vPr_TSO
AS
SELECT 	pt.TSOId, 
		pt.TSOName, 
		pt.TSOAddress, 
		pt.TSOEmail, 
		pt.TSOPhone, 
		pt.TSOPhoneMobile, 
		dbo.Pr_fnsGetShortFNS('', pt.CreaterId, 1) AS CreaterName, 
		pt.CreateDt,  
		dbo.Pr_fnsGetShortFNS('', pt.UpdaterId, 1) AS UpdaterName, 
		pt.UpdateDt 
FROM 	Pr_TSO pt
--
GO
GRANT SELECT ON vPr_TSO TO KvzWorker
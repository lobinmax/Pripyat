IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PacksODU_Delete' AND type = 'V')
    DROP VIEW vPr_PacksODU_Delete
GO
--
CREATE VIEW vPr_PacksODU_Delete
AS
SELECT        	pODU.PublicPointId, 
				cp.PackId, 
				pODU.CommAddressString, 
				cp.Notes, 
				'exec dbo.Documents_ChargePacksDelete @PackId =  ' + CAST(cp.PackId AS varchar) AS Query
FROM            dbo.Pr_PacksODU_Delete AS pODU 
INNER JOIN 		dbo.ChargePacks AS cp ON 'ОДУ: ' + pODU.CommAddressString = cp.Notes
WHERE        	cp.PeriodNumber = 	(SELECT        PeriodNumber
									FROM            dbo.vKernel_PeriodNumberOpenMin
									)
--
GO
GRANT SELECT ON vPr_PacksODU_Delete TO KvzWorker
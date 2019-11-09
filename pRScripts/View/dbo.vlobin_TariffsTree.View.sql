IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vlobin_TariffsTree' AND type = 'V')
    DROP VIEW vlobin_TariffsTree
GO
--
CREATE VIEW vlobin_TariffsTree
AS
SELECT TOP (100) PERCENT t2.Name1 AS EnergyTypeName, 
						 t1.TariffId, t2.TariffId AS 
						 TariffTypeNormId, 
						 t2.TariffTypeId, 
						 t2.TariffMainId AS ChildTariffId, 
                         t1.GroupId AS GroupCookerId, 
						 t2.Name2 AS TariffName, 
						 t2.Name3 AS ChildTariffName, 
						 t2.Name4 AS TariffTypeNormName, 
                         g.Name AS GroupCookerName, 
						 h.DtChange AS DtChangeTariff, 
						 h.TariffCount
FROM		dbo.TariffCookerCommunication AS t1 INNER JOIN
			dbo.vTariffs AS t2 ON t1.TariffId = t2.ParentId INNER JOIN
			dbo.TariffsHistory AS h ON t2.TariffMainId = h.TariffId INNER JOIN
			dbo.TariffCookerGroups AS g ON t1.GroupId = g.GroupId
ORDER BY	t1.TariffId, ChildTariffId, TariffTypeNormId
GO
GRANT SELECT ON vlobin_TariffsTree TO KvzWorker
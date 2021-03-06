IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_HouseType' AND type = 'V')
    DROP VIEW vPr_HouseType
GO

CREATE VIEW dbo.vPr_HouseType
AS
SELECT DISTINCT
	prHouseTypeId
   ,Name
FROM dbo.Pr_HouseType
GO

GRANT SELECT ON vPr_HouseType TO KvzWorker
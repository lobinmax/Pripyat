IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PointsPublicSectionsSchemes' AND type = 'V')
    DROP VIEW vPr_PointsPublicSectionsSchemes
GO
--
CREATE VIEW vPr_PointsPublicSectionsSchemes
AS
SELECT TOP(100) * FROM Pr_PointsPublicSectionsSchemes AS pppss
ORDER BY pppss.SchemesId
--
GO
GRANT SELECT ON vPr_PointsPublicSectionsSchemes TO KvzWorker
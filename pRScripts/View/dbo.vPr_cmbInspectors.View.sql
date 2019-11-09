IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_cmbInspectors' AND type = 'V')
    DROP VIEW vPr_cmbInspectors
GO
--
CREATE VIEW dbo.vPr_cmbInspectors 
AS SELECT  TOP(100) PERCENT 'NULL' AS InspectorId, 'Все участки контролеров' AS Inspector
UNION ALL
SELECT * FROM 	(	
				SELECT TOP 100
				CAST(i.InspectorId AS VARCHAR) AS InspectorId,
   				i.Inspector
				FROM dbo.vPr_InspoctorsTree i
				ORDER BY i.Inspector
				) AS i_
GO
GRANT SELECT ON vPr_cmbInspectors TO KvzWorker
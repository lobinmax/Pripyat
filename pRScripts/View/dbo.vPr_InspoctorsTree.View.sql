IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_InspoctorsTree' AND type = 'V')
    DROP VIEW vPr_InspoctorsTree
GO
--
CREATE VIEW vPr_InspoctorsTree
AS
SELECT TOP(100) PERCENT m.Value AS ManagerId, 
						ChIG.InspectorId AS ChiefInspectorId, 
						IG.InspectorId, 
						e1.Name AS Manager, 
						e2.Name AS ChiefInspector, 
						e3.Name AS Inspector
FROM					Elements AS e1 
INNER JOIN 				(
						SELECT	Value
						FROM	Pr_PripyatConstants
						WHERE 	Name = 'ManagerId'
						) AS m ON e1.ElementId = m.Value 
INNER JOIN 				Elements AS e2 
INNER JOIN 				InspectorGroups AS ChIG ON e2.ElementId = ChIG.InspectorId 
INNER JOIN 				InspectorGroups AS IG ON ChIG.InspectorId = IG.ChiefInspectorId 
INNER JOIN 				Elements AS e3 ON IG.InspectorId = e3.ElementId ON m.Value = ChIG.ChiefInspectorId
ORDER BY 				Manager, 
						ChiefInspector, 
						Inspector
--
GO
GRANT SELECT ON vPr_InspoctorsTree TO KvzWorker
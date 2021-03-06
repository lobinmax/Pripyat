IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnGetCountAbonentPoints' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnGetCountAbonentPoints
GO

CREATE FUNCTION [dbo].[Pr_fnGetCountAbonentPoints]
	(
	--Функция возвращает количество ТУ по каждому абоненту
	)
RETURNS TABLE
AS
	RETURN SELECT     dbo.Abonents.AbonentId, COUNT(dbo.Points.PointId) AS CountTY
	FROM         dbo.Points 
	INNER JOIN	dbo.Abonents ON dbo.Points.AbonentId = dbo.Abonents.AbonentId
	GROUP BY dbo.Abonents.AbonentId, dbo.Points.EnergyTypeId
	HAVING      (dbo.Points.EnergyTypeId = 1)
GO

GRANT SELECT ON Pr_fnGetCountAbonentPoints TO KvzWorker
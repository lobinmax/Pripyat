IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetAbonentGKO' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_GetAbonentGKO
GO

CREATE FUNCTION [dbo].[Pr_GetAbonentGKO]
	(
--Функция возвращает ЖКО по каждому абоненту
	)
		RETURNS  TABLE 
	AS	RETURN SELECT     dbo.Abonents.AbonentId, dbo.Elements.Name AS GKO
FROM         dbo.Elements INNER JOIN
                      dbo.GKO ON dbo.Elements.ElementId = dbo.GKO.GkoId RIGHT OUTER JOIN
                      dbo.Abonents ON dbo.GKO.GkoId = dbo.Abonents.GkoId
GO

GRANT SELECT ON Pr_GetAbonentGKO TO KvzWorker
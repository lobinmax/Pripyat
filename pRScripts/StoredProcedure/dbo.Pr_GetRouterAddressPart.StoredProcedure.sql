IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetRouterAddressPart' AND type = 'P')
    DROP PROCEDURE dbo.Pr_GetRouterAddressPart
GO

CREATE PROCEDURE [dbo].[Pr_GetRouterAddressPart]
-- Процедура вычисляет текущий маршрут на улице контролера
@AddressPartId INT,	
@ControllerId INT

AS	

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

	SELECT		vSpecAddress.Name  as Route

	FROM		SpecArealAbonent INNER JOIN
	  			Abonents ON SpecArealAbonent.AbonentId = Abonents.AbonentId INNER JOIN
				vSpecAddress ON SpecArealAbonent.SpecArealId = vSpecAddress.SpecArealId

	GROUP BY	vSpecAddress.Name, Abonents.AddressPartId, Abonents.ControllerId

	HAVING		(Abonents.AddressPartId = @AddressPartId) AND 
				(Abonents.ControllerId = @ControllerId)
GO

GRANT EXECUTE ON dbo.Pr_GetRouterAddressPart TO KvzWorker
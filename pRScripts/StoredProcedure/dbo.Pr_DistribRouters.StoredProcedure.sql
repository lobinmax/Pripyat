IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_DistribRouters' AND type = 'P')
    DROP PROCEDURE dbo.Pr_DistribRouters
GO

CREATE PROCEDURE [dbo].[Pr_DistribRouters]
-- Процедурры для управления распределением маршрутов контролеров
	@NodeLevel		INT = NULL,		-- Уровень в дереве испектров
	@PerformerId	INT = NULL,		-- ИД выбранного инспектра
	@RouterId		INT = NULL,		-- ИД маршрута
	@AddressPartId	INT = NULL,		-- ИД части адреса
	@ArealId		INT = NULL,		-- ИД административной единицы
	@Function		INT = 1			-- 1 - SELECT
									-- 2 - INSERT
									-- 3 - UPDATE
									-- 4 - DELETE*/
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

IF @RouterId = '' BEGIN
SET @RouterId = NULL
END

IF @Function = 1  BEGIN
	IF	@NodeLevel = 0 BEGIN -- выбран руководитель
		SELECT DISTINCT 
		                         TAddressDict.AddressPartId, SpecArealAbonent.SpecArealId, Abonents.ControllerId AS InspectorId, vPr_InspoctorsTree.ChiefInspectorId, 
		                         vPr_InspoctorsTree.ManagerId, TAddressDict.AddressString, ISNULL(vSpecAddress.Name, 'Нет спецрайонов') AS Router, Elements.Name AS Inspector, 
		                         vPr_InspoctorsTree.ChiefInspector, vPr_InspoctorsTree.Manager
		FROM            Elements INNER JOIN
		                         Abonents ON Elements.ElementId = Abonents.ControllerId INNER JOIN
		                         TAddressDict ON Abonents.AddressPartId = TAddressDict.AddressPartId INNER JOIN
		                         vPr_InspoctorsTree ON Elements.ElementId = vPr_InspoctorsTree.InspectorId LEFT OUTER JOIN
		                         Points ON Abonents.AbonentId = Points.AbonentId LEFT OUTER JOIN
		                         vSpecAddress INNER JOIN
		                         SpecArealAbonent ON vSpecAddress.SpecArealId = SpecArealAbonent.SpecArealId ON Abonents.AbonentId = SpecArealAbonent.AbonentId
		WHERE        (Points.EnergyTypeId = 1) AND (vPr_InspoctorsTree.ManagerId = ISNULL(@PerformerId, vPr_InspoctorsTree.ManagerId)) AND 
		                         (TAddressDict.AddressPartId = ISNULL(@AddressPartId, TAddressDict.AddressPartId)) AND (SpecArealAbonent.SpecArealId = ISNULL(@RouterId, 
		                         SpecArealAbonent.SpecArealId))
		ORDER BY vPr_InspoctorsTree.ChiefInspector, Inspector, Router, TAddressDict.AddressString

	END

	IF	@NodeLevel = 1 BEGIN -- выбран старший контролер
		SELECT DISTINCT 
		                         TAddressDict.AddressPartId, SpecArealAbonent.SpecArealId, Abonents.ControllerId AS InspectorId, vPr_InspoctorsTree.ChiefInspectorId, 
		                         vPr_InspoctorsTree.ManagerId, TAddressDict.AddressString, ISNULL(vSpecAddress.Name, 'Нет спецрайонов') AS Router, Elements.Name AS Inspector, 
		                         vPr_InspoctorsTree.ChiefInspector, vPr_InspoctorsTree.Manager
		FROM            Elements INNER JOIN
		                         Abonents ON Elements.ElementId = Abonents.ControllerId INNER JOIN
		                         TAddressDict ON Abonents.AddressPartId = TAddressDict.AddressPartId INNER JOIN
		                         vPr_InspoctorsTree ON Elements.ElementId = vPr_InspoctorsTree.InspectorId LEFT OUTER JOIN
		                         Points ON Abonents.AbonentId = Points.AbonentId LEFT OUTER JOIN
		                         vSpecAddress INNER JOIN
		                         SpecArealAbonent ON vSpecAddress.SpecArealId = SpecArealAbonent.SpecArealId ON Abonents.AbonentId = SpecArealAbonent.AbonentId
		WHERE        (Points.EnergyTypeId = 1) AND (vPr_InspoctorsTree.ChiefInspectorId = ISNULL(@PerformerId, vPr_InspoctorsTree.ChiefInspectorId)) AND 
		                         (TAddressDict.AddressPartId = ISNULL(@AddressPartId, TAddressDict.AddressPartId)) AND (SpecArealAbonent.SpecArealId = ISNULL(@RouterId, 
		                         SpecArealAbonent.SpecArealId))
		ORDER BY vPr_InspoctorsTree.ChiefInspector, Inspector, Router, TAddressDict.AddressString
		
	END

	IF	@NodeLevel = 2 begin -- выбран линейный контролер
		SELECT DISTINCT 
		                         TAddressDict.AddressPartId, SpecArealAbonent.SpecArealId, Abonents.ControllerId AS InspectorId, vPr_InspoctorsTree.ChiefInspectorId, 
		                         vPr_InspoctorsTree.ManagerId, TAddressDict.AddressString, ISNULL(vSpecAddress.Name, 'Нет спецрайонов') AS Router, Elements.Name AS Inspector, 
		                         vPr_InspoctorsTree.ChiefInspector, vPr_InspoctorsTree.Manager
		FROM            Elements INNER JOIN
		                         Abonents ON Elements.ElementId = Abonents.ControllerId INNER JOIN
		                         TAddressDict ON Abonents.AddressPartId = TAddressDict.AddressPartId INNER JOIN
		                         vPr_InspoctorsTree ON Elements.ElementId = vPr_InspoctorsTree.InspectorId LEFT OUTER JOIN
		                         Points ON Abonents.AbonentId = Points.AbonentId LEFT OUTER JOIN
		                         vSpecAddress INNER JOIN
		                         SpecArealAbonent ON vSpecAddress.SpecArealId = SpecArealAbonent.SpecArealId ON Abonents.AbonentId = SpecArealAbonent.AbonentId
		WHERE        (Points.EnergyTypeId = 1) AND 
		(Abonents.ControllerId = ISNULL(@PerformerId, Abonents.ControllerId)) AND 
		                         (TAddressDict.AddressPartId = ISNULL(@AddressPartId, TAddressDict.AddressPartId)) AND (SpecArealAbonent.SpecArealId = ISNULL(@RouterId, 
		                         SpecArealAbonent.SpecArealId))
		ORDER BY vPr_InspoctorsTree.ChiefInspector, Inspector, Router, TAddressDict.AddressString
	
	END
END

IF @Function = 3  BEGIN -- Привязка маршрутов
UPDATE       SpecArealAbonent
SET                SpecArealId = @RouterId
FROM            Abonents INNER JOIN
                         AddressPartLink ON Abonents.AddressPartId = AddressPartLink.AddressPartId RIGHT OUTER JOIN
                         SpecArealAbonent ON Abonents.AbonentId = SpecArealAbonent.AbonentId
WHERE			(AddressPartLink.ParentId = ISNULL(@ArealId, AddressPartLink.ParentId)) AND 
				(Abonents.AddressPartId = ISNULL(@AddressPartId, Abonents.AddressPartId)) AND 
				(Abonents.ControllerId = ISNULL(@PerformerId, Abonents.ControllerId))
END
GO

GRANT EXECUTE ON dbo.Pr_DistribRouters TO KvzWorker

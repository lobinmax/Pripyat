IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_ISUPointsList' AND type = 'V')
    DROP VIEW vPr_ISUPointsList -- заненадобностью
GO
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_BindingDataView' AND type = 'P')
    DROP PROCEDURE dbo.Pr_BindingDataView
GO
CREATE PROCEDURE dbo.Pr_BindingDataView
/*
	=========================================
	|	Просмотр данных текущие привязки	|
	=========================================
*/
	
	
	@Function	INT 		-- 0 - Управляющие организации
							-- 1 - Метод доставки ПРД
							-- 2 - Районы города
							-- 3 - Сетевые организации
							-- 4 - Место установки ИСУ 
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- 0 - Управляющие организации
IF @Function = 0 BEGIN 
	SELECT		a.AbonNumber, 
				f.SurName + ' ' + LEFT(f.Name, 1) + '.' + LEFT(f.Patronymic, 1) + '.' AS SNP, 
				a.CommAddressString AS Address, 
				ISNULL(gko.GKOName, 'Нет данных о УК') AS GKOName, 
				ISNULL(gkh.GKHName, 'Нет данных о ОО') AS GKHName
	FROM		Pr_GKH AS gkh 
	INNER JOIN	Pr_Abonents AS pa ON gkh.GKHid = pa.GKHid 
	INNER JOIN 	Pr_GKStructure AS gks ON gkh.GKHid = gks.Id 
	INNER JOIN 	Pr_GKO AS gko ON gks.ParentId = gko.GKOId 
	RIGHT OUTER JOIN vMainFamilyMembers AS f 
	INNER JOIN 	vAbonents AS a ON f.AbonentId = a.AbonentId ON pa.AbonentId = a.AbonentId
	ORDER BY 	a.Areal,
				a.CityVillage,
				a.Street,
				CAST(dbo.Pr_fnStripNonDigits(a.House) AS int),
				a.LetterHouse,
				CAST(dbo.Pr_fnStripNonDigits(a.Room) AS int),
				a.Build,
				a.RoomNumber
END

-- 1 - Метод доставки ПРД
IF @Function = 1 BEGIN 
	SELECT				a.AbonNumber, 
						f.SurName + ' ' + LEFT(f.Name, 1) + '.' + LEFT(f.Patronymic, 1) + '.' AS SNP, 
						a.CommAddressString AS Address, 
						mds.Name AS MailDelivery/*,
						ISNULL(gko.GKOName, 'Нет данных о УК') AS GKOName, 
						ISNULL(gkh.GKHName, 'Нет данных о ОО') AS GKHName, 
						ISNULL(cp.Name, 'Часть города неопределена') AS CityParts*/
	FROM				Pr_CityParts AS cp 
	INNER JOIN 			Pr_GKH AS gkh 
	INNER JOIN 			Pr_Abonents AS pa ON gkh.GKHid = pa.GKHid 
	INNER JOIN 			Pr_GKStructure AS gks ON gkh.GKHid = gks.Id 
	INNER JOIN 			Pr_GKO AS gko ON gks.ParentId = gko.GKOId ON cp.Id = pa.CityPartsId 
	RIGHT OUTER JOIN 	vMainFamilyMembers AS f 
	INNER JOIN 			vAbonents AS a 
	INNER JOIN 			MailDeliverySource AS mds ON a.MailDeliverySourceId = mds.MailDeliverySourceId ON f.AbonentId = a.AbonentId ON pa.AbonentId = a.AbonentId
	ORDER BY 			a.Areal, a.CityVillage, a.Street, a.House, a.LetterHouse, a.Room, a.LetterRoom, a.RoomNumber
END

-- 2 - Районы города
IF @Function = 2 BEGIN 
	SELECT				a.AbonNumber, 
						f.SurName + ' ' + LEFT(f.Name, 1) + '.' + LEFT(f.Patronymic, 1) + '.' AS SNP, 
						a.CommAddressString AS Address/*, 
						mds.Name AS MailDelivery,
						ISNULL(gko.GKOName, 'Нет данных о УК') AS GKOName, 
						ISNULL(gkh.GKHName, 'Нет данных о ОО') AS GKHName*/, 
						ISNULL(cp.Name, 'Часть города неназначена') AS CityParts
	FROM				Pr_CityParts AS cp 
	INNER JOIN 			Pr_GKH AS gkh 
	INNER JOIN 			Pr_Abonents AS pa ON gkh.GKHid = pa.GKHid 
	INNER JOIN 			Pr_GKStructure AS gks ON gkh.GKHid = gks.Id 
	INNER JOIN 			Pr_GKO AS gko ON gks.ParentId = gko.GKOId ON cp.Id = pa.CityPartsId 
	RIGHT OUTER JOIN 	vMainFamilyMembers AS f 
	INNER JOIN 			vAbonents AS a 
	INNER JOIN 			MailDeliverySource AS mds ON a.MailDeliverySourceId = mds.MailDeliverySourceId ON f.AbonentId = a.AbonentId ON pa.AbonentId = a.AbonentId
	ORDER BY 			a.Areal, a.CityVillage, a.Street, a.House, a.LetterHouse, a.Room, a.LetterRoom, a.RoomNumber


END

-- 3 - Сетевые организации
IF @Function = 3 BEGIN 
	SELECT				a.AbonNumber, 
						f.SurName + ' ' + LEFT(f.Name, 1) + '.' + LEFT(f.Patronymic, 1) + '.' AS SNP, 
						a.CommAddressString AS Address, 
						ISNULL(Pr_TSO.TSOName, 
						'Филиал ТСО неназначена') AS TSOName
	FROM				Pr_Points pp
	INNER JOIN 			Points ON pp.PointId = Points.PointId 
	INNER JOIN 			Pr_TSO ON pp.TSOId = Pr_TSO.TSOId 
	RIGHT OUTER JOIN	vMainFamilyMembers AS f 
	INNER JOIN 			vAbonents AS a ON f.AbonentId = a.AbonentId ON pp.AbonentId = a.AbonentId
	ORDER BY 			a.Areal, a.CityVillage, a.Street, a.House, a.LetterHouse, a.Room, a.LetterRoom, a.RoomNumber
END

-- 4 - Место установки ИСУ 
IF @Function = 4 BEGIN
	SELECT			pi.PointId, 
					pi.AbonentId, 
					pi.AbonNumber, 
					pi.PointNumber, 
					dbo.Pr_fnsGetShortFNS(pi.AbonentName, 0, 0) AS FNP, 
					pi.Address, 
					cp.CounterPlaceId, 
					cp.Name AS CounterPlace, 
					CAST(ct.OldTypeId AS varchar) + ' - ' + pi.CounterName AS CounterName, 
					pi.CounterNumber, 
					pi.NetworkName, 
					ISNULL(plOnCloseMonth.LossesLine, 0.0000) AS LossesLine, 
					ast.Name AS AbonentStatus, 
					eas.Name AS AbonentReason, 
					ps_1.Name AS PointStatus
	FROM 			Pr_ISUCounterList AS ISU 
	INNER JOIN 		CounterTypes AS ct ON ISU.CounterTypeId = ct.CounterTypeId 
	INNER JOIN 		vPoints_ListPointsInformation AS pi ON ISU.CounterTypeId = pi.CounterTypeId 
	INNER JOIN 		AbonentStatus AS ast 
	INNER JOIN 		vPoints_ListPointsStatus AS ps ON ast.AbonentStatusId = ps.AbonentStatusId 
	INNER JOIN 		AccountStatus AS ps_1 ON ps.PointStatusId = ps_1.AccountStatusId 
	INNER JOIN 		ExtAbonentStatus AS eas ON ps.ExtAbonentStatusId = eas.ExtAbonentStatusId ON pi.PointId = ps.PointId 
	INNER JOIN 		CounterPlace AS cp ON pi.CounterPlaceId = cp.CounterPlaceId 
	LEFT OUTER JOIN (
					SELECT	PointId, 
							PeriodNumber, 
							LossesLine, 
							DtUpdate, 
							PerformerId
	   				FROM 	PointsLossesLineHistory AS pl
	          		WHERE	PeriodNumber = 	(
											SELECT	Closed
	                                    	FROM	vMaxClosedPeriod
											)
					) AS plOnCloseMonth ON pi.PointId = plOnCloseMonth.PointId
	ORDER BY 		pi.Areal, pi.CityVillage, pi.Street, pi.House, pi.LetterHouse, pi.Room
END

GO
GRANT EXECUTE ON Pr_BindingDataView TO KvzWorker
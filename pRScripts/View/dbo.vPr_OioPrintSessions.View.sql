IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_OioPrintSessions' AND type = 'V')
    DROP VIEW vPr_OioPrintSessions
GO

CREATE VIEW vPr_OioPrintSessions
AS
SELECT TOP (100) PERCENT
	ps.SessionId
   ,CONVERT(VARCHAR, ps.DtSession, 104) AS DtSession
   ,CONVERT(CHAR(5), ps.DtSession, 108) AS TimePrint
   ,(SELECT
			COUNT(SessionId) AS SessionCount
		FROM dbo.Pr_OioPrintSessions
		GROUP BY CAST(DtSession AS DATE)
		HAVING (CAST(DtSession AS DATE) = CAST(ps.DtSession AS DATE)))
	AS SessionCount
   ,CAST(CONVERT(VARCHAR, ps.DtSession, 104) AS VARCHAR)
	+ ' - ' + dbo.Pr_fnsGetShortFNS('', ps.AuthorId, 1) + ' (Сеансов печати - ' + (SELECT
			CAST(COUNT(SessionId) AS VARCHAR) AS SessionCount
		FROM dbo.Pr_OioPrintSessions AS Pr_OioPrintSessions_1
		GROUP BY CAST(DtSession AS DATE)
		HAVING (CAST(DtSession AS DATE) = CAST(ps.DtSession AS DATE)))
	+ ')' AS GroupName
   ,ps.AuthorId
   ,dbo.Pr_fnsGetShortFNS('', ps.AuthorId, 1) AS AuthorName
   ,ps.UserName
   ,ps.HostName
   ,ps.PrinterName
   ,ps.Copies
   ,ps.TaskSheetId
   ,ISNULL('Лист - задание на ' + CONVERT(VARCHAR, ts.DtPerformance, 104)
	+ 'г. (№  ' + dbo.Pr_fnsGetConstants(5, 0) + '-' + ts.CodJournalDocsId + '-' + CAST(ts.DocNumber AS VARCHAR) + ' от ' + CONVERT(VARCHAR, ts.DtDocument, 104) + 'г.)',
	'<<Лист - задание НЕ НАЗНАЧЕН>>') AS TaskSheet
   ,dbo.Pr_fnsGetTaskPerformersString(ts.TaskSheetId) AS PerformersName
   ,ISNULL(dbo.Pr_fnsGetShortFNS('',
	ps.fltr_ControllerId, 1), 'Все участки') AS fltr_ControllerName
   ,ISNULL(ps.fltr_Gko, 'Все УК') AS fltr_Gko
   ,ISNULL(pr.Name, 'Все маршруты') AS fltr_RouterName
   ,CASE
		WHEN a.Areal IS NULL AND
			cv.cityvillage IS NULL AND
			s.Street IS NULL THEN 'Без геофильтров'
		ELSE CASE
				WHEN a.Areal IS NULL THEN ''
				ELSE a.Areal
			END +
			CASE
				WHEN cv.cityvillage IS NULL THEN ''
				ELSE ' ' + cv.cityvillage
			END +
			CASE
				WHEN s.Street IS NULL THEN ''
				ELSE ' ' + s.Street
			END
	END AS fltr_Geo
   ,CASE
		WHEN ps.fltr_BalanceMin = 0 AND
			ps.fltr_BalanceMax >= 300000 THEN 'Весь диапазон, р.'
		ELSE CASE
				WHEN ps.fltr_BalanceMin = 0 THEN ''
				ELSE 'от ' + CAST(ps.fltr_BalanceMin AS VARCHAR)
					+ 'р.'
			END +
			CASE
				WHEN ps.fltr_BalanceMax <= 300000 THEN ' до ' + CAST(ps.fltr_BalanceMax AS VARCHAR) + 'р.'
				ELSE ''
			END
	END AS fltr_Balance
   ,CASE
		WHEN ps.fltr_CountMonthMin = 0 AND
			ps.fltr_CountMonthMax = 1000 THEN 'Все периоды, мес.'
		ELSE CASE
				WHEN ps.fltr_CountMonthMin = 0 THEN ''
				ELSE 'от ' + CAST(ps.fltr_CountMonthMin AS VARCHAR)
					+ ' мес.'
			END +
			CASE
				WHEN ps.fltr_CountMonthMax < 1000 THEN ' до ' + CAST(ps.fltr_CountMonthMax AS VARCHAR) + ' мес.'
				ELSE ''
			END
	END AS fltr_CountMonth
   ,ISNULL(ht.Name, 'Все типы жилья') AS fltr_prHouseType
   ,ps.fltr_DocTypeNotice
FROM dbo.Pr_OioPrintSessions AS ps
LEFT OUTER JOIN dbo.Pr_JournalTaskSheets AS ts ON ps.TaskSheetId = ts.TaskSheetId
LEFT OUTER JOIN dbo.vPr_HouseType AS ht ON ps.fltr_prHouseTypeId = ht.prHouseTypeId
LEFT OUTER JOIN (SELECT ArealId, Areal FROM dbo.TAddressDict AS ad1 GROUP BY ArealId, Areal) AS a ON ps.fltr_ArealId = a.ArealId
LEFT OUTER JOIN (SELECT ad2.AddressPartId, st.NameShort + ' ' + ad2.Street AS Street FROM dbo.TAddressDict AS ad2 
				INNER JOIN dbo.StreetTypes AS st ON ad2.StreetTypeId = st.StreetTypeId GROUP BY ad2.AddressPartId, st.NameShort + ' ' + ad2.Street) AS s
				ON ps.fltr_AddressPartId = s.AddressPartId
LEFT OUTER JOIN (SELECT CityVillageId, CityVillage FROM dbo.TAddressDict AS ad3 GROUP BY CityVillageId, CityVillage) AS cv ON ps.fltr_CityVillageId = cv.CityVillageId
LEFT OUTER JOIN Pr_Routers AS pr ON ps.fltr_RouterId = pr.RouterId
ORDER BY ps.SessionId DESC
GO

GRANT SELECT ON vPr_OioPrintSessions TO KvzWorker
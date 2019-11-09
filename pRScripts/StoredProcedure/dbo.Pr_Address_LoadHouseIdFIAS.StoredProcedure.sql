IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Address_LoadHouseIdFIAS' AND type = 'P')
  DROP PROCEDURE Pr_Address_LoadHouseIdFIAS
GO

CREATE PROCEDURE dbo.Pr_Address_LoadHouseIdFIAS
@Function INT               -- 1 загрузка
                            -- список абонентов без ФИАС
AS
SET NOCOUNT ON
SET XACT_ABORT ON           -- Всегда откатывать по ошибке

DECLARE @dt DATETIME = GETDATE()

IF @Function = 1 BEGIN

  ;WITH ab (mo, CityVillage, Street, HouseId , House, LetterHouse, Build, StreetIdFIAS)
  AS
  (
  SELECT
  CASE WHEN (SELECT DivisionName FROM vKernel_QuasarDataBases) = 'Красноярск' THEN 'Красноярск' ELSE
  (SELECT BaseName FROM vKernel_QuasarDataBases) END AS mo ,
  a.CityVillage AS CityVillage ,
  a.Street AS Street, 
  a.HouseId ,
  a.House AS House, 
  a.LetterHouse AS LetterHouse, 
  a.Build AS Build,
  t.StreetIdFIAS
  FROM vAbonents a
  INNER JOIN dbo.TAddressDict t ON a.AddressPartId = t.AddressPartId 
  GROUP BY a.CityVillage , a.Street, a.HouseId , a.House, a.LetterHouse, a.Build, t.StreetIdFIAS 
  )
  SELECT DISTINCT db_name() AS db, 'По названию' AS KodeType, h.HOUSEGUID , h.AOGUID , h.HOUSENUM, h.ESTSTATUS, h.BUILDNUM, h.STRUCNUM, ab.*
  INTO #Houses
  FROM ab
  LEFT JOIN fias.dbo.fias_AddressObject k ON k.oFFnAME = ab.CityVillage AND k.ACTSTATUS = 1
  LEFT JOIN fias.dbo.fias_AddressObject s ON k.AOGUID = s.PARENTGUID AND s.OFFNAME = ab.Street AND s.ACTSTATUS = 1
  LEFT JOIN fias.dbo.Fias_House h ON h.AOGUID = s.AOGUID AND h.HOUSENUM = CAST(ab.House AS VARCHAR(10)) + CAST(ab.LetterHouse AS VARCHAR(10)) + 
  CASE WHEN CAST(Build AS VARCHAR(10)) = '' THEN ''  ELSE ('/' + CAST(Build AS VARCHAR(10))) END 
  WHERE ab.StreetIdFIAS IS NULL AND @dt BETWEEN h.STARTDATE AND h.ENDDATE

  UNION ALL
  SELECT DISTINCT  db_name() AS db, 'По коду' AS KodeType, h.HOUSEGUID , h.AOGUID , h.HOUSENUM, h.ESTSTATUS, h.BUILDNUM, h.STRUCNUM, ab.*
  FROM ab
  LEFT JOIN fias.dbo.Fias_House h ON h.AOGUID = ab.StreetIdFIAS AND h.HOUSENUM = CAST(ab.House AS VARCHAR(10)) + CAST(ab.LetterHouse AS VARCHAR(10)) + 
  CASE WHEN CAST(Build AS VARCHAR(10)) = '' THEN ''  ELSE ('/' + CAST(Build AS VARCHAR(10))) END 
  WHERE ab.StreetIdFIAS IS NOT NULL AND @dt BETWEEN h.STARTDATE AND h.ENDDATE
  
  UPDATE HousesFond SET HouseIdFIAS = h.HOUSEGUID
  FROM HousesFond f
  INNER JOIN #Houses h ON f.HouseId = h.HouseId
  WHERE f.HouseIdFIAS IS NULL
  
  DROP TABLE #Houses
  
  RETURN
  
END

IF @Function = 2 BEGIN
	IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_FIAS_Garages' AND type = 'U') BEGIN 
		-- для Лесосибирских баз исключаем гаражи 
		SELECT DB_NAME() AS db, ab.AbonNumber, ab.CommAddressString
		FROM vAbonents AS ab 
		INNER JOIN AbonentsHistory AS ah ON ab.AbonentId = ah.AbonentId AND 
								 		 @dt BETWEEN ah.DtChange AND ah.DtEnd AND 
								 (ah.AbonentStatusId IN (1, 3) OR ah.AbonentStatusId = 2 AND ah.ExtAbonentStatusId IN (230, 280)) 
		LEFT OUTER JOIN Pr_FIAS_Garages AS fg ON ab.AbonentId = fg.AbonentId 
		LEFT OUTER JOIN HousesFond AS f ON f.HouseId = ab.HouseId
		WHERE f.HouseIdFIAS IS NULL AND ab.HouseTypeId NOT IN (8, 9, 10, 4) AND fg.AbonentId IS NULL
	END 
	ELSE BEGIN
		SELECT 
		Db_name() AS db ,
		ab.AbonNumber ,
		ab.CommAddressString
		FROM dbo.vabonents ab
		INNER JOIN dbo.AbonentsHistory ah ON ab.AbonentId = ah.AbonentId AND @dt BETWEEN ah.DtChange AND ah.DtEnd 
		AND (ah.AbonentStatusId IN (1,3) OR (ah.AbonentStatusId = 2 AND ah.ExtAbonentStatusId IN (230 , 280))) 
		LEFT JOIN dbo.HousesFond f ON f.HouseId = ab.HouseId
		WHERE f.HouseIdFIAS IS NULL
		AND ab.HouseTypeId NOT IN (8 , 9 , 10 , 4)
	END
RETURN
END
GO

GRANT EXECUTE ON Pr_Address_LoadHouseIdFIAS TO KvzWorker
GO

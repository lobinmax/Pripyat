IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fsnGetCountRoom' AND type = 'FN')
    DROP FUNCTION Pr_fsnGetCountRoom
GO
--
CREATE FUNCTION dbo.Pr_fsnGetCountRoom
/* Функция определяет количество квартир в доме абонента*/
	(
	@AbonentId INT
	)
RETURNS INT
AS
BEGIN

DECLARE @Value INT

DECLARE @ArialId INT
DECLARE @CityVillageId INT
DECLARE @AddressPartId INT
DECLARE @House VARCHAR(20)
DECLARE @LetterHouse VARCHAR(20)
DECLARE @Build VARCHAR(20)

SET @AddressPartId = (SELECT       AddressPartId
                      FROM         Abonents
                      WHERE        AbonentId = @AbonentId)

SET @ArialId = (SELECT       ArealId
              FROM         TAddressDict
              WHERE        AddressPartId = @AddressPartId)

SET @CityVillageId = (SELECT       CityVillageId
					FROM         TAddressDict
                    WHERE        AddressPartId = @AddressPartId)

SET @House = (SELECT        House
              FROM            Abonents
              WHERE        (AbonentId = @AbonentId))

SET @LetterHouse = (SELECT        LetterHouse
              FROM            Abonents
              WHERE        (AbonentId = @AbonentId))

SET @Build = (SELECT        Build
              FROM            Abonents
              WHERE        (AbonentId = @AbonentId))

SET @Value =	(
				SELECT		COUNT(Abonents.AbonentId) AS CountRoom
				FROM		Abonents 
				INNER JOIN	TAddressDict ON Abonents.AddressPartId = TAddressDict.AddressPartId
				GROUP BY	TAddressDict.ArealId, TAddressDict.CityVillageId, Abonents.AddressPartId, Abonents.House, Abonents.LetterHouse, Abonents.Build
				HAVING      TAddressDict.ArealId = @ArialId AND 
							TAddressDict.CityVillageId = @CityVillageId AND 
							Abonents.AddressPartId = @AddressPartId AND 
							Abonents.House = @House AND 
							Abonents.LetterHouse = @LetterHouse AND 
							Abonents.Build = @Build
				)


RETURN @Value
END
--
GO
GRANT EXECUTE ON Pr_fsnGetCountRoom TO KvzWorker
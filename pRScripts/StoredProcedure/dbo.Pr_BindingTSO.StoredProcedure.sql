IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_BindingTSO' AND type = 'P')
    DROP PROCEDURE dbo.Pr_BindingTSO
GO
CREATE PROCEDURE dbo.Pr_BindingTSO
/*
	=================================================
	| Привязка лицевых к сетевым организациям	|
	=================================================
*/
	@ArealId			INT,			-- Район
	@VillageId			INT,			-- Деревня
    @StreetId			INT,			-- Улица
	@TSOId				INT,			-- Ид ТСО
	@MultiStreet 		VARCHAR(MAX),	-- Перечень улиц
	@HouseParameters 	VARCHAR(20)		-- Параметры дома одно строкой
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Сounter INT = 0 -- Счетчик обработанных строк

-- если мультивыбор не включен
IF @MultiStreet IS NULL BEGIN
	-- считаем кол-во строк предстоящих к обработке
	SELECT		@Сounter = COUNT(p.PointId)
	FROM		Abonents AS a 
	INNER JOIN 	TAddressDict AS ta ON a.AddressPartId = ta.AddressPartId
	INNER JOIN 	Pr_Points AS p ON a.AbonentId = p.AbonentId 
	WHERE 		ta.ArealId = ISNULL(@ArealId, ta.ArealId) AND 
				ta.CityVillageId = ISNULL(@VillageId, ta.CityVillageId) AND 
				ta.StreetId = ISNULL(@StreetId, ta.StreetId) AND 
				a.House + a.LetterHouse + a.Build = ISNULL(@HouseParameters, a.House + a.LetterHouse + a.Build)
	-- обрабатываем
	UPDATE 	Pr_Points
	SET 	TSOId = @TSOId
	WHERE 	PointId IN 	(
						SELECT		p.PointId
						FROM		Abonents AS a 
						INNER JOIN 	TAddressDict AS ta ON a.AddressPartId = ta.AddressPartId 
						INNER JOIN 	Pr_Points AS p ON a.AbonentId = p.AbonentId 
						WHERE 		ta.ArealId = ISNULL(@ArealId, ta.ArealId) AND 
									ta.CityVillageId = ISNULL(@VillageId, ta.CityVillageId) AND 
									ta.StreetId = ISNULL(@StreetId, ta.StreetId) AND 
									a.House + a.LetterHouse + a.Build = ISNULL(@HouseParameters, a.House + a.LetterHouse + a.Build)
						 )
END
-- задан перечень улиц
ELSE BEGIN
	-- считаем кол-во строк предстоящих к обработке
	SELECT 		@Сounter = COUNT(p.PointId) 
	FROM 		Abonents a
	INNER JOIN 	Pr_Points AS p ON a.AbonentId = p.AbonentId
	WHERE 		a.AddressPartId IN 	(
								SELECT * FROM Pr_fntGetTableFromString(@MultiStreet, ',')
								)
	-- обрабатываем
	UPDATE 	Pr_Points
	SET 	TSOId = @TSOId
	WHERE 	PointId IN	(
						SELECT 		p.PointId 
						FROM 		Abonents a 
						INNER JOIN 	Pr_Points AS p ON a.AbonentId = p.AbonentId
						WHERE 		a.AddressPartId IN 	(
														SELECT * FROM Pr_fntGetTableFromString(@MultiStreet, ',')
														)
						)
END
SELECT @Сounter
GO
GRANT EXECUTE ON dbo.Pr_BindingTSO TO KvzWorker
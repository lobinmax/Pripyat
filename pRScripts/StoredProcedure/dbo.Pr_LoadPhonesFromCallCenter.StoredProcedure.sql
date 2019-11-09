IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_LoadPhonesFromCallCenter' AND type = 'P')
    DROP PROCEDURE Pr_LoadPhonesFromCallCenter
GO
CREATE PROCEDURE dbo.Pr_LoadPhonesFromCallCenter
	/*
	=============================================	
	|	Процедура загрузки номеров телефонов	|
	|	переданных их CALL центра				|
	=============================================
	*/
	@AbonentNumber	VARCHAR(15),
	@PhoneNumber 	VARCHAR(30),
	@PhoneType 		VARCHAR(10),
	@InsertOnly		BIT = 1			-- 1 - заносим только в случае отсутствия данных
									-- 0 - заносим в любом случае
AS 	
	-- текущее значение номера телефона в базе
	DECLARE @PhoneInBase 	VARCHAR(30) 
	DECLARE @AbonentId 		INT = (SELECT e.ElementId FROM Elements e WHERE e.Num = @AbonentNumber AND e.StateId = 1)
	
	-- Проверка сущетвованиЯ абонента
	IF NOT EXISTS (SELECT * FROM Abonents a WHERE AbonentId = @AbonentId) BEGIN
		RETURN 0
	END
	-- длЯ мобильных
	IF @PhoneType = 'Mobile' BEGIN
		SELECT @PhoneInBase = a.PhoneMobile FROM Abonents a WHERE a.AbonentId = @AbonentId
		IF @InsertOnly = 1 BEGIN
			-- проверяем есть в базе данные
			IF @PhoneInBase IS NULL OR @PhoneInBase = '' BEGIN
				UPDATE Abonents SET PhoneMobile = @PhoneNumber WHERE AbonentId = @AbonentId
				RETURN 0
			END
    	END
		ELSE BEGIN
			-- заносим без проверки
			UPDATE Abonents SET PhoneMobile = @PhoneNumber WHERE AbonentId = @AbonentId
			RETURN 0
		END
	END
	-- длЯ городских
	IF @PhoneType = 'Phone' BEGIN
		SELECT @PhoneInBase = a.Phone FROM Abonents a WHERE a.AbonentId = @AbonentId
		IF @InsertOnly = 1 BEGIN
			-- проверЯем есть в базе данные
			IF @PhoneInBase IS NULL OR @PhoneInBase = '' BEGIN
				UPDATE Abonents SET Phone = @PhoneNumber WHERE AbonentId = @AbonentId
				RETURN 0
			END
    	END
		ELSE BEGIN
			-- Заносим без проверки
			UPDATE Abonents SET Phone = @PhoneNumber WHERE AbonentId = @AbonentId
			RETURN 0
		END			
	END 
RETURN 0
GO
GRANT EXECUTE ON Pr_LoadPhonesFromCallCenter TO KvzWorker
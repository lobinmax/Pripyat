IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetShortFNS' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetShortFNS
GO
CREATE FUNCTION dbo.Pr_fnsGetShortFNS
/*  Функция превращает Фамилию Имя Отчество
	в Фамилию И.О.							*/
	(
	@Name			VARCHAR(100),	-- ФИО
	@PerformerId	INT,			-- Ид пользователя
	@Function		INT  			-- Метод
										-- 0 - по ФИО;
										-- 1 - по Ид пользователя;
	)

RETURNS VARCHAR(100)
AS
	BEGIN
	DECLARE @Value VARCHAR(100)
	DECLARE @NewName VARCHAR(100)
		-- 0 - по ФИО;
		IF @Function = 0 BEGIN
			-- Три раза заменяем задвоенные пробелы
			SET @NewName = REPLACE(REPLACE(REPLACE(@Name, '  ',' '), '  ',' '), '  ',' ')
			SET @Value =	(
							SELECT	PARSENAME(REPLACE(@NewName,' ','.'),3)+' '+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),2),1)+'.'+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),1),1)+'.'
							)
			-- Если получился NULL возвращаем исходное имя 
			IF @Value IS NULL BEGIN
				SET @Value = @Name
			END    
			RETURN @Value
		END

		-- 1 - по Ид пользователя;
		IF @Function = 1 BEGIN
			SET @NewName = (SELECT Name FROM Elements WHERE Elementid = @PerformerId)
			-- Три раза заменяем задвоенные пробелы
			SET @NewName = REPLACE(REPLACE(REPLACE(@NewName, '  ',' '), '  ',' '), '  ',' ')
			SET @Value =	(
							SELECT	PARSENAME(REPLACE(@NewName,' ','.'),3)+' '+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),2),1)+'.'+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),1),1)+'.'
							)
			-- Если получился NULL возвращаем полное имя
			IF @Value IS NULL BEGIN
				SET @Value = (SELECT e.Name FROM Elements e WHERE e.ElementId = @PerformerId)
			END            
			RETURN @Value
		END
	RETURN NULL
	END
GO
GRANT EXECUTE ON Pr_fnsGetShortFNS TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fntGetTableFromString' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION dbo.Pr_fntGetTableFromString
GO
CREATE FUNCTION dbo.Pr_fntGetTableFromString
/*
	=============================================
	|	Функция возвращает таблицу из строки	|
	|	со значениями через разделитель			|
	=============================================
*/
(
	@StringParameter 	VARCHAR(MAX),	-- строка со значениями
	@Seporator 			VARCHAR = ',' 	-- разделитель значений
)

RETURNS @tbValues  TABLE([Values] VARCHAR(MAX))
AS 
BEGIN

DECLARE 	@t TABLE(name VARCHAR(MAX)) 	-- таблица для входной строки со значениями
DECLARE 	@tNum TABLE(number INT)			-- таблица с числами

-- заполняем таблицу числами
DECLARE @i int
DECLARE @max int
SET @i = 0
SET @max = 7000
	WHILE 	@i <= @max BEGIN
	INSERT 	@tNum SELECT @i
	SET 	@i = @i+1
END

-- вставляем входную строку
INSERT INTO @t
SELECT 		@StringParameter 

INSERT INTO @tbValues
SELECT 		SUBSTRING(name, t.i2 + 1, t.i1 - t.i2 - 1 ) AS name		
FROM		(
			SELECT 	t1.name, 
					CHARINDEX( @Seporator, t1.name + @Seporator, t2.number ) i1,
					CASE 
						WHEN t2.number = 0 THEN 0 
					ELSE 
						CHARINDEX( @Seporator, t1.name + ',', t2.number - 1 ) 
					END i2
			FROM @t AS t1 
			INNER JOIN @tNum AS t2 ON t2.number BETWEEN 0 AND LEN( t1.name )
			) t WHERE t.i1 != t.i2 
RETURN                     
END
GO
GRANT SELECT ON dbo.Pr_fntGetTableFromString TO KvzWorker
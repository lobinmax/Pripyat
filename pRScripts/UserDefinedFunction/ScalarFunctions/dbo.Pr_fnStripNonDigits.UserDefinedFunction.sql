IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnStripNonDigits' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnStripNonDigits
GO

CREATE FUNCTION [dbo].[Pr_fnStripNonDigits]
-- Процедура преобразует 45б в 45
-- для сортировки домов или квартир
	(
	@InputString NVARCHAR(4000)
	)

RETURNS NVARCHAR(4000)
AS
BEGIN

DECLARE @OutputString NVARCHAR(4000), @i INT, @ch NCHAR
SET @i = 1
SET @OutputString = N''

WHILE @i <= LEN(@InputString)
	BEGIN
  		SET @ch = SUBSTRING(@InputString, @i, 1)  
  			IF ASCII(@ch) > 47 AND ASCII(@ch) < 58
    		SET @OutputString = @OutputString + @ch
  			SET @i = @i + 1
	END
RETURN @OutputString
END
GO

GRANT EXECUTE ON Pr_fnStripNonDigits TO KvzWorker

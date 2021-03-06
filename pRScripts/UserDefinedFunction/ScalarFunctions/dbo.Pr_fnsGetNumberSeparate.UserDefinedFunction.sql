IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetNumberSeparate' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetNumberSeparate
GO
CREATE FUNCTION dbo.Pr_fnsGetNumberSeparate
/*  Функция число с разделителем разрядом 
	в виде строки							*/
	(
	@Num 		NUMERIC(18, 2),		-- Число
	@Separator 	VARCHAR(4) = NULL,	-- Разделитель разрядов
	@IsRound 	BIT = NULL			-- Не 0.00, а 0
	)

RETURNS VARCHAR(100)
AS
BEGIN
IF @Separator IS NULL BEGIN SET @Separator = ' ' END 
IF @IsRound IS NULL BEGIN SET @IsRound = 0 END

DECLARE @Value 		VARCHAR(100)
DECLARE @Integer 	VARCHAR(100) 	-- Целая часть
DECLARE @Fraction 	VARCHAR(100) 	-- Дробная часть
SELECT 	@Integer = REPLACE(REPLACE(CONVERT(VARCHAR(20), CAST(CAST(@num AS INT) AS MONEY), 1), ',', @Separator), '.00', '')
SELECT 	@Fraction = REPLACE(CAST(CAST(@num AS NUMERIC(18, 2)) - CAST(@num AS INT) AS VARCHAR(20)), '0.', '.')

IF @IsRound = 1 AND @Fraction = '.00' BEGIN 
	SET @Fraction = ''
END 
SET @Value = ISNULL(@Integer + @Fraction, '0')
RETURN @Value
END
GO
GRANT EXECUTE ON Pr_fnsGetNumberSeparate TO KvzWorker

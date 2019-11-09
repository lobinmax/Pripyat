IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetPointId' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetPointId
GO
CREATE FUNCTION dbo.Pr_fnsGetPointId
/*
	=================================================
	|	Получаем PointId или AbonentId по номеру ТУ	|
	=================================================
*/
(
	@NumberString VARCHAR(12),
	@IsPointId 	  BIT = 1	-- 1 PointId
							-- 0 AbonentId
)
RETURNS INT 
AS
BEGIN
DECLARE @Result INT 
	IF @IsPointId = 1 BEGIN
    	SET @Result = (SELECT p.PointId FROM Points AS p WHERE p.PointNumber = @NumberString)
	END 
	IF @IsPointId = 0 BEGIN
    	SET @Result = (SELECT e.ElementId FROM Elements AS e WHERE e.Num = @NumberString AND e.StateId = 1)
	END 
RETURN @Result
END
GO
GRANT EXECUTE ON Pr_fnsGetPointId TO KvzWorker
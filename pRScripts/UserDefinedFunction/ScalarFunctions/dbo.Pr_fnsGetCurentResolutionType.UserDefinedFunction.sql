IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetCurentResolutionType' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetCurentResolutionType
GO

CREATE FUNCTION [dbo].[Pr_fnsGetCurentResolutionType]
/*	Получение ИД текущего законодальства
	по дата формирования b методу расчета ДЗ	*/

	(
	@CalcTypeId		INT			= 1,			-- Метод расчета ДЗ
	@DtBeginOio		DATETIME	= '19.10.1987'	-- Дата формирования ДЗ
	)
RETURNS INT
AS
	BEGIN
	DECLARE @Value	INT
	SET @Value =	(
					SELECT		OioResolutionTypeId
					FROM		dbo.Pr_OioResolutionTypes
					WHERE       CalcTypeId = @CalcTypeId AND 
								@DtBeginOio BETWEEN DtBegin AND DtEnd
					)
	RETURN @Value
	END
GO

GRANT EXECUTE ON Pr_fnsGetCurentResolutionType TO KvzWorker

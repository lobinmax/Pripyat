IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetNamePetitionPack' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetNamePetitionPack
GO

CREATE FUNCTION [dbo].[Pr_fnsGetNamePetitionPack] 
	/* Функция создает имя пачки */
	
	(@PetitionTypeId INT)		-- ид типа иска
	 
RETURNS varchar(15)
AS
BEGIN
  DECLARE @NameShort varchar(15)	

SELECT     @NameShort = NameShort
FROM       dbo.Pr_PetitionType
WHERE     (PetitionTypeId = @PetitionTypeId)

 RETURN CAST(DATEPART(YEAR,GETDATE()) * 100 + DATEPARt(MONTH ,GETDATE()) AS VARCHAR(6)) + ' - ' + @NameShort
END
GO

GRANT EXECUTE ON Pr_fnsGetNamePetitionPack TO KvzWorker
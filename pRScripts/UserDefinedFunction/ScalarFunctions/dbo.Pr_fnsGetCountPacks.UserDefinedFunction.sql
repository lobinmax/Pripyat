IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetCountPacks' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetCountPacks
GO

CREATE FUNCTION [dbo].[Pr_fnsGetCountPacks] 
	/* Функция проверяет наличие в базе пачки по 
		ИД типа услуг, ИД типа пачки и текущей дете
		и возвращает количество пачек по этим критериям*/
	
	(
	@Pr_EnergyTypeId INT,		-- Тип взыскиваемых услуг
	@PetitionsPacksType INT		-- Тип пачки
	)
RETURNS INT
AS
BEGIN
  DECLARE @CountPacks INT	

SELECT     @CountPacks = PetitionsPacksId
FROM         Pr_PetitionsPacks
WHERE     (Pr_EnergyTypeId = @Pr_EnergyTypeId) AND (PetitionsPacksType = @PetitionsPacksType) AND (CAST(DtCreate AS date) = CAST(GETDATE() AS date))

 RETURN @CountPacks
END
GO

GRANT EXECUTE ON Pr_fnsGetCountPacks TO KvzWorker

IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReCalculatePetitionPack' AND type = 'P')
    DROP PROCEDURE dbo.Pr_ReCalculatePetitionPack
GO

CREATE PROCEDURE [dbo].[Pr_ReCalculatePetitionPack]   
@PetitionsPacksId INT 
        
AS
SET NOCOUNT ON				-- Не возвращать количество строк 
SET XACT_ABORT ON           -- Всегда откатывать по ошибке 


/* Если количество записей в Pr_PetitionsDebt с PetitionsPacksId = @PetitionsPacksId
не равно нулю то, обновляем суммы по пачке, если записей нет то,
пачку удаляем*/
IF (SELECT     COUNT(ISNULL(AbonentId, 0)) AS PetitionsCount
    FROM         Pr_PetitionsDebt
    WHERE     (PetitionsPacksId = @PetitionsPacksId)) <> 0 
BEGIN
UPDATE Pr_PetitionsPacks 
   sET PetitionsCount =i.PetitionsCount,
       PetitionsSumDebt =  i.PetitionsSumDebt, 
       PetitionsSumGovTax =  i.PetitionsSumGovTax,
       PetitionsSumDebtAfterDecision = i.PetitionsSumDebtAfterDecision

FROM (SELECT COUNT(ISNULL(AbonentId, 0)) AS PetitionsCount, 
		     SUM(ISNULL(DebtSumm, 0)) AS PetitionsSumDebt, 
			 SUM(ISNULL(GovTax, 0)) AS PetitionsSumGovTax, 
			 SUM(ISNULL(DebtSummAfterDecision, 0)) AS PetitionsSumDebtAfterDecision
FROM	dbo.Pr_PetitionsDebt  GROUP BY  PetitionsPacksId
HAVING  (PetitionsPacksId = @PetitionsPacksId)) as i

WHERE 	Pr_PetitionsPacks.PetitionsPacksId =@PetitionsPacksId
END
ELSE
DELETE Pr_PetitionsPacks
WHERE 	Pr_PetitionsPacks.PetitionsPacksId =@PetitionsPacksId
GO

GRANT EXECUTE ON dbo.Pr_ReCalculatePetitionPack TO KvzWorker

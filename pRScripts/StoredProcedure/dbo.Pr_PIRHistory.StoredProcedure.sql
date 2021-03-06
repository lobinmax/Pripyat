IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PIRHistory' AND type = 'P')
    DROP PROCEDURE Pr_PIRHistory
GO
CREATE PROCEDURE dbo.Pr_PIRHistory
AS
SELECT     Documents.AbonentId, Documents.DtDoc AS DtEvent, Receipts.SumPayments AS Sum, Articles.Name AS Event
FROM         Receipts INNER JOIN
                      Articles ON Receipts.ArticleId = Articles.ArticleId INNER JOIN
                      Documents ON Receipts.ReceiptId = Documents.DocumentId
WHERE     (Documents.AbonentId = - 1996223673)
UNION ALL
SELECT     AbonentId AS [1], DtPetitions AS [2], DebtSumm AS [3], 'Составлен иск' AS [4]
FROM         Pr_PetitionsDebt
WHERE     (AbonentId = - 1996223673) AND (NOT (DtPetitions IS NULL))
UNION ALL
SELECT     AbonentId AS [1], DtDispatch AS [2], DebtSumm AS [3], 'Иск направлен в суд' AS [4]
FROM         Pr_PetitionsDebt AS Pr_PetitionsDebt_1
WHERE     (AbonentId = - 1996223673) AND (NOT (DtDispatch IS NULL))
UNION ALL
SELECT     AbonentId AS [1], DtDecision AS [2], DebtSummAfterDecision AS [3], 'Вынесено решение суда' AS [4]
FROM         Pr_PetitionsDebt AS Pr_PetitionsDebt_1
WHERE     (AbonentId = - 1996223673) AND (NOT (DtDecision IS NULL))
UNION ALL
SELECT        Pr_PetitionsDebt_1.AbonentId AS [1], Pr_PetitionsDebt_1.DtDecisionDirection AS [2], Pr_PetitionsDebt_1.DebtSummAfterDecision AS [3], 
                         'Иск направлен ' + Pr_DecisionDirections.Name AS [4]
FROM            Pr_PetitionsDebt AS Pr_PetitionsDebt_1 INNER JOIN
                         Pr_DecisionDirections ON Pr_PetitionsDebt_1.DecisionDirectionId = Pr_DecisionDirections.DecisionDirectionId
WHERE        (Pr_PetitionsDebt_1.AbonentId = - 1996223673) AND (NOT (Pr_PetitionsDebt_1.DtDecisionDirection IS NULL))
ORDER BY dtevent
GO
GRANT EXECUTE ON Pr_PIRHistory TO KvzWorker
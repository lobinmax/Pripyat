IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PointsPublicChargesCalculate' AND type = 'P')
    DROP PROCEDURE dbo.Pr_PointsPublicChargesCalculate
GO
CREATE PROCEDURE dbo.Pr_PointsPublicChargesCalculate
/*
	=====================================
	|	Перерасчет показаний в секции  	|
	|	после заданной даты				|
	=====================================
*/
	@SectionId INT,
	@DtDoc DATE

AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @DocumentId INT
DECLARE @curDtDoc DATE
DECLARE @OldIndication INT
DECLARE @NewIndication INT 
DECLARE @Consumption INT 

DECLARE iCursor CURSOR LOCAL FORWARD_ONLY STATIC FOR

SELECT pppsc.DocumentId FROM Pr_PointsPublicSectionsCharges AS pppsc 
INNER JOIN AccountingPeriods AS ap ON pppsc.PeriodNumber = ap.PeriodNumber
WHERE pppsc.SectionId = @SectionId AND pppsc.DtDoc > @DtDoc AND ap.MonthStatus = 1
ORDER BY pppsc.DtDoc
OPEN iCursor
FETCH NEXT FROM iCursor INTO @DocumentId
WHILE @@FETCH_STATUS = 0 BEGIN
 		SET @curDtDoc = (SELECT pppsc.DtDoc FROM Pr_PointsPublicSectionsCharges AS pppsc WHERE pppsc.DocumentId = @DocumentId)
		SELECT @OldIndication = pp.NewIndication, 
			   @NewIndication = pppsc.NewIndication,
			   @Consumption = dbo.Pr_fnsPointsPublicGetConsumption(@SectionId, @curDtDoc, @DocumentId, @NewIndication)
		FROM   Pr_PointsPublicSectionsCharges AS pppsc 
		INNER JOIN (
				    SELECT SectionId, MAX(DtDoc) AS DtDoc
		    		FROM   (
							SELECT SectionId, DtDoc
		               		FROM Pr_PointsPublicSectionsCharges AS pppsc1
		     				WHERE SectionId = @SectionId AND DtDoc < @curDtDoc AND DocumentId <> @DocumentId
							) AS old_1
		  			GROUP BY SectionId
					) AS old ON pppsc.SectionId = old.SectionId 
		INNER JOIN Pr_PointsPublicSectionsCharges AS pp ON old.SectionId = pp.SectionId AND old.DtDoc = pp.DtDoc
		WHERE pppsc.DocumentId = @DocumentId

		UPDATE Pr_PointsPublicSectionsCharges 
		SET OldIndication = @OldIndication,
		 	NewIndication = @NewIndication,
		 	Consumption = @Consumption
		WHERE DocumentId = @DocumentId

FETCH NEXT FROM iCursor INTO @DocumentId
END
CLOSE iCursor
DEALLOCATE iCursor
 
GO
GRANT EXECUTE ON dbo.Pr_PointsPublicChargesCalculate TO KvzWorker
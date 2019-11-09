IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsPointsPublicGetConsumption' AND type = 'FN')
    DROP FUNCTION Pr_fnsPointsPublicGetConsumption
GO
CREATE FUNCTION dbo.Pr_fnsPointsPublicGetConsumption
/*
	=========================================
	|	Расход по секционному прибору учета	|
	=========================================
*/
	(
	@SectionId INT,
	@DtDoc DATE, -- на дату
	@DocumentId INT,
	@NewIndication INT
	)
RETURNS INT 
AS
BEGIN
	DECLARE @Signs INT 	
	DECLARE @OldIndication INT	
	DECLARE @Consuption INT 

	IF @DtDoc IS NULL BEGIN SET @DtDoc = '19.10.2087' END
	IF @DocumentId IS NULL BEGIN SET @DocumentId = -19999999 END

	-- определяем значность и последние ФП
	SELECT	@OldIndication = pppsc.NewIndication, @Signs = ct.Signs
	FROM	Pr_PointsPublicSectionsCharges AS pppsc 
	INNER JOIN Pr_CountersSectionHistory AS csh ON pppsc.SectionId = csh.SectionId 
	INNER JOIN CounterTypes AS ct ON csh.CounterTypeId = ct.CounterTypeId 
	RIGHT OUTER JOIN (	
					  SELECT SectionId, MAX(DtDoc) AS DtDoc
	            	  FROM Pr_PointsPublicSectionsCharges AS pppsc
	             	  WHERE SectionId = @SectionId AND pppsc.DtDoc <= @DtDoc AND pppsc.DocumentId != @DocumentId
	                  GROUP BY SectionId
					  ) AS DtMax ON pppsc.DtDoc = DtMax.DtDoc AND pppsc.SectionId = DtMax.SectionId
	WHERE pppsc.SectionId = @SectionId
	GROUP BY pppsc.NewIndication, csh.IsActive, ct.Signs
	HAVING csh.IsActive = 1
	
	SET @Consuption = @NewIndication - @OldIndication
	IF @Consuption < 0 BEGIN SET @Consuption = @Consuption + POWER(10, @Signs) END 
RETURN @Consuption
END 
GO
GRANT EXECUTE ON dbo.Pr_fnsPointsPublicGetConsumption TO KvzWorker
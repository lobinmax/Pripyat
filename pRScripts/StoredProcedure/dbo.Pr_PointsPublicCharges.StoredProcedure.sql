IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PointsPublicCharges' AND type = 'P')
    DROP PROCEDURE dbo.Pr_PointsPublicCharges
GO
CREATE PROCEDURE dbo.Pr_PointsPublicCharges
/*
	=====================================
	|	Обработка показаний по секции	|
	=====================================
*/
	
	@SectionId 		INT = NULL,
	@DocumentId		INT = NULL,
	@DtDoc 			SMALLDATETIME = NULL,
	@NewIndication 	INT = NULL,
	@Function		INT = 0		-- 1 - Данные последнего показания в секции
								-- 2 - Запись новых показаний
								-- 4 - DELETE
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке
 
-- 1 - Данные последнего показания в секции
IF @Function = 1 BEGIN 
	-- при создании документа
	IF @DocumentId IS NULL BEGIN 
		SELECT 	pppsc.SectionId, 
				MAX(pppsc.DtDoc) AS DtDoc, 
				pppsc.NewIndication AS OldIndication,
				0 AS NewIndication,
				0 AS Consumption,
				GETDATE() AS Now,
				dbo.Pr_fnsGetShortFNS('', dbo.Kernel_GetPerformer(), 1) AS Performer,
				GETDATE() AS DtCreate
		FROM	Pr_PointsPublicSectionsCharges AS pppsc 
		RIGHT OUTER JOIN 	(
							SELECT SectionId, MAX(DtDoc) AS DtDoc
		                	FROM Pr_PointsPublicSectionsCharges AS pppsc
		                	WHERE SectionId = @SectionId AND pppsc.DtDoc <= @DtDoc
		                	GROUP BY SectionId
							) AS DtMax ON pppsc.DtDoc = DtMax.DtDoc AND pppsc.SectionId = DtMax.SectionId
		WHERE pppsc.SectionId = @SectionId
		GROUP BY pppsc.SectionId, pppsc.NewIndication
	END 
	-- при изменении документа
	ELSE BEGIN
		SELECT pppsc.SectionId, 
			   old.DtDoc, 
			   pp.NewIndication AS OldIndication, 
			   pppsc.NewIndication, 
			   pppsc.Consumption, 
			   pppsc.DtDoc AS Now, 
			   dbo.Pr_fnsGetShortFNS('', dbo.Kernel_GetPerformer(), 1) AS Performer,
			   pppsc.DtCreate AS DtCreate
		FROM   Pr_PointsPublicSectionsCharges AS pppsc 
		INNER JOIN (
				    SELECT SectionId, MAX(DtDoc) AS DtDoc
		    		FROM   (
							SELECT SectionId, DtDoc
		               		FROM Pr_PointsPublicSectionsCharges AS pppsc1
		     				WHERE SectionId = @SectionId AND DtDoc < @DtDoc AND DocumentId <> @DocumentId
							) AS old_1
		  			GROUP BY SectionId
					) AS old ON pppsc.SectionId = old.SectionId 
		INNER JOIN Pr_PointsPublicSectionsCharges AS pp ON old.SectionId = pp.SectionId AND old.DtDoc = pp.DtDoc
		WHERE pppsc.DocumentId = @DocumentId	
	END 
END

-- проверка при добавлении, изменении, удалении
IF @Function IN(2, 3, 4) BEGIN
	-- проверка периода
	DECLARE @DtDocPeriod INT = (YEAR(@DtDoc) * 100) + MONTH(@DtDoc)
	DECLARE @DtDocPeriodStatus INT = (SELECT ap.MonthStatus FROM AccountingPeriods AS ap WHERE ap.PeriodNumber = @DtDocPeriod)	

	IF @DtDocPeriodStatus = 2 BEGIN 
		RAISERROR ('Дата докумета принадлежит закрытому периоду!', 12, 2)
		RETURN
	END 
	IF EXISTS(SELECT * FROM Pr_PointsPublicSectionsCharges AS pppsc WHERE pppsc.DtDoc = @DtDoc AND pppsc.SectionId = @SectionId)
	   AND @Function != 3 BEGIN 
		RAISERROR ('На дату докумета уже выставлен ФП-счет или наряд!', 12, 2)
		RETURN
	END 
END 

-- 2 - Запись новых показаний
IF @Function = 2 BEGIN
	INSERT INTO Pr_PointsPublicSectionsCharges
	SELECT 	@DtDoc,
			@SectionId, 
			pppsc.NewIndication AS OldIndication,
			@NewIndication,
			dbo.Pr_fnsPointsPublicGetConsumption(@SectionId, @DtDoc, @DocumentId, @NewIndication),
			1,
			dbo.Kernel_GetPerformer(),
			GETDATE(),
			dbo.Kernel_GetPerformer(),
			GETDATE(), 
			(YEAR(@DtDoc) * 100) + MONTH(@DtDoc)
	FROM	Pr_PointsPublicSectionsCharges AS pppsc 
	RIGHT OUTER JOIN 	(
						SELECT SectionId, MAX(DtDoc) AS DtDoc
	                	FROM Pr_PointsPublicSectionsCharges AS pppsc
	                	WHERE SectionId = @SectionId
	                	GROUP BY SectionId
						) AS DtMax ON pppsc.DtDoc = DtMax.DtDoc AND pppsc.SectionId = DtMax.SectionId
	WHERE pppsc.SectionId = @SectionId
	GROUP BY pppsc.SectionId, pppsc.NewIndication
	SELECT pppsc.DocumentId FROM Pr_PointsPublicSectionsCharges AS pppsc WHERE pppsc.DocumentId = @@identity
END

-- Изменение
IF @Function = 3 BEGIN 
	UPDATE Pr_PointsPublicSectionsCharges 
	SET DtDoc =@DtDoc, 
		NewIndication = @NewIndication, 
		Consumption = dbo.Pr_fnsPointsPublicGetConsumption(@SectionId, @DtDoc, @DocumentId, @NewIndication), 
		UpdaterId = dbo.Kernel_GetPerformer(), 
		DtUpdate = GETDATE()
	WHERE DocumentId = @DocumentId	
	SELECT pppsc.DocumentId FROM Pr_PointsPublicSectionsCharges AS pppsc WHERE pppsc.DocumentId = @DocumentId
END 

-- Удаление
IF @Function = 4 BEGIN
	SELECT @SectionId = pppsc.SectionId,
		   @DtDoc = pppsc.DtDoc 
	FROM Pr_PointsPublicSectionsCharges AS pppsc 
	WHERE pppsc.DocumentId = @DocumentId
	DELETE FROM Pr_PointsPublicSectionsCharges WHERE DocumentId = @DocumentId
END
 
-- пересчитываем все документы после @DtDoc
IF @Function IN(2, 3, 4) BEGIN
	EXEC Pr_PointsPublicChargesCalculate @SectionId, @DtDoc
END 
GO
GRANT EXECUTE ON dbo.Pr_PointsPublicCharges TO KvzWorker
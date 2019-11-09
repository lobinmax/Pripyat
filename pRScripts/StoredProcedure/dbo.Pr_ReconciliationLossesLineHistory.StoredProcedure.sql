IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReconciliationLossesLineHistory' AND type = 'P')
    DROP PROCEDURE Pr_ReconciliationLossesLineHistory
GO
CREATE PROCEDURE dbo.Pr_ReconciliationLossesLineHistory
	/*
		Процедура для массового изменения потерь
		в линии на точке учета
		Во исполнении приказа РусГидро №62
	*/
	@PointNumber	VARCHAR(15),
	@LossesLine		SMALLMONEY,		-- Значение потерь в линии
	@PeriodNumber	INT 			-- Текущий период для проверки
AS 

DECLARE	@PointId	INT

-- Определяем ИД точки учата
SELECT @PointId = p.PointId FROM Points p WHERE p.PointNumber = @PointNumber
IF @PointId IS NULL BEGIN RETURN END

-- Если потери NULL то, чистим
IF @LossesLine IS NULL BEGIN
	DELETE FROM PointsLossesLineHistory WHERE PointId = @PointId AND PeriodNumber >= @PeriodNumber	
END

-- Если потери NOT NULL
IF @LossesLine IS NOT NULL BEGIN
	-- проверяем есть ли уже записанные потери
	IF EXISTS (SELECT * FROM PointsLossesLineHistory pllh WHERE pllh.PointId = @PointId AND pllh.PeriodNumber = @PeriodNumber) BEGIN
		UPDATE 	PointsLossesLineHistory 
		SET 	LossesLine = @LossesLine, 
				DtUpdate = GETDATE(), 
				PerformerId = dbo.Kernel_GetPerformer()
		WHERE 	PointId = @PointId AND PeriodNumber >= @PeriodNumber
	END	
	ELSE BEGIN
		INSERT INTO PointsLossesLineHistory
		SELECT 	@PointId, plop.PeriodNumber, @LossesLine, GETDATE(), dbo.Kernel_GetPerformer()
		FROM 	vPr_ListOfPeriods plop 
		WHERE 	plop.PeriodNumber BETWEEN @PeriodNumber AND (SELECT CAST(SUBSTRING(CAST(@PeriodNumber AS VARCHAR),1,4) + '12' AS INT)) ORDER BY plop.PeriodNumber
	END
END
GO
GRANT EXECUTE ON Pr_ReconciliationLossesLineHistory TO KvzWorker
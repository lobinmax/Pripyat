IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReconciliationTariffes' AND type = 'P')
    DROP PROCEDURE Pr_ReconciliationTariffes
GO
CREATE PROCEDURE dbo.Pr_ReconciliationTariffes
	/*
		Процедура для массового изменения в истории ТУ
		Добавляется новая строка с нужными параметрами тарифа
		Во исполнении приказа РусГидро №62
	*/
	@PointNumber 		VARCHAR(15),
	@DtChange 	 		DATE,
	@TariffId			INT
AS
DECLARE @PointId INT
-- определяем ИД ТУ
SET @PointId = (SELECT p.PointId FROM Points p WHERE p.PointNumber = @PointNumber) 

DECLARE		@DtOldChange			DATETIME,
			@Indication				INT,
			@AccountStatusId    	INT,
			@NormId					INT,
			@AccountTypeId	    	TINYINT,
			@ConsumMiddle			SMALLINT,
			@LossesLine         	SMALLMONEY,
			@LossesTran         	SMALLMONEY,
			@Function				INT,
			@SchemeExhAccountsId 	INT,
			@AccountDay         	INT,
			@ConsumptionFactor  	SMALLMONEY,
			@Audit              	INT = 1,
			@CondPermLoss       	SMALLMONEY,
			@PossibilityDevice  	BIT,
			@PeriodNumber 			INT

-- выгружаем информацию о последней записи в истории абонента
SELECT 	@DtOldChange = ph.DtChange,
		@Indication = -1,
		@AccountStatusId = ph.AccountStatusId,
		@NormId = ph.NormId,
		@AccountTypeId = ph.AccountTypeId,
		@ConsumMiddle = ph.ConsumMiddle,
		@LossesLine = ph.LossesLine,
		@LossesTran = ph.LossesTran,
		@Function = 1, -- добавление записи
		@SchemeExhAccountsId = ph.SchemeExhAccountsId,
		@AccountDay = ph.AccountDay,
		@ConsumptionFactor = ph.ConsumptionFactor,
		@CondPermLoss = ph.CondPermLoss,
		@PossibilityDevice = ph.PossibilityDevice,
		@PeriodNumber = ph.PeriodNumber
FROM 	vPointsHistory ph WHERE ph.PointId = @PointId AND ph.DtChange = (SELECT max(ph1.DtChange) FROM PointsHistory ph1 WHERE ph1.PointId = @PointId)

-- если последняя запись в том же периоде что и новая то проводим изменение записи
IF @PeriodNumber = (YEAR(@DtChange) * 100 + MONTH(@DtChange)) BEGIN
	SET @Function = 2
	SET @DtChange = @DtOldChange
END 
ELSE BEGIN
	-- если добавляем запись, проверяем прериод последней
	IF (YEAR(@DtOldChange) * 100 + MONTH(@DtOldChange)) = (YEAR(@DtChange) * 100 + MONTH(@DtChange)) BEGIN
		-- если совпадают, прибавляем к новой день
		SET @DtChange = DATEADD(DAY, 1, @DtOldChange)
	END 
END
-- запускаем процедуру Квазара
EXEC Points_PointsHistoryFunctions  @PointId,
									@DtChange,
									@DtOldChange,
									@Indication,
									@AccountStatusId,
									@TariffId,
									@NormId,
									@AccountTypeId,
									@ConsumMiddle,
									@LossesLine,
									@LossesTran,
									@Function,
									@SchemeExhAccountsId,
									@AccountDay,
									@ConsumptionFactor,
									@Audit,
									@CondPermLoss,
									@PossibilityDevice
GO 
GRANT EXECUTE ON Pr_ReconciliationTariffes TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReconciliationTariffes' AND type = 'P')
    DROP PROCEDURE Pr_ReconciliationTariffes
GO
CREATE PROCEDURE dbo.Pr_ReconciliationTariffes
	/*
		��������� ��� ��������� ��������� � ������� ��
		����������� ����� ������ � ������� ����������� ������
		�� ���������� ������� �������� �62
	*/
	@PointNumber 		VARCHAR(15),
	@DtChange 	 		DATE,
	@TariffId			INT
AS
DECLARE @PointId INT
-- ���������� �� ��
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

-- ��������� ���������� � ��������� ������ � ������� ��������
SELECT 	@DtOldChange = ph.DtChange,
		@Indication = -1,
		@AccountStatusId = ph.AccountStatusId,
		@NormId = ph.NormId,
		@AccountTypeId = ph.AccountTypeId,
		@ConsumMiddle = ph.ConsumMiddle,
		@LossesLine = ph.LossesLine,
		@LossesTran = ph.LossesTran,
		@Function = 1, -- ���������� ������
		@SchemeExhAccountsId = ph.SchemeExhAccountsId,
		@AccountDay = ph.AccountDay,
		@ConsumptionFactor = ph.ConsumptionFactor,
		@CondPermLoss = ph.CondPermLoss,
		@PossibilityDevice = ph.PossibilityDevice,
		@PeriodNumber = ph.PeriodNumber
FROM 	vPointsHistory ph WHERE ph.PointId = @PointId AND ph.DtChange = (SELECT max(ph1.DtChange) FROM PointsHistory ph1 WHERE ph1.PointId = @PointId)

-- ���� ��������� ������ � ��� �� ������� ��� � ����� �� �������� ��������� ������
IF @PeriodNumber = (YEAR(@DtChange) * 100 + MONTH(@DtChange)) BEGIN
	SET @Function = 2
	SET @DtChange = @DtOldChange
END 
ELSE BEGIN
	-- ���� ��������� ������, ��������� ������� ���������
	IF (YEAR(@DtOldChange) * 100 + MONTH(@DtOldChange)) = (YEAR(@DtChange) * 100 + MONTH(@DtChange)) BEGIN
		-- ���� ���������, ���������� � ����� ����
		SET @DtChange = DATEADD(DAY, 1, @DtOldChange)
	END 
END
-- ��������� ��������� �������
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
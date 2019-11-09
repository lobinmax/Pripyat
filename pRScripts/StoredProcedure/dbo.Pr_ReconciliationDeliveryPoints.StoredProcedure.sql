IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReconciliationDeliveryPoints' AND type = 'P')
    DROP PROCEDURE Pr_ReconciliationDeliveryPoints
GO
CREATE PROCEDURE dbo.Pr_ReconciliationDeliveryPoints
	/*
		Процедура для массового заполнения данных
		во вкладке Точки поставки
		Во исполнении приказа РусГидро №62
	*/
	@PointNumber      			VARCHAR(20),
	@SubstationTypeId     		TINYINT,
	@SubstationVoltageTypeId  	TINYINT,
	@TransPointVoltageTypeId  	TINYINT,
	@LineTypeId           		TINYINT,
	@TransPointTypeId     		INT,
	@DispenserTypeId      		TINYINT,
	@DispatchLineNameId   		TINYINT,
	@InterfaceTypeId      		TINYINT,
	@SubstationNumber     		VARCHAR(20),
	@SubstationName       		VARCHAR(50),
	@SubstationLineName   		VARCHAR(20),
	@TransPointNumber     		VARCHAR(20),
	@SupportNumber        		VARCHAR(20),
	@InterfaceNumber      		VARCHAR(20)
AS 
	DECLARE @PointId INT = (SELECT p.PointId FROM Points p WHERE p.PointNumber = @PointNumber)
	IF @PointId IS NULL BEGIN RETURN END
	-- проверяем существует ли запись
	IF EXISTS (SELECT * FROM RegisterPrepareDeliveryPoint rpdp WHERE rpdp.PointId = @PointId) BEGIN
		UPDATE RegisterPrepareDeliveryPoint SET SubstationTypeId = @SubstationTypeId, SubstationVoltageTypeId = @SubstationVoltageTypeId,
	                                          TransPointVoltageTypeId = @TransPointVoltageTypeId, LineTypeId = @LineTypeId,
	                                          TransPointTypeId = @TransPointTypeId, DispenserTypeId = @DispenserTypeId, DispatchLineNameId = @DispatchLineNameId,
	                                          InterfaceTypeId = @InterfaceTypeId, SubstationNumber = @SubstationNumber, SubstationName = @SubstationName,
	                                          SubstationLineName = @SubstationLineName, TransPointNumber = @TransPointNumber,	SupportNumber = @SupportNumber,
	                                          InterfaceNumber = @InterfaceNumber
		WHERE PointId = @PointId
	END
	ELSE  BEGIN
		INSERT INTO RegisterPrepareDeliveryPoint (PointId, SubstationTypeId, SubstationVoltageTypeId, TransPointVoltageTypeId, LineTypeId, TransPointTypeId,
	                                            DispenserTypeId, DispatchLineNameId, InterfaceTypeId, SubstationNumber, SubstationName,
	                                            SubstationLineName, TransPointNumber,	SupportNumber, InterfaceNumber) VALUES
	                                           (@PointId, @SubstationTypeId, @SubstationVoltageTypeId, @TransPointVoltageTypeId, @LineTypeId, @TransPointTypeId,
	                                            @DispenserTypeId, @DispatchLineNameId, @InterfaceTypeId, @SubstationNumber, @SubstationName,
	                                            @SubstationLineName, @TransPointNumber,	@SupportNumber, @InterfaceNumber)
	END
GO
GRANT EXECUTE ON Pr_ReconciliationDeliveryPoints TO KvzWorker
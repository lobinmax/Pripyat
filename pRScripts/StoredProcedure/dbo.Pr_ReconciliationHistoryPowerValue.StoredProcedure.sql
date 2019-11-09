IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReconciliationHistoryPowerValue' AND type = 'P')
    DROP PROCEDURE Pr_ReconciliationHistoryPowerValue
GO
CREATE PROCEDURE dbo.Pr_ReconciliationHistoryPowerValue
	/*
		Процедура для массового применения параметров 
		мощности	 	на точке учета
		Во исполнении приказа РусГидро №62
	*/
	@PointNumber			VARCHAR(15),
	@DtChange             	DATETIME,
	@PowerValue           	MONEY,
	@PowerCountHour       	INT,
	@PowerCountDay        	INT,
	@LightPowerValue      	MONEY,
	@LightCountHour       	INT,
	@LightCountDay        	INT,
	@HeatingPowerValue    	MONEY,
	@HeatingCountHour     	INT,
	@HeatingCountDay      	INT,
	@ActNumber            	VARCHAR(100) = '',
	@DtAct                	DATETIME
AS 

DECLARE	@PointId				INT
DECLARE @DtChangeLastRecord		DATETIME
-- Определяем ИД точки учата
SELECT @PointId = p.PointId FROM Points p WHERE p.PointNumber = @PointNumber
IF @PointId IS NULL BEGIN RETURN END

-- Определяем дату последней записи в истории
SELECT @DtChangeLastRecord = MAX(phpv.DtChange) FROM PointsHistoryPowerValue phpv WHERE phpv.PointId = @PointId

-- проверяем есть ли последняя запись с такими же параметрами
IF NOT EXISTS	(
				SELECT * FROM PointsHistoryPowerValue phpv 
				WHERE	phpv.PointId = @PointId AND 
						phpv.PowerValue = @PowerValue AND 
						phpv.PowerCountHour = @PowerCountHour AND 
						phpv.PowerCountDay = @PowerCountDay AND 
						phpv.LightPowerValue = @LightPowerValue AND 
						phpv.LightCountHour = @LightCountHour AND 
						phpv.LightCountDay = @LightCountDay AND 
						phpv.HeatingPowerValue = @HeatingPowerValue AND 
						phpv.HeatingCountHour = @HeatingCountHour AND 
						phpv.HeatingCountDay = @HeatingCountDay AND 
						phpv.DtChange = (
										SELECT 	MAX(phpv1.DtChange) 
										FROM 	PointsHistoryPowerValue phpv1 
										WHERE 	phpv1.PointId = @PointId
										) 
				) BEGIN
		-- если нет, проверяем в каком периоде последняя запись
		IF @DtChangeLastRecord IS NULL BEGIN
			-- записей нет, заносим первую
			EXEC Points_PointsHistoryPowerValueFunctions 	@PointId = @PointId,
															@DtChange = @DtChange,
															@PowerValue = @PowerValue,
															@PowerCountHour = @PowerCountHour,
															@PowerCountDay = @PowerCountDay,
															@LightPowerValue = @LightPowerValue,
															@LightCountHour = @LightCountHour,
															@LightCountDay = @LightCountDay,
															@HeatingPowerValue = @HeatingPowerValue,
															@HeatingCountHour = @HeatingCountHour,
															@HeatingCountDay = @HeatingCountDay,
															@ActNumber = @ActNumber,
															@DtAct = @DtAct,
															@Function = 1  
			RETURN
		END
		-- если последняя запись в текущем периоде
		IF (YEAR(@DtChangeLastRecord) * 100 + MONTH(@DtChangeLastRecord)) = (YEAR(@DtChange) * 100 + MONTH(@DtChange)) BEGIN
			-- Обновляем запись
			EXEC Points_PointsHistoryPowerValueFunctions 	@PointId = @PointId,
															@DtChange = @DtChange,
															@DtOldChange = @DtChangeLastRecord,
															@PowerValue = @PowerValue,
															@PowerCountHour = @PowerCountHour,
															@PowerCountDay = @PowerCountDay,
															@LightPowerValue = @LightPowerValue,
															@LightCountHour = @LightCountHour,
															@LightCountDay = @LightCountDay,
															@HeatingPowerValue = @HeatingPowerValue,
															@HeatingCountHour = @HeatingCountHour,
															@HeatingCountDay = @HeatingCountDay,
															@ActNumber = @ActNumber,
															@DtAct = @DtAct,
															@Function = 2
			RETURN
		END
		ELSE BEGIN
			-- добавляем запись
			EXEC Points_PointsHistoryPowerValueFunctions 	@PointId = @PointId,
															@DtChange = @DtChange,
															@PowerValue = @PowerValue,
															@PowerCountHour = @PowerCountHour,
															@PowerCountDay = @PowerCountDay,
															@LightPowerValue = @LightPowerValue,
															@LightCountHour = @LightCountHour,
															@LightCountDay = @LightCountDay,
															@HeatingPowerValue = @HeatingPowerValue,
															@HeatingCountHour = @HeatingCountHour,
															@HeatingCountDay = @HeatingCountDay,
															@ActNumber = @ActNumber,
															@DtAct = @DtAct,
															@Function = 1 
			RETURN
		END
END
GO
GRANT EXECUTE ON Pr_ReconciliationHistoryPowerValue TO KvzWorker
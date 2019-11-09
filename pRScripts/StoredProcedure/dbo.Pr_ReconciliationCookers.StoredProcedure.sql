IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReconciliationCookers' AND type = 'P')
    DROP PROCEDURE Pr_ReconciliationCookers
GO
CREATE PROCEDURE dbo.Pr_ReconciliationCookers
	/*
		Процедура для массового изменения в истории абоненента
		Добавляется новая строка с нужными параметрами плиты
		Во исполнении приказа РусГидро №62
	*/
	@AbonentNumber 		VARCHAR(15),
	@DtChange 	 		DATE,
	@CookerId			TINYINT
AS
DECLARE @AbonentId INT
-- определяем ИД абонента
SET @AbonentId = (SELECT e.ElementId FROM Elements e WHERE e.StateId = 1 AND e.Num = @AbonentNumber) 

DECLARE @DtOldChange        DATETIME,
		@FamilyMemberId	    INT,
		@AbonentStatusId    TINYINT,
		@HouseStatusId	    TINYINT,
		@HouseOwnerId		TINYINT,
		@Function			INT,
		@ReturnCode		    INT,
		@NotPlaneAccounts   BIT,
		@JuricticFacesId    INT,
		@ExtAbonentStatusId SMALLINT,
		@Notes              VARCHAR(50) = 'По приказу РуcГидро №62',
		@PeriodNumber 		INT


-- выгружаем информацию о последней записи в истории абонента
SELECT 	@DtOldChange = ah.DtChange,
		@FamilyMemberId = ah.FamilyMemberId,
		@AbonentStatusId = ah.AbonentStatusId,
		@HouseStatusId = ah.HouseStatusId,
		@HouseOwnerId = ah.HouseOwnerId,
		@Function = 1, -- добавление новой записи в историю абонента
		@ReturnCode = 0,
		@NotPlaneAccounts = ah.NotPlaneAccounts,
		@JuricticFacesId = ah.JuricticFacesId,
		@ExtAbonentStatusId = ah.ExtAbonentStatusId,
		@PeriodNumber = ah.PeriodNumber 
FROM 	vAbonentsHistory ah WHERE ah.AbonentId = @AbonentId AND ah.DtChange = (SELECT max(ah.DtChange) FROM AbonentsHistory ah WHERE ah.AbonentId = @AbonentId)

-- если последняя запись в том же периоде что и новая то проводим изменение записи
IF @PeriodNumber = (YEAR(@DtChange) * 100 + MONTH(@DtChange)) BEGIN
	SET @Function = 3
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
EXEC dbo.Abonents_AbonentsHistoryFunctions  @AbonentId, 
											@DtChange, 
											@DtOldChange, 
											@FamilyMemberId, 
											@AbonentStatusId, 
											@HouseStatusId, 
											@HouseOwnerId, 
											@CookerId, 
											@Function, 
											@ReturnCode,  
											@NotPlaneAccounts, 
											@JuricticFacesId, 
											@ExtAbonentStatusId, 
											@Notes
GO
GRANT EXECUTE ON Pr_ReconciliationCookers TO KvzWorker
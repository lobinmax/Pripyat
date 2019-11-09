IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ReconciliationContracts' AND type = 'P')
    DROP PROCEDURE Pr_ReconciliationContracts
GO
CREATE PROCEDURE dbo.Pr_ReconciliationContracts
	/*
		Процедура для массового заполнения данных
		во вкладке договор
		Во исполнении приказа РусГидро №62
	*/
	@PointNumber	VARCHAR(15),
	@DtConclusion 	SMALLDATETIME,	-- Дата заключения договора
   	@DtClosed 		SMALLDATETIME,	-- Дата рассторжения договора
   	@ContractNumber VARCHAR(50),	-- Номер договора
	@Function 		INT 			-- 1; Добавление записей
									-- 2; Проверка для даты рассторжения
AS 

DECLARE		@AbonentId		 	INT
DECLARE		@PerformerId 		INT
DECLARE  	@DtCreate 			DATETIME
DECLARE     @DtChangeMax		SMALLDATETIME
DECLARE		@CountContracts    	INT 

-- Определяем ИД абонента
SELECT 	@AbonentId = p.AbonentId FROM Points p WHERE p.PointNumber = @PointNumber
IF @AbonentId IS NULL BEGIN RETURN END
-- определяем собственника из истории абонента
		-- последняя запись в истории на момент заключения
SELECT 	@DtChangeMax = ahM.DtChange 
FROM 	(
		SELECT 	MAX(ah1.DtChange) AS DtChange 
		FROM 	(
				SELECT TOP(100) PERCENT 		ah.DtChange 
				FROM 		AbonentsHistory ah 
				WHERE 		ah.AbonentId = @AbonentId
				ORDER BY 	ah.DtChange
				) ah1
		) AS ahM

-- Добавление записей
IF @Function = 1 BEGIN
	/*
    SELECT 	@FamilyMemberId = ah.FamilyMemberId 
	FROM 	AbonentsHistory ah
	WHERE 	ah.AbonentId = @AbonentId AND ah.DtChange = @DtChangeMax
	*/
	SET @PerformerId = dbo.Kernel_GetPerformer()	-- Автор записи
	SET @DtCreate = GETDATE()						-- Сегодня
		
	-- Запись данных
	IF NOT EXISTS (SELECT * FROM Contracts c WHERE c.AbonentId = @AbonentId AND c.DtConclusion = @DtConclusion) BEGIN
		INSERT 	INTO Contracts
		SELECT 	@AbonentId, 
				NULL, 
				@DtConclusion, 
				@PerformerId, 
				@DtCreate, 
				@DtClosed, 
				@ContractNumber
	END
END 

--Проверка для даты рассторжения
IF @Function = 2 BEGIN
	SELECT @CountContracts = COUNT(c.AbonentId) FROM Contracts c WHERE c.AbonentId = @AbonentId 
			-- переменные для курсора
		DECLARE @CurRecord INT = 1 -- Номер записи курсора
		DECLARE @CurAbonentId INT
		DECLARE @CurDtConclusion SMALLDATETIME

		DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
		SELECT 	c.AbonentId, 
				c.DtConclusion 
		FROM  	Contracts c 
		WHERE 	AbonentId = @AbonentId

		OPEN  iCursor
			FETCH NEXT FROM iCursor INTO @CurAbonentId, @CurDtConclusion
		-- пока есть след строка
		WHILE @@FETCH_STATUS = 0 BEGIN 
			IF @CurRecord < @CountContracts BEGIN
				-- обновляем дату рассторжения на дату закл. след. договора
				UPDATE 	Contracts 
				SET 	DtClosed = (
									SELECT 	MAX(cn.DtConclusion) 
									FROM 	(
											SELECT TOP(100) PERCENT c.DtConclusion 
											FROM 		Contracts c 
											WHERE 		c.AbonentId = @CurAbonentId AND c.DtConclusion > @CurDtConclusion
											ORDER BY 	c.DtConclusion
											) AS cn
									)				
				WHERE AbonentId = @CurAbonentId AND DtConclusion = @CurDtConclusion
			END
			-- договор один
			IF @CurRecord = @CountContracts BEGIN
			-- добавляем собственника из последней записи в истории абонента
				UPDATE Contracts
				SET FamilyMemberId = 	(
										SELECT 	ah.FamilyMemberId 
										FROM 	AbonentsHistory ah 
										WHERE 	ah.AbonentId = @AbonentId AND ah.DtChange = @DtChangeMax
										)
				WHERE AbonentId = @AbonentId AND DtConclusion = @CurDtConclusion
			END
			SET @CurRecord = @CurRecord + 1
		-- след строка курсора	
		FETCH NEXT FROM iCursor INTO @CurAbonentId, @CurDtConclusion
		END  
		CLOSE iCursor
		DEALLOCATE iCursor	
END
GO
GRANT EXECUTE ON Pr_ReconciliationContracts TO KvzWorker
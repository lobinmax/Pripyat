IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OiOEventsMiscFunctions' AND type = 'P')
    DROP PROCEDURE Pr_OiOEventsMiscFunctions
GO
CREATE PROCEDURE dbo.Pr_OiOEventsMiscFunctions
	/*
	=================================================	
	|	�������������� ��������� �� ������			|
	|	��� ������� ����������� ������� 			|
	|	(�������� � ������ ������������ ���������)	|
	=================================================
	*/
		@AbonentId          	INT,
		@EventTypeId        	INT,
		---@CalcTypeId      	INT,			-- ������������ � ���� ���������
		@DtBeginOiO         	DATETIME,
		--@DtPlane          	DATETIME,		-- ������������ � ���� ���������
		@DtFact             	DATETIME,
		@DMethodId          	INT,
		@DocumentNumber     	VARCHAR(20),
		--@Function         	INT = 1,		-- �� ����� ���������
		--@ConnectFlag      	BIT = 0,		-- ����������� ����������� �� ������������
		@DocSum             	MONEY = 0,
		@InspectorId        	INT = NULL,
		@DocId					INT,			-- �� ��������� ��������� � ����	
		--@MobileInspectorId	INT = NULL		-- �� ����������
		--@DisableMethodId  	INT = NULL		-- �� ����������
		@SetCostDisable			INT, 			-- ����������� ������ �� ���������� (0 - ���; 1 - ��)
		@RecordOnlyPR  			INT    			-- ���� ������������ �������
												-- 	0 - ������ � � ������ � � �������
												--	1 - ������ ������ � �������
AS
SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

DECLARE		@Message			VARCHAR(300),
          	@PerformerId  		INT,
          	@PointId      		INT,
         	@ArticleId    		INT,
          	@PlanId       		INT,
          	@PeriodNumber 		INT,
          	@DocumentId   		INT,
          	@SumMoney     		MONEY,
          	@PackId       		INT,
          	@DtCreate     		DATETIME,
          	@PeriodNumberMin  	INT,
          	@PeriodNumberMax  	INT,
          	@AccountId    		INT,
          	@WiringId     		INT,
          	@StateId      		INT,
          	@Msg          		VARCHAR(500),
          	@ServiceId    		INT,
			@CalcTypeId			INT,
			@DtPlane            DATETIME,
			@ConnectFlag 		INT = 0
-- ��� ������
DECLARE   	@OldValueAudit  	VARCHAR(256),
          	@NewValueAudit  	VARCHAR(256),
          	@OldValueOiOAudit 	VARCHAR(256),
          	@NewValueOiOAudit 	VARCHAR(256)

DECLARE     @DtBeginOio_New   	DATETIME  	-- ���� ������ �� ������������ �� �������

SET @PerformerId = dbo.Kernel_GetPerformer()	-- ����� ������

-- ���� �� ���������������, ������������� ���� ������ �� �� ������������ � �������
IF NOT EXISTS (SELECT * FROM dbo.OioAbonents WHERE AbonentId = @AbonentId AND DtBeginOio = @DtBeginOio) BEGIN
	SET @DtBeginOio_New = (SELECT MAX(DtBeginOio) FROM OioAbonents WHERE AbonentId = @AbonentId)
	-- ���� ��� ���� ������ �����������, ������ �� �� ���������� 
	IF @DtBeginOio_New < @DtBeginOio BEGIN
		RAISERROR('�������������� ������ ��������� [dbo.Pr_OiOEventsMiscFunctions]!', 12, 2)
    	RETURN	
	END
	ELSE BEGIN
		SET @DtBeginOio = @DtBeginOio_New
	END
END

-- ���������� ��.���� � ����� ������� ��
SELECT 	@CalcTypeId = e.CalcTypeId, 			-- ����� ������� ��
		@DtPlane = e.DtPlane 					-- �������� ���� �������
FROM 	OioEvents e 
WHERE 	e.AbonentId = @AbonentId AND 
		e.EventTypeId = @EventTypeId AND 
      	e.DtBeginOiO = @DtBeginOiO

  /*IF @ConnectFlag = 1 AND @DtFact IS NULL BEGIN
    RAISERROR('��� ��������� �������� ������������ ����������� ����� ������� ����������� ����.', 12, 2)
    RETURN
  END*/
	
IF @EventTypeId IN(4, 6, 7) AND ISNULL(@DocSum, 0) = 0 BEGIN
	RAISERROR('��� ����� ������� ����������� ������� ��������� �����.', 12, 2)
	RETURN
END

-- ���� �������� ���������
IF @EventTypeId = 8 BEGIN
-- �������������� �� ����������� �������� ���������� ��� ��� �����
	SET @EventTypeId = (
						SELECT		e.EventTypeId
						FROM    	OioEvents e
						WHERE       DtPlane = 	(	
												SELECT		MIN(DtPlane) AS DtPlane
                              					FROM		OioEvents AS e1
                              					WHERE		AbonentId = @AbonentId AND 
															DtBeginOio = @DtBeginOiO AND 
															DtFact IS NULL AND 
															EventTypeId BETWEEN 8 AND 11
												) AND 
									AbonentId = @AbonentId AND 
									DtBeginOio = @DtBeginOiO AND 
									EventTypeId BETWEEN 8 AND 11
						)
	-- ���� �������� ���������� ���������
	IF @EventTypeId IS NULL BEGIN SET @EventTypeId = 11 END
END
  /*IF @EventTypeId = 6 AND @DisableMethodId = NULL BEGIN
    RAISERROR('��� ����� ������� ����������� ������� ������ ����������.', 12, 2)
    RETURN
  END*/

-- ���� �� ����������� ��� ���������, ����� �������� ��������
IF @EventTypeId NOT IN (1, 2, 5) SELECT @DMethodId = NULL
  
  -- ���������� ����������� � �� [������]   
IF @RecordOnlyPR = 0 BEGIN 	
	-- ������� ������ ��� ������
  	SELECT 		@OldValueOiOAudit = ea.Num + ' ('+dbo.Kernel_CastDateTimeToChar(@DtBeginOiO, 0)+') '
         		+ '�������: ' + t.EventName + '; ����: ' + dbo.Kernel_CastDateTimeToChar(e.DtPlane, 0)
         		+ '; ����: ' + dbo.Kernel_CastDateTimeToChar(e.DtFact, 0) + '; ��: ' + ISNULL(CAST(e.ConnectFlag AS VARCHAR(10)), '���')
         		+ ISNULL('; �����: ' + CAST(e.DocSum AS VARCHAR(10)), '') + ISNULL('; � ���������: ' + e.DocumentNumber, '')
         		+ '; ' + ISNULL(p.Name, '') + ISNULL('; ��������: ' + m.DMethodName, '')
  	FROM		OiOEvents e
  	INNER JOIN 	Elements ea ON ea.ElementId = e.AbonentId
  	INNER JOIN 	OiOEventsCalcs c ON c.CalcTypeId = e.CalcTypeId AND c.EventTypeId = e.EventTypeId
  	INNER JOIN 	OiOEventsTypes t ON t.EventTypeId = c.EventTypeId
  	LEFT JOIN 	vPerformersNameReport p ON p.PerformerId = e.InspectorId
  	LEFT JOIN 	OiODeliveryMethods m ON m.DMethodId = e.DMethodId
  	WHERE 		e.AbonentId = @AbonentId AND 
				e.EventTypeId = @EventTypeId AND 
				e.CalcTypeId = @CalcTypeId AND
        		e.DtBeginOiO = @DtBeginOiO
  	-- ������ ������ � ������� ��
  	UPDATE	OiOEvents 
	SET 	DtFact = @DtFact, DocumentNumber = @DocumentNumber, PerformerId = @PerformerId, 
			DMethodId = @DMethodId, ConnectFlag = @ConnectFlag, DtPlane = @DtPlane, 
			DocSum = @DocSum, InspectorId = @InspectorId, MobileInspectorId = NULL, 
			DisableMethodId = NULL
  	WHERE 	AbonentId = @AbonentId AND 
			EventTypeId = @EventTypeId AND 
			CalcTypeId = @CalcTypeId AND 
			DtBeginOiO = @DtBeginOiO
	-- �������� �������� ��� � ����������� ��������
  	EXECUTE dbo.OiO_UpdateEventByType 	@AbonentId, @EventTypeId, @CalcTypeId, @DtBeginOiO, @DtFact, @DMethodId, 
										@DocumentNumber, NULL, @PerformerId, @ConnectFlag

-- ����� �� ��
-- � �������� � �� �������
	SELECT 		@NewValueOiOAudit = '[�� �������] ' + ea.Num + ' ('+dbo.Kernel_CastDateTimeToChar(@DtBeginOiO, 0)+') ' +
	       		+ '�������: ' + t.EventName + '; ����: ' + dbo.Kernel_CastDateTimeToChar(e.DtPlane, 0)
	       		+ '; ����: ' + dbo.Kernel_CastDateTimeToChar(e.DtFact, 0) + '; ��: ' + ISNULL(CAST(e.ConnectFlag AS VARCHAR(10)), '���')
	       		+ ISNULL('; �����: ' + CAST(e.DocSum AS VARCHAR(10)), '') + ISNULL('; � ���������: ' + e.DocumentNumber, '')
	       		+ '; ' + ISNULL(p.Name, '') + ISNULL('; ��������: ' + m.DMethodName, '')
	FROM 		OiOEvents e
	INNER JOIN 	Elements ea ON ea.ElementId = e.AbonentId
	INNER JOIN 	OiOEventsCalcs c ON c.CalcTypeId = e.CalcTypeId AND c.EventTypeId = e.EventTypeId
	INNER JOIN 	OiOEventsTypes t ON t.EventTypeId = c.EventTypeId
	LEFT JOIN 	vPerformersNameReport p ON p.PerformerId = e.InspectorId
	LEFT JOIN 	OiODeliveryMethods m ON m.DMethodId = e.DMethodId
	WHERE 		e.AbonentId = @AbonentId AND 
				e.EventTypeId = @EventTypeId AND 
				e.CalcTypeId = @CalcTypeId AND
	      		e.DtBeginOiO = @DtBeginOiO

  	IF @OldValueOiOAudit != @NewValueOiOAudit EXECUTE dbo.Kernel_PutAuditJournal 21, 3, @OldValueOiOAudit, @NewValueOiOAudit, 0

  	IF @DtFact IS NULL BEGIN
    	RAISERROR('�� ������� ����������� ���� ����������.', 12, 2)
   		RETURN
  	END
END

-- ���������� � �� �������
IF EXISTS (SELECT * FROM Pr_JournalDocsDeveloped pjdd WHERE pjdd.DocId = @DocId) 
BEGIN
-- ���� ������ ���������� ��������� ��
	UPDATE 	Pr_JournalDocsDeveloped 
	SET 	DtBeginOio = @DtBeginOiO, DtFact = @DtFact, DMethodId = @DMethodId, 
			EventTypeId = @EventTypeId, PerformerId = @InspectorId, AuthorId = @PerformerId, 
			DtUpdate = GETDATE()
	WHERE 	DocId = @DocId
END
ELSE BEGIN
	INSERT Pr_JournalDocsDeveloped VALUES(@DocId, @DtBeginOiO, @DtFact, @DMethodId, @EventTypeId, @InspectorId, @PerformerId, GETDATE())
END

	-- ���������� ���� �� ������� ������������
IF @SetCostDisable = 1 BEGIN
	SELECT 	@PeriodNumberMin = MIN(PeriodNumber), 
			@PeriodNumberMax = MAX(PeriodNumber)
  	FROM 	AccountingPeriods  
	WHERE 	MonthStatus = 1
  	IF @PeriodNumberMin IS NULL AND @PeriodNumberMax IS NULL BEGIN
    	RETURN
  	END

  	SET @PointId = NULL

	-- ��������� ��� "�����������"
  	IF EXISTS (SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 331) BEGIN
    	SELECT 		@PointId = p.PointId, 
					@ServiceId = 12
    	FROM		(
      				SELECT DISTINCT p.AbonentId, p.PointId
      				FROM 			Points p
      				INNER JOIN 		(
                  					SELECT 		p.AbonentId, MIN(p.PointsOrder) AS PointsOrder
                  					FROM 		dbo.Points p 
                  					INNER JOIN 	vSchemes_PointsHistory_DtEnd h ON h.PointId = p.PointId 
												AND @DtFact BETWEEN h.DtChange AND h.DtEnd AND h.AccountStatusId IN(1, 3)
                  					WHERE 		p.EnergyTypeId = 1
                  					GROUP BY 	p.AbonentId
                					) m ON p.AbonentId = m.AbonentId AND p.PointsOrder = m.PointsOrder AND p.EnergyTypeId = 1
    				) p
    	INNER JOIN 	Points pp ON pp.PointId = p.PointId AND pp.PowerNetworkId = 2  AND pp.EnergyTypeId = 1
    	INNER JOIN 	vSchemes_PointsHistoryBalanceParts_DtEnd h ON h.PointId = p.PointId AND
               		@DtFact BETWEEN h.DtChange AND h.DtEnd AND h.PartId = 2
    	WHERE 		p.AbonentId = @AbonentId
  	END

	-- ������������
  	IF @PointId IS NULL BEGIN
	    SELECT 		@PointId = p.PointId, 
					@ServiceId = 2
	    FROM 		(
	      			SELECT DISTINCT p.AbonentId, p.PointId
	      			FROM 			Points p
	      			INNER JOIN  	(
	                  				SELECT 		p.AbonentId, MIN(p.PointsOrder) AS PointsOrder
	                  				FROM 		dbo.Points p 
	                  				INNER JOIN 	vSchemes_PointsHistory_DtEnd h ON h.PointId = p.PointId 
												AND @DtFact BETWEEN h.DtChange AND h.DtEnd AND h.AccountStatusId IN(1, 3)
	                  				WHERE 		p.EnergyTypeId = 1
	                  				GROUP BY 	p.AbonentId
	                				) m ON p.AbonentId = m.AbonentId AND p.PointsOrder = m.PointsOrder AND p.EnergyTypeId = 1
	    			) p
	    INNER JOIN 	Points pp ON pp.PointId = p.PointId AND pp.EnergyTypeId = 1
	    INNER JOIN 	PowerNetworks n ON n.PowerNetworkId = pp.PowerNetworkId AND n.PowerNetworkOvnerId = 2
	    INNER JOIN 	vSchemes_PointsHistoryBalanceParts_DtEnd h ON h.PointId = p.PointId AND
	               	@DtFact BETWEEN h.DtChange AND h.DtEnd AND h.PartId = 1
	    WHERE 		p.AbonentId = @AbonentId
  	END

	-- ����
	IF @PointId IS NULL BEGIN
		SELECT 		@PointId = p.PointId, 
					@ServiceId = 14
		FROM 		(
		  			SELECT DISTINCT p.AbonentId, p.PointId
		  			FROM 			Points p
		  			INNER JOIN 		(
		              				SELECT 		p.AbonentId, MIN(p.PointsOrder) AS PointsOrder
		              				FROM 		dbo.Points p 
		              				INNER JOIN 	vSchemes_PointsHistory_DtEnd h ON h.PointId = p.PointId 
												AND @DtFact BETWEEN h.DtChange AND h.DtEnd AND h.AccountStatusId IN(1, 3)
		        					WHERE 		p.EnergyTypeId = 1
		              				GROUP BY p.AbonentId
		            				) m ON p.AbonentId = m.AbonentId AND p.PointsOrder = m.PointsOrder AND p.EnergyTypeId = 1
					) p
		INNER JOIN 	Points pp ON pp.PointId = p.PointId AND pp.EnergyTypeId = 1
		INNER JOIN 	PowerNetworks n ON n.PowerNetworkId = pp.PowerNetworkId AND n.PowerNetworkOvnerId = 1
		WHERE 		p.AbonentId = @AbonentId
		
		IF @PointId IS NOT NULL AND EXISTS (SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 41 OR DivisionPrefix = 16) AND
			EXISTS (SELECT * FROM Abonents WHERE AbonentId = @AbonentId AND HousingOptionId = 2) BEGIN        -- ������������ ��� �������� ���
			RETURN
		END
	END

	IF @PointId IS NULL BEGIN
		RETURN
	END

	SELECT	@ArticleId = ArticleId, 
			@PlanId = PlanId
	FROM 	vArticlesPlan 
	WHERE 	Num = '85'

	-- ��������� �������� � ���� �� ������
	IF EXISTS 
			(
			SELECT 	* FROM vMemoOrdersShort m 
			WHERE 	m.PointId = @PointId AND 
					m.ArticleId = @ArticleId AND 
					m.DocumentTypeId = 7 AND 
					YEAR(@DtFact) * 100 + MONTH(@DtFact) = m.MonthDtDoc
			) BEGIN
		RETURN
	END

	SELECT TOP 1 	@SumMoney = -(Value + NDS)
  	FROM 			ServiceTariffsHistory 
	WHERE 			ServiceId = @ServiceId AND @DtFact >= DtBegin
  	ORDER BY 		DtBegin DESC

  	IF @SumMoney IS NULL SET @SumMoney = 0

  	SELECT @AccountId = AccountId FROM Accounts WHERE PointId = @PointId AND PlanId = @PlanId
  	SELECT @PeriodNumber = YEAR(@DtFact) * 100 + MONTH(@DtFact), @DtPlane = @DtFact - 1,
         	@DtCreate = dbo.Kernel_CastDateTimeToDate(GETDATE()), @StateId = 5

  	IF @PeriodNumber < @PeriodNumberMin SET @PeriodNumber = @PeriodNumberMin
  	IF @PeriodNumber > @PeriodNumberMax SET @PeriodNumber = @PeriodNumberMax

	BEGIN TRANSACTION
  		EXEC Documents_ChargePacksFunctions 
						@PackId OUTPUT, 1, 7, @DtCreate, '����������', @PeriodNumber OUTPUT,
       					0, @StateId OUTPUT, '����� �� ������ ���������� �� ���������������', 0, 0, 0, 
						NULL, NULL, 0, NULL, NULL, NULL 
  	IF @StateId != 5 BEGIN
    	SET @Msg = 	'����� ����-������� � "����������" �� ' + dbo.Kernel_CastDateTimeToChar(@DtCreate, 0) +
               		' �.�. ��������� ! ��������� ��.'
    	RAISERROR(@Msg, 12, 2)
    	ROLLBACK TRANSACTION
    	RETURN
  	END
  
  	EXEC Documents_MemoOrdersFunctions 
						@DocumentId OUTPUT, 7, @PackId, @PeriodNumber, @DtPlane, @DtFact,
      					@PointId, 0, 0, 0, 0, @SumMoney, @ArticleId, 2, @PlanId, 
						'���� �� ������ ���������� �� ���������������',
       					0, 1, NULL, NULL, 0, NULL, 0

  	EXEC Documents_ChargePacksClose @PackId, 5

  	UPDATE 	Documents 
	SET 	StateId = 5 
	WHERE 	DocumentId = @DocumentId
  
  	INSERT INTO JournalOfWiring 
				(AccountId, DocumentId, MonthNumber, WiringTypeId)
  	VALUES		(@AccountId, @DocumentId, @PeriodNumber, 2)

  	SET @WiringId = @@IDENTITY

  	INSERT INTO PartOfWiring 
				(MethodId, TariffId, PartOfWiringTypeId, MoneyAmount, PowerAmount, PrivilegeId, FamilyMemberId, LimitTypeId, WiringId) 
	VALUES 		(NULL, NULL, 1, @SumMoney, 0, NULL, NULL, 0, @WiringId)

  	SELECT 	@NewValueAudit = ISNULL(ArticleName, '')+'; '+PointNumber+'; '+dbo.Kernel_CastDateTimeToChar(DtDoc, 0)+'; '+
         	CAST(SumMoney AS VARCHAR(12))+' ���.; '
  	FROM 	vMemoOrders 
	WHERE 	DocumentId = @DocumentId

  	EXECUTE dbo.Kernel_PutAuditJournal 3, 12, NULL, @NewValueAudit, 0, NULL, @PointId, NULL, NULL

  	COMMIT TRANSACTION
  	RETURN
END

RETURN 0
GO
GRANT EXECUTE ON Pr_OiOEventsMiscFunctions TO KvzWorker
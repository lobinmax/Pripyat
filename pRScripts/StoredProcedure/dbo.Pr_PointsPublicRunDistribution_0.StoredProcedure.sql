IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PointsPublicRunDistribution_0' AND type = 'P')
    DROP PROCEDURE dbo.Pr_PointsPublicRunDistribution_0
GO
CREATE PROCEDURE dbo.Pr_PointsPublicRunDistribution_0
/*
	=================================================
	|	Распределение. При отсутствии соглашения   	|
	=================================================
*/
	@SectionId		INT,
	@PeriodNumber 	INT 
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @ConsumptionSection INT 		-- Расход по секции
DECLARE @CountRegisteredSection INT 	-- Количетво зарегистрированных в секции
DECLARE @DtCorrecting DATETIME = (SELECT dbo.Pr_fnsGetLastDayPeriod(@PeriodNumber))

-- общий расход по секции
SELECT  @ConsumptionSection = SUM(Consumption)
FROM    Pr_PointsPublicSectionsCharges
WHERE   SectionId = @SectionId AND PeriodNumber = @PeriodNumber

-- общее число зарегистрированных в секции
SELECT @CountRegisteredSection = SUM(l.CountRegistered)
FROM	Lodgers AS l 
INNER JOIN (
			SELECT p.AbonentId, p.PointId, MAX(l.DtChange) AS DtChange
			FROM Lodgers AS l 
			INNER JOIN Points AS p ON l.AbonentId = p.AbonentId
       		WHERE l.DtChange < dbo.Pr_fnsGetFirstDayPeriod(201802)
            GROUP BY p.AbonentId, p.PointId
			) AS lodM ON l.AbonentId = lodM.AbonentId AND l.DtChange = lodM.DtChange 
INNER JOIN Pr_PointsPublicSectionsConn AS pc ON lodM.PointId = pc.PointId
GROUP BY pc.SectionId
HAVING pc.SectionId = @SectionId

SELECT		p.PointId, 
			p.SectionId, 
			Consum.Consumption, 
			PartWiring.PowerAmount, 
			PartWiring.overPowerAmount, 
			Lodgers.CountRegistered 
			INTO #PrepareOSN 
FROM		( -- Разбивка расхода СН и свСН
			SELECT	m.PointId, SUM(ISNULL(pSN.PowerAmount * - 1, 0)) AS PowerAmount, SUM(ISNULL(psvSN.PowerAmount * - 1, 0)) AS overPowerAmount
         	FROM 	vMemoOrdersShort AS m 
			LEFT OUTER JOIN vPartOfWiringsMemoOrders AS psvSN ON m.DocumentId = psvSN.DocumentId AND psvSN.LimitTypeId = 2 
			LEFT OUTER JOIN vPartOfWiringsMemoOrders AS pSN ON m.DocumentId = pSN.DocumentId AND pSN.LimitTypeId = 1
         	WHERE m.PeriodNumber = @PeriodNumber
          	GROUP BY m.PointId
			) AS PartWiring
INNER JOIN Pr_PointsPublicSectionsConn AS p ON PartWiring.PointId = p.PointId 
INNER JOIN 	( -- Общий расход
			SELECT PointId, SUM(Consumption) AS Consumption
  			FROM (
				  SELECT PointId, 
				  		 CASE WHEN mos.DocumentTypeId = 7 THEN 
						 	Consumption * - 1 
						 ELSE 
						 	mos.Consumption 
						 END AS Consumption -- Если коррекция *-1
             	  FROM vMemoOrdersShort AS mos
                  WHERE PeriodNumber = @PeriodNumber
       			  GROUP BY PointId, CASE WHEN mos.DocumentTypeId = 7 THEN Consumption * - 1 ELSE mos.Consumption END
				  ) AS mo
			GROUP BY PointId
			) AS Consum ON p.PointId = Consum.PointId  
LEFT JOIN 	(-- данные о зарегистрированных
			SELECT lodM.AbonentId, lodM.PointId, l.CountRegistered
			FROM Lodgers AS l 
			RIGHT OUTER JOIN (
							  SELECT p.AbonentId, p.PointId, MAX(l.DtChange) AS DtChange
           					  FROM Lodgers AS l 
							  INNER JOIN Points AS p ON l.AbonentId = p.AbonentId
                      		  WHERE l.DtChange < dbo.Pr_fnsGetFirstDayPeriod(@PeriodNumber)
                              GROUP BY p.AbonentId, p.PointId
							  ) AS lodM ON l.AbonentId = lodM.AbonentId AND l.DtChange = lodM.DtChange
			GROUP BY lodM.AbonentId, lodM.PointId, l.CountRegistered
			) AS Lodgers ON p.PointId = Lodgers.PointId
WHERE 		p.SectionId = @SectionId

DECLARE @PointId INT
DECLARE @SocialNorm INT					-- социальная норма в ТУ
DECLARE @Coefficient NUMERIC(6, 4)		-- коэффициент распраделения
DECLARE @OSN NUMERIC(10, 0)				-- доля расхода для секция	
DECLARE @CorreсtingFactor VARCHAR(2) 	-- "-": снимаем начисление / "+": доначисляем
DECLARE @ConsumptionPoint INT 			-- расход ТУ общий
DECLARE @ConsumptionPointNorm INT 		-- расход ТУ СН
DECLARE @ConsumptionPointOverNorm INT	-- расход ТУ свСН
DECLARE @ConsumptionForCorrecting INT	-- объем корректировки общий
DECLARE @CorreсtingNorm INT 			-- корректировка СН
DECLARE @CorrectingOverNorm INT			-- корректировка свСН
DECLARE @CountRegistered INT 			-- зарегистрированные в ТУ

DECLARE iCursor CURSOR FAST_FORWARD READ_ONLY LOCAL FOR
SELECT po.PointId FROM #PrepareOSN AS po
OPEN iCursor
FETCH NEXT FROM iCursor INTO @PointId
WHILE @@FETCH_STATUS = 0 BEGIN
	   -- если в последнем закрытом периоде нет прописанных, получаем по последней записи
	   SET @CountRegistered = (SELECT ISNULL(po.CountRegistered, (
	   															  SELECT ldg.CountRegistered
																  FROM Lodgers AS ldg 
																  INNER JOIN Points AS p ON ldg.AbonentId = p.AbonentId
																  WHERE p.PointId = @PointId AND (ldg.DtChange = (
																  												 SELECT MAX(DtChange) 
                               																					 FROM Lodgers
                               																			 		 WHERE AbonentId = p.AbonentId
																												 )
																								  )
																  )) FROM #PrepareOSN AS po WHERE po.PointId = @PointId)
       SET @SocialNorm = (CASE WHEN @CountRegistered BETWEEN 0 AND 1 THEN 110 ELSE @CountRegistered * 75 END)
       SET @Coefficient = (SELECT CAST(CAST(po.CountRegistered AS NUMERIC(10, 4)) / CAST(@CountRegisteredSection AS NUMERIC(10, 4)) AS NUMERIC(10, 4)) 
	   					   FROM #PrepareOSN AS po WHERE po.PointId = @PointId)
       SET @OSN = @Coefficient * @ConsumptionSection
	   SET @ConsumptionPoint = (SELECT po.Consumption FROM #PrepareOSN AS po WHERE po.PointId = @PointId)
	   SET @ConsumptionForCorrecting = @ConsumptionPoint - @OSN
	   SET @CorreсtingFactor = CASE WHEN @ConsumptionForCorrecting > 0 THEN '-' ELSE '+' END 
       SET @ConsumptionPointNorm = (SELECT po.PowerAmount FROM #PrepareOSN AS po WHERE po.PointId = @PointId)
	   SET @ConsumptionPointOverNorm = (SELECT po.overPowerAmount FROM #PrepareOSN AS po WHERE po.PointId = @PointId)
/*
 -- для отладки	
		SELECT '@SocialNorm ' + CAST(@SocialNorm AS VARCHAR)
		UNION ALL
		SELECT '@Coefficient ' + CAST(@Coefficient AS VARCHAR)
		UNION ALL
		SELECT '@OSN ' + CAST(@OSN AS VARCHAR)
		UNION ALL
		SELECT '@ConsumptionPoint ' + CAST(@ConsumptionPoint AS VARCHAR)
		UNION ALL
		SELECT '@ConsumptionForCorrecting ' + CAST(@ConsumptionForCorrecting AS VARCHAR)
		UNION ALL
		SELECT '@CorreсtingFactor ' + CAST(@CorreсtingFactor AS VARCHAR)
		UNION ALL
		SELECT '@ConsumptionPointNorm ' + CAST(@ConsumptionPointNorm AS VARCHAR)
		UNION ALL
		SELECT '@ConsumptionPointOverNorm ' + CAST(@ConsumptionPointOverNorm AS VARCHAR)
		UNION ALL
		SELECT '@CountRegistered ' + CAST(@CountRegistered AS VARCHAR) 
		UNION ALL
		SELECT '@ConsumptionSection ' + CAST(@ConsumptionSection AS VARCHAR) 
*/

	   IF @OSN != @ConsumptionSection BEGIN  
			IF @CorreсtingFactor = '-' BEGIN
				-- если прописано 0 
				IF @CountRegistered = 0 BEGIN
					SET @CorreсtingNorm = 0
					SET @CorrectingOverNorm = @ConsumptionForCorrecting
				END 
				ELSE BEGIN
					IF @ConsumptionPointOverNorm != 0 BEGIN
						IF @ConsumptionPointOverNorm >= @ConsumptionForCorrecting BEGIN
							SET @CorreсtingNorm = 0
							SET @CorrectingOverNorm = @ConsumptionForCorrecting
						END
						IF @ConsumptionPointOverNorm <= @ConsumptionForCorrecting BEGIN
							SET @CorrectingOverNorm = @ConsumptionPointOverNorm
							SET @CorreсtingNorm = @ConsumptionForCorrecting - @ConsumptionPointOverNorm
						END
					END
					ELSE BEGIN
						SET @CorreсtingNorm = @ConsumptionForCorrecting
						SET @CorrectingOverNorm = 0
					END 
				END 
			END	
				
			IF @CorreсtingFactor = '+' BEGIN
				-- если прописано 0 
				IF @CountRegistered = 0 BEGIN
					SET @CorreсtingNorm = 0
					SET @CorrectingOverNorm = @ConsumptionForCorrecting 
				END 
				ELSE BEGIN
					IF 	@ConsumptionPointOverNorm = 0 AND @ConsumptionPointNorm = @SocialNorm OR 
						@ConsumptionPointOverNorm != 0 AND @ConsumptionPointNorm != 0	BEGIN
					 		SET @CorreсtingNorm = 0
							SET @CorrectingOverNorm = @ConsumptionForCorrecting
					END
					IF @ConsumptionPointNorm < @SocialNorm AND (@SocialNorm - @ConsumptionPointNorm) <= (@ConsumptionForCorrecting * -1) BEGIN
						SET @CorreсtingNorm = (@ConsumptionPointNorm - @SocialNorm) 
						SET @CorrectingOverNorm = ( @ConsumptionForCorrecting - @CorreсtingNorm) 
					END		
					IF @ConsumptionPointNorm < @SocialNorm AND (@SocialNorm - @ConsumptionPointNorm) >= (@ConsumptionForCorrecting * -1) BEGIN
						SET @CorreсtingNorm = @ConsumptionForCorrecting 
						SET @CorrectingOverNorm = 0
					END 
				END 
			END 
	   END 
	
--UPDATE #PrepareOSN SET CorrectingNorm = @CorreсtingNorm, CorrectingOverNorm = @CorrectingOverNorm WHERE PointId = @PointId
-- ставим коррекцию 
DECLARE @Notes VARCHAR(256) = 'ОСН: Расход общ.: ' + CAST(@ConsumptionSection AS VARCHAR) + ' кВт*ч | Коэфф.: ' + CAST(@Coefficient AS VARCHAR) + 
								' | Чел.: ' + CAST(@CountRegistered AS VARCHAR) + ' из ' + CAST(@CountRegisteredSection AS VARCHAR) + 
								' | Доля: ' + CAST(@OSN AS VARCHAR) + ' кВт*ч | Фактор: ' + @CorreсtingFactor + '| Схема №5'
IF @CorreсtingNorm !=0 BEGIN
	EXEC Documents_CorrectingDocumentsFunctions @DocumentId = @PointId, @EnergyTypeId = 1, @PlanId = 3, @ReasonCorrectId = 1, @InitRecalcTypeId = 5, 
	@DocumentNumber = 'ОСН', @DtControl = @DtCorrecting, @Consumption = @CorreсtingNorm, @SumCharges = 0, @Notes = @Notes, @RecalcObjectId = 0, 
	@Function = -1, @MethodId = 0
END 

IF @CorrectingOverNorm !=0 BEGIN
	EXEC Documents_CorrectingDocumentsFunctions @DocumentId = @PointId, @EnergyTypeId = 1, @PlanId = 3, @ReasonCorrectId = 1, @InitRecalcTypeId = 5, 
	@DocumentNumber = 'ОСН', @DtControl = @DtCorrecting, @Consumption = @CorrectingOverNorm, @SumCharges = 0, @Notes = @Notes, @RecalcObjectId = 1, 
	@Function = -1, @MethodId = 0
END 

FETCH NEXT FROM iCursor INTO @PointId
END
CLOSE iCursor
DEALLOCATE iCursor 
GO
GRANT EXECUTE ON dbo.Pr_PointsPublicRunDistribution_0 TO KvzWorker
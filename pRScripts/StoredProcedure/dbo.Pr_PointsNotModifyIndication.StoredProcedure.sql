IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PointsNotModifyIndication' AND type = 'P')
    DROP PROCEDURE dbo.Pr_PointsNotModifyIndication
GO
CREATE PROCEDURE dbo.Pr_PointsNotModifyIndication
/*
	=================================================
	|	Специально для Харунжа Н.В.					|
	|	выгрузка ТУ с последними ФП равными нулю	|
	|	и датой от которой тянется нулевой расход  	|
	=================================================
*/
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке
CREATE TABLE #tmpLastIndication(
								PointId INT, 
								DtDoc SMALLDATETIME, 
								NewIndication INT, 
								Consumption INT, 
								PointNumber VARCHAR(20),
								OldIndication INT,				-- предыдущий факт с ненулевым расходом
								DtOldIndication SMALLDATETIME,
								CountMonth INT, 				-- кол-во периодов между фактами
								FactList VARCHAR(MAX) 
								)
INSERT INTO #tmpLastIndication
SELECT DISTINCT 	m.PointId, 
					m.DtDoc, 
					MAX(m.NewIndication) AS NewIndication, 
					m.Consumption, 
					Points.PointNumber,
					NULL,
					NULL,
					NULL, 
					NULL 
FROM            	vMemoOrdersShort AS m 
INNER JOIN 			(
					SELECT 		m.PointId, 
								MAX(d.DtDoc) AS DtDoc
        			FROM 		Documents AS d 
					INNER JOIN 	MemoOrders AS m ON m.DocumentId = d.DocumentId 
					INNER JOIN 	Articles AS a ON a.ArticleId = m.ArticleId 
					INNER JOIN 	ChargePacks AS p ON m.PackId = p.PackId
                	WHERE       /*a.ArticleControlActionId = 1 AND */d.StateId = 5 AND p.PackTypeId IN (0, 2)
                	GROUP BY 	m.PointId
					) AS c ON c.PointId = m.PointId AND c.DtDoc = m.DtDoc AND m.DocumentTypeId IN (3, 4, 5) AND m.StateId = 5 AND m.PackTypeId IN (0, 2) 
INNER JOIN  		Points ON m.PointId = Points.PointId
GROUP BY		 	m.PointId, m.DtDoc, m.Consumption, Points.PointNumber
HAVING        		/*m.PointId = -1428459218 AND */m.Consumption = 0 

DECLARE @c1PointId 			INT
DECLARE @c1DtDoc 			SMALLDATETIME
DECLARE @c1NewIndication 	INT
DECLARE	c1Cursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
SELECT 	PointId, DtDoc, NewIndication FROM #tmpLastIndication
OPEN 	c1Cursor
-- открываем строку курсора
FETCH NEXT FROM c1Cursor INTO @c1PointId, @c1DtDoc, @c1NewIndication
-- пока есть след строка
	WHILE @@FETCH_STATUS = 0   
		BEGIN 
			DECLARE @c2PointId 			INT
			DECLARE @c2DtDoc 			SMALLDATETIME
			DECLARE @c2OldIndication 	INT
			DECLARE @c2Consumption	 	INT
			DECLARE @c2Notes		 	VARCHAR(MAX)
			DECLARE	@c2MultiString		VARCHAR(MAX)

			DECLARE	c2Cursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
			-- выборка для вложенного курсора
			SELECT DISTINCT 	m.PointId, 
								m.DtDoc, 
								m.OldIndication, 
								m.Consumption,
								m.Notes
			FROM            	vMemoOrdersShort AS m 
			INNER JOIN 			(
								SELECT		m.PointId, 
											d.DtDoc
                               	FROM     	Documents AS d 
								INNER JOIN  MemoOrders AS m ON m.DocumentId = d.DocumentId 
								INNER JOIN 	Articles AS a ON a.ArticleId = m.ArticleId 
								INNER JOIN 	ChargePacks AS p ON m.PackId = p.PackId
                               	WHERE       /*a.ArticleControlActionId = 1 AND */d.StateId = 5 AND p.PackTypeId IN (0, 2)
                               	GROUP BY 	m.PointId, d.DtDoc
								) AS c ON c.PointId = m.PointId AND c.DtDoc = m.DtDoc AND m.DocumentTypeId IN (3, 4, 5) AND m.StateId = 5 AND m.PackTypeId IN (0, 2)
			GROUP BY 			m.PointId, m.DtDoc, m.OldIndication, m.Consumption, c.PointId, m.Notes
			HAVING 				c.PointId = @c1PointId
			ORDER BY m.DtDoc DESC
			SET @c2MultiString = ''
			OPEN 	c2Cursor
			FETCH NEXT FROM c2Cursor INTO @c2PointId, @c2DtDoc, @c2OldIndication, @c2Consumption, @c2Notes
				-- пока есть след строка
				WHILE @@FETCH_STATUS = 0   
					BEGIN
					SET @c2MultiString = @c2MultiString + CONVERT(VARCHAR, @c2DtDoc, 104) + ' - ' + @c2Notes + CHAR(10)
					-- если найдена ФП у которой изменились показания
					-- PRINT CONVERT(VARCHAR, @c2DtDoc, 104) + ' / ' + CAST(@c2OldIndication AS VARCHAR)
					IF @c2OldIndication <> @c1NewIndication BEGIN
						UPDATE 	#tmpLastIndication 
						SET 	OldIndication = @c2OldIndication, 
								DtOldIndication = @c2DtDoc, 
								CountMonth = DATEDIFF(MONTH, @c2DtDoc, @c1DtDoc),	-- кол-во периодов между ФП
								FactList = RTRIM(LTRIM(@c2MultiString))
						WHERE 	PointId = @c2PointId
						BREAK
					END
			-- след строка курсора	
			FETCH NEXT FROM c2Cursor INTO @c2PointId, @c2DtDoc, @c2OldIndication, @c2Consumption, @c2Notes			
			END  
			CLOSE c2Cursor
			DEALLOCATE c2Cursor
-- след строка курсора	
FETCH NEXT FROM c1Cursor INTO @c1PointId, @c1DtDoc, @c1NewIndication
END  
CLOSE c1Cursor
DEALLOCATE c1Cursor

SELECT        		a.AbonentId, 
					#tmpLastIndication.PointId, 
					a.AbonNumber, 
					p.PointNumber, 
					a.LastSurName, 
					a.CommAddressString AS Address,
					(SELECT plb.pointbalanced FROM vPointLastBalanced plb WHERE plb.PointId = p.PointId) AS BalanceStatic,
					(SELECT pbt.Balans FROM vPointBalansedTm pbt WHERE pbt.pointid = p.PointId) AS BalanceDinamic,
					#tmpLastIndication.DtDoc, 
					#tmpLastIndication.NewIndication AS LastIndication, 
					#tmpLastIndication.DtOldIndication, 
					#tmpLastIndication.OldIndication, 
					#tmpLastIndication.CountMonth,
					#tmpLastIndication.FactList,
	 				e.Name AS TariffName, 
					n.Name AS PowerNetwork, 
					ct.Name AS CounterType, 
					chMax.CounterNumber, 
					ht.Name AS HouseType, 
					hp.HousePropName AS HouseProperties, 
					ast.Name AS AbonentStatus, 
					eas.Name AS AbonentReason, 
					ps.Name AS PointStatus,
					dbo.Pr_fnsGetShortFNS('', a.ControllerId, 1) AS ControllerName
FROM           	 	HouseProperties AS hp 
INNER JOIN 			vPr_HistoryMaxHouseProperties AS hpm ON hp.HousePropId = hpm.HousePropId 
RIGHT OUTER JOIN 	vPoints_ListPointsStatus AS pls 
INNER JOIN 			AbonentStatus AS ast ON pls.AbonentStatusId = ast.AbonentStatusId 
INNER JOIN 			AccountStatus AS ps ON pls.PointStatusId = ps.AccountStatusId 
INNER JOIN 			ExtAbonentStatus AS eas ON pls.ExtAbonentStatusId = eas.ExtAbonentStatusId 
RIGHT OUTER JOIN 	Elements AS e 
INNER JOIN 			vPr_HistoryMaxPoints AS phMax ON e.ElementId = phMax.TariffId 
RIGHT OUTER JOIN 	PowerNetworks AS n 
INNER JOIN 	 		Points AS p ON n.PowerNetworkId = p.PowerNetworkId 
INNER JOIN 			HouseTypes AS ht 
INNER JOIN 			vAbonents AS a ON 	ht.HouseTypeId = a.HouseTypeId ON 
										p.AbonentId = a.AbonentId ON 
										phMax.PointId = p.PointId ON 
										pls.AbonentId = p.AbonentId AND 
										pls.PointId = p.PointId ON 
										hpm.AbonentId = p.AbonentId 
RIGHT OUTER JOIN 	#tmpLastIndication 
LEFT OUTER JOIN 	vPr_HistoryMaxCounters AS chMax 
INNER JOIN 			CounterTypes AS ct ON 	chMax.CounterTypeId = ct.CounterTypeId ON 
											#tmpLastIndication.PointId = chMax.PointId ON 
											p.PointId = #tmpLastIndication.PointId

DROP TABLE #tmpLastIndication

GO
GRANT EXECUTE ON dbo.Pr_PointsNotModifyIndication TO KvzWorker
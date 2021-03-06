IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetLastIndication' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetLastIndication
GO
CREATE FUNCTION dbo.Pr_fnsGetLastIndication
/*=======================================================
Функция возвращяет последние показания 
=======================================================*/
(
@AbonentId		INT,
@Seporator		VARCHAR(5), -- разделитель значений
@IsHTML			BIT = 0		-- формат HTML
) 
RETURNS VARCHAR(MAX)
AS
BEGIN
DECLARE @Value VARCHAR(MAX) 
DECLARE @_Seporator VARCHAR(5) = ''
SET		@Value = ''
   
	-- переменные для хранения курсора
	DECLARE	@curString	VARCHAR(MAX)	
	-- курсор для..
	DECLARE	iCursor		CURSOR 	FOR
	(
	SELECT		CAST(m1.Num AS VARCHAR) + ': последние снятые показания ' + CONVERT(VARCHAR, m1.DtDoc, 104) + ' г. - ' + CAST(m1.NewIndication AS VARCHAR) AS String
	FROM		(
				SELECT				pm.PointId, 
									pm.DtChange_max, 
									ph.AccountStatusId
                FROM				PointsHistory AS ph 
				RIGHT OUTER JOIN	(
									SELECT		PointId, 
												MAX(DtChange) AS DtChange_max
                                    FROM		PointsHistory AS PointsHistory_1
									GROUP BY	PointId
									) AS pm 
									ON ph.PointId = pm.PointId AND ph.DtChange = pm.DtChange_max) AS pMax 
				INNER JOIN			(
									SELECT		AbonentId, 
												PointId, 
												MAX(DtDoc) AS DtLastIndication
									FROM		vMemoOrdersShort AS m1
									WHERE		(DocumentTypeId IN (3, 5)) AND (PackTypeId IN (0, 2)) AND (StateId = 5)
									GROUP BY	Num, AbonentId, PointId
									HAVING		(NOT (Num IS NULL))
									) AS MemMax 
									ON pMax.PointId = MemMax.PointId
				LEFT OUTER JOIN		vMemoOrdersShort AS m1 ON MemMax.DtLastIndication = m1.DtDoc AND MemMax.AbonentId = m1.AbonentId AND MemMax.PointId = m1.PointId
	WHERE		(m1.DocumentTypeId IN (3, 5)) AND 
				(m1.PackTypeId IN (0, 2)) AND 
				(m1.StateId = 5) AND 
				(NOT (m1.Num IS NULL)) AND 
				(m1.AbonentId = @AbonentId) AND 
                (pMax.AccountStatusId <> 2)
	)
	-- курсором заносим результат в одно поле
	OPEN  iCursor
	-- открываем строку курсора
		FETCH NEXT FROM iCursor INTO @curString
		-- пока есть след строка
		WHILE @@FETCH_STATUS = 0   
			BEGIN 
			-- перебираем строки 
				SET @Value =@Value + @_Seporator + @curString
				SET @_Seporator = @Seporator
		-- след строка курсора	
		FETCH NEXT FROM iCursor INTO @curString
		END  
	CLOSE iCursor
	DEALLOCATE iCursor
-- для HTML 
IF @IsHTML = 1 BEGIN 
	SET @Value = 
	'<pre><p align="left" style="font-size: 8pt; font-family:''Arial''; text-indent: 0px; margin-top: 0em; margin-bottom: 0em">' + 
	@Value + 
	'</p></pre>'
END 
RETURN @Value
END
GO
GRANT EXECUTE ON Pr_fnsGetLastIndication TO KvzWorker
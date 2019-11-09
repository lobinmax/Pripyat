IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetTaskPerformersString' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetTaskPerformersString
GO
CREATE FUNCTION dbo.Pr_fnsGetTaskPerformersString
/*
=========================================================
|	Функция возвращает привязанных к заданному листу	| 
|	задания исполнителей ввиде строки через разделитель	|
=========================================================
*/
	(
	@TaskSheetId INT = NULL --Ид листа выдачи задания
	)
	
RETURNS VARCHAR(MAX)

AS
BEGIN

DECLARE		@Value			VARCHAR(MAX) 
DECLARE		@iString		VARCHAR(MAX) = ''
DECLARE		@PerformerName	VARCHAR(50)
DECLARE		@PerformerId	INT
DECLARE		@Seporator		VARCHAR(5) = '' 

	-- курсор для..
	DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
	SELECT		PerformerId, 
				dbo.Pr_fnsGetShortFNS('', PerformerId, 1) AS PerformerName
	FROM		Pr_JournalTaskSheetPerformers
	WHERE		TaskSheetId = @TaskSheetId
	ORDER BY	PerformerName

	OPEN  iCursor
	-- открываем строку курсора
	FETCH NEXT FROM iCursor INTO @PerformerId, @PerformerName
	-- пока есть след строка
		WHILE @@FETCH_STATUS = 0   
			BEGIN 
				SET @iString = @iString + @Seporator + @PerformerName
				SET @Seporator = ' | '
	-- след строка курсора	
	FETCH NEXT FROM iCursor INTO @PerformerId, @PerformerName
	END  
	CLOSE iCursor
	DEALLOCATE iCursor

SET @Value = @iString
IF @iString = '' BEGIN
	SET @Value = 'Исполнители не назначены'
END
RETURN @Value
END

GO
GRANT EXECUTE ON Pr_fnsGetTaskPerformersString TO KvzWorker
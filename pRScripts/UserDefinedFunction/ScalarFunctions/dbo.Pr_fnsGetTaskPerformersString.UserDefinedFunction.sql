IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetTaskPerformersString' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetTaskPerformersString
GO
CREATE FUNCTION dbo.Pr_fnsGetTaskPerformersString
/*
=========================================================
|	������� ���������� ����������� � ��������� �����	| 
|	������� ������������ ����� ������ ����� �����������	|
=========================================================
*/
	(
	@TaskSheetId INT = NULL --�� ����� ������ �������
	)
	
RETURNS VARCHAR(MAX)

AS
BEGIN

DECLARE		@Value			VARCHAR(MAX) 
DECLARE		@iString		VARCHAR(MAX) = ''
DECLARE		@PerformerName	VARCHAR(50)
DECLARE		@PerformerId	INT
DECLARE		@Seporator		VARCHAR(5) = '' 

	-- ������ ���..
	DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
	SELECT		PerformerId, 
				dbo.Pr_fnsGetShortFNS('', PerformerId, 1) AS PerformerName
	FROM		Pr_JournalTaskSheetPerformers
	WHERE		TaskSheetId = @TaskSheetId
	ORDER BY	PerformerName

	OPEN  iCursor
	-- ��������� ������ �������
	FETCH NEXT FROM iCursor INTO @PerformerId, @PerformerName
	-- ���� ���� ���� ������
		WHILE @@FETCH_STATUS = 0   
			BEGIN 
				SET @iString = @iString + @Seporator + @PerformerName
				SET @Seporator = ' | '
	-- ���� ������ �������	
	FETCH NEXT FROM iCursor INTO @PerformerId, @PerformerName
	END  
	CLOSE iCursor
	DEALLOCATE iCursor

SET @Value = @iString
IF @iString = '' BEGIN
	SET @Value = '����������� �� ���������'
END
RETURN @Value
END

GO
GRANT EXECUTE ON Pr_fnsGetTaskPerformersString TO KvzWorker
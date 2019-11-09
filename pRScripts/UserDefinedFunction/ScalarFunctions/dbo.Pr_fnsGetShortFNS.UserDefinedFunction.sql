IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetShortFNS' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetShortFNS
GO
CREATE FUNCTION dbo.Pr_fnsGetShortFNS
/*  ������� ���������� ������� ��� ��������
	� ������� �.�.							*/
	(
	@Name			VARCHAR(100),	-- ���
	@PerformerId	INT,			-- �� ������������
	@Function		INT  			-- �����
										-- 0 - �� ���;
										-- 1 - �� �� ������������;
	)

RETURNS VARCHAR(100)
AS
	BEGIN
	DECLARE @Value VARCHAR(100)
	DECLARE @NewName VARCHAR(100)
		-- 0 - �� ���;
		IF @Function = 0 BEGIN
			-- ��� ���� �������� ���������� �������
			SET @NewName = REPLACE(REPLACE(REPLACE(@Name, '  ',' '), '  ',' '), '  ',' ')
			SET @Value =	(
							SELECT	PARSENAME(REPLACE(@NewName,' ','.'),3)+' '+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),2),1)+'.'+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),1),1)+'.'
							)
			-- ���� ��������� NULL ���������� �������� ��� 
			IF @Value IS NULL BEGIN
				SET @Value = @Name
			END    
			RETURN @Value
		END

		-- 1 - �� �� ������������;
		IF @Function = 1 BEGIN
			SET @NewName = (SELECT Name FROM Elements WHERE Elementid = @PerformerId)
			-- ��� ���� �������� ���������� �������
			SET @NewName = REPLACE(REPLACE(REPLACE(@NewName, '  ',' '), '  ',' '), '  ',' ')
			SET @Value =	(
							SELECT	PARSENAME(REPLACE(@NewName,' ','.'),3)+' '+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),2),1)+'.'+
							LEFT(	PARSENAME(REPLACE(@NewName,' ','.'),1),1)+'.'
							)
			-- ���� ��������� NULL ���������� ������ ���
			IF @Value IS NULL BEGIN
				SET @Value = (SELECT e.Name FROM Elements e WHERE e.ElementId = @PerformerId)
			END            
			RETURN @Value
		END
	RETURN NULL
	END
GO
GRANT EXECUTE ON Pr_fnsGetShortFNS TO KvzWorker
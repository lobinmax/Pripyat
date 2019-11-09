IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OiOValidateDtFact' AND type = 'P')
    DROP PROCEDURE Pr_OiOValidateDtFact
GO
CREATE PROCEDURE dbo.Pr_OiOValidateDtFact
	/*
	=========================================================	
	|	�������������� ��������� �� ������					|
	|	��� �������� ������������ ������������ ������� � ��	|	
	|	(�������� � ������ ������������ ���������)			|
	=========================================================
	*/
	@AbonentId    	INT 		= NULL,
	@DtBeginOio   	DATETIME 	= NULL,
	--@CalcTypeId   INT 		= NULL, ���������� � ���� ���������
	@EventTypeId  	INT 		= NULL,
	@DtFact       	DATETIME 	= NULL,
	@Result      	INT 		= 0   		--  ������ ����� ������
AS
	SET NOCOUNT ON			-- ��������� ������� ������������ �����
	SET XACT_ABORT ON		-- ������ ���������� �� ������

/* ���� ������ (��������)
	 0 	- �������
	-2	- ������� ������� ��
	-1	- ����������� ���� ������ �.���� ������ �� ���������� �������
	-3 	- ����� ������ 
	-4 	- ����������/����������� ����������� ������� ������
	-5 	- �����������, ����� ������� � ��������� ������ ������� � ��
	-6 	- ����������/����������� ����������, ��� �����������
	-7 	- �� ��� �� ���������� (������� �� ����� ������ �������)
*/

DECLARE 	@DtEndOio 			DATETIME 	-- ���� �������� ������� ��
DECLARE     @DtFact1 			DATETIME 	-- ����������� ���� �����������
DECLARE     @DtBeginOio_New   	DATETIME  	-- ���� ������ �� ������������ �� �������
DECLARE     @CalcTypeId   		INT 		-- ����� ������� ��

-- ���� �� ���������������, ������������� ���� ������ �� �� ������������ � �������
IF NOT EXISTS (SELECT * FROM dbo.OioAbonents WHERE AbonentId = @AbonentId AND DtBeginOio = @DtBeginOio) BEGIN
	SET @DtBeginOio_New = (SELECT MAX(DtBeginOio) FROM OioAbonents WHERE AbonentId = @AbonentId)
	-- ���� ��� ���� ������ ����������� ��� NULL, ������ �� �� ���������� 
	IF @DtBeginOio_New < @DtBeginOio OR @DtBeginOio_New IS NULL BEGIN
		SET @Result = -7 
		GOTO ExitProcedure	
	END
	-- ���� ���� ������ �� ��������� ��
	ELSE BEGIN
		SET @DtBeginOio = @DtBeginOio_New
	END
END

-- ���� �������� ������� ��
SELECT 	@DtEndOio = DtEndOio
FROM 	dbo.OioAbonents 
WHERE 	AbonentId = @AbonentId AND DtBeginOio = @DtBeginOio

-- ����� ������� ��
SELECT 	@CalcTypeId = e.CalcTypeId 
FROM 	OioEvents e 
WHERE 	e.AbonentId = @AbonentId AND 
		e.EventTypeId = @EventTypeId AND 
      	e.DtBeginOiO = @DtBeginOiO

IF GETDATE() > '20090531' AND (@EventTypeId BETWEEN 14 AND 20 ) BEGIN -- �������� �� �������� 13.05.2009 �227/26 - 810
  SET @Result = 0  -- �������� ������� ����� ������� ���� � '20090531'
END


-- ���� ������� �� �������
IF @DtEndOio <> '20781231' BEGIN -- �� 29.10.2010 �227/26� 1274
	IF @EventTypeId = 27 BEGIN -- �����������, ����� ������� � ��������� ������ ������� � �� 
		IF @DtBeginOio = (SELECT MAX(DtBeginOio) FROM OioAbonents WHERE AbonentId = @AbonentId) BEGIN
			SET @Result = 0
		END
		ELSE BEGIN 
			SET @Result = -5  -- ������� "�����������" ��������� ������� ������ ��� ��������� ������� � ������� ������
			GOTO ExitProcedure
		END
	END
	-- ������� ������� ��
	SET @Result = -2 
	GOTO ExitProcedure
END

-- ����������� ���� ����������� �� ��������
SELECT 	@DtFact1 = DtFact 
FROM 	dbo.OioEvents 
WHERE 	AbonentId = @AbonentId AND 
		DtBeginOio = @DtBeginOio AND 
		EventTypeId = 1

-- ��������� ��������� �� ������
IF @EventTypeId IN(3, 6) AND @DtFact1 IS NULL BEGIN --  '����������/����������� ���������� , ��� �����������'
  	SET @Result = -6
	GOTO ExitProcedure
END

-- ��� ���������� ��������� ������� ������ ���� ����� �����������
IF @EventTypeId = 6 BEGIN
	IF 	( @CalcTypeId = 1 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 65 ) OR
		( @CalcTypeId = 2 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 36 ) BEGIN
			SET @Result = 0
	END
	ELSE BEGIN
		SET @Result = -4 -- ���������� ����������� ������� ������
		GOTO ExitProcedure
	END
END

-- ��� ����������� ��������� ������� ������ ���� ����� �����������
IF @EventTypeId = 3 BEGIN
	IF 	( @CalcTypeId = 1 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 40 ) OR
		( @CalcTypeId = 2 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 30 ) BEGIN
			SET @Result = 0
	END
	ELSE BEGIN
		SET @Result = -4 -- ���������� ����������� ������� ������
		GOTO ExitProcedure
	END
END

-- ���������� ������� �� ������� � ����������� ����� ������� ������������
IF EXISTS 
(
  SELECT * 
  FROM dbo.OioEvents
  WHERE
  ( 
        AbonentId   = @AbonentId 
    AND DtBeginOio  = @DtBeginOio
    AND CalcTypeId  = @CalcTypeId
    AND EventTypeId < @EventTypeId
    AND DtFact > @DtFact
  )
) BEGIN
  SET @Result = -1 -- ����������� ���� ������ �.���� ������ �� ���������� ������� 
  GOTO ExitProcedure
END

IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId IN(14, 17, 352))
          AND dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20100326' BEGIN
  SET @Result = 0      -- �� 227/26�-260 �� 22.03.2010
END

IF EXISTS(SELECT * FROM vKernel_QuasarDataBases
          WHERE DivisionId IN(17, 13, 11) OR DivisionPrefix IN(13, 17, 18))
          AND dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20100321' BEGIN
  SET @Result = 0      -- �� 227/26� �� 11.03.2010
END

IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 26) AND -- QuasarBerezovka
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) BETWEEN '20111012' AND '20111014' BEGIN
  SET @Result = 0      -- �� 227/26� 1374 �� 27.09.2011
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 343) AND -- QLesosibirskVillages
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20091019' BEGIN
  SET @Result = 0      -- �� 227/26�-1153 �� 06.10.2009
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 25) AND -- ����������
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20091018' BEGIN
  SET @Result = 0      -- �� 013-227/26�-175 �� 24.09.2009
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionPrefix = 13) AND  -- ������������� ���
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20090918' BEGIN
  SET @Result = 0      -- �� 227/26�-1036 �� 11.09.2009
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId IN('52', '53')) AND -- ������ � �����
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20090915' BEGIN
  SET @Result = 0      -- �� 227/26�-851 �� 09.09.2009 (� �������� 11.09.2009 !)
END
IF EXISTS(SELECT * FROM AccountingPeriods WHERE MonthStatus = 2 AND PeriodNumber = YEAR(@DtFact) * 100 + MONTH(@DtFact)) BEGIN
  SET @Result = -3 -- ����� ������
  GOTO ExitProcedure
END

ExitProcedure:
SELECT @Result
GO
GRANT EXECUTE ON Pr_OiOValidateDtFact TO KvzWorker
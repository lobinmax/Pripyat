IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetTrackingProcedures' AND type = 'P')
    DROP PROCEDURE Pr_GetTrackingProcedures
GO
CREATE PROCEDURE dbo.Pr_GetTrackingProcedures
	/*
	=================================================================	
	|	������� ��� ��������� ������������� �������� �� �������	    |
	=================================================================		
	*/
	@ProcedureName 		VARCHAR(100), 			-- ��� ������������� ���������
	@Notes				TEXT 			= NULL,	-- ����������� � ���������
	@Function			INT  			= 0, 	-- ��������
												-- 0 - �������� �� ���������
												-- 1 - ��������� ������ � ���������
	@Result 			INT = 0 				-- ��� ������ ����� ������							
AS 
SET NOCOUNT ON
SET XACT_ABORT ON -- ������ ���������� �� ������
/* ���� ������ (��������)
	0 - �������
	1 - ��������� ���� ��������������
	2 - ��������� �� ����������
	3 - ��������� �� ��������� � ������ ������������
*/
DECLARE @DtLastUpdate DATETIME = (SELECT o.modify_date FROM sys.objects o WHERE o.name = @ProcedureName AND o.type = 'P') 			-- ���� ��������� ���������
DECLARE @DtTreckingUpdate DATETIME = (SELECT ptp.DtUpdate FROM Pr_TrackingProcedures ptp WHERE ptp.ProcedureName = @ProcedureName) 	-- ���� ��������� � dbo.Pr_TrackingProcedures

	-- 0 - �������� �� ���������
	IF @Function = 0 BEGIN
		IF 	EXISTS(SELECT * FROM Pr_TrackingProcedures ptp WHERE ptp.ProcedureName = @ProcedureName) BEGIN 
			IF @DtLastUpdate != @DtTreckingUpdate BEGIN
				SET @Result = 1
			END
			ELSE BEGIN
				SET @Result = 2
			END 
		END
		ELSE BEGIN
				SET @Result = 3
		END 
	END

	-- 1 - ��������� ��� ���������� ������ � ��������� 
	IF @Function = 1 BEGIN
		-- ���� ������������� ������� �������� � ������
		IF EXISTS(SELECT * FROM Pr_TrackingProcedures ptp WHERE ptp.ProcedureName = @ProcedureName) BEGIN
			UPDATE dbo.Pr_TrackingProcedures SET DtUpdate = @DtLastUpdate WHERE ProcedureName = @ProcedureName
		END
		ELSE BEGIN
			INSERT dbo.Pr_TrackingProcedures (ProcedureName, DtUpdate, Note) VALUES (@ProcedureName, @DtLastUpdate, @Notes)
		END  
	END
SELECT  @Result
GO
GRANT EXECUTE ON Pr_GetTrackingProcedures TO KvzWorker
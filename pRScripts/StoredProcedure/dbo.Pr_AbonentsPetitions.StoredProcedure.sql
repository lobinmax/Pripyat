IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_AbonentsPetitions' AND type = 'P')
    DROP PROCEDURE dbo.Pr_AbonentsPetitions
GO

CREATE PROCEDURE [dbo].[Pr_AbonentsPetitions]
@AbonentId					INT = NULL,				-- �� ��������
@MemberId					INT = NULL,				-- ������������� ����� �����
@DtPeriodStart				SMALLDATETIME = NULL,	-- ������ ���� ������
@DtPeriodEnd				SMALLDATETIME = NULL,	-- ������ ���� �����
@EnergyTypeId				INT = NULL,				-- �� ���� ������
@SerialNumberPetit			INT = NULL,				-- ����� �� �/�
@CopPerformerId				INT = NULL,				-- �� ��������
@ExecutiveNumber			VARCHAR(15) = NULL,		-- ����� ��
@ExcitementDt				DATE = NULL,			-- ���� ����������� ��
@DebtSumm					NUMERIC(10, 2) = NULL,	-- ����� �� ����������
@DtActImpossibleRecovery	SMALLDATETIME = NULL,	-- ���� ���� � ��
@ActImpossibleRecoveryId	INT = NULL,				-- �� ������� ���� � ��
@DtCompletion				DATE = NULL,			-- ���� ��������� ��
@Note						VARCHAR(300) = NULL,	-- ����������� � ��
@Function					INT= 1					-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
AS

SET NOCOUNT ON				-- ��������� ������� ������������ �����
SET XACT_ABORT ON			-- ������ ���������� �� ������
-- Id �������� ������������
DECLARE @PerformerId INT = (
							SELECT p.PerformerId 
							FROM dbo.Performers p 
							JOIN dbo.Elements e   ON p.PerformerId = e.ElementId 
							WHERE (e.ElemTypeId = 4 AND e.StateId = 10 )
							AND p.Login = SYSTEM_USER
							)


IF @Function = 1 BEGIN			-- �������
  SELECT     *
  FROM         vPr_Petitions
  WHERE     (AbonentId = @AbonentId) AND 
			(MemberId = @MemberId) AND 
			(DtPeriodStart = @DtPeriodStart) AND 
			(DtPeriodEnd = @DtPeriodEnd) AND 
			(EnergyTypeId = @EnergyTypeId)
  END

IF @Function = 2 BEGIN			-- ����� ������
--	� ���������� ������� �� ���� ���������� 1
set @SerialNumberPetit   = (
							SELECT	COUNT(AbonentId) + 1 AS COUNT
							FROM	Pr_Petitions
							WHERE	(AbonentId = @AbonentId) AND 
									(MemberId = @MemberId) AND 
									(DtPeriodStart = @DtPeriodStart) AND 
									(DtPeriodEnd = @DtPeriodEnd) AND 
									(EnergyTypeId = @EnergyTypeId)
								)

  INSERT INTO Pr_Petitions
                        (
						 AbonentId, 
						 MemberId, 
						 DtPeriodStart, 
						 DtPeriodEnd, 
						 EnergyTypeId, 
						 SerialNumberPetit, 
						 DtCreate, 
						 DtUpdade, 
						 CreatePerformerId, 
						 UpdatePerformerId, 
                         CopPerformerId, 
						 ExecutiveNumber,
						 ExcitementDt, 
						 DebtSumm, 
						 DtActImpossibleRecovery, 
						 ActImpossibleRecoveryId, 
						 DtCompletion, 
						 Note, 
						 PeriodCreate
						)
  VALUES     (
			  @AbonentId,
			  @MemberId,
			  @DtPeriodStart,
			  @DtPeriodEnd,
			  @EnergyTypeId,
			  @SerialNumberPetit, 
			  GETDATE(), 
              GETDATE(),
			  @PerformerId,
			  @PerformerId,
			  @CopPerformerId,
			  @ExecutiveNumber,
			  @ExcitementDt,
			  @DebtSumm,
			  @DtActImpossibleRecovery,
			  @ActImpossibleRecoveryId,
			  @DtCompletion,
			  @Note,
			  DATEPART(YEAR,GETDATE()) * 100 + DATEPARt(MONTH ,GETDATE()))


END

IF @Function = 3 BEGIN			-- ���������� ������
  UPDATE	Pr_Petitions
  SET		DtUpdade = GETDATE(), 
			UpdatePerformerId = @PerformerId, 
			CopPerformerId = @CopPerformerId, 
			ExecutiveNumber = @ExecutiveNumber, 
			ExcitementDt = @ExcitementDt, 
			DebtSumm = @DebtSumm, 
			DtActImpossibleRecovery = @DtActImpossibleRecovery, 
			ActImpossibleRecoveryId = @ActImpossibleRecoveryId, 
			DtCompletion = @DtCompletion, 
			Note = @Note
  WHERE     (AbonentId = @AbonentId) AND 
			(MemberId = @MemberId) AND 
			(DtPeriodStart = @DtPeriodStart) AND 
			(DtPeriodEnd = @DtPeriodEnd) AND 
			(EnergyTypeId = @EnergyTypeId) AND 
			(SerialNumberPetit = @SerialNumberPetit) 
END

IF @Function = 4 BEGIN			-- �������� ������
  DELETE FROM Pr_Petitions
  WHERE     (AbonentId = @AbonentId) AND 
			(MemberId = @MemberId) AND 
			(DtPeriodStart = @DtPeriodStart) AND 
			(DtPeriodEnd = @DtPeriodEnd) AND 
			(EnergyTypeId = @EnergyTypeId) AND 
			(SerialNumberPetit = @SerialNumberPetit)
-- ����� �������� ������ ������� ���������� ������ ���
DECLARE	@SerialNumber	CHAR(5) -- ����� ���������� �����
DECLARE	iCursor			CURSOR	-- ������
 
FOR -- ������ ��� �������
	-- �������� ��� ������ ��� ���������� ����� 
	-- ������ ������ �/� ��������� ������
	SELECT	SerialNumberPetit 
	FROM	Pr_Petitions
	WHERE	(AbonentId = @AbonentId) AND 
			(MemberId = @MemberId) AND 
			(DtPeriodStart = @DtPeriodStart) AND 
			(DtPeriodEnd = @DtPeriodEnd) AND 
			(EnergyTypeId = @EnergyTypeId) AND 
			(SerialNumberPetit > @SerialNumberPetit)

OPEN iCursor 

  	  FETCH NEXT from iCursor INTO @SerialNumber
  	  WHILE @@FETCH_STATUS = 0   
   	  BEGIN  
  	       -- � ������ ������ ��������� ����� �/� �� 1
		   UPDATE	Pr_Petitions 
		   SET		SerialNumberPetit = @SerialNumber-1 
		   WHERE	(AbonentId = @AbonentId) AND 
					(MemberId = @MemberId) AND 
					(DtPeriodStart = @DtPeriodStart) AND 
					(DtPeriodEnd = @DtPeriodEnd) AND 
					(EnergyTypeId = @EnergyTypeId) AND 
					(SerialNumberPetit = @SerialNumber)	
           FETCH NEXT from iCursor INTO @SerialNumber
  	  END  
	  CLOSE iCursor
	  DEALLOCATE iCursor
END
GO

GRANT EXECUTE ON dbo.Pr_AbonentsPetitions TO KvzWorker

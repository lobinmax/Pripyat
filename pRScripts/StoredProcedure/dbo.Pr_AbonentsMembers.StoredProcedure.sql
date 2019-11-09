IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_AbonentsMembers' AND type = 'P')
    DROP PROCEDURE dbo.Pr_AbonentsMembers
GO

CREATE PROCEDURE [dbo].[Pr_AbonentsMembers] 

@AbonentId			INT = NULL,				-- �� ��������
@MemberId			INT= NULL,				-- ������������� ����� �����
@Surname			VARCHAR(50)= NULL,		-- �������
@Name				VARCHAR(50)= NULL,		-- ���
@Patronymic			VARCHAR(50)= NULL,		-- ��������
@SexMembersId		TINYINT= NULL,			-- ���
@Residence			VARCHAR(100)= NULL,		-- ����� ��������
@DtResidence		DATE= NULL,				-- ���� ��������
@DtUnResidence		DATE= NULL,				-- ���� �������
@FamilyRoleId		TINYINT= NULL,			-- �� ���� ����� �����
@ShareOwner			BIT= NULL,				-- � ���� ��� ���
@PDDATEOfBirth		DATE= NULL,				-- �� ���� ��������
@PDSeries			NVARCHAR(4)= NULL,		-- �� �����
@PDNumber			NVARCHAR(6)= NULL,		-- �� �����
@PDDATEOfIssue		DATE= NULL,				-- �� ���� ������
@PDSubunit			VARCHAR(200)= NULL,		-- �� ��� �����
@PDSubunitCode		VARCHAR(7)= NULL,		-- �� ��� �������������
@PDString			VARCHAR(300)= NULL,		-- ���������� ������ ����� �������
@Phone				CHAR(20)= NULL,			-- ������� ����� �����
@Email				VARCHAR(50)= NULL,		-- ��. ����� ��������
@AddressOfLive		VARCHAR(200)= NULL,		-- ����� ����������
@PlaceOfWork		VARCHAR(60)= NULL,		-- ����� ������
--@DtCreate			SMALLdateTIME= NULL,	-- ���� �������� ������
--@DtUpDATE			SMALLdateTIME,			-- ���� ���������� ������
--@CreatePerformerId	INT= NULL,				-- �� ���������
--@UpDATEPerformerIdINT,					-- �� �����������
@Note				VARCHAR(300)= NULL,		-- �������
@Function			INT= 1					-- 1 - SELECT
											-- 2 - INSERT
											-- 3 - UPDATE
											-- 4 - DELETE
AS

SET NOCOUNT ON				-- ��������� ������� ������������ �����
SET XACT_ABORT ON			-- ������ ���������� �� ������

DECLARE @PerformerId INT	-- Id �������� ����������

  SELECT @PerformerId = p.PerformerId 
  FROM dbo.Performers p 
  JOIN dbo.Elements e   ON p.PerformerId = e.ElementId 
  WHERE (e.ElemTypeId = 4 AND e.StateId = 10 )
  AND p.Login = SYSTEM_USER


IF @Function = 1 BEGIN			-- �������
  SELECT    vPr_Member.*
  FROM      vPr_Member
  WHERE     AbonentId = @AbonentId
  END

IF @Function = 2 BEGIN			-- ����� ������
  INSERT INTO Pr_Members (
                          AbonentId, Surname, Name, 
						  Patronymic, SexMembersId, 
						  Residence, DtResidence, 
						  DtUnResidence, FamilyRoleId, 
						  ShareOwner, PDDateOfBirth, 
                          PDSeries, PDNumber, PDDateOfIssue, 
						  PDSubunit, PDSubunitCode, PDString, 
						  Phone, Email, AddressOfLive, 
						  PlaceOfWork, DtCreate, DtUpdate, 
                          UpdatePerformerId, CreatePerformerId, Note)

  VALUES     (
			  @AbonentId, @Surname, @Name, @Patronymic, @SexMembersId,
			  @Residence, @DtResidence, @DtUnResidence, @FamilyRoleId,
			  @ShareOwner, @PDDateOfBirth, @PDSeries, @PDNumber,
			  @PDDateOfIssue, @PDSubunit, @PDSubunitCode, @PDString,
			  @Phone, @Email, @AddressOfLive, @PlaceOfWork,
              GETDATE(), GETDATE(), 
			  @PerformerId, @PerformerId, @Note
			  )
END

IF @Function = 3 BEGIN			-- ���������� ������
  UPDATE    Pr_Members

  SET       Surname = @Surname, 
            Name = @Name, 
			Patronymic = @Patronymic, 
			SexMembersId = @SexMembersId, 
			Residence = @Residence, 
            DtResidence = @DtResidence, 
			DtUnResidence = @DtUnResidence, 
			FamilyRoleId = @FamilyRoleId, 
			ShareOwner = @ShareOwner, 
            PDDateOfBirth = @PDDateOfBirth, 
			PDSeries = @PDSeries, 
			PDNumber = @PDNumber, 
			PDDateOfIssue = @PDDateOfIssue, 
			PDSubunit = @PDSubunit, 
            PDSubunitCode = @PDSubunitCode, 
			PDString = @PDString, 
			Phone = @Phone, 
			Email = @Email, 
			AddressOfLive = @AddressOfLive, 
            PlaceOfWork = @PlaceOfWork, 
			DtUpdate = GETDATE(), 
            UpdatePerformerId = @PerformerId, 
			Note = @Note

  WHERE     MemberId = @MemberId 

END

IF @Function = 4 BEGIN			-- �������� ������
  DELETE Pr_Members WHERE MemberId = @MemberId
END

IF @Function = 5 BEGIN			-- ������� ��� ������ ����� �� ������ �� ������
  SELECT     FamilyMemberId, FullName
  FROM       vFamilyMembers
  WHERE      AbonentId = @AbonentId        
END 

IF @Function = 6 BEGIN			-- ������� ��� ������ ����� 
  SELECT	SurName,			-- � ������ ����������� �� ������ �� ������
			Name, 
			Patronymic, 
			RoleName AS FamilyRoles, 
			MaleAFemale AS SexMembers, 
			DateOfBirth AS PDDateOfBirth, 
			DtBegin   AS DtResidence, 
            DtClosed  AS DtUnResidence, 
			RegistrAddress AS Residence, 
			ShareOwner, 
			PassportSeries AS PDSeries, 
			PassportNumber AS PDNumber, 
            cast(PassportDate as date)  AS PDDateOfIssue, 
			PassportSubunit AS PDSubunit, 
			PassportSubunitCode AS PDSubunitCode, 
			Passport
  FROM      vFamilyMembers
  WHERE     FamilyMemberId = @MemberId
  END

  IF @Function = 7 BEGIN		-- ������� ��� ������ ����� �� ������ �� �������
SELECT     MemberId, Surname + ' ' + Name + ' ' + Patronymic AS FullName
FROM         Pr_Members
WHERE     (AbonentId = @AbonentId)
  END
GO

GRANT EXECUTE ON dbo.Pr_AbonentsMembers TO KvzWorker

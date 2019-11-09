IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_JudicialArea' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_JudicialArea
GO

CREATE PROCEDURE [dbo].[Pr_Books_JudicialArea] 
@JudicialAreaId			INT,			-- �� ��������� �������
@CourtTypeId		    INT,			-- �� ���������
@Postal					INT,			-- �������� ������ �������
@Adress  				VARCHAR(100),	-- ����� ��������� �������
@HouseNumber			NCHAR(4),		-- ����� ���� ��������� �������
@ZoneOfServiceId		INT,			-- ���� ������������ ��������� �������
@JudicialAreaName		VARCHAR(30),	-- �������� ��������� �������
@Number					VARCHAR(10),	-- ����� ��������� �������
@CurrentJudgeId			INT,			-- �� �������� �������� ����� �������
@Phone					VARCHAR(20),	-- ������� ��������� �������
@PhoneMobile			VARCHAR(20),	-- ��� ������� ��������� �������
@email					VARCHAR(50),	-- Mail ��������� �������
@Site					VARCHAR(50),	-- ���� ��������� �������
@Function				INT				-- 1 - SELECT
										-- 2 - INSERT
										-- 3 - UPDATE
										-- 4 - DELETE
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

IF @Function = 1 BEGIN	-- �������
  SELECT * FROM vPr_JudicialArea as vPr_
           WHERE CourtTypeId = @CourtTypeId
  RETURN 0
END

IF @Function = 2 BEGIN			-- ����� ������
  INSERT INTO Pr_JudicialArea
                        (CourtTypeId,
						 Postal, 
						 Adress,
						 HouseNumber, 
						 ZoneOfServiceId,
						 JudicialAreaName, 
						 Number, 
						 CurrentJudgeId, 
						 Phone, 
						 PhoneMobile, 
						 email, 
						 Site)
  VALUES				(@CourtTypeId, 
						 @Postal,
						 @Adress,
						 @HouseNumber, 
						 @ZoneOfServiceId, 
						 @JudicialAreaName,
						 @Number, 
						 @CurrentJudgeId, 
						 @Phone, 
						 @PhoneMobile, 
						 @email, 
						 @Site)
--EXEC Pr_Books_JudicialArea @CourtTypeId = @CourtTypeId, @Function = 1
  RETURN 0
END

IF @Function = 3 BEGIN			-- ���������� ������
  UPDATE Pr_JudicialArea SET    CourtTypeId = @CourtTypeId, 
								Postal = @Postal, 
								Adress = @Adress,
								HouseNumber = @HouseNumber,
								ZoneOfServiceId = @ZoneOfServiceId, 
								JudicialAreaName = @JudicialAreaName,
								Number = @Number, 
								CurrentJudgeId = @CurrentJudgeId, 
								Phone = @Phone, 
								PhoneMobile = @PhoneMobile, 
								email = @email, 
								Site = @Site
 WHERE JudicialAreaId = @JudicialAreaId 

--EXEC Pr_Books_JudicialArea @CourtTypeId = @CourtTypeId, @Function = 1
  RETURN 0
END

IF @Function = 4 BEGIN			-- �������� ������
  DELETE Pr_JudicialArea WHERE JudicialAreaId = @JudicialAreaId
--EXEC Pr_Books_JudicialArea @CourtTypeId = @CourtTypeId, @Function = 1
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_JudicialArea TO KvzWorker

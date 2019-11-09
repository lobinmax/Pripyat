IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_Judges' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_Judges
GO

CREATE PROCEDURE [dbo].[Pr_Books_Judges] 
@JudgeId		INT,			-- �� �����
@CourtTypeId	INT,			-- �� ���������
@Name			VARCHAR(50),	-- ��� �����
@Phone			CHAR(20),		-- ������� �����
@PhoneMobile	VARCHAR(20),	-- ��������� �����
@email			VARCHAR(50),	-- Mail �����
@Function		INT				-- 1 - SELECT
								-- 2 - INSERT
								-- 3 - UPDATE
								-- 4 - DELETE
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

IF @Function = 1 BEGIN	-- �������
  SELECT	Pr_Judges.*
  FROM		Pr_Judges
  WHERE     (CourtTypeId = @CourtTypeId)
  RETURN 0
END

IF @Function = 2 BEGIN			-- ����� ������
  INSERT INTO Pr_Judges
                        (
						 CourtTypeId, 
						 Name, 
						 Phone, 
						 PhoneMobile, 
						 email
						 )
  VALUES     (
			  @CourtTypeId,
			  @Name,
			  @Phone,
			  @PhoneMobile,
			  @email)
  RETURN 0
END

IF @Function = 3 BEGIN			-- ���������� ������
  UPDATE    Pr_Judges
  SET              
		CourtTypeId = @CourtTypeId, 
		Name = @Name, 
		Phone = @Phone, 
		PhoneMobile = @PhoneMobile, 
		email = @email

  WHERE (JudgeId = @JudgeId) 
   RETURN 0
END

IF @Function = 4 BEGIN			-- �������� ������
  DELETE FROM Pr_Judges
  WHERE     (JudgeId = @JudgeId)
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_Judges TO KvzWorker

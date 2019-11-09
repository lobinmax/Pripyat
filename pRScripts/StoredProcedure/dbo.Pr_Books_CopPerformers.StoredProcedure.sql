IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_CopPerformers' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_CopPerformers
GO

CREATE PROCEDURE [dbo].[Pr_Books_CopPerformers]
@CopPerformerId			INT = NULL,				-- �� ��������
@Name					VARCHAR(50) = NULL,		-- ��� ��������
@Phone					VARCHAR(20) = NULL,		-- �������
@PhoneMobile  			VARCHAR(20) = NULL,		-- ���������
@email					VARCHAR(50) = NULL,		-- ��.�����
@Function				INT = 1		-- 1 - SELECT
									-- 2 - INSERT
									-- 3 - UPDATE
									-- 4 - DELETE
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

IF @Function = 1 BEGIN	-- �������
  SELECT		*
  FROM			Pr_CopPerformers
  ORDER BY		Name
END

IF @Function = 2 BEGIN			-- ����� ������
/*-- @CopPerformersId = ���������� �����
DECLARE @CountCops INT = (SELECT     COUNT(CopPerformerId) + 1 AS COUNT
                       FROM         Pr_CopPerformers)*/

  INSERT INTO Pr_CopPerformers 
              (
			   Name, 
			   Phone, 
			   PhoneMobile, 
			   Email
			  )
  VALUES       (
				@Name,
				@Phone,
				@PhoneMobile,
				@Email
			    )
END

IF @Function = 3 BEGIN			-- ���������� ������
  UPDATE    Pr_CopPerformers
  SET       Name = @Name, 
			Phone = @Phone, 
			PhoneMobile = @PhoneMobile, 
			Email = @Email
  WHERE     (CopPerformerId = @CopPerformerId) 

END

IF @Function = 4 BEGIN			-- �������� ������
  DELETE FROM Pr_CopPerformers
  WHERE			(CopPerformerId = @CopPerformerId)
END

IF @Function = 5 BEGIN	-- ������� ��� ������
  SELECT     CopPerformerId AS id, Name AS name
  FROM         Pr_CopPerformers
  UNION
  SELECT     NULL, ''	-- ������ ������ � ������ ������
  ORDER BY Name
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_CopPerformers TO KvzWorker

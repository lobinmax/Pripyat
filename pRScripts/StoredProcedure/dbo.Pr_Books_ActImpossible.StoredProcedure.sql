IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_Books_ActImpossible' AND type = 'P')
    DROP PROCEDURE dbo.Pr_Books_ActImpossible
GO
CREATE PROCEDURE [dbo].[Pr_Books_ActImpossible]
@ActImpossibleRecoveryId	INT = NULL,			-- �� ������� ���� � ��
@Name						VARCHAR(30) = NULL,	-- ������� ���� � ��
@Function					INT = 1				-- 1 - SELECT
												-- 2 - INSERT
												-- 3 - UPDATE
												-- 4 - DELETE
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

/*IF @Function = 1 BEGIN	-- �������
 

END*/

/*IF @Function = 2 BEGIN			-- ����� ������


END*/

/*IF @Function = 3 BEGIN			-- ���������� ������
 

END*/

/*IF @Function = 4 BEGIN			-- �������� ������


END*/

IF @Function = 5 BEGIN	-- ������� ��� ������
  SELECT     ActImpossibleRecoveryId AS id, Name AS name
  FROM         Pr_ActImpossibleRecovery
  UNION all
  SELECT     NULL, ''	-- ������ ������ � ������ ������
  ORDER BY Name
  RETURN 0
END
GO

GRANT EXECUTE ON dbo.Pr_Books_ActImpossible TO KvzWorker

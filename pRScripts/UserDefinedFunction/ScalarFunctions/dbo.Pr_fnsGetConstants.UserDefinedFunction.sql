IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetConstants' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetConstants
GO
--
CREATE FUNCTION Pr_fnsGetConstants
(
@Parameter	INT		= 0,	--	������ ������������ ����������� 
/*					= 1		--  ����������� ������������ ����������� 	
					= 2		--  ����� ������� ��� ������
								@View = 0 -- ����� 
								@View = 1 -- ����� � ������� (�.����������� �� �������� 116 � �. 8(39145)6-16-28 , 8(39145)6-09-45  c 17.00 �� 8.00 ������������ )
					= 3		--  ������ ���������
					= 4		--  email
					= 5		--  �������� ������������� (010/5-022)
					= 6     --  0 - ��������� ����; 1 - �������� ����
					= 7		--  �����������: �������� ���������
					= 8		--	�������: ������������
					= 9 	-- 	�������� ������� �� ���� (131)
*/
@View		INT     = 0		--	�������� ������������� ��������
) 
RETURNS VARCHAR(MAX)

AS

BEGIN
DECLARE @Value VARCHAR(MAX)
--(������������� ��� ���  "��������������������")
IF @Parameter =	0 BEGIN
SET @Value =	(
				SELECT	LTRIM(RTRIM(value)) AS DivisionName
				FROM	Constants
				WHERE	(Name = 'DivisionName')
				)
END

--(���� ���  "��������������������")
IF @Parameter =	1 BEGIN
SET @Value =	(
				SELECT	LTRIM(RTRIM(value)) AS NameOrganisation
				FROM	Constants
				WHERE	(Name = 'NameOrganisation')
				)
END

IF @Parameter =	2 BEGIN
	--(�.����������� �� �������� 116 �)
	IF @View = 0 BEGIN
		SET @Value =	(
						SELECT	LTRIM(RTRIM(value)) AS OrganizationAddress
						FROM	Constants
						WHERE	(Name = 'OrganizationAddress')
						)
	END
	--(�.����������� �� �������� 116 � �. 8(39145)6-16-28 , 8(39145)6-09-45  c 17.00 �� 8.00 ������������)
	IF @View = 1 BEGIN	
		SET @Value =	(
						(SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='OrganizationAddress')+' �. '+
						(SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='OrganizationPhone')
						)
	END
END

--(8(39145)6-16-28 , 8(39145)6-09-45  c 17.00 �� 8.00 ������������)
IF @Parameter =	3 BEGIN
SET @Value =	(
				SELECT	LTRIM(RTRIM(value)) AS OrganizationPhone
				FROM	Constants
				WHERE	(Name = 'OrganizationPhone')
				)
END

--(email:nurdinovrf@les.krsk-sbit.ru)
IF @Parameter =	4 BEGIN
SET @Value =	(
				SELECT	'email: ' + LTRIM(RTRIM(ISNULL(email, ''))) AS email
				FROM	vKernel_QuasarDataBases
				)
END

--(010/5-022)
IF @Parameter =	5 BEGIN
SET @Value =	(
				SELECT	(SELECT Value FROM Pr_PripyatConstants AS c0 WHERE Name = 'NomenclatureDivision') + '-' +
				        (SELECT Value FROM Pr_PripyatConstants AS c1 WHERE Name = 'NomenclatureGroup'   ) AS Value
				)
END

--0 - ��������� ����; 1 - �������� ����
IF @Parameter =	6 BEGIN
SET @Value =	(
				SELECT Value FROM Pr_PripyatConstants WHERE Name = 'CityOrVillages'
				)
END

-- �����������: �������� ��������� (������������ ������ ������ � ��)
IF @Parameter =	7 BEGIN
SET @Value =	(
				SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='NameRuleManager'
				)
END

-- �������: ������������ (���)
IF @Parameter =	8 BEGIN
SET @Value =	(
				SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='Manager'
				)
END

-- �������� ������� �� ���� (131)
IF @Parameter =	9 BEGIN
SET @Value =	(
				SELECT LTRIM(RTRIM(ppc.Value)) FROM Pr_PripyatConstants AS ppc WHERE ppc.Name = 'DivisionPrefix'
				)
END
RETURN @Value
END

GO
GRANT EXECUTE ON Pr_fnsGetConstants TO KvzWorker
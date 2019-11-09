IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetConstants' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetConstants
GO
--
CREATE FUNCTION Pr_fnsGetConstants
(
@Parameter	INT		= 0,	--	полное наименование организации 
/*					= 1		--  сокращенное наименование организации 	
					= 2		--  адрес участка для сверки
								@View = 0 -- Адрес 
								@View = 1 -- Адрес и телефон (г.Лесосибирск ул Горького 116 Б т. 8(39145)6-16-28 , 8(39145)6-09-45  c 17.00 до 8.00 автоответчик )
					= 3		--  номера толефонов
					= 4		--  email
					= 5		--  преффикс подразделения (010/5-022)
					= 6     --  0 - городская база; 1 - сельская база
					= 7		--  Уведомления: Название должности
					= 8		--	Участок: Руководитель
					= 9 	-- 	преффикс лицевых по базе (131)
*/
@View		INT     = 0		--	параметр представления значения
) 
RETURNS VARCHAR(MAX)

AS

BEGIN
DECLARE @Value VARCHAR(MAX)
--(Лесосибирское МРО ПАО  "Красноярскэнергосбыт")
IF @Parameter =	0 BEGIN
SET @Value =	(
				SELECT	LTRIM(RTRIM(value)) AS DivisionName
				FROM	Constants
				WHERE	(Name = 'DivisionName')
				)
END

--(ЛМРО ПАО  "Красноярскэнергосбыт")
IF @Parameter =	1 BEGIN
SET @Value =	(
				SELECT	LTRIM(RTRIM(value)) AS NameOrganisation
				FROM	Constants
				WHERE	(Name = 'NameOrganisation')
				)
END

IF @Parameter =	2 BEGIN
	--(г.Лесосибирск ул Горького 116 Б)
	IF @View = 0 BEGIN
		SET @Value =	(
						SELECT	LTRIM(RTRIM(value)) AS OrganizationAddress
						FROM	Constants
						WHERE	(Name = 'OrganizationAddress')
						)
	END
	--(г.Лесосибирск ул Горького 116 Б т. 8(39145)6-16-28 , 8(39145)6-09-45  c 17.00 до 8.00 автоответчик)
	IF @View = 1 BEGIN	
		SET @Value =	(
						(SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='OrganizationAddress')+' т. '+
						(SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='OrganizationPhone')
						)
	END
END

--(8(39145)6-16-28 , 8(39145)6-09-45  c 17.00 до 8.00 автоответчик)
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

--0 - городская база; 1 - сельская база
IF @Parameter =	6 BEGIN
SET @Value =	(
				SELECT Value FROM Pr_PripyatConstants WHERE Name = 'CityOrVillages'
				)
END

-- Уведомления: Название должности (Руководитель группы работы с ФЛ)
IF @Parameter =	7 BEGIN
SET @Value =	(
				SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='NameRuleManager'
				)
END

-- Участок: Руководитель (ФИО)
IF @Parameter =	8 BEGIN
SET @Value =	(
				SELECT LTRIM(RTRIM(value)) FROM dbo.constants WHERE NAME='Manager'
				)
END

-- преффикс лицевых по базе (131)
IF @Parameter =	9 BEGIN
SET @Value =	(
				SELECT LTRIM(RTRIM(ppc.Value)) FROM Pr_PripyatConstants AS ppc WHERE ppc.Name = 'DivisionPrefix'
				)
END
RETURN @Value
END

GO
GRANT EXECUTE ON Pr_fnsGetConstants TO KvzWorker
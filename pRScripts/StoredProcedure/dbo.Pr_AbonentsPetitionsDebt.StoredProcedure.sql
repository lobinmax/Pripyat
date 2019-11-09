IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_AbonentsPetitionsDebt' AND type = 'P')
    DROP PROCEDURE dbo.Pr_AbonentsPetitionsDebt
GO

CREATE PROCEDURE [dbo].[Pr_AbonentsPetitionsDebt]
@AbonentId					INT = NULL,				-- ИД абонента
@MemberId					INT = NULL,				-- Идентификатор члена семьи
@DtPeriodStart				SMALLDATETIME = NULL,	-- Период иска Начало
@DtPeriodEnd				SMALLDATETIME = NULL,	-- Период иска Конец
@EnergyTypeId				INT = NULL,				-- Ид типа статьи
@Function					INT= 1					-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
AS

SET NOCOUNT ON				-- Отключить счетчик обработанных строк
SET XACT_ABORT ON			-- Всегда откатывать по ошибке
-- Id текущего пользователя
/*DECLARE @PerformerId INT = (
							SELECT p.PerformerId 
							FROM dbo.Performers p 
							JOIN dbo.Elements e   ON p.PerformerId = e.ElementId 
							WHERE (e.ElemTypeId = 4 AND e.StateId = 10 )
							AND p.Login = SYSTEM_USER
							)*/


-- Выборка
IF @Function = 1 BEGIN			
  return 0
END

-- Новая запись
IF @Function = 2 BEGIN			
  return 0
END

-- Обновление записи
IF @Function = 3 BEGIN			
   return 0
END

-- Удаление записи
IF @Function = 4 BEGIN			
  return 0
END

-- Выборка для бланка Заявления в суд
IF @Function = 5 BEGIN			
SELECT     CONVERT(VARCHAR, Pr_PetitionsDebt.DtPeriodStart, 104) AS DtPeriodStart, CONVERT(VARCHAR, Pr_PetitionsDebt.DtPeriodEnd, 104) AS DtPeriodEnd, 
                      Elements.Num AS AbonNumber, Pr_Members.Surname + ' ' + Pr_Members.Name + ' ' + Pr_Members.Patronymic AS SNP, 
                      REPLACE(CASE WHEN TAddressDict.Areal = ' ' THEN '' ELSE TAddressDict.Areal + ' ' END + CASE WHEN TAddressDict.CityVillage <> 'Лесосибирск' THEN
                       'Лесосибирск ' + TAddressDict.CityVillage ELSE TAddressDict.CityVillage END + ' ' + ISNULL(CASE WHEN StreetTypes.NameShort = 'м-н' THEN '' ELSE
                       StreetTypes.NameShort END, '') 
                      + TAddressDict.Street + ' ' + CASE WHEN Abonents.House = '' THEN '' ELSE ' д.' + Abonents.House END + CASE WHEN Abonents.LetterHouse LIKE '%[^0-9]%'
                       THEN Abonents.LetterHouse ELSE CASE WHEN Abonents.LetterHouse = '' THEN '' ELSE '/' + Abonents.LetterHouse END END + CASE WHEN Abonents.Build
                       = '' THEN '' ELSE '-' + Abonents.Build END + CASE WHEN Abonents.Section = '' THEN '' ELSE ' сек.' + Abonents.Section + ' ' END + CASE WHEN Abonents.Room
                       = '' THEN '' ELSE ' кв.' + Abonents.Room END + CASE WHEN Abonents.LetterRoom LIKE '%[^0-9]%' THEN '' ELSE CASE WHEN Abonents.LetterRoom = ''
                       THEN '' ELSE '-' END END + Abonents.LetterRoom + ISNULL(' ' + LTRIM(RTRIM(RoomTypes.Name)) + ' ' + Abonents.RoomNumber, ''), '  ', ' ') 
                      AS Address, Pr_Members.PlaceOfWork, REPLACE(REPLACE(CONVERT(varchar(20), CAST(Pr_PetitionsDebt.DebtSumm AS money), 1), ',', ' '), '.00', '') 
                      AS DebtSumm, REPLACE(REPLACE(CONVERT(varchar(20), CAST(Pr_PetitionsDebt.GovTax AS money), 1), ',', ' '), '.00', '') AS GovTax, 
                      Pr_JudicialArea.Number, CONVERT(VARCHAR, Pr_Members.PDDateOfBirth, 104) AS PDDateOfBirth

FROM         Abonents INNER JOIN
                      TAddressDict ON TAddressDict.AddressPartId = Abonents.AddressPartId INNER JOIN
                      Pr_PetitionsDebt ON Abonents.AbonentId = Pr_PetitionsDebt.AbonentId INNER JOIN
                      Elements ON Pr_PetitionsDebt.AbonentId = Elements.ElementId INNER JOIN
                      Pr_Members ON Pr_PetitionsDebt.MemberId = Pr_Members.MemberId INNER JOIN
                      Pr_JudicialArea ON Pr_PetitionsDebt.JudicialAreaId = Pr_JudicialArea.JudicialAreaId LEFT OUTER JOIN
                      StreetTypes ON TAddressDict.StreetTypeId = StreetTypes.StreetTypeId LEFT OUTER JOIN
                      RoomTypes ON RoomTypes.RoomTypeId = Abonents.RoomTypeId

WHERE	(Pr_PetitionsDebt.AbonentId = @AbonentId) AND 
		(Pr_PetitionsDebt.MemberId = @MemberId) AND 
		(Pr_PetitionsDebt.EnergyTypeId = @EnergyTypeId) AND 
		(CONVERT(VARCHAR, Pr_PetitionsDebt.DtPeriodStart, 104) = @DtPeriodStart) AND 
		(CONVERT(VARCHAR, Pr_PetitionsDebt.DtPeriodEnd, 104) = @DtPeriodEnd) 
END
GO

GRANT EXECUTE ON dbo.Pr_AbonentsPetitionsDebt TO KvzWorker

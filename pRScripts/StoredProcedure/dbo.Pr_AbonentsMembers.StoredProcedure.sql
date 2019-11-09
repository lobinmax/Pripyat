IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_AbonentsMembers' AND type = 'P')
    DROP PROCEDURE dbo.Pr_AbonentsMembers
GO

CREATE PROCEDURE [dbo].[Pr_AbonentsMembers] 

@AbonentId			INT = NULL,				-- ИД абонента
@MemberId			INT= NULL,				-- Идентификатор члена семьи
@Surname			VARCHAR(50)= NULL,		-- Фамилия
@Name				VARCHAR(50)= NULL,		-- Имя
@Patronymic			VARCHAR(50)= NULL,		-- Отчество
@SexMembersId		TINYINT= NULL,			-- Пол
@Residence			VARCHAR(100)= NULL,		-- Адрес прописки
@DtResidence		DATE= NULL,				-- Дата прописки
@DtUnResidence		DATE= NULL,				-- Дата выписки
@FamilyRoleId		TINYINT= NULL,			-- ИД роли члена семьи
@ShareOwner			BIT= NULL,				-- В доле или нет
@PDDATEOfBirth		DATE= NULL,				-- ПД Дата рождения
@PDSeries			NVARCHAR(4)= NULL,		-- ПД Серия
@PDNumber			NVARCHAR(6)= NULL,		-- ПД Номер
@PDDATEOfIssue		DATE= NULL,				-- ПД Дата выдачи
@PDSubunit			VARCHAR(200)= NULL,		-- ПД Кем выдан
@PDSubunitCode		VARCHAR(7)= NULL,		-- ПД Код подразделения
@PDString			VARCHAR(300)= NULL,		-- Паспортные данные одной строкой
@Phone				CHAR(20)= NULL,			-- Телефон члена семьи
@Email				VARCHAR(50)= NULL,		-- Эл. почта абонента
@AddressOfLive		VARCHAR(200)= NULL,		-- Адрес проживания
@PlaceOfWork		VARCHAR(60)= NULL,		-- Место работы
--@DtCreate			SMALLdateTIME= NULL,	-- Дата создания записи
--@DtUpDATE			SMALLdateTIME,			-- Дата обновления записи
--@CreatePerformerId	INT= NULL,				-- ИД создателя
--@UpDATEPerformerIdINT,					-- ИД обтовлятора
@Note				VARCHAR(300)= NULL,		-- Пометки
@Function			INT= 1					-- 1 - SELECT
											-- 2 - INSERT
											-- 3 - UPDATE
											-- 4 - DELETE
AS

SET NOCOUNT ON				-- Отключить счетчик обработанных строк
SET XACT_ABORT ON			-- Всегда откатывать по ошибке

DECLARE @PerformerId INT	-- Id текущего пользовате

  SELECT @PerformerId = p.PerformerId 
  FROM dbo.Performers p 
  JOIN dbo.Elements e   ON p.PerformerId = e.ElementId 
  WHERE (e.ElemTypeId = 4 AND e.StateId = 10 )
  AND p.Login = SYSTEM_USER


IF @Function = 1 BEGIN			-- Выборка
  SELECT    vPr_Member.*
  FROM      vPr_Member
  WHERE     AbonentId = @AbonentId
  END

IF @Function = 2 BEGIN			-- Новая запись
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

IF @Function = 3 BEGIN			-- Обновление записи
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

IF @Function = 4 BEGIN			-- Удаление записи
  DELETE Pr_Members WHERE MemberId = @MemberId
END

IF @Function = 5 BEGIN			-- Выборка ФИО членов семьи по данным ПК Квазар
  SELECT     FamilyMemberId, FullName
  FROM       vFamilyMembers
  WHERE      AbonentId = @AbonentId        
END 

IF @Function = 6 BEGIN			-- Выборка ФИО членов семьи 
  SELECT	SurName,			-- с полной информацией по данным ПК Квазар
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

  IF @Function = 7 BEGIN		-- Выборка ФИО членов семьи по данным ПК Припять
SELECT     MemberId, Surname + ' ' + Name + ' ' + Patronymic AS FullName
FROM         Pr_Members
WHERE     (AbonentId = @AbonentId)
  END
GO

GRANT EXECUTE ON dbo.Pr_AbonentsMembers TO KvzWorker

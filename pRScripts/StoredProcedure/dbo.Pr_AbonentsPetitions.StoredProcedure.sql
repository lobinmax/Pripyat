IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_AbonentsPetitions' AND type = 'P')
    DROP PROCEDURE dbo.Pr_AbonentsPetitions
GO

CREATE PROCEDURE [dbo].[Pr_AbonentsPetitions]
@AbonentId					INT = NULL,				-- ИД абонента
@MemberId					INT = NULL,				-- Идентификатор члена семьи
@DtPeriodStart				SMALLDATETIME = NULL,	-- Период иска Начало
@DtPeriodEnd				SMALLDATETIME = NULL,	-- Период иска Конец
@EnergyTypeId				INT = NULL,				-- Ид типа статьи
@SerialNumberPetit			INT = NULL,				-- Номер ИП п/п
@CopPerformerId				INT = NULL,				-- Ид пристава
@ExecutiveNumber			VARCHAR(15) = NULL,		-- Номер ИП
@ExcitementDt				DATE = NULL,			-- Дата возбуждения ИП
@DebtSumm					NUMERIC(10, 2) = NULL,	-- Сумма на исполнении
@DtActImpossibleRecovery	SMALLDATETIME = NULL,	-- Дата акта о НВ
@ActImpossibleRecoveryId	INT = NULL,				-- Ид причины акта о НВ
@DtCompletion				DATE = NULL,			-- Дата окончания ИП
@Note						VARCHAR(300) = NULL,	-- Комментарий к ИП
@Function					INT= 1					-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
AS

SET NOCOUNT ON				-- Отключить счетчик обработанных строк
SET XACT_ABORT ON			-- Всегда откатывать по ошибке
-- Id текущего пользователя
DECLARE @PerformerId INT = (
							SELECT p.PerformerId 
							FROM dbo.Performers p 
							JOIN dbo.Elements e   ON p.PerformerId = e.ElementId 
							WHERE (e.ElemTypeId = 4 AND e.StateId = 10 )
							AND p.Login = SYSTEM_USER
							)


IF @Function = 1 BEGIN			-- Выборка
  SELECT     *
  FROM         vPr_Petitions
  WHERE     (AbonentId = @AbonentId) AND 
			(MemberId = @MemberId) AND 
			(DtPeriodStart = @DtPeriodStart) AND 
			(DtPeriodEnd = @DtPeriodEnd) AND 
			(EnergyTypeId = @EnergyTypeId)
  END

IF @Function = 2 BEGIN			-- Новая запись
--	К количеству записей по иску прибавляем 1
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

IF @Function = 3 BEGIN			-- Обновление записи
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

IF @Function = 4 BEGIN			-- Удаление записи
  DELETE FROM Pr_Petitions
  WHERE     (AbonentId = @AbonentId) AND 
			(MemberId = @MemberId) AND 
			(DtPeriodStart = @DtPeriodStart) AND 
			(DtPeriodEnd = @DtPeriodEnd) AND 
			(EnergyTypeId = @EnergyTypeId) AND 
			(SerialNumberPetit = @SerialNumberPetit)
-- После удаления зиписи смещаем порядковые номера МИП
DECLARE	@SerialNumber	CHAR(5) -- новый порядковый номер
DECLARE	iCursor			CURSOR	-- Курсор
 
FOR -- Курсор для селекта
	-- Выбираем все записи где порядковый номер 
	-- больше номера п/п удаленной записи
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
  	       -- у каждой записи уменьшаем номер п/п на 1
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

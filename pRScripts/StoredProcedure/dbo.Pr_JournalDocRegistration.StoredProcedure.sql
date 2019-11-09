IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_JournalDocRegistration' AND type = 'P')
    DROP PROCEDURE Pr_JournalDocRegistration
GO
CREATE PROCEDURE dbo.Pr_JournalDocRegistration
	/*
	=============================================	
	|	Процедура регистрации документов журнал	|
	=============================================
	*/
	@DocId				INT				= NULL,		-- Ид строки для получения последней записи
	@CodJournalId		VARCHAR(10)		= NULL,		-- Код журнала хранения
	@CodJournalDocsId	VARCHAR(10)		= NULL,		-- Код документа хранимого в журнале
	@JournalNumber		INT				= NULL,		-- Номер журнала хранения
	@DocNumber			INT				= NULL,		-- Регистрационный номер в журнале
	@DocumentTypeId		INT				= NULL,		-- Тип документа
	@SessionId			INT				= NULL,		-- Ид сеанса печати
	@DtDocument			SMALLDATETIME	= NULL,		-- Регистрационная д ата документа
	@AbonentId			INT				= NULL,		-- Ид абонента
	@FamilyMemberId		INT				= NULL,		-- Ид члена семьи
	@AbonentNumber		VARCHAR(20)		= NULL,		-- Номер абонента
	@SNP_short			VARCHAR(100)	= NULL,		-- ФИО абонента
	@AddressString		VARCHAR(200)	= NULL,		-- Адрес абонента
	@SumDoc				NUMERIC(10, 2)	= NULL,		-- Сумма документа
	@ControllerId		INT				= NULL,		-- ИД владельца участка
	@AuthorId			INT				= NULL,		-- Автор записи в журнале
	@PeriodNumber		INT				= NULL,		-- Кол- во периодов ДЗ на момент регистрации
	@DtDoc				SMALLDATETIME	= NULL,		-- Планируемая дата события по документу
	@DtBeginOio			SMALLDATETIME	= NULL,		-- Дата начала истории ДЗ
	@Function			INT				= 1,		-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
	@Parameter   		INT 			= 1			-- 1 - получение информации по номеру абонента
													-- 2 - получение информации по Ид документа

AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Message VARCHAR(MAX) -- хранение сообщений для пользователя

-- Получаем информацию для регистрации документа
IF @Function = 1 BEGIN
	-- по номеру абонента
	IF @Parameter = 1 BEGIN 
		SELECT @AbonentId = e.ElementId FROM Elements e WHERE e.Num = @AbonentNumber AND e.StateId = 1
		SELECT @DtBeginOio = MAX(oa.DtBeginOio) FROM OioAbonents oa WHERE oa.AbonentId = @AbonentId
		-- Абонент не найден
		IF @AbonentId IS NULL BEGIN
			SET @Message =	'Абонент с номером [' + @AbonentNumber + '] в базе данных [' + DB_NAME() + '] не найден!'
			RAISERROR(@Message , 12, 1)
			RETURN
		END
		-- Нет истории ДЗ
		IF @DtBeginOio IS NULL BEGIN
			SET @Message =	'У потребителя отсутствует история ДЗ!' + CHAR(10) + 
							'Документ не может быть зарегистрирован!'
			RAISERROR(@Message , 12, 1)
			RETURN
		END
		-- определяем плановую дату события ДЗ
		SELECT @DtDoc = oe.DtPlane FROM OioEvents oe WHERE oe.AbonentId = @AbonentId AND oe.DtBeginOio = @DtBeginOio AND oe.EventTypeId = @DocumentTypeId
	
		-- Выбираем информацию по абоненту
		SELECT        	a.AbonentId, 
						f.FamilyMemberId, 
						e.Num AS AbonentNumber, 
						ISNULL(dbo.Pr_fnsGetShortFNS(f.SurName + ' ' + f.Name + ' ' + f.Patronymic, 0, 0), 'Собственник не определён') AS SNP_short, 
	                    a.CommAddressString AS AddressString, 
						a.ControllerId,
						@DtDoc AS DtDoc,
						@DtBeginOio AS DtBeginOio
		FROM            vAbonents AS a 
		INNER JOIN		Elements AS e ON a.AbonentId = e.ElementId 
		LEFT OUTER JOIN	FamilyMembers AS f ON a.AbonentId = f.AbonentId AND f.FamilyRoleId = 1
		WHERE 			a.AbonentId = @AbonentId
	END
	-- по ИД документа
	IF @Parameter = 2 BEGIN
		SELECT 		CONVERT(VARCHAR, j.DtDocument, 104) + ' г.' AS DtDoc,
	   				CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + CAST(j.CodJournalDocsId AS VARCHAR) + '-' + CAST(j.DocNumber AS VARCHAR) AS Number,
	   				j.AbonentNumber,
	   				j.SNP_short,
	   				j.AddressString,
	   				j.SumDoc,
	   				dbo.Pr_fnsGetShortFNS('', j.AuthorId, 1) AS Author,
	   				t.Name AS DocumentsType
		FROM 		dbo.Pr_JournalDocs4_05 j
		INNER JOIN 	dbo.Pr_JournalDocumentsType t ON j.CodJournalDocsId = t.CodJournalId
		WHERE 		j.DocId = @DocId
	END
END

-- Регистрация документа
IF @Function = 2 BEGIN
	BEGIN TRANSACTION 
	/*	Определяем по типу документа 
		необходимый журнал для хранения и 
		регистрационный преффикс документа	*/
	SET @CodJournalId		=	(SELECT ParentCodJournalId		FROM Pr_JournaTypeDocs WHERE DocumentTypeId = @DocumentTypeId)					
	SET @CodJournalDocsId	=	(SELECT CodJournalId			FROM Pr_JournaTypeDocs WHERE DocumentTypeId = @DocumentTypeId)

	/*	проверяем найден ли подходящий журнал для хранения
		регистрируемого документа	*/
		 IF @CodJournalId IS NULL BEGIN
			SET @Message =	'Не найден подходящий журнал для хранения данного типа документа!' + CHAR(10) + 
							'Установите для него соответствующее место хранения в Справочниках!'
			RAISERROR(@Message, 12, 1)
			COMMIT TRANSACTION
			RETURN 0
		END


	/*	Проверяем наличие нужного журнала в состоянии активен
		если нету создаем, так же проверяем в журнале 
		год максимальной даты регистрации
		если не совпадает с текущим, тоже создаем новый журнал	*/
	IF	(
		SELECT	CodJournalId
		FROM	Pr_JournalBooks
		WHERE	CodJournalId = @CodJournalId AND JournalStatusId = 1
		) IS NULL	OR (
						SELECT	MAX(YEAR(DtDocument)) AS MaxYearDocs
						FROM	Pr_JournalDocs4_05 AS j WHERE j.CodJournalId = @CodJournalId
						) != YEAR(GETDATE()) BEGIN
	-- Создание журнала
	DECLARE @NewJournalYear		VARCHAR(100)	= (SELECT CAST(YEAR(GETDATE()) AS varchar) + ' год. Журнал создан автоматически.' AS y)
	EXEC Pr_Journals_Functions 
							@CodJournalId = @CodJournalId, 
							@Notes = @NewJournalYear, 
							@Function = 2 -- создание журнала 
	END
	/*	Регистрируем документ
		-- получаем данные журнала - хранилища	*/
		-- код журнала
	SET @CodJournalId	=	(
							SELECT	CodJournalId
							FROM	Pr_JournalBooks
							WHERE	CodJournalId = @CodJournalId AND 
									JournalStatusId = 1 AND 
									JournalNumber = ( 
													SELECT	MAX(JournalNumber)
													FROM	Pr_JournalBooks											
													WHERE	CodJournalId = @CodJournalId AND JournalStatusId = 1
													)
							)	
		-- номер журнала
		-- макс. номер журнала с открытым статусом									
	SET @JournalNumber	=	(
							SELECT	JournalNumber
							FROM	Pr_JournalBooks
							WHERE	CodJournalId = @CodJournalId AND 
									JournalStatusId = 1 AND 
									JournalNumber = ( 
													SELECT	MAX(JournalNumber)
													FROM	Pr_JournalBooks											
													WHERE	CodJournalId = @CodJournalId AND JournalStatusId = 1
													)
							)

		-- максимальный номер в журнале за год по типу журнала
	SET @DocNumber =	(
						SELECT	ISNULL(MAX(DocNumber), 0) + 1 AS Count
						FROM	Pr_JournalDocs4_05
						WHERE	CodJournalId = @CodJournalId AND 
								JournalNumber = @JournalNumber AND 
								YEAR(DtDocument) = YEAR(GETDATE())
						)

		-- вставляем запись в журжал
	INSERT INTO Pr_JournalDocs4_05	(
									CodJournalId,
									CodJournalDocsId, 
									JournalNumber, 
									DocNumber,
									SessionId, 
									DtDocument, 
									AbonentId,
									FamilyMemberId, 
									AbonentNumber, 
									SNP_short, 
									AddressString, 
									SumDoc, 
									DocumentTypeId, 
									ControllerId, 
									PeriodNumber, 
									DtDoc, 
									DtBeginOio,
									AuthorId
									)
	VALUES	(
			@CodJournalId,
			@CodJournalDocsId,
			@JournalNumber,
			@DocNumber,
			@SessionId,
			GETDATE(),
			@AbonentId,
			@FamilyMemberId,
			@AbonentNumber,
			@SNP_short,
			@AddressString,
			@SumDoc,
			@DocumentTypeId,
			@ControllerId,
			YEAR(GETDATE()) * 100 + MONTH(GETDATE()),
			@DtDoc,
			@DtBeginOio,
			dbo.Kernel_GetPerformer()
			)

	-- по Id последней записи возвращаем регистрационный номер
	-- уведомления
	SELECT	DocId,
			CONVERT(VARCHAR, DtDocument, 104) AS DtDocument, 
			CAST(dbo.Pr_fnsGetConstants(5,0) AS VARCHAR) + '-' + CAST(CodJournalDocsId AS VARCHAR) + '-' + CAST(DocNumber AS VARCHAR) AS DocNumber 
	FROM	Pr_JournalDocs4_05 
	WHERE	DocId = @@identity 

COMMIT TRANSACTION
END 

-- Удаление регистрационной записи
IF @Function = 4 BEGIN
	DELETE FROM Pr_JournalDocs4_05 WHERE DocId = @DocId
END
GO
GRANT EXECUTE ON Pr_JournalDocRegistration TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_JournalTaskRegistration' AND type = 'P')
    DROP PROCEDURE Pr_JournalTaskRegistration
GO
CREATE PROCEDURE dbo.Pr_JournalTaskRegistration
	/*
	=================================================	
	|	Процедура регистрации листов выдачи заданий	|
	|	и прочие манипуляции с ними					|
	=================================================
													*/
	@TaskSheetId		INT				= NULL,		-- Ид листа задания
	@CodJournalId		VARCHAR(10)		= NULL,		-- Код журнала хранения
	@CodJournalDocsId	VARCHAR(10)		= NULL,		-- Код документа хранимого в журнале
	@JournalNumber		INT				= NULL,		-- Номер журнала хранения
	@DocNumber			INT				= NULL,		-- Регистрационный номер в журнале
	@DocumentTypeId		INT				= NULL,		-- Тип документа
	@DtPerformance		SMALLDATETIME	= NULL,		-- Дата исполнения задания
	@SessionId			VARCHAR(500)	= NULL,		-- Сеансы печати попадающие в лист задания
	@PerformerId		VARCHAR(500)	= NULL,		-- Дополнительные исполнители задания

	@Function			INT				= NULL,		-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
	@Parameter			INT				= NULL			-- Для @Function = 1
															--- 0: Выборка перечння лицевых листа задания
															--- 1: Выборка исполнителей и выдавшего задания
															--- 2: Выборка перечня листов заданий по которым имеются не врученные уведомления
															--- 3: Выборка не врученных уведомлений
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Message			VARCHAR(512)	-- хранение сообщений для пользователя
DECLARE @NewTaskSheetId		INT				-- Ид нового листа задания
--DECLARE @InsTaskSheetId		VARCHAR(512)	-- Процедура привязки сеансов печати клисту задания

-- Выборка для отчета
IF @Function = 1 BEGIN

	--- 1: Выборка перечння лицевых листа задания (в FastReport)
	IF @Parameter = 0 BEGIN
		SELECT			CAST(dbo.Pr_fnsGetConstants(5, 0) AS VARCHAR) + '-' + CAST(j.CodJournalDocsId AS VARCHAR) + '-' + CAST(j.DocNumber AS VARCHAR) AS DocNumber, 
						CONVERT(varchar, j.DtDocument, 104) AS DtDocument, 
						e.Num AS AbonNumber, 
						j.SNP_short, 
						j.AddressString, 
						j.SumDoc, 
						cp.GroupName, 
						et.prEventNameShort, 
						CASE 
							WHEN	a.PhoneProfiles IS NULL AND 
									a.PhoneMobileProfiles IS NULL OR
									a.PhoneProfiles != '' AND 
									a.PhoneMobileProfiles != '' THEN 
								0 
							ELSE 
								1 
							END AS aProfiles
		FROM			vPr_OioEventsTypes AS et 
		INNER JOIN		Pr_JournalDocs4_05 AS j 
		INNER JOIN		Pr_OioPrintSessions AS s ON j.SessionId = s.SessionId 
		INNER JOIN		Elements AS e ON j.AbonentId = e.ElementId 
		INNER JOIN		vAbonents AS a ON j.AbonentId = a.AbonentId ON et.KVZ_EventTypeId = j.DocumentTypeId AND et.prHouseTypeId = a.HousingOptionId 
		LEFT OUTER JOIN	Pr_OioCounterPeriod AS cp 
		INNER JOIN		Pr_OioCountMonthAbonent AS p ON	cp.CountMin <= p.CountMonth AND 
													cp.CountMax >= p.CountMonth ON 
													j.AbonentId = p.AbonentId AND 
													YEAR(j.DtDocument) * 100 + (MONTH(j.DtDocument) - CASE WHEN MONTH(j.DtDocument) = 1 THEN 89 ELSE 1 END) = p.PeriodNumber
		WHERE			s.TaskSheetId = @TaskSheetId
		ORDER BY		DocNumber
	END

	--- 1: Выборка исполнителей и выдавшего задания
	IF @Parameter = 1 BEGIN
		SELECT				'Задание получил' AS IsTaked, 
							CASE -- если Прудников В
								WHEN PerformerId = -1424533615 THEN 
									'Электромонтер ' 
								ELSE 
									'Контролер 2 разряда ' 
								END + dbo.Pr_fnsGetShortFNS('', PerformerId, 1) AS PerformerName
		FROM				Pr_JournalTaskSheetPerformers
		WHERE				TaskSheetId = @TaskSheetId
		UNION ALL
		SELECT DISTINCT		'Задание выдал' AS IsGived, 
							'Контролер 3 разряда ' + dbo.Pr_fnsGetShortFNS('', ts.AuthorId, 1) AS AuthorName
		FROM				Pr_JournalTaskSheets AS ts 
		LEFT OUTER JOIN		Pr_OioPrintSessions AS ps ON ts.TaskSheetId = ps.TaskSheetId
		WHERE				ts.TaskSheetId = @TaskSheetId
	END

	--- 2: Выборка даты, номера и наименования отчета
	IF @Parameter = 2 BEGIN
		SELECT		'№ ' + dbo.Pr_fnsGetConstants(5, 0) + 
					'-' + CodJournalDocsId + 
					'-' + CAST(DocNumber AS VARCHAR) + 
					' от ' + CONVERT(varchar, DtDocument, 104) + 
					' г.' AS DateNumber, 

					'Лист выдачи задания на ' + CONVERT(varchar, DtPerformance, 104) + ' г.' AS ReportTitle
		FROM		Pr_JournalTaskSheets AS jTS
		WHERE		TaskSheetId = @TaskSheetId
	END

	--- 3: Выборка не врученных уведомлений за текущий месяц с первого числа
	IF @Parameter = 3 BEGIN
		SELECT			'Лист - задание на ' + CONVERT(varchar, jTS.DtPerformance, 104) + 
						' г. (№ ' + dbo.Pr_fnsGetConstants(5, 0) + 
						'-' + jTS.CodJournalDocsId + 
						'-' + CAST(jTS.DocNumber AS VARCHAR) + 
						' от ' + CONVERT(varchar, jTS.DtDocument, 104) + 'г.)' + CHAR(10) + 
						'Выдавший: ' + dbo.Pr_fnsGetShortFNS('', jTS.AuthorId, 1) + 
						'| Исполнитель: ' + dbo.Pr_fnsGetShortFNS('', jTSP.PerformerId, 1) AS TashSheetName_h,
						 
						jTS.DtPerformance AS DtPerformance_h, 
						dbo.Pr_fnsGetShortFNS('', jTSP.PerformerId, 1) AS PerformerName_h,
						 
						dbo.Pr_fnsGetConstants(5, 0) + 
						'-' + jd.CodJournalDocsId + 
						'-' + CAST(jd.DocNumber AS VARCHAR) AS DocNumber_h, 
						
						jd.AbonentNumber AS AbonentNumber_h, 
						jd.SNP_short AS SNP_short_h, 
						jd.AddressString AS AddressString_h, 
						jd.SumDoc AS SumDoc_h, 
						cp.GroupName AS GroupName_h, 
						vPr_OioEventsTypes.prEventNameShort AS prEventNameShort_h,
						CASE 
							WHEN	a.PhoneProfiles IS NULL AND	
									a.PhoneMobileProfiles IS NULL OR
									a.PhoneProfiles != '' AND 
									a.PhoneMobileProfiles != '' THEN 
								0 
							ELSE 
								1 
							END AS aProfiles_h
		FROM			Pr_JournalTaskSheetPerformers AS jTSP 
		INNER JOIN		Pr_JournalTaskSheets AS jTS ON	jTSP.TaskSheetId = jTS.TaskSheetId AND 
														jTS.DtPerformance >= dbo.fnsGetFirstDayOfMonth
						(
							(
								SELECT		DtPerformance
								FROM		Pr_JournalTaskSheets
								WHERE		TaskSheetId = @TaskSheetId
							)
						) AND jTS.DtPerformance <
												(
													SELECT			DtPerformance
													FROM            Pr_JournalTaskSheets
													WHERE			TaskSheetId = @TaskSheetId
												) 
		INNER JOIN		Pr_OioPrintSessions AS ps ON jTS.TaskSheetId = ps.TaskSheetId 
		INNER JOIN		Pr_JournalDocs4_05 AS jd ON ps.SessionId = jd.SessionId 
		INNER JOIN		Pr_OioCounterPeriod AS cp 
		INNER JOIN		Pr_OioCountMonthAbonent AS p ON p.CountMonth >= cp.CountMin AND 
														p.CountMonth <= cp.CountMax ON 
														jd.AbonentId = p.AbonentId AND 
														YEAR(jd.DtDocument) * 100 + (MONTH(jd.DtDocument) - CASE WHEN MONTH(jd.DtDocument) = 1 THEN 89 ELSE 1 END) = p.PeriodNumber 
		INNER JOIN		Abonents AS a ON jd.AbonentId = a.AbonentId 
		INNER JOIN		vPr_OioEventsTypes ON jd.DocumentTypeId = vPr_OioEventsTypes.KVZ_EventTypeId AND a.HousingOptionId = vPr_OioEventsTypes.prHouseTypeId
		WHERE			(
						NOT (
							CASE 
								WHEN dbo.Pr_fsnOiOGetNextEventType(jd.AbonentId) != jd.DocumentTypeId THEN 
									NULL 
								ELSE 
									dbo.Pr_fsnOiOGetNextEventType(jd.AbonentId) 
								END IS NULL
							)
						) AND	(
								jTSP.PerformerId IN (
													SELECT		PerformerId
													FROM		Pr_JournalTaskSheetPerformers AS Pr_jTSP
													WHERE		TaskSheetId = @TaskSheetId
													)
								) AND jd.DocumentTypeId < 8
		ORDER BY PerformerName_h, DtPerformance_h
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
	
				/*	Проверяем не привязан ли к выбранным сеансам печати
					уже лист выдачи задания								*/
				-- временная таблица для прогона курсора
				CREATE TABLE #tTaskSheet	(
											TaskSheetId INT,
											AuthorId	INT
											)
				INSERT INTO #tTaskSheet 
				SELECT TaskSheetId, AuthorId FROM Pr_OioPrintSessions WHERE SessionId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@SessionId, ',') AS pgtfs)
				--EXEC ('SELECT TaskSheetId, AuthorId FROM Pr_OioPrintSessions WHERE SessionId IN (' + @SessionId + ')')
				
				DECLARE	@CurTaskSheetId		INT			-- переменная для хранения листа задания
				DECLARE	@CurAuthorId		INT			-- переменная для хранения автора задания
				DECLARE	@RepAuthorId		INT			-- переменная для сравнения автора задания
				DECLARE	@CurPerformerId		INT			-- переменная для хранения исполнителя задания
				DECLARE	@RepPerformerId		INT			-- переменная для сравнения исполнителя задания
				DECLARE	@iCounter			INT = 0		-- кол-во привязанных сеансов печати
				DECLARE	@iRowCount			INT = 0		-- номер строки курсора

				-- курсор для..
				DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
					SELECT * FROM #tTaskSheet

				OPEN  iCursor
				-- открываем строку курсора
				FETCH NEXT FROM iCursor INTO @CurTaskSheetId, @CurAuthorId
				-- пока есть след строка
					WHILE @@FETCH_STATUS = 0   
						BEGIN 
						-- если это первая строка курсора
							IF @iRowCount = 0 BEGIN 
								SET @RepAuthorId = @CurAuthorId
								SET @RepPerformerId = @CurPerformerId
							END
						-- перебираем сеансы печати 
							-- если лист задания уже назначен
							IF @CurTaskSheetId IS NOT NULL OR @CurTaskSheetId != '' BEGIN
								SET @Message =	'Для ' + CAST(@iCounter AS VARCHAR) + ' сеансов печати уже назначен лист задания!'
								RAISERROR(@Message, 12, 1)
								COMMIT TRANSACTION
								CLOSE iCursor
								DEALLOCATE iCursor
								RETURN 0
							END
						-- проверяем на повтор авторов
							IF @RepAuthorId != @CurAuthorId BEGIN
								SET @Message =	'Выбранные сеансы печати имеют разных авторов!'
								RAISERROR(@Message, 12, 1)
								COMMIT TRANSACTION
								CLOSE iCursor
								DEALLOCATE iCursor
								RETURN 0
							END
						-- проверяем на повтор исполнителей
						/*	IF @RepPerformerId != @CurPerformerId BEGIN
								SET @Message =	'Выбранные сеансы печати имеют разных исполнителей!'
								RAISERROR(@Message, 12, 1)
								COMMIT TRANSACTION
								CLOSE iCursor
								DEALLOCATE iCursor
								RETURN 0
							END
							SET @iRowCount = @iRowCount + 1 */
				-- след строка курсора	
				FETCH NEXT FROM iCursor INTO @CurTaskSheetId, @CurAuthorId
				END  
				CLOSE iCursor
				DEALLOCATE iCursor

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
		) IS NULL OR		(
						SELECT	MAX(YEAR(DtDocument)) AS MaxYearDocs
						FROM	Pr_JournalTaskSheets AS j
						) != (YEAR(GETDATE())) BEGIN
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
						FROM	Pr_JournalTaskSheets
						WHERE	CodJournalId = @CodJournalId AND 
								JournalNumber = @JournalNumber AND 
								YEAR(DtDocument) = YEAR(GETDATE())
						)
		-- вставляем запись в журжал
	INSERT INTO		Pr_JournalTaskSheets(
										CodJournalId, 
										CodJournalDocsId, 
										JournalNumber, 
										DocNumber,
										DtDocument, 
										DtPerformance, 
										AuthorId
										)
	VALUES	(
			@CodJournalId,
			@CodJournalDocsId,
			@JournalNumber,
			@DocNumber,
			GETDATE(),
			@DtPerformance,
			dbo.Kernel_GetPerformer()
			)

		-- Записывае Ид нового листа задания
				SET @NewTaskSheetId = (SELECT @@identity FROM Pr_JournalTaskSheets WHERE TaskSheetId = @@identity)

		-- Привязываем новый лист задания к выбранным сеансам печати
				UPDATE Pr_OioPrintSessions SET TaskSheetId = CAST(@NewTaskSheetId AS VARCHAR) WHERE SessionId IN(SELECT * FROM dbo.Pr_fntGetTableFromString(@SessionId, ',') AS pgtfs)
				--SET @InsTaskSheetId = 'UPDATE Pr_OioPrintSessions SET TaskSheetId = ' + CAST(@NewTaskSheetId AS VARCHAR) + ' WHERE SessionId IN(' + @SessionId + ')'
				--EXEC (@InsTaskSheetId)
				
		-- Првязываем выбранных исполнителей к новому листу задания
		IF (@PerformerId != '') BEGIN
			DECLARE @t TABLE (name VARCHAR(500))
			INSERT INTO @t
			SELECT @PerformerId 

			INSERT INTO Pr_JournalTaskSheetPerformers  
			SELECT	@NewTaskSheetId,									-- ИД нового листа задания
					SUBSTRING(name, i2 + 1, i1 - i2 - 1 ) AS name		-- ИД исполнителя задания
			FROM	(
					SELECT t1.name, 
					CHARINDEX( ',', t1.name + ',', number ) i1,
					CASE WHEN number = 0 THEN 0 ELSE CHARINDEX( ',', t1.name + ',', number - 1 ) END i2
					FROM @t AS t1 
					INNER JOIN master.dbo.spt_values AS t2
					  ON t2.type = 'P' AND number BETWEEN 0 AND LEN( t1.name )
					) t WHERE i1 != i2

		END
	-- по Id последней записи возвращаем регистрационный номер
	-- листа выдачи задания
	/*SELECT	CONVERT(VARCHAR, DtDocument, 104) AS DtDocument, 
			CAST(dbo.Pr_fnsGetConstants(5,0) AS VARCHAR) + '-' + CAST(CodJournalDocsId AS VARCHAR) + '-' + CAST(DocNumber AS VARCHAR) AS DocNumber 
	FROM	Pr_JournalTaskSheets 
	WHERE	TaskSheetId = @NewTaskSheetId */

	SELECT	TaskSheetId 
	FROM	Pr_JournalTaskSheets 
	WHERE	TaskSheetId = @NewTaskSheetId 

COMMIT TRANSACTION
END
GO
GRANT EXECUTE ON Pr_JournalTaskRegistration TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_JournalTaskRegistration' AND type = 'P')
    DROP PROCEDURE Pr_JournalTaskRegistration
GO
CREATE PROCEDURE dbo.Pr_JournalTaskRegistration
	/*
	=================================================	
	|	��������� ����������� ������ ������ �������	|
	|	� ������ ����������� � ����					|
	=================================================
													*/
	@TaskSheetId		INT				= NULL,		-- �� ����� �������
	@CodJournalId		VARCHAR(10)		= NULL,		-- ��� ������� ��������
	@CodJournalDocsId	VARCHAR(10)		= NULL,		-- ��� ��������� ��������� � �������
	@JournalNumber		INT				= NULL,		-- ����� ������� ��������
	@DocNumber			INT				= NULL,		-- ��������������� ����� � �������
	@DocumentTypeId		INT				= NULL,		-- ��� ���������
	@DtPerformance		SMALLDATETIME	= NULL,		-- ���� ���������� �������
	@SessionId			VARCHAR(500)	= NULL,		-- ������ ������ ���������� � ���� �������
	@PerformerId		VARCHAR(500)	= NULL,		-- �������������� ����������� �������

	@Function			INT				= NULL,		-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
	@Parameter			INT				= NULL			-- ��� @Function = 1
															--- 0: ������� �������� ������� ����� �������
															--- 1: ������� ������������ � ��������� �������
															--- 2: ������� ������� ������ ������� �� ������� ������� �� ��������� �����������
															--- 3: ������� �� ��������� �����������
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

DECLARE @Message			VARCHAR(512)	-- �������� ��������� ��� ������������
DECLARE @NewTaskSheetId		INT				-- �� ������ ����� �������
--DECLARE @InsTaskSheetId		VARCHAR(512)	-- ��������� �������� ������� ������ ������ �������

-- ������� ��� ������
IF @Function = 1 BEGIN

	--- 1: ������� �������� ������� ����� ������� (� FastReport)
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

	--- 1: ������� ������������ � ��������� �������
	IF @Parameter = 1 BEGIN
		SELECT				'������� �������' AS IsTaked, 
							CASE -- ���� ��������� �
								WHEN PerformerId = -1424533615 THEN 
									'������������� ' 
								ELSE 
									'��������� 2 ������� ' 
								END + dbo.Pr_fnsGetShortFNS('', PerformerId, 1) AS PerformerName
		FROM				Pr_JournalTaskSheetPerformers
		WHERE				TaskSheetId = @TaskSheetId
		UNION ALL
		SELECT DISTINCT		'������� �����' AS IsGived, 
							'��������� 3 ������� ' + dbo.Pr_fnsGetShortFNS('', ts.AuthorId, 1) AS AuthorName
		FROM				Pr_JournalTaskSheets AS ts 
		LEFT OUTER JOIN		Pr_OioPrintSessions AS ps ON ts.TaskSheetId = ps.TaskSheetId
		WHERE				ts.TaskSheetId = @TaskSheetId
	END

	--- 2: ������� ����, ������ � ������������ ������
	IF @Parameter = 2 BEGIN
		SELECT		'� ' + dbo.Pr_fnsGetConstants(5, 0) + 
					'-' + CodJournalDocsId + 
					'-' + CAST(DocNumber AS VARCHAR) + 
					' �� ' + CONVERT(varchar, DtDocument, 104) + 
					' �.' AS DateNumber, 

					'���� ������ ������� �� ' + CONVERT(varchar, DtPerformance, 104) + ' �.' AS ReportTitle
		FROM		Pr_JournalTaskSheets AS jTS
		WHERE		TaskSheetId = @TaskSheetId
	END

	--- 3: ������� �� ��������� ����������� �� ������� ����� � ������� �����
	IF @Parameter = 3 BEGIN
		SELECT			'���� - ������� �� ' + CONVERT(varchar, jTS.DtPerformance, 104) + 
						' �. (� ' + dbo.Pr_fnsGetConstants(5, 0) + 
						'-' + jTS.CodJournalDocsId + 
						'-' + CAST(jTS.DocNumber AS VARCHAR) + 
						' �� ' + CONVERT(varchar, jTS.DtDocument, 104) + '�.)' + CHAR(10) + 
						'��������: ' + dbo.Pr_fnsGetShortFNS('', jTS.AuthorId, 1) + 
						'| �����������: ' + dbo.Pr_fnsGetShortFNS('', jTSP.PerformerId, 1) AS TashSheetName_h,
						 
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

-- ����������� ���������
IF @Function = 2 BEGIN
	BEGIN TRANSACTION 
	/*	���������� �� ���� ��������� 
		����������� ������ ��� �������� � 
		��������������� �������� ���������	*/
	SET @CodJournalId		=	(SELECT ParentCodJournalId		FROM Pr_JournaTypeDocs WHERE DocumentTypeId = @DocumentTypeId)					
	SET @CodJournalDocsId	=	(SELECT CodJournalId			FROM Pr_JournaTypeDocs WHERE DocumentTypeId = @DocumentTypeId)
	
				/*	��������� �� �������� �� � ��������� ������� ������
					��� ���� ������ �������								*/
				-- ��������� ������� ��� ������� �������
				CREATE TABLE #tTaskSheet	(
											TaskSheetId INT,
											AuthorId	INT
											)
				INSERT INTO #tTaskSheet 
				SELECT TaskSheetId, AuthorId FROM Pr_OioPrintSessions WHERE SessionId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@SessionId, ',') AS pgtfs)
				--EXEC ('SELECT TaskSheetId, AuthorId FROM Pr_OioPrintSessions WHERE SessionId IN (' + @SessionId + ')')
				
				DECLARE	@CurTaskSheetId		INT			-- ���������� ��� �������� ����� �������
				DECLARE	@CurAuthorId		INT			-- ���������� ��� �������� ������ �������
				DECLARE	@RepAuthorId		INT			-- ���������� ��� ��������� ������ �������
				DECLARE	@CurPerformerId		INT			-- ���������� ��� �������� ����������� �������
				DECLARE	@RepPerformerId		INT			-- ���������� ��� ��������� ����������� �������
				DECLARE	@iCounter			INT = 0		-- ���-�� ����������� ������� ������
				DECLARE	@iRowCount			INT = 0		-- ����� ������ �������

				-- ������ ���..
				DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
					SELECT * FROM #tTaskSheet

				OPEN  iCursor
				-- ��������� ������ �������
				FETCH NEXT FROM iCursor INTO @CurTaskSheetId, @CurAuthorId
				-- ���� ���� ���� ������
					WHILE @@FETCH_STATUS = 0   
						BEGIN 
						-- ���� ��� ������ ������ �������
							IF @iRowCount = 0 BEGIN 
								SET @RepAuthorId = @CurAuthorId
								SET @RepPerformerId = @CurPerformerId
							END
						-- ���������� ������ ������ 
							-- ���� ���� ������� ��� ��������
							IF @CurTaskSheetId IS NOT NULL OR @CurTaskSheetId != '' BEGIN
								SET @Message =	'��� ' + CAST(@iCounter AS VARCHAR) + ' ������� ������ ��� �������� ���� �������!'
								RAISERROR(@Message, 12, 1)
								COMMIT TRANSACTION
								CLOSE iCursor
								DEALLOCATE iCursor
								RETURN 0
							END
						-- ��������� �� ������ �������
							IF @RepAuthorId != @CurAuthorId BEGIN
								SET @Message =	'��������� ������ ������ ����� ������ �������!'
								RAISERROR(@Message, 12, 1)
								COMMIT TRANSACTION
								CLOSE iCursor
								DEALLOCATE iCursor
								RETURN 0
							END
						-- ��������� �� ������ ������������
						/*	IF @RepPerformerId != @CurPerformerId BEGIN
								SET @Message =	'��������� ������ ������ ����� ������ ������������!'
								RAISERROR(@Message, 12, 1)
								COMMIT TRANSACTION
								CLOSE iCursor
								DEALLOCATE iCursor
								RETURN 0
							END
							SET @iRowCount = @iRowCount + 1 */
				-- ���� ������ �������	
				FETCH NEXT FROM iCursor INTO @CurTaskSheetId, @CurAuthorId
				END  
				CLOSE iCursor
				DEALLOCATE iCursor

	/*	��������� ������ �� ���������� ������ ��� ��������
		��������������� ���������	*/
		IF @CodJournalId IS NULL BEGIN
			SET @Message =	'�� ������ ���������� ������ ��� �������� ������� ���� ���������!' + CHAR(10) + 
							'���������� ��� ���� ��������������� ����� �������� � ������������!'
			RAISERROR(@Message, 12, 1)
			COMMIT TRANSACTION
			RETURN 0
		END


	/*	��������� ������� ������� ������� � ��������� �������
		���� ���� �������, ��� �� ��������� � ������� 
		��� ������������ ���� �����������
		���� �� ��������� � �������, ���� ������� ����� ������	*/
	IF	(
		SELECT	CodJournalId
		FROM	Pr_JournalBooks
		WHERE	CodJournalId = @CodJournalId AND JournalStatusId = 1
		) IS NULL OR		(
						SELECT	MAX(YEAR(DtDocument)) AS MaxYearDocs
						FROM	Pr_JournalTaskSheets AS j
						) != (YEAR(GETDATE())) BEGIN
	-- �������� �������
	DECLARE @NewJournalYear		VARCHAR(100)	= (SELECT CAST(YEAR(GETDATE()) AS varchar) + ' ���. ������ ������ �������������.' AS y)
	EXEC Pr_Journals_Functions 
							@CodJournalId = @CodJournalId, 
							@Notes = @NewJournalYear, 
							@Function = 2 -- �������� ������� 
	END

	/*	������������ ��������
		-- �������� ������ ������� - ���������	*/
		-- ��� �������
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
		-- ����� �������
		-- ����. ����� ������� � �������� ��������									
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

		-- ������������ ����� � ������� �� ��� �� ���� �������
	SET @DocNumber =	(
						SELECT	ISNULL(MAX(DocNumber), 0) + 1 AS Count
						FROM	Pr_JournalTaskSheets
						WHERE	CodJournalId = @CodJournalId AND 
								JournalNumber = @JournalNumber AND 
								YEAR(DtDocument) = YEAR(GETDATE())
						)
		-- ��������� ������ � ������
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

		-- ��������� �� ������ ����� �������
				SET @NewTaskSheetId = (SELECT @@identity FROM Pr_JournalTaskSheets WHERE TaskSheetId = @@identity)

		-- ����������� ����� ���� ������� � ��������� ������� ������
				UPDATE Pr_OioPrintSessions SET TaskSheetId = CAST(@NewTaskSheetId AS VARCHAR) WHERE SessionId IN(SELECT * FROM dbo.Pr_fntGetTableFromString(@SessionId, ',') AS pgtfs)
				--SET @InsTaskSheetId = 'UPDATE Pr_OioPrintSessions SET TaskSheetId = ' + CAST(@NewTaskSheetId AS VARCHAR) + ' WHERE SessionId IN(' + @SessionId + ')'
				--EXEC (@InsTaskSheetId)
				
		-- ���������� ��������� ������������ � ������ ����� �������
		IF (@PerformerId != '') BEGIN
			DECLARE @t TABLE (name VARCHAR(500))
			INSERT INTO @t
			SELECT @PerformerId 

			INSERT INTO Pr_JournalTaskSheetPerformers  
			SELECT	@NewTaskSheetId,									-- �� ������ ����� �������
					SUBSTRING(name, i2 + 1, i1 - i2 - 1 ) AS name		-- �� ����������� �������
			FROM	(
					SELECT t1.name, 
					CHARINDEX( ',', t1.name + ',', number ) i1,
					CASE WHEN number = 0 THEN 0 ELSE CHARINDEX( ',', t1.name + ',', number - 1 ) END i2
					FROM @t AS t1 
					INNER JOIN master.dbo.spt_values AS t2
					  ON t2.type = 'P' AND number BETWEEN 0 AND LEN( t1.name )
					) t WHERE i1 != i2

		END
	-- �� Id ��������� ������ ���������� ��������������� �����
	-- ����� ������ �������
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
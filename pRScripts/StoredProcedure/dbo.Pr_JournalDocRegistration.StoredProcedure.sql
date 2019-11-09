IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_JournalDocRegistration' AND type = 'P')
    DROP PROCEDURE Pr_JournalDocRegistration
GO
CREATE PROCEDURE dbo.Pr_JournalDocRegistration
	/*
	=============================================	
	|	��������� ����������� ���������� ������	|
	=============================================
	*/
	@DocId				INT				= NULL,		-- �� ������ ��� ��������� ��������� ������
	@CodJournalId		VARCHAR(10)		= NULL,		-- ��� ������� ��������
	@CodJournalDocsId	VARCHAR(10)		= NULL,		-- ��� ��������� ��������� � �������
	@JournalNumber		INT				= NULL,		-- ����� ������� ��������
	@DocNumber			INT				= NULL,		-- ��������������� ����� � �������
	@DocumentTypeId		INT				= NULL,		-- ��� ���������
	@SessionId			INT				= NULL,		-- �� ������ ������
	@DtDocument			SMALLDATETIME	= NULL,		-- ��������������� � ��� ���������
	@AbonentId			INT				= NULL,		-- �� ��������
	@FamilyMemberId		INT				= NULL,		-- �� ����� �����
	@AbonentNumber		VARCHAR(20)		= NULL,		-- ����� ��������
	@SNP_short			VARCHAR(100)	= NULL,		-- ��� ��������
	@AddressString		VARCHAR(200)	= NULL,		-- ����� ��������
	@SumDoc				NUMERIC(10, 2)	= NULL,		-- ����� ���������
	@ControllerId		INT				= NULL,		-- �� ��������� �������
	@AuthorId			INT				= NULL,		-- ����� ������ � �������
	@PeriodNumber		INT				= NULL,		-- ���- �� �������� �� �� ������ �����������
	@DtDoc				SMALLDATETIME	= NULL,		-- ����������� ���� ������� �� ���������
	@DtBeginOio			SMALLDATETIME	= NULL,		-- ���� ������ ������� ��
	@Function			INT				= 1,		-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE
	@Parameter   		INT 			= 1			-- 1 - ��������� ���������� �� ������ ��������
													-- 2 - ��������� ���������� �� �� ���������

AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������

DECLARE @Message VARCHAR(MAX) -- �������� ��������� ��� ������������

-- �������� ���������� ��� ����������� ���������
IF @Function = 1 BEGIN
	-- �� ������ ��������
	IF @Parameter = 1 BEGIN 
		SELECT @AbonentId = e.ElementId FROM Elements e WHERE e.Num = @AbonentNumber AND e.StateId = 1
		SELECT @DtBeginOio = MAX(oa.DtBeginOio) FROM OioAbonents oa WHERE oa.AbonentId = @AbonentId
		-- ������� �� ������
		IF @AbonentId IS NULL BEGIN
			SET @Message =	'������� � ������� [' + @AbonentNumber + '] � ���� ������ [' + DB_NAME() + '] �� ������!'
			RAISERROR(@Message , 12, 1)
			RETURN
		END
		-- ��� ������� ��
		IF @DtBeginOio IS NULL BEGIN
			SET @Message =	'� ����������� ����������� ������� ��!' + CHAR(10) + 
							'�������� �� ����� ���� ���������������!'
			RAISERROR(@Message , 12, 1)
			RETURN
		END
		-- ���������� �������� ���� ������� ��
		SELECT @DtDoc = oe.DtPlane FROM OioEvents oe WHERE oe.AbonentId = @AbonentId AND oe.DtBeginOio = @DtBeginOio AND oe.EventTypeId = @DocumentTypeId
	
		-- �������� ���������� �� ��������
		SELECT        	a.AbonentId, 
						f.FamilyMemberId, 
						e.Num AS AbonentNumber, 
						ISNULL(dbo.Pr_fnsGetShortFNS(f.SurName + ' ' + f.Name + ' ' + f.Patronymic, 0, 0), '����������� �� ��������') AS SNP_short, 
	                    a.CommAddressString AS AddressString, 
						a.ControllerId,
						@DtDoc AS DtDoc,
						@DtBeginOio AS DtBeginOio
		FROM            vAbonents AS a 
		INNER JOIN		Elements AS e ON a.AbonentId = e.ElementId 
		LEFT OUTER JOIN	FamilyMembers AS f ON a.AbonentId = f.AbonentId AND f.FamilyRoleId = 1
		WHERE 			a.AbonentId = @AbonentId
	END
	-- �� �� ���������
	IF @Parameter = 2 BEGIN
		SELECT 		CONVERT(VARCHAR, j.DtDocument, 104) + ' �.' AS DtDoc,
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

-- ����������� ���������
IF @Function = 2 BEGIN
	BEGIN TRANSACTION 
	/*	���������� �� ���� ��������� 
		����������� ������ ��� �������� � 
		��������������� �������� ���������	*/
	SET @CodJournalId		=	(SELECT ParentCodJournalId		FROM Pr_JournaTypeDocs WHERE DocumentTypeId = @DocumentTypeId)					
	SET @CodJournalDocsId	=	(SELECT CodJournalId			FROM Pr_JournaTypeDocs WHERE DocumentTypeId = @DocumentTypeId)

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
		) IS NULL	OR (
						SELECT	MAX(YEAR(DtDocument)) AS MaxYearDocs
						FROM	Pr_JournalDocs4_05 AS j WHERE j.CodJournalId = @CodJournalId
						) != YEAR(GETDATE()) BEGIN
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
						FROM	Pr_JournalDocs4_05
						WHERE	CodJournalId = @CodJournalId AND 
								JournalNumber = @JournalNumber AND 
								YEAR(DtDocument) = YEAR(GETDATE())
						)

		-- ��������� ������ � ������
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

	-- �� Id ��������� ������ ���������� ��������������� �����
	-- �����������
	SELECT	DocId,
			CONVERT(VARCHAR, DtDocument, 104) AS DtDocument, 
			CAST(dbo.Pr_fnsGetConstants(5,0) AS VARCHAR) + '-' + CAST(CodJournalDocsId AS VARCHAR) + '-' + CAST(DocNumber AS VARCHAR) AS DocNumber 
	FROM	Pr_JournalDocs4_05 
	WHERE	DocId = @@identity 

COMMIT TRANSACTION
END 

-- �������� ��������������� ������
IF @Function = 4 BEGIN
	DELETE FROM Pr_JournalDocs4_05 WHERE DocId = @DocId
END
GO
GRANT EXECUTE ON Pr_JournalDocRegistration TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OioPrintNotice' AND type = 'P')
    DROP PROCEDURE Pr_OioPrintNotice
GO
CREATE PROCEDURE dbo.Pr_OioPrintNotice
	/*
	�=======================================================�	
	�	������������ ������ ��������� ��� ������ ����������	�
	L=======================================================-		
	*/
-- ������������ ������ ��������� ��� ������ ����������
	@AbonentId			VARCHAR(32)		= NULL,		-- �� �������� (��� ������ 1�� ��������)
	@DtDoc				DATE			= NULL,		-- ���� ���������
	@ControllerId		INT				= NULL,		-- �� ����������
	@GKO				VARCHAR(100)	= NULL,		-- ������������ ��
	@RouterId			INT				= NULL,		-- �� ��������
	@ArealId			INT				= NULL,		-- ���������������� �����
	@VillageId		    INT				= NULL,		-- ����� / �������
	@AddressPartId 		INT				= NULL,		-- �����
	@BalanceMin			MONEY			= NULL,		-- �������� ����� ���
	@BalanceMax			MONEY			= NULL,		-- �������� ����� ����
	@CountMonthMin 		INT				= NULL,		-- ������ �������� �� ���
	@CountMonthMax 		INT				= NULL,		-- ������ �������� �� ����
	@prHouseTypeId		INT				= NULL,		-- ��� ����� �� �� �������
	@KVZ_EventTypeId	INT				= NULL,		-- ��� ��������� �� �������� ����������� �� �� �������

	@prEventGroupMin    INT				= NULL,     -- ����������� �� ���� ���������
	@prEventGroupMax    INT				= NULL,		-- ��� �����������
														-- ��� ���� ����������� (100 - 110)
														-- ��������� (110)
														-- ���������� (1)
	@IsDelPrinted		INT				= 0,		-- ���������� �� ������� ��� ����������
														-- 1: - ����������
														-- 0: - ���������

	@Function			INT				= 1			-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE 
AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� �� ������
/*
IF @ControllerId != 0 BEGIN 
RAISERROR('������ ���������� �������������� �� ���������� ������������ ...', 12, 1)
RETURN
END
*/
-- ����� ������� ��� ���-�� �������� ����������� ��
DECLARE @Period			INT
DECLARE @ClosePeriod	INT
DECLARE @IsHeatPeriod	INT = 1		-- ������������ ������ (1 - ��; 0 - ���)

SET		@DtDoc = GETDATE()
SET		@ClosePeriod = ( -- ��������� �������� ������
						SELECT	MAX(PeriodNumber) AS LastCloseMonth
						FROM	AccountingPeriods
						WHERE	(MonthStatus = 2) 
						)
SET		@Period = DATEPART(YEAR, @DtDoc)*100 + (DATEPART(MONTH, @DtDoc)-1)
-- ������������ @Period � @ClosePeriod ����....
IF @Period > @ClosePeriod BEGIN
	SET @Period = @ClosePeriod
END

-- ������������ �� ������ ������
IF @DtDoc NOT BETWEEN	(
						SELECT CAST('15.09.' + CAST(YEAR(GETDATE()) AS VARCHAR) AS DATE)
						) AND	(
								SELECT CAST('15.05.' + CAST(YEAR(GETDATE())+1 AS VARCHAR) as DATE)
								) BEGIN
	SET @IsHeatPeriod = 0
END
DECLARE @TempPrintList TABLE	(
							RowNumber INT,
							AbonentId INT,
							DtBeginOio SMALLDATETIME,
							AbonentNumber VARCHAR(50),
							FamilyMemberId INT,
							SNP VARCHAR(100),
							SNP_short VARCHAR(100),
							AddressString VARCHAR(200),
							Address VARCHAR(200),
							altAddress VARCHAR(200),
							Balance NUMERIC(10,2),
							CalcTypeId INT,
							KVZ_EventTypeId INT,
							prEventTypeId INT,
							prEventName VARCHAR(100),
							DtDoc SMALLDATETIME,
							DtFact1 SMALLDATETIME,
							DtFact3 SMALLDATETIME,
							ArealId INT,
							VillageId VARCHAR(100),
							AddressPartId VARCHAR(100),
							Areal VARCHAR(100),
							CityVillage VARCHAR(100),
							Street VARCHAR(100),
							House INT,
							LetterHouse VARCHAR(5),
							Room INT,
							GKO VARCHAR(200),
							prHouseTypeId INT,
							ControllerId INT,
							RouterId INT,
							CountMonth INT,
							GroupCount INT,
							prEventGroup INT,
							IsPrinted INT
							) 

INSERT INTO			@TempPrintList
SELECT 				NULL AS RowNumber, 
					vPr_OioEP.AbonentId, 
					vPr_OioEP.DtBeginOio, 
					e.Num AS AbonentNumber,
					fm.FamilyMemberId, 
					ISNULL (fm.SNP, '����������� �� ��������') as SNP, 
					ISNULL (fm.SNP_short, '����������� �� ��������') as SNP_short, 
					vA.CommAddressString +	CASE 
												WHEN vA.HouseTypeId = 8 THEN 
													' (�����)' 
												ELSE 
													'' 
												END + 
													CASE --	���� � ������� ���������������� � ������� ������������ ������
														WHEN vPr_OioEP.HousePropId = 25 AND vPr_OioEP.KVZ_EventTypeId IN (3,6,8) /*AND @IsHeatPeriod = 1*/ THEN
															' (����� ����������������)'
															ELSE 
															''
														END AS AddressString , 
					vA.EuCommAddressString + CASE 
												WHEN vA.PostIndex IS NOT NULL THEN 
													', ' + CAST(vA.PostIndex AS VARCHAR) 
												ELSE '' 
											END +	CASE 
													WHEN vA.HouseTypeId = 8 THEN 
														' (�����)' 
													ELSE '' 
													END + 
															CASE --	���� � ������� ���������������� � ������� ������������ ������
																WHEN vPr_OioEP.HousePropId = 25 AND vPr_OioEP.KVZ_EventTypeId IN (3,6,8) /*AND @IsHeatPeriod = 1*/ THEN
																	' (����� ����������������)'
																ELSE 
																	''
																END AS Address,
					CASE 
						WHEN vA.CommAltAddressString IS NOT NULL THEN 
							'�� ���������: ' + vA.CommAltAddressString 
						ELSE '' 
					END AS altAddress,
					OioB.Balance,
					vA.CalcTypeId, 
					vPr_OioEP.KVZ_EventTypeId, 
					vPr_OioEP.prEventTypeId, 
					vPr_OioEP.prEventName,
					vPr_OioEP.DtDoc, 
					vPr_OioEP.DtFact1, 
					vPr_OioEP.DtFact3, 
					ad.ArealId, 
					ad.VillageId, 
					vA.AddressPartId,
					vA.Areal,
					vA.CityVillage,
					vA.Street, 
					CAST(dbo.Pr_fnStripNonDigits(vA.House) AS int) AS House, 
					vA.LetterHouse, 
					CAST(dbo.Pr_fnStripNonDigits(vA.Room) AS int) AS Room, 
					e1.Name AS GKO, 
					vA.HousingOptionId AS prHouseTypeId, 
					vA.ControllerId, 
					pa.RouterId, 
					ISNULL(vPr_OioCM.CountMonth, 0) AS CountMonth, 
					ISNULL(vPr_OioCM.GroupCount, 0) AS GroupCount,
					vPr_OioEP.prEventGroup,
					-- ����������� ��������� �� ��� �������
					-- ���������� � ��������
					CASE 
						WHEN	oiob.Balance = j.SumDoc AND							-- ��� �� ������
								(
								SELECT		monthnumber
								FROM		vCurrentMonthNumber
								) = j.periodnumber AND								-- � ��� �� �������
								vpr_oioep.KVZ_EventTypeId = j.DocumentTypeId AND	-- ���� �����������
								vpr_oioep.KVZ_EventTypeId <> 8 THEN					-- ����� �������� ����������
							1 
						ELSE 
							0 
					END AS IsPrinted

FROM            	(
					SELECT		AbonentId, 
								ABS(CAST(Balance AS NUMERIC(10, 2))) AS Balance
              		FROM    	dbo.OioBalances AS OioBal
               		WHERE       (
								DateBalance = 	(
												SELECT		MAX(DateBalance) AS db
                                          		FROM   		dbo.OioBalances AS b
                                         		WHERE   	DateBalance <= CONVERT(DATETIME, GETDATE(), 102)
												)
								)
					) AS OioB 
RIGHT OUTER JOIN	(
					SELECT 		AbonentId, 
								FamilyMemberId, 
								SurName + ' ' + Name + ' ' + Patronymic AS SNP, 
								SurName + ' ' + LEFT(RTRIM(LTRIM(Name)), 1) + '.' + LEFT(RTRIM(LTRIM(Patronymic)), 1) + '.' AS SNP_short
             		FROM   		dbo.FamilyMembers
                  	WHERE  		FamilyRoleId = 1
					) AS fm 
RIGHT OUTER JOIN 	dbo.vPr_Schemes_JournalDocs4_05_DtEnd AS j 
RIGHT OUTER JOIN  	dbo.vPr_OioEventsPlane AS vPr_OioEP ON j.AbonentId = vPr_OioEP.AbonentId 
LEFT OUTER JOIN 	dbo.Pr_Abonents AS pa ON vPr_OioEP.AbonentId = pa.AbonentId 
LEFT OUTER JOIN 	dbo.vPr_OioCountMonthAbonent AS vPr_OioCM ON vPr_OioEP.AbonentId = vPr_OioCM.AbonentId AND 
													vPr_OioCM.PeriodNumber = ISNULL(@Period,
                             																(
																							SELECT		MAX(PeriodNumber) AS Period
                               																FROM		dbo.AccountingPeriods
                               																GROUP BY 	MonthStatus
                               																HAVING    	MonthStatus = 2
																							)
																					) ON fm.AbonentId = vPr_OioEP.AbonentId 
LEFT OUTER JOIN 	dbo.Elements AS e ON vPr_OioEP.AbonentId = e.ElementId ON OioB.AbonentId = vPr_OioEP.AbonentId 
LEFT OUTER JOIN		dbo.vAddressArealVillage AS ad 
INNER JOIN 			dbo.vAbonents AS vA ON ad.AddressPartId = vA.AddressPartId ON vPr_OioEP.AbonentId = vA.AbonentId 
LEFT OUTER JOIN 	dbo.Elements AS e1 ON vA.GkoId = e1.ElementId
ORDER BY 			vA.Areal, 
					vA.CityVillage, 
					vA.Street,
					House, 
					vA.LetterHouse, 
					Room


-- ���������� �������
								-- @AbonentId
IF ISNULL(@AbonentId, 0) <> 0 
	DELETE FROM @TempPrintList WHERE AbonentId != @AbonentId	

  								-- @DtDoc
IF @DtDoc IS NOT NULL 
	DELETE FROM @TempPrintList WHERE cast(DtDoc as date) > @DtDoc

  								-- @ControllerId
IF @ControllerId IS NOT NULL 
	DELETE FROM @TempPrintList WHERE ControllerId != @ControllerId

  								-- @GKO
IF @GKO IS NOT NULL  
	DELETE FROM @TempPrintList WHERE GKO NOT LIKE '%' + @GKO + '%'
	
								-- @RouterId
IF @RouterId IS NOT NULL 
	DELETE FROM @TempPrintList WHERE RouterId != @RouterId
	
								-- @ArealId
IF @ArealId IS NOT NULL 
	DELETE FROM @TempPrintList WHERE ArealId != @ArealId	
		
								-- @VillageId
IF @VillageId IS NOT NULL 
	DELETE FROM @TempPrintList WHERE VillageId != @VillageId

								-- @AddressPartId
IF @AddressPartId IS NOT NULL 
	DELETE FROM @TempPrintList WHERE AddressPartId != @AddressPartId

								-- Balance
IF @BalanceMin IS NOT NULL OR @BalanceMax IS NOT NULL 
	DELETE FROM @TempPrintList WHERE Balance NOT BETWEEN @BalanceMin AND @BalanceMax

								-- @CountMonth
IF @CountMonthMin IS NOT NULL OR @CountMonthMax IS NOT NULL 
	DELETE FROM @TempPrintList WHERE CountMonth NOT BETWEEN @CountMonthMin AND @CountMonthMax

								-- @prHouseTypeId
IF @prHouseTypeId IS NOT NULL 
	DELETE FROM @TempPrintList WHERE prHouseTypeId != @prHouseTypeId

								-- @KVZ_EventTypeId
IF @KVZ_EventTypeId IS NOT NULL 
	DELETE FROM @TempPrintList WHERE KVZ_EventTypeId != @KVZ_EventTypeId

								-- @prEventGroup
IF @prEventGroupMin IS NOT NULL OR @prEventGroupMax IS NOT NULL 
	DELETE FROM @TempPrintList WHERE prEventGroup NOT BETWEEN @prEventGroupMin AND @prEventGroupMax
			
-- ��������� ���� ��������� ��� ������������ �����������
IF @IsDelPrinted = 1 
	DELETE FROM @TempPrintList WHERE IsPrinted = 1

-- ���������� �������������� ����� ��������� ������ � ��� ��� ����������� ��
DELETE FROM @TempPrintList WHERE KVZ_EventTypeId IN (3, 6) AND GKO != '��� ������ �� ��'

/*--------------------------------------------------------------+
|          ��������� �������� @TempPrintList ��� ��������� �����|
+--------------------------------------------------------------*/

DECLARE	@curAbonentId	INT			-- ���������� ��� �������� �������
DECLARE	@Areal varchar(100) 
DECLARE	@CityVillage varchar(100) 
DECLARE	@Street varchar(100)
DECLARE	@House INT 
DECLARE	@LetterHouse varchar(5)
DECLARE	@Room int
DECLARE	@Row			INT = 0		-- ����� ������
-- ������ ���..
DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR
	SELECT DISTINCT	AbonentId, 
					Areal, 
					CityVillage, 
					Street,
					House, 
					LetterHouse, 
					Room
	FROM			@TempPrintList tp
	ORDER BY 		tp.Areal, 
					tp.CityVillage, 
					tp.Street,
					tp.House, 
					tp.LetterHouse, 
					tp.Room
OPEN  iCursor
-- ��������� ������ �������
FETCH NEXT FROM iCursor INTO @curAbonentId, @Areal, @CityVillage, @Street, @House, @LetterHouse, @Room
-- ���� ���� ���� ������
	WHILE @@FETCH_STATUS = 0   
		BEGIN 
			-- ���������� ������ 
			-- � ��������� ����� ������
			SET		 @Row = @Row + 1	
			UPDATE	@TempPrintList 
			SET		RowNumber = @Row
			WHERE	AbonentId = @curAbonentId
-- ���� ������ �������	
FETCH NEXT FROM iCursor INTO @curAbonentId, @Areal, @CityVillage, @Street, @House, @LetterHouse, @Room
END  
CLOSE iCursor
DEALLOCATE iCursor
----------------------------------------------------------------+

/* ������ ������� �� ��� ��������������� � ��������������� �������
   � ��� � ��� ���������� �������*/
SELECT	DISTINCT	RowNumber,
					AbonentId,
					FamilyMemberId,
					DtBeginOio,
					AbonentNumber,
					SNP,
					SNP_short,
					AddressString,
					Address,
					altAddress,
					dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) AS Balance,
					'���� � ����� ��������� ������: ' + dbo.Pr_fnsGetLastPayments(AbonentId, @DtDoc, 0) AS LastPayString,	-- ����������� ����.�������
					dbo.Pr_fnsGetLastIndication(AbonentId,'</br>', 1) AS LastIndicString,									-- ����������� ����.���������
					dbo.Pr_fnsGetAbonentCounterNumber(p.AbonentId) + CASE WHEN dbo.Pr_fnsIsPublic(p.AbonentId, 1) IS NOT NULL THEN ' (' + dbo.Pr_fnsIsPublic(p.AbonentId, 1) + ')' ELSE '' END  AS CounterNumber,	-- ����������� ������ ��
					'(' + dbo.Pr_fnsIsPublic(p.AbonentId, 1) + ')' AS IsPublic,												-- ����������� ���� � ����
					CalcTypeId,
					KVZ_EventTypeId,
					prEventTypeId,
					prEventName,
		
					 -- ��������� ���������		 
					CASE 
						-- ������
						WHEN p.CalcTypeId = 2 THEN
							CASE
								-- �����������
								WHEN p.KVZ_EventTypeId = 1 THEN 
									'����������� � ������ ����������� ������ ����������� ��������������'

								-- ����������
								WHEN p.KVZ_EventTypeId = 6 THEN 
									'� ������ ����������� ������ ����������� ��������������'

								-- �������� ����������
								WHEN p.KVZ_EventTypeId = 8 THEN 
									'� �������� ����������� ��������������'
							END
						-- ����� ����
						WHEN p.CalcTypeId = 1 THEN
							CASE
								-- �����������
								WHEN p.KVZ_EventTypeId = 1 THEN 
									'�������������� (�����������)'

								-- �����������
								WHEN p.KVZ_EventTypeId = 3 THEN 
									'� �������� ���������� ����������� ������ �����������'

								-- ����������
								WHEN p.KVZ_EventTypeId = 6 THEN 
									'� �������� ������� ����������� ������ �����������'

								-- �������� ����������
								WHEN p.KVZ_EventTypeId = 8 THEN 
									'� �������� ����������� ��������������'
							END
					ELSE
					'��� ��������� �� ���������'
					END	AS prDocName,

					 -- ����� ���������
					CASE 
						-- ������
						WHEN CalcTypeId = 2 THEN
							CASE 
								-- �����������
								WHEN p.KVZ_EventTypeId = 1 THEN 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									dbo.Pr_fnsGetConstants(0, 0) + ' ����������, ��� �� ��������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + ' �. ���� ������������� �� ������ ' + 
									'���������������� ���������� - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' ���.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'������ ����������� ������ ����������� ������������� ������� �������� �� ��������� ������ 2 ��������� � �.2 ������ ������� � (���)' + 
									'���������� ����������� ������ ����������� ������������� �������, ������������ �������������� ������������� �� �� 04.05.2012 � 442 (����� ������)' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'���� �������� ������� �����������: �____� __________ 20____�.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'������� ������������ ��� ���� �����, � ����������������� ����������� �(���) �������� ����������������� ������� �������������� ' + 
									'������������ ����������������� ���������� �����������, ������ ����������� ������ ����������� ����� ���� ������� � ����� ����� ' + 
									'����� 12-00 ���, ���������� ��� ���� �������� ������� �����������.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'�� 12-00 �____�&nbsp;__________&nbsp;20____�. ��� ���������� ���������� ��������������� ����������� ������ ����������� ������������� �������. ' + 
									'�������� ����������� ������ ����������� ������� ������������ ��� ���� �����, � ����������������� ����������� �(���) �������� ' + 
									'����������������� ������� �������������� ������������ ����������������� ���������� ����������� �� �������� ����� ����������� ��������� ' + 
									'���������� � ��������������� ����������� ������ �����������.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'��� ���������� �� 16-00 ���, ��������������� ��� �������� ����������� ���������� ������ ������ ������������� �� ������ ' + 
									'��������������� � ������������ ��� �� ������ � ' +  dbo.Pr_fnsGetConstants(1, 0) + ' �� ������: ' + dbo.Pr_fnsGetConstants(2, 1) + ' ' +
									dbo.Pr_fnsGetConstants(4, 0) + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'��������� �� ����� ����� ���������� � ��� ��� ��������� ������������� � �������������� �������, � ����������� �� ��� �������� �� ������ ' + 
									'��������������� �������.' +
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' + 
									CASE -- ����������� ����� ����� ���� ������� ��� ���� 
										WHEN dbo.Pr_fnsGetCostDisable(AbonentId, 0) IS NOT NULL THEN
											'� ������, ���� ��� ����� ������� ����������� ������ �������������� �� �������������, ' +
											'� ������������ � �.20 ������ �������, ��������� � ��������� �����������, ���������������� � �������������� ���������������� ' + 
											'����������� - ��������, �������� ���������� � ����� ' + dbo.Pr_fnsGetCostDisable(AbonentId, 0) + ' ������ �� ���� �����������, � ��������� �������� ' + 
											'�������������� ��������� ��������.'
										ELSE
											''
									END +
									'</p></pre>'

								-- ����������
								WHEN p.KVZ_EventTypeId = 6 THEN 
									'          ��������� ����������� ������ ������ � ����������� ������ ' + dbo.Pr_fnsGetConstants(1, 0)  + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' � �����������:                                                  '  + CHAR(10) +
									'�� ������� ���������� ���������������� � ������' + CHAR(10) +
									'' + CHAR(10) +
									'������������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + '�. - ' + CAST(Balance AS VARCHAR) + '���.'

								-- �������� ����������
								WHEN p.KVZ_EventTypeId = 8 THEN 
									'          ��������� ����������� ������ ������ � ����������� ������ ' + dbo.Pr_fnsGetConstants(1, 0)  + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' � �����������:                                                  '  + CHAR(10) +
									'�� ������� �������� ���������� ���������������� � ������' + CHAR(10) +
									'' + CHAR(10) +
									'������������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + '�. - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + '���.'
							END
		
						-- ����� ����
						WHEN CalcTypeId = 1 THEN
							CASE 
								-- �����������
								WHEN KVZ_EventTypeId = 1 THEN
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +   
									dbo.Pr_fnsGetConstants(0, 0) + ' ����������, ��� �� ��������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + ' �. ���� ������������� �� ������ ' + 
									'���������������� ���������� - <b>' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' ���.</b>' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'�������������� �.119� ������� �������������� ������������ ����� ������������� � ������������� ��������� ' + 
									'� ��������������� ����� � ����� �����, ������������ �������������� ������������� �� �� 06.05.2011 �. �354, (����� ������), ' + 
									'��� ���������� � ������� 20 ����, �� ��� �������� ������� �������������� (�����������), ���������� ������ ������ ������������� �� ' + 
									'�������������� � ������������ ��������, �������������� ������ � ' + dbo.Pr_fnsGetConstants(1, 0) + ' �� ������: ' + 
									dbo.Pr_fnsGetConstants(2, 1) + ' ' + dbo.Pr_fnsGetConstants(4, 0) + '.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'� ������������ � �.�. 119�, 119� ������, � ������ �������� �������� ��� �������� ������ ������������� �� ������ ' + 
									'����������������, � ������� �������������� � ����������� �����, ' + dbo.Pr_fnsGetConstants(1, 0) + ' ����� ��������� ��� ������� ' + 
									'����������� ����������� ������ ����������� ������ ������������� ������� � �____�&nbsp;__________&nbsp;20____�. � � ������ ���������� �������� ' + 
									'�� ��������� 10 ���� �� ��� �������� ����������� ������ ������������� �������, �____�&nbsp;__________&nbsp;20____�. ������������� ������ ������������� �������.' +
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'��� ���������� ����������� ����������� �������� ����������� ������ ������������� ������� ����� �������������� � �____�&nbsp;__________&nbsp;20____�. ' + 
									'�� ��������� �������������.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'��������� �� ����� ����� ���������� � ��� ��� ��������� ������������� � �������������� �������, � ����������� �� ��� ' + 
									'�������� �� ������ ��������������� �������.' +
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' +
									CASE -- ����������� ����� ����� ���� ������� ��� ���� 
										WHEN dbo.Pr_fnsGetCostDisable(AbonentId, 0) IS NOT NULL THEN
											'� ������, ���� ��� ����� ������� ����������� ' +
											'������ �������������� �� �������������, � ������������ � �.121 ������ �������, ��������� � ��������� �����������, ���������������� � �������������� ' + 
											'���������������� ����������� - ��������, �������� ���������� � ����� ' + dbo.Pr_fnsGetCostDisable(AbonentId, 0) + ' ������ �� ���� �����������, ' +  
											'� ��������� �������� �������������� ��������� ��������.'
										ELSE
											''
										END +
									'</p></pre>' 

								-- �����������
								WHEN KVZ_EventTypeId = 3 THEN
									SPACE(10) + '��������� ����������� �� � �� ' + dbo.Pr_fnsGetConstants(1, 0) + SPACE(35) + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' � �����������:' + SPACE(137) + CHAR(10) +
									'�� ������� ����������� ���������������� �' + SPACE(10) +	CASE
																									WHEN prHouseTypeId = 1 THEN 
																										'������� ����' + SPACE(123)
																									WHEN prHouseTypeId = 2 THEN
																										'��������' + SPACE(130)
																									END + CHAR(10) +
									'�� ������� �.�. 119�, 119� ������� �������������� ������������ ����� ������������� � �������������' + SPACE(48) + CHAR(10) +
									'��������� ��������������� ����� � ����� �����, ������������ ��������������' + SPACE(68) + CHAR(10) +
									'������������� �� �� 06.05.2011 �. �354, ����� �������. ��� ���������� ����������� �����������' + SPACE(45) + CHAR(10) +
									'�������� ����������� �� ��������� �.119� �������, ������ �������������� ����� ��������������.' + SPACE(42) + CHAR(10) +
									'' + CHAR(10) +
									'������������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + ' �. - ' + CAST(Balance AS VARCHAR) + ' ���.' + SPACE(5)							

								-- ����������
								WHEN KVZ_EventTypeId = 6 THEN 
									'          ��������� ����������� �� � �� ' + dbo.Pr_fnsGetConstants(1, 0) + SPACE(35) + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' � �����������:' + SPACE(137) + CHAR(10) +
									'�� ������� ���������� ���������������� �' + SPACE(10) +	CASE	
																									WHEN prHouseTypeId = 1 THEN 
																										'������� ����' + SPACE(123)
																									WHEN prHouseTypeId = 2 THEN
																										'��������' + SPACE(130)
																									END + CHAR(10) +
									'' + CHAR(10) +
									'������������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + ' �. - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' ���.' + SPACE(5)

								-- �������� ����������
								WHEN KVZ_EventTypeId = 8 THEN 
									'          ��������� ����������� �� � �� ' + dbo.Pr_fnsGetConstants(1, 0) + SPACE(35)  + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' � �����������:' + SPACE(137) + CHAR(10) +
									'�� ������� �������� ���������� ���������������� �' + SPACE(10) +	CASE	
																											WHEN prHouseTypeId = 1 THEN 
																												'������� ����' + SPACE(123)
																											WHEN prHouseTypeId = 2 THEN
																												'��������' + SPACE(130)
																											END + CHAR(10) +
									'' + CHAR(10) +
									'������������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + ' � . - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' ���.' + SPACE(5)
						END		
				
					ELSE
					'��� ��������� �� ���������'
					END AS prDocText,
					CASE WHEN p.KVZ_EventTypeId = 1 THEN
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 0px; margin-top: 1em; margin-bottom: 0em">' + 
					'<b>������� � ��������� ����������� (��������������) </b>' + 
					'</p></pre>' + 
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 0px; margin-top: 1em; margin-bottom: 0em">' +
					'�� ��������� �� ' + CONVERT(VARCHAR, @DtDoc, 104) + '�. �� ����� ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' ���.' + 
					'</p></pre>' + 
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' +
					'� ������ �������� �������� ��� �������� ������ ������������� �� ������ ����������������, � ������� �������������� � ����������� �����, ����� ����������� ' + 
					'����������� �____�&nbsp;__________&nbsp;20____�. � ������ ���������� ��������, ������ ������������� ������� ����� �������������� �____�&nbsp;__________&nbsp;20____�. ' + 
					'</p></pre>' + 
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' +
					CASE -- ����������� ����� ����� ���� ������� ��� ���� 
						WHEN dbo.Pr_fnsGetCostDisable(AbonentId, 0) IS NOT NULL THEN
							'������������, ��� � ������ ����� ����������� ������ ������������� ������� �� �������������, � ������������ � �. ' + 
							CASE 
                            	WHEN p.CalcTypeId = 2 THEN '20'
                            	WHEN p.CalcTypeId = 1 THEN '121' 
                            ELSE ''
                            END + ' ������ �������, ��������� ' + 
							'� ��������� �����������, ���������������� � �������������� ���������������� �������� ���������� � ����� ' + dbo.Pr_fnsGetCostDisable(AbonentId, 0) + ' ' + 
							'������ �� ���� �����������, � ��������� �������� �������������� ��������� ��������. '
					ELSE
						''
					END + '</pre></p>'
					END AS prDocText_footer,
					DtDoc,
					DtFact1,
					DtFact3,
					ArealId,
					VillageId,
					AddressPartId,
					House,
					LetterHouse,
					Room,
					GKO,
					prHouseTypeId,
					ControllerId,
					'��������� 2 �������: ' + dbo.Pr_fnsGetShortFNS('', ControllerId, 1) AS PerformerName,
					RouterId,
					CountMonth,
					GroupCount,
					prEventGroup
FROM	@TempPrintList AS p


-- ����������� �������� ���� ��������� ��������
-- ���� ������� @TempPrintList �� ������
IF (SELECT COUNT(AbonentId) AS c FROM @TempPrintList) != 0

-- �����������
SELECT		OioET.prEventName + ':' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			0 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId
GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId
HAVING		(OioET.KVZ_EventTypeId = 1)
	
	UNION ALL
-- �������� ��� / ��
			SELECT		'- ' + hp.Name AS prEventName, 
						dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
						dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
						OioET.prEventTypeId
			FROM		Pr_OioEventsTypes AS OioET 
			INNER JOIN	@TempPrintList AS tp 
						ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
						AND OioET.prHouseTypeId = tp.prHouseTypeId 
			INNER JOIN	vPr_HouseType AS hp 
						ON tp.prHouseTypeId = hp.prHouseTypeId
			GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId, hp.Name, OioET.prEventTypeId
			HAVING		(OioET.KVZ_EventTypeId = 1)

UNION ALL
-- ��������� �� �����������
SELECT		OioET.prEventName + ':' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			0 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId
GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId
HAVING		(OioET.KVZ_EventTypeId = 2)
	
	UNION ALL
-- �������� ��� / ��
			SELECT		'- ' + hp.Name AS prEventName, 
						dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
						dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
						OioET.prEventTypeId
			FROM		Pr_OioEventsTypes AS OioET 
			INNER JOIN	@TempPrintList AS tp 
						ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
						AND OioET.prHouseTypeId = tp.prHouseTypeId 
			INNER JOIN	vPr_HouseType AS hp 
						ON tp.prHouseTypeId = hp.prHouseTypeId
			GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId, hp.Name, OioET.prEventTypeId
			HAVING		(OioET.KVZ_EventTypeId = 2)

UNION ALL
-- �����������
SELECT		OioET.prEventName + ':' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			0 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId
GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId
HAVING		(OioET.KVZ_EventTypeId = 3)

	UNION ALL
-- �������� ��� / ��
			SELECT		'- ' + hp.Name AS prEventName, 
						dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
						dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
						OioET.prEventTypeId
			FROM		Pr_OioEventsTypes AS OioET 
			INNER JOIN	@TempPrintList AS tp 
						ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
						AND OioET.prHouseTypeId = tp.prHouseTypeId 
			INNER JOIN	vPr_HouseType AS hp 
						ON tp.prHouseTypeId = hp.prHouseTypeId
			GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId, hp.Name, OioET.prEventTypeId
			HAVING		(OioET.KVZ_EventTypeId = 3)

UNION ALL
-- ��������� �� ����������
SELECT		OioET.prEventName + ':' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			0 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId
GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId
HAVING		(OioET.KVZ_EventTypeId = 5)

	UNION ALL
-- �������� ��� / ��
			SELECT		'- ' + hp.Name AS prEventName, 
						dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
						dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
						OioET.prEventTypeId
			FROM		Pr_OioEventsTypes AS OioET 
			INNER JOIN	@TempPrintList AS tp 
						ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
						AND OioET.prHouseTypeId = tp.prHouseTypeId 
			INNER JOIN	vPr_HouseType AS hp 
						ON tp.prHouseTypeId = hp.prHouseTypeId
			GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId, hp.Name, OioET.prEventTypeId
			HAVING		(OioET.KVZ_EventTypeId = 5)

UNION ALL
-- ����������
SELECT		OioET.prEventName + ':' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			0 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId
GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId
HAVING		(OioET.KVZ_EventTypeId = 6)

	UNION ALL
-- �������� ��� / ��
			SELECT		'- ' + hp.Name AS prEventName, 
						dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
						dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
						OioET.prEventTypeId
			FROM		Pr_OioEventsTypes AS OioET 
			INNER JOIN	@TempPrintList AS tp 
						ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
						AND OioET.prHouseTypeId = tp.prHouseTypeId 
			INNER JOIN	vPr_HouseType AS hp 
						ON tp.prHouseTypeId = hp.prHouseTypeId
			GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId, hp.Name, OioET.prEventTypeId
			HAVING		(OioET.KVZ_EventTypeId = 6)

UNION ALL
-- �������� ����������
SELECT		OioET.prEventName + ':' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			0 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId
GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId
HAVING		(OioET.KVZ_EventTypeId = 8)

	UNION ALL
-- �������� ��� / ��
			SELECT		'- ' + hp.Name AS prEventName, 
						dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
						dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
						OioET.prEventTypeId
			FROM		Pr_OioEventsTypes AS OioET 
			INNER JOIN	@TempPrintList AS tp 
						ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
						AND OioET.prHouseTypeId = tp.prHouseTypeId 
			INNER JOIN	vPr_HouseType AS hp 
						ON tp.prHouseTypeId = hp.prHouseTypeId
			GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId, hp.Name, OioET.prEventTypeId
			HAVING		(OioET.KVZ_EventTypeId = 8)

UNION ALL
-- ����� �� ���� �������
SELECT		'�����:' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			90 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId

-- ���� ������� @TempPrintList ������
-- ������ �������� �������
ELSE BEGIN
SELECT		OioET.prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			0 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN  @TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId
GROUP BY	OioET.prEventName, OioET.KVZ_EventTypeId
END
-- DROP TABLE @TempPrintList
GO
GRANT EXECUTE ON Pr_OioPrintNotice TO KvzWorker
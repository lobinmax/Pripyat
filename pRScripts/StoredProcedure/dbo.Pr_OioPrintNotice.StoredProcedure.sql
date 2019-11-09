IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OioPrintNotice' AND type = 'P')
    DROP PROCEDURE Pr_OioPrintNotice
GO
CREATE PROCEDURE dbo.Pr_OioPrintNotice
	/*
	г=======================================================¬	
	¦	Формирование списка должников для печати документов	¦
	L=======================================================-		
	*/
-- Формирование списка должников для печати документов
	@AbonentId			VARCHAR(32)		= NULL,		-- Ид абонента (для печати 1го лицевого)
	@DtDoc				DATE			= NULL,		-- Дата документа
	@ControllerId		INT				= NULL,		-- Ид контролера
	@GKO				VARCHAR(100)	= NULL,		-- Наименование УК
	@RouterId			INT				= NULL,		-- Ид маршрута
	@ArealId			INT				= NULL,		-- Административный район
	@VillageId		    INT				= NULL,		-- Город / Деревня
	@AddressPartId 		INT				= NULL,		-- Улица
	@BalanceMin			MONEY			= NULL,		-- Диапазон долга Мин
	@BalanceMax			MONEY			= NULL,		-- Диапазон долга Макс
	@CountMonthMin 		INT				= NULL,		-- Диапан периодов ДЗ Мин
	@CountMonthMax 		INT				= NULL,		-- Группа периодов ДЗ Макс
	@prHouseTypeId		INT				= NULL,		-- Тип жилья по ПК Припять
	@KVZ_EventTypeId	INT				= NULL,		-- Тип документа на вручение расчитанный по ПК Припять

	@prEventGroupMin    INT				= NULL,     -- Группировка по типу документа
	@prEventGroupMax    INT				= NULL,		-- Тип мероприятия
														-- Все типы Уведомлений (100 - 110)
														-- Извещения (110)
														-- Отключения (1)
	@IsDelPrinted		INT				= 0,		-- Исключение из перечня уже печатавших
														-- 1: - исключение
														-- 0: - оставляем

	@Function			INT				= 1			-- 1 - SELECT
													-- 2 - INSERT
													-- 3 - UPDATE
													-- 4 - DELETE 
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке
/*
IF @ControllerId != 0 BEGIN 
RAISERROR('Печать документов приостановлена по инициативе разработчика ...', 12, 1)
RETURN
END
*/
-- Номер периода для кол-ва периодов образования ДЗ
DECLARE @Period			INT
DECLARE @ClosePeriod	INT
DECLARE @IsHeatPeriod	INT = 1		-- Отопительный период (1 - да; 0 - нет)

SET		@DtDoc = GETDATE()
SET		@ClosePeriod = ( -- последний закрытый период
						SELECT	MAX(PeriodNumber) AS LastCloseMonth
						FROM	AccountingPeriods
						WHERE	(MonthStatus = 2) 
						)
SET		@Period = DATEPART(YEAR, @DtDoc)*100 + (DATEPART(MONTH, @DtDoc)-1)
-- приравниваем @Period к @ClosePeriod если....
IF @Period > @ClosePeriod BEGIN
	SET @Period = @ClosePeriod
END

-- Отопительный ли сейчас период
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
					ISNULL (fm.SNP, 'Собственник не определён') as SNP, 
					ISNULL (fm.SNP_short, 'Собственник не определён') as SNP_short, 
					vA.CommAddressString +	CASE 
												WHEN vA.HouseTypeId = 8 THEN 
													' (Гараж)' 
												ELSE 
													'' 
												END + 
													CASE --	если у клиента электроотопление и сегодня отопительный период
														WHEN vPr_OioEP.HousePropId = 25 AND vPr_OioEP.KVZ_EventTypeId IN (3,6,8) /*AND @IsHeatPeriod = 1*/ THEN
															' (Кроме электроотопления)'
															ELSE 
															''
														END AS AddressString , 
					vA.EuCommAddressString + CASE 
												WHEN vA.PostIndex IS NOT NULL THEN 
													', ' + CAST(vA.PostIndex AS VARCHAR) 
												ELSE '' 
											END +	CASE 
													WHEN vA.HouseTypeId = 8 THEN 
														' (Гараж)' 
													ELSE '' 
													END + 
															CASE --	если у клиента электроотопление и сегодня отопительный период
																WHEN vPr_OioEP.HousePropId = 25 AND vPr_OioEP.KVZ_EventTypeId IN (3,6,8) /*AND @IsHeatPeriod = 1*/ THEN
																	' (Кроме электроотопления)'
																ELSE 
																	''
																END AS Address,
					CASE 
						WHEN vA.CommAltAddressString IS NOT NULL THEN 
							'за помещение: ' + vA.CommAltAddressString 
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
					-- Определение печатался ли уже абонент
					-- сравниваем с журналом
					CASE 
						WHEN	oiob.Balance = j.SumDoc AND							-- тот же баланс
								(
								SELECT		monthnumber
								FROM		vCurrentMonthNumber
								) = j.periodnumber AND								-- в том же периоде
								vpr_oioep.KVZ_EventTypeId = j.DocumentTypeId AND	-- тоже мероприятие
								vpr_oioep.KVZ_EventTypeId <> 8 THEN					-- кроме проверок отключения
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


-- ФИЛЬТРАЦИЯ ВЫБОРКИ
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
			
-- Исключаем если требуется уже напечатанных мероприятий
IF @IsDelPrinted = 1 
	DELETE FROM @TempPrintList WHERE IsPrinted = 1

-- Отключение самостоятельно можем проводить только в МКД где отсутствует УО
DELETE FROM @TempPrintList WHERE KVZ_EventTypeId IN (3, 6) AND GKO != 'Нет данных по УО'

/*--------------------------------------------------------------+
|          Обработка курсором @TempPrintList для нумерации строк|
+--------------------------------------------------------------*/

DECLARE	@curAbonentId	INT			-- переменная для хранения курсора
DECLARE	@Areal varchar(100) 
DECLARE	@CityVillage varchar(100) 
DECLARE	@Street varchar(100)
DECLARE	@House INT 
DECLARE	@LetterHouse varchar(5)
DECLARE	@Room int
DECLARE	@Row			INT = 0		-- номер строки
-- курсор для..
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
-- открываем строку курсора
FETCH NEXT FROM iCursor INTO @curAbonentId, @Areal, @CityVillage, @Street, @House, @LetterHouse, @Room
-- пока есть след строка
	WHILE @@FETCH_STATUS = 0   
		BEGIN 
			-- перебираем строки 
			-- и вставляем номер строки
			SET		 @Row = @Row + 1	
			UPDATE	@TempPrintList 
			SET		RowNumber = @Row
			WHERE	AbonentId = @curAbonentId
-- след строка курсора	
FETCH NEXT FROM iCursor INTO @curAbonentId, @Areal, @CityVillage, @Street, @House, @LetterHouse, @Room
END  
CLOSE iCursor
DEALLOCATE iCursor
----------------------------------------------------------------+

/* делаем выборку из уже отфильтрованной и пронумерованной таблицы
   и уже в ней производим расчеты*/
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
					'Дата и сумма последней оплаты: ' + dbo.Pr_fnsGetLastPayments(AbonentId, @DtDoc, 0) AS LastPayString,	-- Определение посл.платежа
					dbo.Pr_fnsGetLastIndication(AbonentId,'</br>', 1) AS LastIndicString,									-- определение посл.показаний
					dbo.Pr_fnsGetAbonentCounterNumber(p.AbonentId) + CASE WHEN dbo.Pr_fnsIsPublic(p.AbonentId, 1) IS NOT NULL THEN ' (' + dbo.Pr_fnsIsPublic(p.AbonentId, 1) + ')' ELSE '' END  AS CounterNumber,	-- определение номера ПУ
					'(' + dbo.Pr_fnsIsPublic(p.AbonentId, 1) + ')' AS IsPublic,												-- определение дома с ОДПУ
					CalcTypeId,
					KVZ_EventTypeId,
					prEventTypeId,
					prEventName,
		
					 -- ЗАГОЛОВОК ДОКУМЕНТА		 
					CASE 
						-- Гаражи
						WHEN p.CalcTypeId = 2 THEN
							CASE
								-- Уведомление
								WHEN p.KVZ_EventTypeId = 1 THEN 
									'УВЕДОМЛЕНИЕ о полном ограничении режима потребления электроэнергии'

								-- Отключение
								WHEN p.KVZ_EventTypeId = 6 THEN 
									'о полном ограничении режима потребления электроэнергии'

								-- Проверка отключения
								WHEN p.KVZ_EventTypeId = 8 THEN 
									'о проверке отключенной электроэнергии'
							END
						-- Жилые дома
						WHEN p.CalcTypeId = 1 THEN
							CASE
								-- Уведомление
								WHEN p.KVZ_EventTypeId = 1 THEN 
									'ПРЕДУПРЕЖДЕНИЕ (УВЕДОМЛЕНИЕ)'

								-- Ограничение
								WHEN p.KVZ_EventTypeId = 3 THEN 
									'о введении частичного ограничения режима потребления'

								-- Отключение
								WHEN p.KVZ_EventTypeId = 6 THEN 
									'о введении полного ограничения режима потребления'

								-- Проверка отключения
								WHEN p.KVZ_EventTypeId = 8 THEN 
									'о проверке отключенной электроэнергии'
							END
					ELSE
					'Тип документа не определен'
					END	AS prDocName,

					 -- ТЕКСТ ДОКУМЕНТА
					CASE 
						-- Гаражи
						WHEN CalcTypeId = 2 THEN
							CASE 
								-- Уведомление
								WHEN p.KVZ_EventTypeId = 1 THEN 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									dbo.Pr_fnsGetConstants(0, 0) + ' уведомляет, что по состоянию на ' + CONVERT(VARCHAR, @DtDoc, 104) + ' г. Ваша задолженность по услуге ' + 
									'электроснабжения составляет - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' руб.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'Полное ограничение режима потребления электрической энергии вводится на основании абзаца 2 подпункта б п.2 Правил полного и (или)' + 
									'частичного ограничения режима потребления электрической энергии, утвержденных постановлением Правительства РФ от 04.05.2012 № 442 (далее правил)' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'Дата введения полного ограничения: «____» __________ 20____г.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'Сетевой организацией или иным лицом, к энергопринимающим устройствам и(или) объектам электроэнергетики которым технологически ' + 
									'присоединены энергопринимающие устройства потребителя, полное ограничение режима потребления может быть введено в любое время ' + 
									'после 12-00 дня, указанного как дата введения полного ограничения.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'До 12-00 «____»&nbsp;__________&nbsp;20____г. Вам необходимо произвести самостоятельное ограничение режима потребления электрической энергии. ' + 
									'Введение ограничения режима потребления сетевой организацией или иным лицом, к энергопринимающим устройствам и(или) объектам ' + 
									'электроэнергетики которым технологически присоединены энергопринимающие устройства потребителя не отменяет Вашей обязанности выполнить ' + 
									'требование о самостоятельном ограничении режима потребления.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'Вам необходимо до 16-00 дня, предшествующего дню введения ограничения произвести полную оплату задолженности по услуге ' + 
									'энергоснабжения и предоставить чек об оплате в ' +  dbo.Pr_fnsGetConstants(1, 0) + ' по адресу: ' + dbo.Pr_fnsGetConstants(2, 1) + ' ' +
									dbo.Pr_fnsGetConstants(4, 0) + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'Оставляем за собой право обратиться в суд для взыскания задолженности в принудительном порядке, с возложением на Вас расходов по уплате ' + 
									'государственной пошлины.' +
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' + 
									CASE -- определение суммы допов если КрасЭко или МРСК 
										WHEN dbo.Pr_fnsGetCostDisable(AbonentId, 0) IS NOT NULL THEN
											'В случае, если Вам будет введено ограничение подачи электроэнергии за задолженность, ' +
											'в соответствии с п.20 Правил расходы, связанные с введением ограничения, приостановлением и возобновлением электроснабжения ' + 
											'потребителю - должнику, подлежат возмещению в сумме ' + dbo.Pr_fnsGetCostDisable(AbonentId, 0) + ' рублей за счет потребителя, в отношении которого ' + 
											'осуществлялись указанные действия.'
										ELSE
											''
									END +
									'</p></pre>'

								-- Отключение
								WHEN p.KVZ_EventTypeId = 6 THEN 
									'          Составлен контролером Группы работы с физическими лицами ' + dbo.Pr_fnsGetConstants(1, 0)  + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' в присутствии:                                                  '  + CHAR(10) +
									'на предмет отключения электроустановки в Гараже' + CHAR(10) +
									'' + CHAR(10) +
									'Задолженность на ' + CONVERT(VARCHAR, @DtDoc, 104) + 'г. - ' + CAST(Balance AS VARCHAR) + 'руб.'

								-- Проверка отключения
								WHEN p.KVZ_EventTypeId = 8 THEN 
									'          Составлен контролером Группы работы с физическими лицами ' + dbo.Pr_fnsGetConstants(1, 0)  + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' в присутствии:                                                  '  + CHAR(10) +
									'на предмет проверки отключения электроустановки в Гараже' + CHAR(10) +
									'' + CHAR(10) +
									'Задолженность на ' + CONVERT(VARCHAR, @DtDoc, 104) + 'г. - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + 'руб.'
							END
		
						-- Жилые дома
						WHEN CalcTypeId = 1 THEN
							CASE 
								-- Уведомление
								WHEN KVZ_EventTypeId = 1 THEN
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +   
									dbo.Pr_fnsGetConstants(0, 0) + ' уведомляет, что по состоянию на ' + CONVERT(VARCHAR, @DtDoc, 104) + ' г. Ваша задолженность по услуге ' + 
									'электроснабжения составляет - <b>' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' руб.</b>' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'Руководствуясь п.119а «Правил предоставления коммунальных услуг собственникам и пользователям помещений ' + 
									'в многоквартирных домах и жилых домов», утвержденных Постановлением Правительства РФ от 06.05.2011 г. №354, (далее Правил), ' + 
									'Вам необходимо в течение 20 дней, со дня доставки данного предупреждения (уведомления), произвести полную оплату задолженности по ' + 
									'электроэнергии и предоставить документ, подтверждающий оплату в ' + dbo.Pr_fnsGetConstants(1, 0) + ' по адресу: ' + 
									dbo.Pr_fnsGetConstants(2, 1) + ' ' + dbo.Pr_fnsGetConstants(4, 0) + '.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'В соответствии с п.п. 119б, 119в Правил, в случае задержки платежей или неполной оплаты задолженности по услуге ' + 
									'электроснабжения, в течение установленного в уведомлении срока, ' + dbo.Pr_fnsGetConstants(1, 0) + ' будет вынуждено при наличии ' + 
									'технической возможности ввести ограничение подачи электрической энергии с «____»&nbsp;__________&nbsp;20____г. и в случае дальнейшей неоплаты ' + 
									'по истечении 10 дней со дня введения ограничения подачи электрической энергии, «____»&nbsp;__________&nbsp;20____г. приостановить подачу электрической энергии.' +
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'При отсутствии технической возможности введения ограничения подача электрической энергии будет приостановлена с «____»&nbsp;__________&nbsp;20____г. ' + 
									'до погашения задолженности.' + 
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 0em; margin-bottom: 0em">' +
									'Оставляем за собой право обратиться в суд для взыскания задолженности в принудительном порядке, с возложением на Вас ' + 
									'расходов по уплате государственной пошлины.' +
									'</p></pre>' + 
									'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' +
									CASE -- определение суммы допов если КрасЭко или МРСК 
										WHEN dbo.Pr_fnsGetCostDisable(AbonentId, 0) IS NOT NULL THEN
											'В случае, если Вам будет введено ограничение ' +
											'подачи электроэнергии за задолженность, в соответствии с п.121 Правил расходы, связанные с введением ограничения, приостановлением и возобновлением ' + 
											'электроснабжения потребителю - должнику, подлежат возмещению в сумме ' + dbo.Pr_fnsGetCostDisable(AbonentId, 0) + ' рублей за счет потребителя, ' +  
											'в отношении которого осуществлялись указанные действия.'
										ELSE
											''
										END +
									'</p></pre>' 

								-- Ограничение
								WHEN KVZ_EventTypeId = 3 THEN
									SPACE(10) + 'Составлен контролером ГР с ФЛ ' + dbo.Pr_fnsGetConstants(1, 0) + SPACE(35) + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' в присутствии:' + SPACE(137) + CHAR(10) +
									'на предмет ограничения электроустановки в' + SPACE(10) +	CASE
																									WHEN prHouseTypeId = 1 THEN 
																										'Частном доме' + SPACE(123)
																									WHEN prHouseTypeId = 2 THEN
																										'Квартире' + SPACE(130)
																									END + CHAR(10) +
									'На освании п.п. 119б, 119в «Правил предоставления коммунальных услуг собственникам и пользователям' + SPACE(48) + CHAR(10) +
									'помещений многоквартирных домах и жилых домов», утвержденных Постановлением' + SPACE(68) + CHAR(10) +
									'Правительства РФ от 06.05.2011 г. №354, далее «Правил». При отсутствии технической возможности' + SPACE(45) + CHAR(10) +
									'введения ограничения на основании п.119в «Правил», подача электроэнергии будет приостановлена.' + SPACE(42) + CHAR(10) +
									'' + CHAR(10) +
									'Задолженность на ' + CONVERT(VARCHAR, @DtDoc, 104) + ' г. - ' + CAST(Balance AS VARCHAR) + ' руб.' + SPACE(5)							

								-- Отключение
								WHEN KVZ_EventTypeId = 6 THEN 
									'          Составлен контролером ГР с ФЛ ' + dbo.Pr_fnsGetConstants(1, 0) + SPACE(35) + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' в присутствии:' + SPACE(137) + CHAR(10) +
									'на предмет отключения электроустановки в' + SPACE(10) +	CASE	
																									WHEN prHouseTypeId = 1 THEN 
																										'Частном доме' + SPACE(123)
																									WHEN prHouseTypeId = 2 THEN
																										'Квартире' + SPACE(130)
																									END + CHAR(10) +
									'' + CHAR(10) +
									'Задолженность на ' + CONVERT(VARCHAR, @DtDoc, 104) + ' г. - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' руб.' + SPACE(5)

								-- Проверка отключения
								WHEN KVZ_EventTypeId = 8 THEN 
									'          Составлен контролером ГР с ФЛ ' + dbo.Pr_fnsGetConstants(1, 0) + SPACE(35)  + CHAR(10) +
									ISNULL(dbo.Pr_fnsGetPerfData(ControllerId, 0), dbo.Kernel_GetPerformer()) + ' в присутствии:' + SPACE(137) + CHAR(10) +
									'на предмет проверки отключения электроустановки в' + SPACE(10) +	CASE	
																											WHEN prHouseTypeId = 1 THEN 
																												'Частном доме' + SPACE(123)
																											WHEN prHouseTypeId = 2 THEN
																												'Квартире' + SPACE(130)
																											END + CHAR(10) +
									'' + CHAR(10) +
									'Задолженность на ' + CONVERT(VARCHAR, @DtDoc, 104) + ' г . - ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' руб.' + SPACE(5)
						END		
				
					ELSE
					'Тип документа не определен'
					END AS prDocText,
					CASE WHEN p.KVZ_EventTypeId = 1 THEN
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 0px; margin-top: 1em; margin-bottom: 0em">' + 
					'<b>Отметка о получении уведомления (предупреждения) </b>' + 
					'</p></pre>' + 
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 0px; margin-top: 1em; margin-bottom: 0em">' +
					'По состоянию на ' + CONVERT(VARCHAR, @DtDoc, 104) + 'г. на сумму ' + dbo.Pr_fnsGetNumberSeparate(p.Balance, NULL, NULL) + ' руб.' + 
					'</p></pre>' + 
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' +
					'В случае задержки платежей или неполной оплаты задолженности по услуге электроснабжения, в течении установленного в уведомлении срока, будет произведено ' + 
					'ограничение «____»&nbsp;__________&nbsp;20____г. в случае дальнейшей неоплаты, подача электрической энергии будет приостановлена «____»&nbsp;__________&nbsp;20____г. ' + 
					'</p></pre>' + 
					'<pre><p align="Justify" style="font-size: 8pt; font-family:''Arial''; text-indent: 30px; margin-top: 1em; margin-bottom: 0em">' +
					CASE -- определение суммы допов если КрасЭко или МРСК 
						WHEN dbo.Pr_fnsGetCostDisable(AbonentId, 0) IS NOT NULL THEN
							'Предупрежден, что в случае ввода ограничения подачи электрической энергии за задолженность, в соответствии с п. ' + 
							CASE 
                            	WHEN p.CalcTypeId = 2 THEN '20'
                            	WHEN p.CalcTypeId = 1 THEN '121' 
                            ELSE ''
                            END + ' Правил расходы, связанные ' + 
							'с введением ограничения, приостановлением и возобновлением электроснабжения подлежат возмещению в сумме ' + dbo.Pr_fnsGetCostDisable(AbonentId, 0) + ' ' + 
							'рублей за счет потребителя, в отношении которого осуществлялись указанные действия. '
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
					'Контролер 2 разряда: ' + dbo.Pr_fnsGetShortFNS('', ControllerId, 1) AS PerformerName,
					RouterId,
					CountMonth,
					GroupCount,
					prEventGroup
FROM	@TempPrintList AS p


-- Группировка итоговых сумм отдельной таблицей
-- если таблица @TempPrintList не пустая
IF (SELECT COUNT(AbonentId) AS c FROM @TempPrintList) != 0

-- Уведомления
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
-- Разбивка МКД / ЧС
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
-- Извещения на ограничение
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
-- Разбивка МКД / ЧС
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
-- Ограничение
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
-- Разбивка МКД / ЧС
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
-- Извещения на отключение
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
-- Разбивка МКД / ЧС
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
-- Отключения
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
-- Разбивка МКД / ЧС
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
-- Проверки отключения
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
-- Разбивка МКД / ЧС
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
-- Итого по всей выборке
SELECT		'Итого:' AS prEventName, 
			dbo.Pr_fnsGetNumberSeparate(COUNT(tp.AbonentId), NULL, 1) AS Count, 
			dbo.Pr_fnsGetNumberSeparate(SUM(tp.Balance), NULL, NULL) AS Sum, 
			90 AS EventTypeId
FROM		Pr_OioEventsTypes AS OioET 
INNER JOIN	@TempPrintList AS tp 
			ON OioET.KVZ_EventTypeId = tp.KVZ_EventTypeId 
			AND OioET.prHouseTypeId = tp.prHouseTypeId

-- если таблица @TempPrintList пустая
-- делаем холостую выборку
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
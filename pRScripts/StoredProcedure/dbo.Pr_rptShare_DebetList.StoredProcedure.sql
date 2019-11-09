IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_rptShare_DebetList' AND type = 'P')
    DROP PROCEDURE dbo.Pr_rptShare_DebetList
GO
CREATE PROCEDURE dbo.Pr_rptShare_DebetList
/*
	=====================================
	|	Расширенный список должников	|
	=====================================
*/	
	@TSOId							INT = NULL,
	@ChiefId						INT = NULL,
	@ControllerId 					INT = NULL,
	@RouterId 						INT = NULL,
	@RouterMultyStringId 			VARCHAR(MAX) = NULL, 	-- мультифильтр для маршрутов
	@GKOid							INT = NULL,
	@GKHid	 						INT = NULL,
	@GKHMultyStringId 				VARCHAR(MAX) = NULL,	-- мультифильтр для УК
	@ArealId 						INT = NULL,
	@CityVillageId 					INT = NULL,
	@StreetId 						INT = NULL,
	@MultiStreetsStringId	 		VARCHAR(MAX) = NULL,	-- мультифильтр для улиц
	@PeriodMin_3005 				INT = NULL,
	@PeriodMax_3005 				INT = NULL,
	@PeriodMin_3201 				INT = NULL,
	@PeriodMax_3201 				INT = NULL,
	@BalanceMin						INT = 0,
	@BalanceMax						INT = 999999,
	@BalanceType 					BIT = 0, -- 0 - статическое / 1 - динамическое
	@PointStatusId 					INT = NULL,
	@AbonentStatusId 				INT = NULL,
	@ExtAbonentStatusId 			INT = NULL,
	@AbonentStatusMultyStringId 	VARCHAR(MAX) = NULL	-- мультифильтр для причин статуса

AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке
-- последний закрытый период
DECLARE @PeriodNumber INT 
SELECT @PeriodNumber = MAX(ap.PeriodNumber) 
FROM AccountingPeriods ap 
WHERE ap.MonthStatus = 2 
GROUP BY ap.PeriodNumber

DECLARE @tReport TABLE(
	PointId INT,
	AbonentId INT,
	CountMonthPoint INT,
	CountMonthAbonent INT,
	AbonNumber VARCHAR(32),
	PointNumber VARCHAR(20),
	FNP VARCHAR(152),
	Phone VARCHAR(88),
	email VARCHAR(50),
	[Address] VARCHAR(530),
	ArealId INT,
	CityVillageId INT,
	StreetId INT,
	CloseBalance MONEY,
	DinamicBalance DECIMAL(14,2),
	LastDtPay SMALLDATETIME,
	LastSumPay MONEY,
	ChiefName VARCHAR(100),
	ChiefId INT,
	ControllerName VARCHAR(100),
	ControllerId INT,
	RouterId INT,
	Router VARCHAR(30),
	DtChange_p SMALLDATETIME,
	PointStatus VARCHAR(50),
	AccountStatusId INT,
	DtChange_a SMALLDATETIME,
	AbonentStatus VARCHAR(50),
	AbonentStatusId INT,
	AbonentReason VARCHAR(200),
	ExtAbonentStatusId INT,
	HouseType VARCHAR(50),
	HouseTypeId INT,
	CalcType VARCHAR(50),
	CalcTypeId INT,
	HousingOptionId INT,
	HousingOption VARCHAR(50),
	GKOName VARCHAR(100),
	GKOId INT, 
	GKHName VARCHAR(100), 
	GKHid INT,
	TSOName VARCHAR(100), 
	TSOId INT, 
	CounterType VARCHAR(160),
	CounterPlace VARCHAR(80),
	CounterNumber VARCHAR(30),
	DtLastIndication SMALLDATETIME,
	SumCharges_15_16 MONEY,
	SumPayments_15_16 MONEY,
	DtDoc_15_16 SMALLDATETIME, 
	Balance_15_16 MONEY, 
	DateOfBirth SMALLDATETIME, 
	DtDeath SMALLDATETIME, 
	e1_Plan DATE,e1_Fact DATE, e1_DocSum MONEY, e1_DocNumber VARCHAR(20), e1_ControllerName VARCHAR(30), e1_DMethod VARCHAR(250), 
	e2_Plan DATE, e2_Fact DATE, e2_DocSum MONEY, e2_DocNumber VARCHAR(20), e2_ControllerName VARCHAR(30), e2_DMethod VARCHAR(250), 
	e3_Plan DATE, e3_Fact DATE, e3_DocSum MONEY, e3_ControllerName VARCHAR(30), 
	e5_Plan DATE, e5_Fact DATE, e5_DocSum MONEY, e5_DocNumber VARCHAR(20), e5_ControllerName VARCHAR(30), e5_DMethod VARCHAR(250), 
	e6_Plan DATE, e6_Fact DATE, e6_DocSum MONEY, e6_ControllerName VARCHAR(30), 
	e11_Plan DATE, e11_Fact DATE, e11_DocSum MONEY, e11_ControllerName VARCHAR(30), e11_DMethod VARCHAR(250), 
	e36_Plan DATE, e36_Fact DATE, e36_DocSum MONEY, e36_ControllerName VARCHAR(30), 
	e30_Plan DATE, e30_Fact DATE, e30_DocSum MONEY, e30_DocNumber VARCHAR(20), e30_ControllerName VARCHAR(30), 
	e31_Plan DATE, e31_Fact DATE, e31_DocSum MONEY, e31_ControllerName VARCHAR(30), 
	e32_Plan DATE, e32_Fact DATE, e32_DocSum MONEY, e32_ControllerName VARCHAR(30), 
	e37_Plan DATE, e37_Fact DATE, e37_DocSum MONEY, e37_ControllerName VARCHAR(30), e37_DMethod VARCHAR(250), 
	e33_Plan DATE, e33_Fact DATE, e33_DocSum MONEY, e33_ControllerName VARCHAR(30), e33_DMethod VARCHAR(250), 
	e35_Plan DATE, e35_Fact DATE, e35_DocSum MONEY, e35_ControllerName VARCHAR(30), 
	e14_Plan DATE, e14_Fact DATE, e14_DocSum MONEY, e14_ControllerName VARCHAR(30), 
	e15_Plan DATE, e15_Fact DATE, e15_DocSum MONEY, e15_ControllerName VARCHAR(30), 
	e38_Plan DATE, e38_Fact DATE, e38_DocSum MONEY, e38_ControllerName VARCHAR(30), e38_DMethod VARCHAR(250), 
	e16_Plan DATE, e16_Fact DATE, e16_DocSum MONEY, e16_ControllerName VARCHAR(30), 
	e17_Plan DATE, e17_Fact DATE, e17_DocSum MONEY, e17_ControllerName VARCHAR(30), 
	e19_Plan DATE, e19_Fact DATE, e19_DocSum MONEY, e19_ControllerName VARCHAR(30), 
	e18_Plan DATE, e18_Fact DATE, e18_DocSum MONEY, e18_ControllerName VARCHAR(30), 
	e20_Plan DATE, e20_Fact DATE, e20_DocSum MONEY, e20_ControllerName VARCHAR(30), 
	Notes VARCHAR(1000)
)
INSERT INTO @tReport
SELECT 		cmMain.PointId, 
			a.AbonentId, 
			cmMain.CountMonth AS CountMonthPoint, 
			ISNULL(oio.CountMonth, - 1) AS CountMonthAbonent, 
			'''' + a.AbonNumber, 
			'''' + p_.PointNumber, 
     		aow.FNP, 
			LTRIM(CAST(ISNULL(a.Phone, '') AS VARCHAR(20))) + ', ' + 
			LTRIM(CAST(ISNULL(a.PhoneMobile, '') AS VARCHAR(20))) + ', ' + 
			CASE WHEN LTRIM(CAST(ISNULL(a.PhoneProfiles, '') AS VARCHAR(20))) = '' THEN '' ELSE 'а' END + 
			LTRIM(CAST(ISNULL(a.PhoneProfiles, '') AS VARCHAR(20))) + ', ' + 
			CASE WHEN LTRIM(CAST(ISNULL(a.PhoneMobileProfiles, '') AS VARCHAR(20))) = '' THEN '' ELSE 'а' END + 
			LTRIM(CAST(ISNULL(a.PhoneMobileProfiles, '') AS VARCHAR(20))) AS Phone, 
			a.email, 
			a.CommAddressString AS Address,
			td.ArealId,
			td.CityVillageId,
			td.StreetId,
      		cmMain.SumBalance * -1 AS CloseBalance, 
			vPointBalansedTm.Balans * -1 AS DinamicBalance, 
			lp.LastDtdoc AS LastDtPay, 
			lp.LastSumPay, 
			dbo.Pr_fnsGetShortFNS('', (SELECT ig.ChiefInspectorId FROM InspectorGroups AS ig WHERE ig.InspectorId = a.ControllerId), 1) AS ChiefName,
			(SELECT ig.ChiefInspectorId FROM InspectorGroups AS ig WHERE ig.InspectorId = a.ControllerId) AS ChiefId,
			dbo.Pr_fnsGetShortFNS('', a.ControllerId, 1) AS ControllerName, 
			a.ControllerId,
			(a.ControllerId + 10000) - (SELECT pa1.RouterId FROM Pr_Abonents pa1 WHERE pa1.AbonentId = a.AbonentId) AS RouterId,
			(SELECT pr.Name FROM Pr_Routers pr WHERE pr.RouterId = (SELECT pa1.RouterId FROM Pr_Abonents pa1 WHERE pa1.AbonentId = a.AbonentId)) AS Router,
			hp.DtChange AS DtChange_p, 
			aSt.Name AS PointStatus, 
			aSt.AccountStatusId, 
			ha.DtChange AS DtChange_a, 
  			abSt.Name AS AbonentStatus, 
			abSt.AbonentStatusId, 
			eabSt.Name AS AbonentReason, 
			eabSt.ExtAbonentStatusId, 
			ht.Name AS HouseType, 
			ht.HouseTypeId, 
 			ct_1.CalcTypeName AS CalcType, 
			ct_1.CalcTypeId, 
			ho.HousingOptionId, 
			ho.Name AS HousingOption, 
			gko.GKOName, 
			gko.GKOId, 
			gkh.GKHName, 
			gkh.GKHid, 
   			pnw.TSOName, 
			pnw.TSOId, 
			CAST(ct.OldTypeId AS varchar) + ' - ' + ct.Name + ' (МПИ - ' + CAST(ct.IntervalVerify AS varchar) + '; зн. - ' + CAST(ct.Signs AS varchar) + ')' AS CounterType, 
			cp.Name AS CounterPlace, 
			'''' + hc.CounterNumber AS CounterNumber,
			li.DtDoc AS DtLastIndication, 
			Doptc.SumCharges_15_16, 
			Doptp.SumPayments_15_16, 
			Dopld.DtDoc_15_16, 
         	Dopb.Balance_15_16, 
			fm.DateOfBirth, 
			fm.DtDeath, 
			oio.e1_Plan, oio.e1_Fact, oio.e1_DocSum, oio.e1_DocNumber, oio.e1_ControllerName, oio.e1_DMethod, 
    		oio.e2_Plan, oio.e2_Fact, oio.e2_DocSum, oio.e2_DocNumber, oio.e2_ControllerName, oio.e2_DMethod, 
			oio.e3_Plan, oio.e3_Fact, oio.e3_DocSum, oio.e3_ControllerName, 
			oio.e5_Plan, oio.e5_Fact, oio.e5_DocSum, oio.e5_DocNumber, oio.e5_ControllerName, oio.e5_DMethod, 
			oio.e6_Plan, oio.e6_Fact, oio.e6_DocSum, oio.e6_ControllerName, 
			oio.e11_Plan, oio.e11_Fact, oio.e11_DocSum, oio.e11_ControllerName, oio.e11_DMethod, 
			oio.e36_Plan, oio.e36_Fact, oio.e36_DocSum, oio.e36_ControllerName, 
			oio.e30_Plan, oio.e30_Fact, oio.e30_DocSum, oio.e30_DocNumber, oio.e30_ControllerName, 
			oio.e31_Plan, oio.e31_Fact, oio.e31_DocSum, oio.e31_ControllerName, 
			oio.e32_Plan, oio.e32_Fact, oio.e32_DocSum, oio.e32_ControllerName, 
			oio.e37_Plan, oio.e37_Fact, oio.e37_DocSum, oio.e37_ControllerName, oio.e37_DMethod, 
			oio.e33_Plan, oio.e33_Fact, oio.e33_DocSum, oio.e33_ControllerName, oio.e33_DMethod, 
			oio.e35_Plan, oio.e35_Fact, oio.e35_DocSum, oio.e35_ControllerName, 
			oio.e14_Plan, oio.e14_Fact, oio.e14_DocSum, oio.e14_ControllerName, 
			oio.e15_Plan, oio.e15_Fact, oio.e15_DocSum, oio.e15_ControllerName, 
			oio.e38_Plan, oio.e38_Fact, oio.e38_DocSum, oio.e38_ControllerName, oio.e38_DMethod, 
			oio.e16_Plan, oio.e16_Fact, oio.e16_DocSum, oio.e16_ControllerName, 
			oio.e17_Plan, oio.e17_Fact, oio.e17_DocSum, oio.e17_ControllerName, 
			oio.e19_Plan, oio.e19_Fact, oio.e19_DocSum, oio.e19_ControllerName, 
			oio.e18_Plan, oio.e18_Fact, oio.e18_DocSum, oio.e18_ControllerName, 
			oio.e20_Plan, oio.e20_Fact, oio.e20_DocSum, oio.e20_ControllerName, 
			oio.Notes
FROM Pr_GKStructure AS gks 
INNER JOIN Pr_GKH AS gkh 
INNER JOIN Pr_Abonents AS pa ON gkh.GKHid = pa.GKHid ON gks.Id = gkh.GKHid
INNER JOIN Pr_GKO AS gko ON gks.ParentId = gko.GKOId 
RIGHT OUTER JOIN FamilyMembers AS fm 
INNER JOIN ExtAbonentStatus AS eabSt 
INNER JOIN vPr_HistoryMaxAbonents AS ha 
INNER JOIN Points AS p_ ON ha.AbonentId = p_.AbonentId 
INNER JOIN vAbonentOwners AS aow ON p_.AbonentId = aow.AbonentId 
INNER JOIN vAbonents AS a ON p_.AbonentId = a.AbonentId
INNER JOIN TAddressDict AS td ON a.AddressPartId = td.AddressPartId 
INNER JOIN AbonentStatus AS abSt ON ha.AbonentStatusId = abSt.AbonentStatusId ON eabSt.ExtAbonentStatusId = ha.ExtAbonentStatusId 
INNER JOIN vPointBalansedTm ON p_.PointId = vPointBalansedTm.pointid 
INNER JOIN HouseTypes AS ht ON a.HouseTypeId = ht.HouseTypeId 
INNER JOIN vPr_HistoryMaxCounters AS hc ON p_.PointId = hc.PointId 
INNER JOIN CounterTypes AS ct ON hc.CounterTypeId = ct.CounterTypeId 
INNER JOIN CounterPlace AS cp ON hc.CounterPlaceId = cp.CounterPlaceId ON fm.FamilyMemberId = aow.FamilyMemberId 
INNER JOIN OiOCalcTypes AS ct_1 ON a.CalcTypeId = ct_1.CalcTypeId 
INNER JOIN Pr_HousingOptionId AS ho ON a.HousingOptionId = ho.HousingOptionId ON pa.AbonentId = p_.AbonentId 
LEFT OUTER JOIN dbo.Pr_fntGetOIOData() AS oio ON p_.AbonentId = oio.AbonentId 
RIGHT OUTER JOIN AccountStatus AS aSt 
INNER JOIN Pr_OioCountMonthPoint AS cmMain 
INNER JOIN vPr_HistoryMaxPoints AS hp ON cmMain.PointId = hp.PointId ON aSt.AccountStatusId = hp.AccountStatusId 
LEFT OUTER JOIN Pr_TSO AS pnw 
INNER JOIN Pr_Points AS pp_ ON pnw.TSOId = pp_.TSOId ON cmMain.PointId = pp_.PointId 
LEFT OUTER JOIN	(	-- сумма платежей по доп.счетам
				SELECT	sa.PointId, 
						ISNULL(SUM(b.SumPayments), $0) AS SumPayments_15_16
      			FROM 	Accounts AS sa 
				INNER JOIN BalanceOfClosedMonths AS b ON b.AccountId = sa.AccountId
            	WHERE (sa.PlanId = 15 OR sa.PlanId = 16)
            	GROUP BY sa.PointId
				) AS Doptp ON cmMain.PointId = Doptp.PointId 
LEFT OUTER JOIN	(	-- сальдо на допсчетах
				SELECT	sa.PointId, 
						ISNULL(SUM(b.SumBalance), $0) AS Balance_15_16
       			FROM	Accounts AS sa 
				INNER JOIN BalanceOfClosedMonths AS b ON b.AccountId = sa.AccountId
          		WHERE (sa.PlanId = 15 OR sa.PlanId = 16) AND b.PeriodNumber = @PeriodNumber
             	GROUP BY sa.PointId
				) AS Dopb ON cmMain.PointId = Dopb.PointId 
LEFT OUTER JOIN	( 	-- дата последнего начисление по доп.счетам
				SELECT	sa.PointId, 
						MAX(d.DtDoc) AS DtDoc_15_16
          		FROM	Accounts AS sa 
				INNER JOIN JournalOfWiring AS j ON j.AccountId = sa.AccountId 
				INNER JOIN Documents AS d ON d.DocumentId = j.DocumentId
          		WHERE (sa.PlanId = 15 OR sa.PlanId = 16) AND j.WiringTypeId = 2
         		GROUP BY sa.PointId
				) AS Dopld ON cmMain.PointId = Dopld.PointId 
LEFT OUTER JOIN	(	-- сумма начислений по доп. счетам
				SELECT	sa.PointId, 
						ISNULL(SUM(b.SumCharges), $0) AS SumCharges_15_16
				FROM	Accounts AS sa 
				INNER JOIN BalanceOfClosedMonths AS b ON b.AccountId = sa.AccountId
      			WHERE (sa.PlanId = 15) OR (sa.PlanId = 16)
   				GROUP BY sa.PointId
				) AS Doptc ON cmMain.PointId = Doptc.PointId 
LEFT OUTER JOIN	(	-- дата и сумма последнего платежа
				SELECT	pp.PointId, pp.LastDtdoc, SUM(vp.SumPayment) AS LastSumPay
          		FROM	(
						SELECT	p.PointId, MAX(d.DtDoc) AS LastDtdoc
      					FROM	Points AS p1 
						INNER JOIN Documents AS d ON d.AbonentId = p1.AbonentId 
						INNER JOIN Receipts AS r ON d.DocumentId = r.ReceiptId 
						INNER JOIN Payments AS p ON p.ReceiptId = r.ReceiptId
                 		GROUP BY p.PointId
						) AS pp 
				INNER JOIN vPayments AS vp ON pp.PointId = vp.PointId AND pp.LastDtdoc = vp.DtReceipt
          		GROUP BY pp.PointId, pp.LastDtdoc
				) AS lp ON cmMain.PointId = lp.PointId 
LEFT OUTER JOIN (	-- дата последнего ФП
				SELECT	PointId, DtDoc
            	FROM	(
						SELECT	p.PointId, MAX(d.DtDoc) AS DtDoc
                		FROM	Points AS p 
						INNER JOIN MemoOrders AS m ON m.PointId = p.PointId 
						INNER JOIN Documents AS d ON d.DocumentId = m.DocumentId AND d.AbonentId = p.AbonentId AND d.DocumentTypeId IN (2, 3, 5) AND d.StateId = 5 
						INNER JOIN ChargePacks AS c ON c.PackId = m.PackId AND c.PackTypeId IN (0, 2)
                    	GROUP BY p.PointId
						) AS d_1
				) AS li ON cmMain.PointId = li.PointId ON p_.PointId = cmMain.PointId
WHERE        	cmMain.DebtTypeId = 1 AND cmMain.PeriodNumber = @PeriodNumber
ORDER BY		a.Areal, a.CityVillage, a.Street, a.House, a.LetterHouse, a.Room, a.LetterRoom, a.RoomNumber

-- Применение фильтров
IF @TSOId IS NOT NULL BEGIN DELETE FROM @tReport WHERE TSOId != @TSOId END
IF @ChiefId IS NOT NULL BEGIN DELETE FROM @tReport WHERE ChiefId != @ChiefId END
IF @ControllerId IS NOT NULL BEGIN DELETE FROM @tReport WHERE ControllerId != @ControllerId END
IF @RouterId IS NOT NULL BEGIN DELETE FROM @tReport WHERE RouterId != @RouterId END
IF @RouterMultyStringId IS NOT NULL BEGIN DELETE FROM @tReport WHERE RouterId NOT IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@RouterMultyStringId,',')) END
IF @GKOid IS NOT NULL BEGIN DELETE FROM @tReport WHERE GKOId != @GKOid END
IF @GKHid IS NOT NULL BEGIN DELETE FROM @tReport WHERE GKHid != @GKHid END
IF @GKHMultyStringId IS NOT NULL BEGIN DELETE FROM @tReport WHERE GKHid NOT IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@GKHMultyStringId,',')) END
IF @ArealId IS NOT NULL BEGIN DELETE FROM @tReport WHERE ArealId != @ArealId END
IF @CityVillageId IS NOT NULL BEGIN DELETE FROM @tReport WHERE CityVillageId != @CityVillageId END
IF @StreetId IS NOT NULL BEGIN DELETE FROM @tReport WHERE StreetId != @StreetId END
IF @MultiStreetsStringId IS NOT NULL BEGIN DELETE FROM @tReport WHERE StreetId NOT IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@MultiStreetsStringId,',')) END
DELETE FROM @tReport WHERE CountMonthPoint NOT BETWEEN @PeriodMin_3005 AND @PeriodMax_3005
DELETE FROM @tReport WHERE CountMonthAbonent NOT BETWEEN @PeriodMin_3201 AND @PeriodMax_3201
IF @BalanceType = 0 BEGIN DELETE @tReport WHERE CloseBalance NOT BETWEEN @BalanceMin AND @BalanceMax END
IF @BalanceType = 1 BEGIN DELETE @tReport WHERE DinamicBalance NOT BETWEEN @BalanceMin AND @BalanceMax END
IF @PointStatusId IS NOT NULL BEGIN DELETE FROM @tReport WHERE AccountStatusId != @PointStatusId END
IF @AbonentStatusId IS NOT NULL BEGIN DELETE FROM @tReport WHERE AbonentStatusId != @AbonentStatusId END
IF @ExtAbonentStatusId IS NOT NULL BEGIN DELETE FROM @tReport WHERE ExtAbonentStatusId != @ExtAbonentStatusId END
IF @AbonentStatusMultyStringId IS NOT NULL BEGIN DELETE FROM @tReport WHERE ExtAbonentStatusId NOT IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@AbonentStatusMultyStringId,',')) END

SELECT 	CountMonthPoint AS [Период ДЗ 30-05], 
		CountMonthAbonent AS [Период ДЗ 32-01], 
		AbonNumber AS [Номер абонента], 
		PointNumber AS [Номер ТУ], 
		FNP AS [ФИО], 
		Phone AS [Контакты], 
		email AS [Эл. почта], 
		Address AS [Адрес], 
		CloseBalance AS [Стат. сальдо], 
		DinamicBalance AS [Динам. сальдо], 
		LastDtPay AS [Последн.платеж, дт], 
		LastSumPay AS [Послед. платеж, р],
		ISNULL(ChiefName, 'Не назначен') AS [Ст.контроллер], 
		ISNULL(ControllerName, 'Не назначен') AS [Контролер], 
		Router AS [Маршрут],
		PointStatus AS [Статус ТУ],
		DtChange_p AS [Дата изменения ],
		AbonentStatus AS [Статус абонента], 
		AbonentReason AS [Причина статуса],   
		DtChange_a AS [Дата изменения],  
		HouseType AS [Тип жилья], 
		CalcType AS [Метод расчета ДЗ], 
		HousingOption AS [Параметр жилья], 
		GKOName AS [ЖКО], 
		GKHName AS [ЖКХ], 
		TSOName AS [ТСО], 
		CounterType AS [Тип ПУ], 
		CounterPlace AS [Место установки ПУ], 
		CounterNumber AS [Номер ПУ],
		DtLastIndication AS [Последние ФП], 
		SumCharges_15_16 AS [ДС всего начислено],
		SumPayments_15_16 AS [ДС всего оплачено], 
		DtDoc_15_16 AS [ДС дата посл.счета], 
		Balance_15_16 AS [ДС сальдо], 
		DateOfBirth AS [Дата рождения], 
		DtDeath AS [Дата смерти], 
		e1_Plan AS [Уведомление, П], 
		e1_Fact AS [Уведомление, Ф], 
		e1_DocSum AS [Уведомление, Руб], 
		e1_DocNumber AS [Уведомление, №], 
		e1_ControllerName AS [Уведомление, К], 
		e1_DMethod AS [Уведомление, М], 
		e2_Plan AS [Извещение на огр, П], 
		e2_Fact AS [Извещение на огр, Ф], 
		e2_DocSum AS [Извещение на огр, Р], 
		e2_DocNumber AS [Извещение на огр, №], 
		e2_ControllerName AS [Извещение на огр, К], 
		e2_DMethod AS [Извещение на огр, М], 
		e3_Plan AS [Ограничение, П], 
		e3_Fact AS [Ограничение, Ф], 
		e3_DocSum AS [Ограничение, Р], 
		e3_ControllerName AS [Ограничение, К], 
		e5_Plan AS [Извещение на откл, П], 
		e5_Fact AS [Извещение на откл, Ф], 
		e5_DocSum AS [Извещение на откл, Р], 
		e5_DocNumber AS [Извещение на откл, №], 
		e5_ControllerName AS [Извещение на откл, К], 
		e5_DMethod AS [Извещение на откл, М], 
		e6_Plan AS [Отключение, П], 
		e6_Fact AS [Отключение, Ф], 
		e6_DocSum AS [Отключение, Р], 
		e6_ControllerName AS [Отключение, К], 
		e11_Plan AS [Посл.проверка отключения, П], 
		e11_Fact AS [Посл.проверка отключения, Ф], 
		e11_DocSum AS [Посл.проверка отключения, Р], 
		e11_ControllerName AS [Посл.проверка отключения, К], 
		e11_DMethod AS [Посл.проверка отключения, М], 
		e36_Plan AS [Оформление СП, П], 
		e36_Fact AS [Оформление СП, Ф], 
		e36_DocSum AS [Оформление СП, Р], 
		e36_ControllerName AS [Оформление СП, К], 
		e30_Plan AS [Передано заявление в суд, П], 
		e30_Fact AS [Передано заявление в суд, Ф], 
		e30_DocSum AS [Передано заявление в суд, Р], 
		e30_DocNumber AS [Передано заявление в суд, №], 
		e30_ControllerName AS [Передано заявление в суд, К], 
		e31_Plan AS [Вынесение суд. приказа, П], 
		e31_Fact AS [Вынесение суд. приказа, Ф], 
		e31_DocSum AS [Вынесение суд. приказа, Р], 
		e31_ControllerName AS [Вынесение суд. приказа, К], 
		e32_Plan AS [Вынесение суд. приказа, П], 
		e32_Fact AS [Вынесение суд. приказа, Ф], 
		e32_DocSum AS [Вынесение суд. приказа, Р], 
		e32_ControllerName AS [Вынесение суд. приказа, К], 
		e37_Plan AS [Возврат СП из суда, П], 
		e37_Fact AS [Возврат СП из суда, Ф], 
		e37_DocSum AS [Возврат СП из суда, Р], 
		e37_ControllerName AS [Возврат СП из суда, К], 
		e37_DMethod AS [Возврат СП из суда, М], 
		e33_Plan AS [Направлено в ССП, П], 
		e33_Fact AS [Направлено в ССП, Ф], 
		e33_DocSum AS [Направлено в ССП, Р], 
		e33_ControllerName AS [Направлено в ССП, К], 
		e33_DMethod AS [Направлено в ССП, М], 
		e35_Plan AS [Оформление ИЗ, П], 
		e35_Fact AS [Оформление ИЗ, Ф], 
		e35_DocSum AS [Оформление ИЗ, Р], 
		e35_ControllerName AS [Оформление ИЗ, К], 
		e14_Plan AS [Передан в суд, П], 
		e14_Fact AS [Передан в суд, Ф], 
		e14_DocSum AS [Передан в суд, Р], 
		e14_ControllerName AS [Передан в суд, К], 
		e15_Plan AS [Решение суда, П], 
		e15_Fact AS [Решение суда, Ф], 
		e15_DocSum AS [Решение суда, Р], 
		e15_ControllerName AS [Решение суда, К], 
		e38_Plan AS [Отказано судом, П], 
		e38_Fact AS [Отказано судом, Ф], 
		e38_DocSum AS [Отказано судом, Р], 
		e38_ControllerName AS [Отказано судом, К], 
		e38_DMethod AS [Отказано судом, М], 
		e16_Plan AS [Передан в ССП, П], 
		e16_Fact AS [Передан в ССП, Ф], 
		e16_DocSum AS [Передан в ССП, Р], 
		e16_ControllerName AS [Передан в ССП, К], 
		e17_Plan AS [Запрос в ССП, П], 
		e17_Fact AS [Запрос в ССП, Ф], 
		e17_DocSum AS [Запрос в ССП, Р], 
		e17_ControllerName AS [Запрос в ССП, К], 
		e19_Plan AS [Рейд с СП, П], 
		e19_Fact AS [Рейд с СП, Ф], 
		e19_DocSum AS [Рейд с СП, Р], 
		e19_ControllerName AS [Рейд с СП, К], 
		e18_Plan AS [Передан на списание, П], 
		e18_Fact AS [Передан на списание, Ф], 
		e18_DocSum AS [Передан на списание, Р], 
		e18_ControllerName AS [Передан на списание, К], 
		e20_Plan AS [Запрос в суд, П], 
		e20_Fact AS [Запрос в суд, Ф], 
		e20_DocSum AS [Запрос в суд, Р], 
		e20_ControllerName AS [Запрос в суд, К], 
 		Notes AS [Пометки]
FROM @tReport
GO
GRANT EXECUTE ON dbo.Pr_rptShare_DebetList TO KvzWorker
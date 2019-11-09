IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_PointsPublic_MiscFunctions' AND type = 'P')
    DROP PROCEDURE dbo.Pr_PointsPublic_MiscFunctions
GO
CREATE PROCEDURE dbo.Pr_PointsPublic_MiscFunctions
/*
	=====================================
	|	Основные процедуры для модуля	|
	|	распределения ОДН				|
	=====================================
*/	
	@SectionId		INT = NULL,
	@PublicPointId 	INT = 0, 
	@SchemeId		INT = NULL,
	@YEAR			INT = NULL,			
	@MONTH			INT = NULL,
	@Function		INT = 0		-- 0 - дерево домов с ОДПУ
						  		-- 1 - список ТУ принадлежащих дому
								-- 2 - история замен
								-- 3 - список ТУ принадлежащих секции
								-- 4 - изменение схемы распределения ОДН
								-- 4 - история начислений секции
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- дерево домов с ОДПУ
IF @Function = 0 BEGIN
	DECLARE @tb AS TABLE(Id INT, ParentId INT, Name VARCHAR(300), PublicPointId INT, AddressHouse VARCHAR(350), IsExpanded BIT)

	-- районы
	INSERT INTO @tb
	SELECT a.AddressPartId AS Id, 0 AS ParentId, a.Name, NULL AS PublicPointId, NULL AS AddressHouse, 1 AS IsExpanded
  	FROM vAddress AS a WHERE a.AddressPartId IN (
												SELECT ParentId
												FROM vAddress AS va
												WHERE AddressPartId IN (
																		SELECT ppa.AddressPartId 
																		FROM PointsPublicAccount AS ppa 
																		GROUP BY ppa.AddressPartId
																		)
												GROUP BY ParentId
												)
	ORDER BY Name, ParentId, Id

	-- улицы
    INSERT INTO @tb
    SELECT DISTINCT va.AddressPartId AS Id, ParentId, Name, NULL, NULL, 0 AS IsExpanded
    FROM vAddress AS va
	RIGHT JOIN PointsPublicAccount AS ppa ON va.AddressPartId = ppa.AddressPartId
	WHERE AddressPartTypeId = 6
	ORDER BY Name, ParentId, Id
	
	-- дома с ОДПУ
	INSERT INTO @tb
    SELECT  p.PublicPointId AS Id, p.AddressPartId AS ParentId,
			CASE WHEN h.AccountStatusId = 2 THEN '(Закрыта) ' ELSE '' END + 
            CASE WHEN p.House = '' THEN '' ELSE ' д.' + p.House END + p.LetterHouse +
            CASE WHEN p.Build = '' THEN '' ELSE '-' + p.Build   END +
            CASE WHEN p.SectionBegin = '' THEN '' ELSE ' сек.' + p.SectionBegin+' ' END +
            CASE WHEN p.RoomBegin = '' THEN '' ELSE ' кв.' END + RTRIM(p.RoomBegin) +
            CASE WHEN p.LetterRoomBegin = '' THEN '' ELSE '/' END + p.LetterRoomBegin + ' ' +
	        CASE WHEN p.RoomEnd != '' THEN '...' +
            CASE WHEN p.SectionEnd = '' THEN '' ELSE ' сек.'+p.SectionEnd+' ' END +
         	CASE WHEN p.RoomEnd = '' THEN '' ELSE ' кв.' END + RTRIM(p.RoomEnd) +
			CASE WHEN p.LetterRoomEnd = '' THEN '' ELSE '/' END + p.LetterRoomEnd
       		ELSE ''
            END AS Name, p.PublicPointId, p.AddressString + ' д.' + p.House + p.LetterHouse + CASE WHEN p.Build != '' THEN ' корп.' + p.Build ELSE '' END,
			0 AS IsExpanded
    FROM vPointsPublicAccount p 
    INNER JOIN vSchemes_PointsPublicHistory_DtEnd h ON h.PublicPointId = p.PublicPointId AND GETDATE() BETWEEN h.DtChange AND h.DtEnd
    WHERE h.AccountStatusId = 1
	ORDER BY Name, ParentId, Id

	-- секции
	INSERT INTO @tb
	SELECT 	ppps.SectionId AS Id, ppps.PublicPointId AS ParentId, 
			'Секция № ' + CAST(ppps.SectionRoomNumber AS VARCHAR) + ' (№л/с ' + CAST(ppps.SectionNumber AS VARCHAR) + ')' AS Name, ppps.PublicPointId,
			NULL, 0 AS IsExpanded
	FROM Pr_PointsPublicSections AS ppps
    ORDER BY CAST(dbo.Pr_fnStripNonDigits(ppps.SectionRoomNumber) AS INT), ParentId, Id

	SELECT * FROM @tb
END

-- получаем список ТУ принадлежащих дому
-- выборка среди ТУ подключенных к дому с ОДУ c исключением снятых с учета по всем параметрам
IF @Function = 1 BEGIN
	SELECT	CAST(CASE WHEN EXISTS(SELECT * FROM Pr_PointsPublicSectionsConn AS pppsc WHERE pppsc.PointId = ppc.PointId) THEN 1 ELSE 0 END AS BIT) AS Checked, -- пустые чекбоксы для текущего выбора
			CAST(CASE WHEN EXISTS(SELECT * FROM Pr_PointsPublicSectionsConn AS pppsc WHERE pppsc.PointId = ppc.PointId) THEN 1 ELSE 0 END AS BIT) AS IsConnection,
			ppc.PointId, 
			(SELECT p1.PointNumber FROM Points AS p1 WHERE p1.PointId = p.PointId) AS PointNumber, 
			ISNULL(mfm.SurName + ' ' + mfm.Name + ' ' + mfm.Patronymic, 'Собственник не определен') AS SNP,
			'Секция № ' + CAST(ppps.SectionRoomNumber AS VARCHAR) AS Connect, 
       		a.CommAddressString AS Address,
			l.CountLodgers,
			a.SquareTotal
	FROM	Pr_PointsPublicSections AS ppps 
	INNER JOIN Pr_PointsPublicSectionsConn AS pppsc ON ppps.SectionId = pppsc.SectionId 
	RIGHT OUTER JOIN (SELECT * FROM PointsPublicCommunication AS _ppc WHERE AccountStatusId <> 2 AND DtEnd = '31.12.2078') AS ppc 
	INNER JOIN vPoints_ListPointsStatus AS p ON p.PointId = ppc.PointId AND p.PointStatusId <> 2 AND p.AbonentStatusId = 1 
	INNER JOIN vAbonents AS a ON p.AbonentId = a.AbonentId 
	INNER JOIN vMainFamilyMembers AS mfm ON a.AbonentId = mfm.AbonentId 
	INNER JOIN Lodgers AS l ON a.AbonentId = l.AbonentId AND l.DtEnd = '31.12.2078' ON pppsc.PointId = p.PointId
	INNER JOIN vPr_HistoryMaxCounters AS phmc ON pppsc.PointId = phmc.PointId
	WHERE ppc.PublicPointId = @PublicPointId
	ORDER BY CAST(dbo.Pr_fnStripNonDigits(a.Room) AS INT), 
			 CAST(dbo.Pr_fnStripNonDigits(a.RoomNumber) AS INT), 
			 CAST(dbo.Pr_fnStripNonDigits(a.LetterRoom) AS INT)
END

-- История замен
IF @Function = 2 BEGIN 
	SELECT 	pcsh.SectionId, pcsh.DtCounterSetup, 
			pct.FullCounterName, pcsh.CounterNumber, 
			pcsh.IndicationSetup, pcsh.DtCountRemove, 
			pcsh.IndicationRemove, pcsh.DtUpdate, 
			dbo.Pr_fnsGetShortFNS('', pcsh.UpdaterId, 1) AS Updater 
	FROM Pr_CountersSectionHistory AS pcsh 
	INNER JOIN vPr_cmbCountersType AS pct ON pcsh.CounterTypeId = pct.CounterTypeId
	WHERE pcsh.SectionId = @SectionId
END 

-- список ТУ принадлежащих секции
IF @Function = 3 BEGIN 
	SELECT 	ppps.SectionId, ppps.PublicPointId, pppsc.PointId, p.PointNumber, 
			mfm.SurName + ' ' + mfm.Name + ' ' + mfm.Patronymic AS SNP, 
			a.CommAddressString AS Address, l.CountLodgers, a.SquareTotal, 
			pppsc.DtCreate, dbo.Pr_fnsGetShortFNS('', pppsc.CreaterId, 1) AS Creater,
			pct1. FullCounterName AS CounterName, phmc.CounterNumber
	FROM Pr_PointsPublicSectionsConn AS pppsc
	INNER JOIN Points AS p ON pppsc.PointId = p.PointId
	INNER JOIN vAbonents AS a ON p.AbonentId = a.AbonentId
	INNER JOIN Lodgers AS l ON p.AbonentId = l.AbonentId AND l.DtEnd = '31.12.2078'
	INNER JOIN Pr_PointsPublicSections AS ppps ON pppsc.SectionId = ppps.SectionId
	INNER JOIN vMainFamilyMembers AS mfm ON p.AbonentId = mfm.AbonentId
	INNER JOIN vPr_HistoryMaxCounters AS phmc ON pppsc.PointId = phmc.PointId
	INNER JOIN vPr_cmbCountersType AS pct1 ON phmc.CounterTypeId = pct1.CounterTypeId
	WHERE pppsc.SectionId = @SectionId
	ORDER BY CAST(dbo.Pr_fnStripNonDigits(a.Room) AS INT), 
			 CAST(dbo.Pr_fnStripNonDigits(a.RoomNumber) AS INT), 
			 CAST(dbo.Pr_fnStripNonDigits(a.LetterRoom) AS INT)
END

-- Изменение активной схемы распределения ОДН
IF @Function = 4 BEGIN 
	UPDATE 	Pr_PointsPublicSections 
	SET 	SchemesId = @SchemeId 
	WHERE 	SectionId = @SectionId
END 

-- История начислений секции
IF @Function = 5 BEGIN 
	SELECT 	pppsc.DocumentId,
			pppsc.DtDoc,
			pppsc.OldIndication,
			pppsc.NewIndication,
			pppsc.Consumption,
			ppis.Name AS Source,
			pppsc.DtUpdate,
			dbo.Pr_fnsGetShortFNS('', pppsc.UpdaterId, 1) AS Updater,
			CAST(ap.MonthStatus AS INT) AS MonthStatus
	FROM 	Pr_PointsPublicSectionsCharges AS pppsc
	INNER JOIN PointsPublicIndicationsSource AS ppis ON pppsc.SourceId = ppis.SourceId
	INNER JOIN AccountingPeriods AS ap ON pppsc.PeriodNumber = ap.PeriodNumber
	WHERE 	pppsc.SectionId = @SectionId AND 
			FLOOR(pppsc.PeriodNumber / 100) = ISNULL(@YEAR, FLOOR(pppsc.PeriodNumber / 100)) AND 
			pppsc.PeriodNumber - (FLOOR(pppsc.PeriodNumber / 100) * 100) = ISNULL(@MONTH, pppsc.PeriodNumber - (FLOOR(pppsc.PeriodNumber / 100) * 100))
	ORDER BY pppsc.DtDoc 
END

-- Начисления по секции из Квазара
IF @Function = 6 BEGIN 
	DECLARE @DtStart DATETIME = dbo.Pr_fnsGetFirstDayPeriod(@YEAR * 100 + @MONTH)
	DECLARE @DtEnd DATETIME = dbo.Pr_fnsGetLastDayPeriod(@YEAR * 100 + @MONTH)
	DECLARE @PointId INT
	DECLARE @PointsCharges TABLE(
								Id INT,
								DocumentId INT,
								PointId INT,
								DtDoc DATETIME,
								OldIndication INT,
								NewIndication INT,
								Consumption INT,
								SumPayment MONEY,
								SumCharge MONEY,
								SumBalance MONEY,
								Name VARCHAR(200),
								PlanName VARCHAR(200),
								DocumentTypeId INT,
								RecordLevel INT,
								PackId INT,
								PlanId INT,
								TariffCount MONEY,
								PowerPayms INT,
								ArticleNumber VARCHAR(2),
								Signs TINYINT,
								SumCurBalance MONEY,
								ArticleControlActionId INT,
								PackTypeId INT,
								cPeriodNumber VARCHAR(7),
								DtCreate DATETIME,
								PerformerCreator VARCHAR(300),
								Notes VARCHAR(300),
								PeriodNumber INT,
								DtUpdate SMALLDATETIME,
								Performer VARCHAR(300),
								SumBalanceClosed DECIMAL(38, 16),
								DtBegin DATETIME,
								TariffNotCount MONEY,
								StateId INT,
								SumChargesNorm MONEY,
								SumChargesComp MONEY,
								ExtPackTypeId INT
								)
    
    DECLARE cur CURSOR FAST_FORWARD READ_ONLY LOCAL FOR
    SELECT pppsc.PointId FROM Pr_PointsPublicSectionsConn AS pppsc WHERE pppsc.SectionId = @SectionId
    OPEN cur
    FETCH NEXT FROM cur INTO @PointId
    WHILE @@FETCH_STATUS = 0 BEGIN
		INSERT INTO @PointsCharges
		EXEC Abonents_MiscFunctions17 @PointId = @PointId
    FETCH NEXT FROM cur INTO @PointId
    END    
    CLOSE cur
    DEALLOCATE cur

	DELETE FROM @PointsCharges WHERE DtDoc NOT BETWEEN @DtStart AND @DtEnd
	SELECT 	'{л.с: <b>' + a.AbonNumber + '</b>} ' + 
			'{ФИО: <b>' + ISNULL(fm.SurName + ' ' + fm.Name + ' ' + fm.Patronymic, 'Собственник не определен') + '</b>} ' +  
			'{Адрес: <b>' + a.CommAddressString + '</b>} ' AS GroupString, 
			pc.DocumentId,
			pc.DtDoc, 
			pc.OldIndication, 
			pc.NewIndication, 
			pc.Consumption,  
			pc.SumCharge, 
			pc.SumPayment,
			pc.SumCurBalance,
			pc.SumBalanceClosed, 
			pc.Name, 
			pc.TariffCount, 
			pc.Performer, 
			pc.DtUpdate

	FROM @PointsCharges AS pc
	INNER JOIN Points AS p ON pc.PointId = p.PointId
	INNER JOIN vAbonents AS a ON p.AbonentId = a.AbonentId
	LEFT OUTER JOIN FamilyMembers AS fm ON a.AbonentId = fm.AbonentId AND fm.FamilyRoleId = 1
END 
GO
GRANT EXECUTE ON dbo.Pr_PointsPublic_MiscFunctions TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_rptPaymentDiscipline' AND type = 'P')
    DROP PROCEDURE dbo.Pr_rptPaymentDiscipline
GO
CREATE PROCEDURE dbo.Pr_rptPaymentDiscipline
/*
	=============================================
	|	Платежная дициплина МРО					|
	| 	В основе dbo.Reports_Report22 - Ф22.00 	|
	=============================================
*/
@EnergyTypeId   INT = 1,
@AddressPartId  INT = 1000,
@MonthBegin     INT = 04,
@YearBegin      INT = 2015,
@MonthEnd       INT = 04,
@YearEnd        INT = 2015,
@Period         VARCHAR(50) = '' OUTPUT,
@Function       INT = 32,
@SumBalance     MONEY = -100
AS
SET NOCOUNT ON
SET ANSI_WARNINGS OFF

DECLARE   @PeriodNumber1    INT,
          @PeriodNumber2    INT,
          @PeriodNumber     INT,
          @AttribAccountId  INT,
          @Message          VARCHAR(300),
          @DtBegin          SMALLDATETIME,
          @IdentNumber      INT,
          @DtEnd            SMALLDATETIME,
          @DtBalance        SMALLDATETIME,
          @ParentId         INT,
          @OrganName        VARCHAR(100),
          @CountMonth       INT

CREATE TABLE #Points_TempSumMoneyBalances (PointId INT, SumBalance MONEY, PointNumber VARCHAR(20), AbonNumber VARCHAR(20))
CREATE TABLE #TempTable_SumMoneyBalances (EnergyTypeId INT, AbonentId INT, SumBalance MONEY)
CREATE INDEX Abonent ON #TempTable_SumMoneyBalances (EnergyTypeId, AbonentId)
CREATE TABLE #TempListPoints_SumMoneyBalances (AbonentId INT, PointId INT, DtCurrBalance DATETIME NULL)

SET @Message = CAST(@Function AS VARCHAR(20))
SET @PeriodNumber1 = @YearBegin * 100 + @MonthBegin
SET @PeriodNumber2 = @YearEnd * 100 + @MonthEnd
SET @DtBegin = CAST(@PeriodNumber1 AS CHAR(6)) + '01'
SET @DtEnd = CAST(@PeriodNumber2 AS CHAR(6)) + '01'
SET @DtEnd = DATEADD(mm, 1, @DtEnd) - 1
SET @DtBalance = CAST(@PeriodNumber2 AS CHAR(6)) + '01'
IF EXISTS(SELECT * FROM AccountingPeriods WHERE PeriodNumber = @PeriodNumber2 AND MonthStatus = 2) BEGIN
  SET @DtBalance = DATEADD(mm, 1, @DtBalance) - 1
END

SELECT *
INTO #vRegisterOverhaul
FROM vRegisterOverhaul
CREATE INDEX Point ON #vRegisterOverhaul (PointId, PeriodNumber)

SET @Period = 'За период с ' + dbo.Kernel_CastDateTimeToChar(@DtBegin, 0) + ' по ' + dbo.Kernel_CastDateTimeToChar(@DtEnd, 0)

SELECT @CountMonth = COUNT(*) 
FROM MonthCalendar
WHERE MonthNumber > @PeriodNumber1 AND MonthNumber < @PeriodNumber2

IF @Function = 32 BEGIN
  SELECT @PeriodNumber = MAX(PeriodNumber) FROM AccountingPeriods WHERE MonthStatus = 2
  SET @DtBalance = dbo.Kernel_GetLastDateMonth(CAST(@PeriodNumber AS CHAR(6))+'01')

  CREATE TABLE #TempAbonentsReport22_32 (AbonentId INT, AbonNumber VARCHAR(20), FamilyMemberId INT, DtBegin SMALLDATETIME,
                                         DtClosed SMALLDATETIME, NSF VARCHAR(100), OrganName VARCHAR(100))
  SELECT @ParentId = ParentId, @OrganName = Name
  FROM Organizations WHERE OrganizationId = @AddressPartId

  IF @ParentId IS NOT NULL BEGIN            -- Подразделение
    INSERT INTO #TempAbonentsReport22_32
      SELECT DISTINCT m.AbonentId, e.Num AS AbonNumber, h.FamilyMemberId, h.DtBegin, h.DtClosed,
                      m.SurName + ' ' + m.Name + ' ' + m.Patronymic AS NSP, o.Name AS OrganName
      FROM
          (
            SELECT h.DtBegin, ISNULL(h.DtClosed, '20790101') AS DtClosed, h.FamilyMemberId, h.OrganizationId
            FROM AbonentsHistoryOrganizations h
            WHERE h.OrganizationId = @AddressPartId AND @DtBegin BETWEEN h.DtBegin AND ISNULL(h.DtClosed, '20790101')
          ) h
      INNER JOIN FamilyMembers m ON m.FamilyMemberId = h.FamilyMemberId
      INNER JOIN Organizations o ON o.OrganizationId = h.OrganizationId
      INNER JOIN Elements e      ON e.ElementId = m.AbonentId
  END
  ELSE BEGIN                                -- Организация
    INSERT INTO #TempAbonentsReport22_32
      SELECT DISTINCT m.AbonentId, e.Num AS AbonNumber, h.FamilyMemberId, h.DtBegin, h.DtClosed,
                      m.SurName + ' ' + m.Name + ' ' + m.Patronymic AS NSP, o.Name AS OrganName
      FROM
          (
            SELECT h.DtBegin, ISNULL(h.DtClosed, '20790101') AS DtClosed, h.FamilyMemberId, h.OrganizationId
            FROM AbonentsHistoryOrganizations h
            INNER JOIN Organizations o ON o.OrganizationId = h.OrganizationId
            WHERE o.ParentId = @AddressPartId AND @DtBegin BETWEEN h.DtBegin AND ISNULL(h.DtClosed, '20790101')
          ) h
      INNER JOIN FamilyMembers m ON m.FamilyMemberId = h.FamilyMemberId
      INNER JOIN Organizations o ON o.OrganizationId = h.OrganizationId
      INNER JOIN Elements e      ON e.ElementId = m.AbonentId
  END
  CREATE INDEX AbonNumber ON #TempAbonentsReport22_32 (AbonNumber)

  DELETE #TempAbonentsReport22_32
  FROM #TempAbonentsReport22_32 t
  INNER JOIN AgentContractsCommunication c ON c.AbonentId = t.AbonentId
  INNER JOIN AgentContractsSubjects s ON s.AgentSubjectId = c.AgentSubjectId
  INNER JOIN AgentContractsHistory h ON h.AgentSubjectId = s.AgentSubjectId AND @DtEnd BETWEEN h.DtBegin AND ISNULL(h.DtClosed, '20781231')
  INNER JOIN Points p ON p.AbonentId = c.AbonentId
  INNER JOIN PointsHistory ph ON ph.PointId = p.PointId AND @DtEnd BETWEEN ph.DtChange AND ph.DtEnd AND ph.AccountStatusId = 2
  WHERE p.EnergyTypeId = 1

--- Расчёт сальдо
  DECLARE EnergyCursor CURSOR LOCAL FORWARD_ONLY READ_ONLY FOR
    SELECT EnergyTypeId
    FROM EnergyTypes WHERE AccountStatusId = 1
  OPEN EnergyCursor
  FETCH EnergyCursor INTO @EnergyTypeId
  WHILE(@@FETCH_STATUS = 0) BEGIN
    TRUNCATE TABLE #TempListPoints_SumMoneyBalances
    TRUNCATE TABLE #Points_TempSumMoneyBalances

    INSERT INTO #TempListPoints_SumMoneyBalances (AbonentId, PointId, DtCurrBalance)
      SELECT DISTINCT p.AbonentId, p.PointId, @DtBalance
      FROM #TempAbonentsReport22_32 a
      INNER JOIN Points p ON p.AbonentId = a.AbonentId
      WHERE p.EnergyTypeId = @EnergyTypeId

    IF @EnergyTypeId = 5 BEGIN
      INSERT INTO #Points_TempSumMoneyBalances (PointId, SumBalance, PointNumber, AbonNumber)
        SELECT p.PointId,
               -r.SumInBalance + (-r.SumCharges) + (-r.SumRecharges) + r.SumPayments + (-r.SumPines) + (-r.SumRepines) + r.SumPaymPines,
               r.PointNumber, r.PointNumber
        FROM
        (
          SELECT r.PointId, MAX(r.PeriodNumber) AS PeriodNumber
          FROM #vRegisterOverhaul r
          INNER JOIN #TempListPoints_SumMoneyBalances t ON t.PointId = r.PointId
          GROUP BY r.PointId
        ) p
        INNER JOIN #vRegisterOverhaul r ON r.PointId = p.PointId AND r.PeriodNumber = p.PeriodNumber
    END
    ELSE BEGIN
      EXEC Points_SumMoneyBalances @DtBalance, 10, NULL, NULL, 1, 0, 'Scheme1', 1, @EnergyTypeId, 0
    END

    INSERT INTO #TempTable_SumMoneyBalances (EnergyTypeId, AbonentId, SumBalance)
      SELECT @EnergyTypeId, p.AbonentId, SUM(t.SumBalance)
      FROM #Points_TempSumMoneyBalances t
      INNER JOIN Points p ON p.PointId = t.PointId
      GROUP BY p.AbonentId
    FETCH EnergyCursor INTO @EnergyTypeId
  END
  CLOSE EnergyCursor
  DEALLOCATE EnergyCursor

--- Оплаты для сальдо
  SELECT DISTINCT t.AbonentId, p.EnergyTypeId, ROUND(SUM(ISNULL(w.MoneyAmount, $0)), 2) AS SumPayments
  INTO #TempTable_SumPaymentsBalances
  FROM #TempAbonentsReport22_32 t
  INNER JOIN Points p ON p.AbonentId = t.AbonentId
  INNER JOIN Accounts a ON a.PointId = p.PointId
  INNER JOIN JournalOfWiring j ON j.AccountId = a.AccountId AND j.WiringTypeId = 1
  INNER JOIN PartOfWiring w ON w.WiringId = j.WiringId AND w.PartOfWiringTypeId IN(1, 2)
  INNER JOIN Documents d ON d.DocumentId = j.DocumentId
  WHERE d.DocumentTypeId = 1 AND d.DtDoc > @DtBalance
  GROUP BY t.AbonentId, t.FamilyMemberId, p.EnergyTypeId

--- Оплаты за период
  SELECT DISTINCT t.AbonentId, p.EnergyTypeId, ROUND(SUM(ISNULL(w.MoneyAmount, $0)), 2) AS SumPayments
  INTO #TempTable_SumPayments
  FROM #TempAbonentsReport22_32 t
  INNER JOIN Points p ON p.AbonentId = t.AbonentId
  INNER JOIN Accounts a ON a.PointId = p.PointId
  INNER JOIN JournalOfWiring j ON j.AccountId = a.AccountId AND j.WiringTypeId = 1
  INNER JOIN PartOfWiring w ON w.WiringId = j.WiringId AND w.PartOfWiringTypeId IN(1, 2)
  INNER JOIN Documents d ON d.DocumentId = j.DocumentId
  WHERE d.DocumentTypeId = 1 AND d.PeriodNumber BETWEEN @PeriodNumber1 AND @PeriodNumber2
  GROUP BY t.AbonentId, t.FamilyMemberId, p.EnergyTypeId
  
  IF NOT EXISTS(SELECT * FROM Constants WHERE Name = 'DivisionId' AND Value = '8') BEGIN
    SELECT a.AbonentId,
		   CASE
             WHEN e2.EnergyTypeId IS NOT NULL OR e3.EnergyTypeId IS NOT NULL OR e6.EnergyTypeId IS NOT NULL OR e8.EnergyTypeId IS NOT NULL
             THEN '2' + RIGHT(t.AbonNumber, 11)
             ELSE t.AbonNumber
           END AS AbonNumber,
           t.DtBegin, t.DtClosed, t.NSF, t.OrganName,
           s1.SumPayments AS e1SumPayments, e1.SumBalance + ISNULL(b1.SumPayments, 0) AS e1SumBalance,
           s2.SumPayments AS e2SumPayments, e2.SumBalance + ISNULL(b2.SumPayments, 0) AS e2SumBalance,
           s3.SumPayments + s12.SumPayments AS e3SumPayments, e3.SumBalance + ISNULL(b3.SumPayments, 0) +
           e12.SumBalance + ISNULL(b12.SumPayments, 0) AS e3SumBalance,
           s5.SumPayments AS e5SumPayments, e5.SumBalance + ISNULL(b5.SumPayments, 0) AS e5SumBalance,
           s6.SumPayments AS e6SumPayments, e6.SumBalance + ISNULL(b6.SumPayments, 0) AS e6SumBalance,
           s8.SumPayments AS e8SumPayments, e8.SumBalance + ISNULL(b8.SumPayments, 0) AS e8SumBalance,
           s.Areal+' '+s.CityVillage+' '+s.Street+
             CASE WHEN a.House = '' THEN '' ELSE ' д.'+a.House END +
             a.LetterHouse +
             CASE WHEN a.Build = '' THEN '' ELSE '-'+a.Build   END +
             CASE WHEN a.Room  = '' THEN '' ELSE ' кв.'+a.Room END AS Address
    INTO #TempResult
    FROM #TempAbonentsReport22_32 t
    INNER JOIN Abonents a ON a.AbonentId = t.AbonentId
    INNER JOIN tAddressDict s ON s.AddressPartId = a.AddressPartId
    LEFT JOIN #TempTable_SumMoneyBalances e1 ON e1.AbonentId = t.AbonentId AND e1.EnergyTypeId = 1
    LEFT JOIN #TempTable_SumMoneyBalances e2 ON e2.AbonentId = t.AbonentId AND e2.EnergyTypeId = 2
    LEFT JOIN #TempTable_SumMoneyBalances e3 ON e3.AbonentId = t.AbonentId AND e3.EnergyTypeId = 3
    LEFT JOIN #TempTable_SumMoneyBalances e12 ON e12.AbonentId = t.AbonentId AND e12.EnergyTypeId = 12
    LEFT JOIN #TempTable_SumMoneyBalances e5 ON e5.AbonentId = t.AbonentId AND e5.EnergyTypeId = 5
    LEFT JOIN #TempTable_SumMoneyBalances e6 ON e6.AbonentId = t.AbonentId AND e6.EnergyTypeId = 6
    LEFT JOIN #TempTable_SumMoneyBalances e8 ON e8.AbonentId = t.AbonentId AND e8.EnergyTypeId = 8

    LEFT JOIN #TempTable_SumPayments s1 ON s1.AbonentId = t.AbonentId AND s1.EnergyTypeId = 1
    LEFT JOIN #TempTable_SumPayments s2 ON s2.AbonentId = t.AbonentId AND s2.EnergyTypeId = 2
    LEFT JOIN #TempTable_SumPayments s3 ON s3.AbonentId = t.AbonentId AND s3.EnergyTypeId = 3
    LEFT JOIN #TempTable_SumPayments s12 ON s12.AbonentId = t.AbonentId AND s12.EnergyTypeId = 12
    LEFT JOIN #TempTable_SumPayments s5 ON s5.AbonentId = t.AbonentId AND s5.EnergyTypeId = 5
    LEFT JOIN #TempTable_SumPayments s6 ON s6.AbonentId = t.AbonentId AND s6.EnergyTypeId = 6
    LEFT JOIN #TempTable_SumPayments s8 ON s8.AbonentId = t.AbonentId AND s8.EnergyTypeId = 8

    LEFT JOIN #TempTable_SumPaymentsBalances b1 ON b1.AbonentId = t.AbonentId AND b1.EnergyTypeId = 1
    LEFT JOIN #TempTable_SumPaymentsBalances b2 ON b2.AbonentId = t.AbonentId AND b2.EnergyTypeId = 2
    LEFT JOIN #TempTable_SumPaymentsBalances b3 ON b3.AbonentId = t.AbonentId AND b3.EnergyTypeId = 3
    LEFT JOIN #TempTable_SumPaymentsBalances b12 ON b12.AbonentId = t.AbonentId AND b12.EnergyTypeId = 12
    LEFT JOIN #TempTable_SumPaymentsBalances b5 ON b5.AbonentId = t.AbonentId AND b5.EnergyTypeId = 5
    LEFT JOIN #TempTable_SumPaymentsBalances b6 ON b6.AbonentId = t.AbonentId AND b6.EnergyTypeId = 6
    LEFT JOIN #TempTable_SumPaymentsBalances b8 ON b8.AbonentId = t.AbonentId AND b8.EnergyTypeId = 8
    ORDER BY t.OrganName, t.NSF

    IF @SumBalance >= 0 BEGIN
      SELECT t.DtBegin, t.DtClosed, t.AbonNumber, t.NSF, t.OrganName, t.Address,
             t.e1SumPayments, t.e1SumBalance, t.e2SumPayments, t.e2SumBalance, t.e3SumPayments, t.e3SumBalance,
             t.e6SumPayments, t.e6SumBalance, t.e8SumPayments, t.e8SumBalance,
             t.e5SumPayments, t.e5SumBalance,
			 ISNULL(t.e1SumPayments, $0) + ISNULL(t.e2SumPayments, $0) + ISNULL(t.e3SumPayments, $0) + ISNULL(t.e6SumPayments, $0) + ISNULL(t.e8SumPayments, $0) + ISNULL(t.e5SumPayments, $0) AS TotalPayments,
			 ISNULL(t.e1SumBalance, $0) + ISNULL(t.e2SumBalance, $0) + ISNULL(t.e3SumBalance, $0) + ISNULL(t.e6SumBalance, $0) + ISNULL(t.e8SumBalance, $0) + ISNULL(t.e5SumBalance, $0) AS TotalBalance, 
			 CASE WHEN a.email LIKE '%@%' THEN 'Эл.адрес указан' ELSE 'Эл.адрес НЕ указан' END AS Email,
			 CASE WHEN a.PhoneProfiles IS NOT NULL AND a.PhoneProfiles != '' OR a.PhoneMobileProfiles IS NOT NULL AND a.PhoneMobileProfiles != '' THEN 
			 'Анкета заполнена' ELSE 'Анкета НЕ заполнена' END AS Profiles,
	         CASE WHEN a.RegPersonalAccount = 1 THEN 'Зарегистрирован в ЛКК' ELSE 'НЕ зарегистрирован в ЛКК' END AS RegPersonalAccount
      FROM #TempResult t
	  INNER JOIN Abonents AS a ON t.AbonentId = a.AbonentId
	  ORDER BY t.OrganName, t.NSF
    END
    ELSE BEGIN
      SELECT t.DtBegin, t.DtClosed, t.AbonNumber, t.NSF, t.OrganName, t.Address,
             t.e1SumPayments, t.e1SumBalance, t.e2SumPayments, t.e2SumBalance, t.e3SumPayments, t.e3SumBalance,
             t.e6SumPayments, t.e6SumBalance, t.e8SumPayments, t.e8SumBalance,
             t.e5SumPayments, t.e5SumBalance, 
			 ISNULL(t.e1SumPayments, $0) + ISNULL(t.e2SumPayments, $0) + ISNULL(t.e3SumPayments, $0) + ISNULL(t.e6SumPayments, $0) + ISNULL(t.e8SumPayments, $0) + ISNULL(t.e5SumPayments, $0) AS TotalPayments,
			 ISNULL(t.e1SumBalance, $0) + ISNULL(t.e2SumBalance, $0) + ISNULL(t.e3SumBalance, $0) + ISNULL(t.e6SumBalance, $0) + ISNULL(t.e8SumBalance, $0) + ISNULL(t.e5SumBalance, $0) AS TotalBalance, 
			 CASE WHEN a.email LIKE '%@%' THEN 'Эл.адрес указан' ELSE 'Эл.адрес НЕ указан' END AS Email,
			 CASE WHEN a.PhoneProfiles IS NOT NULL AND a.PhoneProfiles != '' OR a.PhoneMobileProfiles IS NOT NULL AND a.PhoneMobileProfiles != '' THEN 
			 'Анкета заполнена' ELSE 'Анкета НЕ заполнена' END AS Profiles,
			 CASE WHEN a.RegPersonalAccount = 1 THEN 'Зарегистрирован в ЛКК' ELSE 'НЕ зарегистрирован в ЛКК' END AS RegPersonalAccount
      FROM #TempResult t
	  INNER JOIN Abonents AS a ON t.AbonentId = a.AbonentId
      WHERE t.e1SumBalance <= @SumBalance OR t.e2SumBalance <= @SumBalance OR t.e3SumBalance <= @SumBalance OR
            t.e6SumBalance <= @SumBalance OR t.e8SumBalance <= @SumBalance
      ORDER BY t.OrganName, t.NSF
    END
  END
  RETURN
END
RETURN 0
GO
GRANT EXECUTE ON dbo.Pr_rptPaymentDiscipline TO KvzWorker
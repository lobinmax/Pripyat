IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'lobin_Reports_Report31' AND type = 'P')
    DROP PROCEDURE dbo.lobin_Reports_Report31
GO
CREATE PROCEDURE dbo.lobin_Reports_Report31
/*
  Клонированая процедура формы 30-03.10 
  с добавлением групировки типа плиты привязанного к тарифу 
  и даты начала его действия
*/

@PeriodNumber INT = 201105 ,
@Function INT = 0, -- 0 полная старая
                   -- 1 без доначислений
                   -- 2 доначисления до передачи
                   -- 3 доначисления после передачи
                   -- 4 анализ полезного отпуска
                   -- 5 Для формы 15_09 город (электро и бойлер)
                   -- 6 Ведомость доначислений до передачи 
                   -- 7 анализ полезного отпуска 4_2
                   -- 8 Без счетов Нарушение в ПУ,Нагрузка мимо уч.                   
                   -- 9 30_04 - по уровням напряжения
                   -- 101 ф30.03.10 Анализ полезного отпуска по уровням напряжения в пределах и сверх СН в деньгежном выражении
                   -- 102 ф30.03.10 Анализ полезного отпуска по уровням напряжения в пределах и сверх СН в КвтЧ
                   -- 11  ф30.03.11 Полезный отпуск по тарифам
@DivisionName VARCHAR(50) = null OUTPUT, --OUTPUT , 
@ShortNameOrganisation VARCHAR(50) = null OUTPUT , --OUTPUT ,
@AdminTypeIdFilter INT = -1 ,  -- все
@AgentSubjectId INT = 0 ,      -- Фильтр по управляющим компаниям
@AddressPartId    INT = 0 ,    -- Улица
@HouseNumber      VARCHAR(10) = NULL ,  -- № дома
@HouseLetter      VARCHAR(10) = NULL ,  
@Build            VARCHAR(10) = NULL ,
@DropAbonentODU   INT = 0 ,    -- Исключить абонентов с ОДУ
@TGroupName VARCHAR(128) = NULL , -- Название тарифа для подробного отчета ,
@JuricticFacesId INT = NULL ,      -- Юридическое лицо (только для 31.10)
@PowerNetworkOvnerId INT = NULL    -- Владелец сети  (только для 31.10)

AS
SET NOCOUNT ON
/*
IF @HouseNumber = '' SET @HouseNumber = NULL
IF @HouseLetter = '' SET @HouseLetter = NULL
IF @Build       = '' SET @Build = NULL
IF @JuricticFacesId = 0 SET @JuricticFacesId = NULL
IF @PowerNetworkOvnerId = 0 SET @PowerNetworkOvnerId = NULL
*/
DECLARE @cMonth Varchar(15)
SELECT @DivisionName = Value from dbo.constants WHERE Name = 'DivisionName'
SELECT @ShortNameOrganisation = Value from dbo.constants WHERE Name = 'ShortNameOrganisation' 
SELECT @cMonth = dbo.Kernel_GetMonthYear_2(@PeriodNumber)

IF @Function = 102 BEGIN
  EXECUTE dbo.Reports_Report31_102 
     @PeriodNumber ,
     @JuricticFacesId ,      -- Юридическое лицо (только для 31.10)
     @PowerNetworkOvnerId ,  -- Владелец сети  (только для 31.10)
     @AdminTypeIdFilter ,    -- все
     @AgentSubjectId ,       -- Фильтр по управляющим компаниям
     @AddressPartId  ,       -- Улица
     @HouseNumber  ,         -- № дома
     @HouseLetter ,  
     @Build ,
     @DropAbonentODU         -- Исключить абонентов с ОДУ
     RETURN 0
END

SELECT *
INTO #limits
FROM
(
  SELECT 0 AS LimitTypeId, 'Без нормы' AS LimitName
  UNION
  SELECT 1 AS LimitTypeId, 'Нормативный' AS LimitName
  UNION
  SELECT 2 AS LimitTypeId, 'Сверхнормативный' AS LimitName
) a

SELECT t1.*, e1.name AS Name1
INTO #TariffsE
FROM dbo.Tariffs t1
INNER JOIN dbo.Elements e1 ON t1.TariffId = e1.ElementId

/*
SELECT     t1.TariffId, t1.EnergyTypeId, t1.ParentId, t1.TariffName, t1.LevelId, t1.IconTypeId, t1.TariffTypeId, e1.Name AS Name1
INTO            [#TariffsE]
FROM         Tariffs AS t1 INNER JOIN
                      Elements AS e1 ON t1.TariffId = e1.ElementId LEFT OUTER JOIN
                      TariffCookerCommunication ON t1.TariffId = TariffCookerCommunication.TariffId
*/

CREATE TABLE #t0
(
  AccountId INT,
  SumCharges MONEY,
  PowerCharges MONEY,
  TariffCount MONEY,
  TariffTypeId INT,
  TariffTypeName VARCHAR(128),
  [name] VARCHAR(128),
  CookId INT,
  CookName VARCHAR(128),
  LimitTypeId INT,
  LimitName VARCHAR(128),
  TariffId INT,
  [Date] DATETIME,
  MonthNumber INT,
  DtBegin DATETIME,
  DtDOC DATETIME,
  datesendfunction DATETIME,
  DocumentTypeId INT,
  WiringTypeId INT,
  partofwiringtypeid INT,
  powernetworkid INT,
  DocumentId INT ,
  PointId INT ,
  PackTypeId INT ,
  ExtPackTypeId INT ,
  ArticleNum CHAR(2),
  IncreasingFactor MONEY,
  GroupCookerId INT,
  DtChangeTariff smalldatetime
)

CREATE TABLE #t1
(
  AccountId INT,
  SumCharges MONEY,
  PowerCharges MONEY,
  TariffCount MONEY,
  TariffTypeId INT,
  TariffTypeName VARCHAR(128),
  [name] VARCHAR(128),
  CookId INT,
  CookName VARCHAR(128),
  LimitTypeId INT,
  LimitName VARCHAR(128),
  TariffId INT,
  [Date] DATETIME,
  MonthNumber INT,
  powernetworkid INT,
  IncreasingFactor MONEY,
  GroupCookerId INT,
  DtChangeTariff smalldatetime
)

IF @Function = 6
  EXECUTE dbo.Reports_PrepareReport31 @PeriodNumber , -1 , @AgentSubjectId, -- без фильтра - город / село
    @AddressPartId,    -- Улица
    @HouseNumber,      -- № дома
    @HouseLetter,
    @Build,
    @DropAbonentODU    -- Исключить абонентов с ОДУ
ELSE
  EXECUTE dbo.Reports_PrepareReport31 @PeriodNumber , @AdminTypeIdFilter , @AgentSubjectId ,
    @AddressPartId,    -- Улица
    @HouseNumber,      -- № дома
    @HouseLetter,
    @Build,
    @DropAbonentODU    -- Исключить абонентов с ОДУ

IF @Function = 0
  EXECUTE dbo.Reports_Report31_00 @PeriodNumber  -- 0 полная старая

IF @Function = 1
  EXECUTE dbo.Reports_Report31_01 @PeriodNumber

IF @Function = 2
  EXECUTE dbo.Reports_Report31_02 @PeriodNumber  -- 2 доначисления до передачи

IF @Function = 3
  EXECUTE dbo.Reports_Report31_03 @PeriodNumber  -- 3 доначисления после передачи

IF @Function = 4 BEGIN
  EXECUTE dbo.Reports_Report31_04 @PeriodNumber  -- анализ полезного отпуска
  RETURN 0
END

IF @Function = 5 BEGIN
  EXECUTE dbo.Reports_Report31_05 @PeriodNumber  -- Для формы 15_09 город (электро и бойлер)
  RETURN 0
END

IF @Function = 6 BEGIN                           -- Добавлены параметры Постников 03.09.2007       
  EXECUTE dbo.Reports_Report31_06 @PeriodNumber
  RETURN 0
END

IF @Function = 7 BEGIN                           -- Анализ полезного отпуска с названиями груп тарифов   
  EXECUTE dbo.Reports_Report31_04_2 @PeriodNumber
  RETURN 0
END

IF @Function = 9 BEGIN                           -- Анализ полезного отпуска по уровням напряжения   
  EXECUTE dbo.Reports_Report31_09 @PeriodNumber
  RETURN 0
END

IF @Function = 101 BEGIN                           -- Анализ полезного отпуска по уровням напряжения в пределах и сверх СН 
  EXECUTE dbo.Reports_Report31_101 @PeriodNumber , @JuricticFacesId , @PowerNetworkOvnerId 
  RETURN 0
END

IF @Function = 11 BEGIN                            -- ф30.03.11 Полезный отпуск по тарифам
  EXECUTE dbo.Reports_Report31_11 @PeriodNumber , @JuricticFacesId , @PowerNetworkOvnerId 
  RETURN 0
END

IF @Function = 8 BEGIN                           -- Исключить счета: "Нарушение в приборе учета" , "Нагрузка мимо учета"
  EXECUTE dbo.Reports_Report31_08
END

IF @TGroupName IS NOT NULL BEGIN                 -- Абоненты с заданым именем тарифа
 
  SELECT
  @TGroupName AS TGroupName ,
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName , 
  ROUND(-SUM(t.PowerCharges),0) AS PowerCharges ,
  ROUND(-SUM(t.SumCharges),2) AS SumCharges
  FROM #t1 t
  LEFT JOIN dbo.Accounts acc ON acc.AccountId = t.AccountId
  LEFT JOIN dbo.Points p ON acc.PointId = p.PointId
  LEFT JOIN dbo.vAbonentsShort a ON a.AbonentId = p.AbonentId
  WHERE t.CookName = @TGroupName 
  OR (t.SumCharges <> $0 AND t.PowerCharges = $0)
  GROUP BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName

  UNION ALL
  SELECT
  'Коррекции без расхода' AS TGroupName ,
  a.AbonNumber ,
  p.PointNumber , 
  'Коррекции без расхода!!! ' + a.CommAddressString AS CommAddressString , 
  a.LastSurName , 
  ROUND(-SUM(t.PowerCharges),0) AS PowerCharges ,
  ROUND(-SUM(t.SumCharges),2) AS SumCharges
  FROM #t1 t
  LEFT JOIN dbo.Accounts acc ON acc.AccountId = t.AccountId
  LEFT JOIN dbo.Points p ON acc.PointId = p.PointId
  LEFT JOIN dbo.vAbonentsShort a ON a.AbonentId = p.AbonentId
  WHERE (t.SumCharges <> $0 AND t.PowerCharges = $0)
  GROUP BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName

  UNION ALL
  SELECT
  'Коррекции с расходом' AS TGroupName ,
  a.AbonNumber ,
  p.PointNumber , 
  'Коррекции с расходом!!! ' + a.CommAddressString AS CommAddressString , 
  a.LastSurName , 
  ROUND(-SUM(t.PowerCharges),0) AS PowerCharges ,
  ROUND(-SUM(t.SumCharges),2) AS SumCharges
  FROM #t1 t
  LEFT JOIN dbo.Accounts acc ON acc.AccountId = t.AccountId
  LEFT JOIN dbo.Points p ON acc.PointId = p.PointId
  LEFT JOIN dbo.vAbonentsShort a ON a.AbonentId = p.AbonentId
  WHERE 
  t.SumCharges <> $0 
  AND t.PowerCharges <> $0
  AND (t.TariffCount = $0 OR t.TariffCount IS NULL)
  GROUP BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName

  UNION ALL
  SELECT
  'Бесплатно' AS TGroupName ,
  a.AbonNumber ,
  p.PointNumber , 
  'Бесплатно!!! ' + a.CommAddressString AS CommAddressString , 
  a.LastSurName , 
  ROUND(-SUM(t.PowerCharges),0) AS PowerCharges ,
  ROUND(-SUM(t.SumCharges),2) AS SumCharges
  FROM #t1 t
  LEFT JOIN dbo.Accounts acc ON acc.AccountId = t.AccountId
  LEFT JOIN dbo.Points p ON acc.PointId = p.PointId
  LEFT JOIN dbo.vAbonentsShort a ON a.AbonentId = p.AbonentId
  WHERE SumCharges = $0 AND PowerCharges <> $0
  AND (TariffCount <> $0)
  GROUP BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName
  RETURN 0
END

IF @Function = 12 BEGIN
  SELECT
  @TGroupName AS TGroupName ,
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName , 
  ROUND(-SUM(t.PowerCharges),0) AS PowerCharges ,
  ROUND(-SUM(t.SumCharges),2) AS SumCharges
  FROM #t1 t
  LEFT JOIN dbo.Accounts acc ON acc.AccountId = t.AccountId
  LEFT JOIN dbo.Points p ON acc.PointId = p.PointId
  LEFT JOIN dbo.vAbonentsShort a ON a.AbonentId = p.AbonentId
  WHERE t.SumCharges <> $0 AND t.PowerCharges = $0
  GROUP BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName
  ORDER BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName
  RETURN 0
END


IF @Function = 13 BEGIN

--  select * from #t1

  SELECT
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName , 
  t.TariffCount ,
  ISNULL(t.TariffTypeName, 'без типа тарифа') AS TariffTypeName ,
  ROUND(-SUM(t.PowerCharges),0) AS PowerCharges ,
  ROUND(-SUM(t.SumCharges),2) AS SumCharges ,
  -SUM(t.PowerCharges) * ISNULL(t.TariffCount,0) - -SUM(t.SumCharges) AS Diff
  
  FROM #t1 t
  LEFT JOIN dbo.Accounts acc ON acc.AccountId = t.AccountId
  LEFT JOIN dbo.Points p ON acc.PointId = p.PointId
  LEFT JOIN dbo.vAbonentsShort a ON a.AbonentId = p.AbonentId
  GROUP BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName , 
  t.TariffCount ,
  t.TariffTypeName
  HAVING -SUM(t.PowerCharges) * ISNULL(t.TariffCount,0) <> -SUM(t.SumCharges)
  ORDER BY
  a.AbonNumber ,
  p.PointNumber , 
  a.CommAddressString , 
  a.LastSurName

  RETURN 0
  
END

SELECT
  ROUND(-(SUM(SumCharges)),2) AS SumCharges ,
  ROUND(-(SUM(PowerCharges)),0) AS PowerCharges ,
  ISNULL(TariffCount,0) AS TariffCount ,
  ISNULL(TariffTypeId, 0)AS TariffTypeId ,
  ISNULL(TariffTypeName, 'без типа тарифа') AS TariffTypeName ,
  SUM(PowerCharges) * TariffCount - SUM(SumCharges) AS ControlSum ,
--  ISNULL(t.name, 'без тарифа ' + t.LimitName) AS name ,

  CASE WHEN t.IncreasingFactor IS NULL THEN ISNULL(t.name, 'без тарифа ' + t.LimitName)
       ELSE ISNULL(t.name, 'без тарифа ' + t.LimitName) + ' с пов. коэф.'
  END AS [name] ,

  ISNULL(t.CookId, 0) AS CookId , 
  ISNULL(t.CookName,'без плиты') AS CookName ,
  t.LimitTypeId ,
  1 AS PayId ,
  CONVERT(VARCHAR(25),' ') AS PayName ,
  @cMonth AS cMonth ,
  @DivisionName AS DivisionName ,
  @ShortNameOrganisation AS ShortNameOrganisation,
  t.IncreasingFactor
INTO #t2
FROM #t1 t
WHERE 
  SumCharges <> $0 
  AND PowerCharges <> $0
  AND (TariffCount <> $0 OR TariffCount IS NOT NULL)
GROUP BY
  TariffCount ,
  TariffTypeId ,
  TariffTypeName ,
  t.name ,
  t.CookId , 
  t.CookName ,
  t.LimitTypeId,
  t.LimitName,
  t.IncreasingFactor

INSERT INTO #t2
SELECT
  ROUND(-(SUM(SumCharges)),2) AS SumCharges ,
  ROUND(-(SUM(PowerCharges)),0) AS PowerCharges ,
  ISNULL(TariffCount,0) AS TariffCount,
  ISNULL(TariffTypeId, 0),
  ISNULL(TariffTypeName, 'без типа тарифа'),
  SUM(PowerCharges) * TariffCount - SUM(SumCharges) AS ControlSum,
--  ISNULL(t.name, 'без тарифа ' + t.LimitName) AS name,

  CASE WHEN t.IncreasingFactor IS NULL THEN ISNULL(t.name, 'без тарифа ' + t.LimitName)
       ELSE ISNULL(t.name, 'без тарифа ' + t.LimitName) + ' с пов. коэф.'
  END AS [name] ,

  ISNULL(t.CookId, 0), 
  ISNULL(t.CookName,'без плиты'),
  t.LimitTypeId,
  2 AS PayId,
  'Беcплатно' AS PayName,
  @cMonth AS cMonth,
  @DivisionName AS DivisionName,
  @ShortNameOrganisation AS ShortNameOrganisation,
  t.IncreasingFactor
FROM #t1 t
WHERE SumCharges = $0 AND PowerCharges <> $0
  AND (TariffCount <> $0)
GROUP BY 
  TariffCount,
  TariffTypeId,
  TariffTypeName,
  t.name,
  t.CookId,
  t.CookName,
  t.LimitTypeId,
  t.LimitName,
  t.IncreasingFactor

INSERT INTO #t2
SELECT
  ROUND(-(SUM(SumCharges)),2) AS SumCharges ,
  ROUND(-(SUM(PowerCharges)),0) AS PowerCharges ,
  ISNULL(TariffCount,0) AS TariffCount,
  ISNULL(TariffTypeId, 0),
  ISNULL(TariffTypeName, 'без типа тарифа'),
  SUM(PowerCharges) * TariffCount - SUM(SumCharges) AS ControlSum,
--  ISNULL(t.name, 'без тарифа ' + t.LimitName) AS name,

  CASE WHEN t.IncreasingFactor IS NULL THEN ISNULL(t.name, 'без тарифа ' + t.LimitName)
       ELSE ISNULL(t.name, 'без тарифа ' + t.LimitName) + ' с пов. коэф.'
  END AS [name] ,

  ISNULL(t.CookId, 0), 
  ISNULL(t.CookName,'без плиты'),
  t.LimitTypeId,
  3 AS PayId,
  'Коррекции без расхода' AS PayName,
  @cMonth AS cMonth,
  @DivisionName AS DivisionName,
  @ShortNameOrganisation AS ShortNameOrganisation,
  t.IncreasingFactor
FROM #t1 t
WHERE SumCharges <> $0 AND PowerCharges = $0
GROUP BY
  TariffCount,
  TariffTypeId,
  TariffTypeName,
  t.name,
  t.CookId,
  t.CookName,
  t.LimitTypeId,
  t.LimitName,
  t.IncreasingFactor

INSERT INTO #t2
SELECT
  ROUND(-(SUM(SumCharges)),2) AS SumCharges ,
  ROUND(-(SUM(PowerCharges)),0) AS PowerCharges ,
  ISNULL(TariffCount,0) AS TariffCount ,
  ISNULL(TariffTypeId, 0)AS TariffTypeId ,
  ISNULL(TariffTypeName, 'без типа тарифа') AS TariffTypeName ,
  SUM(PowerCharges) * TariffCount - SUM(SumCharges) AS ControlSum ,
--  ISNULL(t.name, 'без тарифа ' + t.LimitName) AS name ,

  CASE WHEN t.IncreasingFactor IS NULL THEN ISNULL(t.name, 'без тарифа ' + t.LimitName)
       ELSE ISNULL(t.name, 'без тарифа ' + t.LimitName) + ' с пов. коэф.'
  END AS [name] ,

  ISNULL(t.CookId, 0) AS CookId , 
  ISNULL(t.CookName,'без плиты') AS CookName ,
  t.LimitTypeId ,
  4 AS PayId ,
  CONVERT(VARCHAR(25),'Коррекции с расходом') AS PayName ,
  @cMonth AS cMonth ,
  @DivisionName AS DivisionName ,
  @ShortNameOrganisation AS ShortNameOrganisation,
  t.IncreasingFactor
FROM #t1 t
WHERE 
  SumCharges <> $0 
  AND PowerCharges <> $0
  AND (TariffCount = $0 OR TariffCount IS NULL)
GROUP BY
  TariffCount ,
  TariffTypeId ,
  TariffTypeName ,
  t.name ,
  t.CookId , 
  t.CookName ,
  t.LimitTypeId,
  t.LimitName,
  t.IncreasingFactor

INSERT INTO #t2
SELECT
  ROUND(-(SUM(SumCharges)),2) AS SumCharges ,
  ROUND(-(SUM(PowerCharges)),0) AS PowerCharges ,
  ISNULL(TariffCount,0) AS TariffCount ,
  ISNULL(TariffTypeId, 0)AS TariffTypeId ,
  ISNULL(TariffTypeName, 'без типа тарифа') AS TariffTypeName ,
  SUM(PowerCharges) * TariffCount - SUM(SumCharges) AS ControlSum ,
--  ISNULL(t.name, 'без тарифа ' + t.LimitName) AS name ,

  CASE WHEN t.IncreasingFactor IS NULL THEN ISNULL(t.name, 'без тарифа ' + t.LimitName)
       ELSE ISNULL(t.name, 'без тарифа ' + t.LimitName) + ' с пов. коэф.'
  END AS [name] ,

  ISNULL(t.CookId, 0) AS CookId , 
  ISNULL(t.CookName,'без плиты') AS CookName ,
  t.LimitTypeId ,
  5 AS PayId ,
  CONVERT(VARCHAR(25),'Коррекции расхода') AS PayName ,
  @cMonth AS cMonth ,
  @DivisionName AS DivisionName ,
  @ShortNameOrganisation AS ShortNameOrganisation,
  t.IncreasingFactor
FROM #t1 t
WHERE 
  SumCharges = $0 
  AND PowerCharges <> $0
  AND (TariffCount = $0 OR TariffCount IS NULL)
GROUP BY
  TariffCount ,
  TariffTypeId ,
  TariffTypeName ,
  t.name ,
  t.CookId , 
  t.CookName ,
  t.LimitTypeId,
  t.LimitName,
  t.IncreasingFactor

SELECT     SumCharges, ROUND(PowerCharges, 0) AS PowerCharges, t.TariffCount, t.TariffTypeId, t.TariffTypeName, t.ControlSum, name, t.CookId, t.CookName, 
                      t.LimitTypeId, t.PayId, t.PayName, t.cMonth, t.DivisionName, t.ShortNameOrganisation , t9.GroupCookerId, t9.DtChangeTariff, ISNULL(t.IncreasingFactor, $0) AS IncreasingFactor
FROM         [#t2] AS t LEFT OUTER JOIN
                      vlobin_TariffsTree AS t9 ON t.CookId = t9.TariffId AND t.TariffCount = t9.TariffCount AND t.TariffTypeId = t9.TariffTypeId 
WHERE     (SumCharges <> $0) OR
                      (PowerCharges <> $0) OR
                      (t.TariffCount <> $0)
ORDER BY t.PayId, t.CookId, t.LimitTypeId, t.TariffTypeId , t9.GroupCookerId, t9.DtChangeTariff

DROP TABLE #TariffsE
DROP TABLE #t1
DROP TABLE #limits
GO
GRANT EXECUTE ON dbo.lobin_Reports_Report31 TO KvzWorker
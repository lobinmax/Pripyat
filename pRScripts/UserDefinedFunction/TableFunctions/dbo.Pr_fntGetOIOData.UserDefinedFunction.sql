IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fntGetOIOData' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fntGetOIOData
GO
CREATE FUNCTION dbo.Pr_fntGetOIOData()
/*
	=========================================
	|	Функция возвращает всю информацию	|
	|	по активным историям ДЗ				|
	=========================================
*/
RETURNS @OIOData TABLE (
AbonentId INT,
DtBeginOio SMALLDATETIME,
Notes VARCHAR(1000),
CountMonth INT,
SumBalance MONEY,
CalcTypeName VARCHAR(50),
-- Уведомления
e1_Plan DATE,
e1_Fact DATE,
e1_DocSum MONEY,
e1_DocNumber VARCHAR(20),
e1_ControllerId INT,
e1_ControllerName VARCHAR(30),
e1_DMethodId INT,
e1_DMethod VARCHAR(250),

-- Извещение на ограничение
e2_Plan DATE,
e2_Fact DATE,
e2_DocSum MONEY,
e2_DocNumber VARCHAR(20),
e2_ControllerId INT,
e2_ControllerName VARCHAR(30),
e2_DMethodId INT,
e2_DMethod VARCHAR(250),

-- Ограничение
e3_Plan DATE,
e3_Fact DATE,
e3_DocSum MONEY,
-- e3_DocNumber VARCHAR(20),
e3_ControllerId INT,
e3_ControllerName VARCHAR(30),
-- e3_DMethodId INT,
-- e3_DMethod VARCHAR(15),

-- Извещение на отключение
e5_Plan DATE,
e5_Fact DATE,
e5_DocSum MONEY,
e5_DocNumber VARCHAR(20),
e5_ControllerId INT,
e5_ControllerName VARCHAR(30),
e5_DMethodId INT,
e5_DMethod VARCHAR(250),

-- Отключение
e6_Plan DATE,
e6_Fact DATE,
e6_DocSum MONEY,
-- e6_DocNumber VARCHAR(20),
e6_ControllerId INT,
e6_ControllerName VARCHAR(30),
-- e6_DMethodId INT,
-- e6_DMethod VARCHAR(15),

-- Проверка отключение
e11_Plan DATE,
e11_Fact DATE,
e11_DocSum MONEY,
-- e11_DocNumber VARCHAR(20),
e11_ControllerId INT,
e11_ControllerName VARCHAR(30),
e11_DMethodId INT,
e11_DMethod VARCHAR(250),

-- Оформление судебного приказа
e36_Plan DATE,
e36_Fact DATE,
e36_DocSum MONEY,
-- e36_DocNumber VARCHAR(20),
e36_ControllerId INT,
e36_ControllerName VARCHAR(30),
-- e36_DMethodId INT,
-- e36_DMethod VARCHAR(15),

-- Передано заявление в суд
e30_Plan DATE,
e30_Fact DATE,
e30_DocSum MONEY,
e30_DocNumber VARCHAR(20),
e30_ControllerId INT,
e30_ControllerName VARCHAR(30),
-- e30_DMethodId INT,
-- e30_DMethod VARCHAR(15),

-- Вынесение судебного приказа
e31_Plan DATE,
e31_Fact DATE,
e31_DocSum MONEY,
-- e31_DocNumber VARCHAR(20),
e31_ControllerId INT,
e31_ControllerName VARCHAR(30),
-- e31_DMethodId INT,
-- e31_DMethod VARCHAR(15),

-- Отмена судебного приказа
e32_Plan DATE,
e32_Fact DATE,
e32_DocSum MONEY,
-- e32_DocNumber VARCHAR(20),
e32_ControllerId INT,
e32_ControllerName VARCHAR(30),
-- e32_DMethodId INT,
-- e32_DMethod VARCHAR(15),

-- Возврат судебного приказа из суда
e37_Plan DATE,
e37_Fact DATE,
e37_DocSum MONEY,
-- e37_DocNumber VARCHAR(20),
e37_ControllerId INT,
e37_ControllerName VARCHAR(30),
e37_DMethodId INT,
e37_DMethod VARCHAR(250),

-- Направлено в ССП
e33_Plan DATE,
e33_Fact DATE,
e33_DocSum MONEY,
-- e33_DocNumber VARCHAR(20),
e33_ControllerId INT,
e33_ControllerName VARCHAR(30),
e33_DMethodId INT,
e33_DMethod VARCHAR(250),

-- Оформление искового заявления
e35_Plan DATE,
e35_Fact DATE,
e35_DocSum MONEY,
-- e35_DocNumber VARCHAR(20),
e35_ControllerId INT,
e35_ControllerName VARCHAR(30),
-- e35_DMethodId INT,
-- e35_DMethod VARCHAR(15),

-- Передан в суд
e14_Plan DATE,
e14_Fact DATE,
e14_DocSum MONEY,
-- e14_DocNumber VARCHAR(20),
e14_ControllerId INT,
e14_ControllerName VARCHAR(30),
-- e14_DMethodId INT,
-- e14_DMethod VARCHAR(15),

-- Решение суда
e15_Plan DATE,
e15_Fact DATE,
e15_DocSum MONEY,
-- e15_DocNumber VARCHAR(20),
e15_ControllerId INT,
e15_ControllerName VARCHAR(30),
-- e15_DMethodId INT,
-- e15_DMethod VARCHAR(15),

-- Отказано судом
e38_Plan DATE,
e38_Fact DATE,
e38_DocSum MONEY,
-- e38_DocNumber VARCHAR(20),
e38_ControllerId INT,
e38_ControllerName VARCHAR(30),
e38_DMethodId INT,
e38_DMethod VARCHAR(250),

-- Передан в ССП
e16_Plan DATE,
e16_Fact DATE,
e16_DocSum MONEY,
-- e16_DocNumber VARCHAR(20),
e16_ControllerId INT,
e16_ControllerName VARCHAR(30),
-- e16_DMethodId INT,
-- e16_DMethod VARCHAR(15),

-- Запрос в ССП
e17_Plan DATE,
e17_Fact DATE,
e17_DocSum MONEY,
-- e17_DocNumber VARCHAR(20),
e17_ControllerId INT,
e17_ControllerName VARCHAR(30),
-- e17_DMethodId INT,
-- e17_DMethod VARCHAR(15),

-- Рейд в ССП
e19_Plan DATE,
e19_Fact DATE,
e19_DocSum MONEY,
-- e19_DocNumber VARCHAR(20),
e19_ControllerId INT,
e19_ControllerName VARCHAR(30),
-- e19_DMethodId INT,
-- e19_DMethod VARCHAR(15),

-- Передан на списание
e18_Plan DATE,
e18_Fact DATE,
e18_DocSum MONEY,
-- e18_DocNumber VARCHAR(20),
e18_ControllerId INT,
e18_ControllerName VARCHAR(30),
-- e18_DMethodId INT,
-- e18_DMethod VARCHAR(15),

-- Запрос в суд
e20_Plan DATE,
e20_Fact DATE,
e20_DocSum MONEY,
-- e20_DocNumber VARCHAR(20),
e20_ControllerId INT,
e20_ControllerName VARCHAR(30)
-- e20_DMethodId INT,
-- e20_DMethod VARCHAR(15)
)

AS 
BEGIN


-- создание и заполнение таблиц 
DECLARE @a TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
Notes VARCHAR(1000),
CountMonth INT,
SumBalance MONEY,
CalcTypeName VARCHAR(50)
)
INSERT INTO @a
SELECT        		a.AbonentId, a.DtBeginOio, a.Notes, cm.CountMonth, cm.SumBalance, ct.CalcTypeName
FROM            	dbo.OiOCalcTypes AS ct
INNER JOIN 			dbo.Abonents ON ct.CalcTypeId = dbo.Abonents.CalcTypeId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON dbo.Abonents.AbonentId = a.AbonentId 
LEFT OUTER JOIN 	dbo.Pr_OioCountMonthAbonent AS cm ON a.AbonentId = cm.AbonentId
WHERE        		a.DtEndOio > GETDATE() AND cm.PeriodNumber = 	(
																	SELECT DISTINCT MAX(PeriodNumber) AS PeriodNumberMax
								                               		FROM            dbo.Pr_OioCountMonthAbonent AS cmaMax
																	)

-- Уведомления
DECLARE @e1 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e1_Plan DATE,
e1_Fact DATE,
e1_DocSum MONEY,
e1_DocNumber VARCHAR(20),
e1_ControllerId INT,
e1_ControllerName VARCHAR(30),
e1_DMethodId INT,
e1_DMethod VARCHAR(250)
)
INSERT INTO @e1
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					CHAR(39) + ev.DocumentNumber AS DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName, 
					ev.DMethodId, 
					dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 1

-- Извещение на ограничение
DECLARE @e2 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e2_Plan DATE,
e2_Fact DATE,
e2_DocSum MONEY,
e2_DocNumber VARCHAR(20),
e2_ControllerId INT,
e2_ControllerName VARCHAR(30),
e2_DMethodId INT,
e2_DMethod VARCHAR(250)
)
INSERT INTO @e2
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName, 
					ev.DMethodId, 
					dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 2

-- Ограничение
DECLARE @e3 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e3_Plan DATE,
e3_Fact DATE,
e3_DocSum MONEY,
-- e3_DocNumber VARCHAR(20),
e3_ControllerId INT,
e3_ControllerName VARCHAR(30)
-- e3_DMethodId INT,
-- e3_DMethod VARCHAR(15)
)
INSERT INTO @e3
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 3

-- Извещение на отключение
DECLARE @e5 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e5_Plan DATE,
e5_Fact DATE,
e5_DocSum MONEY,
e5_DocNumber VARCHAR(20),
e5_ControllerId INT,
e5_ControllerName VARCHAR(30),
e5_DMethodId INT,
e5_DMethod VARCHAR(250)
)
INSERT INTO @e5
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName, 
					ev.DMethodId, 
					dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 5

-- Отключение
DECLARE @e6 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e6_Plan DATE,
e6_Fact DATE,
e6_DocSum MONEY,
-- e6_DocNumber VARCHAR(20),
e6_ControllerId INT,
e6_ControllerName VARCHAR(30)
-- e6_DMethodId INT,
-- e6_DMethod VARCHAR(15)
)
INSERT INTO @e6
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 6

-- Проверка отключение
DECLARE @e11 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e11_Plan DATE,
e11_Fact DATE,
e11_DocSum MONEY,
-- e11_DocNumber VARCHAR(20),
e11_ControllerId INT,
e11_ControllerName VARCHAR(30),
e11_DMethodId INT,
e11_DMethod VARCHAR(250)
)
INSERT INTO @e11
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName, 
					ev.DMethodId, 
					dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 11

-- Оформление судебного приказа
DECLARE @e36 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e36_Plan DATE,
e36_Fact DATE,
e36_DocSum MONEY,
-- e36_DocNumber VARCHAR(20),
e36_ControllerId INT,
e36_ControllerName VARCHAR(30)
-- e36_DMethodId INT,
-- e36_DMethod VARCHAR(15)
)
INSERT INTO @e36
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 36

-- Передано заявление в суд
DECLARE @e30 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e30_Plan DATE,
e30_Fact DATE,
e30_DocSum MONEY,
e30_DocNumber VARCHAR(20),
e30_ControllerId INT,
e30_ControllerName VARCHAR(30)
-- e30_DMethodId INT,
-- e30_DMethod VARCHAR(15)
)
INSERT INTO @e30
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 30

-- Вынесение судебного приказа
DECLARE @e31 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e31_Plan DATE,
e31_Fact DATE,
e31_DocSum MONEY,
-- e31_DocNumber VARCHAR(20),
e31_ControllerId INT,
e31_ControllerName VARCHAR(30)
-- e31_DMethodId INT,
-- e31_DMethod VARCHAR(15)
)
INSERT INTO @e31
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 31

-- Отмена судебного приказа
DECLARE @e32 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e32_Plan DATE,
e32_Fact DATE,
e32_DocSum MONEY,
-- e32_DocNumber VARCHAR(20),
e32_ControllerId INT,
e32_ControllerName VARCHAR(30)
-- e32_DMethodId INT,
-- e32_DMethod VARCHAR(15)
)
INSERT INTO @e32
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 32

-- Возврат судебного приказа из суда
DECLARE @e37 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e37_Plan DATE,
e37_Fact DATE,
e37_DocSum MONEY,
-- e37_DocNumber VARCHAR(20),
e37_ControllerId INT,
e37_ControllerName VARCHAR(30),
e37_DMethodId INT,
e37_DMethod VARCHAR(250)
)
INSERT INTO @e37
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName, 
					ev.DMethodId, 
					dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 37

-- Направлено в ССП
DECLARE @e33 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e33_Plan DATE,
e33_Fact DATE,
e33_DocSum MONEY,
-- e33_DocNumber VARCHAR(20),
e33_ControllerId INT,
e33_ControllerName VARCHAR(30),
e33_DMethodId INT,
e33_DMethod VARCHAR(250)
)
INSERT INTO @e33
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName, 
					ev.DMethodId, 
					dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 33

-- Оформление искового заявления
DECLARE @e35 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e35_Plan DATE,
e35_Fact DATE,
e35_DocSum MONEY,
-- e35_DocNumber VARCHAR(20),
e35_ControllerId INT,
e35_ControllerName VARCHAR(30)
-- e35_DMethodId INT,
-- e35_DMethod VARCHAR(15)
)
INSERT INTO @e35
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 35

-- Передан в суд
DECLARE @e14 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e14_Plan DATE,
e14_Fact DATE,
e14_DocSum MONEY,
-- e14_DocNumber VARCHAR(20),
e14_ControllerId INT,
e14_ControllerName VARCHAR(30)
-- e14_DMethodId INT,
-- e14_DMethod VARCHAR(15)
)
INSERT INTO @e14
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 14

-- Решение суда
DECLARE @e15 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e15_Plan DATE,
e15_Fact DATE,
e15_DocSum MONEY,
-- e15_DocNumber VARCHAR(20),
e15_ControllerId INT,
e15_ControllerName VARCHAR(30)
-- e15_DMethodId INT,
-- e15_DMethod VARCHAR(15)
)
INSERT INTO @e15
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 15

-- Отказано судом
DECLARE @e38 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e38_Plan DATE,
e38_Fact DATE,
e38_DocSum MONEY,
-- e38_DocNumber VARCHAR(20),
e38_ControllerId INT,
e38_ControllerName VARCHAR(30),
e38_DMethodId INT,
e38_DMethod VARCHAR(250)
)
INSERT INTO @e38
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName, 
					ev.DMethodId, 
					dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 38

-- Передан в ССП
DECLARE @e16 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e16_Plan DATE,
e16_Fact DATE,
e16_DocSum MONEY,
-- e16_DocNumber VARCHAR(20),
e16_ControllerId INT,
e16_ControllerName VARCHAR(30)
-- e16_DMethodId INT,
-- e16_DMethod VARCHAR(15)
)
INSERT INTO @e16
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 16

-- Запрос в ССП
DECLARE @e17 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e17_Plan DATE,
e17_Fact DATE,
e17_DocSum MONEY,
-- e17_DocNumber VARCHAR(20),
e17_ControllerId INT,
e17_ControllerName VARCHAR(30)
-- e17_DMethodId INT,
-- e17_DMethod VARCHAR(15)
)
INSERT INTO @e17
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 17

-- Рейд в ССП
DECLARE @e19 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e19_Plan DATE,
e19_Fact DATE,
e19_DocSum MONEY,
-- e19_DocNumber VARCHAR(20),
e19_ControllerId INT,
e19_ControllerName VARCHAR(30)
-- e19_DMethodId INT,
-- e19_DMethod VARCHAR(15)
)
INSERT INTO @e19
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 19

-- Передан на списание
DECLARE @e18 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e18_Plan DATE,
e18_Fact DATE,
e18_DocSum MONEY,
-- e18_DocNumber VARCHAR(20),
e18_ControllerId INT,
e18_ControllerName VARCHAR(30)
-- e18_DMethodId INT,
-- e18_DMethod VARCHAR(15)
)
INSERT INTO @e18
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 18

-- Запрос в суд
DECLARE @e20 TABLE
(
AbonentId INT,
DtBeginOio SMALLDATETIME,
e20_Plan DATE,
e20_Fact DATE,
e20_DocSum MONEY,
-- e20_DocNumber VARCHAR(20),
e20_ControllerId INT,
e20_ControllerName VARCHAR(30)
-- e20_DMethodId INT,
-- e20_DMethod VARCHAR(15)
)
INSERT INTO @e20
SELECT        		a.AbonentId, 
					a.DtBeginOio, 
					ev.DtPlane, 
					ev.DtFact, 
					ev.DocSum, 
					-- ev.DocumentNumber, 
					ev.InspectorId AS ControllerId, 
					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS ControllerName 
					-- ev.DMethodId, 
					-- dm.DMethodName AS DMethod
FROM            	dbo.OioEvents AS ev 
LEFT OUTER JOIN 	dbo.OiODeliveryMethods AS dm ON ev.DMethodId = dm.DMethodId 
RIGHT OUTER JOIN 	dbo.OioAbonents AS a ON ev.AbonentId = a.AbonentId AND ev.DtBeginOio = a.DtBeginOio
WHERE        		a.DtEndOio > GETDATE() AND ev.EventTypeId = 20

INSERT INTO @OIOData
SELECT 	a.AbonentId, a.DtBeginOio, a.Notes, a.CountMonth, a.SumBalance, a.CalcTypeName,
		e1.e1_Plan, e1.e1_Fact, e1.e1_DocSum, e1.e1_DocNumber, e1.e1_ControllerId, e1.e1_ControllerName, e1.e1_DMethodId, e1.e1_DMethod,
		e2.e2_Plan, e2.e2_Fact, e2.e2_DocSum, e2.e2_DocNumber, e2.e2_ControllerId, e2.e2_ControllerName, e2.e2_DMethodId, e2.e2_DMethod,
		e3.e3_Plan, e3.e3_Fact, e3.e3_DocSum, e3.e3_ControllerId, e3.e3_ControllerName,
		e5.e5_Plan, e5.e5_Fact, e5.e5_DocSum, e5.e5_DocNumber, e5.e5_ControllerId, e5.e5_ControllerName, e5.e5_DMethodId, e5.e5_DMethod,
		e6.e6_Plan, e6.e6_Fact, e6.e6_DocSum, e6.e6_ControllerId, e6.e6_ControllerName,
		e11.e11_Plan, e11.e11_Fact, e11.e11_DocSum, e11.e11_ControllerId, e11.e11_ControllerName, e11.e11_DMethodId, e11.e11_DMethod,
		e36.e36_Plan, e36.e36_Fact, e36.e36_DocSum, e36.e36_ControllerId, e36.e36_ControllerName,
		e30.e30_Plan, e30.e30_Fact, e30.e30_DocSum, e30.e30_DocNumber, e30.e30_ControllerId, e30.e30_ControllerName,
		e31.e31_Plan, e31.e31_Fact, e31.e31_DocSum, e31.e31_ControllerId, e31.e31_ControllerName,
		e32.e32_Plan, e32.e32_Fact, e32.e32_DocSum, e32.e32_ControllerId, e32.e32_ControllerName,
		e37.e37_Plan, e37.e37_Fact, e37.e37_DocSum, e37.e37_ControllerId, e37.e37_ControllerName, e37.e37_DMethodId, e37.e37_DMethod,
		e33.e33_Plan, e33.e33_Fact, e33.e33_DocSum, e33.e33_ControllerId, e33.e33_ControllerName, e33.e33_DMethodId, e33.e33_DMethod,
		e35.e35_Plan, e35.e35_Fact, e35.e35_DocSum, e35.e35_ControllerId, e35.e35_ControllerName,
		e14.e14_Plan, e14.e14_Fact, e14.e14_DocSum, e14.e14_ControllerId, e14.e14_ControllerName,
		e15.e15_Plan, e15.e15_Fact, e15.e15_DocSum, e15.e15_ControllerId, e15.e15_ControllerName,
		e38.e38_Plan, e38.e38_Fact, e38.e38_DocSum, e38.e38_ControllerId, e38.e38_ControllerName, e38.e38_DMethodId, e38.e38_DMethod,
		e16.e16_Plan, e16.e16_Fact, e16.e16_DocSum, e16.e16_ControllerId, e16.e16_ControllerName,
		e17.e17_Plan, e17.e17_Fact, e17.e17_DocSum, e17.e17_ControllerId, e17.e17_ControllerName,
		e19.e19_Plan, e19.e19_Fact, e19.e19_DocSum, e19.e19_ControllerId, e19.e19_ControllerName,
		e18.e18_Plan, e18.e18_Fact, e18.e18_DocSum, e18.e18_ControllerId, e18.e18_ControllerName,
		e20.e20_Plan, e20.e20_Fact, e20.e20_DocSum, e20.e20_ControllerId, e20.e20_ControllerName
FROM @a AS a
LEFT OUTER JOIN @e1 AS e1 ON a.AbonentId = e1.AbonentId AND a.DtBeginOio = e1.DtBeginOio
LEFT OUTER JOIN @e2 AS e2 ON a.AbonentId = e2.AbonentId AND a.DtBeginOio = e2.DtBeginOio
LEFT OUTER JOIN @e3 AS e3 ON a.AbonentId = e3.AbonentId AND a.DtBeginOio = e3.DtBeginOio
LEFT OUTER JOIN @e5 AS e5 ON a.AbonentId = e5.AbonentId AND a.DtBeginOio = e5.DtBeginOio
LEFT OUTER JOIN @e6 AS e6 ON a.AbonentId = e6.AbonentId AND a.DtBeginOio = e6.DtBeginOio
LEFT OUTER JOIN @e11 AS e11 ON a.AbonentId = e11.AbonentId AND a.DtBeginOio = e11.DtBeginOio
LEFT OUTER JOIN @e36 AS e36 ON a.AbonentId = e36.AbonentId AND a.DtBeginOio = e36.DtBeginOio
LEFT OUTER JOIN @e30 AS e30 ON a.AbonentId = e30.AbonentId AND a.DtBeginOio = e30.DtBeginOio
LEFT OUTER JOIN @e31 AS e31 ON a.AbonentId = e31.AbonentId AND a.DtBeginOio = e31.DtBeginOio
LEFT OUTER JOIN @e32 AS e32 ON a.AbonentId = e32.AbonentId AND a.DtBeginOio = e32.DtBeginOio
LEFT OUTER JOIN @e37 AS e37 ON a.AbonentId = e37.AbonentId AND a.DtBeginOio = e37.DtBeginOio
LEFT OUTER JOIN @e33 AS e33 ON a.AbonentId = e33.AbonentId AND a.DtBeginOio = e33.DtBeginOio
LEFT OUTER JOIN @e35 AS e35 ON a.AbonentId = e35.AbonentId AND a.DtBeginOio = e35.DtBeginOio
LEFT OUTER JOIN @e14 AS e14 ON a.AbonentId = e14.AbonentId AND a.DtBeginOio = e14.DtBeginOio
LEFT OUTER JOIN @e15 AS e15 ON a.AbonentId = e15.AbonentId AND a.DtBeginOio = e15.DtBeginOio
LEFT OUTER JOIN @e38 AS e38 ON a.AbonentId = e38.AbonentId AND a.DtBeginOio = e38.DtBeginOio
LEFT OUTER JOIN @e16 AS e16 ON a.AbonentId = e16.AbonentId AND a.DtBeginOio = e16.DtBeginOio
LEFT OUTER JOIN @e17 AS e17 ON a.AbonentId = e17.AbonentId AND a.DtBeginOio = e17.DtBeginOio
LEFT OUTER JOIN @e19 AS e19 ON a.AbonentId = e19.AbonentId AND a.DtBeginOio = e19.DtBeginOio
LEFT OUTER JOIN @e18 AS e18 ON a.AbonentId = e18.AbonentId AND a.DtBeginOio = e18.DtBeginOio
LEFT OUTER JOIN @e20 AS e20 ON a.AbonentId = e20.AbonentId AND a.DtBeginOio = e20.DtBeginOio

RETURN
END 
GO
GRANT SELECT ON Pr_fntGetOIOData TO KvzWorker
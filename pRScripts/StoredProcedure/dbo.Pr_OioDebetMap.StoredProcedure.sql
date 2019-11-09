IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OioDebetMap' AND type = 'P')
    DROP PROCEDURE Pr_OioDebetMap
GO
CREATE PROCEDURE dbo.Pr_OioDebetMap 
/*
	=================================================
	|	Процедура для формирования карты ДЗ 		|
	=================================================
*/
@fltrEventsList		VARCHAR(200)	= NULL,		-- Перечень ид событий для фильтрации
@BalanceMin 		MONEY			= 0,		-- Фильтр по сумме ДЗ (мин)
@BalanceMax			MONEY			= 999999,	-- Фильтр по сумме ДЗ (макс)
@Function			INT							-- 1 - Список мероприятий
												-- 2 - Карта ДЗ
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- Список мероприятий
/*
	1 - Уведомления
	3 - Ограничения
	6 - Отключения
	8 - Проверки отключения
*/
IF @Function = 1 BEGIN
	SELECT 		e.EventTypeId,
   				e.EventName
	FROM 		dbo.OioEventsTypes e
	WHERE 		e.EventTypeId IN (1, 3, 6, 8)
	GROUP BY 	e.EventName, 
				e.EventTypeId
	ORDER BY 	e.EventTypeId
END

IF @Function = 2 BEGIN
DECLARE @MaxClosePeriod INT = (SELECT mcp.Closed  FROM vMaxClosedPeriod mcp) -- последний зокрытый период
DECLARE @CityOrVillages INT = (SELECT dbo.GetConstantValue('AttribAccount')) -- тип базы город/село

	-- городская база
	IF @CityOrVillages = 1 BEGIN
		SELECT        	ROW_NUMBER() OVER (	ORDER BY e.Name, a.SpecDepart) AS RowId,
						e.Name AS GroupName, 
						a.SpecDepart AS SubGroupName, 
						SUM(pd2.SumBalance) AS Group2_sum, 
						COUNT(pd2.AbonentId) AS Group2_count,
						SUM(pd3.SumBalance) AS Group3_sum, 
						COUNT(pd3.AbonentId) AS Group3_count,
						SUM(pd4.SumBalance) AS Group4_sum, 
						COUNT(pd4.AbonentId) AS Group4_count,
						SUM(pd5.SumBalance) AS Group5_sum, 
						COUNT(pd5.AbonentId) AS Group5_count,
						SUM(pd6.SumBalance) AS Group6_sum, 
						COUNT(pd6.AbonentId) AS Group6_count,
						SUM(pd7.SumBalance) AS Group7_sum, 
						COUNT(pd7.AbonentId) AS Group7_count,
						SUM(pd8.SumBalance) AS Group8_sum, 
						COUNT(pd8.AbonentId) AS Group8_count,
						SUM(pd9.SumBalance) AS Group9_sum, 
						COUNT(pd9.AbonentId) AS Group9_count,
						SUM(pd0.SumBalance) AS Group0_sum, 
						COUNT(pd0.AbonentId) AS Group0_count
					 FROM            (SELECT        p0.AbonentId, p0.CountMonth, p0.SumBalance * - 1 AS SumBalance, p0.PeriodNumber
		                          FROM            Pr_OioCountMonthAbonent AS p0 INNER JOIN
		                                                    Pr_OioCounterPeriod AS c0 ON p0.CountMonth BETWEEN c0.CountMin AND c0.CountMax
		                          WHERE        (p0.PeriodNumber = @MaxClosePeriod) AND (p0.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd0 RIGHT OUTER JOIN
		                         vPr_OioEventsPlane AS ev ON pd0.AbonentId = ev.AbonentId LEFT OUTER JOIN
		                             (SELECT        p9.AbonentId, p9.CountMonth, p9.SumBalance * - 1 AS SumBalance, p9.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p9 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c9 ON p9.CountMonth BETWEEN c9.CountMin AND c9.CountMax
		                               WHERE        (p9.PeriodNumber = @MaxClosePeriod) AND (c9.GroupCount = 9) AND (p9.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd9 ON 
		                         ev.AbonentId = pd9.AbonentId LEFT OUTER JOIN
		                             (SELECT        p8.AbonentId, p8.CountMonth, p8.SumBalance * - 1 AS SumBalance, p8.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p8 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c8 ON p8.CountMonth BETWEEN c8.CountMin AND c8.CountMax
		                               WHERE        (p8.PeriodNumber = @MaxClosePeriod) AND (c8.GroupCount = 8) AND (p8.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd8 ON 
		                         ev.AbonentId = pd8.AbonentId LEFT OUTER JOIN
		                             (SELECT        p7.AbonentId, p7.CountMonth, p7.SumBalance * - 1 AS SumBalance, p7.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p7 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c7 ON p7.CountMonth BETWEEN c7.CountMin AND c7.CountMax
		                               WHERE        (p7.PeriodNumber = @MaxClosePeriod) AND (c7.GroupCount = 7) AND (p7.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd7 ON 
		                         ev.AbonentId = pd7.AbonentId LEFT OUTER JOIN
		                             (SELECT        p6.AbonentId, p6.CountMonth, p6.SumBalance * - 1 AS SumBalance, p6.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p6 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c6 ON p6.CountMonth BETWEEN c6.CountMin AND c6.CountMax
		                               WHERE        (p6.PeriodNumber = @MaxClosePeriod) AND (c6.GroupCount = 6) AND (p6.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd6 ON 
		                         ev.AbonentId = pd6.AbonentId LEFT OUTER JOIN
		                             (SELECT        p5.AbonentId, p5.CountMonth, p5.SumBalance * - 1 AS SumBalance, p5.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p5 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c5 ON p5.CountMonth BETWEEN c5.CountMin AND c5.CountMax
		                               WHERE        (p5.PeriodNumber = @MaxClosePeriod) AND (c5.GroupCount = 5) AND (p5.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd5 ON 
		                         ev.AbonentId = pd5.AbonentId LEFT OUTER JOIN
		                             (SELECT        p4.AbonentId, p4.CountMonth, p4.SumBalance * - 1 AS SumBalance, p4.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p4 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c4 ON p4.CountMonth BETWEEN c4.CountMin AND c4.CountMax
		                               WHERE        (p4.PeriodNumber = @MaxClosePeriod) AND (c4.GroupCount = 4) AND (p4.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd4 ON 
		                         ev.AbonentId = pd4.AbonentId LEFT OUTER JOIN
		                             (SELECT        p3.AbonentId, p3.CountMonth, p3.SumBalance * - 1 AS SumBalance, p3.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p3 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c3 ON p3.CountMonth BETWEEN c3.CountMin AND c3.CountMax
		                               WHERE        (p3.PeriodNumber = @MaxClosePeriod) AND (c3.GroupCount = 3) AND (p3.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd3 ON 
		                         ev.AbonentId = pd3.AbonentId LEFT OUTER JOIN
		                             (SELECT        p2.AbonentId, p2.CountMonth, p2.SumBalance * - 1 AS SumBalance, p2.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p2 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c2 ON p2.CountMonth BETWEEN c2.CountMin AND c2.CountMax
		                               WHERE        (p2.PeriodNumber = @MaxClosePeriod) AND (c2.GroupCount = 2) AND (p2.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd2 ON 
		                         ev.AbonentId = pd2.AbonentId LEFT OUTER JOIN
		                         vAbonents AS a INNER JOIN
		                         Elements AS e ON a.ControllerId = e.ElementId ON ev.AbonentId = a.AbonentId
		WHERE        (ev.KVZ_EventTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@fltrEventsList,',') AS pgtfs))
		GROUP BY a.SpecDepart, e.Name
		UNION ALL
		SELECT        	999999 AS RowId,
						e.Name AS GroupName, 
						'Итого:' AS Тotal,
						SUM(pd2.SumBalance) AS Group2_sum, 
						COUNT(pd2.AbonentId) AS Group2_count,
						SUM(pd3.SumBalance) AS Group3_sum, 
						COUNT(pd3.AbonentId) AS Group3_count,
						SUM(pd4.SumBalance) AS Group4_sum, 
						COUNT(pd4.AbonentId) AS Group4_count,
						SUM(pd5.SumBalance) AS Group5_sum, 
						COUNT(pd5.AbonentId) AS Group5_count,
						SUM(pd6.SumBalance) AS Group6_sum, 
						COUNT(pd6.AbonentId) AS Group6_count,
						SUM(pd7.SumBalance) AS Group7_sum, 
						COUNT(pd7.AbonentId) AS Group7_count,
						SUM(pd8.SumBalance) AS Group8_sum, 
						COUNT(pd8.AbonentId) AS Group8_count,
						SUM(pd9.SumBalance) AS Group9_sum, 
						COUNT(pd9.AbonentId) AS Group9_count,
						SUM(pd0.SumBalance) AS Group0_sum, 
						COUNT(pd0.AbonentId) AS Group0_count
		FROM            (SELECT        p0.AbonentId, p0.CountMonth, p0.SumBalance * - 1 AS SumBalance, p0.PeriodNumber
		                          FROM            Pr_OioCountMonthAbonent AS p0 INNER JOIN
		                                                    Pr_OioCounterPeriod AS c0 ON p0.CountMonth BETWEEN c0.CountMin AND c0.CountMax
		                          WHERE        (p0.PeriodNumber = @MaxClosePeriod) AND (p0.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd0 RIGHT OUTER JOIN
		                         vPr_OioEventsPlane AS ev ON pd0.AbonentId = ev.AbonentId LEFT OUTER JOIN
		                             (SELECT        p9.AbonentId, p9.CountMonth, p9.SumBalance * - 1 AS SumBalance, p9.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p9 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c9 ON p9.CountMonth BETWEEN c9.CountMin AND c9.CountMax
		                               WHERE        (p9.PeriodNumber = @MaxClosePeriod) AND (c9.GroupCount = 9) AND (p9.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd9 ON 
		                         ev.AbonentId = pd9.AbonentId LEFT OUTER JOIN
		                             (SELECT        p8.AbonentId, p8.CountMonth, p8.SumBalance * - 1 AS SumBalance, p8.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p8 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c8 ON p8.CountMonth BETWEEN c8.CountMin AND c8.CountMax
		                               WHERE        (p8.PeriodNumber = @MaxClosePeriod) AND (c8.GroupCount = 8) AND (p8.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd8 ON 
		                         ev.AbonentId = pd8.AbonentId LEFT OUTER JOIN
		                             (SELECT        p7.AbonentId, p7.CountMonth, p7.SumBalance * - 1 AS SumBalance, p7.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p7 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c7 ON p7.CountMonth BETWEEN c7.CountMin AND c7.CountMax
		                               WHERE        (p7.PeriodNumber = @MaxClosePeriod) AND (c7.GroupCount = 7) AND (p7.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd7 ON 
		                         ev.AbonentId = pd7.AbonentId LEFT OUTER JOIN
		                             (SELECT        p6.AbonentId, p6.CountMonth, p6.SumBalance * - 1 AS SumBalance, p6.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p6 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c6 ON p6.CountMonth BETWEEN c6.CountMin AND c6.CountMax
		                               WHERE        (p6.PeriodNumber = @MaxClosePeriod) AND (c6.GroupCount = 6) AND (p6.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd6 ON 
		                         ev.AbonentId = pd6.AbonentId LEFT OUTER JOIN
		                             (SELECT        p5.AbonentId, p5.CountMonth, p5.SumBalance * - 1 AS SumBalance, p5.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p5 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c5 ON p5.CountMonth BETWEEN c5.CountMin AND c5.CountMax
		                               WHERE        (p5.PeriodNumber = @MaxClosePeriod) AND (c5.GroupCount = 5) AND (p5.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd5 ON 
		                         ev.AbonentId = pd5.AbonentId LEFT OUTER JOIN
		                             (SELECT        p4.AbonentId, p4.CountMonth, p4.SumBalance * - 1 AS SumBalance, p4.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p4 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c4 ON p4.CountMonth BETWEEN c4.CountMin AND c4.CountMax
		                               WHERE        (p4.PeriodNumber = @MaxClosePeriod) AND (c4.GroupCount = 4) AND (p4.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd4 ON 
		                         ev.AbonentId = pd4.AbonentId LEFT OUTER JOIN
		                             (SELECT        p3.AbonentId, p3.CountMonth, p3.SumBalance * - 1 AS SumBalance, p3.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p3 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c3 ON p3.CountMonth BETWEEN c3.CountMin AND c3.CountMax
		                               WHERE        (p3.PeriodNumber = @MaxClosePeriod) AND (c3.GroupCount = 3) AND (p3.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd3 ON 
		                         ev.AbonentId = pd3.AbonentId LEFT OUTER JOIN
		                             (SELECT        p2.AbonentId, p2.CountMonth, p2.SumBalance * - 1 AS SumBalance, p2.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p2 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c2 ON p2.CountMonth BETWEEN c2.CountMin AND c2.CountMax
		                               WHERE        (p2.PeriodNumber = @MaxClosePeriod) AND (c2.GroupCount = 2) AND (p2.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd2 ON 
		                         ev.AbonentId = pd2.AbonentId LEFT OUTER JOIN
		                         vAbonents AS a INNER JOIN
		                         Elements AS e ON a.ControllerId = e.ElementId ON ev.AbonentId = a.AbonentId
		WHERE        (ev.KVZ_EventTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@fltrEventsList,',') AS pgtfs))
		GROUP BY e.Name
		ORDER BY GroupName, RowId
	END
	-- сельская база
	IF @CityOrVillages = 2 BEGIN
		SELECT        	ROW_NUMBER() OVER (	ORDER BY a.Areal, a.CityVillage) AS RowId,
						a.Areal AS GroupName, 
						a.CityVillage AS SubGroupName, 
						SUM(pd2.SumBalance) AS Group2_sum, 
						COUNT(pd2.AbonentId) AS Group2_count,
						SUM(pd3.SumBalance) AS Group3_sum, 
						COUNT(pd3.AbonentId) AS Group3_count,
						SUM(pd4.SumBalance) AS Group4_sum, 
						COUNT(pd4.AbonentId) AS Group4_count,
						SUM(pd5.SumBalance) AS Group5_sum, 
						COUNT(pd5.AbonentId) AS Group5_count,
						SUM(pd6.SumBalance) AS Group6_sum, 
						COUNT(pd6.AbonentId) AS Group6_count,
						SUM(pd7.SumBalance) AS Group7_sum, 
						COUNT(pd7.AbonentId) AS Group7_count,
						SUM(pd8.SumBalance) AS Group8_sum, 
						COUNT(pd8.AbonentId) AS Group8_count,
						SUM(pd9.SumBalance) AS Group9_sum, 
						COUNT(pd9.AbonentId) AS Group9_count,
						SUM(pd0.SumBalance) AS Group0_sum, 
						COUNT(pd0.AbonentId) AS Group0_count
					 FROM            (SELECT        p0.AbonentId, p0.CountMonth, p0.SumBalance * - 1 AS SumBalance, p0.PeriodNumber
		                          FROM            Pr_OioCountMonthAbonent AS p0 INNER JOIN
		                                                    Pr_OioCounterPeriod AS c0 ON p0.CountMonth BETWEEN c0.CountMin AND c0.CountMax
		                          WHERE        (p0.PeriodNumber = @MaxClosePeriod) AND (p0.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd0 RIGHT OUTER JOIN
		                         vPr_OioEventsPlane AS ev ON pd0.AbonentId = ev.AbonentId LEFT OUTER JOIN
		                             (SELECT        p9.AbonentId, p9.CountMonth, p9.SumBalance * - 1 AS SumBalance, p9.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p9 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c9 ON p9.CountMonth BETWEEN c9.CountMin AND c9.CountMax
		                               WHERE        (p9.PeriodNumber = @MaxClosePeriod) AND (c9.GroupCount = 9) AND (p9.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd9 ON 
		                         ev.AbonentId = pd9.AbonentId LEFT OUTER JOIN
		                             (SELECT        p8.AbonentId, p8.CountMonth, p8.SumBalance * - 1 AS SumBalance, p8.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p8 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c8 ON p8.CountMonth BETWEEN c8.CountMin AND c8.CountMax
		                               WHERE        (p8.PeriodNumber = @MaxClosePeriod) AND (c8.GroupCount = 8) AND (p8.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd8 ON 
		                         ev.AbonentId = pd8.AbonentId LEFT OUTER JOIN
		                             (SELECT        p7.AbonentId, p7.CountMonth, p7.SumBalance * - 1 AS SumBalance, p7.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p7 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c7 ON p7.CountMonth BETWEEN c7.CountMin AND c7.CountMax
		                               WHERE        (p7.PeriodNumber = @MaxClosePeriod) AND (c7.GroupCount = 7) AND (p7.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd7 ON 
		                         ev.AbonentId = pd7.AbonentId LEFT OUTER JOIN
		                             (SELECT        p6.AbonentId, p6.CountMonth, p6.SumBalance * - 1 AS SumBalance, p6.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p6 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c6 ON p6.CountMonth BETWEEN c6.CountMin AND c6.CountMax
		                               WHERE        (p6.PeriodNumber = @MaxClosePeriod) AND (c6.GroupCount = 6) AND (p6.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd6 ON 
		                         ev.AbonentId = pd6.AbonentId LEFT OUTER JOIN
		                             (SELECT        p5.AbonentId, p5.CountMonth, p5.SumBalance * - 1 AS SumBalance, p5.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p5 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c5 ON p5.CountMonth BETWEEN c5.CountMin AND c5.CountMax
		                               WHERE        (p5.PeriodNumber = @MaxClosePeriod) AND (c5.GroupCount = 5) AND (p5.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd5 ON 
		                         ev.AbonentId = pd5.AbonentId LEFT OUTER JOIN
		                             (SELECT        p4.AbonentId, p4.CountMonth, p4.SumBalance * - 1 AS SumBalance, p4.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p4 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c4 ON p4.CountMonth BETWEEN c4.CountMin AND c4.CountMax
		                               WHERE        (p4.PeriodNumber = @MaxClosePeriod) AND (c4.GroupCount = 4) AND (p4.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd4 ON 
		                         ev.AbonentId = pd4.AbonentId LEFT OUTER JOIN
		                             (SELECT        p3.AbonentId, p3.CountMonth, p3.SumBalance * - 1 AS SumBalance, p3.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p3 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c3 ON p3.CountMonth BETWEEN c3.CountMin AND c3.CountMax
		                               WHERE        (p3.PeriodNumber = @MaxClosePeriod) AND (c3.GroupCount = 3) AND (p3.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd3 ON 
		                         ev.AbonentId = pd3.AbonentId LEFT OUTER JOIN
		                             (SELECT        p2.AbonentId, p2.CountMonth, p2.SumBalance * - 1 AS SumBalance, p2.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p2 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c2 ON p2.CountMonth BETWEEN c2.CountMin AND c2.CountMax
		                               WHERE        (p2.PeriodNumber = @MaxClosePeriod) AND (c2.GroupCount = 2) AND (p2.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd2 ON 
		                         ev.AbonentId = pd2.AbonentId LEFT OUTER JOIN
		                         vAbonents AS a ON ev.AbonentId = a.AbonentId
		WHERE        (ev.KVZ_EventTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@fltrEventsList,',') AS pgtfs))
		GROUP BY a.CityVillage, a.Areal
		UNION ALL
		SELECT        	999999 AS RowId,
						a.Areal AS GroupName, 
						'Итого:' AS Тotal,
						SUM(pd2.SumBalance) AS Group2_sum, 
						COUNT(pd2.AbonentId) AS Group2_count,
						SUM(pd3.SumBalance) AS Group3_sum, 
						COUNT(pd3.AbonentId) AS Group3_count,
						SUM(pd4.SumBalance) AS Group4_sum, 
						COUNT(pd4.AbonentId) AS Group4_count,
						SUM(pd5.SumBalance) AS Group5_sum, 
						COUNT(pd5.AbonentId) AS Group5_count,
						SUM(pd6.SumBalance) AS Group6_sum, 
						COUNT(pd6.AbonentId) AS Group6_count,
						SUM(pd7.SumBalance) AS Group7_sum, 
						COUNT(pd7.AbonentId) AS Group7_count,
						SUM(pd8.SumBalance) AS Group8_sum, 
						COUNT(pd8.AbonentId) AS Group8_count,
						SUM(pd9.SumBalance) AS Group9_sum, 
						COUNT(pd9.AbonentId) AS Group9_count,
						SUM(pd0.SumBalance) AS Group0_sum, 
						COUNT(pd0.AbonentId) AS Group0_count
		FROM            (SELECT        p0.AbonentId, p0.CountMonth, p0.SumBalance * - 1 AS SumBalance, p0.PeriodNumber
		                          FROM            Pr_OioCountMonthAbonent AS p0 INNER JOIN
		                                                    Pr_OioCounterPeriod AS c0 ON p0.CountMonth BETWEEN c0.CountMin AND c0.CountMax
		                          WHERE        (p0.PeriodNumber = @MaxClosePeriod) AND (p0.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd0 RIGHT OUTER JOIN
		                         vPr_OioEventsPlane AS ev ON pd0.AbonentId = ev.AbonentId LEFT OUTER JOIN
		                             (SELECT        p9.AbonentId, p9.CountMonth, p9.SumBalance * - 1 AS SumBalance, p9.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p9 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c9 ON p9.CountMonth BETWEEN c9.CountMin AND c9.CountMax
		                               WHERE        (p9.PeriodNumber = @MaxClosePeriod) AND (c9.GroupCount = 9) AND (p9.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd9 ON 
		                         ev.AbonentId = pd9.AbonentId LEFT OUTER JOIN
		                             (SELECT        p8.AbonentId, p8.CountMonth, p8.SumBalance * - 1 AS SumBalance, p8.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p8 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c8 ON p8.CountMonth BETWEEN c8.CountMin AND c8.CountMax
		                               WHERE        (p8.PeriodNumber = @MaxClosePeriod) AND (c8.GroupCount = 8) AND (p8.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd8 ON 
		                         ev.AbonentId = pd8.AbonentId LEFT OUTER JOIN
		                             (SELECT        p7.AbonentId, p7.CountMonth, p7.SumBalance * - 1 AS SumBalance, p7.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p7 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c7 ON p7.CountMonth BETWEEN c7.CountMin AND c7.CountMax
		                               WHERE        (p7.PeriodNumber = @MaxClosePeriod) AND (c7.GroupCount = 7) AND (p7.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd7 ON 
		                         ev.AbonentId = pd7.AbonentId LEFT OUTER JOIN
		                             (SELECT        p6.AbonentId, p6.CountMonth, p6.SumBalance * - 1 AS SumBalance, p6.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p6 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c6 ON p6.CountMonth BETWEEN c6.CountMin AND c6.CountMax
		                               WHERE        (p6.PeriodNumber = @MaxClosePeriod) AND (c6.GroupCount = 6) AND (p6.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd6 ON 
		                         ev.AbonentId = pd6.AbonentId LEFT OUTER JOIN
		                             (SELECT        p5.AbonentId, p5.CountMonth, p5.SumBalance * - 1 AS SumBalance, p5.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p5 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c5 ON p5.CountMonth BETWEEN c5.CountMin AND c5.CountMax
		                               WHERE        (p5.PeriodNumber = @MaxClosePeriod) AND (c5.GroupCount = 5) AND (p5.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd5 ON 
		                         ev.AbonentId = pd5.AbonentId LEFT OUTER JOIN
		                             (SELECT        p4.AbonentId, p4.CountMonth, p4.SumBalance * - 1 AS SumBalance, p4.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p4 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c4 ON p4.CountMonth BETWEEN c4.CountMin AND c4.CountMax
		                               WHERE        (p4.PeriodNumber = @MaxClosePeriod) AND (c4.GroupCount = 4) AND (p4.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd4 ON 
		                         ev.AbonentId = pd4.AbonentId LEFT OUTER JOIN
		                             (SELECT        p3.AbonentId, p3.CountMonth, p3.SumBalance * - 1 AS SumBalance, p3.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p3 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c3 ON p3.CountMonth BETWEEN c3.CountMin AND c3.CountMax
		                               WHERE        (p3.PeriodNumber = @MaxClosePeriod) AND (c3.GroupCount = 3) AND (p3.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd3 ON 
		                         ev.AbonentId = pd3.AbonentId LEFT OUTER JOIN
		                             (SELECT        p2.AbonentId, p2.CountMonth, p2.SumBalance * - 1 AS SumBalance, p2.PeriodNumber
		                               FROM            Pr_OioCountMonthAbonent AS p2 INNER JOIN
		                                                         Pr_OioCounterPeriod AS c2 ON p2.CountMonth BETWEEN c2.CountMin AND c2.CountMax
		                               WHERE        (p2.PeriodNumber = @MaxClosePeriod) AND (c2.GroupCount = 2) AND (p2.SumBalance * - 1 BETWEEN @BalanceMin AND @BalanceMax)) AS pd2 ON 
		                         ev.AbonentId = pd2.AbonentId LEFT OUTER JOIN
		                         vAbonents AS a ON ev.AbonentId = a.AbonentId
		WHERE        (ev.KVZ_EventTypeId IN (SELECT * FROM dbo.Pr_fntGetTableFromString(@fltrEventsList,',') AS pgtfs))
		GROUP BY a.Areal
		ORDER BY GroupName, RowId
	END
END
GO
GRANT EXECUTE ON Pr_OioDebetMap TO KvzWorker
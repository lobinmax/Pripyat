IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_ListOfMonth' AND type = 'V')
    DROP VIEW vPr_ListOfMonth
GO
--
CREATE VIEW vPr_ListOfMonth
AS
SELECT        1 AS MonthId, '01' AS strMonthId, '1. Январь' AS Name, 'Январь' AS Title, 'Янв' AS Short
UNION
SELECT        2 AS MonthId, '02' AS strMonthId, '2. Февраль' AS Name, 'Февраль' AS Title, 'Фев' AS Short
UNION
SELECT        3 AS MonthId, '03' AS strMonthId, '3. Март' AS Name, 'Март' AS Title, 'Мар' AS Short
UNION
SELECT        4 AS MonthId, '04' AS strMonthId, '4. Апрель' AS Name, 'Апрель' AS Title, 'Апр' AS Short
UNION
SELECT        5 AS MonthId, '05' AS strMonthId, '5. Май' AS Name, 'Май' AS Title, 'Май' AS Short
UNION
SELECT        6 AS MonthId, '06' AS strMonthId, '6. Июнь' AS Name, 'Июнь' AS Title, 'Июн' AS Short
UNION
SELECT        7 AS MonthId, '07' AS strMonthId, '7. Июль' AS Name, 'Июль' AS Title, 'Июл' AS Short
UNION
SELECT        8 AS MonthId, '08' AS strMonthId, '8. Август' AS Name, 'Август' AS Title, 'Авг' AS Short
UNION
SELECT        9 AS MonthId, '09' AS strMonthId, '9. Сентябрь' AS Name, 'Сентябрь' AS Title, 'Сен' AS Short
UNION
SELECT        10 AS MonthId, '10' AS strMonthId, '10. Октябрь' AS Name, 'Октябрь' AS Title, 'Окт' AS Short
UNION
SELECT        11 AS MonthId, '11' AS strMonthId, '11. Ноябрь' AS Name, 'Ноябрь' AS Title, 'Ноя' AS Short
UNION
SELECT        12 AS MonthId, '12' AS strMonthId, '12. Декабрь' AS Name, 'Декабрь' AS Title, 'Дек' AS Short
GO
GRANT SELECT ON vPr_ListOfMonth TO KvzWorker
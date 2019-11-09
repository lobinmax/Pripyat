IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_ListOfMonth' AND type = 'V')
    DROP VIEW vPr_ListOfMonth
GO
--
CREATE VIEW vPr_ListOfMonth
AS
SELECT        1 AS MonthId, '01' AS strMonthId, '1. ������' AS Name, '������' AS Title, '���' AS Short
UNION
SELECT        2 AS MonthId, '02' AS strMonthId, '2. �������' AS Name, '�������' AS Title, '���' AS Short
UNION
SELECT        3 AS MonthId, '03' AS strMonthId, '3. ����' AS Name, '����' AS Title, '���' AS Short
UNION
SELECT        4 AS MonthId, '04' AS strMonthId, '4. ������' AS Name, '������' AS Title, '���' AS Short
UNION
SELECT        5 AS MonthId, '05' AS strMonthId, '5. ���' AS Name, '���' AS Title, '���' AS Short
UNION
SELECT        6 AS MonthId, '06' AS strMonthId, '6. ����' AS Name, '����' AS Title, '���' AS Short
UNION
SELECT        7 AS MonthId, '07' AS strMonthId, '7. ����' AS Name, '����' AS Title, '���' AS Short
UNION
SELECT        8 AS MonthId, '08' AS strMonthId, '8. ������' AS Name, '������' AS Title, '���' AS Short
UNION
SELECT        9 AS MonthId, '09' AS strMonthId, '9. ��������' AS Name, '��������' AS Title, '���' AS Short
UNION
SELECT        10 AS MonthId, '10' AS strMonthId, '10. �������' AS Name, '�������' AS Title, '���' AS Short
UNION
SELECT        11 AS MonthId, '11' AS strMonthId, '11. ������' AS Name, '������' AS Title, '���' AS Short
UNION
SELECT        12 AS MonthId, '12' AS strMonthId, '12. �������' AS Name, '�������' AS Title, '���' AS Short
GO
GRANT SELECT ON vPr_ListOfMonth TO KvzWorker
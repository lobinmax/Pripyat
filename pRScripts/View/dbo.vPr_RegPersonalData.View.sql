IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_RegPersonalData' AND type = 'V')
    DROP VIEW vPr_RegPersonalData
GO
--
CREATE VIEW vPr_RegPersonalData
AS
/*
=========================================	
|	������������� �������� ����������	|
|	�� ������������ ������  			|
=========================================
*/
SELECT 	'��������������� � ���' AS States, 
		(SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.RegPersonalAccount = 1) AS [Count], 
		CAST(CAST(((CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.RegPersonalAccount = 1) AS NUMERIC(10,2)))
		/
		CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a) AS NUMERIC(10,2))) * 100 AS NUMERIC(10,2)) AS VARCHAR) + '%' AS [Percent]
UNION ALL
SELECT 	'����� ����������� �����', 
		(SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.email LIKE '%@%') AS [Count], 
		CAST(CAST(((CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.email LIKE '%@%') AS NUMERIC(10,2)))
		/
		CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a) AS NUMERIC(10,2))) * 100 AS NUMERIC(10,2)) AS VARCHAR) + '%' AS [Percent]
UNION ALL
SELECT 	'������� �������:', NULL, NULL
UNION ALL
SELECT 	'     - ������� ������������', 
		(SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.Phone LIKE '839%') AS [Count], 
		CAST(CAST(((CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.Phone LIKE '839%') AS NUMERIC(10,2)))
		/
		CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a) AS NUMERIC(10,2))) * 100 AS NUMERIC(10,2)) AS VARCHAR) + '%' AS [Percent]
UNION ALL
SELECT 	'     - ������� ���������', 
		(SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.PhoneMobile LIKE '9%') AS [Count], 
		CAST(CAST(((CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.PhoneMobile LIKE '9%') AS NUMERIC(10,2)))
		/
		CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a) AS NUMERIC(10,2))) * 100 AS NUMERIC(10,2)) AS VARCHAR) + '%' AS [Percent]
UNION ALL
SELECT 	'������� � ������:', NULL, NULL
UNION ALL
SELECT 	'     - ������� ������������', 
		(SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.PhoneProfiles LIKE '839%') AS [Count], 
		CAST(CAST(((CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.PhoneProfiles LIKE '839%') AS NUMERIC(10,2)))
		/
		CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a) AS NUMERIC(10,2))) * 100 AS NUMERIC(10,2)) AS VARCHAR) + '%' AS [Percent]
UNION ALL
SELECT 	'     - ������� ���������', 
		(SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.PhoneMobileProfiles LIKE '9%') AS [Count], 
		CAST(CAST(((CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a WHERE a.PhoneMobileProfiles LIKE '9%') AS NUMERIC(10,2)))
		/
		CAST((SELECT COUNT(a.AbonentId) AS Count FROM Abonents a) AS NUMERIC(10,2))) * 100 AS NUMERIC(10,2)) AS VARCHAR) + '%' AS [Percent]
GO
GRANT SELECT ON vPr_RegPersonalData TO KvzWorker
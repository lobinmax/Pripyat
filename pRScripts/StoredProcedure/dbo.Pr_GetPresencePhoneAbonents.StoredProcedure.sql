IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetPresencePhoneAbonents' AND type = 'P')
    DROP PROCEDURE dbo.Pr_GetPresencePhoneAbonents
GO

CREATE PROCEDURE [dbo].[Pr_GetPresencePhoneAbonents]
-- ������� ���������� ���� ������ ����������� �������� ���������
	
	AS

SET NOCOUNT ON			-- ��������� ������� ������������ �����
SET XACT_ABORT ON		-- ������ ���������� ���� ������

SELECT        '������� � ���� ���������� ��������' AS [��� �����],
                             (SELECT        COUNT(AbonentId) AS c
                               FROM            Abonents
                               WHERE        (PhoneMobile <> '')) AS ����������, CAST(CAST
                             ((SELECT        CAST(COUNT(AbonentId) AS money) AS c
                                 FROM            Abonents AS Abonents_1
                                 WHERE        (PhoneMobile <> '')) * 100 /
                             (SELECT        CAST(COUNT(AbonentId) AS money) AS c
                               FROM            Abonents AS Abonents_2) AS numeric(4, 2)) AS varchar) + '%' AS �������
UNION ALL
SELECT        '������� � ���� ���������� ��������' AS [��� �����],
                             (SELECT        COUNT(AbonentId) AS c
                               FROM            Abonents
                               WHERE        (Phone <> '')) AS ����������, CAST(CAST
                             ((SELECT        CAST(COUNT(AbonentId) AS money) AS c
                                 FROM            Abonents AS Abonents_1
                                 WHERE        (Phone <> '')) * 100 /
                             (SELECT        CAST(COUNT(AbonentId) AS money) AS c
                               FROM            Abonents AS Abonents_2) AS numeric(4, 2)) AS varchar) + '%' AS �������
UNION ALL
SELECT        '������� � ���� ������������ ������' AS [��� �����],
                             (SELECT        COUNT(AbonentId) AS c
                               FROM            Abonents
                               WHERE        (email <> '')) AS ����������, CAST(CAST
                             ((SELECT        CAST(COUNT(AbonentId) AS money) AS c
                                 FROM            Abonents AS Abonents_1
                                 WHERE        (email <> '')) * 100 /
                             (SELECT        CAST(COUNT(AbonentId) AS money) AS c
                               FROM            Abonents AS Abonents_2) AS numeric(4, 2)) AS varchar) + '%' AS �������
GRANT EXECUTE ON Pr_GetPresencePhoneAbonents TO KvzWorker
GO

GRANT EXECUTE ON dbo.Pr_GetPresencePhoneAbonents TO KvzWorker

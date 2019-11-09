IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetPresencePhoneAbonents' AND type = 'P')
    DROP PROCEDURE dbo.Pr_GetPresencePhoneAbonents
GO

CREATE PROCEDURE [dbo].[Pr_GetPresencePhoneAbonents]
-- Процент наполнения базы данных телефонными номерами абонентов
	
	AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать если ошибка

SELECT        'Наличие в базе мобильного телефона' AS [Вид связи],
                             (SELECT        COUNT(AbonentId) AS c
                               FROM            Abonents
                               WHERE        (PhoneMobile <> '')) AS Количество, CAST(CAST
                             ((SELECT        CAST(COUNT(AbonentId) AS money) AS c
                                 FROM            Abonents AS Abonents_1
                                 WHERE        (PhoneMobile <> '')) * 100 /
                             (SELECT        CAST(COUNT(AbonentId) AS money) AS c
                               FROM            Abonents AS Abonents_2) AS numeric(4, 2)) AS varchar) + '%' AS Процент
UNION ALL
SELECT        'Наличие в базе городского телефона' AS [Вид связи],
                             (SELECT        COUNT(AbonentId) AS c
                               FROM            Abonents
                               WHERE        (Phone <> '')) AS Количество, CAST(CAST
                             ((SELECT        CAST(COUNT(AbonentId) AS money) AS c
                                 FROM            Abonents AS Abonents_1
                                 WHERE        (Phone <> '')) * 100 /
                             (SELECT        CAST(COUNT(AbonentId) AS money) AS c
                               FROM            Abonents AS Abonents_2) AS numeric(4, 2)) AS varchar) + '%' AS Процент
UNION ALL
SELECT        'Наличие в базе электронного адреса' AS [Вид связи],
                             (SELECT        COUNT(AbonentId) AS c
                               FROM            Abonents
                               WHERE        (email <> '')) AS Количество, CAST(CAST
                             ((SELECT        CAST(COUNT(AbonentId) AS money) AS c
                                 FROM            Abonents AS Abonents_1
                                 WHERE        (email <> '')) * 100 /
                             (SELECT        CAST(COUNT(AbonentId) AS money) AS c
                               FROM            Abonents AS Abonents_2) AS numeric(4, 2)) AS varchar) + '%' AS Процент
GRANT EXECUTE ON Pr_GetPresencePhoneAbonents TO KvzWorker
GO

GRANT EXECUTE ON dbo.Pr_GetPresencePhoneAbonents TO KvzWorker

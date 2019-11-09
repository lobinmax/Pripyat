IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'lobin_Statistics' AND type = 'P')
    DROP PROCEDURE dbo.lobin_Statistics
GO
CREATE PROCEDURE dbo.lobin_Statistics
--Для отчета Количество абонентов 
@Period	INT = 201601	 -- период для выгрузки
AS
/*	Принятые на учет абоненты в заданном периоде, включая Собственников помещения
	В истории одна запись за период и она Принят на учет */ 
SELECT 'Принято впервые в ' + CAST (@Period AS VARCHAR) AS Признак,	COUNT(*) AS Количество
												FROM (	SELECT ah1.AbonentId AS IdCount
														FROM dbo.AbonentsHistory AS ah INNER JOIN
															dbo.AbonentsHistory AS ah1 ON ah.AbonentId = ah1.AbonentId INNER JOIN
															dbo.Elements AS e ON ah1.AbonentId = e.ElementId
														GROUP BY ah1.AbonentId, ah1.PeriodNumber, ah1.AbonentStatusId
														HAVING	(COUNT(ah.AbonentId) = 1) AND 
															(ah1.PeriodNumber = @Period) AND 
															(ah1.AbonentStatusId = 1)) AS iStatistics
UNION	
SELECT 'Долги погашены в ' + CAST (@Period AS VARCHAR) AS Признак,	COUNT(*) AS Количество
												FROM (	SELECT     ah1.AbonentId AS IdCount
														FROM dbo.AbonentsHistory AS ah INNER JOIN
															dbo.AbonentsHistory AS ah1 ON ah.AbonentId = ah1.AbonentId INNER JOIN
															dbo.Elements AS e ON ah1.AbonentId = e.ElementId
														GROUP BY ah1.AbonentId, ah1.PeriodNumber, ah1.ExtAbonentStatusId
														HAVING	(ah1.PeriodNumber = @Period) AND 
																(ah1.ExtAbonentStatusId = 130)) AS iStatistics
UNION
SELECT 'Сняты с учета в ' + CAST (@Period AS VARCHAR) AS Признак,	COUNT(*) AS Количество
											FROM (	SELECT ah1.AbonentId AS IdCount
													FROM dbo.AbonentsHistory AS ah INNER JOIN
														dbo.AbonentsHistory AS ah1 ON ah.AbonentId = ah1.AbonentId INNER JOIN
														dbo.Elements AS e ON ah1.AbonentId = e.ElementId
													GROUP BY ah1.AbonentId, ah1.PeriodNumber, ah1.AbonentStatusId
													HAVING	(ah1.PeriodNumber = @Period) AND 
															(ah1.AbonentStatusId = 2)) AS iStatistics
UNION
SELECT 'Отключено за долги в ' + CAST (@Period AS VARCHAR) AS Признак,	COUNT(*) AS Количество
													FROM (	SELECT ah1.AbonentId AS IdCount
															FROM dbo.AbonentsHistory AS ah INNER JOIN
																dbo.AbonentsHistory AS ah1 ON ah.AbonentId = ah1.AbonentId INNER JOIN
																dbo.Elements AS e ON ah1.AbonentId = e.ElementId
													GROUP BY ah1.AbonentId, ah1.PeriodNumber, ah1.ExtAbonentStatusId
													HAVING	(ah1.PeriodNumber = @Period) AND 
															(ah1.ExtAbonentStatusId = 230)) AS iStatistics
UNION
SELECT 'Принято по данным РО в ' + CAST (@Period AS VARCHAR) AS Признак,	COUNT(*) AS Количество
													FROM (	SELECT ah1.AbonentId AS IdCount
															FROM dbo.AbonentsHistory AS ah INNER JOIN
																dbo.AbonentsHistory AS ah1 ON ah.AbonentId = ah1.AbonentId INNER JOIN
																dbo.Elements AS e ON ah1.AbonentId = e.ElementId
															GROUP BY ah1.AbonentId, ah1.PeriodNumber, ah1.AbonentStatusId, e.Name
															HAVING	(ah1.PeriodNumber = @Period) AND 
																	(ah1.AbonentStatusId = 1) AND 
																	(COUNT(ah.AbonentId) = 1) AND 
																	(e.Name = 'Собственник')) AS iStatistics
UNION
SELECT 'Снято по данным РО в ' + CAST (@Period AS VARCHAR) AS Признак,	COUNT(*) AS Количество
													FROM (	SELECT ah1.AbonentId AS IdCount
															FROM	dbo.AbonentsHistory AS ah INNER JOIN
																	dbo.AbonentsHistory AS ah1 ON ah.AbonentId = ah1.AbonentId INNER JOIN
																	dbo.Elements AS e ON ah1.AbonentId = e.ElementId
															GROUP BY ah1.AbonentId, ah1.PeriodNumber, ah1.AbonentStatusId, e.Name
															HAVING	(ah1.PeriodNumber = @Period) AND 
																	(ah1.AbonentStatusId = 2) AND 
																	(e.Name = 'Собственник')) AS iStatistics

ORDER BY [Признак]

GO
GRANT EXECUTE ON dbo.lobin_Statistics TO KvzWorker
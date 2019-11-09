IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_AbonentCountersList' AND type = 'P')
    DROP PROCEDURE dboPr_AbonentCountersList
GO

CREATE PROCEDURE [dbo].[Pr_AbonentCountersList]
-- Перечень текущих ПУ по каждой ТУ принадлежащих абоненту
@AbonentId		INT = NULL,	-- ИД абонента
@EnergyTypeId	INT = 1		-- Тип энергии
AS

SET NOCOUNT ON				-- Отключить счетчик обработанных строк
SET XACT_ABORT ON			-- Всегда откатывать по ошибке


SELECT		cast(0 as bit)  as iCheck,	
			Points.AbonentId, 
			Points.PointId, 
			Points.PointNumber, 
			CounterHistoryMax.DtCountSetup, 
			CounterTypes.Name AS CounterName, 
			CountersHistory_1.CounterNumber
			
FROM		CounterTypes INNER JOIN
			CountersHistory AS CountersHistory_1 ON CounterTypes.CounterTypeId = CountersHistory_1.CounterTypeId RIGHT OUTER JOIN
            Points INNER JOIN
                             (
							  SELECT	PointId, 
										MAX(DtCountSetup) AS DtCountSetup
                              FROM		CountersHistory
                              GROUP BY PointId
							 ) 
								AS CounterHistoryMax 

			ON Points.PointId = CounterHistoryMax.PointId 
			ON CountersHistory_1.PointId = CounterHistoryMax.PointId 
			AND CountersHistory_1.DtCountSetup = CounterHistoryMax.DtCountSetup

WHERE       (Points.EnergyTypeId = @EnergyTypeId) AND 
			(Points.AbonentId = @AbonentId)

ORDER BY	Points.PointNumber

RETURN
GO

GRANT EXECUTE ON dbo.Pr_AbonentCountersList TO KvzWorker

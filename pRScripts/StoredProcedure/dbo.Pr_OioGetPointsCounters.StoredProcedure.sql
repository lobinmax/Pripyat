IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OioGetPointsCounters' AND type = 'P')
    DROP PROCEDURE dbo.Pr_OioGetPointsCounters
GO
CREATE PROCEDURE dbo.Pr_OioGetPointsCounters
	/*	Процедура для заполнения таблицы
		в акте на отключение			*/
	@AbonentId	INT		-- Ид абонента
AS

SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

SELECT ROW_NUMBER() OVER(ORDER BY p.PointNumber) Number, 
       CHAR(39) + p.PointNumber AS PointNumber, 
	   ct.Name AS CounterName, 
	   CHAR(39) + phmc.CounterNumber AS CounterNumber, 
	   CONVERT(VARCHAR, gpli.DtDoc, 104) + ' - ' + CAST(gpli.newindication AS VARCHAR) AS LastIndication
       FROM dbo.fnGetPointLastIndication() AS gpli 
INNER JOIN Points AS p ON gpli.PointId = p.PointId
INNER JOIN vPr_HistoryMaxCounters AS phmc ON gpli.PointId = phmc.PointId
INNER JOIN CounterTypes AS ct ON phmc.CounterTypeId = ct.CounterTypeId
WHERE gpli.PointId IN (
					   SELECT plps.PointId 
					   FROM vPoints_ListPointsStatus AS plps 
					   WHERE plps.AbonentId = @AbonentId AND 
					         plps.PointStatusId != 2 AND 
							 plps.EnergyTypeId = 1
					   )
GO
GRANT EXECUTE ON dbo.Pr_OioGetPointsCounters TO KvzWorker
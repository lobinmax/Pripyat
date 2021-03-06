IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetAbonentCounterNumber' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetAbonentCounterNumber
GO

CREATE FUNCTION [dbo].[Pr_fnsGetAbonentCounterNumber]
/*=======================================================
Функция возвращяет номер ПУ по абоненту у минимальной ТУ
среди электроэнергии
=======================================================*/
(
@AbonentId INT = 1
) 
RETURNS varchar(50)
AS
BEGIN
DECLARE @CounterNumber VARCHAR(50)
	SET @CounterNumber =	( 
							SELECT	ISNULL(CHAR(39) + ch.CounterNumber, NULL) AS CounterNumber
							FROM	(-- минимальный ИД ТУ
									SELECT		AbonentId,
												MIN(PointId) AS PointId
									FROM		dbo.Points AS P
									GROUP BY	AbonentId, EnergyTypeId
									HAVING		(AbonentId IS NOT NULL) AND 
												(EnergyTypeId = 1) -- ТУ только ЭЭ
									) AS PointsMax 
							LEFT OUTER JOIN		(-- последняя дата установки ПУ
												SELECT		PointId, 
															MAX(DtCountSetup) AS DtCountSetup
												FROM		dbo.CountersHistory
												GROUP BY PointId
												) AS CountersMax 
											ON PointsMax.PointId = CountersMax.PointId 
							LEFT OUTER JOIN dbo.CountersHistory AS ch ON PointsMax.PointId = ch.PointId AND CountersMax.DtCountSetup = ch.DtCountSetup
							WHERE			(PointsMax.AbonentId = @AbonentId)
							)
RETURN @CounterNumber	
END
GO

GRANT EXECUTE ON Pr_fnsGetAbonentCounterNumber TO KvzWorker	-- для скалярных

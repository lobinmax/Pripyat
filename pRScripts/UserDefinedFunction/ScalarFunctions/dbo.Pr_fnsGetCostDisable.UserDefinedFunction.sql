IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetCostDisable' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetCostDisable
GO

CREATE FUNCTION dbo.Pr_fnsGetCostDisable
-- функция возращает стоимость работ по окл/вкл
(
@AbonentId		INT,
@Parameter		INT --0 - Стоимость допов
					--1 - Дата вступления в силу размера допов
) 

RETURNS VARCHAR(20)

AS
BEGIN
DECLARE		@ServiceId_13			INT						--	Отключение
DECLARE		@ServiceId_4			INT						--	Подключение
DECLARE		@PowerNetworkOvnerId	INT						--	Ид владельца сетей
DECLARE		@ValueCost				VARCHAR(20) = NULL		--	Стоимость допа
DECLARE		@ValueDt				VARCHAR(20) = NULL		--	Дата начала действия
DECLARE		@Value					VARCHAR(20) = NULL		--	Выходное значение

-- определяем сетевую принадлежность у абонента
SELECT		@PowerNetworkOvnerId = PowerNetworks.PowerNetworkOvnerId
FROM		(
			SELECT		AbonentId, 
						MIN(PointId) AS PointId
			FROM		Points AS P
			GROUP BY	AbonentId, EnergyTypeId
			HAVING		(AbonentId IS NOT NULL) AND (EnergyTypeId = 1)
			) AS MaxPoints 
			INNER JOIN	Points ON MaxPoints.PointId = Points.PointId 
			INNER JOIN	PowerNetworks ON Points.PowerNetworkId = PowerNetworks.PowerNetworkId
WHERE		(MaxPoints.AbonentId = @AbonentId)

-- КрасЭко
IF @PowerNetworkOvnerId = 1 BEGIN
	SET @ServiceId_13 = 14
	SET @ServiceId_4 = 15
END
-- МРСК Сибири
IF @PowerNetworkOvnerId = 2 BEGIN
	SET @ServiceId_13 = 2
	SET @ServiceId_4 = 3
END
-- стоимость допов вычисляем только по КрасЭко либо МРСК Сибири
IF @PowerNetworkOvnerId IN(1,2) BEGIN 
	SELECT	@ValueCost =	SUM(Cost), @ValueDt = CONVERT(VARCHAR, c.DtBegin, 104)
	FROM		(
				SELECT		ServiceTariffsHistory.Value + ServiceTariffsHistory.NDS AS Cost , ServiceTariffsHistoryMax.DtBegin
				FROM		(
							SELECT		ServiceId, 
										MAX(DtBegin) AS DtBegin
							FROM		ServiceTariffsHistory AS sth
							GROUP BY	ServiceId
							) AS ServiceTariffsHistoryMax 
				INNER JOIN	AdditionalServiceTypes 
							ON ServiceTariffsHistoryMax.ServiceId = AdditionalServiceTypes.ServiceId 
				INNER JOIN	ServiceTariffsHistory 
							ON ServiceTariffsHistoryMax.ServiceId = ServiceTariffsHistory.ServiceId 
							AND ServiceTariffsHistoryMax.DtBegin = ServiceTariffsHistory.DtBegin
				GROUP BY	AdditionalServiceTypes.ServiceId, ServiceTariffsHistory.Value + ServiceTariffsHistory.NDS, ServiceTariffsHistoryMax.DtBegin
				HAVING		(AdditionalServiceTypes.ServiceId IN (@ServiceId_13, @ServiceId_4))
				) AS c
	 GROUP BY c.Cost, c.DtBegin
END
IF @Parameter = 0 BEGIN SET @Value = @ValueCost END -- стоимость
IF @Parameter = 1 BEGIN SET @Value = @ValueDt END	-- дата вступления
RETURN @Value
 END 
GO

GRANT EXECUTE ON dbo.Pr_fnsGetCostDisable TO KvzWorker
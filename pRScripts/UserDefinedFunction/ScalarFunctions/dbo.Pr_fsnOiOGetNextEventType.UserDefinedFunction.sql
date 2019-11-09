IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fsnOiOGetNextEventType' AND type = 'FN')
    DROP FUNCTION Pr_fsnOiOGetNextEventType
GO
--
CREATE FUNCTION dbo.Pr_fsnOiOGetNextEventType
	/*	Функция возвращает тип
		следующего события в работе с ДЗ */
	(
	@AbonentId	INT
	)
RETURNS INT
AS
BEGIN

DECLARE		@Value	INT
SET @Value =	(
				SELECT		CASE 
								WHEN vA.CalcTypeId = 1 THEN -- Жилые дома
									CASE 
										WHEN 
											OioEv1.DtFact IS NULL AND 
											OioEv3.DtFact IS NULL AND 
											OioEv6.DtFact IS NULL THEN 
										
											1 
										WHEN 
											OioEv1.DtFact IS NOT NULL AND 
											OioEv3.DtFact IS NULL AND 
											OioEv6.DtFact IS NULL THEN 
										
											3 
										WHEN 
											OioEv1.DtFact IS NOT NULL AND 
											OioEv3.DtFact IS NOT NULL AND 
											OioEv6.DtFact IS NULL THEN 
										
											6 
										WHEN 
											OioEv1.DtFact IS NOT NULL AND 
											OioEv3.DtFact IS NOT NULL AND 
											OioEv6.DtFact IS NOT NULL THEN 
										
											8 
										WHEN 
											OioEv1.DtFact IS NOT NULL AND 
											OioEv3.DtFact IS NULL AND 
											OioEv6.DtFact IS NOT NULL THEN  
										
											8 
										ELSE 
											0 
									END 
								WHEN vA.CalcTypeId = 2 THEN -- Гаражи
									CASE 
										WHEN 
											OioEv1.DtFact IS NULL AND 
											OioEv2.DtFact IS NULL AND 
											OioEv3.DtFact IS NULL AND 
											OioEv5.DtFact IS NULL AND 
											OioEv6.DtFact IS NULL THEN 
										
											1 
										WHEN 
											OioEv1.DtFact IS NOT NULL AND 
											OioEv2.DtFact IS NULL AND
											OioEv3.DtFact IS NULL AND 
											OioEv5.DtFact IS NULL AND 
											OioEv6.DtFact IS NULL THEN 
										
											6 
										WHEN 
											OioEv1.DtFact IS NOT NULL AND 
											OioEv2.DtFact IS NULL AND 
											OioEv3.DtFact IS NULL AND 
											OioEv5.DtFact IS NULL AND 
											OioEv6.DtFact IS NOT NULL THEN
										
											8 
										ELSE 
											0 
									END 
			 				END AS KVZ_EventTypeId

			FROM            OioAbonents AS OioA 
			LEFT OUTER JOIN vAbonents AS vA ON OioA.AbonentId = vA.AbonentId  
			LEFT OUTER JOIN OioEvents AS OioEv1 ON OioA.AbonentId = OioEv1.AbonentId AND OioA.DtBeginOio = OioEv1.DtBeginOio AND OioEv1.EventTypeId = 1 
			LEFT OUTER JOIN OioEvents AS OioEv2 ON OioA.AbonentId = OioEv2.AbonentId AND OioA.DtBeginOio = OioEv2.DtBeginOio AND OioEv2.EventTypeId = 2 
			LEFT OUTER JOIN OioEvents AS OioEv3 ON OioA.AbonentId = OioEv3.AbonentId AND OioA.DtBeginOio = OioEv3.DtBeginOio AND OioEv3.EventTypeId = 3
			LEFT OUTER JOIN OioEvents AS OioEv5 ON OioA.AbonentId = OioEv5.AbonentId AND OioA.DtBeginOio = OioEv5.DtBeginOio AND OioEv5.EventTypeId = 5 
			LEFT OUTER JOIN OioEvents AS OioEv6 ON OioA.AbonentId = OioEv6.AbonentId AND OioA.DtBeginOio = OioEv6.DtBeginOio AND OioEv6.EventTypeId = 6

			WHERE			OioA.DtEndOio > GETDATE() AND OioA.AbonentId = @AbonentId
				)
RETURN @Value
END
--
GO
GRANT EXECUTE ON Pr_fsnOiOGetNextEventType TO KvzWorker
IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'lobin_ReferenceOfReasons' AND type = 'P')
    DROP PROCEDURE dbo.lobin_ReferenceOfReasons
GO
CREATE PROCEDURE dbo.lobin_ReferenceOfReasons
--Для отчета "Причины обращений"
@DtStart	Datetime = '01.08.2016',
@DtEnd		Datetime = '01.08.2016',
@View		INT = 1

AS
-- Список
IF @View = 0 BEGIN
SELECT		AbonentsReferenceHistory.DtCreate, 
			AbonentsReferenceHistory.Phone, 
			AbonentsReferenceReason.Name AS Reason, 
			vAbonentsReferenceSource.Name AS Metod, 
			vPerformers.Name AS Avtor

FROM        AbonentsReferenceHistory AS AbonentsReferenceHistory INNER JOIN
            AbonentsReferenceReason AS AbonentsReferenceReason ON 
			AbonentsReferenceHistory.ReasonId = AbonentsReferenceReason.ReasonId INNER JOIN
            vAbonentsReferenceSource AS vAbonentsReferenceSource ON 
		    AbonentsReferenceHistory.SourceId = vAbonentsReferenceSource.SourceId INNER JOIN
            vPerformers AS vPerformers ON 

			AbonentsReferenceHistory.PerformerId = vPerformers.PerformerId
WHERE		(AbonentsReferenceHistory.DtCreate >= CAST(@DtStart AS DATE)) AND (AbonentsReferenceHistory.DtCreate <= CAST(@DtEnd AS DATE))
END

-- В разрезе причин
IF @View = 1 BEGIN
SELECT		vAbonentsReferenceSource.Name AS Metod, 
			AbonentsReferenceReason.Name AS Reason, 
			COUNT(AbonentsReferenceHistory.DtCreate) AS Count
FROM        AbonentsReferenceHistory AS AbonentsReferenceHistory INNER JOIN
            AbonentsReferenceReason AS AbonentsReferenceReason ON 
			AbonentsReferenceHistory.ReasonId = AbonentsReferenceReason.ReasonId INNER JOIN
			vAbonentsReferenceSource AS vAbonentsReferenceSource ON 
			AbonentsReferenceHistory.SourceId = vAbonentsReferenceSource.SourceId INNER JOIN
			vPerformers AS vPerformers ON AbonentsReferenceHistory.PerformerId = vPerformers.PerformerId

WHERE		(AbonentsReferenceHistory.DtCreate >= CAST(@DtStart AS DATE)) AND (AbonentsReferenceHistory.DtCreate <= CAST(@DtEnd AS DATE))

GROUP BY	AbonentsReferenceReason.Name, vAbonentsReferenceSource.Name
ORDER BY	Metod, Reason, Count
END
GO
GRANT EXECUTE ON dbo.lobin_ReferenceOfReasons TO KvzWorker
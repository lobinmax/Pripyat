IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'lobin_ReportGKH_22' AND type = 'P')
    DROP PROCEDURE dbo.lobin_ReportGKH_22
GO

CREATE PROCEDURE dbo.lobin_ReportGKH_22
@Period1 INT = 201601,
@Period2 INT = 201602
AS
-- Для отчета ЖКХ форма 22
SELECT		vPayments.PeriodNumber,							-- Период платежей
			SUM(vPayments.MoneyAmount) AS 'SumPayment',		-- Сумма платежей в периоде
			vAbonentsCookers.cookerid,						-- ИД типа плиты
			Cookers.Name AS 'CookersName',					-- Тип плиты
			LodgersCount.Count AS 'CountLodgers'			-- Количество прописанных на текущий момент

FROM		Cookers AS Cookers INNER JOIN
			vAbonentsCookers AS vAbonentsCookers ON Cookers.CookerId = vAbonentsCookers.cookerid INNER JOIN
			vPayments_JournalOfWirings AS vPayments ON vAbonentsCookers.abonentid = vPayments.AbonentId INNER JOIN
                             (
							  SELECT	vAc.cookerid,					-- ИД типа плиты
										SUM(vL.CountLodgers) AS Count	-- Количество зарегистрированных
                               FROM		Cookers AS c INNER JOIN
										vAbonentsCookers AS vAc ON c.CookerId = vAc.cookerid INNER JOIN
										vSchemes_Lodgers_DtEnd AS vL ON vAc.abonentid = vL.AbonentId INNER JOIN
										vSchemes_AbonentsHistory_DtEnd AS vAst ON vAc.abonentid = vAst.AbonentId LEFT OUTER JOIN
										AgentContractsCommunication AS AgC ON vAc.abonentid = AgC.AbonentId
                               WHERE	(vL.DtEnd > CAST('01.01.2075' AS date)) AND							-- Последняя запись в истории прописанных
										(vAst.DtEnd > CAST('01.01.2075' AS date)) AND						-- Последняя запись в истории абонента
										(vAst.ExtAbonentStatusId IN (110, 120, 130, 140, 150, 230)) AND		-- Только принятые на учет и Отключенные за долги
										(AgC.AbonentId IS NULL)												-- Исключаем абнентов на агенских договорах
                               GROUP BY vAc.cookerid
							  ) AS LodgersCount 
													ON vAbonentsCookers.cookerid = LodgersCount.cookerid LEFT OUTER JOIN
			AgentContractsCommunication ON vAbonentsCookers.abonentid = AgentContractsCommunication.AbonentId

WHERE		(vPayments.EnergyTypeId = 1) AND		-- Электроэнергия
			(vPayments.DocumentTypeId = 1) AND		-- Квитанция
			(vPayments.PlanId NOT IN (15, 16))		-- Исключение допов (Отключение/Подключение)

GROUP BY	vPayments.PeriodNumber, 
			Cookers.Name, 
			LodgersCount.Count, 
			vAbonentsCookers.cookerid, 
			AgentContractsCommunication.AbonentId

HAVING		(vPayments.PeriodNumber >= @Period1) AND 
			(vPayments.PeriodNumber <= @Period2) AND 
			(AgentContractsCommunication.AbonentId IS NULL)

ORDER BY	vPayments.PeriodNumber, 
			vAbonentsCookers.cookerid

GO
GRANT EXECUTE ON dbo.lobin_ReportGKH_22 TO KvzWorker
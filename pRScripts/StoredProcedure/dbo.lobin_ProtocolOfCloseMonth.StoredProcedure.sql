IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'lobin_ProtocolOfCloseMonth' AND type = 'P')
    DROP PROCEDURE dbo.lobin_ProtocolOfCloseMonth
GO
CREATE PROCEDURE dbo.lobin_ProtocolOfCloseMonth
	@PeriodNumber	INT = 201601,	 -- период для выгрузки
	@EnergyType INT = 1, /* тип энергии 1 - ЭЭ
									    5 - КР*/
	@Function INT = 1	/*	1 - реест лицевых
							2 - групировка по контролерам*/
AS

DECLARE @PeriodNumberPast INT				-- Переменная для предыдущего периода
SET @PeriodNumberPast = @PeriodNumber - 1	-- Текущий период минус 1

	-- Если месяц текущего периода Январь то, минус 89
IF RIGHT(@PeriodNumber, 2) = 01 BEGIN	
	SET @PeriodNumberPast=@PeriodNumber-89
END

RAISERROR ('', 16, 2)
RETURN 0

IF @Function = 1 BEGIN
SELECT    ISNULL(b.PeriodNumber, @PeriodNumber) AS PeriodNumber, p.PointNumber, dbo.vAbonents.LastSurName, 
                      dbo.vAbonents.CommAddressString AS Address, dbo.vPerformersName.Name AS ControlerName, BalanceOfClosedMonths.InSumBalance, 
                      BalanceOfClosedMonths.InPowerBalance, ISNULL(SUM(ISNULL(b.SumCharges, $0)), $0) AS SumCharges, ISNULL(SUM(ISNULL(b.SumPayments, $0)), 
                      $0) AS SumPayments, ISNULL(SUM(ISNULL(b.CorrectSumCharges, $0)), $0) + ISNULL(SUM(ISNULL(eb.PowerAmount, $0)), $0) AS CorrectSumCharges, 
                      ISNULL(SUM(ISNULL(b.PowerCharges, $0)), $0) AS PowerCharges, ISNULL(SUM(ISNULL(b.PowerActual, $0)), $0) AS PowerActual, 
                      ISNULL(SUM(ISNULL(b.CorrectPowerCharges, $0)), $0) + ISNULL(SUM(ISNULL(eb.MoneyAmount, $0)), $0) AS CorrectPowerCharges, 
                      ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) AS SumBalance, ISNULL(SUM(ISNULL(b.PowerBalance, $0)), $0) AS PowerBalance
FROM         dbo.vPerformersName INNER JOIN
                      dbo.vAbonents ON dbo.vPerformersName.PerformerId = dbo.vAbonents.ControllerId RIGHT OUTER JOIN
                      dbo.Points AS p INNER JOIN
                      dbo.Accounts AS a ON a.PointId = p.PointId INNER JOIN
                          (SELECT     a.PointId, b.PeriodNumber, ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) AS InSumBalance, ISNULL(SUM(ISNULL(b.PowerBalance, $0)), 
                                                   $0) AS InPowerBalance
                            FROM          dbo.Points AS p INNER JOIN
                                                   dbo.Accounts AS a ON a.PointId = p.PointId LEFT OUTER JOIN
                                                   dbo.BalanceOfClosedMonths AS b ON b.AccountId = a.AccountId AND b.PeriodNumber = @PeriodNumberPast
                            GROUP BY p.PointNumber, b.PeriodNumber, p.EnergyTypeId, a.PointId
                            HAVING      (p.EnergyTypeId = 1)) AS BalanceOfClosedMonths ON p.PointId = BalanceOfClosedMonths.PointId ON 
                      dbo.vAbonents.AbonentId = p.AbonentId LEFT OUTER JOIN
                      dbo.BalanceOfClosedMonths AS b ON a.AccountId = b.AccountId AND b.PeriodNumber = @PeriodNumber LEFT OUTER JOIN
                      dbo.ExtBalanceOfClosedMonths AS eb ON eb.AccountId = a.AccountId AND eb.PeriodNumber = @PeriodNumber
GROUP BY ISNULL(b.PeriodNumber, @PeriodNumber), p.EnergyTypeId, BalanceOfClosedMonths.InSumBalance, BalanceOfClosedMonths.InPowerBalance, 
                      p.PointNumber, dbo.vPerformersName.Name, dbo.vAbonents.CommAddressString, dbo.vAbonents.LastSurName
HAVING      (p.EnergyTypeId = @EnergyType)
END 

IF @Function = 2 BEGIN 
SELECT     TOP (100) PERCENT ISNULL(dbo.Elements.Name, 'Некорректные платежи') AS ControlerName, SUM(Protocol.InSumBalance) AS InSumBalance, 
                      SUM(Protocol.InPowerBalance) AS InPowerBalance, SUM(Protocol.SumCharges) AS SumCharges, SUM(Protocol.SumPayments) AS SumPayments, 
                      SUM(Protocol.CorrectSumCharges) AS CorrectSumCharges, SUM(Protocol.PowerCharges) AS PowerCharges, SUM(Protocol.PowerActual) 
                      AS PowerActual, SUM(Protocol.CorrectPowerCharges) AS CorrectPowerCharges, SUM(Protocol.SumBalance) AS SumBalance, 
                      SUM(Protocol.PowerBalance) AS PowerBalance, AbonentsCount.AbonentsCount, COUNT(Protocol.PointId) AS PointsCount, 
                      SUM(SumBalance_Debet.SumBalance) AS SumBalance_Debet, COUNT(SumBalance_Debet.PointId) AS SumBalance_DebetCount, 
                      SUM(SumBalance_Credet.SumBalance) AS SumBalance_Credet, COUNT(SumBalance_Credet.PointId) AS SumBalance_CredetCount, 
                      SUM(InSumBalance_Debet.InSumBalance) AS InSumBalance_Debet, COUNT(InSumBalance_Debet.PointId) AS InSumBalance_DebetCount, 
                      SUM(InSumBalance_Credet.InSumBalance) AS InSumBalance_Credet, COUNT(InSumBalance_Credet.PointId) AS InSumBalance_CredetCount
FROM         (SELECT     p.PointId, BalanceOfClosedMonths_1.InSumBalance
                       FROM          dbo.Points AS p INNER JOIN
                                              dbo.Accounts AS a ON a.PointId = p.PointId INNER JOIN
                                                  (SELECT     a.PointId, b.PeriodNumber, ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) AS InSumBalance, 
                                                                           ISNULL(SUM(ISNULL(b.PowerBalance, $0)), $0) AS InPowerBalance
                                                    FROM          dbo.Points AS p INNER JOIN
                                                                           dbo.Accounts AS a ON a.PointId = p.PointId LEFT OUTER JOIN
                                                                           dbo.BalanceOfClosedMonths AS b ON b.AccountId = a.AccountId AND b.PeriodNumber = @PeriodNumberPast
                                                    GROUP BY p.PointNumber, b.PeriodNumber, p.EnergyTypeId, a.PointId
                                                    HAVING      (p.EnergyTypeId = 1)) AS BalanceOfClosedMonths_1 ON p.PointId = BalanceOfClosedMonths_1.PointId
                       GROUP BY p.EnergyTypeId, BalanceOfClosedMonths_1.InSumBalance, p.PointId
                       HAVING      (p.EnergyTypeId = @EnergyType) AND (BalanceOfClosedMonths_1.InSumBalance < 0)) AS InSumBalance_Debet RIGHT OUTER JOIN
                          (SELECT     p.PointId, BalanceOfClosedMonths_2.InSumBalance
                            FROM          dbo.Points AS p INNER JOIN
                                                   dbo.Accounts AS a ON a.PointId = p.PointId INNER JOIN
                                                       (SELECT     a.PointId, b.PeriodNumber, ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) AS InSumBalance, 
                                                                                ISNULL(SUM(ISNULL(b.PowerBalance, $0)), $0) AS InPowerBalance
                                                         FROM          dbo.Points AS p INNER JOIN
                                                                                dbo.Accounts AS a ON a.PointId = p.PointId LEFT OUTER JOIN
                                                                                dbo.BalanceOfClosedMonths AS b ON b.AccountId = a.AccountId AND b.PeriodNumber = @PeriodNumberPast
                                                         GROUP BY p.PointNumber, b.PeriodNumber, p.EnergyTypeId, a.PointId
                                                         HAVING      (p.EnergyTypeId = 1)) AS BalanceOfClosedMonths_2 ON p.PointId = BalanceOfClosedMonths_2.PointId
                            GROUP BY p.EnergyTypeId, BalanceOfClosedMonths_2.InSumBalance, p.PointId
                            HAVING      (p.EnergyTypeId = @EnergyType) AND (BalanceOfClosedMonths_2.InSumBalance > 0)) AS InSumBalance_Credet RIGHT OUTER JOIN
                      dbo.Points ON InSumBalance_Credet.PointId = dbo.Points.PointId ON InSumBalance_Debet.PointId = dbo.Points.PointId LEFT OUTER JOIN
                          (SELECT     p.PointId, ISNULL(b.PeriodNumber, @PeriodNumber) AS PeriodNumber, ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) 
                                                   AS SumBalance
                            FROM          dbo.Points AS p INNER JOIN
                                                   dbo.Accounts AS a ON a.PointId = p.PointId LEFT OUTER JOIN
                                                   dbo.BalanceOfClosedMonths AS b ON a.AccountId = b.AccountId AND b.PeriodNumber = @PeriodNumber
                            GROUP BY ISNULL(b.PeriodNumber, @PeriodNumber), p.EnergyTypeId, p.PointId
                            HAVING      (p.EnergyTypeId = @EnergyType) AND (ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) > 0)) AS SumBalance_Credet ON 
                      dbo.Points.PointId = SumBalance_Credet.PointId LEFT OUTER JOIN
                          (SELECT     p.PointId, ISNULL(b.PeriodNumber, @PeriodNumber) AS PeriodNumber, ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) 
                                                   AS SumBalance
                            FROM          dbo.Points AS p INNER JOIN
                                                   dbo.Accounts AS a ON a.PointId = p.PointId LEFT OUTER JOIN
                                                   dbo.BalanceOfClosedMonths AS b ON a.AccountId = b.AccountId AND b.PeriodNumber = @PeriodNumber
                            GROUP BY ISNULL(b.PeriodNumber, @PeriodNumber), p.EnergyTypeId, p.PointId
                            HAVING      (p.EnergyTypeId = @EnergyType) AND (ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) < 0)) AS SumBalance_Debet ON 
                      dbo.Points.PointId = SumBalance_Debet.PointId LEFT OUTER JOIN
                          (SELECT     ISNULL(b.PeriodNumber, @PeriodNumber) AS PeriodNumber, ISNULL(dbo.vPerformersName.PerformerId, NULL) AS PerformerId, 
                                                   BalanceOfClosedMonths.InSumBalance, BalanceOfClosedMonths.InPowerBalance, ISNULL(SUM(ISNULL(b.SumCharges, $0)), $0) 
                                                   AS SumCharges, ISNULL(SUM(ISNULL(b.SumPayments, $0)), $0) AS SumPayments, ISNULL(SUM(ISNULL(b.CorrectSumCharges, $0)), $0) 
                                                   + ISNULL(SUM(ISNULL(eb.PowerAmount, $0)), $0) AS CorrectSumCharges, ISNULL(SUM(ISNULL(b.PowerCharges, $0)), $0) 
                                                   AS PowerCharges, ISNULL(SUM(ISNULL(b.PowerActual, $0)), $0) AS PowerActual, ISNULL(SUM(ISNULL(b.CorrectPowerCharges, $0)), $0) 
                                                   + ISNULL(SUM(ISNULL(eb.MoneyAmount, $0)), $0) AS CorrectPowerCharges, ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) 
                                                   AS SumBalance, ISNULL(SUM(ISNULL(b.PowerBalance, $0)), $0) AS PowerBalance, p.PointId
                            FROM          dbo.vPerformersName INNER JOIN
                                                   dbo.vAbonents ON dbo.vPerformersName.PerformerId = dbo.vAbonents.ControllerId RIGHT OUTER JOIN
                                                   dbo.Points AS p INNER JOIN
                                                   dbo.Accounts AS a ON a.PointId = p.PointId INNER JOIN
                                                       (SELECT     a.PointId, b.PeriodNumber, ISNULL(SUM(ISNULL(b.SumBalance, $0)), $0) AS InSumBalance, 
                                                                                ISNULL(SUM(ISNULL(b.PowerBalance, $0)), $0) AS InPowerBalance
                                                         FROM          dbo.Points AS p INNER JOIN
                                                                                dbo.Accounts AS a ON a.PointId = p.PointId LEFT OUTER JOIN
                                                                                dbo.BalanceOfClosedMonths AS b ON b.AccountId = a.AccountId AND b.PeriodNumber = @PeriodNumberPast
                                                         GROUP BY p.PointNumber, b.PeriodNumber, p.EnergyTypeId, a.PointId
                                                         HAVING      (p.EnergyTypeId = 1)) AS BalanceOfClosedMonths ON p.PointId = BalanceOfClosedMonths.PointId ON 
                                                   dbo.vAbonents.AbonentId = p.AbonentId LEFT OUTER JOIN
                                                   dbo.BalanceOfClosedMonths AS b ON a.AccountId = b.AccountId AND b.PeriodNumber = @PeriodNumber LEFT OUTER JOIN
                                                   dbo.ExtBalanceOfClosedMonths AS eb ON eb.AccountId = a.AccountId AND eb.PeriodNumber = @PeriodNumber
                            GROUP BY ISNULL(b.PeriodNumber, @PeriodNumber), p.EnergyTypeId, BalanceOfClosedMonths.InSumBalance, 
                                                   BalanceOfClosedMonths.InPowerBalance, ISNULL(dbo.vPerformersName.PerformerId, NULL), p.PointId
                            HAVING      (p.EnergyTypeId = @EnergyType)) AS Protocol ON dbo.Points.PointId = Protocol.PointId LEFT OUTER JOIN
                          (SELECT     Elements_1.ElementId AS PerformerId, COUNT(Abonents_1.AbonentId) AS AbonentsCount
                            FROM          dbo.Abonents AS Abonents_1 INNER JOIN
                                                   dbo.Elements AS Elements_1 ON Abonents_1.ControllerId = Elements_1.ElementId
                            GROUP BY Elements_1.ElementId) AS AbonentsCount INNER JOIN
                      dbo.Abonents INNER JOIN
                      dbo.Elements ON dbo.Abonents.ControllerId = dbo.Elements.ElementId ON AbonentsCount.PerformerId = dbo.Elements.ElementId ON 
                      dbo.Points.AbonentId = dbo.Abonents.AbonentId
GROUP BY ISNULL(dbo.Elements.Name, 'Некорректные платежи'), AbonentsCount.AbonentsCount
ORDER BY ControlerName
END
GO
GRANT EXECUTE ON dbo.lobin_ProtocolOfCloseMonth TO KvzWorker
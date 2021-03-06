IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PayOrders' AND type = 'V')
    DROP VIEW vPr_PayOrders
GO

CREATE VIEW dbo.vPr_PayOrders
AS
SELECT TOP (100) PERCENT
	dbo.Pr_PayOrders.PayOrderId
   ,dbo.Pr_PayOrders.MemberId
   ,dbo.Pr_PayOrders.AbonentId
   ,dbo.Pr_PayOrders.DtPeriodStart
   ,dbo.Pr_PayOrders.DtPeriodEnd
   ,dbo.Pr_PayOrders.EnergyTypeId
   ,dbo.Pr_PayOrders.DtPayOrder
   ,dbo.Pr_PayOrders.SumPayOrder
   ,dbo.Pr_PayOrders.NumberPayOrder
   ,dbo.Pr_PayOrders.PayOrderStatusId
   ,dbo.Pr_PayOrderStatus.Name AS PayOrderStatus
   ,dbo.Pr_PayOrders.DtCreate
   ,dbo.Pr_PayOrders.CratePerformerId
   ,dbo.Pr_PayOrders.DtUpdate
   ,dbo.Pr_PayOrders.UpdatePerformerId
   ,dbo.Elements.Num
FROM dbo.Pr_PayOrders
INNER JOIN dbo.Elements
	ON dbo.Pr_PayOrders.AbonentId = dbo.Elements.ElementId
LEFT OUTER JOIN dbo.Pr_PayOrderStatus
	ON dbo.Pr_PayOrders.PayOrderStatusId = dbo.Pr_PayOrderStatus.PayOrderStatusId
ORDER BY dbo.Pr_PayOrders.DtPayOrder, dbo.Pr_PayOrders.MemberId
GO

GRANT SELECT ON vPr_PayOrders TO KvzWorker
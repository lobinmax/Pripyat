IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_ActRevise_OPS' AND type = 'P')
    DROP PROCEDURE dbo.Pr_ActRevise_OPS
GO

create PROCEDURE [dbo].[Pr_ActRevise_OPS]
	-- Выгрузка реестра для акта сверки с почтой
    @Period int  
AS 

SET NOCOUNT ON
	SELECT     TOP (100) PERCENT dbo.vAbonents.PostIndex, dbo.PrintAbonentsPeriod.period, dbo.PrintAbonentsPeriod.abonnumber, dbo.vAbonents.AddressString, 
                      dbo.vAbonents.House, dbo.vAbonents.LetterHouse, dbo.vAbonents.CityVillage, dbo.vAbonents.Areal, dbo.vAbonents.Street
FROM         dbo.vAbonents INNER JOIN
                      dbo.PrintAbonentsPeriod ON dbo.vAbonents.AbonentId = dbo.PrintAbonentsPeriod.abonentid
WHERE     (dbo.PrintAbonentsPeriod.period = @Period)
ORDER BY dbo.vAbonents.PostIndex, dbo.vAbonents.Street, dbo.vAbonents.Areal, dbo.vAbonents.CityVillage
GO

GRANT EXECUTE ON dbo.Pr_ActRevise_OPS TO KvzWorker

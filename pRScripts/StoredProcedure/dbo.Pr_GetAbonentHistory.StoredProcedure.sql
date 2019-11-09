IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetAbonentHistory' AND type = 'P')
    DROP PROCEDURE dbo.Pr_GetAbonentHistory
GO

CREATE PROCEDURE [dbo].[Pr_GetAbonentHistory] 
-- Функция возвращает историю абонента по Id (@AbonentId int)
    @AbonentId int  
AS 

SET NOCOUNT ON
	SELECT      AbonentsHistory.AbonentId AS Id, AbonentsHistory.DtChange AS Дата, 
	                      FamilyMembers.SurName + ' ' + FamilyMembers.Name + ' ' + FamilyMembers.Patronymic AS Собственник, AbonentStatus.Name AS Состояние, 
	                      HouseStatus.Name AS [Статус жилья], Cookers.Name AS [Тип плиты], ExtAbonentStatus.Name AS Причина, 
	                      AbonentsHistory.DtUpdate AS [Дата изменения], vPerformersName.Name AS [Автор измененй]
	FROM         AbonentsHistory INNER JOIN
	                      AbonentStatus ON AbonentsHistory.AbonentStatusId = AbonentStatus.AbonentStatusId INNER JOIN
	                      ExtAbonentStatus ON AbonentsHistory.ExtAbonentStatusId = ExtAbonentStatus.ExtAbonentStatusId INNER JOIN
	                      Cookers ON AbonentsHistory.CookerId = Cookers.CookerId INNER JOIN
	                      HouseStatus ON AbonentsHistory.HouseStatusId = HouseStatus.HouseStatusId INNER JOIN
	                      FamilyMembers ON AbonentsHistory.FamilyMemberId = FamilyMembers.FamilyMemberId LEFT OUTER JOIN
	                      vPerformersName ON AbonentsHistory.PerformerId = vPerformersName.PerformerId
	WHERE     (AbonentsHistory.AbonentId = @AbonentId)
	ORDER BY Дата
GO

GRANT EXECUTE ON dbo.Pr_GetAbonentHistory TO KvzWorker

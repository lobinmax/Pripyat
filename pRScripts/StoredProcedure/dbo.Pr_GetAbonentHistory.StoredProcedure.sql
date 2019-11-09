IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_GetAbonentHistory' AND type = 'P')
    DROP PROCEDURE dbo.Pr_GetAbonentHistory
GO

CREATE PROCEDURE [dbo].[Pr_GetAbonentHistory] 
-- ������� ���������� ������� �������� �� Id (@AbonentId int)
    @AbonentId int  
AS 

SET NOCOUNT ON
	SELECT      AbonentsHistory.AbonentId AS Id, AbonentsHistory.DtChange AS ����, 
	                      FamilyMembers.SurName + ' ' + FamilyMembers.Name + ' ' + FamilyMembers.Patronymic AS �����������, AbonentStatus.Name AS ���������, 
	                      HouseStatus.Name AS [������ �����], Cookers.Name AS [��� �����], ExtAbonentStatus.Name AS �������, 
	                      AbonentsHistory.DtUpdate AS [���� ���������], vPerformersName.Name AS [����� ��������]
	FROM         AbonentsHistory INNER JOIN
	                      AbonentStatus ON AbonentsHistory.AbonentStatusId = AbonentStatus.AbonentStatusId INNER JOIN
	                      ExtAbonentStatus ON AbonentsHistory.ExtAbonentStatusId = ExtAbonentStatus.ExtAbonentStatusId INNER JOIN
	                      Cookers ON AbonentsHistory.CookerId = Cookers.CookerId INNER JOIN
	                      HouseStatus ON AbonentsHistory.HouseStatusId = HouseStatus.HouseStatusId INNER JOIN
	                      FamilyMembers ON AbonentsHistory.FamilyMemberId = FamilyMembers.FamilyMemberId LEFT OUTER JOIN
	                      vPerformersName ON AbonentsHistory.PerformerId = vPerformersName.PerformerId
	WHERE     (AbonentsHistory.AbonentId = @AbonentId)
	ORDER BY ����
GO

GRANT EXECUTE ON dbo.Pr_GetAbonentHistory TO KvzWorker

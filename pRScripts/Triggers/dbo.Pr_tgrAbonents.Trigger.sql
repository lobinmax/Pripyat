IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_tgrAbonents' AND type = 'TR')
    DROP TRIGGER Pr_tgrAbonents
GO
CREATE TRIGGER Pr_tgrAbonents
	ON Abonents
	FOR INSERT, DELETE
AS BEGIN
	-- после добавления
	INSERT INTO Pr_Abonents
	SELECT i.AbonentId FROM INSERTED i
	-- после удаления
	DELETE Pr_Abonents WHERE AbonentId = (SELECT d.AbonentId FROM DELETED d)
END 
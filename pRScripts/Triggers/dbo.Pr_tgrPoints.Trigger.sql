IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_tgrPoints' AND type = 'TR')
    DROP TRIGGER Pr_tgrPoints
GO
CREATE TRIGGER Pr_tgrPoints
	ON Points
	FOR INSERT, DELETE
AS BEGIN
	-- после добавления
	INSERT INTO Pr_Points
	SELECT i.PointId FROM INSERTED i
	-- после удаления
	DELETE Pr_Points WHERE PointId = (SELECT d.PointId FROM DELETED d)
END 
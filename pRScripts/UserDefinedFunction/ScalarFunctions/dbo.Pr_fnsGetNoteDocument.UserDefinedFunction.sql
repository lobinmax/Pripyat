IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetNoteDocument' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetNoteDocument
GO
CREATE FUNCTION dbo.Pr_fnsGetNoteDocument
/*
	=========================================
	|	Возвращает пометки документа по ИД	|
	=========================================
*/
(
	-- парметры
	@DocumentId INT -- Ид документа
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Note VARCHAR(MAX)
	SELECT @Note = mo.Notes FROM MemoOrders AS mo WHERE mo.DocumentId = @DocumentId
	RETURN @Note
END
GO
GRANT EXECUTE ON Pr_fnsGetNoteDocument TO KvzWorker	-- для скалярных
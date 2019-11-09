IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetJournalAttributes' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetJournalAttributes
GO
CREATE FUNCTION dbo.Pr_fnsGetJournalAttributes
/*
	=========================================
	|	Получение атрибутов по коду журнала	|
	=========================================
*/
(
	@CodJournalId 	VARCHAR(10), 	-- 4-03. Журнал выдачи заданий линейному контролеру
	                           		-- 4-05. Журнал регистрации уведомлений и извещений о задолженности
							   		-- 4-09. Журнал регистрации актов об ограничении (отключении), проверки ограничений (отключений) электроэнергии
	@JournalNumber 	INT,	       	-- Номер журнала
	@Parameter 		INT             -- 1 - Получить кол-во документов
	                           		-- 2 - Получить сумму документов
)
RETURNS NUMERIC(12, 2)
AS
BEGIN
DECLARE @Value NUMERIC(12, 2) = 0
DECLARE @ValueCount NUMERIC(12, 2) = NULL 
DECLARE @ValueMoney NUMERIC(12, 2) = NULL 

-- 4-03. Журнал выдачи заданий линейному контролеру
IF @CodJournalId = '4-03' BEGIN 
	SELECT @ValueCount = COUNT(pjts.TaskSheetId) FROM Pr_JournalTaskSheets AS pjts 
	WHERE pjts.CodJournalId = @CodJournalId AND pjts.JournalNumber = @JournalNumber
END 

-- 4-05. Журнал регистрации уведомлений и извещений о задолженности
-- 4-09. Журнал регистрации актов об ограничении (отключении), проверки ограничений (отключений) электроэнергии
IF @CodJournalId IN ('4-05', '4-09') BEGIN 
	SELECT @ValueCount = COUNT(pjd.DocId), @ValueMoney = SUM(pjd.SumDoc) FROM Pr_JournalDocs4_05 AS pjd
	WHERE pjd.CodJournalId = @CodJournalId AND pjd.JournalNumber = @JournalNumber 
END 

IF @Parameter = 1 BEGIN SET @Value = @ValueCount END
IF @Parameter = 2 BEGIN SET @Value = @ValueMoney END

RETURN @Value
END
GO
GRANT EXECUTE ON Pr_fnsGetJournalAttributes TO KvzWorker
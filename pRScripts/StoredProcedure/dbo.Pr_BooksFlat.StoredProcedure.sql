IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_BooksFlat' AND type = 'P')
    DROP PROCEDURE dbo.Pr_BooksFlat
GO
CREATE PROCEDURE dbo.Pr_BooksFlat
/*
	+===================================+
	|	Обработка плоских справочников	|
	+===================================+
*/
	@Id 		INT = NULL,				-- Ид записи 
	@Name 		VARCHAR(250) = NULL,	-- Значение для вставки в плоский справочник
	@Function	INT = 1,				-- 1 - SELECT
										-- 2 - INSERT
										-- 3 - UPDATE
										-- 4 - DELETE
	@SelectNumber	INT = 0
AS
SET NOCOUNT ON			-- Отключить счетчик обработанных строк
SET XACT_ABORT ON		-- Всегда откатывать по ошибке

DECLARE @Message VARCHAR(300)
IF @Function = 1 BEGIN
	-- Акты ССП
	IF @SelectNumber = 0 BEGIN
		SELECT pair.ActImpossibleRecoveryId AS Id, pair.Name FROM Pr_ActImpossibleRecovery pair
	END
	-- виды судов
	IF @SelectNumber = 1 BEGIN
		SELECT pct.CourtTypeId AS Id, pct.Name FROM Pr_CourtType pct
	END
	-- зоны обслуживания судьи
	IF @SelectNumber = 2 BEGIN
		SELECT pzos.ZoneOfServiceId AS Id, pzos.Name FROM Pr_ZoneOfService pzos
	END
	-- виды заявлений в суд
	IF @SelectNumber = 3 BEGIN
		SELECT ppt.PetitionTypeId AS Id, ppt.Name, ppt.NameShort FROM Pr_PetitionType ppt
	END
	-- виды решений
	IF @SelectNumber = 4 BEGIN
		SELECT pdt.DecisionTypeId AS Id, pdt.Name FROM Pr_DecisionType pdt
		WHERE pdt.Name != '' AND pdt.DecisionTypeId != 5
		ORDER BY pdt.Name
	END
	-- причины решений
    IF @SelectNumber = 5 BEGIN
		SELECT pdte.DecisionTypeId AS Id, pdte.DecisionTypeExtId AS ExtId, pdte.Name FROM Pr_DecisionTypeExt pdte
		ORDER BY pdte.Name
	END
	-- место взыскания
	IF @SelectNumber = 6 BEGIN
		SELECT pdd.DecisionDirectionId AS Id, pdd.Name FROM Pr_DecisionDirections pdd
		WHERE pdd.Name != '' 
		ORDER BY pdd.Name DESC
	END
	-- статьи взыскания
	IF @SelectNumber = 7 BEGIN
		SELECT pet.EnergyTypeId AS Id, pet.Name, pet.NameShort FROM Pr_EnergyTypes pet
		ORDER BY pet.EnergyTypeId
	END
	-- итоги слушания
	IF @SelectNumber = 8 BEGIN
		SELECT plt.ListeningTypeId AS Id, plt.Name FROM Pr_ListeningType plt
	END
	-- причины окончания
	IF @SelectNumber = 9 BEGIN
		SELECT prfe.ReasonForEndId AS Id, prfe.Name FROM Pr_ReasonForEnd prfe
		WHERE prfe.Name != ''
		ORDER BY prfe.ReasonForEndId
	END
	-- статус платежного поручения
	IF @SelectNumber = 10 BEGIN
		SELECT ppos.PayOrderStatusId AS Id, ppos.Name FROM Pr_PayOrderStatus ppos
	END
	-- виды журналов
	IF @SelectNumber = 11 BEGIN
		SELECT DISTINCT 	d.CodJournalId, d.Name, d.SaveTimeYear, d.ArticleNumber
		FROM            	Pr_JournalDocumentsType AS jdt 
		INNER JOIN			Pr_JournaTypeDocs AS j ON jdt.DocumentTypeId = j.DocumentTypeId 
		RIGHT OUTER JOIN 	Pr_JournaType AS d ON j.ParentCodJournalId = d.CodJournalId
	END
	-- типы документов
	IF @SelectNumber = 12 BEGIN
		SELECT				ISNULL(j.CodJournalId, 'N/D') AS CodJournalId, 
							d.CodJournalId AS CodParentJournalId, 
							ISNULL(jdt.Name, 'Тип документа не назначен') AS Name, 
							j.SaveTimeYear, 
							j.ArticleNumber
		FROM				dbo.Pr_JournalDocumentsType AS jdt 
		INNER JOIN 			dbo.Pr_JournaTypeDocs AS j ON jdt.DocumentTypeId = j.DocumentTypeId 
		RIGHT OUTER JOIN 	dbo.Pr_JournaType AS d ON j.ParentCodJournalId = d.CodJournalId
	END
	-- статус журнала
	IF @SelectNumber = 13 BEGIN
		SELECT pjs.StatusId AS Id, pjs.Name FROM Pr_JournalStatus pjs
	END
	-- части города
	IF @SelectNumber = 14 BEGIN
		SELECT pcp.Id, pcp.Name FROM Pr_CityParts pcp
	END
END

-- добавление
IF @Function = 2 BEGIN 
	-- части города
	IF @SelectNumber = 14 BEGIN
		-- Проверка есть ли похожая запись
		IF EXISTS (SELECT * FROM Pr_CityParts pcp WHERE pcp.Name = @Name) BEGIN
			SET @Message = 	'Часть города с именем <u><b>' + 
							(SELECT pcp.Name FROM Pr_CityParts pcp WHERE pcp.Name = @Name) + 
							'</u></b> уже существует!' + CHAR(10) +
							'Запись невозможна!'
			RAISERROR(@Message, 12, 1)
			RETURN
		END
		INSERT INTO  Pr_CityParts
		SELECT @Name, dbo.Kernel_GetPerformer(), GETDATE(), dbo.Kernel_GetPerformer(), GETDATE()
	END
END 

-- изменение
IF @Function = 3 BEGIN 
	-- части города
	IF @SelectNumber = 14 BEGIN
		UPDATE  Pr_CityParts
		SET 	Name = @Name, UpdaterId = dbo.Kernel_GetPerformer(), UpdateDt = GETDATE() 
		WHERE 	Id = @Id
	END
END 

-- удаление
IF @Function = 4 BEGIN 
	-- части города
	IF @SelectNumber = 14 BEGIN
		-- проверка привязки к абонентам

		DELETE FROM Pr_CityParts
		WHERE 	Id = @Id
	END
END 
GO
GRANT EXECUTE ON dbo.Pr_BooksFlat TO KvzWorker
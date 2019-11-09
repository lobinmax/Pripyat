IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OiOUpdateEvents' AND type = 'P')
    DROP PROCEDURE dbo.Pr_OiOUpdateEvents
GO
CREATE PROCEDURE dbo.Pr_OiOUpdateEvents
	/*
	=================================	
	|	Процедура для обработки		|
	|	записи событий в ДЗ 		|
	=================================
	*/
	@AbonentId	INT		= 0,		-- Ид абонента
	@DocNumber 	INT		= 0,		-- Номер документа
	@DocYear	INT 	= 0,		-- Год регистрации документа
	@DocGroup  	INT		= 0,		-- Группа мероприятий (0 - уведомления; 1 - отключения)
	@Function	INT		= NULL		-- 1 - Получаем список годов из записей в жернале
									-- 2 - Получаем информацию о документе по его номеру
									-- 3 - Получаем список методом доставки
									-- 4 - Получаем информации по истрии ДЗ
									-- 5 - Получаем информации записям истории ДЗ
AS 
	SET NOCOUNT ON			-- Отключить счетчик обработанных строк
	SET XACT_ABORT ON		-- Всегда откатывать по ошибке

-- 1 - Получаем список годов из записей в журнале
IF @Function = 1 BEGIN
	SELECT DISTINCT CAST(YEAR(DtDocument) AS VARCHAR) + ' год.' AS YearName,
					YEAR(DtDocument) AS Years
	FROM            Pr_JournalDocs4_05 AS j
	ORDER BY Years DESC
END

-- 2 - Получаем информацию о документе по его номеру и году регистрации
IF @Function = 2 BEGIN
DECLARE @Events AS TABLE(EventTypeId INT)
	IF @DocGroup = 0 BEGIN	-- уведомления
		INSERT INTO @Events
		SELECT oet.EventTypeId FROM OioEventsTypes oet WHERE oet.EventTypeId in(1,2,5)
	END
	IF @DocGroup = 1 BEGIN 	-- отключения
		INSERT INTO @Events
		SELECT oet.EventTypeId FROM OioEventsTypes oet WHERE oet.EventTypeId in(3,6,8)
	END
	-- выбираем информацию по мероприятию
	SELECT DISTINCT	j.DocId,
   					j.AbonentId,
  	 				j.AbonentNumber,
   					j.SNP_short,
   					j.AddressString,
   					et.prEventName,
					j.DocumentTypeId AS EventTypeId,
					j.DocNumber AS DocNum,
   					j.SumDoc,
   					'№  ' + dbo.Pr_fnsGetConstants(5, 0) + '-' + 
							j.CodJournalDocsId + '-' + 
							CAST(j.DocNumber AS VARCHAR) + ' от ' + 
							CONVERT(VARCHAR, j.DtDocument, 104) + 'г.' AS DocNumber,
   					dbo.Pr_fnsGetShortFNS('', j.ControllerId, 1) AS Controller,
   					vPr_OioPrintSessions.PerformersName,
   					vPr_OioPrintSessions.TaskSheet,
					j.DtBeginOio
	FROM 			dbo.Pr_JournalDocs4_05 j
	INNER JOIN 		dbo.Pr_OioEventsTypes et ON j.DocumentTypeId = et.KVZ_EventTypeId
	LEFT OUTER JOIN dbo.vPr_OioPrintSessions ON vPr_OioPrintSessions.SessionId = j.SessionId
	WHERE 			j.DocNumber = @DocNumber AND j.DocumentTypeId IN (SELECT * FROM @Events) 
					AND YEAR(j.DtDocument) = @DocYear
END 

-- 3 - Получаем список методов доставки
IF @Function = 3 BEGIN
	SELECT 		m.DMethodId,
   				m.DMethodName
	FROM 		dbo.OiODeliveryMethods m
	WHERE 		m.DMethodId BETWEEN 2 AND 5
	ORDER BY 	m.Sort
END

-- 4 - Получаем информации по истрии ДЗ
IF @Function = 4 BEGIN
	SELECT		a.AbonentId, 
				a.DtBeginOio, 
				a.DtEndOio, 
				'Норматив ' + CAST(b.NormConsumption * -1 AS VARCHAR) + ' кВт.час, ' + 
                'Количество ' + CAST(b.NormCount AS VARCHAR) + ', ' + 
				'Сумма ' + CAST((b.NormSum * b.NormCount) * -1 AS VARCHAR) + ' руб., ' + 
				'Сальдо ' + CAST(b.Balance as VARCHAR) + ' руб.' AS ResultOfWork, 
				dbo.Pr_fnsGetShortFNS('', a.PerformerId, 1) AS PerformerName
	FROM 		dbo.OioAbonents a
	INNER JOIN 	dbo.OioBalances b ON a.AbonentId = b.AbonentId
								AND a.DtBeginOio = b.DateBalance
	WHERE 		a.AbonentId = @AbonentId
	ORDER BY  	a.DtEndOio
END

-- 5 - Получаем информации по записям истории ДЗ
IF @Function = 5 BEGIN
	SELECT 			ev.AbonentId,
   					ev.DtBeginOio,
   					et.EventName,
   					ev.DtPlane,
   					ev.DtFact,
   					ev.DocSum,
   					ev.DocumentNumber,
   					dbo.Pr_fnsGetShortFNS('', ev.InspectorId, 1) AS PerformerName,
   					dm.DMethodName
	FROM 			dbo.OioEvents ev
	LEFT OUTER JOIN dbo.OioEventsTypes et ON ev.EventTypeId = et.EventTypeId
	LEFT OUTER JOIN dbo.OiODeliveryMethods dm ON ev.DMethodId = dm.DMethodId
	WHERE 			ev.AbonentId = @AbonentId AND ev.EventTypeId <= 11
	ORDER BY 		ev.EventTypeId
END
GO
GRANT EXECUTE ON dbo.Pr_OiOUpdateEvents TO KvzWorker
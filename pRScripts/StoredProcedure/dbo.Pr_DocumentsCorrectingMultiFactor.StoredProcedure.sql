IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_DocumentsCorrectingMultiFactor' AND type = 'P')
    DROP PROCEDURE Pr_DocumentsCorrectingMultiFactor
GO
--
CREATE PROCEDURE dbo.Pr_DocumentsCorrectingMultiFactor
/*	Перерасчет всех БПУ документов по абоненту за период
															*/
	@AbonentNum			VARCHAR(12) = '',			-- Номер абонента
	@PeriodStart		INT			= NULL,			-- Период начала коррекции
	@DocumentNumber		VARCHAR(20)	= '',			-- Входящий номер документа - основания
	@DtControl			DATETIME	= '20150713'	-- Дата регистрации перерасчёта
AS
	/* SET NOCOUNT ON */
/*
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131400496500', @PeriodStart = 201607, @DtControl = '20170320'
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131400490470', @PeriodStart = 201607, @DtControl = '20170320'
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131400409900', @PeriodStart = 201607, @DtControl = '20170320'
exec dbo.Pr_DocumentsCorrectingMultiFactor @AbonentNum = '131700702680', @PeriodStart = 201607, @DtControl = '20170320'
*/

DECLARE @iDocs	INT
DECLARE	iCursor	CURSOR LOCAL FORWARD_ONLY STATIC FOR

SELECT		DocumentId FROM Documents 
WHERE		num = @AbonentNum AND 
			PeriodNumber >= @PeriodStart AND 
			DocumentTypeId = 2 -- БПУ документы

OPEN  iCursor
-- открываем строку курсора
FETCH NEXT FROM iCursor INTO @iDocs
-- пока есть след строка
WHILE @@FETCH_STATUS = 0   
BEGIN 
			EXEC Documents_CorrectingDocuments 
						@DocumentId				= @iDocs,						--- Пересчитываемый документ
						@EnergyTypeId			= 1,
						@PlanId					= 3,            				--- План счетов
						@ReasonCorrectId		= 42,           				--- Причина перерасчёта (1 ... 19)
						@InitRecalcTypeId		= 1,            				--- Инициатор перерасчёта (1 ... 6)
																			/*
																				1. Акт ГП
																				2. Акт СО
																				3. Справка УК
																				4. Выписка о численности зарегистрированных
																				5. Решение суда
																				6. Служебная записка
																			*/
/*VARCHAR(20)*/			@DocumentNumber			= @DocumentNumber,	            --- Входящий номер документа перерасчёта
						@DtControl				= @DtControl,					--- Дата регистрации перерасчёта
						@PeriodNumberBegin		= NULL,							--- Начало периода перерасчёта
						@PeriodNumberEnd		= NULL,							--- Конец периода перерасчёта
						@NewIndication			= 0,            				--- Новое показание для перерасчёта
						@Consumption			= 0,							--- Расчётное потребление
						@SumCharges				= 0,							--- Начислено по перерасчёту
/*VARCHAR(256)*/		@Notes					= '',							--- Пометки
						@RecalcObjectId			= 1,							--- 1 - Выбранный документ
																				--- 2 - За период
																				--- 3 - Ввод значений
						@Transaction			= 1,
						@Function				= 1,
						@MessageDiag			= 1

FETCH NEXT FROM iCursor INTO @iDocs
END  
CLOSE iCursor
DEALLOCATE iCursor
 /*
                                      1	  45	Неверные показания абонента
                                      2	  21	Неверные показания Сетевого предприятия
                                      3	  22	Неверные показания контролера Энергосбыта
                                      4	  50	Изменение значности прибора учета
                                      5	  26	Перевод в нежилое помещение
                                      6	  51	Изменения количества комнат
                                      7	  8	  Изменение коэффициентов трансформации/напряжения
                                      8	  16	Изменение типа плиты
                                      9	  2	  Изменение численности проживающих
                                      10	42	Изменение параметров услуг для ЖКХ
                                      11	36	Сторнирование неверных начислений
                                      12	24	Нагрузка переведена на один прибор учета
                                      13	41	Перевод в Управляющую компанию
                                      14	47	Перерасчёт за некачественное энергоснабжение
                                      15	28	Перерасчет по решению суда
                                      16	32	Сторнирование начислений по ГП
                                      17	48	Коррекция выпадающих доходов для ЖКХ
                                      18	43	Закрытие договора с ООО "КРЭК" для ЖКХ
                                      19	52	Сторнирование начислений по доп. счетам
                                    */
RETURN
--
GO
GRANT EXECUTE ON Pr_DocumentsCorrectingMultiFactor TO KvzWorker
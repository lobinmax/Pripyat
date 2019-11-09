IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_OiOValidateDtFact' AND type = 'P')
    DROP PROCEDURE Pr_OiOValidateDtFact
GO
CREATE PROCEDURE dbo.Pr_OiOValidateDtFact
	/*
	=========================================================	
	|	Видоизмененная процедура ПК Квазар					|
	|	для проверки корректности фактического события в ДЗ	|	
	|	(занесена в реестр отслеживания изменений)			|
	=========================================================
	*/
	@AbonentId    	INT 		= NULL,
	@DtBeginOio   	DATETIME 	= NULL,
	--@CalcTypeId   INT 		= NULL, Определяем в теле процедуры
	@EventTypeId  	INT 		= NULL,
	@DtFact       	DATETIME 	= NULL,
	@Result      	INT 		= 0   		--  запись кодов ошибок
AS
	SET NOCOUNT ON			-- Отключить счетчик обработанных строк
	SET XACT_ABORT ON		-- Всегда откатывать по ошибке

/* Коды ошибок (Реторнов)
	 0 	- успешно
	-2	- Закрыта история ДЗ
	-1	- фактическая дата меньше ф.даты одного из предыдущих событий
	-3 	- месяц закрыт 
	-4 	- отключение/ограничение произведено слишком поздно
	-5 	- подключение, можно вводить в последнюю запись истории с ДЗ
	-6 	- отключение/ограничение невозможно, нет уведомления
	-7 	- ДЗ уже не существует (забивки не будет вообще никакой)
*/

DECLARE 	@DtEndOio 			DATETIME 	-- дата закрытия истории ДЗ
DECLARE     @DtFact1 			DATETIME 	-- фактическая дата уведомления
DECLARE     @DtBeginOio_New   	DATETIME  	-- Дата начала ДЗ максимальная из истории
DECLARE     @CalcTypeId   		INT 		-- Метод расчета ДЗ

-- если ДЗ переформировано, переназначаем дату начала ДЗ на максимальную в истории
IF NOT EXISTS (SELECT * FROM dbo.OioAbonents WHERE AbonentId = @AbonentId AND DtBeginOio = @DtBeginOio) BEGIN
	SET @DtBeginOio_New = (SELECT MAX(DtBeginOio) FROM OioAbonents WHERE AbonentId = @AbonentId)
	-- если эта дата меньше изначальной или NULL, значит ДЗ не существует 
	IF @DtBeginOio_New < @DtBeginOio OR @DtBeginOio_New IS NULL BEGIN
		SET @Result = -7 
		GOTO ExitProcedure	
	END
	-- если дата больше то назначаем ее
	ELSE BEGIN
		SET @DtBeginOio = @DtBeginOio_New
	END
END

-- дата закрытия истории ДЗ
SELECT 	@DtEndOio = DtEndOio
FROM 	dbo.OioAbonents 
WHERE 	AbonentId = @AbonentId AND DtBeginOio = @DtBeginOio

-- Метод расчета ДЗ
SELECT 	@CalcTypeId = e.CalcTypeId 
FROM 	OioEvents e 
WHERE 	e.AbonentId = @AbonentId AND 
		e.EventTypeId = @EventTypeId AND 
      	e.DtBeginOiO = @DtBeginOiO

IF GETDATE() > '20090531' AND (@EventTypeId BETWEEN 14 AND 20 ) BEGIN -- Билецкий по служебке 13.05.2009 №227/26 - 810
  SET @Result = 0  -- Судебные события можно править всем с '20090531'
END


-- если история ДЗ закрыта
IF @DtEndOio <> '20781231' BEGIN -- СЗ 29.10.2010 №227/26н 1274
	IF @EventTypeId = 27 BEGIN -- подключение, можно вводить в последнюю запись истории с ДЗ 
		IF @DtBeginOio = (SELECT MAX(DtBeginOio) FROM OioAbonents WHERE AbonentId = @AbonentId) BEGIN
			SET @Result = 0
		END
		ELSE BEGIN 
			SET @Result = -5  -- Событие "подключение" разрешено вводить только для последней стороки в истории работы
			GOTO ExitProcedure
		END
	END
	-- Закрыта история ДЗ
	SET @Result = -2 
	GOTO ExitProcedure
END

-- Фактическая дата уведомления по абоненту
SELECT 	@DtFact1 = DtFact 
FROM 	dbo.OioEvents 
WHERE 	AbonentId = @AbonentId AND 
		DtBeginOio = @DtBeginOio AND 
		EventTypeId = 1

-- Проверяем уведомлен ли клиент
IF @EventTypeId IN(3, 6) AND @DtFact1 IS NULL BEGIN --  'Отключение/ограничение невозможно , нет уведомления'
  	SET @Result = -6
	GOTO ExitProcedure
END

-- для отключения проверяем сколько прошло дней после уведомления
IF @EventTypeId = 6 BEGIN
	IF 	( @CalcTypeId = 1 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 65 ) OR
		( @CalcTypeId = 2 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 36 ) BEGIN
			SET @Result = 0
	END
	ELSE BEGIN
		SET @Result = -4 -- отключение произведено слишком поздно
		GOTO ExitProcedure
	END
END

-- для ограничения проверяем сколько прошло дней после уведомления
IF @EventTypeId = 3 BEGIN
	IF 	( @CalcTypeId = 1 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 40 ) OR
		( @CalcTypeId = 2 AND DATEDIFF(day , @DtFact1 , @DtFact ) BETWEEN 0 AND 30 ) BEGIN
			SET @Result = 0
	END
	ELSE BEGIN
		SET @Result = -4 -- отключение произведено слишком поздно
		GOTO ExitProcedure
	END
END

-- предыдущие события по истории с фактической датой большей записываемой
IF EXISTS 
(
  SELECT * 
  FROM dbo.OioEvents
  WHERE
  ( 
        AbonentId   = @AbonentId 
    AND DtBeginOio  = @DtBeginOio
    AND CalcTypeId  = @CalcTypeId
    AND EventTypeId < @EventTypeId
    AND DtFact > @DtFact
  )
) BEGIN
  SET @Result = -1 -- Фактическая дата меньше ф.даты одного из предыдущих событий 
  GOTO ExitProcedure
END

IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId IN(14, 17, 352))
          AND dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20100326' BEGIN
  SET @Result = 0      -- СЗ 227/26н-260 от 22.03.2010
END

IF EXISTS(SELECT * FROM vKernel_QuasarDataBases
          WHERE DivisionId IN(17, 13, 11) OR DivisionPrefix IN(13, 17, 18))
          AND dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20100321' BEGIN
  SET @Result = 0      -- СЗ 227/26н от 11.03.2010
END

IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 26) AND -- QuasarBerezovka
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) BETWEEN '20111012' AND '20111014' BEGIN
  SET @Result = 0      -- СЗ 227/26н 1374 от 27.09.2011
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 343) AND -- QLesosibirskVillages
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20091019' BEGIN
  SET @Result = 0      -- СЗ 227/26н-1153 от 06.10.2009
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId = 25) AND -- Емельяново
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20091018' BEGIN
  SET @Result = 0      -- СЗ 013-227/26н-175 от 24.09.2009
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionPrefix = 13) AND  -- Лесосибирское МРО
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20090918' BEGIN
  SET @Result = 0      -- СЗ 227/26н-1036 от 11.09.2009
END
IF EXISTS(SELECT * FROM vKernel_QuasarDataBases WHERE DivisionId IN('52', '53')) AND -- Ачинск и Район
                                                              dbo.Kernel_CastDateTimeToDate(GETDATE()) <= '20090915' BEGIN
  SET @Result = 0      -- СЗ 227/26н-851 от 09.09.2009 (а принесли 11.09.2009 !)
END
IF EXISTS(SELECT * FROM AccountingPeriods WHERE MonthStatus = 2 AND PeriodNumber = YEAR(@DtFact) * 100 + MONTH(@DtFact)) BEGIN
  SET @Result = -3 -- месяц закрыт
  GOTO ExitProcedure
END

ExitProcedure:
SELECT @Result
GO
GRANT EXECUTE ON Pr_OiOValidateDtFact TO KvzWorker
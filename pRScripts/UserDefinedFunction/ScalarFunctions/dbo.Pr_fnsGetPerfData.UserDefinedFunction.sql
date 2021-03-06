IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetPerfData' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsGetPerfData
GO

CREATE FUNCTION [dbo].[Pr_fnsGetPerfData]
/*=======================================================
Функция возвращяет информацию по контролеру
=======================================================*/
(
@PerformerId		INT,
@DataType			INT = 0 -- Склоненое ФИО
) 
RETURNS varchar(50)
AS
BEGIN
DECLARE @Value VARCHAR(100)

-- Бастан Ольгой Владимировной   
IF @DataType = 0 BEGIN
	SET @Value =	(
					SELECT		Notes
					FROM		PerfData
					WHERE		(PerformerId = @PerformerId)
					)
END
RETURN @Value	
END
GO

GRANT EXECUTE ON Pr_fnsGetPerfData TO KvzWorker

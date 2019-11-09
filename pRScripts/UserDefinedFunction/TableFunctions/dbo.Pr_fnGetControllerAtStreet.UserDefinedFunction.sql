IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnGetControllerAtStreet' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnGetControllerAtStreet
GO

CREATE FUNCTION dbo.Pr_fnGetControllerAtStreet 
  /*
  =====================================
  |  Функция возвращиет контролеров   |
  |  привязанных к заданной улице     |
  =====================================
  */
  (
  @AddressPartId  INT = NULL   --- Ид улицы
  )
RETURNS TABLE 
AS
RETURN  SELECT  a.ControllerId
        FROM    dbo.Abonents AS a
        WHERE   a.AddressPartId = @AddressPartId
GO

GRANT SELECT ON Pr_fnGetControllerAtStreet TO KvzWorker
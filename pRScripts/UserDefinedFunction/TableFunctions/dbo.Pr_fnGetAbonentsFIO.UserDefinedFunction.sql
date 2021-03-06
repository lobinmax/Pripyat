IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnGetAbonentsFIO' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnGetAbonentsFIO
GO
--
CREATE FUNCTION [dbo].[Pr_fnGetAbonentsFIO]()
	RETURNS  TABLE 
	AS	RETURN SELECT abonentid,surname+' '+name+' '+patronymic AS Fio
                 FROM vFamilymembers  WHERE familyroleid=1
GO

GRANT SELECT ON Pr_fnGetAbonentsFIO TO KvzWorker

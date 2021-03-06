IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetCurrentSchemeSection' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION dbo.Pr_fnsGetCurrentSchemeSection
GO
CREATE FUNCTION dbo.Pr_fnsGetCurrentSchemeSection
/*=======================================================
Функция активную схему распределения в секции
=======================================================*/
(
@SectionId		INT = 1
) 
RETURNS INT
AS
BEGIN
	DECLARE @Value INT 
	SELECT @Value = ppps.SchemesId FROM Pr_PointsPublicSections AS ppps WHERE ppps.SectionId = @SectionId
	RETURN @Value
END
GO
GRANT EXECUTE ON dbo.Pr_fnsGetCurrentSchemeSection TO KvzWorker
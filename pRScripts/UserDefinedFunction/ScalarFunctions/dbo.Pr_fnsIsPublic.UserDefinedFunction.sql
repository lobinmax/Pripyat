IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsIsPublic' AND type IN ('IF', 'FN', 'TF'))
    DROP FUNCTION Pr_fnsIsPublic
GO
CREATE FUNCTION Pr_fnsIsPublic
/*=======================================================
Функция возвращяет значение указывающее принадлижит 
ли адрес, абонент либо точка учета к общедомовой ТУ
=======================================================*/
(
@AbonentId		INT = 1,
@Function		INT = 1  -- определение по @AbonentId
) 
RETURNS varchar(25)
AS
BEGIN
DECLARE @IsPublic VARCHAR(25)

IF @Function = 1 BEGIN
	SET @IsPublic =		( 
						SELECT		CASE 
										WHEN p.PublicPointId IS NOT NULL THEN 
											'Дом оснащен ОДПУ' 
									END AS IsPublic
						FROM		vPointsPublicCommunication AS p 
						INNER JOIN	(
									SELECT		PointId, 
												AccountStatusId, 
												MAX(DtChange) AS DtChange
									FROM		PointsHistory
									GROUP BY	PointId, AccountStatusId
									) AS PointPublicMax 
									ON p.PointId = PointPublicMax.PointId
						GROUP BY	CASE 
										WHEN p.PublicPointId IS NOT NULL THEN 
											'Дом оснащен ОДПУ' 
									END, p.AbonentId, PointPublicMax.AccountStatusId
						HAVING		(p.AbonentId = @AbonentId) AND (PointPublicMax.AccountStatusId != 2) -- только подключенные к ОДПУ
						)
END
RETURN @IsPublic
END
GO
GRANT EXECUTE ON Pr_fnsIsPublic TO KvzWorker
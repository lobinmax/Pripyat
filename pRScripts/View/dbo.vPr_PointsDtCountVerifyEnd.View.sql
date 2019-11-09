IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PointsDtCountVerifyEnd' AND type = 'V')
    DROP VIEW vPr_PointsDtCountVerifyEnd
GO
--
CREATE VIEW vPr_PointsDtCountVerifyEnd
AS
SELECT		pi.AbonNumber, 
			pi.PointNumber, 
			ISNULL(fm.SurName + ' ' + fm.Name + ' ' + fm.Patronymic, 'Собственник неопределен') AS SNP, 
			pi.Address, 
			pi.CounterName, 
			pi.CounterNumber, 
			pi.CounterPlace, 
			pi.Signs, 
			pi.DtCountVerify, 
			ct.IntervalVerify, 
			DATEADD(year, ct.IntervalVerify, pi.DtCountVerify) AS DtCountVerifyEnd, 
			hf.Id AS IdFond, 
			CASE WHEN (SELECT a1.HousingOptionId FROM Abonents AS a1 WHERE a1.AbonentId = pi.AbonentId) = 1 THEN 
				'Индивидуальные жилые дома' 
			ELSE 
				'Многоквартирные дома' 
			END AS HousingOption,
			(
			SELECT	Name
			FROM HouseTypes AS ht
			WHERE HouseTypeId = (
								SELECT HouseTypeId
								FROM Abonents AS a2
								WHERE AbonentId = pi.AbonentId
								)
			) AS HouseTypes, 
			AbonentStatus.Name AS AbonentStatus, 
			ExtAbonentStatus.Name AS AbonentReason, 
			AccountStatus.Name AS PointStatus
FROM		AbonentStatus 
INNER JOIN 	vPoints_ListPointsStatus AS ps ON AbonentStatus.AbonentStatusId = ps.AbonentStatusId 
INNER JOIN 	ExtAbonentStatus ON ps.ExtAbonentStatusId = ExtAbonentStatus.ExtAbonentStatusId 
INNER JOIN 	AccountStatus ON ps.PointStatusId = AccountStatus.AccountStatusId 
RIGHT OUTER JOIN vPoints_ListPointsInformation AS pi 
INNER JOIN 	CounterTypes AS ct ON pi.CounterTypeId = ct.CounterTypeId ON ps.AbonentId = pi.AbonentId 
LEFT OUTER JOIN vMainFamilyMembers AS fm ON pi.AbonentId = fm.AbonentId 
LEFT OUTER JOIN vHouseFondOverhaul AS hf ON pi.AbonentId = hf.AbonentId
WHERE pi.CounterName NOT LIKE 'Бесприборный учёт' AND DATEADD(year, ct.IntervalVerify, pi.DtCountVerify) < GETDATE() AND ps.EnergyTypeId = 1
--
GO
GRANT SELECT ON vPr_PointsDtCountVerifyEnd TO KvzWorker

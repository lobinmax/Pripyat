IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_PointsPublicDirectlyManage' AND type = 'V')
    DROP VIEW vPr_PointsPublicDirectlyManage
GO
--
CREATE VIEW vPr_PointsPublicDirectlyManage
AS
-- общедомовые ТУ с непосредственным управлением
SELECT		psa.PublicPointId, 
			psa.PointNumber, 
			pa.CommAddressString, 
			psa.Name, 
			psa.DtCreate, 
			psa.PerformerId, 
			psa.PointNumberIdent, 
			pa.EnergyTypeId, 
			pa.AddressString, 
			pa.House, 
			pa.LetterHouse, 
			pa.Build, 
			pa.SectionBegin, 
			pa.RoomBegin, 
			pa.LetterRoomBegin, 
			pa.SectionEnd, 
			pa.RoomEnd, 
			pa.LetterRoomEnd, 
			e.Name AS PerformerName, 
			ph.SquareAccount,
			'EXEC PointsPublic_PointsPublicIndicationsFunctions @PublicPointId = ' + CAST(psa.PublicPointId AS VARCHAR) + ', @PeriodNumber = ' + CAST((SELECT kpnom.PeriodNumber FROM vKernel_PeriodNumberOpenMin AS kpnom) AS VARCHAR) + ', @DtDoc = ''' + CONVERT (VARCHAR, (SELECT dbo.Pr_fnsGetLastDayPeriod((SELECT kpnom.PeriodNumber FROM vKernel_PeriodNumberOpenMin AS kpnom))), 104) + ''', @Function = 1, @PointsPublicSchemeId = 7, @SquareJuricticFace = 0' AS QueryString 
FROM		Elements AS e 
INNER JOIN 	vPointsPublicAccount AS pa ON e.ElementId = pa.PerformerId 
LEFT OUTER JOIN (
				SELECT	pph.DtChange, 
						pphM.PublicPointId, 
						pphM.DtChange AS DtChangeM, 
						pph.AccountStatusId, 
						pph.DtUpdate, 
						pph.PerformerId, 
						pph.SquareAccount, 
						pph.DtEnd, 
						pph.NormId
				FROM	PointsPublicHistory AS pph 
				RIGHT OUTER JOIN (
								SELECT	PublicPointId, 
										MAX(DtChange) AS DtChange
								FROM	PointsPublicHistory AS pph
								GROUP BY PublicPointId
								) AS pphM ON pph.PublicPointId = pphM.PublicPointId AND pph.DtChange = pphM.DtChange
				) AS ph ON pa.PublicPointId = ph.PublicPointId 
LEFT OUTER JOIN PointsPublicSubAccount AS psa ON pa.PublicPointId = psa.PublicPointId
WHERE    	psa.Name LIKE '%непосредст%'
--
GO
GRANT SELECT ON vPr_PointsPublicDirectlyManage TO KvzWorker
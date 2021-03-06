IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'Pr_fnsGetLastPayments' AND type = 'FN')
    DROP FUNCTION Pr_fnsGetLastPayments
GO
CREATE FUNCTION dbo.Pr_fnsGetLastPayments
/*=======================================================
Функция возвращяет дату и сумму последнего платежа
в разныз интерпритациях
=======================================================*/
	(
	@AbonentId	INT,		-- Ид абоента
	@Dtdoc		DATE,		-- Максимальная дата платежей
	@Function	INT = 0		-- одной строкой
	)
RETURNS VARCHAR(MAX)
AS
BEGIN
DECLARE @Value	VARCHAR(MAX) 
-- если дата не указана, устанавливаем сегодняшнюю
IF @DtDoc IS NULL OR @DtDoc = '' BEGIN SET @DtDoc = GETDATE() END
IF @Function = 0 BEGIN
	SET @Value =	(
					SELECT			ISNULL(CONVERT(VARCHAR, p.LastDtPay, 104) + ' г. - ' + dbo.Pr_fnsGetNumberSeparate(CAST(CAST(p.LastSumPay AS NUMERIC(10, 2)) AS VARCHAR), NULL, NULL) + ' руб.', 'Оплаты не производились') AS LastPayString
					FROM			dbo.Abonents 
					LEFT OUTER JOIN (
									SELECT		a.AbonentId, 
												a.LastDtdoc AS LastDtPay, 
												CAST(SUM(r1.SumPayments) AS NUMERIC(10, 2)) AS LastSumPay
									FROM		(
												SELECT			d.AbonentId, 
																MAX(d.DtDoc) AS LastDtdoc
												FROM			vDocuments AS d 
												INNER JOIN		Receipts AS r ON d.DocumentId = r.ReceiptId 
												INNER JOIN		Points AS p ON d.PointId = p.PointId
												WHERE			r.SumPayments > $0 AND 
																--r.ArticleId IN (2004100119, 2004100131) AND 
																d.DocumentTypeId = 1 AND 
																d.StateId = 5 AND 
																d.DtDoc <= CONVERT(DATETIME, @DtDoc, 102) AND 
																p.EnergyTypeId = 1
												GROUP BY		d.AbonentId
												) AS a 
									INNER JOIN	vDocuments AS d1 ON d1.AbonentId = a.AbonentId AND d1.DtDoc = a.LastDtdoc 
									INNER JOIN	Receipts AS r1 ON r1.ReceiptId = d1.DocumentId 
									INNER JOIN	Points AS p1 ON d1.PointId = p1.PointId
									WHERE		r1.SumPayments > $0 AND
												d1.DocumentTypeId = 1 AND 
												d1.StateId = 5 AND 
												p1.EnergyTypeId = 1
									GROUP BY	a.AbonentId, a.LastDtdoc
									) AS p 
					ON dbo.Abonents.AbonentId = p.AbonentId
					WHERE	Abonents.AbonentId = @AbonentId
					)
END
	RETURN @Value
END
GO
GRANT EXECUTE ON Pr_fnsGetLastPayments TO KvzWorker

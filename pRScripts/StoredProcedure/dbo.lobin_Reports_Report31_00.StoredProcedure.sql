IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'lobin_Reports_Report31_00' AND type = 'P')
    DROP PROCEDURE dbo.lobin_Reports_Report31_00
GO
CREATE PROCEDURE dbo.lobin_Reports_Report31_00 
--производная процедура от dbo.lobin_Reports_Report31
@PeriodNumber INT = NULL
AS
SET NOCOUNT ON

INSERT INTO #t1
(
  AccountId,
  SumCharges,
  PowerCharges,
  TariffCount,
  TariffTypeId,
  TariffTypeName,
  [name],
  CookId,
  CookName,
  LimitTypeId,
  LimitName,
  TariffId,
  [Date],
  MonthNumber,
  GroupCookerId,
  DtChangeTariff
)
SELECT
  AccountId,
  SumCharges,
  PowerCharges,
  TariffCount,
  TariffTypeId,
  TariffTypeName,
  [name],
  CookId,
  CookName,
  LimitTypeId,
  LimitName,
  TariffId,
  [Date],
  MonthNumber,
  GroupCookerId,
  DtChangeTariff
FROM #t0

GO
GRANT EXECUTE ON dbo.lobin_Reports_Report31_00 TO KvzWorker
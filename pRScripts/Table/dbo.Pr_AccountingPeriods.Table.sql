CREATE TABLE dbo.Pr_AccountingPeriods (
	PeriodNumber INT NOT NULL
   ,MonthStatus TINYINT NOT NULL
   ,DtOpened SMALLDATETIME NULL
   ,DtClosed SMALLDATETIME NULL
   ,ActiveStatusId TINYINT NULL
) ON [PRIMARY]
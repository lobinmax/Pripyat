CREATE TABLE dbo.Pr_JournalBooks (
	CodJournalId VARCHAR(10) NOT NULL
   ,JournalNumber INT NOT NULL
   ,JournalStatusId INT NOT NULL
   ,DtOpen SMALLDATETIME NOT NULL
   ,DtClose SMALLDATETIME NULL
   ,OpenPerformerId INT NOT NULL
   ,ClosePerformerId INT NULL
   ,Notes VARCHAR(300) NULL
   ,CONSTRAINT PK_Pr_JournalBooks PRIMARY KEY CLUSTERED (CodJournalId, JournalNumber)
) ON [PRIMARY]

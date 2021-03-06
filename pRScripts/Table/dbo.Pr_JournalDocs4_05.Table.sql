CREATE TABLE dbo.Pr_JournalDocs4_05 (
	DocId INT IDENTITY (-1999999999, 1)
   ,CodJournalId VARCHAR(10) NOT NULL
   ,CodJournalDocsId VARCHAR(10) NOT NULL
   ,JournalNumber INT NOT NULL
   ,DocNumber INT NOT NULL
   ,SessionId INT NULL
   ,DtDocument SMALLDATETIME NOT NULL
   ,AbonentId INT NOT NULL
   ,FamilyMemberId INT NULL
   ,AbonentNumber VARCHAR(20) NOT NULL
   ,SNP_short VARCHAR(100) NOT NULL
   ,AddressString VARCHAR(200) NOT NULL
   ,SumDoc NUMERIC(10, 2) NOT NULL
   ,DocumentTypeId TINYINT NOT NULL
   ,ControllerId INT NOT NULL
   ,PeriodNumber INT NOT NULL
   ,DtDoc SMALLDATETIME NOT NULL
   ,DtBeginOio SMALLDATETIME NOT NULL
   ,AuthorId INT NOT NULL
   ,CONSTRAINT PK_Pr_JournalDocs4_05_1 PRIMARY KEY CLUSTERED (DocId)
) ON [PRIMARY]
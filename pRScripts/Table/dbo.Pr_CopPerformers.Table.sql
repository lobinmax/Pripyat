CREATE TABLE dbo.Pr_CopPerformers (
	CopPerformerId INT IDENTITY
   ,Name VARCHAR(50) NOT NULL
   ,Phone VARCHAR(20) NULL
   ,PhoneMobile VARCHAR(20) NULL
   ,Email VARCHAR(50) NULL
   ,CONSTRAINT PK_Pr_CopPerformers PRIMARY KEY CLUSTERED (CopPerformerId)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX IX_Pr_CopPerformersId
ON dbo.Pr_CopPerformers (CopPerformerId)
ON [PRIMARY]
GO

CREATE UNIQUE INDEX IX_Pr_CopPerformersName
ON dbo.Pr_CopPerformers (Name)
ON [PRIMARY]

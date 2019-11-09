CREATE TABLE dbo.Pr_CountersSectionHistory (
	SectionId INT NOT NULL
   ,DtCounterSetup SMALLDATETIME NOT NULL
   ,CounterTypeId SMALLINT NOT NULL
   ,CounterNumber VARCHAR(20) NOT NULL
   ,IndicationSetup INT NOT NULL
   ,DtCountRemove SMALLDATETIME NULL
   ,IndicationRemove VARCHAR(50) NULL
   ,DtCreate SMALLDATETIME NOT NULL
   ,CreaterId INT NOT NULL
   ,DtUpdate SMALLDATETIME NOT NULL
   ,UpdaterId INT NOT NULL
   ,PeriodNumber INT NOT NULL
   ,IsActive INT NOT NULL
   ,CONSTRAINT PK_Pr_CountersSectionHistory PRIMARY KEY CLUSTERED (SectionId)
   ,CONSTRAINT KEY_Pr_CountersSectionHistory UNIQUE (SectionId, DtCounterSetup)
) ON [PRIMARY]
GO

CREATE INDEX IDX_Pr_CountersSectionHistory_CounterTypeId
ON dbo.Pr_CountersSectionHistory (CounterTypeId)
ON [PRIMARY]
GO

CREATE INDEX IDX_Pr_CountersSectionHistory_CreaterId
ON dbo.Pr_CountersSectionHistory (CreaterId)
ON [PRIMARY]
GO

CREATE INDEX IDX_Pr_CountersSectionHistory_UpdaterId
ON dbo.Pr_CountersSectionHistory (UpdaterId)
ON [PRIMARY]
GO
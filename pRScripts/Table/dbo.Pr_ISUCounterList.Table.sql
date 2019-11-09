CREATE TABLE dbo.Pr_ISUCounterList (
	CounterTypeId SMALLINT NOT NULL
   ,CreaterId INT NOT NULL
   ,CreateDt DATETIME NOT NULL
   ,CONSTRAINT PK_Pr_ISUCounterList_CounterTypeId PRIMARY KEY CLUSTERED (CounterTypeId)
   ,CONSTRAINT KEY_Pr_ISUCounterList_CounterTypeId UNIQUE (CounterTypeId)
) ON [PRIMARY]
GO

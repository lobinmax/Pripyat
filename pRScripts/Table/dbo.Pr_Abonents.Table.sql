CREATE TABLE dbo.Pr_Abonents (
	AbonentId INT NOT NULL
   ,GKHid INT NULL
   ,CityPartsId INT NULL
   ,RouterId INT NULL
   ,CONSTRAINT PK_Pr_Abonents_AbonentId PRIMARY KEY CLUSTERED (AbonentId)
) ON [PRIMARY]
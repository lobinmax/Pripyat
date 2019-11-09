CREATE TABLE dbo.Pr_HousingOptionId (
	HousingOptionId INT NOT NULL
   ,Name VARCHAR(50) NOT NULL
   ,CONSTRAINT PK_Pr_HousingOptionId_HousingOptionId PRIMARY KEY CLUSTERED (HousingOptionId)
) ON [PRIMARY]
GO

-- добавить данные
INSERT INTO Pr_HousingOptionId SELECT 1, 'Индивидуальные жилые дома'
INSERT INTO Pr_HousingOptionId SELECT 2, 'Многоквартирные дома'
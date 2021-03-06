CREATE TABLE dbo.Pr_EnergyTypes (
	EnergyTypeId INT NOT NULL
   ,Name VARCHAR(50) NOT NULL
   ,NameShort VARCHAR(5) NOT NULL
   ,CONSTRAINT PK_Pr_EnergyTypes PRIMARY KEY CLUSTERED (EnergyTypeId DESC)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX IX_Pr_EnergyTypes_Name
ON dbo.Pr_EnergyTypes (Name DESC)
ON [PRIMARY]
GO

-- Добавить данные
INSERT [dbo].[Pr_EnergyTypes] ([EnergyTypeId], [Name], [NameShort]) VALUES (9, N'Дополнительные услуги', N'ДУ')
INSERT [dbo].[Pr_EnergyTypes] ([EnergyTypeId], [Name], [NameShort]) VALUES (5, N'Взнос на капитальный ремонт', N'КР')
INSERT [dbo].[Pr_EnergyTypes] ([EnergyTypeId], [Name], [NameShort]) VALUES (3, N'ЭЭ + Допп.услуги', N'ЭЭДУ')
INSERT [dbo].[Pr_EnergyTypes] ([EnergyTypeId], [Name], [NameShort]) VALUES (1, N'Электроэнергия', N'ЭЭ')
GO
GRANT SELECT ON Pr_EnergyTypes TO KvzWorker
GRANT UPDATE ON Pr_EnergyTypes TO KvzWorker
GRANT DELETE ON Pr_EnergyTypes TO KvzWorker
GRANT INSERT ON Pr_EnergyTypes TO KvzWorker
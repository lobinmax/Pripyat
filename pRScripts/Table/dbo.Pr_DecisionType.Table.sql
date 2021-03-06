CREATE TABLE dbo.Pr_DecisionType (
	DecisionTypeId INT NOT NULL
   ,Name VARCHAR(50) NULL
   ,CONSTRAINT PK_Pr_DecisionType PRIMARY KEY CLUSTERED (DecisionTypeId)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX IX_Pr_DecisionType_Name
ON dbo.Pr_DecisionType (Name)
ON [PRIMARY]
GO

-- добавить данные
INSERT [dbo].[Pr_DecisionType] ([DecisionTypeId], [Name]) VALUES (4, NULL)
INSERT [dbo].[Pr_DecisionType] ([DecisionTypeId], [Name]) VALUES (5, N'1. Судебный приказ')
INSERT [dbo].[Pr_DecisionType] ([DecisionTypeId], [Name]) VALUES (3, N'2. Определение')
INSERT [dbo].[Pr_DecisionType] ([DecisionTypeId], [Name]) VALUES (2, N'3. Заочное решение')
INSERT [dbo].[Pr_DecisionType] ([DecisionTypeId], [Name]) VALUES (1, N'4. Решение')
GO
GRANT SELECT ON Pr_DecisionType TO KvzWorker
GRANT UPDATE ON Pr_DecisionType TO KvzWorker
GRANT DELETE ON Pr_DecisionType TO KvzWorker
GRANT INSERT ON Pr_DecisionType TO KvzWorker
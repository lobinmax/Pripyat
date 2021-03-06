CREATE TABLE dbo.Pr_DecisionTypeExt (
	DecisionTypeId INT NOT NULL
   ,DecisionTypeExtId INT NOT NULL
   ,Name VARCHAR(100) NULL
   ,CONSTRAINT PK_Pr_DecisionTypeExt PRIMARY KEY CLUSTERED (DecisionTypeId, DecisionTypeExtId)
) ON [PRIMARY]
GO

CREATE INDEX IX_Pr_DecisionTypeExt_Name
ON dbo.Pr_DecisionTypeExt (Name)
ON [PRIMARY]
GO

-- Добавить данные
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (1, 130, N'1. Решение об удовлетворении исковых требований в полном объеме')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (2, 230, N'1. Решение об удовлетворении исковых требований в полном объеме')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 390, N'1. Удовлетворить заявленные требования в полном объеме')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 310, N'2. Возражение абонента')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (1, 120, N'2. Решение об отказе в удовлетворении исковых требований')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (2, 220, N'2. Решение об отказе в удовлетворении исковых требований')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 340, N'3. Определение об оставлении без рассмотрения и возвратете искового заявления')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (1, 110, N'3. Решение о частичном удовлетворении исковых требований')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (2, 210, N'3. Решение о частичном удовлетворении исковых требований')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (1, 140, N'4. Задолженность за сроком исковой')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (2, 240, N'4. Задолженность за сроком исковой')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 350, N'4. Определение об отказе исца от иска')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 330, N'5. Определение о прекращении производства по делу')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 360, N'6. Смерть должника')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 370, N'7. Выдать дубликат исполнительного документа')
INSERT [dbo].[Pr_DecisionTypeExt] ([DecisionTypeId], [DecisionTypeExtId], [Name]) VALUES (3, 380, N'8. Отказать в выдаче дубликата исполнительного документа')

GO
GRANT SELECT ON Pr_DecisionTypeExt TO KvzWorker
GRANT UPDATE ON Pr_DecisionTypeExt TO KvzWorker
GRANT DELETE ON Pr_DecisionTypeExt TO KvzWorker
GRANT INSERT ON Pr_DecisionTypeExt TO KvzWorker
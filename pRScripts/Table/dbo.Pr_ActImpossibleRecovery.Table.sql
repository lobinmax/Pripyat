CREATE TABLE dbo.Pr_ActImpossibleRecovery (
	ActImpossibleRecoveryId INT NOT NULL
   ,Name VARCHAR(30) NOT NULL
   ,CONSTRAINT PK_Pr_ActImpossibleRecovery PRIMARY KEY CLUSTERED (ActImpossibleRecoveryId)
) ON [PRIMARY]
GO

-- добавить 
INSERT [dbo].[Pr_ActImpossibleRecovery] ([ActImpossibleRecoveryId], [Name]) VALUES (1, N'Отсутствует имущество')
INSERT [dbo].[Pr_ActImpossibleRecovery] ([ActImpossibleRecoveryId], [Name]) VALUES (2, N'Местонахождение не установлено')

GO
GRANT SELECT ON Pr_ActImpossibleRecovery TO KvzWorker
GRANT UPDATE ON Pr_ActImpossibleRecovery TO KvzWorker
GRANT DELETE ON Pr_ActImpossibleRecovery TO KvzWorker
GRANT INSERT ON Pr_ActImpossibleRecovery TO KvzWorker
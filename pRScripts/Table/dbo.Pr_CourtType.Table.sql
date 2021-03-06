CREATE TABLE dbo.Pr_CourtType (
	CourtTypeId INT NOT NULL
   ,Name VARCHAR(30) NOT NULL
   ,CONSTRAINT PK_Pr_CourtType PRIMARY KEY CLUSTERED (CourtTypeId)
   ,CONSTRAINT IX_Pr_CourtType UNIQUE (Name)
) ON [PRIMARY]
GO
-- добавить данные
INSERT [dbo].[Pr_CourtType] ([CourtTypeId], [Name]) VALUES (1, N'Мировой суд')
INSERT [dbo].[Pr_CourtType] ([CourtTypeId], [Name]) VALUES (2, N'Федеральный суд')
GO
GRANT SELECT ON Pr_CourtType TO KvzWorker
GRANT UPDATE ON Pr_CourtType TO KvzWorker
GRANT DELETE ON Pr_CourtType TO KvzWorker
GRANT INSERT ON Pr_CourtType TO KvzWorker
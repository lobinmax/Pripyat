CREATE TABLE dbo.Pr_DecisionDirections (
	DecisionDirectionId INT NOT NULL
   ,Name VARCHAR(30) NULL
   ,CONSTRAINT PK_Pr_DecisionDirections PRIMARY KEY CLUSTERED (DecisionDirectionId)
   ,CONSTRAINT IX_Pr_DecisionDirections_Name UNIQUE (Name)
) ON [PRIMARY]
GO
-- �������� ������
INSERT [dbo].[Pr_DecisionDirections] ([DecisionDirectionId], [Name]) VALUES (5, N'')
INSERT [dbo].[Pr_DecisionDirections] ([DecisionDirectionId], [Name]) VALUES (4, N'����� ������ ��������')
INSERT [dbo].[Pr_DecisionDirections] ([DecisionDirectionId], [Name]) VALUES (2, N'����')
INSERT [dbo].[Pr_DecisionDirections] ([DecisionDirectionId], [Name]) VALUES (3, N'����')
INSERT [dbo].[Pr_DecisionDirections] ([DecisionDirectionId], [Name]) VALUES (1, N'���� ������')
GO
GRANT SELECT ON Pr_DecisionDirections TO KvzWorker
GRANT UPDATE ON Pr_DecisionDirections TO KvzWorker
GRANT DELETE ON Pr_DecisionDirections TO KvzWorker
GRANT INSERT ON Pr_DecisionDirections TO KvzWorker

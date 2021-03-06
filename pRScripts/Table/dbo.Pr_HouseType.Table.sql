CREATE TABLE dbo.Pr_HouseType (
	prHouseTypeId INT NOT NULL
   ,Name VARCHAR(30) NOT NULL
   ,ShortName VARCHAR(5) NOT NULL
   ,KVZ_HousePropId INT NOT NULL
   ,KVZ_HousePropName VARCHAR(255) NOT NULL
   ,CONSTRAINT PK_Pr_HouseType PRIMARY KEY CLUSTERED (KVZ_HousePropId)
) ON [PRIMARY]
GO

--добавить данные
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (2, N'Многоквартирные дома', N'МКД', 1, N'Многоквартирные дома со всеми удобствами с электроплитой')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (2, N'Многоквартирные дома', N'МКД', 2, N'Многоквартирные дома со всеми удобствами с газовой плитой')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (2, N'Многоквартирные дома', N'МКД', 3, N'Многоквартирные дома НЕ со всеми удобствами БЕЗ электроплиты')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (1, N'Частный сектор', N'ЧС', 4, N'Индивидуальные жилые дома')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (1, N'Частный сектор', N'ЧС', 11, N'Одноквартирные дома, НЕ оборудованные электрическими плитами')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (1, N'Частный сектор', N'ЧС', 12, N'Одноквартирные дома, оборудованные электрическими плитами')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (2, N'Многоквартирные дома', N'МКД', 13, N'Многоквартирные дома, без лифта, не оборудованные электрическими плитами')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (2, N'Многоквартирные дома', N'МКД', 14, N'Многоквартирные дома, без лифта, оборудованные электрическими плитами')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (2, N'Многоквартирные дома', N'МКД', 15, N'Многоквартирные дома, с лифтом, не оборудованные электрическими плитами')
INSERT [dbo].[Pr_HouseType] ([prHouseTypeId], [Name], [ShortName], [KVZ_HousePropId], [KVZ_HousePropName]) VALUES (2, N'Многоквартирные дома', N'МКД', 16, N'Многоквартирные дома, с лифтом, оборудованные электрическими плитами')
GO

GRANT SELECT ON Pr_HouseType TO KvzWorker
GRANT UPDATE ON Pr_HouseType TO KvzWorker
GRANT DELETE ON Pr_HouseType TO KvzWorker
GRANT INSERT ON Pr_HouseType TO KvzWorker
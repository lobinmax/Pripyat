-- Pr_Abonents
ALTER TABLE dbo.Pr_Abonents
ADD CONSTRAINT FK_Pr_Abonents_CityPartsId FOREIGN KEY (CityPartsId) REFERENCES dbo.Pr_CityParts (Id)
GO

ALTER TABLE dbo.Pr_Abonents
ADD CONSTRAINT FK_Pr_Abonents_GKHid FOREIGN KEY (GKHid) REFERENCES dbo.Pr_GKH (GKHid)
GO

ALTER TABLE dbo.Pr_Abonents
ADD CONSTRAINT FK_Pr_Abonents_RouterId FOREIGN KEY (RouterId) REFERENCES dbo.Pr_Routers (RouterId)
GO

-- Pr_CityParts
ALTER TABLE dbo.Pr_CityParts
ADD CONSTRAINT FK_Pr_CityParts_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_CityParts
ADD CONSTRAINT FK_Pr_CityParts_UpdaterId FOREIGN KEY (UpdaterId) REFERENCES dbo.Performers (PerformerId)
GO

-- Pr_DecisionTypeExt
ALTER TABLE dbo.Pr_DecisionTypeExt
ADD CONSTRAINT FK_Pr_DecisionTypeExt_Pr_DecisionType FOREIGN KEY (DecisionTypeId) REFERENCES dbo.Pr_DecisionType (DecisionTypeId)
GO

-- Pr_GKH
ALTER TABLE dbo.Pr_GKH
ADD CONSTRAINT FK_Pr_GKH_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_GKH
ADD CONSTRAINT FK_Pr_GKH_UpdaterId FOREIGN KEY (UpdaterId) REFERENCES dbo.Performers (PerformerId)
GO

-- Pr_GKO
ALTER TABLE dbo.Pr_GKO
ADD CONSTRAINT FK_Pr_GKO_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_GKO
ADD CONSTRAINT FK_Pr_GKO_UpdaterId FOREIGN KEY (UpdaterId) REFERENCES dbo.Performers (PerformerId)
GO

-- Pr_ISUCounterList
/*
ALTER TABLE dbo.Pr_ISUCounterList
ADD CONSTRAINT FK_Pr_ISUCounterList_CounterTypeId FOREIGN KEY (CounterTypeId) REFERENCES dbo.CounterTypes (CounterTypeId)
GO
*/
ALTER TABLE dbo.Pr_ISUCounterList
ADD CONSTRAINT FK_Pr_ISUCounterList_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO

-- Pr_JournalBooks
ALTER TABLE dbo.Pr_JournalBooks
ADD CONSTRAINT FK_Pr_JournalBooks_Pr_JournalStatus FOREIGN KEY (JournalStatusId) REFERENCES dbo.Pr_JournalStatus (StatusId)
GO

ALTER TABLE dbo.Pr_JournalBooks
ADD CONSTRAINT FK_Pr_JournalBooks_Pr_JournaType FOREIGN KEY (CodJournalId) REFERENCES dbo.Pr_JournaType (CodJournalId)
GO

-- Pr_JournalDocs4_05
/*
ALTER TABLE dbo.Pr_JournalDocs4_05 WITH NOCHECK
ADD CONSTRAINT FK_Pr_JournalDocs4_05_Abonents FOREIGN KEY (AbonentId) REFERENCES dbo.Abonents (AbonentId)
GO
*/
ALTER TABLE dbo.Pr_JournalDocs4_05
ADD CONSTRAINT FK_Pr_JournalDocs4_05_ControllerId FOREIGN KEY (ControllerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_JournalDocs4_05
ADD CONSTRAINT FK_Pr_JournalDocs4_05_Pr_JournalBooks FOREIGN KEY (CodJournalId, JournalNumber) REFERENCES dbo.Pr_JournalBooks (CodJournalId, JournalNumber)
GO

ALTER TABLE dbo.Pr_JournalDocs4_05
ADD CONSTRAINT FK_Pr_JournalDocs4_05_Pr_JournaType FOREIGN KEY (CodJournalId) REFERENCES dbo.Pr_JournaType (CodJournalId)
GO

ALTER TABLE dbo.Pr_JournalDocs4_05
ADD CONSTRAINT FK_Pr_JournalDocs4_05_Pr_JournaTypeDocs FOREIGN KEY (CodJournalDocsId, CodJournalId, DocumentTypeId) REFERENCES dbo.Pr_JournaTypeDocs (CodJournalId, ParentCodJournalId, DocumentTypeId)
GO

ALTER TABLE dbo.Pr_JournalDocs4_05
ADD CONSTRAINT FK_Pr_JournalDocs4_05_Pr_OioPrintSessions FOREIGN KEY (SessionId) REFERENCES dbo.Pr_OioPrintSessions (SessionId)
GO

-- Pr_JournalDocsDeveloped
ALTER TABLE dbo.Pr_JournalDocsDeveloped
ADD CONSTRAINT FK_Pr_JournalDocsDeveloped_AuthorId FOREIGN KEY (AuthorId) REFERENCES dbo.Performers (PerformerId)
GO
/*
ALTER TABLE dbo.Pr_JournalDocsDeveloped
ADD CONSTRAINT FK_Pr_JournalDocsDeveloped_DMethodId FOREIGN KEY (DMethodId) REFERENCES dbo.OiODeliveryMethods (DMethodId)
GO
*/
ALTER TABLE dbo.Pr_JournalDocsDeveloped
ADD CONSTRAINT FK_Pr_JournalDocsDeveloped_DocId FOREIGN KEY (DocId) REFERENCES dbo.Pr_JournalDocs4_05 (DocId)
GO
/*
ALTER TABLE dbo.Pr_JournalDocsDeveloped
ADD CONSTRAINT FK_Pr_JournalDocsDeveloped_EventTypeId FOREIGN KEY (EventTypeId) REFERENCES dbo.OioEventsTypes (EventTypeId)
GO
*/
ALTER TABLE dbo.Pr_JournalDocsDeveloped
ADD CONSTRAINT FK_Pr_JournalDocsDeveloped_PerformerId FOREIGN KEY (PerformerId) REFERENCES dbo.Performers (PerformerId)
GO

-- Pr_JournalTaskSheetPerformers
ALTER TABLE dbo.Pr_JournalTaskSheetPerformers
ADD CONSTRAINT FK_Pr_JournalTaskSheetP_Pr_JournalTaskSheets FOREIGN KEY (TaskSheetId) REFERENCES dbo.Pr_JournalTaskSheets (TaskSheetId)
GO

-- Pr_JournalTaskSheets
ALTER TABLE dbo.Pr_JournalTaskSheets
ADD CONSTRAINT FK_Pr_JournalTaskSheets_Pr_JournalBooks FOREIGN KEY (CodJournalId, JournalNumber) REFERENCES dbo.Pr_JournalBooks (CodJournalId, JournalNumber)
GO

-- Pr_JournaTypeDocs
ALTER TABLE dbo.Pr_JournaTypeDocs
ADD CONSTRAINT FK_Pr_JournaTypeDocs_Pr_JournalDocumentsType1 FOREIGN KEY (DocumentTypeId) REFERENCES dbo.Pr_JournalDocumentsType (DocumentTypeId)
GO

ALTER TABLE dbo.Pr_JournaTypeDocs
ADD CONSTRAINT FK_Pr_JournaTypeDocs_Pr_JournaType FOREIGN KEY (ParentCodJournalId) REFERENCES dbo.Pr_JournaType (CodJournalId)
GO

-- Pr_Judges
ALTER TABLE dbo.Pr_Judges
ADD CONSTRAINT FK_Pr_Judges_Pr_CourtType FOREIGN KEY (CourtTypeId) REFERENCES dbo.Pr_CourtType (CourtTypeId)
GO

-- Pr_JudicialArea
ALTER TABLE dbo.Pr_JudicialArea
ADD CONSTRAINT FK_Pr_JudicialArea_Pr_CourtType FOREIGN KEY (CourtTypeId) REFERENCES dbo.Pr_CourtType (CourtTypeId)
GO

ALTER TABLE dbo.Pr_JudicialArea
ADD CONSTRAINT FK_Pr_JudicialArea_Pr_Judges FOREIGN KEY (CurrentJudgeId) REFERENCES dbo.Pr_Judges (JudgeId)
GO

ALTER TABLE dbo.Pr_JudicialArea
ADD CONSTRAINT FK_Pr_JudicialArea_Pr_ZoneOfService FOREIGN KEY (ZoneOfServiceId) REFERENCES dbo.Pr_ZoneOfService (ZoneOfServiceId)
GO

-- Pr_Members
/*
ALTER TABLE dbo.Pr_Members
ADD CONSTRAINT FK_Pr_Members_Abonents FOREIGN KEY (AbonentId) REFERENCES dbo.Abonents (AbonentId)
GO

ALTER TABLE dbo.Pr_Members
ADD CONSTRAINT FK_Pr_Members_FamilyRoles FOREIGN KEY (FamilyRoleId) REFERENCES dbo.FamilyRoles (FamilyRoleId)
GO
*/
ALTER TABLE dbo.Pr_Members
ADD CONSTRAINT FK_Pr_Members_Performers FOREIGN KEY (CreatePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_Members
ADD CONSTRAINT FK_Pr_Members_Performers1 FOREIGN KEY (UpdatePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_Members
ADD CONSTRAINT FK_Pr_Members_Pr_SexMembers FOREIGN KEY (SexMembersId) REFERENCES dbo.Pr_SexMembers (SexMembersId)
GO

-- Pr_OioCountMonthAbonent
/*
ALTER TABLE dbo.Pr_OioCountMonthAbonent WITH NOCHECK
ADD CONSTRAINT FK_Pr_OioCountMonthAbonent_Abonents FOREIGN KEY (AbonentId) REFERENCES dbo.Abonents (AbonentId)
GO
*/
-- Pr_OioCountMonthPoint
/*
ALTER TABLE dbo.Pr_OioCountMonthPoint WITH NOCHECK
ADD CONSTRAINT FK_Pr_OioCountMonthPoint_Points FOREIGN KEY (PointId) REFERENCES dbo.Points (PointId)
GO
*/
ALTER TABLE dbo.Pr_OioCountMonthPoint
ADD CONSTRAINT FK_Pr_OioCountMonthPoint_Pr_OioDebtType FOREIGN KEY (DebtTypeId) REFERENCES dbo.Pr_OioDebtType (DebtTypeId)
GO

-- Pr_OioPrintSessions
ALTER TABLE dbo.Pr_OioPrintSessions
ADD CONSTRAINT FK_Pr_OioPrintSessions_AuthorId FOREIGN KEY (AuthorId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_OioPrintSessions
ADD CONSTRAINT FK_Pr_OioPrintSessions_fltr_ControllerId FOREIGN KEY (fltr_ControllerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_OioPrintSessions
ADD CONSTRAINT FK_Pr_OioPrintSessions_fltr_prHouseTypeId FOREIGN KEY (fltr_prHouseTypeId) REFERENCES dbo.Pr_HousingOptionId (HousingOptionId)
GO

ALTER TABLE dbo.Pr_OioPrintSessions
ADD CONSTRAINT FK_Pr_OioPrintSessions_fltr_RouterId FOREIGN KEY (fltr_RouterId) REFERENCES dbo.Pr_Routers (RouterId)
GO

ALTER TABLE dbo.Pr_OioPrintSessions
ADD CONSTRAINT FK_Pr_OioPrintSessions_TaskSheetId FOREIGN KEY (TaskSheetId) REFERENCES dbo.Pr_JournalTaskSheets (TaskSheetId)
GO

-- Pr_PayOrders
ALTER TABLE dbo.Pr_PayOrders WITH NOCHECK
ADD CONSTRAINT FK_Pr_PayOrders_Pr_PayOrderStatus FOREIGN KEY (PayOrderStatusId) REFERENCES dbo.Pr_PayOrderStatus (PayOrderStatusId)
GO

ALTER TABLE dbo.Pr_PayOrders
ADD CONSTRAINT FK_Pr_PayOrders_Pr_PetitionsDebt FOREIGN KEY (AbonentId, DtPeriodStart, DtPeriodEnd, EnergyTypeId, MemberId) REFERENCES dbo.Pr_PetitionsDebt (AbonentId, DtPeriodStart, DtPeriodEnd, EnergyTypeId, MemberId)
GO

-- Pr_Petitions
ALTER TABLE dbo.Pr_Petitions
ADD CONSTRAINT FK_Pr_Petitions_CreatePerformerId FOREIGN KEY (CreatePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_Petitions
ADD CONSTRAINT FK_Pr_Petitions_Pr_ActImpossibleRecovery FOREIGN KEY (ActImpossibleRecoveryId) REFERENCES dbo.Pr_ActImpossibleRecovery (ActImpossibleRecoveryId)
GO

ALTER TABLE dbo.Pr_Petitions
ADD CONSTRAINT FK_Pr_Petitions_Pr_CopPerformers FOREIGN KEY (CopPerformerId) REFERENCES dbo.Pr_CopPerformers (CopPerformerId)
GO

ALTER TABLE dbo.Pr_Petitions
ADD CONSTRAINT FK_Pr_Petitions_Pr_EnergyTypes FOREIGN KEY (EnergyTypeId) REFERENCES dbo.Pr_EnergyTypes (EnergyTypeId)
GO

ALTER TABLE dbo.Pr_Petitions
ADD CONSTRAINT FK_Pr_Petitions_Pr_PetitionsDebt FOREIGN KEY (AbonentId, DtPeriodStart, DtPeriodEnd, EnergyTypeId, MemberId) REFERENCES dbo.Pr_PetitionsDebt (AbonentId, DtPeriodStart, DtPeriodEnd, EnergyTypeId, MemberId)
GO

ALTER TABLE dbo.Pr_Petitions
ADD CONSTRAINT FK_Pr_Petitions_UpdatePerformerId FOREIGN KEY (UpdatePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

--Pr_PetitionsDebt
/*
ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Abonents FOREIGN KEY (AbonentId) REFERENCES dbo.Abonents (AbonentId)
GO
*/
ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Performers FOREIGN KEY (CratePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Performers1 FOREIGN KEY (UpdatePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_CourtType FOREIGN KEY (CourtTypeId) REFERENCES dbo.Pr_CourtType (CourtTypeId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_DecisionDirections FOREIGN KEY (DecisionDirectionId) REFERENCES dbo.Pr_DecisionDirections (DecisionDirectionId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_DecisionType FOREIGN KEY (DecisionTypeId) REFERENCES dbo.Pr_DecisionType (DecisionTypeId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_EnergyTypes FOREIGN KEY (EnergyTypeId) REFERENCES dbo.Pr_EnergyTypes (EnergyTypeId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_JudicialArea FOREIGN KEY (JudicialAreaId) REFERENCES dbo.Pr_JudicialArea (JudicialAreaId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_Members FOREIGN KEY (MemberId) REFERENCES dbo.Pr_Members (MemberId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_PetitionsPacks FOREIGN KEY (PetitionsPacksId) REFERENCES dbo.Pr_PetitionsPacks (PetitionsPacksId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_PetitionType FOREIGN KEY (PetitionTypeId) REFERENCES dbo.Pr_PetitionType (PetitionTypeId)
GO

ALTER TABLE dbo.Pr_PetitionsDebt
ADD CONSTRAINT FK_Pr_PetitionsDebt_Pr_ReasonForEnd FOREIGN KEY (ReasonForEndId) REFERENCES dbo.Pr_ReasonForEnd (ReasonForEndId)
GO

-- Pr_PetitionsListening
ALTER TABLE dbo.Pr_PetitionsListening
ADD CONSTRAINT FK_Pr_PetitionsListening_CratePerformerId FOREIGN KEY (CratePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_PetitionsListening
ADD CONSTRAINT FK_Pr_PetitionsListening_EnergyTypeId FOREIGN KEY (EnergyTypeId) REFERENCES dbo.Pr_EnergyTypes (EnergyTypeId)
GO

ALTER TABLE dbo.Pr_PetitionsListening
ADD CONSTRAINT FK_Pr_PetitionsListening_Pr_ListeningType FOREIGN KEY (ListeningTypeId) REFERENCES dbo.Pr_ListeningType (ListeningTypeId)
GO

ALTER TABLE dbo.Pr_PetitionsListening
ADD CONSTRAINT FK_Pr_PetitionsListening_Pr_PetitionsDebt FOREIGN KEY (AbonentId, DtPeriodStart, DtPeriodEnd, EnergyTypeId, MemberId) REFERENCES dbo.Pr_PetitionsDebt (AbonentId, DtPeriodStart, DtPeriodEnd, EnergyTypeId, MemberId)
GO

ALTER TABLE .dbo.Pr_PetitionsListening
ADD CONSTRAINT FK_Pr_PetitionsListening_UpdatePerformerId FOREIGN KEY (UpdatePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

--Pr_PetitionsPacks
ALTER TABLE dbo.Pr_PetitionsPacks
ADD CONSTRAINT FK_Pr_PetitionsPacks_CratePerformerId FOREIGN KEY (CratePerformerId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_PetitionsPacks
ADD CONSTRAINT FK_Pr_PetitionsPacks_Pr_EnergyTypeId FOREIGN KEY (Pr_EnergyTypeId) REFERENCES dbo.Pr_EnergyTypes (EnergyTypeId)
GO

-- Pr_Points
ALTER TABLE dbo.Pr_Points
ADD CONSTRAINT FK_Pr_Points_AbonentId FOREIGN KEY (AbonentId) REFERENCES dbo.Pr_Abonents (AbonentId)
GO

ALTER TABLE dbo.Pr_Points
ADD CONSTRAINT FK_Pr_Points_TSOId FOREIGN KEY (TSOId) REFERENCES dbo.Pr_TSO (TSOId)
GO

-- Rms_AuditTasks
ALTER TABLE dbo.Rms_AuditTasks
ADD CONSTRAINT FK_Rms_AuditTasks_Rms_TaskList FOREIGN KEY (TaskId) REFERENCES dbo.Rms_TaskList (TaskId)
GO

ALTER TABLE dbo.Rms_AuditTasks
ADD CONSTRAINT FK_Rms_AuditTasks_Rms_TaskStatus FOREIGN KEY (TaskStatusId) REFERENCES dbo.Rms_TaskStatus (TaskStatusId)
GO

-- Rms_TaskList
ALTER TABLE dbo.Rms_TaskList
ADD CONSTRAINT FK_Rms_TaskList_Rms_TaskList FOREIGN KEY (TaskId) REFERENCES dbo.Rms_TaskList (TaskId)
GO

-- 201801
-- Pr_PointsPublicSections
ALTER TABLE dbo.Pr_PointsPublicSections
ADD CONSTRAINT FK_Pr_PointsPublicSections_SchemesId FOREIGN KEY (SchemesId) REFERENCES dbo.Pr_PointsPublicSectionsSchemes (SchemesId)
GO

ALTER TABLE dbo.Pr_PointsPublicSections
ADD CONSTRAINT FK_Pr_PointsPublicSictions_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_PointsPublicSections
ADD CONSTRAINT FK_Pr_PointsPublicSictions_PublicPointId FOREIGN KEY (PublicPointId) REFERENCES dbo.PointsPublicAccount (PublicPointId)
GO

-- Pr_PointsPublicSectionsConn
ALTER TABLE dbo.Pr_PointsPublicSectionsConn
ADD CONSTRAINT FK_Pr_PointsPublicSectionsConn_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_PointsPublicSectionsConn
ADD CONSTRAINT FK_Pr_PointsPublicSectionsConn_PointId FOREIGN KEY (PointId) REFERENCES dbo.Pr_Points (PointId)
GO

ALTER TABLE dbo.Pr_PointsPublicSectionsConn
ADD CONSTRAINT FK_Pr_PointsPublicSectionsConn_SectionId FOREIGN KEY (SectionId) REFERENCES dbo.Pr_PointsPublicSections (SectionId)
GO

-- Pr_CountersSectionHistory
/*
ALTER TABLE dbo.Pr_CountersSectionHistory
ADD CONSTRAINT FK_Pr_CountersSectionHistory_CounterTypeId FOREIGN KEY (CounterTypeId) REFERENCES dbo.CounterTypes (CounterTypeId)
GO
*/
ALTER TABLE dbo.Pr_CountersSectionHistory
ADD CONSTRAINT FK_Pr_CountersSectionHistory_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO

ALTER TABLE dbo.Pr_CountersSectionHistory
ADD CONSTRAINT FK_Pr_CountersSectionHistory_SectionId FOREIGN KEY (SectionId) REFERENCES dbo.Pr_PointsPublicSections (SectionId)
GO

ALTER TABLE dbo.Pr_CountersSectionHistory
ADD CONSTRAINT FK_Pr_CountersSectionHistory_UpdaterId FOREIGN KEY (UpdaterId) REFERENCES dbo.Performers (PerformerId)
GO

-- Pr_PointsPublicSectionsCharges
ALTER TABLE dbo.Pr_PointsPublicSectionsCharges
ADD CONSTRAINT FK_Pr_PointsPublicSectionsCharges_CreaterId FOREIGN KEY (CreaterId) REFERENCES dbo.Performers (PerformerId)
GO
/*
ALTER TABLE dbo.Pr_PointsPublicSectionsCharges
ADD CONSTRAINT FK_Pr_PointsPublicSectionsCharges_PeriodNumber FOREIGN KEY (PeriodNumber) REFERENCES dbo.AccountingPeriods (PeriodNumber)
GO
*/
ALTER TABLE dbo.Pr_PointsPublicSectionsCharges
ADD CONSTRAINT FK_Pr_PointsPublicSectionsCharges_SectionId FOREIGN KEY (SectionId) REFERENCES dbo.Pr_PointsPublicSections (SectionId)
GO
/*
ALTER TABLE dbo.Pr_PointsPublicSectionsCharges
ADD CONSTRAINT FK_Pr_PointsPublicSectionsCharges_SourceId FOREIGN KEY (SourceId) REFERENCES dbo.PointsPublicIndicationsSource (SourceId)
GO
*/
ALTER TABLE dbo.Pr_PointsPublicSectionsCharges
ADD CONSTRAINT FK_Pr_PointsPublicSectionsCharges_UpdaterId FOREIGN KEY (UpdaterId) REFERENCES dbo.Performers (PerformerId)
GO



















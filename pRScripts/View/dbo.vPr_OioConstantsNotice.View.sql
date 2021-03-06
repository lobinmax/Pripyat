IF EXISTS (SELECT name FROM sysobjects WHERE  name = N'vPr_OioConstantsNotice' AND type = 'V')
    DROP VIEW vPr_OioConstantsNotice
GO

CREATE VIEW dbo.vPr_OioConstantsNotice 
AS SELECT        ((SELECT        LTRIM(RTRIM(Value)) AS v
                            FROM            dbo.Constants AS c1
                            WHERE        (Name = 'BankOrganization')) + ' ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c2
                               WHERE        (Name = 'BankName'))) + (CHAR(10) + 'р/с ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c3
                               WHERE        (Name = 'BankCalcAccount'))) + 'к/с ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c4
                               WHERE        (Name = 'BankCorrAccount')) + ' ' + 'БИК ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c5
                               WHERE        (Name = 'BankBIK')) + ' ' + 'ИНН ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c6
                               WHERE        (Name = 'BankINN')) AS Requisitions, 'тел. ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c7
                               WHERE        (Name = 'OrganizationPhone')) AS OrganizationPhone,
                             (SELECT        ISNULL(RTRIM(Value), '') AS v
                               FROM            dbo.Constants AS c8
                               WHERE        (Name = 'NameRuleManager')) AS NameRuleManager,
                             (SELECT        ISNULL(RTRIM(Value), '') AS v
                               FROM            dbo.Constants AS c9
                               WHERE        (Name = 'NameRuleManagerReason')) AS NameRuleManagerReason,
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c10
                               WHERE        (Name = 'Manager')) AS Manager,
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c11
                               WHERE        (Name = 'OrganizationAddress')) + ' ' + 'тел. ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c12
                               WHERE        (Name = 'OrganizationPhone')) AS DivisionAddress, 'Представитель ' +
                             (SELECT        LTRIM(RTRIM(Value)) AS v
                               FROM            dbo.Constants AS c13
                               WHERE        (Name = 'NameOrganisation')) AS PerformerOrganisation
GO

GRANT SELECT ON vPr_OioConstantsNotice TO KvzWorker
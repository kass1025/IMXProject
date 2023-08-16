IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [MiddleName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [DisasterOnDuts] (
        [Id] int NOT NULL IDENTITY,
        [DisasterName] nvarchar(100) NOT NULL,
        [DateHapped] datetime2 NOT NULL,
        [DisasterTypeId] int NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_DisasterOnDuts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [DisasterTypes] (
        [Id] int NOT NULL IDENTITY,
        [DisasterTypeName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_DisasterTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [EducationLevels] (
        [Id] int NOT NULL IDENTITY,
        [LevelName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_EducationLevels] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [EducationTypes] (
        [Id] int NOT NULL IDENTITY,
        [TypeName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_EducationTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [Genders] (
        [Id] int NOT NULL IDENTITY,
        [GenderName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Genders] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [Members] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(100) NOT NULL,
        [MiddleName] nvarchar(100) NOT NULL,
        [LastName] nvarchar(100) NOT NULL,
        [IsDisable] bit NOT NULL,
        [Role] nvarchar(max) NULL,
        [DateOfJoing] datetime2 NOT NULL,
        [BirthDate] datetime2 NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Members] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [MemberTypes] (
        [Id] int NOT NULL IDENTITY,
        [TypeName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_MemberTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [Regions] (
        [Id] int NOT NULL IDENTITY,
        [RegionName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        [RegionCode] int NOT NULL,
        CONSTRAINT [PK_Regions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [Titles] (
        [Id] int NOT NULL IDENTITY,
        [TitleName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Titles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [DisasterMembers] (
        [Id] int NOT NULL IDENTITY,
        [DisasterTypeId] int NOT NULL,
        [DisasterOnDutyId] int NOT NULL,
        [MemberId] int NOT NULL,
        [DateHapped] datetime2 NOT NULL,
        [Discription] nvarchar(max) NULL,
        CONSTRAINT [PK_DisasterMembers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DisasterMembers_DisasterOnDuts_DisasterOnDutyId] FOREIGN KEY ([DisasterOnDutyId]) REFERENCES [DisasterOnDuts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DisasterMembers_DisasterTypes_DisasterTypeId] FOREIGN KEY ([DisasterTypeId]) REFERENCES [DisasterTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DisasterMembers_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [EducationInformation] (
        [Id] int NOT NULL IDENTITY,
        [InstitutionName] nvarchar(200) NOT NULL,
        [EducationTypeId] int NOT NULL,
        [EducationLevelId] int NOT NULL,
        [MemberId] int NOT NULL,
        [Certificate] nvarchar(max) NULL,
        CONSTRAINT [PK_EducationInformation] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EducationInformation_EducationLevels_EducationLevelId] FOREIGN KEY ([EducationLevelId]) REFERENCES [EducationLevels] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_EducationInformation_EducationTypes_EducationTypeId] FOREIGN KEY ([EducationTypeId]) REFERENCES [EducationTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_EducationInformation_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [Zones] (
        [Id] int NOT NULL IDENTITY,
        [ZoneName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        [ZoneCode] int NOT NULL,
        [RegionId] int NOT NULL,
        CONSTRAINT [PK_Zones] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Zones_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [Woredas] (
        [Id] int NOT NULL IDENTITY,
        [WoredaName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        [WoredaCode] int NOT NULL,
        [ZoneId] int NOT NULL,
        CONSTRAINT [PK_Woredas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Woredas_Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [Zones] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE TABLE [Cities] (
        [Id] int NOT NULL IDENTITY,
        [CityName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        [CityCode] int NOT NULL,
        [ZoneId] int NULL,
        [WoredaId] int NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Cities_Woredas_WoredaId] FOREIGN KEY ([WoredaId]) REFERENCES [Woredas] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Cities_Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [Zones] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_Cities_WoredaId] ON [Cities] ([WoredaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_Cities_ZoneId] ON [Cities] ([ZoneId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_DisasterMembers_DisasterOnDutyId] ON [DisasterMembers] ([DisasterOnDutyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_DisasterMembers_DisasterTypeId] ON [DisasterMembers] ([DisasterTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_DisasterMembers_MemberId] ON [DisasterMembers] ([MemberId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_EducationInformation_EducationLevelId] ON [EducationInformation] ([EducationLevelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_EducationInformation_EducationTypeId] ON [EducationInformation] ([EducationTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_EducationInformation_MemberId] ON [EducationInformation] ([MemberId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_Woredas_ZoneId] ON [Woredas] ([ZoneId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    CREATE INDEX [IX_Zones_RegionId] ON [Zones] ([RegionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317210641_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220317210641_initial', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211355_memberAddressInfo_Table_added')
BEGIN
    CREATE TABLE [MemberAddressInfos] (
        [Id] int NOT NULL IDENTITY,
        [MemberAddress] nvarchar(200) NOT NULL,
        [RegionId] int NOT NULL,
        [ZoneId] int NOT NULL,
        [WoredaId] int NOT NULL,
        [CityId] int NOT NULL,
        [MemberId] int NOT NULL,
        [KebeleName] nvarchar(max) NULL,
        CONSTRAINT [PK_MemberAddressInfos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MemberAddressInfos_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]),
        CONSTRAINT [FK_MemberAddressInfos_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]),
        CONSTRAINT [FK_MemberAddressInfos_Woredas_WoredaId] FOREIGN KEY ([WoredaId]) REFERENCES [Woredas] ([Id]),
        CONSTRAINT [FK_MemberAddressInfos_Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [Zones] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211355_memberAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_MemberAddressInfos_MemberId] ON [MemberAddressInfos] ([MemberId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211355_memberAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_MemberAddressInfos_RegionId] ON [MemberAddressInfos] ([RegionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211355_memberAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_MemberAddressInfos_WoredaId] ON [MemberAddressInfos] ([WoredaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211355_memberAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_MemberAddressInfos_ZoneId] ON [MemberAddressInfos] ([ZoneId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211355_memberAddressInfo_Table_added')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220317211355_memberAddressInfo_Table_added', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211902_member_Table_updated')
BEGIN
    ALTER TABLE [Members] ADD [GenderId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211902_member_Table_updated')
BEGIN
    ALTER TABLE [Members] ADD [TitleId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211902_member_Table_updated')
BEGIN
    CREATE INDEX [IX_Members_GenderId] ON [Members] ([GenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211902_member_Table_updated')
BEGIN
    CREATE INDEX [IX_Members_TitleId] ON [Members] ([TitleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211902_member_Table_updated')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211902_member_Table_updated')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Titles_TitleId] FOREIGN KEY ([TitleId]) REFERENCES [Titles] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317211902_member_Table_updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220317211902_member_Table_updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    ALTER TABLE [Members] ADD [MemberTypeId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE TABLE [Enterprises] (
        [Id] int NOT NULL IDENTITY,
        [EnterpriseName] nvarchar(100) NOT NULL,
        [TINNumber] nvarchar(max) NULL,
        [InitialCapital] decimal(18,2) NOT NULL,
        [CurrentCapital] decimal(18,2) NULL,
        [FoundedYear] int NOT NULL,
        CONSTRAINT [PK_Enterprises] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE TABLE [EnterpriseAddressInfos] (
        [Id] int NOT NULL IDENTITY,
        [EnterpriseAddress] nvarchar(200) NOT NULL,
        [RegionId] int NOT NULL,
        [ZoneId] int NOT NULL,
        [WoredaId] int NOT NULL,
        [CityId] int NOT NULL,
        [EnterpriseId] int NOT NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [HouseNumber] nvarchar(max) NULL,
        [KebeleName] nvarchar(max) NULL,
        CONSTRAINT [PK_EnterpriseAddressInfos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EnterpriseAddressInfos_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]),
        CONSTRAINT [FK_EnterpriseAddressInfos_Enterprises_EnterpriseId] FOREIGN KEY ([EnterpriseId]) REFERENCES [Enterprises] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_EnterpriseAddressInfos_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]),
        CONSTRAINT [FK_EnterpriseAddressInfos_Woredas_WoredaId] FOREIGN KEY ([WoredaId]) REFERENCES [Woredas] ([Id]),
        CONSTRAINT [FK_EnterpriseAddressInfos_Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [Zones] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_Members_MemberTypeId] ON [Members] ([MemberTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_MemberAddressInfos_CityId] ON [MemberAddressInfos] ([CityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_EnterpriseAddressInfos_CityId] ON [EnterpriseAddressInfos] ([CityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_EnterpriseAddressInfos_EnterpriseId] ON [EnterpriseAddressInfos] ([EnterpriseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_EnterpriseAddressInfos_RegionId] ON [EnterpriseAddressInfos] ([RegionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_EnterpriseAddressInfos_WoredaId] ON [EnterpriseAddressInfos] ([WoredaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    CREATE INDEX [IX_EnterpriseAddressInfos_ZoneId] ON [EnterpriseAddressInfos] ([ZoneId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    ALTER TABLE [MemberAddressInfos] ADD CONSTRAINT [FK_MemberAddressInfos_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_MemberTypes_MemberTypeId] FOREIGN KEY ([MemberTypeId]) REFERENCES [MemberTypes] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220317214343_EnterpriseandEnterpriseAddressInfo_Table_added', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317214702_memberType_Table_updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220317214702_memberType_Table_updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD [BranchItemId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD [CapitalSourceId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD [EnterpriseLevelId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD [EnterpriseStatusId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD [GroupTypeId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD [PromotionLevelId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE TABLE [Branches] (
        [Id] int NOT NULL IDENTITY,
        [BranchName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Branches] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE TABLE [CapitalSources] (
        [Id] int NOT NULL IDENTITY,
        [CapitalSourceName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_CapitalSources] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE TABLE [EnterpriseLevels] (
        [Id] int NOT NULL IDENTITY,
        [EnterpriseLevelName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_EnterpriseLevels] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE TABLE [EnterpriseStatuses] (
        [Id] int NOT NULL IDENTITY,
        [EnterpriseStatusName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_EnterpriseStatuses] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE TABLE [GroupTypes] (
        [Id] int NOT NULL IDENTITY,
        [GroupTypeName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_GroupTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE TABLE [PromotionLevels] (
        [Id] int NOT NULL IDENTITY,
        [PromotionLeveName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_PromotionLevels] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE TABLE [BranchItems] (
        [Id] int NOT NULL IDENTITY,
        [BranchItemName] nvarchar(100) NOT NULL,
        [BranchId] int NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_BranchItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BranchItems_Branches_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branches] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE INDEX [IX_Enterprises_BranchItemId] ON [Enterprises] ([BranchItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE INDEX [IX_Enterprises_CapitalSourceId] ON [Enterprises] ([CapitalSourceId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE INDEX [IX_Enterprises_EnterpriseLevelId] ON [Enterprises] ([EnterpriseLevelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE INDEX [IX_Enterprises_EnterpriseStatusId] ON [Enterprises] ([EnterpriseStatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE INDEX [IX_Enterprises_GroupTypeId] ON [Enterprises] ([GroupTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE INDEX [IX_Enterprises_PromotionLevelId] ON [Enterprises] ([PromotionLevelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    CREATE INDEX [IX_BranchItems_BranchId] ON [BranchItems] ([BranchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_BranchItems_BranchItemId] FOREIGN KEY ([BranchItemId]) REFERENCES [BranchItems] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_CapitalSources_CapitalSourceId] FOREIGN KEY ([CapitalSourceId]) REFERENCES [CapitalSources] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_EnterpriseLevels_EnterpriseLevelId] FOREIGN KEY ([EnterpriseLevelId]) REFERENCES [EnterpriseLevels] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_EnterpriseStatuses_EnterpriseStatusId] FOREIGN KEY ([EnterpriseStatusId]) REFERENCES [EnterpriseStatuses] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_GroupTypes_GroupTypeId] FOREIGN KEY ([GroupTypeId]) REFERENCES [GroupTypes] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_PromotionLevels_PromotionLevelId] FOREIGN KEY ([PromotionLevelId]) REFERENCES [PromotionLevels] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220317222928_Seven_Tables_added')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220317222928_Seven_Tables_added', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220318065812_disability_Table_Added')
BEGIN
    DROP TABLE [DisasterMembers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220318065812_disability_Table_Added')
BEGIN
    DROP TABLE [DisasterOnDuts];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220318065812_disability_Table_Added')
BEGIN
    DROP TABLE [DisasterTypes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220318065812_disability_Table_Added')
BEGIN
    ALTER TABLE [Members] ADD [DisabilityId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220318065812_disability_Table_Added')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220318065812_disability_Table_Added', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220319055859_disability_updated')
BEGIN
    CREATE TABLE [Disabilities] (
        [Id] int NOT NULL IDENTITY,
        [DisabilityName] nvarchar(100) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Disabilities] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220319055859_disability_updated')
BEGIN
    CREATE INDEX [IX_Members_DisabilityId] ON [Members] ([DisabilityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220319055859_disability_updated')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Disabilities_DisabilityId] FOREIGN KEY ([DisabilityId]) REFERENCES [Disabilities] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220319055859_disability_updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220319055859_disability_updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320153004_member_table-updated')
BEGIN
    ALTER TABLE [Members] ADD [EnterpriseId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320153004_member_table-updated')
BEGIN
    CREATE INDEX [IX_Members_EnterpriseId] ON [Members] ([EnterpriseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320153004_member_table-updated')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Enterprises_EnterpriseId] FOREIGN KEY ([EnterpriseId]) REFERENCES [Enterprises] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320153004_member_table-updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220320153004_member_table-updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320163910_member_table-updated2')
BEGIN
    ALTER TABLE [Members] DROP CONSTRAINT [FK_Members_Disabilities_DisabilityId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320163910_member_table-updated2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Members]') AND [c].[name] = N'DisabilityId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Members] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Members] ALTER COLUMN [DisabilityId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320163910_member_table-updated2')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Disabilities_DisabilityId] FOREIGN KEY ([DisabilityId]) REFERENCES [Disabilities] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220320163910_member_table-updated2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220320163910_member_table-updated2', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322190654_UserLocation_Table_Added')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LocationId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322190654_UserLocation_Table_Added')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LocationName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322190654_UserLocation_Table_Added')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [RoleName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322190654_UserLocation_Table_Added')
BEGIN
    CREATE TABLE [UserLocations] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NULL,
        [RegionId] int NOT NULL,
        CONSTRAINT [PK_UserLocations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserLocations_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserLocations_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322190654_UserLocation_Table_Added')
BEGIN
    CREATE INDEX [IX_UserLocations_RegionId] ON [UserLocations] ([RegionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322190654_UserLocation_Table_Added')
BEGIN
    CREATE INDEX [IX_UserLocations_UserId] ON [UserLocations] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220322190654_UserLocation_Table_Added')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220322190654_UserLocation_Table_Added', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323012707_applicationUserZonePrivilage_table_Updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323012707_applicationUserZonePrivilage_table_Updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323013025_applicationUserZonePrivilage_table_Updateds')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323013025_applicationUserZonePrivilage_table_Updateds', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    ALTER TABLE [UserLocations] DROP CONSTRAINT [FK_UserLocations_Regions_RegionId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    DROP INDEX [IX_UserLocations_RegionId] ON [UserLocations];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserLocations]') AND [c].[name] = N'RegionId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [UserLocations] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [UserLocations] DROP COLUMN [RegionId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    ALTER TABLE [UserLocations] ADD [UserLocationId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    CREATE INDEX [IX_UserLocations_UserLocationId] ON [UserLocations] ([UserLocationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    ALTER TABLE [UserLocations] ADD CONSTRAINT [FK_UserLocations_Regions_UserLocationId] FOREIGN KEY ([UserLocationId]) REFERENCES [Regions] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    ALTER TABLE [UserLocations] ADD CONSTRAINT [FK_UserLocations_Zones_UserLocationId] FOREIGN KEY ([UserLocationId]) REFERENCES [Zones] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014358_applicationUser_table_Updated2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323014358_applicationUser_table_Updated2', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014627_applicationUser_table_Updated3')
BEGIN
    ALTER TABLE [UserLocations] ADD CONSTRAINT [FK_UserLocations_Cities_UserLocationId] FOREIGN KEY ([UserLocationId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014627_applicationUser_table_Updated3')
BEGIN
    ALTER TABLE [UserLocations] ADD CONSTRAINT [FK_UserLocations_Woredas_UserLocationId] FOREIGN KEY ([UserLocationId]) REFERENCES [Woredas] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323014627_applicationUser_table_Updated3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323014627_applicationUser_table_Updated3', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_Enterprise_table_Updated')
BEGIN
    ALTER TABLE [UserLocations] ADD [EnterpriseId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_Enterprise_table_Updated')
BEGIN
    CREATE INDEX [IX_UserLocations_EnterpriseId] ON [UserLocations] ([EnterpriseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_Enterprise_table_Updated')
BEGIN
    ALTER TABLE [UserLocations] ADD CONSTRAINT [FK_UserLocations_Enterprises_EnterpriseId] FOREIGN KEY ([EnterpriseId]) REFERENCES [Enterprises] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_Enterprise_table_Updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323033445_Enterprise_table_Updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033645_Enterprise_table_Updated3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323033645_Enterprise_table_Updated3', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323034631_Enterprise_table_Updated2')
BEGIN
    ALTER TABLE [UserLocations] DROP CONSTRAINT [FK_UserLocations_Enterprises_EnterpriseId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323034631_Enterprise_table_Updated2')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserLocations]') AND [c].[name] = N'EnterpriseId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [UserLocations] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [UserLocations] ALTER COLUMN [EnterpriseId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323034631_Enterprise_table_Updated2')
BEGIN
    ALTER TABLE [Enterprises] ADD [UserLocationId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323034631_Enterprise_table_Updated2')
BEGIN
    CREATE INDEX [IX_Enterprises_UserLocationId] ON [Enterprises] ([UserLocationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323034631_Enterprise_table_Updated2')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_UserLocations_UserLocationId] FOREIGN KEY ([UserLocationId]) REFERENCES [UserLocations] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323034631_Enterprise_table_Updated2')
BEGIN
    ALTER TABLE [UserLocations] ADD CONSTRAINT [FK_UserLocations_UserLocations_EnterpriseId] FOREIGN KEY ([EnterpriseId]) REFERENCES [UserLocations] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323034631_Enterprise_table_Updated2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323034631_Enterprise_table_Updated2', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323041806_Enterprise_table_Updated1')
BEGIN
    ALTER TABLE [UserLocations] DROP CONSTRAINT [FK_UserLocations_UserLocations_EnterpriseId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323041806_Enterprise_table_Updated1')
BEGIN
    DROP INDEX [IX_UserLocations_EnterpriseId] ON [UserLocations];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323041806_Enterprise_table_Updated1')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserLocations]') AND [c].[name] = N'EnterpriseId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [UserLocations] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [UserLocations] DROP COLUMN [EnterpriseId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323041806_Enterprise_table_Updated1')
BEGIN
    ALTER TABLE [UserLocations] ADD CONSTRAINT [FK_UserLocations_UserLocations_UserLocationId] FOREIGN KEY ([UserLocationId]) REFERENCES [UserLocations] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323041806_Enterprise_table_Updated1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323041806_Enterprise_table_Updated1', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042420_Enterprise_table_Updated12')
BEGIN
    ALTER TABLE [UserLocations] DROP CONSTRAINT [FK_UserLocations_UserLocations_UserLocationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042420_Enterprise_table_Updated12')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323042420_Enterprise_table_Updated12', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042919_Enterprise_table_Updated123')
BEGIN
    ALTER TABLE [Enterprises] DROP CONSTRAINT [FK_Enterprises_UserLocations_UserLocationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042919_Enterprise_table_Updated123')
BEGIN
    DROP INDEX [IX_Enterprises_UserLocationId] ON [Enterprises];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042919_Enterprise_table_Updated123')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enterprises]') AND [c].[name] = N'UserLocationId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Enterprises] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Enterprises] DROP COLUMN [UserLocationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042919_Enterprise_table_Updated123')
BEGIN
    ALTER TABLE [Enterprises] ADD [EnterUserLocationId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042919_Enterprise_table_Updated123')
BEGIN
    CREATE INDEX [IX_Enterprises_EnterUserLocationId] ON [Enterprises] ([EnterUserLocationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042919_Enterprise_table_Updated123')
BEGIN
    ALTER TABLE [Enterprises] ADD CONSTRAINT [FK_Enterprises_UserLocations_EnterUserLocationId] FOREIGN KEY ([EnterUserLocationId]) REFERENCES [UserLocations] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323042919_Enterprise_table_Updated123')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323042919_Enterprise_table_Updated123', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323151522_userLocation_table_Updated')
BEGIN
    ALTER TABLE [UserLocations] ADD [LocationCode] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323151522_userLocation_table_Updated')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LocationCode] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323151522_userLocation_table_Updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323151522_userLocation_table_Updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323195848_userLocation-updated')
BEGIN
    ALTER TABLE [UserLocations] DROP CONSTRAINT [FK_UserLocations_Regions_UserLocationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323195848_userLocation-updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323195848_userLocation-updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323222049_ApplicationUser-updated')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ParentId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323222049_ApplicationUser-updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323222049_ApplicationUser-updated', N'3.1.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220325053617_FieldAdded_IN_MemberTable')
BEGIN
    ALTER TABLE [Members] ADD [IsFounder] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220325053617_FieldAdded_IN_MemberTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220325053617_FieldAdded_IN_MemberTable', N'3.1.0');
END;

GO


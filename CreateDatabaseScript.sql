IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Team] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(450) NULL,
    [CreatedTimestamp] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_Team] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ActualResult] (
    [Id] int NOT NULL IDENTITY,
    [TeamId] int NOT NULL,
    [Wins] int NOT NULL,
    [Equality] int NOT NULL,
    [Losses] int NOT NULL,
    [UpdatedTimestamp] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
    [CreatedTimestamp] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_ActualResult] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ActualResult_Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Team] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Match] (
    [Id] int NOT NULL IDENTITY,
    [HostId] int NOT NULL,
    [VisitorId] int NOT NULL,
    [TeamHostResult] int NOT NULL,
    [TeamVisitorResult] int NOT NULL,
    [CreatedTimestamp] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_Match] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Match_Team_HostId] FOREIGN KEY ([HostId]) REFERENCES [Team] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Match_Team_VisitorId] FOREIGN KEY ([VisitorId]) REFERENCES [Team] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_ActualResult_TeamId] ON [ActualResult] ([TeamId]);
GO

CREATE INDEX [IX_Match_HostId] ON [Match] ([HostId]);
GO

CREATE INDEX [IX_Match_VisitorId] ON [Match] ([VisitorId]);
GO

CREATE UNIQUE INDEX [IX_Team_Name] ON [Team] ([Name]) WHERE [Name] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220629112912_CreateDatabase', N'5.0.17');
GO

COMMIT;
GO


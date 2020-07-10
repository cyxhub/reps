IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [leagues] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [country] nvarchar(max) NULL,
    CONSTRAINT [PK_leagues] PRIMARY KEY ([id])
);

GO

CREATE TABLE [clubs] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [leagueid] int NULL,
    CONSTRAINT [PK_clubs] PRIMARY KEY ([id]),
    CONSTRAINT [FK_clubs_leagues_leagueid] FOREIGN KEY ([leagueid]) REFERENCES [leagues] ([id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [players] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    [birthDay] datetime2 NOT NULL,
    [Clubid] int NULL,
    CONSTRAINT [PK_players] PRIMARY KEY ([id]),
    CONSTRAINT [FK_players_clubs_Clubid] FOREIGN KEY ([Clubid]) REFERENCES [clubs] ([id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_clubs_leagueid] ON [clubs] ([leagueid]);

GO

CREATE INDEX [IX_players_Clubid] ON [players] ([Clubid]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200710015217_initdata', N'3.1.5');

GO


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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250218034122_init'
)
BEGIN
    CREATE TABLE [Role] (
        [Id] uniqueidentifier NOT NULL,
        [RoleName] nvarchar(max) NOT NULL,
        [CreateNy] uniqueidentifier NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [UpdateBy] uniqueidentifier NOT NULL,
        [UpdateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250218034122_init'
)
BEGIN
    CREATE TABLE [User] (
        [Id] uniqueidentifier NOT NULL,
        [FullName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [DateOfBirth] date NOT NULL,
        [CreateNy] uniqueidentifier NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [UpdateBy] uniqueidentifier NOT NULL,
        [UpdateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250218034122_init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250218034122_init', N'8.0.13');
END;
GO

COMMIT;
GO


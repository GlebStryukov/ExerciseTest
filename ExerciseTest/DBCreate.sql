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

CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NULL,
    [DoB] date NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Edition] nvarchar(max) NULL,
    [Publeshid_At] date NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [BooksAuthors] (
    [Id] int NOT NULL IDENTITY,
    [BookId] int NOT NULL,
    [AuthorId] int NOT NULL,
    CONSTRAINT [PK_BooksAuthors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BooksAuthors_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BooksAuthors_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BooksAuthors_AuthorId] ON [BooksAuthors] ([AuthorId]);
GO

CREATE INDEX [IX_BooksAuthors_BookId] ON [BooksAuthors] ([BookId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210320110301_BooksAuthor', N'5.0.4');
GO

COMMIT;
GO


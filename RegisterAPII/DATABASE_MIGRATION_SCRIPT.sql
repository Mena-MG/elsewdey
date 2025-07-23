-- Migration Script for School Management System
-- Run this script to add the new tables for Notes, Reports, and Notifications

-- Create Notes table
CREATE TABLE [Notes] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NOT NULL,
    [StudentProfileId] int NOT NULL,
    [CreatedByAccountId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Notes_StudentProfiles_StudentProfileId] FOREIGN KEY ([StudentProfileId]) REFERENCES [StudentProfiles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Notes_Accounts_CreatedByAccountId] FOREIGN KEY ([CreatedByAccountId]) REFERENCES [Accounts] ([Id]) ON DELETE NO ACTION
);

-- Create Notifications table
CREATE TABLE [Notifications] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Message] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NULL,
    [FromAccountId] int NOT NULL,
    [ToAccountId] int NOT NULL,
    [RelatedEntityId] int NULL,
    [RelatedEntityType] nvarchar(max) NULL,
    [IsRead] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ReadAt] datetime2 NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Notifications_Accounts_FromAccountId] FOREIGN KEY ([FromAccountId]) REFERENCES [Accounts] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Notifications_Accounts_ToAccountId] FOREIGN KEY ([ToAccountId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE
);

-- Create Reports table
CREATE TABLE [Reports] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NULL,
    [StudentProfileId] int NOT NULL,
    [CreatedByAccountId] int NOT NULL,
    [ReviewedByAccountId] int NULL,
    [Status] nvarchar(max) NOT NULL,
    [AdminComments] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ReviewedAt] datetime2 NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Reports] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reports_StudentProfiles_StudentProfileId] FOREIGN KEY ([StudentProfileId]) REFERENCES [StudentProfiles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reports_Accounts_CreatedByAccountId] FOREIGN KEY ([CreatedByAccountId]) REFERENCES [Accounts] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reports_Accounts_ReviewedByAccountId] FOREIGN KEY ([ReviewedByAccountId]) REFERENCES [Accounts] ([Id]) ON DELETE SET NULL
);

-- Create indexes for better performance
CREATE NONCLUSTERED INDEX [IX_Notes_StudentProfileId] ON [Notes] ([StudentProfileId]);
CREATE NONCLUSTERED INDEX [IX_Notes_CreatedByAccountId] ON [Notes] ([CreatedByAccountId]);
CREATE NONCLUSTERED INDEX [IX_Notes_Type] ON [Notes] ([Type]);
CREATE NONCLUSTERED INDEX [IX_Notes_CreatedAt] ON [Notes] ([CreatedAt]);

CREATE NONCLUSTERED INDEX [IX_Notifications_FromAccountId] ON [Notifications] ([FromAccountId]);
CREATE NONCLUSTERED INDEX [IX_Notifications_ToAccountId] ON [Notifications] ([ToAccountId]);
CREATE NONCLUSTERED INDEX [IX_Notifications_IsRead] ON [Notifications] ([IsRead]);
CREATE NONCLUSTERED INDEX [IX_Notifications_CreatedAt] ON [Notifications] ([CreatedAt]);

CREATE NONCLUSTERED INDEX [IX_Reports_StudentProfileId] ON [Reports] ([StudentProfileId]);
CREATE NONCLUSTERED INDEX [IX_Reports_CreatedByAccountId] ON [Reports] ([CreatedByAccountId]);
CREATE NONCLUSTERED INDEX [IX_Reports_ReviewedByAccountId] ON [Reports] ([ReviewedByAccountId]);
CREATE NONCLUSTERED INDEX [IX_Reports_Status] ON [Reports] ([Status]);
CREATE NONCLUSTERED INDEX [IX_Reports_CreatedAt] ON [Reports] ([CreatedAt]);
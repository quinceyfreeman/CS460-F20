CREATE TABLE [Assignment] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [ClassID] int NOT NULL,
  [Priority] int NOT NULL,
  [DueDate] datetime NOT NULL,
  [Title] nvarchar(50) NOT NULL,
  [Notes] nvarchar(512),
  [isComplete] BIT DEFAULT 'FALSE' NOT NULL
)
GO

CREATE TABLE [AssignmentTags] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [AssignmentID] int,
  [TagID] int
)
GO

CREATE TABLE [Tags] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50)
)
GO

CREATE TABLE [Class] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50)
)
GO

ALTER TABLE [Assignment] ADD CONSTRAINT [Assignment_FK_Class] FOREIGN KEY ([ClassID]) REFERENCES [Class] ([ID])
GO

ALTER TABLE [AssignmentTags] ADD CONSTRAINT [AssignmentTags_FK_Assignment] FOREIGN KEY ([AssignmentID]) REFERENCES [Assignment] ([ID])
GO

ALTER TABLE [AssignmentTags] ADD CONSTRAINT [AssignmentTags_FK_Tags] FOREIGN KEY ([TagID]) REFERENCES [Tags] ([ID])
GO
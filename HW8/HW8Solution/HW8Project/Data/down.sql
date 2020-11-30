ALTER TABLE [AssignmentTags] DROP CONSTRAINT [AssignmentTags_FK_Tags]
ALTER TABLE [AssignmentTags] DROP CONSTRAINT [AssignmentTags_FK_Assignment]
ALTER TABLE [Assignment] DROP CONSTRAINT [Assignment_FK_Class]
GO

DROP TABLE [Assignment]
DROP TABLE [Class]
DROP TABLE [Tags]
DROP TABLE [AssignmentTags]
GO
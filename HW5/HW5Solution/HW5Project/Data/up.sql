CREATE TABLE Assignments
(
    ID                  INTEGER                 NOT NULL PRIMARY KEY AUTOINCREMENT,
    Priority            INTEGER                 NOT NULL,
    DueDate             DATETIME                NOT NULL,
    Course              NVARCHAR(10)            NOT NULL,
    Title               NVARCHAR(64)            NOT NULL,
    Notes               NVARCHAR(512)
);
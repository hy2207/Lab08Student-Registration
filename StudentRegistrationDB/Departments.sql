CREATE TABLE [Departments] (
    [DepartmentId]   INT IDENTITY (1, 1) NOT NULL,
    [DepartmentCode] NVARCHAR (10) NOT NULL UNIQUE,
    [DepartmentName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);


GO
--CREATE UNIQUE NONCLUSTERED INDEX [IX_DepartmentCode]
--    ON [Departments]([DepartmentCode] ASC);


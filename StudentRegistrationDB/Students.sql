CREATE TABLE [dbo].[Students] (
    [StudentId]        INT           IDENTITY (1, 1) NOT NULL,
    [StudentFirstName] NVARCHAR (50) NOT NULL,
    [StudentLastName]  NVARCHAR (50) NOT NULL,
    [DepartmentId]     INT           NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([StudentId] ASC),
    CONSTRAINT [FK_Students_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([DepartmentId])
);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentId]
    ON [dbo].[Students]([DepartmentId] ASC);


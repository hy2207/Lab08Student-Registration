CREATE TABLE [Courses] (
    [CourseId]     INT           IDENTITY (1, 1) NOT NULL,
    [CourseNumber] INT           NOT NULL,
    [DepartmentId] INT           NOT NULL,
    [CourseName]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED ([CourseId] ASC),
    CONSTRAINT [UN_Courses] UNIQUE ([CourseNumber], [DepartmentId]),
    CONSTRAINT [FK_Courses_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([DepartmentId]) ON DELETE CASCADE
);


GO



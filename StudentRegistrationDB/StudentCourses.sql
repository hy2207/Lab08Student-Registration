CREATE TABLE [StudentCourses] (
    [CourseId]  INT NOT NULL,
    [StudentId] INT NOT NULL,
    CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED ([CourseId] ASC, [StudentId] ASC),
    CONSTRAINT [FK_StudentCourses_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentCourses_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([StudentId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CourseId]
    ON [StudentCourses]([CourseId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StudentId]
    ON [StudentCourses]([StudentId] ASC);


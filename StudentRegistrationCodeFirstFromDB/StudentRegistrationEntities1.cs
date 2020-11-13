namespace StudentRegistrationCodeFirstFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentRegistrationEntities : DbContext
    {
        public StudentRegistrationEntities()
            : base("name=StudentRegistrationDBConnection")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("StudentCourses").MapLeftKey("CourseId").MapRightKey("StudentId"));
        }
    }
}

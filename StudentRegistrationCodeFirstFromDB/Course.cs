namespace StudentRegistrationCodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int CourseId { get; set; }

        [ForeignKey("Department")]
        [Index("IX_CourseNumber_DepartmentId", IsUnique = true, Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required]
        [Index("IX_CourseNumber_DepartmentId", IsUnique = true, Order = 2)]
        public int CourseNumber { get; set; }

        [Required]
        [StringLength(CourseNameMaxLength)]
        public string CourseName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}

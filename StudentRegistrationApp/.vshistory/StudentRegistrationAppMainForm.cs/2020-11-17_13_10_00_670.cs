using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationApp
{
    public partial class StudentRegistrationAppMainForm : Form
    {
        public StudentRegistrationAppMainForm()
        {
            InitializeComponent();

            this.Text = "Student Registration App";

            this.Load += (s, e) => StudentRegistrationFormsAppMainForm_Load();
        }

        private void StudentRegistrationFormsAppMainForm_Load()
        {
            using (StudentRegistrationEntities context = new StudentRegistrationEntities())
            {
                context.SeedDatabase();
            }

            // common setup for datagridview controls
            InitializeDataGridView<Student>(dataGridViewStudents, "Department", "Courses");
            InitializeDataGridView<Department>(dataGridViewDepartments, "Courses", "Students");
            InitializeDataGridView<Course>(dataGridViewCourses, "Students", "Department");


            StudentRegistrationEntities context2 = new StudentRegistrationEntities();

            dataGridViewRegistrations.AllowUserToAddRows = false;
            dataGridViewRegistrations.AllowUserToDeleteRows = true;
            dataGridViewRegistrations.ReadOnly = true;
            dataGridViewRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var studentRegistrations = (from student in context2.Students
                                        from course in student.Courses
                                        select new
                                        {
                                            DepartmentCode = student.Department.DepartmentCode,
                                            CouseNumber = course.CourseNumber,
                                            CourseName = course.CourseName,
                                            StudentId = student.StudentId,
                                            StudentLastName = student.StudentLastName,

                                        }).ToList();

            dataGridViewRegistrations.DataSource = studentRegistrations;

        }
    }
}

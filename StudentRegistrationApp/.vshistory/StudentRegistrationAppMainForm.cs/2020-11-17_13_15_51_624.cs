using StudentRegistrationCodeFirstFromDB;
using EFControllerUtilities;
using System.Linq;
using System.Windows.Forms;
using SeedDatabaseExtensions;

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

        private void InitializeDataGridView<T>(DataGridView gridView, params string[] columnsToHide) where T : class
        {
            // Allow users to add/delete rows, and fill out columns to the entire width of the control


            //List<Course> list = context.Courses.Include("Students").ToList();

            gridView.AllowUserToAddRows = false;

            gridView.AllowUserToDeleteRows = true;
            gridView.ReadOnly = true;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            /*// set the handler used to delete an item. Note use of generics.

            gridView.UserDeletingRow += (s, e) => DeletingRow<T>(s as DataGridView, e);

            // probably not needed, but just in case we have some issues

            gridView.DataError += (s, e) => HandleDataError<T>(s as DataGridView, e);*/

            gridView.DataSource = Controller<StudentRegistrationEntities, T>.SetBindingList();

            foreach (string column in columnsToHide)
                gridView.Columns[column].Visible = false;

        }
    }
}

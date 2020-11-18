using StudentRegistrationCodeFirstFromDB;
using EFControllerUtilities;
using System.Linq;
using System.Windows.Forms;
using SeedDatabaseExtensions;
using System.Diagnostics;

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

        private void InitializeDataGridView<T>(DataGridView datagridView, params string[] columnsToHide) where T : class
        {
            datagridView.AllowUserToAddRows = false;
            datagridView.AllowUserToDeleteRows = true;
            datagridView.ReadOnly = true;
            datagridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridView.UserDeletingRow += (s, e) => DeletingRow<T>(s as DataGridView, e);
            datagridView.DataError += (s, e) => HandleDataError<T>(s as DataGridView, e);
            datagridView.DataSource = Controller<StudentRegistrationEntities, T>.SetBindingList();

            foreach (string column in columnsToHide)
            {
                datagridView.Columns[column].Visible = false;
            }
        }

        private void DeletingRow<T>(DataGridView dataGridView, DataGridViewRowCancelEventArgs e) where T : class
        {
            T item = e.Row.DataBoundItem as T;
            Controller<StudentRegistrationEntities, Course>.GetEntitiesWithIncluded("Department");
            Controller<StudentRegistrationEntities, T>.DeleteEntity(item);
            dataGridView.Refresh();

            StudentRegistrationEntities context = new StudentRegistrationEntities();
            var studentRegistrations = (from student in context.Students
                                        from course in student.Courses
                                        select new
                                        {
                                            student.Department.DepartmentCode,
                                            CouseNumber = course.CourseNumber,
                                            course.CourseName,
                                            student.StudentId,
                                            student.StudentLastName,
                                        }).ToList();

            dataGridViewRegistrations.DataSource = studentRegistrations;
            dataGridViewRegistrations.Refresh();
        }

        private void HandleDataError<T>(DataGridView gridView, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}

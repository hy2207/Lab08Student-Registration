using StudentRegistrationCodeFirstFromDB;
using EFControllerUtilities;
using System.Linq;
using System.Windows.Forms;
using System;

namespace StudentRegistrationApp
{
    public partial class StudentRegistrationAppMainForm : Form
    {
        public StudentRegistrationAppMainForm()
        {
            InitializeComponent();
            this.Text = "Student Registration App";
            this.Load += (s, e) => InitializeStudentRegistrationFormsAppMainForm();

            AddOrUpdateStudent addOrUpdateStudent = new AddOrUpdateStudent();
            AddOrUpdateCourse addOrUpdateCourse = new AddOrUpdateCourse();
            AddOrUpdateDepartment addOrUpdateDepartment = new AddOrUpdateDepartment();

            buttonAddOrUpdateStudent.Click += (s, e) => AddOrUpdateForm<Student>(dataGridViewStudents, addOrUpdateStudent);
            buttonAddOrUpdateCourse.Click += (s, e) => AddOrUpdateForm<Course>(dataGridViewCourses, addOrUpdateCourse);
            buttonAddOrUpdateDepartment.Click += (s, e) => AddOrUpdateForm<Department>(dataGridViewDepartments, addOrUpdateDepartment);

        }

        private void InitializeStudentRegistrationFormsAppMainForm()
        {
            StudentRegistrationEntities context = new StudentRegistrationEntities();
            //context.SeedDatabase();
            
            InitializeDataGridView<Student>(dataGridViewStudents, "Department", "Courses");
            InitializeDataGridView<Department>(dataGridViewDepartments, "Courses", "Students");
            InitializeDataGridView<Course>(dataGridViewCourses, "Students", "Department");
            
            dataGridViewRegistrations.AllowUserToAddRows = false;
            dataGridViewRegistrations.AllowUserToDeleteRows = true;
            dataGridViewRegistrations.ReadOnly = true;
            dataGridViewRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var registrations = (from student in context.Students
                                        from course in student.Courses
                                        select new
                                        {
                                            student.Department.DepartmentCode,
                                            CouseNumber = course.CourseNumber,
                                            course.CourseName,
                                            student.StudentId,
                                            student.StudentLastName
                                        }).ToList();

            dataGridViewRegistrations.DataSource = registrations;
        }

        private void InitializeDataGridView<T>(DataGridView datagridView, params string[] columnsToHide) where T : class
        {
            datagridView.AllowUserToAddRows = false;
            datagridView.AllowUserToDeleteRows = true;
            datagridView.ReadOnly = true;
            datagridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridView.UserDeletingRow += (s, e) => DeleteRow<T>(s as DataGridView, e);
            datagridView.DataError += (s, e) => HandleError<T>(s as DataGridView, e);
            datagridView.DataSource = Controller<StudentRegistrationEntities, T>.SetBindingList();

            foreach (string column in columnsToHide)
            {
                datagridView.Columns[column].Visible = false;
            }
        }

        private void DeleteRow<T>(DataGridView dataGridView, DataGridViewRowCancelEventArgs e) where T : class
        {
            T eachItem = e.Row.DataBoundItem as T;
            Controller<StudentRegistrationEntities, Course>.GetEntitiesWithIncluded("Department");
            Controller<StudentRegistrationEntities, T>.DeleteEntity(eachItem);
            dataGridView.Refresh();
            StudentRegistrationEntities context = new StudentRegistrationEntities();
            var registrations = (from student in context.Students
                                        from course in student.Courses
                                        select new
                                        {
                                            student.Department.DepartmentCode,
                                            CouseNumber = course.CourseNumber,
                                            course.CourseName,
                                            student.StudentId,
                                            student.StudentLastName
                                        }).ToList();

            dataGridViewRegistrations.DataSource = registrations;
            dataGridViewRegistrations.Refresh();
        }

        private void HandleError<T>(DataGridView gridView, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void AddOrUpdateForm<T>(DataGridView dataGridView, Form form) where T : class
        {
            var result = form.ShowDialog();
            Type tType = typeof(T);
            // form has closed

            if (result == DialogResult.OK)
            {
                
                dataGridView.DataSource = Controller<StudentRegistrationEntities, T>.SetBindingList();
                dataGridView.Refresh();

            }

            form.Hide();
        }

    }
}

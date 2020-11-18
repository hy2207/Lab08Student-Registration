using StudentRegistrationCodeFirstFromDB;
using EFControllerUtilities;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace StudentRegistrationApp
{
    public partial class StudentRegistrationAppMainForm : Form
    {
        public StudentRegistrationAppMainForm()
        {
            InitializeComponent();
            this.Text = "Student Registration App";
            //load data
            this.Load += (s, e) => InitializeStudentRegistrationFormsAppMainForm();

            //add or update function -> child form
            AddOrUpdateStudent addOrUpdateStudent = new AddOrUpdateStudent();
            AddOrUpdateCourse addOrUpdateCourse = new AddOrUpdateCourse();
            AddOrUpdateDepartment addOrUpdateDepartment = new AddOrUpdateDepartment();

            buttonAddOrUpdateStudent.Click += (s, e) => AddOrUpdateForm<Student>(dataGridViewStudents, addOrUpdateStudent);
            buttonAddOrUpdateCourse.Click += (s, e) => AddOrUpdateForm<Course>(dataGridViewCourses, addOrUpdateCourse);
            buttonAddOrUpdateDepartment.Click += (s, e) => AddOrUpdateForm<Department>(dataGridViewDepartments, addOrUpdateDepartment);
            
            //set register button
            buttonRegister.Click += ButtonRegister_Click;
            //set drop button
            buttonDrop.Click += ButtonDrop_Click;
        }
        /// <summary>
        /// Drop by selecting registration 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDrop_Click(object sender, EventArgs e)
        {
            StudentRegistrationEntities context = new StudentRegistrationEntities();

            //if registration is not selected
            if (dataGridViewRegistrations.SelectedRows == null)
            {
                MessageBox.Show("Registration must be selected");
                return;
            }

            int currentStudentId = (int)dataGridViewRegistrations.CurrentRow.Cells[3].Value;
            int currentCourseNumber = (int)dataGridViewRegistrations.CurrentRow.Cells[1].Value;

            Student currentStudent = context.Students.Find(currentStudentId);
            Course currentCourse = context.Courses
                .First(course => course.CourseNumber == currentCourseNumber) as Course;

            //drop the course
            currentStudent.Courses.Remove(currentCourse);
            //save the change
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update registraiton information" + ex.InnerException.InnerException.Message);
                return;
            }

            //refresh datagridview of registration            
            updateRegistrationInfo();
            dataGridViewRegistrations.Refresh();

        }

        /// <summary>
        /// registration based on student and course information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            StudentRegistrationEntities context = new StudentRegistrationEntities();

            //if student or course is not selected
            if ((dataGridViewStudents.SelectedRows == null) & (dataGridViewCourses.SelectedRows == null))
            {
                MessageBox.Show("Student and course must be selected");
                return;
            }

            int currentStudentId = (int)dataGridViewStudents.CurrentCell.Value;
            int currentCourseId = (int)dataGridViewCourses.CurrentCell.Value;

            //get selected student
            Student Selectedstudent = context.Students.Find(currentStudentId);
            //get selected course
            Course Selectedcourse = context.Courses.Find(currentCourseId);

            //update entity 
            Selectedstudent.Courses.Add(Selectedcourse);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update registraiton information" + ex.InnerException.InnerException.Message);
                return;
            }

            //refresh datagridview of registration            
            updateRegistrationInfo();
            dataGridViewRegistrations.Refresh();
        }

        /// <summary>
        /// Update datagridview for registration
        /// </summary>
        private void updateRegistrationInfo()
        {
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
        }


        /// <summary>
        /// Method to initialize main form.
        /// </summary>
        private void InitializeStudentRegistrationFormsAppMainForm()
        {
            StudentRegistrationEntities context = new StudentRegistrationEntities();
            //context.SeedDatabase();
            
            //Calling method that initializes all of the datagrids.
            InitializeDataGridView<Student>(dataGridViewStudents, "Department", "Courses");
            InitializeDataGridView<Department>(dataGridViewDepartments, "Courses", "Students");
            InitializeDataGridView<Course>(dataGridViewCourses, "Students", "Department");
            
            dataGridViewRegistrations.AllowUserToAddRows = false;
            dataGridViewRegistrations.AllowUserToDeleteRows = true;
            dataGridViewRegistrations.ReadOnly = true;
            dataGridViewRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            updateRegistrationInfo();
            //var registrations = (from student in context.Students
            //                            from course in student.Courses
            //                            select new
            //                            {
            //                                student.Department.DepartmentCode,
            //                                CouseNumber = course.CourseNumber,
            //                                course.CourseName,
            //                                student.StudentId,
            //                                student.StudentLastName
            //                            }).ToList();

            //dataGridViewRegistrations.DataSource = registrations;
        }

        /// <summary>
        /// Method to initialize DataGridsViews
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datagridView"></param>
        /// <param name="columnsToHide"></param>
        private void InitializeDataGridView<T>(DataGridView datagridView, params string[] columnsToHide) where T : class
        {
            datagridView.AllowUserToAddRows = false;
            datagridView.AllowUserToDeleteRows = true;
            datagridView.ReadOnly = true;
            datagridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridView.UserDeletingRow += (s, e) => DeleteRow<T>(s as DataGridView, e);
            datagridView.DataError += (s, e) => HandleExceptions<T>(s as DataGridView, e);
            datagridView.DataSource = Controller<StudentRegistrationEntities, T>.SetBindingList();

            foreach (string column in columnsToHide)
            {
                datagridView.Columns[column].Visible = false;
            }
        }

        /// <summary>
        /// Method to delete a row in Data Grids
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Method to Handle expections.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridView"></param>
        /// <param name="e"></param>
        private void HandleExceptions<T>(DataGridView gridView, DataGridViewDataErrorEventArgs e)
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

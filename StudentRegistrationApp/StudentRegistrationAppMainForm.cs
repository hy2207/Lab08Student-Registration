﻿using StudentRegistrationCodeFirstFromDB;
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
            this.Load += (s, e) => InitializeStudentRegistrationFormsAppMainForm();
        }

        /// <summary>
        /// Method to initialize main form.
        /// </summary>
        private void InitializeStudentRegistrationFormsAppMainForm()
        {
            StudentRegistrationEntities context = new StudentRegistrationEntities();
            context.SeedDatabase();
            
            //Calling method that initializes all of the datagrids.
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
    }
}

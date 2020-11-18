using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentRegistrationCodeFirstFromDB;
using System.Data.Entity;
using System.Diagnostics;

namespace StudentRegistrationApp
{
    public partial class AddOrUpdateStudent : Form
    {
        private StudentRegistrationEntities context;
        public AddOrUpdateStudent()
        {
            InitializeComponent();

            //register the event handlers
            this.Load += AddOrUpdateStudent_Load;
            //add new student
            buttonAdd.Click += ButtonAdd_Click;
            //update student
            buttonUpdate.Click += ButtonUpdate_Click;

            //listbox event handler for when a student is selected
            listBoxStudnets.SelectedIndexChanged += ListBoxStudnets_SelectedIndexChanged;

            //dispose of the context when the form is closed
            this.FormClosed += (s, e) => context.Dispose();
        }
        /// <summary>
        /// loaded it when user select index in student list box is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxStudnets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBoxStudnets.SelectedItem is Student student))
                return;
            else
            {
                textBoxFirstName.Text = student.StudentFirstName;
                textBoxLastName.Text = student.StudentLastName;
            }
        }
        /// <summary>
        /// When click the update button after selecting one of student list
        /// User can update student name and department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!(listBoxStudnets.SelectedItem is Student student))
            {
                MessageBox.Show("Student to be updated must be selected");
                return;
            }
            //update entity 
            student.StudentFirstName = textBoxFirstName.Text;
            student.StudentLastName = textBoxLastName.Text;

            string selectedDepartmentCode = listBoxDepartment.SelectedItem.ToString();
            Department newDepartment = context.Departments.First(d => d.DepartmentCode == selectedDepartmentCode);
            student.Department = newDepartment;
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update student to database" + ex.InnerException.InnerException.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
            context.Dispose();
            Close();
        }
        /// <summary>
        /// User can add student based on selecting department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string selectedDepartmentCode = listBoxDepartment.SelectedItem.ToString();

            //find department based on selected department code
            Department newDepartment = context.Departments.First(d => d.DepartmentCode == selectedDepartmentCode);

            //get the student infromation from the textboxes
            Student newStudent = new Student()
            {
                StudentFirstName = textBoxFirstName.Text,
                StudentLastName = textBoxLastName.Text,
                Department = newDepartment,
            };
            //update db
            try
            {
                context.Students.Add(newStudent);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot add student to databse" + ex.InnerException.InnerException.Message);
                return;
            }
            // if everyting is ok, get rid of the context, and close the form.
            this.DialogResult = DialogResult.OK;
            context.Dispose();
            Close();
        }
        /// <summary>
        /// Load the student and department table
        /// In department, only display department code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOrUpdateStudent_Load(object sender, EventArgs e)
        {
            this.Tag = null;

            //get context and load student and department table
            context = new StudentRegistrationEntities();
            context.Database.Log = s => Debug.Write(s);
            context.SaveChanges();
            context.Students.Load();
            context.Departments.Load();

            // bind the listbox of studentst to the table.
            listBoxStudnets.DataSource = context.Students.Local.ToBindingList();

            //set department list box
            var departmentCode = context.Departments.OrderBy(x => x.DepartmentId).Select(x => x.DepartmentCode);
            listBoxDepartment.DataSource = departmentCode.ToList();

            // any student is not selected
            listBoxStudnets.SelectedIndex = -1;
            //select first department in default
            listBoxDepartment.SelectedIndex = 0;

            // set all textboxes to blank
            textBoxFirstName.ResetText();
            textBoxLastName.ResetText();
        }
    }
}

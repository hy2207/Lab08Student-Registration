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
using EFControllerUtilities;

namespace StudentRegistrationApp
{
    public partial class AddOrUpdateCourse : Form
    {
        Course selectedCourse;
        public AddOrUpdateCourse()
        {
            InitializeComponent();
        }

        private void listBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCourse = (Course)listBoxCourse.SelectedItem;
            if(selectedCourse == null)
            {
                return;
            }
            textBoxCourseNumber.Text = selectedCourse.CourseNumber.ToString();
            textBoxCourseName.Text = selectedCourse.CourseName;

            Department dept = Controller<StudentRegistrationEntities, Department>.GetEntities(d => d.DepartmentId == selectedCourse.DepartmentId).FirstOrDefault();
            int deptIndex = listBoxDepartment.FindString(listBoxDepartment.GetItemText(dept));
            listBoxDepartment.SelectedIndex = deptIndex;
        }

        private void AddOrUpdateCourse_Load(object sender, EventArgs e)
        {
            listBoxCourse.DataSource = Controller<StudentRegistrationEntities, Course>.GetEntitiesWithIncluded("Department").ToList();
            listBoxCourse.SelectedIndex = -1;
            listBoxDepartment.DataSource = Controller<StudentRegistrationEntities, Department>.SetBindingList();
            listBoxDepartment.SelectedIndex = -1;

            textBoxCourseName.ResetText();
            textBoxCourseNumber.ResetText();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int courseNo;
            if (!int.TryParse(textBoxCourseNumber.Text, out courseNo))
            {
                MessageBox.Show("Course Number should be a number!");
                return;
            }
            selectedCourse.CourseNumber = courseNo;
            selectedCourse.CourseName = textBoxCourseName.Text;
            Department dept = (Department)listBoxDepartment.SelectedItem;
            if(dept == null)
            {
                MessageBox.Show("Please select the Department!");
                return;
            }
            selectedCourse.DepartmentId = dept.DepartmentId;
            selectedCourse.Department = dept;
            Course existingCourse = Controller<StudentRegistrationEntities, Course>.GetEntities(c => c.CourseNumber == selectedCourse.CourseNumber && c.DepartmentId == selectedCourse.DepartmentId).FirstOrDefault();
            if (existingCourse == null)
            {
                if (Controller<StudentRegistrationEntities, Course>.UpdateEntity(selectedCourse))
                    MessageBox.Show("Course updated successfully!");
                else
                    MessageBox.Show("Error updating the course!");
            }
            else
            {
                MessageBox.Show("Another course with same course number exist in this Department!");
            }
            this.AddOrUpdateCourse_Load(sender, e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Course newCourse = new Course();
            int courseNo;
            if (!int.TryParse(textBoxCourseNumber.Text, out courseNo))
            {
                MessageBox.Show("Course Number should be a number!");
                return;
            }
            newCourse.CourseNumber = courseNo;
            newCourse.CourseName = textBoxCourseName.Text;
            Department dept = (Department)listBoxDepartment.SelectedItem;
            if (dept == null)
            {
                MessageBox.Show("Please select the Department!");
                return;
            }
            newCourse.DepartmentId = dept.DepartmentId;
            Course existingCourse = Controller<StudentRegistrationEntities, Course>.GetEntities(c => c.CourseNumber == newCourse.CourseNumber && c.DepartmentId == newCourse.DepartmentId).FirstOrDefault();
            if (existingCourse == null)
            {
                newCourse = Controller<StudentRegistrationEntities, Course>.AddEntity(newCourse);
                if (newCourse == null)
                    MessageBox.Show("Error creating new course!");
                else
                    MessageBox.Show("New course created successfully!");
            }
            else
            {
                MessageBox.Show("Another course with same course number exist in this Department!");
            }
            this.AddOrUpdateCourse_Load(sender, e);
        }
    }
}

using System;
using System.Linq;
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
            // Setting the course to user selected course from the listbox.
            selectedCourse = (Course)listBoxCourse.SelectedItem;
            if (selectedCourse == null)
            {
                return;
            }

            // Setting the values of user selected course to textboxes
            // so that user can update the values.
            textBoxCourseNumber.Text = selectedCourse.CourseNumber.ToString();
            textBoxCourseName.Text = selectedCourse.CourseName;

            // Getting the corresponding department to the selected course.
            Department dept = Controller<StudentRegistrationEntities, Department>.
                GetEntities(d => d.DepartmentId == selectedCourse.DepartmentId).FirstOrDefault();
            
            //Setting the Department listbox to the current department as per the course. 
            int deptIndex = listBoxDepartment.FindString(listBoxDepartment.GetItemText(dept));
            listBoxDepartment.SelectedIndex = deptIndex;
        }

        private void AddOrUpdateCourse_Load(object sender, EventArgs e)
        {
            // Setting the DataSource for Courses list and deselecting all the options.
            listBoxCourse.DataSource = Controller<StudentRegistrationEntities, Course>.GetEntitiesWithIncluded("Department").ToList();
            listBoxCourse.SelectedIndex = -1;

            // Setting the DataSource for Departments list and deselecting all the options.
            listBoxDepartment.DataSource = Controller<StudentRegistrationEntities, Department>.SetBindingList();
            listBoxDepartment.SelectedIndex = -1;

            // Clearing the texts from the textboxes, from initial load.
            textBoxCourseName.ResetText();
            textBoxCourseNumber.ResetText();
        }

        /// <summary>
        /// This method is called when the update button on form is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Parsing the user input for course number to valid int.
            int courseNo;
            if (!int.TryParse(textBoxCourseNumber.Text, out courseNo))
            {
                MessageBox.Show("Course Number should be a number!");
                return;
            }

            // Setting the properties of the selected course as per user entry.
            selectedCourse.CourseNumber = courseNo;
            selectedCourse.CourseName = textBoxCourseName.Text;
            Department dept = (Department)listBoxDepartment.SelectedItem;
            if (dept == null)
            {
                MessageBox.Show("Please select the Department!");
                return;
            }
            selectedCourse.DepartmentId = dept.DepartmentId;
            selectedCourse.Department = dept;

            // Checking if already another course with same course number in the same department exists.
            Course existingCourse = Controller<StudentRegistrationEntities, Course>.
                GetEntities(c => c.CourseNumber == selectedCourse.CourseNumber &&
                c.DepartmentId == selectedCourse.DepartmentId &&
                c.CourseId != selectedCourse.CourseId).FirstOrDefault();

            // If no same course in the same department found then try updating the current course.
            if (existingCourse == null)
            {
                if (Controller<StudentRegistrationEntities, Course>.UpdateEntity(selectedCourse))
                {
                    MessageBox.Show("Course updated successfully!");
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Error updating the course!");
            }
            // else show the error to the user, that already another course exists in this department with same number.
            else
            {
                MessageBox.Show("Another course with same course number exist in this Department!");
            }

            // Reset all controls to initial states.
            this.AddOrUpdateCourse_Load(sender, e);
        }

        /// <summary>
        /// This method is called when the Add button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Course newCourse = new Course();

            // Parsing the user input for course number to valid int.
            int courseNo;
            if (!int.TryParse(textBoxCourseNumber.Text, out courseNo))
            {
                MessageBox.Show("Course Number should be a number!");
                return;
            }

            // Setting the properties of the new course as per user entry.
            newCourse.CourseNumber = courseNo;
            newCourse.CourseName = textBoxCourseName.Text;
            Department dept = (Department)listBoxDepartment.SelectedItem;
            if (dept == null)
            {
                MessageBox.Show("Please select the Department!");
                return;
            }
            newCourse.DepartmentId = dept.DepartmentId;

            // Checking if already another course with same course number in the same department exists.
            Course existingCourse = Controller<StudentRegistrationEntities, Course>.
                GetEntities(c => c.CourseNumber == newCourse.CourseNumber &&
                c.DepartmentId == newCourse.DepartmentId).FirstOrDefault();

            // If no same course in the same department found then try inserting the new course.
            if (existingCourse == null)
            {
                newCourse = Controller<StudentRegistrationEntities, Course>.AddEntity(newCourse);
                if (newCourse == null)
                    MessageBox.Show("Error creating new course!");
                else
                {
                    MessageBox.Show("New course created successfully!");
                    this.DialogResult = DialogResult.OK;
                }
            }
            // else show the error to the user, that already another course exists in this department with same number.
            else
            {
                MessageBox.Show("Another course with same course number exist in this Department!");
            }

            // Reset all controls to initial states.
            this.AddOrUpdateCourse_Load(sender, e);
        }
    }
}

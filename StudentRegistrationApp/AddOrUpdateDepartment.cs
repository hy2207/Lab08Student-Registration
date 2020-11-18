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
    public partial class AddOrUpdateDepartment : Form
    {
        Department selectedDepartment;
        public AddOrUpdateDepartment()
        {
            InitializeComponent();
        }

        private void AddOrUpdateDepartment_Load(object sender, EventArgs e)
        {
            listBoxDepartment.DataSource = Controller<StudentRegistrationEntities, Department>.SetBindingList();
            listBoxDepartment.SelectedIndex = -1;
            textBoxDepartmentCode.ResetText();
            textBox1.ResetText();
        }

        private void listBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDepartment = (Department)listBoxDepartment.SelectedItem;

            if (selectedDepartment == null)
            {
                return;
            }

            textBoxDepartmentCode.Text = selectedDepartment.DepartmentCode;
            textBox1.Text = selectedDepartment.DepartmentName;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            selectedDepartment.DepartmentCode = textBoxDepartmentCode.Text;
            selectedDepartment.DepartmentName = textBox1.Text;

            if (Controller<StudentRegistrationEntities, Department>.UpdateEntity(selectedDepartment))
                MessageBox.Show("Department Updated Successfully!");
            else
                MessageBox.Show("Error Updating Department!");
            this.AddOrUpdateDepartment_Load(sender, e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Department newDepartment = new Department();
            newDepartment.DepartmentCode = textBoxDepartmentCode.Text;
            newDepartment.DepartmentName = textBox1.Text;

            Department existingDept = Controller<StudentRegistrationEntities, Department>.GetEntities(d => d.DepartmentCode == newDepartment.DepartmentCode).FirstOrDefault();
            if (existingDept == null)
            {
                newDepartment = Controller<StudentRegistrationEntities, Department>.AddEntity(newDepartment);
                if (newDepartment != null)
                    MessageBox.Show("Department created Successfully!");
                else
                    MessageBox.Show("Error creating new Department!");
            }
            else
            {
                MessageBox.Show("Department with Department Code '" + newDepartment.DepartmentCode + "' already exist!");
            }
            this.AddOrUpdateDepartment_Load(sender, e);
        }
    }
}

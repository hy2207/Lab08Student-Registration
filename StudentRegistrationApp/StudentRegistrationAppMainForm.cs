using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Diagnostics;
using StudentRegistrationCodeFirstFromDB;

namespace StudentRegistrationApp
{
    public partial class StudentRegistrationAppMainForm : Form
    {
        private StudentRegistrationEntities context;
        public StudentRegistrationAppMainForm()
        {
            InitializeComponent();

            AddOrUpdateStudent addOrUpdateStudent = new AddOrUpdateStudent();
            buttonAddOrUpdateStudent.Click += (s, e) => AddOrUpdateForm<Student>(dataGridViewStudents, addOrUpdateStudent);

        }

        private void AddOrUpdateForm<T>(DataGridView dataGridView, Form form) where T : class
        {
            var result = form.ShowDialog();

            // form has closed

            if (result == DialogResult.OK)
            {
                // reload the db and update the gridview

                // EF will not reload if there are no additions, so we need to force a reload
                // Use the form's Tag to get the key of the item updated, and then force the reload
                // of just that item.
                // If we use controller, the table is just reloaded. This is a bit more efficient,
                // but a pain.

                if (form.Tag != null)
                {
                    int id = (int)form.Tag;

                    T entity = context.Set<T>().Find(id);
                    context.Entry<T>(entity).Reload();
                }
                else dataGridView.DataSource = SetBindingList<T>();

                dataGridView.Refresh();

                // ALWAYS update the customer orders report, hence use of AsNoTracking()

                //LoadCustomerOrdersView();
            }

            // do not close, as the form object will be disposed, 
            // just hide the form (make it invisible). 
            // 
            // when the inputForm is opened again (ShowDialog()), the Load event will fire
            //  and the form will be reinitialized

            form.Hide();
        }
        private BindingList<T> SetBindingList<T>() where T : class
        {
            DbSet<T> dbSet = context.Set<T>();

            dbSet.Load();
            BindingList<T> list = dbSet.Local.ToBindingList<T>();
            return list;
        }
        
    }
}

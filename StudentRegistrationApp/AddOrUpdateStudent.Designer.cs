namespace StudentRegistrationApp
{
    partial class AddOrUpdateStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelStudents = new System.Windows.Forms.Label();
            this.listBoxStudnets = new System.Windows.Forms.ListBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.listBoxDepartment = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStudents
            // 
            this.labelStudents.AutoSize = true;
            this.labelStudents.Location = new System.Drawing.Point(27, 33);
            this.labelStudents.Name = "labelStudents";
            this.labelStudents.Size = new System.Drawing.Size(80, 21);
            this.labelStudents.TabIndex = 0;
            this.labelStudents.Text = "Students";
            // 
            // listBoxStudnets
            // 
            this.listBoxStudnets.FormattingEnabled = true;
            this.listBoxStudnets.ItemHeight = 16;
            this.listBoxStudnets.Location = new System.Drawing.Point(134, 33);
            this.listBoxStudnets.Name = "listBoxStudnets";
            this.listBoxStudnets.Size = new System.Drawing.Size(246, 228);
            this.listBoxStudnets.TabIndex = 1;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(27, 290);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(95, 21);
            this.labelFirstName.TabIndex = 3;
            this.labelFirstName.Text = "First Name";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(134, 290);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(153, 22);
            this.textBoxFirstName.TabIndex = 4;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(134, 351);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(153, 22);
            this.textBoxLastName.TabIndex = 6;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(27, 351);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(76, 17);
            this.labelLastName.TabIndex = 5;
            this.labelLastName.Text = "Last Name";
            // 
            // labelDepartment
            // 
            this.labelDepartment.AutoSize = true;
            this.labelDepartment.Location = new System.Drawing.Point(27, 409);
            this.labelDepartment.Name = "labelDepartment";
            this.labelDepartment.Size = new System.Drawing.Size(103, 21);
            this.labelDepartment.TabIndex = 7;
            this.labelDepartment.Text = "Department";
            // 
            // listBoxDepartment
            // 
            this.listBoxDepartment.FormattingEnabled = true;
            this.listBoxDepartment.ItemHeight = 16;
            this.listBoxDepartment.Location = new System.Drawing.Point(134, 409);
            this.listBoxDepartment.Name = "listBoxDepartment";
            this.listBoxDepartment.Size = new System.Drawing.Size(153, 132);
            this.listBoxDepartment.TabIndex = 8;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(134, 568);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(248, 568);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // AddOrUpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 635);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxDepartment);
            this.Controls.Add(this.labelDepartment);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.listBoxStudnets);
            this.Controls.Add(this.labelStudents);
            this.Name = "AddOrUpdateStudent";
            this.Text = "AddOrUpdateStudent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStudents;
        private System.Windows.Forms.ListBox listBoxStudnets;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.ListBox listBoxDepartment;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
    }
}
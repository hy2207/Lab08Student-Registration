namespace StudentRegistrationApp
{
    partial class StudentRegistrationAppMainForm
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
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.buttonAddOrUpdateStudent = new System.Windows.Forms.Button();
            this.buttonAddOrUpdateDepartment = new System.Windows.Forms.Button();
            this.dataGridViewDepartments = new System.Windows.Forms.DataGridView();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.buttonAddOrUpdateCourse = new System.Windows.Forms.Button();
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            this.labelCourses = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelRegistration = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonDrop = new System.Windows.Forms.Button();
            this.labelRegisterDrop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStudents
            // 
            this.labelStudents.AutoSize = true;
            this.labelStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStudents.Location = new System.Drawing.Point(42, 27);
            this.labelStudents.Name = "labelStudents";
            this.labelStudents.Size = new System.Drawing.Size(66, 19);
            this.labelStudents.TabIndex = 0;
            this.labelStudents.Text = "Students";
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(42, 54);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.RowHeadersWidth = 51;
            this.dataGridViewStudents.RowTemplate.Height = 24;
            this.dataGridViewStudents.Size = new System.Drawing.Size(490, 171);
            this.dataGridViewStudents.TabIndex = 1;
            // 
            // buttonAddOrUpdateStudent
            // 
            this.buttonAddOrUpdateStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonAddOrUpdateStudent.Location = new System.Drawing.Point(560, 101);
            this.buttonAddOrUpdateStudent.Name = "buttonAddOrUpdateStudent";
            this.buttonAddOrUpdateStudent.Size = new System.Drawing.Size(88, 68);
            this.buttonAddOrUpdateStudent.TabIndex = 2;
            this.buttonAddOrUpdateStudent.Text = "Add Or Update Student";
            this.buttonAddOrUpdateStudent.UseVisualStyleBackColor = true;
            // 
            // buttonAddOrUpdateDepartment
            // 
            this.buttonAddOrUpdateDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonAddOrUpdateDepartment.Location = new System.Drawing.Point(1110, 101);
            this.buttonAddOrUpdateDepartment.Name = "buttonAddOrUpdateDepartment";
            this.buttonAddOrUpdateDepartment.Size = new System.Drawing.Size(88, 68);
            this.buttonAddOrUpdateDepartment.TabIndex = 5;
            this.buttonAddOrUpdateDepartment.Text = "Add Or Update Department";
            this.buttonAddOrUpdateDepartment.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDepartments
            // 
            this.dataGridViewDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartments.Location = new System.Drawing.Point(690, 54);
            this.dataGridViewDepartments.Name = "dataGridViewDepartments";
            this.dataGridViewDepartments.RowHeadersWidth = 51;
            this.dataGridViewDepartments.RowTemplate.Height = 24;
            this.dataGridViewDepartments.Size = new System.Drawing.Size(386, 171);
            this.dataGridViewDepartments.TabIndex = 4;
            // 
            // labelDepartment
            // 
            this.labelDepartment.AutoSize = true;
            this.labelDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDepartment.Location = new System.Drawing.Point(690, 27);
            this.labelDepartment.Name = "labelDepartment";
            this.labelDepartment.Size = new System.Drawing.Size(91, 19);
            this.labelDepartment.TabIndex = 3;
            this.labelDepartment.Text = "Departments";
            // 
            // buttonAddOrUpdateCourse
            // 
            this.buttonAddOrUpdateCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonAddOrUpdateCourse.Location = new System.Drawing.Point(560, 342);
            this.buttonAddOrUpdateCourse.Name = "buttonAddOrUpdateCourse";
            this.buttonAddOrUpdateCourse.Size = new System.Drawing.Size(88, 68);
            this.buttonAddOrUpdateCourse.TabIndex = 8;
            this.buttonAddOrUpdateCourse.Text = "Add Or Update Course";
            this.buttonAddOrUpdateCourse.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCourses
            // 
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourses.Location = new System.Drawing.Point(42, 295);
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.RowHeadersWidth = 51;
            this.dataGridViewCourses.RowTemplate.Height = 24;
            this.dataGridViewCourses.Size = new System.Drawing.Size(490, 171);
            this.dataGridViewCourses.TabIndex = 7;
            // 
            // labelCourses
            // 
            this.labelCourses.AutoSize = true;
            this.labelCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCourses.Location = new System.Drawing.Point(42, 268);
            this.labelCourses.Name = "labelCourses";
            this.labelCourses.Size = new System.Drawing.Size(62, 19);
            this.labelCourses.TabIndex = 6;
            this.labelCourses.Text = "Courses";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 513);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(770, 171);
            this.dataGridView1.TabIndex = 10;
            // 
            // labelRegistration
            // 
            this.labelRegistration.AutoSize = true;
            this.labelRegistration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRegistration.Location = new System.Drawing.Point(42, 486);
            this.labelRegistration.Name = "labelRegistration";
            this.labelRegistration.Size = new System.Drawing.Size(93, 19);
            this.labelRegistration.TabIndex = 9;
            this.labelRegistration.Text = "Registrations";
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonRegister.Location = new System.Drawing.Point(873, 542);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(88, 33);
            this.buttonRegister.TabIndex = 11;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            // 
            // buttonDrop
            // 
            this.buttonDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonDrop.Location = new System.Drawing.Point(873, 612);
            this.buttonDrop.Name = "buttonDrop";
            this.buttonDrop.Size = new System.Drawing.Size(88, 33);
            this.buttonDrop.TabIndex = 12;
            this.buttonDrop.Text = "Drop";
            this.buttonDrop.UseVisualStyleBackColor = true;
            // 
            // labelRegisterDrop
            // 
            this.labelRegisterDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRegisterDrop.Location = new System.Drawing.Point(1004, 532);
            this.labelRegisterDrop.Name = "labelRegisterDrop";
            this.labelRegisterDrop.Size = new System.Drawing.Size(179, 125);
            this.labelRegisterDrop.TabIndex = 13;
            this.labelRegisterDrop.Text = "Register by selecting students and course then hit Register button \r\n\r\nDrop by se" +
    "lecting Registration and then hit Drop button";
            // 
            // StudentRegistrationAppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 765);
            this.Controls.Add(this.labelRegisterDrop);
            this.Controls.Add(this.buttonDrop);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelRegistration);
            this.Controls.Add(this.buttonAddOrUpdateCourse);
            this.Controls.Add(this.dataGridViewCourses);
            this.Controls.Add(this.labelCourses);
            this.Controls.Add(this.buttonAddOrUpdateDepartment);
            this.Controls.Add(this.dataGridViewDepartments);
            this.Controls.Add(this.labelDepartment);
            this.Controls.Add(this.buttonAddOrUpdateStudent);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.labelStudents);
            this.Name = "StudentRegistrationAppMainForm";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.StudentRegistrationAppMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStudents;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.Button buttonAddOrUpdateStudent;
        private System.Windows.Forms.Button buttonAddOrUpdateDepartment;
        private System.Windows.Forms.DataGridView dataGridViewDepartments;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.Button buttonAddOrUpdateCourse;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.Label labelCourses;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelRegistration;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonDrop;
        private System.Windows.Forms.Label labelRegisterDrop;
    }
}


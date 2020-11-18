namespace StudentRegistrationApp
{
    partial class AddOrUpdateCourse
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
            this.labelCourses = new System.Windows.Forms.Label();
            this.listBoxCourse = new System.Windows.Forms.ListBox();
            this.listBoxDepartment = new System.Windows.Forms.ListBox();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.labelCourseNumber = new System.Windows.Forms.Label();
            this.textBoxCourseNumber = new System.Windows.Forms.TextBox();
            this.textBoxCourseName = new System.Windows.Forms.TextBox();
            this.labelCourseName = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCourses
            // 
            this.labelCourses.AutoSize = true;
            this.labelCourses.Location = new System.Drawing.Point(31, 49);
            this.labelCourses.Name = "labelCourses";
            this.labelCourses.Size = new System.Drawing.Size(60, 17);
            this.labelCourses.TabIndex = 0;
            this.labelCourses.Text = "Courses";
            // 
            // listBoxCourse
            // 
            this.listBoxCourse.FormattingEnabled = true;
            this.listBoxCourse.ItemHeight = 16;
            this.listBoxCourse.Location = new System.Drawing.Point(154, 49);
            this.listBoxCourse.Name = "listBoxCourse";
            this.listBoxCourse.Size = new System.Drawing.Size(168, 132);
            this.listBoxCourse.TabIndex = 1;
            this.listBoxCourse.SelectedIndexChanged += new System.EventHandler(this.listBoxCourse_SelectedIndexChanged);
            // 
            // listBoxDepartment
            // 
            this.listBoxDepartment.FormattingEnabled = true;
            this.listBoxDepartment.ItemHeight = 16;
            this.listBoxDepartment.Location = new System.Drawing.Point(154, 218);
            this.listBoxDepartment.Name = "listBoxDepartment";
            this.listBoxDepartment.Size = new System.Drawing.Size(120, 132);
            this.listBoxDepartment.TabIndex = 3;
            // 
            // labelDepartment
            // 
            this.labelDepartment.AutoSize = true;
            this.labelDepartment.Location = new System.Drawing.Point(31, 218);
            this.labelDepartment.Name = "labelDepartment";
            this.labelDepartment.Size = new System.Drawing.Size(82, 17);
            this.labelDepartment.TabIndex = 2;
            this.labelDepartment.Text = "Department";
            // 
            // labelCourseNumber
            // 
            this.labelCourseNumber.AutoSize = true;
            this.labelCourseNumber.Location = new System.Drawing.Point(12, 373);
            this.labelCourseNumber.Name = "labelCourseNumber";
            this.labelCourseNumber.Size = new System.Drawing.Size(107, 17);
            this.labelCourseNumber.TabIndex = 4;
            this.labelCourseNumber.Text = "Course Number";
            // 
            // textBoxCourseNumber
            // 
            this.textBoxCourseNumber.Location = new System.Drawing.Point(154, 373);
            this.textBoxCourseNumber.Name = "textBoxCourseNumber";
            this.textBoxCourseNumber.Size = new System.Drawing.Size(120, 22);
            this.textBoxCourseNumber.TabIndex = 5;
            // 
            // textBoxCourseName
            // 
            this.textBoxCourseName.Location = new System.Drawing.Point(154, 418);
            this.textBoxCourseName.Name = "textBoxCourseName";
            this.textBoxCourseName.Size = new System.Drawing.Size(120, 22);
            this.textBoxCourseName.TabIndex = 7;
            // 
            // labelCourseName
            // 
            this.labelCourseName.AutoSize = true;
            this.labelCourseName.Location = new System.Drawing.Point(12, 418);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(94, 17);
            this.labelCourseName.TabIndex = 6;
            this.labelCourseName.Text = "Course Name";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(113, 471);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(237, 471);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // AddOrUpdateCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 573);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxCourseName);
            this.Controls.Add(this.labelCourseName);
            this.Controls.Add(this.textBoxCourseNumber);
            this.Controls.Add(this.labelCourseNumber);
            this.Controls.Add(this.listBoxDepartment);
            this.Controls.Add(this.labelDepartment);
            this.Controls.Add(this.listBoxCourse);
            this.Controls.Add(this.labelCourses);
            this.Name = "AddOrUpdateCourse";
            this.Text = "AddOrUpdateCourse";
            this.Load += new System.EventHandler(this.AddOrUpdateCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCourses;
        private System.Windows.Forms.ListBox listBoxCourse;
        private System.Windows.Forms.ListBox listBoxDepartment;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.Label labelCourseNumber;
        private System.Windows.Forms.TextBox textBoxCourseNumber;
        private System.Windows.Forms.TextBox textBoxCourseName;
        private System.Windows.Forms.Label labelCourseName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
    }
}
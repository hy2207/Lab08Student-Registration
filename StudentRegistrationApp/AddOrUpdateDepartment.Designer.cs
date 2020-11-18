namespace StudentRegistrationApp
{
    partial class AddOrUpdateDepartment
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
            this.listBoxDepartment = new System.Windows.Forms.ListBox();
            this.labelDepartmentCode = new System.Windows.Forms.Label();
            this.textBoxDepartmentCode = new System.Windows.Forms.TextBox();
            this.labelDepartmentName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxDepartment
            // 
            this.listBoxDepartment.FormattingEnabled = true;
            this.listBoxDepartment.ItemHeight = 16;
            this.listBoxDepartment.Location = new System.Drawing.Point(22, 12);
            this.listBoxDepartment.Name = "listBoxDepartment";
            this.listBoxDepartment.Size = new System.Drawing.Size(143, 180);
            this.listBoxDepartment.TabIndex = 0;
            this.listBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.listBoxDepartment_SelectedIndexChanged);
            // 
            // labelDepartmentCode
            // 
            this.labelDepartmentCode.AutoSize = true;
            this.labelDepartmentCode.Location = new System.Drawing.Point(19, 218);
            this.labelDepartmentCode.Name = "labelDepartmentCode";
            this.labelDepartmentCode.Size = new System.Drawing.Size(119, 17);
            this.labelDepartmentCode.TabIndex = 1;
            this.labelDepartmentCode.Text = "Department Code";
            // 
            // textBoxDepartmentCode
            // 
            this.textBoxDepartmentCode.Location = new System.Drawing.Point(22, 242);
            this.textBoxDepartmentCode.Name = "textBoxDepartmentCode";
            this.textBoxDepartmentCode.Size = new System.Drawing.Size(130, 22);
            this.textBoxDepartmentCode.TabIndex = 2;
            // 
            // labelDepartmentName
            // 
            this.labelDepartmentName.AutoSize = true;
            this.labelDepartmentName.Location = new System.Drawing.Point(19, 314);
            this.labelDepartmentName.Name = "labelDepartmentName";
            this.labelDepartmentName.Size = new System.Drawing.Size(123, 17);
            this.labelDepartmentName.TabIndex = 3;
            this.labelDepartmentName.Text = "Department Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 334);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 22);
            this.textBox1.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(22, 381);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(166, 381);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // AddOrUpdateDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 450);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelDepartmentName);
            this.Controls.Add(this.textBoxDepartmentCode);
            this.Controls.Add(this.labelDepartmentCode);
            this.Controls.Add(this.listBoxDepartment);
            this.Name = "AddOrUpdateDepartment";
            this.Text = "AddOrUpdateDepartment";
            this.Load += new System.EventHandler(this.AddOrUpdateDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDepartment;
        private System.Windows.Forms.Label labelDepartmentCode;
        private System.Windows.Forms.TextBox textBoxDepartmentCode;
        private System.Windows.Forms.Label labelDepartmentName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
    }
}
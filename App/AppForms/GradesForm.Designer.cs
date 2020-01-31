namespace App.AppForms
{
    partial class GradesForm
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
            this.components = new System.ComponentModel.Container();
            this.StudentIdsComboBox = new System.Windows.Forms.ComboBox();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridViewAddGrade = new System.Windows.Forms.DataGridView();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddGradeButton = new System.Windows.Forms.Button();
            this.RemoveGradeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentIdsComboBox
            // 
            this.StudentIdsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentIdsComboBox.FormattingEnabled = true;
            this.StudentIdsComboBox.Location = new System.Drawing.Point(25, 37);
            this.StudentIdsComboBox.Name = "StudentIdsComboBox";
            this.StudentIdsComboBox.Size = new System.Drawing.Size(121, 21);
            this.StudentIdsComboBox.TabIndex = 0;
            this.StudentIdsComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grade value";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.comboBox2.Location = new System.Drawing.Point(161, 37);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // dataGridViewAddGrade
            // 
            this.dataGridViewAddGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAddGrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAddGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddGrade.Location = new System.Drawing.Point(313, 12);
            this.dataGridViewAddGrade.Name = "dataGridViewAddGrade";
            this.dataGridViewAddGrade.Size = new System.Drawing.Size(480, 193);
            this.dataGridViewAddGrade.TabIndex = 5;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Programowanie Aplikacji",
            "Matematyka",
            "Zarządzanie Bazami Danych",
            "Systemy Operacyjne"});
            this.comboBox3.Location = new System.Drawing.Point(25, 84);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(257, 21);
            this.comboBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subject";
            // 
            // AddGradeButton
            // 
            this.AddGradeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddGradeButton.Location = new System.Drawing.Point(58, 173);
            this.AddGradeButton.Name = "AddGradeButton";
            this.AddGradeButton.Size = new System.Drawing.Size(88, 32);
            this.AddGradeButton.TabIndex = 8;
            this.AddGradeButton.Text = "Add grade";
            this.AddGradeButton.UseVisualStyleBackColor = true;
            this.AddGradeButton.Click += new System.EventHandler(this.AddGradeButton_Click);
            // 
            // RemoveGradeButton
            // 
            this.RemoveGradeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveGradeButton.Location = new System.Drawing.Point(161, 173);
            this.RemoveGradeButton.Name = "RemoveGradeButton";
            this.RemoveGradeButton.Size = new System.Drawing.Size(89, 32);
            this.RemoveGradeButton.TabIndex = 9;
            this.RemoveGradeButton.Text = "Remove grade";
            this.RemoveGradeButton.UseVisualStyleBackColor = true;
            this.RemoveGradeButton.Click += new System.EventHandler(this.RemoveGradeButton_Click);
            // 
            // GradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 217);
            this.Controls.Add(this.RemoveGradeButton);
            this.Controls.Add(this.AddGradeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.dataGridViewAddGrade);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StudentIdsComboBox);
            this.Name = "GradesForm";
            this.Text = "Add grade";
            //this.Load += new System.EventHandler(this.AddGradeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox StudentIdsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewAddGrade;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddGradeButton;
        private System.Windows.Forms.Button RemoveGradeButton;
    }
}
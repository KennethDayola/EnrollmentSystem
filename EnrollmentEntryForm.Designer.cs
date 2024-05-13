namespace EnrollmentSystem
{
    partial class EnrollmentEntryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.EnrollmentTablePanel2 = new System.Windows.Forms.Panel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.EncodedTextBox = new System.Windows.Forms.TextBox();
            this.EnrollmentDataGridView = new System.Windows.Forms.DataGridView();
            this.EDPCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EnrollmentTablePanel = new System.Windows.Forms.Panel();
            this.TotalUnitsLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.EnrollmentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.EDPTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.IDFoundIndicatorLabel = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.CourseLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IDNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubjectScheduleEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.EnrollmentTablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnrollmentDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.EnrollmentTablePanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel7.Location = new System.Drawing.Point(0, 545);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1007, 10);
            this.panel7.TabIndex = 25;
            // 
            // EnrollmentTablePanel2
            // 
            this.EnrollmentTablePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.EnrollmentTablePanel2.Controls.Add(this.ClearButton);
            this.EnrollmentTablePanel2.Controls.Add(this.SaveButton);
            this.EnrollmentTablePanel2.Controls.Add(this.label16);
            this.EnrollmentTablePanel2.Controls.Add(this.EncodedTextBox);
            this.EnrollmentTablePanel2.Controls.Add(this.EnrollmentDataGridView);
            this.EnrollmentTablePanel2.Location = new System.Drawing.Point(88, 493);
            this.EnrollmentTablePanel2.Name = "EnrollmentTablePanel2";
            this.EnrollmentTablePanel2.Size = new System.Drawing.Size(814, 225);
            this.EnrollmentTablePanel2.TabIndex = 28;
            this.EnrollmentTablePanel2.Click += new System.EventHandler(this.EnrollmentTablePanel2_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Gainsboro;
            this.ClearButton.Enabled = false;
            this.ClearButton.Font = new System.Drawing.Font("Segoe UI Light", 7.8F);
            this.ClearButton.Location = new System.Drawing.Point(544, 192);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(86, 23);
            this.ClearButton.TabIndex = 33;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveButton.Enabled = false;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI Light", 7.8F);
            this.SaveButton.Location = new System.Drawing.Point(701, 192);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(86, 23);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gainsboro;
            this.label16.Location = new System.Drawing.Point(39, 196);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 20);
            this.label16.TabIndex = 32;
            this.label16.Text = "Encoded by: ";
            // 
            // EncodedTextBox
            // 
            this.EncodedTextBox.BackColor = System.Drawing.Color.Silver;
            this.EncodedTextBox.Enabled = false;
            this.EncodedTextBox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.EncodedTextBox.Location = new System.Drawing.Point(141, 194);
            this.EncodedTextBox.Name = "EncodedTextBox";
            this.EncodedTextBox.Size = new System.Drawing.Size(209, 25);
            this.EncodedTextBox.TabIndex = 32;
            // 
            // EnrollmentDataGridView
            // 
            this.EnrollmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.EnrollmentDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EnrollmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.EnrollmentDataGridView.ColumnHeadersHeight = 30;
            this.EnrollmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDPCodeColumn,
            this.SubjectCodeColumn,
            this.StartTimeColumn,
            this.EndTimeColumn,
            this.DaysColumn,
            this.RoomColumn,
            this.UnitsColumn});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EnrollmentDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.EnrollmentDataGridView.Enabled = false;
            this.EnrollmentDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.EnrollmentDataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnrollmentDataGridView.Location = new System.Drawing.Point(14, 11);
            this.EnrollmentDataGridView.Name = "EnrollmentDataGridView";
            this.EnrollmentDataGridView.ReadOnly = true;
            this.EnrollmentDataGridView.RowHeadersVisible = false;
            this.EnrollmentDataGridView.RowHeadersWidth = 51;
            this.EnrollmentDataGridView.RowTemplate.Height = 24;
            this.EnrollmentDataGridView.Size = new System.Drawing.Size(785, 174);
            this.EnrollmentDataGridView.TabIndex = 0;
            // 
            // EDPCodeColumn
            // 
            this.EDPCodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EDPCodeColumn.FillWeight = 90.20618F;
            this.EDPCodeColumn.HeaderText = "EDP Code";
            this.EDPCodeColumn.MinimumWidth = 6;
            this.EDPCodeColumn.Name = "EDPCodeColumn";
            this.EDPCodeColumn.ReadOnly = true;
            // 
            // SubjectCodeColumn
            // 
            this.SubjectCodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectCodeColumn.FillWeight = 112.9053F;
            this.SubjectCodeColumn.HeaderText = "Subject Code";
            this.SubjectCodeColumn.MinimumWidth = 6;
            this.SubjectCodeColumn.Name = "SubjectCodeColumn";
            this.SubjectCodeColumn.ReadOnly = true;
            // 
            // StartTimeColumn
            // 
            this.StartTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StartTimeColumn.FillWeight = 96.87312F;
            this.StartTimeColumn.HeaderText = "Start Time";
            this.StartTimeColumn.MinimumWidth = 6;
            this.StartTimeColumn.Name = "StartTimeColumn";
            this.StartTimeColumn.ReadOnly = true;
            // 
            // EndTimeColumn
            // 
            this.EndTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndTimeColumn.FillWeight = 98.98589F;
            this.EndTimeColumn.HeaderText = "End Time";
            this.EndTimeColumn.MinimumWidth = 6;
            this.EndTimeColumn.Name = "EndTimeColumn";
            this.EndTimeColumn.ReadOnly = true;
            // 
            // DaysColumn
            // 
            this.DaysColumn.FillWeight = 75.11742F;
            this.DaysColumn.HeaderText = "Days";
            this.DaysColumn.MinimumWidth = 6;
            this.DaysColumn.Name = "DaysColumn";
            this.DaysColumn.ReadOnly = true;
            this.DaysColumn.Width = 65;
            // 
            // RoomColumn
            // 
            this.RoomColumn.FillWeight = 86.65486F;
            this.RoomColumn.HeaderText = "Room";
            this.RoomColumn.MinimumWidth = 6;
            this.RoomColumn.Name = "RoomColumn";
            this.RoomColumn.ReadOnly = true;
            this.RoomColumn.Width = 74;
            // 
            // UnitsColumn
            // 
            this.UnitsColumn.FillWeight = 139.2573F;
            this.UnitsColumn.HeaderText = "Units";
            this.UnitsColumn.MinimumWidth = 6;
            this.UnitsColumn.Name = "UnitsColumn";
            this.UnitsColumn.ReadOnly = true;
            this.UnitsColumn.Width = 66;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(890, 887);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "__________";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::EnrollmentSystem.Properties.Resources.bgEnrollbackup1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.EnrollmentTablePanel);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 642);
            this.panel1.TabIndex = 2;
            // 
            // EnrollmentTablePanel
            // 
            this.EnrollmentTablePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(36)))), ((int)(((byte)(65)))));
            this.EnrollmentTablePanel.Controls.Add(this.TotalUnitsLabel);
            this.EnrollmentTablePanel.Controls.Add(this.label14);
            this.EnrollmentTablePanel.Controls.Add(this.EnrollmentDateTimePicker);
            this.EnrollmentTablePanel.Controls.Add(this.label13);
            this.EnrollmentTablePanel.Controls.Add(this.EDPTextBox);
            this.EnrollmentTablePanel.Controls.Add(this.label12);
            this.EnrollmentTablePanel.Location = new System.Drawing.Point(88, 449);
            this.EnrollmentTablePanel.Name = "EnrollmentTablePanel";
            this.EnrollmentTablePanel.Size = new System.Drawing.Size(814, 49);
            this.EnrollmentTablePanel.TabIndex = 29;
            this.EnrollmentTablePanel.Click += new System.EventHandler(this.EnrollmentTablePanel_Click);
            // 
            // TotalUnitsLabel
            // 
            this.TotalUnitsLabel.BackColor = System.Drawing.Color.Gray;
            this.TotalUnitsLabel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalUnitsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TotalUnitsLabel.Location = new System.Drawing.Point(743, 11);
            this.TotalUnitsLabel.Name = "TotalUnitsLabel";
            this.TotalUnitsLabel.Size = new System.Drawing.Size(47, 23);
            this.TotalUnitsLabel.TabIndex = 14;
            this.TotalUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gainsboro;
            this.label14.Location = new System.Drawing.Point(656, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "Total Units";
            // 
            // EnrollmentDateTimePicker
            // 
            this.EnrollmentDateTimePicker.CalendarForeColor = System.Drawing.Color.DimGray;
            this.EnrollmentDateTimePicker.CalendarMonthBackground = System.Drawing.Color.Silver;
            this.EnrollmentDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.EnrollmentDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.EnrollmentDateTimePicker.CustomFormat = "";
            this.EnrollmentDateTimePicker.Enabled = false;
            this.EnrollmentDateTimePicker.Font = new System.Drawing.Font("Segoe UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnrollmentDateTimePicker.Location = new System.Drawing.Point(357, 11);
            this.EnrollmentDateTimePicker.Name = "EnrollmentDateTimePicker";
            this.EnrollmentDateTimePicker.Size = new System.Drawing.Size(214, 25);
            this.EnrollmentDateTimePicker.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gainsboro;
            this.label13.Location = new System.Drawing.Point(307, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 20);
            this.label13.TabIndex = 15;
            this.label13.Text = "Date";
            // 
            // EDPTextBox
            // 
            this.EDPTextBox.BackColor = System.Drawing.Color.Silver;
            this.EDPTextBox.Enabled = false;
            this.EDPTextBox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDPTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.EDPTextBox.Location = new System.Drawing.Point(117, 13);
            this.EDPTextBox.Name = "EDPTextBox";
            this.EDPTextBox.Size = new System.Drawing.Size(149, 25);
            this.EDPTextBox.TabIndex = 14;
            this.EDPTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EDPTextBox_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(30, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "EDP Code";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(42)))), ((int)(((byte)(75)))));
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.IDFoundIndicatorLabel);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.YearLabel);
            this.panel6.Controls.Add(this.CourseLabel);
            this.panel6.Controls.Add(this.NameLabel);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.IDNumberTextBox);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(175, 162);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(638, 220);
            this.panel6.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(435, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "**Please fill up this field first";
            // 
            // IDFoundIndicatorLabel
            // 
            this.IDFoundIndicatorLabel.AutoSize = true;
            this.IDFoundIndicatorLabel.Font = new System.Drawing.Font("Segoe UI Light", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDFoundIndicatorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(37)))), ((int)(((byte)(35)))));
            this.IDFoundIndicatorLabel.Location = new System.Drawing.Point(267, 93);
            this.IDFoundIndicatorLabel.Name = "IDFoundIndicatorLabel";
            this.IDFoundIndicatorLabel.Size = new System.Drawing.Size(193, 15);
            this.IDFoundIndicatorLabel.TabIndex = 37;
            this.IDFoundIndicatorLabel.Text = "ID number not found in the database!!";
            this.IDFoundIndicatorLabel.Visible = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(36)))), ((int)(((byte)(65)))));
            this.panel10.Controls.Add(this.label3);
            this.panel10.Location = new System.Drawing.Point(0, -8);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(638, 39);
            this.panel10.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(22, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Student Information 🖊️  ";
            // 
            // YearLabel
            // 
            this.YearLabel.BackColor = System.Drawing.Color.Gray;
            this.YearLabel.Font = new System.Drawing.Font("Segoe UI", 6.8F);
            this.YearLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.YearLabel.Location = new System.Drawing.Point(397, 162);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(72, 23);
            this.YearLabel.TabIndex = 12;
            this.YearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CourseLabel
            // 
            this.CourseLabel.BackColor = System.Drawing.Color.Gray;
            this.CourseLabel.Font = new System.Drawing.Font("Segoe UI", 6.8F);
            this.CourseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CourseLabel.Location = new System.Drawing.Point(258, 162);
            this.CourseLabel.Name = "CourseLabel";
            this.CourseLabel.Size = new System.Drawing.Size(72, 23);
            this.CourseLabel.TabIndex = 11;
            this.CourseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameLabel
            // 
            this.NameLabel.BackColor = System.Drawing.Color.Gray;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 6.8F);
            this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NameLabel.Location = new System.Drawing.Point(258, 119);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(211, 23);
            this.NameLabel.TabIndex = 10;
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(350, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(176, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Course";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(181, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Name";
            // 
            // IDNumberTextBox
            // 
            this.IDNumberTextBox.BackColor = System.Drawing.Color.Silver;
            this.IDNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDNumberTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.IDNumberTextBox.Location = new System.Drawing.Point(258, 68);
            this.IDNumberTextBox.Name = "IDNumberTextBox";
            this.IDNumberTextBox.Size = new System.Drawing.Size(211, 25);
            this.IDNumberTextBox.TabIndex = 6;
            this.IDNumberTextBox.TextChanged += new System.EventHandler(this.IDNumberTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(149, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "ID Number";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(0)))), ((int)(((byte)(124)))));
            this.panel2.Controls.Add(this.menuStrip2);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 73);
            this.panel2.TabIndex = 26;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip2.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI Variable Display Semil", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(862, 16);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(90, 32);
            this.menuStrip2.TabIndex = 26;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExitToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ExitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(80, 28);
            this.ExitToolStripMenuItem.Text = "🚪 Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Variable Display Semil", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(26, 13);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(90, 35);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectEntryToolStripMenuItem,
            this.SubjectScheduleEntryToolStripMenuItem,
            this.studentEntryToolStripMenuItem});
            this.FileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.FileToolStripMenuItem.Text = "🏚️ File";
            this.FileToolStripMenuItem.DropDownClosed += new System.EventHandler(this.FileToolStripMenuItem_DropDownClosed);
            this.FileToolStripMenuItem.DropDownOpened += new System.EventHandler(this.FileToolStripMenuItem_DropDownOpened);
            // 
            // subjectEntryToolStripMenuItem
            // 
            this.subjectEntryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.subjectEntryToolStripMenuItem.Name = "subjectEntryToolStripMenuItem";
            this.subjectEntryToolStripMenuItem.Size = new System.Drawing.Size(307, 30);
            this.subjectEntryToolStripMenuItem.Text = "📚 Subject Entry";
            this.subjectEntryToolStripMenuItem.Click += new System.EventHandler(this.subjectEntryToolStripMenuItem_Click);
            // 
            // SubjectScheduleEntryToolStripMenuItem
            // 
            this.SubjectScheduleEntryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.SubjectScheduleEntryToolStripMenuItem.Name = "SubjectScheduleEntryToolStripMenuItem";
            this.SubjectScheduleEntryToolStripMenuItem.Size = new System.Drawing.Size(307, 30);
            this.SubjectScheduleEntryToolStripMenuItem.Text = "🕒 Subject Schedule Entry";
            this.SubjectScheduleEntryToolStripMenuItem.Click += new System.EventHandler(this.SubjectScheduleEntryToolStripMenuItem_Click);
            // 
            // studentEntryToolStripMenuItem
            // 
            this.studentEntryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.studentEntryToolStripMenuItem.Name = "studentEntryToolStripMenuItem";
            this.studentEntryToolStripMenuItem.Size = new System.Drawing.Size(307, 30);
            this.studentEntryToolStripMenuItem.Text = "👩‍🎓 Student Entry";
            this.studentEntryToolStripMenuItem.Click += new System.EventHandler(this.studentEntryToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(363, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "📝";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(1, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(989, 10);
            this.panel3.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Banner Semibold", 16.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(425, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enrollment Entry ";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Controls.Add(this.label20);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(973, 23);
            this.panel5.TabIndex = 25;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.RoyalBlue;
            this.label20.Font = new System.Drawing.Font("Segoe UI Variable Display Semil", 9.25F);
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Location = new System.Drawing.Point(432, -1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(160, 21);
            this.label20.TabIndex = 18;
            this.label20.Text = "🏫 Enrollment System";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Location = new System.Drawing.Point(0, 245);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(976, 10);
            this.panel4.TabIndex = 24;
            // 
            // EnrollmentEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(16)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(971, 769);
            this.Controls.Add(this.EnrollmentTablePanel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Name = "EnrollmentEntryForm";
            this.Text = "EnrollmentEntryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnrollmentEntry_FormClosing);
            this.EnrollmentTablePanel2.ResumeLayout(false);
            this.EnrollmentTablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnrollmentDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.EnrollmentTablePanel.ResumeLayout(false);
            this.EnrollmentTablePanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SubjectScheduleEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentEntryToolStripMenuItem;
        private System.Windows.Forms.Panel EnrollmentTablePanel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel EnrollmentTablePanel;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox EDPTextBox;
        private System.Windows.Forms.DataGridView EnrollmentDataGridView;
        private System.Windows.Forms.DateTimePicker EnrollmentDateTimePicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label TotalUnitsLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox EncodedTextBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ToolStripMenuItem subjectEntryToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label IDFoundIndicatorLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label CourseLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox IDNumberTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDPCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn;
    }
}
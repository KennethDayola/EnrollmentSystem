using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnrollmentSystem
{
    public partial class StudentEntryForm : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\johnk\source\repos\EnrollmentSystem\Dayola.accdb";
        bool closedDirectly = true;
        public StudentEntryForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateClrMethods.AreTextBoxesEmpty(IDNumTextBox, FirstNameTextBox, LastNameTextBox, MiddleInitialTextBox,
                CourseTextBox, CourseTextBox, YearTextBox) || ValidateClrMethods.AreComboBoxesEmpty(RemarksComboBox))
            {
                MessageBox.Show("Please fill out all required fields before proceeding");
                return;
            }
            if (!int.TryParse(IDNumTextBox.Text, out _))
            {
                MessageBox.Show("The input in the ID Number field must be an integer");
                return;
            }
            if (!int.TryParse(YearTextBox.Text, out _))
            {
                MessageBox.Show("The input in the year textbox must be an integer");
                return;
            }

            DatabaseHelper databaseHelper = new DatabaseHelper();
            string query = "Select * From STUDENTFILE";
            databaseHelper.ConnectToDatabase(query);

            if (databaseHelper.CheckIfDataInDB(IDNumTextBox.Text, "STFSTUDID", query))
            {
                MessageBox.Show("Current ID number is already on the database");
                return;
            }

            DataSet thisDataset = new DataSet();
            databaseHelper.dbDataAdapter.Fill(thisDataset, "StudentFile");

            DataRow thisRow = thisDataset.Tables["StudentFile"].NewRow();
            thisRow["STFSTUDID"] = IDNumTextBox.Text;
            thisRow["STFSTUDLNAME"] = LastNameTextBox.Text;
            thisRow["STFSTUDFNAME"] = FirstNameTextBox.Text;
            thisRow["STFSTUDMNAME"] = MiddleInitialTextBox.Text;
            thisRow["STFSTUDCOURSE"] = CourseTextBox.Text;
            thisRow["STFSTUDYEAR"] = YearTextBox.Text;
            thisRow["STFSTUDREMARKS"] = RemarksComboBox.Text;
            thisRow["STFSTUDSTATUS"] = "AC";

            thisDataset.Tables["StudentFile"].Rows.Add(thisRow);
            databaseHelper.dbDataAdapter.Update(thisDataset, "StudentFile");

            MessageBox.Show("Recorded");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ValidateClrMethods.ClearTextBoxes(IDNumTextBox, FirstNameTextBox, LastNameTextBox, MiddleInitialTextBox,
                CourseTextBox, CourseTextBox, YearTextBox);
            ValidateClrMethods.ClearComboBoxes(RemarksComboBox);
        }

        private void StudentEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedDirectly)
                Application.Exit();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SubjectEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            SubjectEntryForm subjectEntryForm= new SubjectEntryForm();
            this.Hide();
            subjectEntryForm.Show();
            this.Close();
        }

        private void SubjectScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            SubjectScheduleEntryForm subjectScheduleEntryForm = new SubjectScheduleEntryForm();
            this.Hide();
            subjectScheduleEntryForm.Show();
            this.Close();
        }

        private void FileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.White;
        }

        private void FileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.Black;
        }
    }
}

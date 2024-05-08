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
    public partial class StudentEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\johnk\source\repos\EnrollmentSystem\Dayola.accdb";
        bool closedDirectly = true;
        public StudentEntry()
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

            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string Ole = "Select * From STUDENTFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            thisConnection.Open();
            OleDbCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = Ole;
            OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
            while (thisDataReader.Read())
            {
                if (thisDataReader["STFSTUDID"].ToString().Trim().ToUpper() == IDNumTextBox.Text.Trim().ToUpper())
                {
                    MessageBox.Show("Current ID number is already on the database");
                    return;
                }
            }
            thisConnection.Close();

            DataSet thisDataset = new DataSet();
            thisAdapter.Fill(thisDataset, "StudentFile");

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
            thisAdapter.Update(thisDataset, "StudentFile");

            MessageBox.Show("Recorded");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ValidateClrMethods.ClearTextBoxes(IDNumTextBox, FirstNameTextBox, LastNameTextBox, MiddleInitialTextBox,
                CourseTextBox, CourseTextBox, YearTextBox);
            ValidateClrMethods.ClearComboBoxes(RemarksComboBox);
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StudentEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedDirectly)
                Application.Exit();
        }
    }
}

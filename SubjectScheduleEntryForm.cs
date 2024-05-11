using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class SubjectScheduleEntryForm : Form
    {
        List<string> subjCodes = new List<string>();
        List<string> subjDescs = new List<string>();
        bool foundSubject = false;
        bool closedDirectly = true;

        public SubjectScheduleEntryForm()
        {
            InitializeComponent();
            GetDescriptionFromTable();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateClrMethods.AreTextBoxesEmpty(SubjectEDPCodeTextBox, SubjectCodeTextBox, DaysTextBox, SectionTextBox,
                RoomTextBox, SchoolYearTextBox) || ValidateClrMethods.AreComboBoxesEmpty (XMComboBox))
            {
                MessageBox.Show("Please fill out all required fields");
                return;
            }
            if (TimeStartTimePicker.Value.TimeOfDay >= TimeEndTimePicker.Value.TimeOfDay)
            {
                MessageBox.Show("End time must be greater than start time");
                return;
            }
            if (!foundSubject)
            {
                MessageBox.Show("Subject code must already exist on the database");
                return;
            }
            if (!int.TryParse(SchoolYearTextBox.Text, out _))
            {
                MessageBox.Show("The input in the school year textbox must be an integer");
                return;
            }

            DatabaseHelper databaseHelper = new DatabaseHelper();
            string query = "Select * From SUBJECTSCHEDFILE";
            databaseHelper.ConnectToDatabase(query);

            if (databaseHelper.CheckIfDataInDB(SubjectEDPCodeTextBox.Text, "SSFEDPCODE", query)) 
            { 
                MessageBox.Show("Current subject code is already on the database");
                return;
            }
            
            DataSet thisDataset = new DataSet();
            databaseHelper.dbDataAdapter.Fill(thisDataset, "SubjectSchedFile");

            DataRow thisRow = thisDataset.Tables["SubjectSchedFile"].NewRow();
            thisRow["SSFEDPCODE"] = SubjectEDPCodeTextBox.Text;
            thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SSFSTARTTIME"] = TimeStartTimePicker.Value.TimeOfDay.ToString();
            thisRow["SSFENDTIME"] = TimeEndTimePicker.Value.TimeOfDay.ToString();
            thisRow["SSFDAYS"] = DaysTextBox.Text;
            thisRow["SSFROOM"] = RoomTextBox.Text;
            thisRow["SSFSTATUS"] = "AC";
            thisRow["SSFXM"] = XMComboBox.Text;
            thisRow["SSFSECTION"] = SectionTextBox.Text;
            thisRow["SSFSCHOOLYEAR"] = SchoolYearTextBox.Text;

            thisDataset.Tables["SubjectSchedFile"].Rows.Add(thisRow);
            databaseHelper.dbDataAdapter.Update(thisDataset, "SubjectSchedFile");

            MessageBox.Show("Recorded");
        }
        
        /// <summary>
        /// returns subjects with corresponding description from table subjectFile
        /// </summary>
        private void GetDescriptionFromTable()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            databaseHelper.dbConnection = new OleDbConnection(DatabaseHelper.connectionString);
            string query = "Select * From SUBJECTFILE";
            databaseHelper.FetchDataFromDB(query, "SFSUBJCODE", "SFSUBJDESC");
            foreach (string[] row in databaseHelper.resultList)
            {
                subjCodes.Add(row[0]);
                subjDescs.Add(row[1]);
            }
        }

        private void SubjectCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SubjectCodeTextBox.Text))
                SubjFoundIndicatorLabel.Visible = true;
            else
                SubjFoundIndicatorLabel.Visible = false;

            foundSubject = false;
            for (int i = 0; i < subjCodes.Count; i++)
            {
                if (subjCodes[i].Trim().ToUpper() == SubjectCodeTextBox.Text.Trim().ToUpper())
                {
                    SubjFoundIndicatorLabel.Text = "Subject found!!";
                    SubjFoundIndicatorLabel.ForeColor = Color.Green;
                    DescriptionLabel.Text = subjDescs[i].ToString();
                    foundSubject = true;
                }
            }
            if (!foundSubject) {
                SubjFoundIndicatorLabel.Text = "Subject not found in the database!!";
                SubjFoundIndicatorLabel.ForeColor = Color.Brown;
                DescriptionLabel.Text = "";
            }
                
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ValidateClrMethods.ClearTextBoxes(SubjectEDPCodeTextBox, SubjectCodeTextBox, DaysTextBox, SectionTextBox,
                RoomTextBox, SchoolYearTextBox);
            ValidateClrMethods.ClearComboBoxes(XMComboBox);
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SubjectScheduleEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedDirectly)
                Application.Exit();
        }

        private void SubjectEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            SubjectEntryForm subjectEntryForm = new SubjectEntryForm();
            this.Hide();
            subjectEntryForm.Show();
            this.Close();
        }

        private void StudentEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            StudentEntryForm studentEntryForm = new StudentEntryForm();
            this.Hide();
            studentEntryForm.Show();
            this.Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
 }

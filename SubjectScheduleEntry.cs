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
    public partial class SubjectScheduleEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\johnk\source\repos\EnrollmentSystem\Dayola.accdb";
        List<string> subjCodes = new List<string>();
        List<string> subjDescs = new List<string>();
        bool foundSubject = false;
        bool closedDirectly = true;

        public SubjectScheduleEntry()
        {
            InitializeComponent();
            GetSubjAndDescFromTable();
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

            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string Ole = "Select * From SUBJECTSCHEDFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);

            thisConnection.Open();
            OleDbCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = Ole;
            OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
            while (thisDataReader.Read())
            {
                if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == SubjectEDPCodeTextBox.Text.Trim().ToUpper())
                {
                    MessageBox.Show("Current subject code is already on the database");
                    return;
                }
            }
            thisConnection.Close();

            DataSet thisDataset = new DataSet();
            thisAdapter.Fill(thisDataset, "SubjectSchedFile");

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
            thisAdapter.Update(thisDataset, "SubjectSchedFile");

            MessageBox.Show("Recorded");
        }

        /// <summary>
        /// gets subjects and corresponding description from table
        /// </summary>
        /// <returns></returns>
        private void GetSubjAndDescFromTable()
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            thisConnection.Open();
            OleDbCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT SFSUBJCODE, SFSUBJDESC from SUBJECTFILE";
            OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

            while (thisDataReader.Read())
            {
                subjCodes.Add(thisDataReader.GetString(0));
                subjDescs.Add(thisDataReader.GetString(1));
                //if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextBox.Text.Trim().ToUpper())
                //{
                //    DescriptionLabel.Text = thisDataReader["SFSUBJDESC"].ToString();
                //    break;
                //}
                //else
                //    DescriptionLabel.Text = "";
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
    }
 }

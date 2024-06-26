﻿using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    //TODO: Is WI really the status cry
    //TODO: Changing from new to old student
    public partial class EnrollmentEntryForm : Form
    {
        bool closedDirectly = true;
        bool idFound = false;

        string[] dayConstants = new string[] {"S", "F", "TH", "W", "T", "M" };
        List<int> classroomCurrentSizes = new List<int>();

        List<string> studID = new List<string>();
        List<string> studName = new List<string>();
        List<string> studCourse = new List<string>();
        List<string> studYear = new List<string>();
        public EnrollmentEntryForm()
        {
            InitializeComponent();
            GetStudInfosFromDB();
        }

        private void IDNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IDNumberTextBox.Text))
                IDFoundIndicatorLabel.Visible = true;
            else
                IDFoundIndicatorLabel.Visible = false;

            idFound = false;
            for (int i = 0; i < studID.Count; i++)
            {
                if (studID[i].Trim() == IDNumberTextBox.Text.Trim())
                {
                    IDFoundIndicatorLabel.Text = "ID number found!!";
                    IDFoundIndicatorLabel.ForeColor = Color.Green;
                    NameLabel.Text = studName[i].ToString();
                    CourseLabel.Text = studCourse[i].ToString();
                    YearLabel.Text = studYear[i].ToString();
                    NameLabel.BackColor = Color.Silver;
                    CourseLabel.BackColor = Color.Silver;
                    YearLabel.BackColor = Color.Silver;
                    EDPTextBox.Enabled = true;
                    EnrollmentDateTimePicker.Enabled = true;
                    EnrollmentDataGridView.Enabled = true;
                    EncodedTextBox.Enabled = true;
                    SchoolYearTextBox.Enabled = true;
                    ClearButton.Enabled = true;
                    SaveButton.Enabled = true;
                    idFound = true;
                }
            }
            if (!idFound)
            {
                IDFoundIndicatorLabel.Text = "ID number not found in the database!!";
                IDFoundIndicatorLabel.ForeColor = Color.FromArgb(255, 37, 35);
                NameLabel.Text = "";
                CourseLabel.Text = "";
                YearLabel.Text = "";
                NameLabel.BackColor = Color.Gray;
                CourseLabel.BackColor = Color.Gray;
                YearLabel.BackColor = Color.Gray;
                EDPTextBox.Enabled = false;
                EnrollmentDateTimePicker.Enabled = false;
                EnrollmentDataGridView.Enabled = false;
                EncodedTextBox.Enabled = false;
                SchoolYearTextBox.Enabled = false;
                ClearButton.Enabled = false;
                SaveButton.Enabled = false;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (EnrollmentDataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("No data found in the data grid. Please add some data before proceeding");
                return;
            }
            if (ValidateClrMethods.AreTextBoxesEmpty(EncodedTextBox, SchoolYearTextBox))
            {
                MessageBox.Show("Please fill up fields \"Encoded by\" and \"School Year\"");
                return;
            }
            
            //Recording of enrollment detail file
            DatabaseHelper databaseHelperDF = new DatabaseHelper();
            databaseHelperDF.ConnectToDatabase("Select * From ENROLLMENTDETAILFILE");

            for (int i = 0; i < EnrollmentDataGridView.RowCount - 1; i++)
            {
                //if (databaseHelperDF.CheckIfDataInDB(EnrollmentDataGridView.Rows[i].Cells["EDPCodeColumn"].ToString(),
                //    "ENRDFSTUDEDPCODE", "Select * From ENROLLMENTDETAILFILE") && databaseHelperDF.CheckIfDataInDB(IDNumberTextBox.Text,
                //    "ENRDFSTUDID", "Select * From ENROLLMENTDETAILFILE"))
                if (databaseHelperDF.CheckIfDataInDBTwoKeys(EnrollmentDataGridView.Rows[i].Cells["EDPCodeColumn"].Value.ToString(), IDNumberTextBox.Text,
                    "ENRDFSTUDEDPCODE", "ENRDFSTUDID", "Select * From ENROLLMENTDETAILFILE"))
                {
                    MessageBox.Show("Current student ID has already enrolled in the EDP code " + EnrollmentDataGridView.Rows[i].Cells["EDPCodeColumn"].Value.ToString());
                    return;
                }

                if (databaseHelperDF.CheckAndFetchFromDB(EnrollmentDataGridView.Rows[i].Cells["SubjectCodeColumn"].Value.ToString(), "SUBJCODE"
                    , "Select * From SUBJECTPREQFILE", "SUBJCATEGORY", "SUBJPRECODE"))
                {
                    if (databaseHelperDF.resultList[1] == "PR")
                    {
                        if (!(databaseHelperDF.CheckIfDataInDB(databaseHelperDF.resultList[2], "ENRDFSTUDSUBJCODE", "Select * From ENROLLMENTDETAILFILE") 
                            && databaseHelperDF.CheckIfDataInDB(IDNumberTextBox.Text, "ENRDFSTUDID", "Select * From ENROLLMENTDETAILFILE")))
                        {
                            MessageBox.Show("Subject code\"" + EnrollmentDataGridView.Rows[i].Cells["SubjectCodeColumn"].Value.ToString() + "\"  needs the pre-requisite subject \""
                                + databaseHelperDF.resultList[2] + "\" which cannot be found in the current student ID's database");
                            return;
                        }
                    }
                    else if (databaseHelperDF.resultList[1] == "CR")
                    {
                        bool found = false;
                        for (int j = 0; j < EnrollmentDataGridView.RowCount - 1; i++)
                        {
                            if (databaseHelperDF.resultList[2] == EnrollmentDataGridView.Rows[j].Cells["SubjectCodeColumn"].Value.ToString())
                                found = true;
                        }
                        if (!found)
                        {
                            MessageBox.Show("Subject code \"" + EnrollmentDataGridView.Rows[i].Cells["SubjectCodeColumn"].Value.ToString() + "\" needs the co-requisite subject \""
                                + databaseHelperDF.resultList[2] + "\" which cannot be found in the current list");
                            return;
                        }
                    }
                }
            }

            for (int i = 0; i < EnrollmentDataGridView.RowCount - 1; i++)
            {
                if (databaseHelperDF.CheckIfDataInDB(IDNumberTextBox.Text, "ENRDFSTUDID", "Select * From ENROLLMENTDETAILFILE"))
                {
                    if (databaseHelperDF.CheckIfDataInDBTwoKeys(IDNumberTextBox.Text, "New", "STFSTUDID", "STFSTUDREMARKS", "Select * From STUDENTFILE"))
                    {
                        databaseHelperDF.UpdateCell("StudentFile", "STFSTUDREMARKS", "Old", "STFSTUDID", IDNumberTextBox.Text);
                    }
                }

                DataSet thisDatasetDF = new DataSet();
                databaseHelperDF.dbDataAdapter.Fill(thisDatasetDF, "EnrollmentDetailFile");

                DataRow thisRowDF = thisDatasetDF.Tables["EnrollmentDetailFile"].NewRow();
                thisRowDF["ENRDFSTUDID"] = IDNumberTextBox.Text;
                thisRowDF["ENRDFSTUDSUBJCODE"] = EnrollmentDataGridView.Rows[i].Cells["SubjectCodeColumn"].Value.ToString();
                thisRowDF["ENRDFSTUDEDPCODE"] = EnrollmentDataGridView.Rows[i].Cells["EDPCodeColumn"].Value.ToString();
                thisRowDF["ENRDFSTUDSTATUS"] = "WI";

                thisDatasetDF.Tables["EnrollmentDetailFile"].Rows.Add(thisRowDF);
                databaseHelperDF.dbDataAdapter.Update(thisDatasetDF, "EnrollmentDetailFile");
            }
            if (databaseHelperDF.dbConnection.State == ConnectionState.Open)
            {
                databaseHelperDF.dbConnection.Close();
            }

            //Recording of enrollment header file
            DatabaseHelper databaseHelperHF = new DatabaseHelper();
            databaseHelperHF.ConnectToDatabase("Select * From ENROLLMENTHEADERFILE");

            if (!databaseHelperHF.CheckIfDataInDB(IDNumberTextBox.Text, "ENRHFSTUDID", "Select * From ENROLLMENTHEADERFILE"))
            {
                DataSet thisDatasetHF = new DataSet();
                databaseHelperHF.dbDataAdapter.Fill(thisDatasetHF, "EnrollmentHeaderFile");

                DataRow thisRowHF = thisDatasetHF.Tables["EnrollmentHeaderFile"].NewRow();
                thisRowHF["ENRHFSTUDID"] = IDNumberTextBox.Text;
                thisRowHF["ENRHFSTUDDATEENROLL"] = EnrollmentDateTimePicker.Value;
                thisRowHF["ENRHFSTUDSCHLYR"] = SchoolYearTextBox.Text;
                thisRowHF["ENRHFSTUDENCODER"] = EncodedTextBox.Text;
                thisRowHF["ENRHFSTUDTOTALUNITS"] = TotalUnitsLabel.Text;
                thisRowHF["ENRHFSTUDSTATUS"] = "EN";

                thisDatasetHF.Tables["EnrollmentHeaderFile"].Rows.Add(thisRowHF);
                databaseHelperHF.dbDataAdapter.Update(thisDatasetHF, "EnrollmentHeaderFile");
            }

            //Updating class size
            DatabaseHelper databaseHelperSSF = new DatabaseHelper();
            databaseHelperSSF.ConnectToDatabase("Select * From SubjectSchedFile");

            DataSet thisDatasetSSF = new DataSet();
            databaseHelperSSF.dbDataAdapter.Fill(thisDatasetSSF, "SubjectSchedFile");

            for (int i = 0; i < EnrollmentDataGridView.RowCount - 1; i++)
            {
                foreach (DataRow row in thisDatasetSSF.Tables["SubjectSchedFile"].Rows)
                {
                    if (row["SSFEDPCODE"].ToString().Trim() == EnrollmentDataGridView.Rows[i].Cells["EDPCodeColumn"].Value.ToString().Trim())
                    {
                        databaseHelperSSF.UpdateCell("SubjectSchedFile", "SSFCLASSSIZE", classroomCurrentSizes[i], "SSFEDPCODE", row["SSFEDPCODE"].ToString().Trim());
                        break;
                    }
                }
            }

            MessageBox.Show("Recorded");
        }

        /// <summary>
        /// responsible for catching conflicts in the schedule
        /// </summary>
        /// <param name="source"></param>
        private bool IsScheduleValid(List <string> source)
        {
            string enteredCurrentStartTime = Convert12HourTo24HourFormat(DateTime.Parse(source[2]).ToString("hh:mm:tt"));
            string filteredCurrentStartTime = new string(enteredCurrentStartTime.Where(char.IsDigit).ToArray());
            int parsedCurrentStartTime = int.Parse(filteredCurrentStartTime);

            string enteredCurrentEndTime = Convert12HourTo24HourFormat(DateTime.Parse(source[3]).ToString("hh:mm:tt"));
            string filteredCurrentEndTime = new string(enteredCurrentEndTime.Where(char.IsDigit).ToArray());
            int parsedCurrentEndTime = int.Parse(filteredCurrentEndTime);
           
            for (int i = 0; i < EnrollmentDataGridView.Rows.Count - 1; i++)
            {
                string enteredStartTime = Convert12HourTo24HourFormat(EnrollmentDataGridView.Rows[i].Cells["StartTimeColumn"].Value.ToString());
                string filteredStartTime = new string(enteredStartTime.Where(char.IsDigit).ToArray());
                int parsedStartTime = int.Parse(filteredStartTime);

                string enteredEndTime = Convert12HourTo24HourFormat(EnrollmentDataGridView.Rows[i].Cells["EndTimeColumn"].Value.ToString());
                string filteredEndTime = new string(enteredEndTime.Where(char.IsDigit).ToArray());
                int parsedEndTime = int.Parse(filteredEndTime);

                string errorMessage = "New subject entry with the days of \"" + source[4] + "\" and start time of \"" + DateTime.Parse(source[2]).ToString("hh:mm:tt")
                                  + "\" and end time of \"" + DateTime.Parse(source[3]).ToString("hh:mm:tt")
                                  + "\" conflicts with an existing entry with the days of \"" + EnrollmentDataGridView.Rows[i].Cells["DaysColumn"].Value.ToString()
                                  + "\" a start time of \"" + EnrollmentDataGridView.Rows[i].Cells["StartTimeColumn"].Value.ToString()
                                  + "\" and end time of \"" + EnrollmentDataGridView.Rows[i].Cells["EndTimeColumn"].Value.ToString() + "\"";

                if ((parsedStartTime <= parsedCurrentStartTime && parsedEndTime >= parsedCurrentStartTime)
                    || (parsedStartTime <= parsedCurrentEndTime && parsedEndTime >= parsedCurrentEndTime))
                {
                    string currentDays = source[4].Trim().ToUpper();
                    for (int j = 0; j < dayConstants.Length; j++)
                    {
                        if (currentDays.Contains(dayConstants[j]))
                        {
                            currentDays = currentDays.Replace(dayConstants[j], "");
                            if (j == 4)
                            {
                                string dgvIndexDays = EnrollmentDataGridView.Rows[i].Cells["DaysColumn"].Value.ToString().Trim().ToUpper();
                                for (i = 0; i < dgvIndexDays.Length; i++)
                                {
                                    if (dgvIndexDays[i] == 'T')
                                    {
                                        if (!(i + 1 < dgvIndexDays.Length && dgvIndexDays[i + 1] == 'H'))
                                        {
                                            MessageBox.Show(errorMessage);
                                            return false;
                                        }
                                    }
                                }
                            }
                            else if (EnrollmentDataGridView.Rows[i].Cells["DaysColumn"].Value.ToString().Trim().ToUpper().Contains(dayConstants[j]))
                            {
                                MessageBox.Show(errorMessage);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// converts 12 hour time formats to 24 houor
        /// </summary>
        /// <param name="time12HourFormat"></param>
        /// <returns></returns>
        private string Convert12HourTo24HourFormat(string time12HourFormat)
        {
            string[] parts = time12HourFormat.Split(':');
            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);
            string amPm = parts[2];

            if (string.Equals(amPm, "PM", StringComparison.OrdinalIgnoreCase) && hours < 12)
            {
                hours += 12;
            }
            else if (string.Equals(amPm, "AM", StringComparison.OrdinalIgnoreCase) && hours == 12)
            {
                hours = 0;
            }

            return string.Format("{0:D2}:{1:D2}", hours, minutes);
        }

        private void EDPTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidateClrMethods.CheckIfDataInDGV(EDPTextBox.Text, EnrollmentDataGridView, "EDPCodeColumn"))
                {
                    MessageBox.Show("Current EDP code is already in the data grid");
                    return;
                }

                DatabaseHelper databaseHelper = new DatabaseHelper();
                databaseHelper.dbConnection = new OleDbConnection(DatabaseHelper.connectionString);

                int index;
                if (databaseHelper.CheckAndFetchFromDB(EDPTextBox.Text, "SSFEDPCODE", "Select * From SUBJECTSCHEDFILE",
                    "SSFSUBJCODE", "SSFSTARTTIME", "SSFENDTIME", "SSFDAYS", "SSFROOM", "SSFMAXSIZE", "SSFCLASSSIZE"))
                {
                    List<string> temp = new List<string>();
                    temp = databaseHelper.resultList;

                    //Checks if class capacity is at max
                    int maxSize, currentSize = 0;
                    maxSize = Convert.ToInt16(temp[6]);
                    if (!string.IsNullOrWhiteSpace(temp[7]))
                        currentSize = Convert.ToInt16(temp[7]);

                    if (maxSize <= currentSize)
                    {
                        MessageBox.Show("Current subject is already at full capacity");
                        return;
                    }
                    currentSize += 1;
                    classroomCurrentSizes.Add(currentSize);

                    if (!IsScheduleValid(temp))
                        return;

                    //Now the usual getting the data from the database and assigning values to the dgv
                    int units = 0;
                    if (databaseHelper.CheckAndFetchFromDB(temp[1], "SFSUBJCODE", "Select * From SUBJECTFILE", "SFSUBJUNITS"))
                    {
                        index = EnrollmentDataGridView.Rows.Add();
                        EnrollmentDataGridView.Rows[index].Cells["UnitsColumn"].Value = databaseHelper.resultList[1];
                        units = Convert.ToInt16(databaseHelper.resultList[1]);
                    }
                    else
                    {
                        MessageBox.Show("Units for the EDP Code inputted cannot be found!");
                        return;
                    }

                    EnrollmentDataGridView.Rows[index].Cells["EDPCodeColumn"].Value = temp[0];
                    EnrollmentDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = temp[1];
                    EnrollmentDataGridView.Rows[index].Cells["StartTimeColumn"].Value = DateTime.Parse(temp[2]).ToString("hh:mm:tt");
                    EnrollmentDataGridView.Rows[index].Cells["EndTimeColumn"].Value = DateTime.Parse(temp[3]).ToString("hh:mm:tt");
                    EnrollmentDataGridView.Rows[index].Cells["DaysColumn"].Value = temp[4];
                    EnrollmentDataGridView.Rows[index].Cells["RoomColumn"].Value = temp[5];
                    
                    if (string.IsNullOrWhiteSpace(TotalUnitsLabel.Text)) 
                    {
                        TotalUnitsLabel.BackColor = Color.Silver;
                        TotalUnitsLabel.Text = "0";
                    }
                    int totalUnits = Convert.ToInt16(TotalUnitsLabel.Text);
                    totalUnits += units;
                    TotalUnitsLabel.Text = totalUnits.ToString();
                }
                else
                    MessageBox.Show("EDP code not found in the database");
            }
        }

        private void GetStudInfosFromDB()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            databaseHelper.dbConnection = new OleDbConnection(DatabaseHelper.connectionString);
            string query = "Select * From STUDENTFILE";
            databaseHelper.FetchDataFromDB(query, "STFSTUDID", "STFSTUDFNAME", "STFSTUDMNAME", "STFSTUDLNAME", "STFSTUDCOURSE", "STFSTUDYEAR");
            foreach (var resultArray in databaseHelper.resultListArray)
            {
                if (resultArray != null)
                {
                    studID.Add(resultArray[0]);
                    if (string.IsNullOrEmpty(resultArray[2]))
                        studName.Add(resultArray[1] + " " + resultArray[3]);
                    else
                        studName.Add(resultArray[1] + " " + resultArray[2] + ". " + resultArray[3]);
                    studCourse.Add(resultArray[4]);
                    studYear.Add(resultArray[5]);
                }
            }
        }

        private void EnrollmentEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedDirectly)
                Application.Exit();
        }

        private void subjectEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            SubjectEntryForm subjectEntryForm = new SubjectEntryForm();
            this.Hide();
            subjectEntryForm.Show();
            this.Close();
        }

        private void SubjectScheduleEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            SubjectScheduleEntryForm subjectScheduleEntryForm = new SubjectScheduleEntryForm();
            this.Hide();
            subjectScheduleEntryForm.Show();
            this.Close();
        }

        private void studentEntryToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void EnrollmentTablePanel_Click(object sender, EventArgs e)
        {
            if (!idFound)
                MessageBox.Show("Please make sure ID number is found");
        }

        private void EnrollmentTablePanel2_Click(object sender, EventArgs e)
        {
            if (!idFound)
                MessageBox.Show("Please make sure ID number is found");
        }

        private void FileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.White;
        }

        private void FileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            classroomCurrentSizes.Clear();
            TotalUnitsLabel.Text = null;
            TotalUnitsLabel.BackColor = Color.Gray;
            EnrollmentDataGridView.Rows.Clear();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            HomeForm homeForm = new HomeForm();
            this.Hide();
            homeForm.Show();
            this.Close();
        }
    }
}

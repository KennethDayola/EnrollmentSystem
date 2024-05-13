using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    //TODO: Add menu
    //TODO: Handle prequisite and co requisite in subject entry form by adding textboxes needed and also dgv there
    //TODO: Fix error trapping
    //TODO: When student has not taken a pre requisite subject do not allow them to take the subject when enrolled
    //TODO: Add curriculum code in requisite info for duplicate subjects
    //TODO: Add all entries to database in this form
    public partial class EnrollmentEntryForm : Form
    {
        bool closedDirectly = true;
        bool idFound = false;

        List<int> classroomCurrentSizes = new List<int>();

        // student information
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
            if (string.IsNullOrWhiteSpace(EncodedTextBox.Text))
            {
                MessageBox.Show("The \"Encoded by:\" field is empty");
                return;
            }

            //Recording enrollment detail file
            DatabaseHelper databaseHelperDF = new DatabaseHelper();
            databaseHelperDF.ConnectToDatabase("Select * From ENROLLMENTDETAILFILE");

            for (int i = 0; i < EnrollmentDataGridView.RowCount - 1; i++)
            {
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

            //Recording enrollment header file
            DatabaseHelper databaseHelperHF = new DatabaseHelper();
            databaseHelperHF.ConnectToDatabase("Select * From ENROLLMENTHEADERFILE");

            DataSet thisDatasetHF = new DataSet();
            databaseHelperDF.dbDataAdapter.Fill(thisDatasetHF, "EnrollmentHeaderFile");

            DataRow thisRowHF = thisDatasetHF.Tables["EnrollmentHeaderFile"].NewRow();
            thisRowHF["ENRHFSTUDID"] = IDNumberTextBox.Text;
            thisRowHF["ENRHFSTUDDATEENROLL"] = EnrollmentDateTimePicker.Value;
            thisRowHF["ENRHFSTUDSCHLYR"] = YearLabel.Text; 
            thisRowHF["ENRHFSTUDENCODER"] = EncodedTextBox.Text; 
            thisRowHF["ENRHFSTUDTOTALUNITS"] = TotalUnitsLabel.Text; 
            thisRowHF["ENRHFSTUDSTATUS"] = "EN"; 

            thisDatasetHF.Tables["EnrollmentHeaderFile"].Rows.Add(thisRowHF);
            databaseHelperDF.dbDataAdapter.Update(thisDatasetHF, "EnrollmentHeaderFile");

            //Updating class size
            DatabaseHelper databaseHelperSSF = new DatabaseHelper();
            databaseHelperSSF.ConnectToDatabase("Select * From SubjectSchedFile");

            DataSet thisDatasetSSF = new DataSet();
            databaseHelperSSF.dbDataAdapter.Fill(thisDatasetSSF, "SubjectSchedFile");
            
            //wtf tabang tug sa ko
            //for (int i = 0; i < EnrollmentDataGridView.RowCount - 1; i++)
            //{
            //    foreach (DataRow row in thisDatasetSSF.Tables["SubjectSchedFile"].Rows)
            //    {
            //        if (row["SSFEDPCODE"].ToString().Trim() == EnrollmentDataGridView.Rows[i].Cells["EDPCodeColumn"].Value.ToString().Trim())
            //        {
            //            OleDbCommand updateCommand = databaseHelperSSF.dbConnection.CreateCommand();
            //            updateCommand.CommandText = "UPDATE SubjectSchedFile SET SSFCLASSSIZE = @ClassSize WHERE SSFEDPCODE = @EDPCode";
            //            updateCommand.Parameters.AddWithValue("@ClassSize", "YourValue"); 
            //            updateCommand.Parameters.AddWithValue("@EDPCode", row["SSFEDPCODE"].ToString().Trim());
            //            updateCommand.ExecuteNonQuery();
            //            updateCommand.Dispose();
            //            break;
            //        }
            //    }
            //}
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
                    classroomCurrentSizes.Add(currentSize++);

                    //Checks if there is a conflict in schedules
                    string filteredCurrentStartTime = new string(DateTime.Parse(temp[2]).ToString("hh:mm:tt").Where(c => char.IsDigit(c)).ToArray());
                    int parsedCurrentStartTime = int.Parse(filteredCurrentStartTime);
                    string filteredCurrentEndTime = new string(DateTime.Parse(temp[3]).ToString("hh:mm:tt").Where(c => char.IsDigit(c)).ToArray());
                    int parsedCurrentEndTime = int.Parse(filteredCurrentEndTime);
                    for (int i = 0; i < EnrollmentDataGridView.Rows.Count - 1; i++)
                    {
                        string enteredStartTime = EnrollmentDataGridView.Rows[i].Cells["StartTimeColumn"].Value.ToString();
                        string filteredStartTime = new string(enteredStartTime.Where(char.IsDigit).ToArray());
                        int parsedStartTime = int.Parse(filteredStartTime);

                        string enteredEndTime = EnrollmentDataGridView.Rows[i].Cells["EndTimeColumn"].Value.ToString();
                        string filteredEndTime = new string(enteredEndTime.Where(char.IsDigit).ToArray());
                        int parsedEndTime = int.Parse(filteredEndTime);

                        if ((parsedStartTime <= parsedCurrentStartTime && parsedEndTime >= parsedCurrentStartTime)
                            || (parsedStartTime <= parsedCurrentEndTime && parsedEndTime >= parsedCurrentEndTime))
                        {
                            MessageBox.Show("New subject entry with the start time of \"" + DateTime.Parse(temp[2]).ToString("hh:mm:tt")
                                + "\" and end time of \"" + DateTime.Parse(temp[3]).ToString("hh:mm:tt")
                                + "\" conflicts with an existing entry with a start time of \"" + EnrollmentDataGridView.Rows[i].Cells["StartTimeColumn"].Value.ToString()
                                + "\" and end time of \"" + EnrollmentDataGridView.Rows[i].Cells["EndTimeColumn"].Value.ToString() + "\"");
                            return;
                        }
                    }

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
            
            studID.Add(databaseHelper.resultList[0]);
            if (string.IsNullOrEmpty(databaseHelper.resultList[2]))
            {
                studName.Add(databaseHelper.resultList[1] + " " + databaseHelper.resultList[3]);
            }
            else
                studName.Add(databaseHelper.resultList[1] + " " + databaseHelper.resultList[2] + ". " + databaseHelper.resultList[3]);
            studCourse.Add(databaseHelper.resultList[4]);
            studYear.Add(databaseHelper.resultList[5]);
            
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
            TotalUnitsLabel.Text = null;
            TotalUnitsLabel.BackColor = Color.Gray;
            EnrollmentDataGridView.Rows.Clear();
        }
    }
}

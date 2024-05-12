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
    public partial class EnrollmentEntryForm : Form
    {
        bool closedDirectly = true;
        bool idFound = false;
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
                    "SSFSUBJCODE", "SSFSTARTTIME", "SSFENDTIME", "SSFDAYS", "SSFROOM"))
                {
                    List<string[]> temp = new List<string[]>();
                    foreach (string[] result in databaseHelper.resultList)
                    {
                        temp.Add(result);
                    }

                    int units = 0;
                    if (databaseHelper.CheckAndFetchFromDB(temp[0][1], "SFSUBJCODE", "Select * From SUBJECTFILE", "SFSUBJUNITS"))
                    {
                        index = EnrollmentDataGridView.Rows.Add();
                        foreach (string[] result in databaseHelper.resultList)
                        {
                            MessageBox.Show(result[2]);
                            EnrollmentDataGridView.Rows[index].Cells["UnitsColumn"].Value = result[2];
                            units = Convert.ToInt16(EnrollmentDataGridView.Rows[index].Cells["UnitsColumn"].Value);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Units for the EDP Code inputted cannot be found!");
                        return;
                    }

                    foreach (string[] result in temp)
                    {
                        EnrollmentDataGridView.Rows[index].Cells["EDPCodeColumn"].Value = result[0];
                        EnrollmentDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = result[1];
                        EnrollmentDataGridView.Rows[index].Cells["StartTimeColumn"].Value = DateTime.Parse(result[2]).ToString("hh:mm:tt");
                        EnrollmentDataGridView.Rows[index].Cells["EndTimeColumn"].Value = DateTime.Parse(result[3]).ToString("hh:mm:tt");
                        EnrollmentDataGridView.Rows[index].Cells["DaysColumn"].Value = result[4];
                        EnrollmentDataGridView.Rows[index].Cells["RoomColumn"].Value = result[5];
                    }
 
                    if (!string.IsNullOrWhiteSpace(TotalUnitsLabel.Text)) 
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
            foreach (string[] row in databaseHelper.resultList)
            {
                studID.Add(row[0]);
                if (string.IsNullOrEmpty(row[1]))
                {
                    studName.Add(row[1] + " " + row[3]);
                }
                else
                    studName.Add(row[1] + " " + row[2] + ". " + row[3]);
                studCourse.Add(row[4]);
                studYear.Add(row[5]);
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
            TotalUnitsLabel.Text = null;
            TotalUnitsLabel.BackColor = Color.Gray;
            EnrollmentDataGridView.Rows.Clear();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EnrollmentDataGridView.RowCount.ToString());
        }
    }
}

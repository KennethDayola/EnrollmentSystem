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

namespace EnrollmentSystem
{
    public partial class SubjectEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\johnk\source\repos\EnrollmentSystem\Dayola.accdb";
        bool closedDirectly = true;
        public SubjectEntry()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateClrMethods.AreTextBoxesEmpty(SubjectCodeTextBox, DescriptionTextBox, UnitsTextBox, CurriculumYearTextBox) ||
                ValidateClrMethods.AreComboBoxesEmpty(OfferingComboBox, CategoryComboBox, CourseCodeComboBox))
            {
                MessageBox.Show("Please fill out all required fields before proceeding");
                return;
            }

            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string Ole = "Select * From SUBJECTFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
            
            thisConnection.Open();
            OleDbCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandText = Ole;
            OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
            while (thisDataReader.Read())
            {
                if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextBox.Text.Trim().ToUpper())
                {
                    MessageBox.Show("Current subject code is already on the database");
                    return;
                }
            }
            thisConnection.Close();

            DataSet thisDataset = new DataSet();
            thisAdapter.Fill(thisDataset, "SubjectFile");

            DataRow thisRow = thisDataset.Tables["SubjectFile"].NewRow();
            thisRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;
            thisRow["SFSUBJUNITS"] = UnitsTextBox.Text;
            thisRow["SFSUBJREGOFRNG"] = Convert.ToSingle(OfferingComboBox.Text.Substring(0, 1));
            thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 1);
            thisRow["SFSUBJSTATUS"] = "AC";
            thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
            thisRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

            thisDataset.Tables["SubjectFile"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataset, "SubjectFile");

            MessageBox.Show("Recorded");
        }

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                for (int i = 0; i < SubjectDataGridView.RowCount - 1; i++)
                {
                    if (SubjectDataGridView.Rows[i].Cells["SubjectCodeColumn"].Value.ToString().Trim().ToUpper() == RequisiteTextBox.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("Current subject code already on the data grid");
                        return;
                    }
                }

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();

                OleDbCommand thisCommand = thisConnection.CreateCommand();
                // string sql = "SELECT * SUBJECTFILE";
                thisCommand.CommandText = "SELECT * from SUBJECTFILE";

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
                bool found = false;
                string subjectCode = "";
                string description = "";
                string units = "";

                while (thisDataReader.Read())
                {
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == RequisiteTextBox.Text.Trim().ToUpper())
                    {
                        found = true;
                        subjectCode = thisDataReader["SFSUBJCODE"].ToString();
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        units = thisDataReader["SFSUBJUNITS"].ToString();
                        break;
                    }
                }

                int index;
                if (found == false)
                    MessageBox.Show("Subject Code Not Found");
                else
                {
                    index = SubjectDataGridView.Rows.Add();
                    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjectCode;
                    SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = description;
                    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = units;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ValidateClrMethods.ClearTextBoxes(SubjectCodeTextBox, DescriptionTextBox, UnitsTextBox, CurriculumYearTextBox);
            ValidateClrMethods.ClearComboBoxes(OfferingComboBox, CategoryComboBox, CourseCodeComboBox);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void FileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            FileToolStripMenuItem.ForeColor = Color.White;
        }

        private void SubjectScheduleEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            SubjectScheduleEntry subjectScheduleEntry = new SubjectScheduleEntry();
            this.Hide();
            subjectScheduleEntry.Show();
            this.Close();
        }

        private void studentEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            StudentEntry studentEntry = new StudentEntry();
            this.Hide();
            studentEntry.Show();
            this.Close();
        }

        private void SubjectEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedDirectly)
                Application.Exit();
        }
    }
 }

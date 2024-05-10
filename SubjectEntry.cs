using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        bool closedDirectly = true;
        string query = "Select * From SUBJECTFILE";
        public SubjectEntry()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            if (ValidateClrMethods.AreTextBoxesEmpty(SubjectCodeTextBox, DescriptionTextBox, UnitsTextBox, CurriculumYearTextBox) ||
                ValidateClrMethods.AreComboBoxesEmpty(OfferingComboBox, CategoryComboBox, CourseCodeComboBox))
            {
                MessageBox.Show("Please fill out all required fields before proceeding");
                return;
            }
            if (!int.TryParse(UnitsTextBox.Text, out _) || UnitsTextBox.Text.Length > 1)
            {
                MessageBox.Show("Units must be an integer and in single digits only");
                return;
            }

            databaseHelper.ConnectToDatabase(query);

            if (databaseHelper.CheckIfDataInDB(SubjectCodeTextBox.Text, "SFSUBJCODE", query))
            {
                MessageBox.Show("Current subject code is already in the database");
                return;
            }

            DataSet thisDataset = new DataSet();
            databaseHelper.dbDataAdapter.Fill(thisDataset, "SubjectFile");

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
            databaseHelper.dbDataAdapter.Update(thisDataset, "SubjectFile");

            MessageBox.Show("Recorded");
        }

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidateClrMethods.CheckIfDataInDGV(RequisiteTextBox.Text, SubjectDataGridView, "SubjectCodeColumn"))
                {
                    MessageBox.Show("Current subject code is already in the data grid");
                    return;
                }

                DatabaseHelper databaseHelper = new DatabaseHelper();
                databaseHelper.dbConnection = new OleDbConnection(DatabaseHelper.connectionString);

                int index;
                if (databaseHelper.CheckAndFetchFromDB(RequisiteTextBox.Text, "SFSUBJCODE", query, "SFSUBJDESC", "SFSUBJUNITS"))
                {
                    index = SubjectDataGridView.Rows.Add();
                    foreach (string[] result in databaseHelper.resultList)
                    {
                        SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = result[0];
                        SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = result[1];
                        SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = result[2];
                    }
                }
                else
                    MessageBox.Show("Subject Code Not Found");
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

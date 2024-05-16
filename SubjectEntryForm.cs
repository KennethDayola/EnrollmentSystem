using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnrollmentSystem
{
    public partial class SubjectEntryForm : Form
    {    
        bool closedDirectly = true;
        string query = "Select * From SUBJECTFILE";
        public SubjectEntryForm()
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
                MessageBox.Show("Units field must be an integer and in single digits only");
                return;
            }

            databaseHelper.ConnectToDatabase(query);

            if (databaseHelper.CheckIfDataInDB(SubjectCodeTextBox.Text, "SFSUBJCODE", query) 
                && databaseHelper.CheckIfDataInDB(CourseCodeComboBox.Text, "SFSUBJCOURSECODE", query))
            {
                MessageBox.Show("Current subject code with corresponding course code is already in the database");
                return;
            }

            DataSet thisDataset = new DataSet();
            databaseHelper.dbDataAdapter.Fill(thisDataset, "SubjectFile");

            DataRow thisRow = thisDataset.Tables["SubjectFile"].NewRow();
            thisRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;
            thisRow["SFSUBJUNITS"] = UnitsTextBox.Text;
            thisRow["SFSUBJREGOFRNG"] = Convert.ToSingle(OfferingComboBox.Text.Substring(0, 1));
            thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 3);
            thisRow["SFSUBJSTATUS"] = "AC";
            thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
            thisRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

            thisDataset.Tables["SubjectFile"].Rows.Add(thisRow);
            databaseHelper.dbDataAdapter.Update(thisDataset, "SubjectFile");

            MessageBox.Show("Recorded");
        }

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // FIX - what if 2 of the same subjcode but diff currcode when pressing enter in textbox
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
                databaseHelper.FetchDataFromDB(query, "SFSUBJCODE", "SFSUBJDESC", "SFSUBJUNITS", "SFSUBJCOURSECODE");

                List<string> subjCodes = databaseHelper.resultListArray[0].ToList();
                List<string> subjDescs = databaseHelper.resultListArray[1].ToList();
                List<string> subjUnits = databaseHelper.resultListArray[2].ToList();
                List<string> subjCourseCode = databaseHelper.resultListArray[3].ToList();

                int count = 0;
                for (int i = 0; i < subjCodes.Count; i++)
                {
                    if (RequisiteTextBox.Text == subjCodes[i])
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("Subject Code Not Found");
                    return;
                }
                else
                {

                }
                //if (databaseHelper.CheckAndFetchFromDB(RequisiteTextBox.Text, "SFSUBJCODE", query, "SFSUBJDESC", "SFSUBJUNITS"))
                //{
                //    index = SubjectDataGridView.Rows.Add();
                //    SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = databaseHelper.resultList[0];
                //    SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = databaseHelper.resultList[1];
                //    SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = databaseHelper.resultList[2];
                //}
                //else
                //    MessageBox.Show("Subject Code Not Found");
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

        private void SubjectEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedDirectly)
                Application.Exit();
        }

        private void enrollmentEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            EnrollmentEntryForm enrollmentEntryForm = new EnrollmentEntryForm();
            this.Hide();
            enrollmentEntryForm.Show();
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            HomeForm homeForm = new HomeForm();
            this.Hide();
            homeForm.Show();
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            RequisiteTextBoxToolTip.Show("Press Enter to display subject information" +
                ", otherwise fill up this field and \nclick a radio button to input the requisite subject for the subject code above", RequisitePromptPicBox);
        }
    }
 }

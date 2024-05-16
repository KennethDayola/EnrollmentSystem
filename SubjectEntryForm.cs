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

        List<string> subjCodes = new List<string>();
        List<string> subjDescs = new List<string>();
        List<string> subjUnits = new List<string>();
        List<string> subjCourseCode = new List<string>();
        List<string> subjRequisiteCategory = new List<string>();
        List<string> subjRequisiteSubj = new List<string>();
        public SubjectEntryForm()
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
            if (!int.TryParse(UnitsTextBox.Text, out _) || UnitsTextBox.Text.Length > 1)
            {
                MessageBox.Show("Units field must be an integer and in single digits only");
                return;
            }
            
            DatabaseHelper databaseHelperSF = new DatabaseHelper();
            databaseHelperSF.ConnectToDatabase(query);

            //if (databaseHelperSF.CheckIfDataInDB(SubjectCodeTextBox.Text, "SFSUBJCODE", query)
            //    && databaseHelperSF.CheckIfDataInDB(CourseCodeComboBox.Text, "SFSUBJCOURSECODE", query))
            if (databaseHelperSF.CheckIfDataInDBTwoKeys(SubjectCodeTextBox.Text, CourseCodeComboBox.Text, "SFSUBJCODE"
                , "SFSUBJCOURSECODE", query))
            {
                MessageBox.Show("Current subject code with corresponding course code is already in the database");
                return;
            }

            DatabaseHelper databaseHelperReq = new DatabaseHelper();
            databaseHelperReq.ConnectToDatabase("Select * From SUBJECTPREQFILE");

            if (!string.IsNullOrWhiteSpace(RequisiteTextBox.Text))
            {
                if (databaseHelperSF.CheckIfDataInDB(SubjectCodeTextBox.Text, "SUBJCODE", "Select * From SUBJECTPREQFILE"))
                {
                    MessageBox.Show("Current subject code already has requisite data in the database");
                    return;
                }
                if (!(PreRequisiteRadio.Checked || CoRequisiteRadio.Checked))
                {
                    MessageBox.Show("Please check either the pre requisite radio or the co requisite radio");
                    return;
                }
            }

            DataSet thisDatasetSF = new DataSet();
            databaseHelperSF.dbDataAdapter.Fill(thisDatasetSF, "SubjectFile");

            DataRow thisRowSF = thisDatasetSF.Tables["SubjectFile"].NewRow();
            thisRowSF["SFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRowSF["SFSUBJDESC"] = DescriptionTextBox.Text;
            thisRowSF["SFSUBJUNITS"] = UnitsTextBox.Text;
            thisRowSF["SFSUBJREGOFRNG"] = Convert.ToSingle(OfferingComboBox.Text.Substring(0, 1));
            thisRowSF["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 3);
            thisRowSF["SFSUBJSTATUS"] = "AC";
            thisRowSF["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
            thisRowSF["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

            thisDatasetSF.Tables["SubjectFile"].Rows.Add(thisRowSF);
            databaseHelperSF.dbDataAdapter.Update(thisDatasetSF, "SubjectFile");

            if (!string.IsNullOrWhiteSpace(RequisiteTextBox.Text))
            {
                DataSet thisDataSetReq = new DataSet();
                databaseHelperReq.dbDataAdapter.Fill(thisDataSetReq, "SubjectPreqFile");

                DataRow thisRowReq = thisDataSetReq.Tables["SubjectPreqFile"].NewRow();
                thisRowReq["SUBJCODE"] = SubjectCodeTextBox.Text;
                thisRowReq["SUBJPRECODE"] = RequisiteTextBox.Text;
                if (PreRequisiteRadio.Checked)
                    thisRowReq["SUBJCATEGORY"] = "PR";
                else if (CoRequisiteRadio.Checked)
                    thisRowReq["SUBJCATEGORY"] = "CR";

                thisDataSetReq.Tables["SubjectPreqFile"].Rows.Add(thisRowReq);
                databaseHelperReq.dbDataAdapter.Update(thisDataSetReq, "SubjectPreqFile");
            }

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
                databaseHelper.FetchDataFromDB(query, "SFSUBJCODE", "SFSUBJDESC", "SFSUBJUNITS", "SFSUBJCOURSECODE");

                subjCodes.Clear();
                subjDescs.Clear();
                subjUnits.Clear();
                subjCourseCode.Clear();
                foreach (var resultArray in databaseHelper.resultListArray)
                {
                    if (resultArray != null)
                    {
                        subjCodes.Add(resultArray[0]);
                        subjDescs.Add(resultArray[1]);
                        subjUnits.Add(resultArray[2]);
                        subjCourseCode.Add(resultArray[3]);
                    }
                }

                if (subjCodes.Count == 0)
                {
                    MessageBox.Show("Subject database currently empty. Please enter some data first");
                    return;
                }

                bool found = false;
                for (int i = 0; i < subjCodes.Count; i++)
                {
                    if (RequisiteTextBox.Text.Trim().ToUpper() == subjCodes[i].Trim().ToUpper())
                    {
                        found = true;
                        index = SubjectDataGridView.Rows.Add();
                        SubjectDataGridView.Rows[index].Cells["SubjectCodeColumn"].Value = subjCodes[i];
                        SubjectDataGridView.Rows[index].Cells["DescriptionColumn"].Value = subjDescs[i];
                        SubjectDataGridView.Rows[index].Cells["UnitsColumn"].Value = subjUnits[i];
                        SubjectDataGridView.Rows[index].Cells["CourseCodeColumn"].Value = subjCourseCode[i];

                        if (databaseHelper.CheckAndFetchFromDB(subjCodes[i], "SUBJCODE", "Select * From SUBJECTPREQFILE", "SUBJPRECODE", "SUBJCATEGORY"))
                        {
                            SubjectDataGridView.Rows[index].Cells["CoPreRequisiteColumn"].Value = databaseHelper.resultList[2];
                            SubjectDataGridView.Rows[index].Cells["RequisiteSubjectColumn"].Value = databaseHelper.resultList[1];
                        }
                        else
                        {
                            SubjectDataGridView.Rows[index].Cells["CoPreRequisiteColumn"].Value = "N/A";
                            SubjectDataGridView.Rows[index].Cells["RequisiteSubjectColumn"].Value = "N/A";
                        }
                    }
                }
                if (!found)
                    MessageBox.Show("Subject Code Not Found");

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

        private void RequisitePromptPicBox_MouseHover(object sender, EventArgs e)
        {
            RequisiteTextBoxToolTip.Show("Press Enter to display subject information" +
                ", otherwise fill up this field and \nclick a radio button to input the requisite subject for the subject code above", RequisitePromptPicBox);
        }
    }
 }

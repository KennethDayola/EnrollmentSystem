using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    internal class ValidateClrMethods
    {
            /// <summary>
            /// returns true if textboxes are empty
            /// </summary>
            /// <param name="textBoxes">The textboxes to check.</param>
            /// <returns>True if a textbox are empty, otherwise false.</returns>
            public static bool AreTextBoxesEmpty(params TextBox[] textBoxes)
            {
                foreach (var textBox in textBoxes)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text)) return true;
                }
                return false;
            }

            /// <summary>
            /// returns true if combo boxes are empty
            /// </summary>
            /// <param name="comboBoxes">The combo boxes to check.</param>
            /// <returns>True if a combo box is empty, otherwise false.</returns>
            public static bool AreComboBoxesEmpty(params ComboBox[] comboBoxes)
                {
                foreach(var comboBox in comboBoxes)
                {
                    if (comboBox.SelectedIndex == -1) return true;
                }
                return false;
            }

            /// <summary>
            /// clears textboxes
            /// </summary>
            /// <param name="textBoxes">The textboxes to clear</param>
            public static void ClearTextBoxes(params TextBox[] textBoxes)
            {
                foreach (var textBox in textBoxes)
                {
                    textBox.Text = null; 
                }
            }

            /// <summary>
            /// clears combo boxes
            /// </summary>
            /// <param name="comboBoxes">The comboboxes to clear</param>
            public static void ClearComboBoxes(params ComboBox[] comboBoxes)
            {
                foreach (var comboBox in comboBoxes)
                {
                    comboBox.SelectedIndex = -1;
                }
            }

            /// <summary>
            /// checks if specified data is already in the data grid view
            /// </summary>
            /// <param name="value">The data to search for.</param>
            /// <param name="dgv">The DataGridView to search.</param>
            /// <param name="column">The name of the column to search in.</param>
            /// <returns>True if the data is found, otherwise false.</returns>
            public static bool CheckIfDataInDGV(string value, DataGridView dgv, string column)
            {
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    if (dgv.Rows[i].Cells[column].Value.ToString().Trim().ToUpper() == value.Trim().ToUpper())
                    {
                        return true;
                    }
                }
                return false;
            }
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    internal class HelpMethods
    {
        /// <summary>
        /// returns true if textboxes are empty
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns></returns>
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
        /// <param name="comboBoxes"></param>
        /// <returns></returns>
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
        /// <param name="textBoxes"></param>
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
        /// <param name="comboBoxes"></param>
        public static void ClearComboBoxes(params ComboBox[] comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                comboBox.SelectedIndex = -1;
            }
        }
    }
}

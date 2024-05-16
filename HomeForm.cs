using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class HomeForm : Form
    {
        bool closedDirectly = true;
        public HomeForm()
        {
            InitializeComponent();
            ProceedMenuStrip.Renderer = new MyRenderer();
            ExitMenuStrip.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected || e.Item.Pressed)
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(21, 21, 22)))
                    {
                        e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Transparent; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Transparent; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.Transparent; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return Color.FromArgb(21, 21, 22); }
            }
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedDirectly)
                Application.Exit();
        }

        private void ProceedToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                if (menuItem == ProceedToolStripMenuItem)
                {
                    menuItem.ForeColor = Color.Gray;
                }
            }
        }

        private void ProceedToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                if (menuItem == ProceedToolStripMenuItem)
                {
                    menuItem.ForeColor = Color.White;
                }
            }
        }

        private void ExitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                if (menuItem == ExitToolStripMenuItem)
                {
                    menuItem.ForeColor = Color.Gray;
                }
            }
        }

        private void ExitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                if (menuItem == ExitToolStripMenuItem)
                {
                    menuItem.ForeColor = Color.White;
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void enrollmentEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closedDirectly = false;
            EnrollmentEntryForm enrollmentEntryForm = new EnrollmentEntryForm();
            this.Hide();
            enrollmentEntryForm.Show();
            this.Close();
        }
    }
}

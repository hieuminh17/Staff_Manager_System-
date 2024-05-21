using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management_System
{
    public partial class dash_boad : Form
    {
        public dash_boad()
        {
            InitializeComponent();
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Add_Employee"] == null)
            {
                
                Add_Employee v = new Add_Employee();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Add_Employee"].Activate();
            this.BringToFront();
        }
        private void ShowForm(string formName, Type formType)
        {
            if (Application.OpenForms[formName] == null)
            {
                Form v = (Form)Activator.CreateInstance(formType);
                v.MdiParent = this.MdiParent; // This ensures that the parent is the main MDI form
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else
            {
                Application.OpenForms[formName].Activate();
            }
        }
        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Add_Employee", typeof(Add_Employee));
        }
    }
}

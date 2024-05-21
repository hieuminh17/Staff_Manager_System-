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
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["dash_boad"] == null)
            {

                dash_boad v = new dash_boad();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["dash_boad"].Activate();
        }

        private void btn_vacation_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Vacationday"] == null)
            {
                Vacationday v = new Vacationday();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Vacationday"].Activate();
        }

        private void btn_average_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Average_benefits"] == null)
            {
                Average_benefits v = new Average_benefits();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Average_benefits"].Activate();
        }

        private void btn_hiring_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Hiring_Aniversary"] == null)
            {
                Hiring_Aniversary v = new Hiring_Aniversary();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Hiring_Aniversary"].Activate();
        }

        private void btn_Accumulator_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Accumulator_Days"] == null)
            {
                Accumulator_Days v = new Accumulator_Days();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Accumulator_Days"].Activate();
        }

        private void btn_plans_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Benefits_Plan"] == null)
            {
                Benefits_Plan v = new Benefits_Plan();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Benefits_Plan"].Activate();
        }

        private void btn_birthday_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Birthday"] == null)
            {
                Birthday v = new Birthday();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Birthday"].Activate();
        }

        private void btn_Total_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Total_earning"] == null)
            {
                Total_earning v = new Total_earning();
                v.MdiParent = this;
                v.WindowState = FormWindowState.Maximized;
                v.FormBorderStyle = FormBorderStyle.None; // or FormBorderStyle.FixedSingle
                v.TopMost = true;
                v.Show();
            }
            else Application.OpenForms["Total_earning"].Activate();
        }
    }
}

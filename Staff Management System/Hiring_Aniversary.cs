using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Staff_Management_System
{
    public partial class Hiring_Aniversary : Form
    {
        String conectString = @"Data Source=LAPTOP-KP432QPH\SQLEXPRESS02;Initial Catalog=HRM;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        public Hiring_Aniversary()
        {
            InitializeComponent();
        }

        private void Hiring_Aniversary_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conectString);
            con.Open();
            //TRUY VAN CSDL
            cmd = new SqlCommand("select e.EMPLOYMENT_ID, emp.First_Name, emp.Last_Name, j.DEPARTMENT,e.REHIRE_DATE_FOR_WORKING from PERSONAL p, openquery(MySql, 'Select *from employee') emp, JOB_HISTORY j, EMPLOYMENT e where p.PERSONAL_ID = emp.idEmployee and p.PERSONAL_ID = e.PERSONAL_ID and j.EMPLOYMENT_ID = e.EMPLOYMENT_ID   ", con);
            adt = new SqlDataAdapter(cmd);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Font chữ cho tiêu đề cột
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear(); // Clear the DataTable
            dataGridView1.DataSource = dt;
            con = new SqlConnection(conectString);
            con.Open();
            //TRUY VAN CSDL
            cmd = new SqlCommand("select e.EMPLOYMENT_ID, emp.First_Name, emp.Last_Name, j.DEPARTMENT,e.REHIRE_DATE_FOR_WORKING from PERSONAL p, openquery(MySql, 'Select *from employee') emp, JOB_HISTORY j, EMPLOYMENT e where p.PERSONAL_ID = emp.idEmployee and p.PERSONAL_ID = e.PERSONAL_ID and j.EMPLOYMENT_ID = e.EMPLOYMENT_ID and Year(e.REHIRE_DATE_FOR_WORKING) = @Search  ", con);
            cmd.Parameters.AddWithValue("@Search", dateTimePicker1.Value.Year);
            adt = new SqlDataAdapter(cmd);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Font chữ cho tiêu đề cột
            con.Close();
        }
    }
}

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
    public partial class Accumulator_Days : Form
    {
        String conectString = @"Data Source=LAPTOP-KP432QPH\SQLEXPRESS02;Initial Catalog=HRM;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        public Accumulator_Days()
        {
            InitializeComponent();
        }

        private void Accumulator_Days_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conectString);
            con.Open();
            //TRUY VAN CSDL
            cmd = new SqlCommand("select EMPLOYMENT_ID,  SUM(Vacation_Day) as Vacation_Day from vacation_days group by EMPLOYMENT_ID   ", con);
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
            cmd = new SqlCommand("Select * from vacation_days where EMPLOYMENT_ID = @Search ", con);
            cmd.Parameters.AddWithValue("@Search", txt_Search.Text);
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

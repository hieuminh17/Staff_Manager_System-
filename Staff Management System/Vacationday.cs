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
    public partial class Vacationday : Form
    {
        String conectString = @"Data Source=LAPTOP-KP432QPH\SQLEXPRESS02;Initial Catalog=HRM;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        public Vacationday()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Vacationday_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conectString);
            con.Open();
            //TRUY VAN CSDL
            cmd = new SqlCommand("select E.EMPLOYMENT_ID,emp.Last_Name as Name,P.SHAREHOLDER_STATUS,P.CURRENT_GENDER,P.ETHNICITY,E.EMPLOYMENT_STATUS,365-(W.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH*W.MONTH_WORKING) as Vacation_Day, W.YEAR_WORKING from EMPLOYMENT_WORKING_TIME W, EMPLOYMENT E, PERSONAL P JOIN openquery(MySql, 'Select *from employee') emp ON  emp.idEmployee = p.PERSONAL_ID where P.PERSONAL_ID = E.PERSONAL_ID and E.EMPLOYMENT_ID = W.EMPLOYMENT_ID  ", con);
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
            cmd = new SqlCommand("select E.EMPLOYMENT_ID,emp.Last_Name as Name,P.SHAREHOLDER_STATUS,P.CURRENT_GENDER,P.ETHNICITY,E.EMPLOYMENT_STATUS,365-(W.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH*W.MONTH_WORKING) as Vacation_Day, W.YEAR_WORKING from EMPLOYMENT_WORKING_TIME W, EMPLOYMENT E, PERSONAL P JOIN openquery(MySql, 'Select *from employee') emp ON  emp.idEmployee = p.PERSONAL_ID where P.PERSONAL_ID = E.PERSONAL_ID and E.EMPLOYMENT_ID = W.EMPLOYMENT_ID and E.EMPLOYMENT_ID=@Search   ", con);
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            
        }
    }
}

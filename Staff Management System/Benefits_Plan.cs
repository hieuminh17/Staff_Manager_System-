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
    public partial class Benefits_Plan : Form
    {
       
        String conectString = @"Data Source=LAPTOP-KP432QPH\SQLEXPRESS02;Initial Catalog=HRM;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        
        public Benefits_Plan()
        {
            InitializeComponent();
        }

        private void Benefits_Plan_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(conectString);
            con.Open();
            //TRUY VAN CSDL
            cmd = new SqlCommand("SELECT p.PERSONAL_ID,  emp.First_Name,emp.Last_Name,j.DEPARTMENT,b.PLAN_NAME,b.DEDUCTABLE FROM JOB_HISTORY j, BENEFIT_PLANS b, EMPLOYMENT e, PERSONAL p  JOIN openquery(MySql, 'Select *from employee') emp ON  emp.idEmployee = p.PERSONAL_ID  where p.PERSONAL_ID=e.PERSONAL_ID and e.EMPLOYMENT_ID=j.EMPLOYMENT_ID and b.BENEFIT_PLANS_ID=p.BENEFIT_PLAN_ID;  ", con);
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
            cmd = new SqlCommand("SELECT p.PERSONAL_ID,  emp.First_Name,emp.Last_Name,j.DEPARTMENT,b.PLAN_NAME,b.DEDUCTABLE FROM JOB_HISTORY j, BENEFIT_PLANS b, EMPLOYMENT e, PERSONAL p  JOIN openquery(MySql, 'Select *from employee') emp ON  emp.idEmployee = p.PERSONAL_ID  where p.PERSONAL_ID=e.PERSONAL_ID and e.EMPLOYMENT_ID=j.EMPLOYMENT_ID and b.BENEFIT_PLANS_ID=p.BENEFIT_PLAN_ID and (p.CURRENT_LAST_NAME=@Search or p.PERSONAL_ID=@Search);   ", con);
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
            // Start a transaction to ensure data consistency
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Get the updated DataTable from the DataGridView
                DataTable updatedTable = (DataTable)dataGridView1.DataSource;

                // Create a MySqlCommandBuilder to generate the UPDATE, INSERT, and DELETE commands
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adt);

                // Update the database using the MySqlDataAdapter's Update method
                adt.Update(updatedTable);

                // Commit the transaction
                transaction.Commit();
                MessageBox.Show("Changes saved successfully!");
            }
            catch (Exception ex)
            {
                // Rollback the transaction in case of an error
                transaction.Rollback();
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

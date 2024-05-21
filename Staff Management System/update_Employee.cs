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
    
    public partial class update_Employee : Form
    {
        String conectString = @"Data Source=LAPTOP-KP432QPH\SQLEXPRESS02;Initial Catalog=HRM;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        public update_Employee()
        {
            InitializeComponent();
        }

        private void update_Employee_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conectString);
            con.Open();
            //TRUY VAN CSDL
            cmd = new SqlCommand("Select * from PERSONAL  ", con);
            adt = new SqlDataAdapter(cmd);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Font chữ cho tiêu đề cột
            con.Close();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            dt.Clear(); // Clear the DataTable
            dataGridView1.DataSource = dt;

            con = new SqlConnection(conectString);
            con.Open();
            cmd = new SqlCommand("SELECT *from PERSONAL where   PERSONAL_ID=@Search  ", con);
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        SqlCommand cmd = CreateUpdateCommand(row, con, transaction);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected <= 0)
                        {
                            string PersonalID = Convert.ToString(row.Cells["PersonalID"].Value);
                            MessageBox.Show("Failed to update record for PersonalID: " + PersonalID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            transaction.Rollback();
                            return;
                        }
                    }
                }

                transaction.Commit();
                MessageBox.Show("Changes saved successfully!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error updating records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private SqlCommand CreateUpdateCommand(DataGridViewRow row, SqlConnection con, SqlTransaction transaction)
        {
            string query = @"UPDATE PERSONAL SET 
                        CURRENT_FIRST_NAME = @FirstName, 
                        CURRENT_LAST_NAME = @LastName, 
                        CURRENT_MIDDLE_NAME = @MiddleName, 
                        BIRTH_DATE = @Birthday, 
                        SOCIAL_SECURITY_NUMBER = @SocialSecurityNumber, 
                        DRIVERS_LICENSE = @DriversLicense, 
                        CURRENT_ADDRESS_1 = @CurrentAddress1, 
                        CURRENT_ADDRESS_2 = @CurrentAddress2, 
                        CURRENT_CITY = @CurrentCity, 
                        CURRENT_COUNTRY = @CurrentCountry, 
                        CURRENT_ZIP = @CurrentZip, 
                        CURRENT_GENDER = @CurrentGender, 
                        CURRENT_PHONE_NUMBER = @CurrentPhoneNumber, 
                        CURRENT_PERSONAL_EMAIL = @CurrentPersonalEmail, 
                        CURRENT_MARITAL_STATUS = @CurrentMaritalStatus, 
                        ETHNICITY = @Ethnicity, 
                        SHAREHOLDER_STATUS = @ShareholderStatus, 
                        BENEFIT_PLAN_ID = @BenefitPlanID 
                        PERSONAL_ID = @PersonalID";

            SqlCommand cmd = new SqlCommand(query, con, transaction);

            cmd.Parameters.AddWithValue("@PersonalID", Convert.ToString(row.Cells["PERSONAL_ID"].Value));
            cmd.Parameters.AddWithValue("@FirstName", Convert.ToString(row.Cells["CURRENT_FIRST_NAME"].Value));
            cmd.Parameters.AddWithValue("@LastName", Convert.ToString(row.Cells["CURRENT_LAST_NAME"].Value));
            cmd.Parameters.AddWithValue("@MiddleName", Convert.ToString(row.Cells["CURRENT_MIDDLE_NAME"].Value));
            cmd.Parameters.AddWithValue("@Birthday", Convert.ToString(row.Cells["BIRTH_DATE"].Value));
            cmd.Parameters.AddWithValue("@SocialSecurityNumber", Convert.ToString(row.Cells["SOCIAL_SECURITY_NUMBER"].Value));
            cmd.Parameters.AddWithValue("@DriversLicense", Convert.ToString(row.Cells["DRIVERS_LICENSE"].Value));
            cmd.Parameters.AddWithValue("@CurrentAddress1", Convert.ToString(row.Cells["CURRENT_ADDRESS_1"].Value));
            cmd.Parameters.AddWithValue("@CurrentAddress2", Convert.ToString(row.Cells["CURRENT_ADDRESS_2"].Value));
            cmd.Parameters.AddWithValue("@CurrentCity", Convert.ToString(row.Cells["CURRENT_CITY"].Value));
            cmd.Parameters.AddWithValue("@CurrentCountry", Convert.ToString(row.Cells["CURRENT_COUNTRY"].Value));
            cmd.Parameters.AddWithValue("@CurrentZip", Convert.ToString(row.Cells["CURRENT_ZIP"].Value));
            cmd.Parameters.AddWithValue("@CurrentGender", Convert.ToString(row.Cells["CURRENT_GENDER"].Value));
            cmd.Parameters.AddWithValue("@CurrentPhoneNumber", Convert.ToString(row.Cells["CURRENT_PHONE_NUMBER"].Value));
            cmd.Parameters.AddWithValue("@CurrentPersonalEmail", Convert.ToString(row.Cells["CURRENT_PERSONAL_EMAIL"].Value));
            cmd.Parameters.AddWithValue("@CurrentMaritalStatus", Convert.ToString(row.Cells["CURRENT_MARITAL_STATUS"].Value));
            cmd.Parameters.AddWithValue("@Ethnicity", Convert.ToString(row.Cells["ETHNICITY"].Value));
            cmd.Parameters.AddWithValue("@ShareholderStatus", Convert.ToString(row.Cells["SHAREHOLDER_STATUS"].Value));
            cmd.Parameters.AddWithValue("@BenefitPlanID", Convert.ToString(row.Cells["BENEFIT_PLAN_ID"].Value));

            return cmd;
        }


        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conectString))
                {
                    conn.Open();
                    int currentIndex = e.RowIndex;

                    if (currentIndex >= 0 && currentIndex < dataGridView1.Rows.Count)
                    {
                        DataGridViewRow row = dataGridView1.Rows[currentIndex];

                        SqlCommand cmd = CreateUpdateCommand(row, conn, null);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Không có bản ghi nào được cập nhật.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một hàng để cập nhật.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi cập nhật dữ liệu: " + ex.Message, "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

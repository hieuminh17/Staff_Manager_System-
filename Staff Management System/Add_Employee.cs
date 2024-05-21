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
using MySql.Data.MySqlClient;

namespace Staff_Management_System
{
    public partial class Add_Employee : Form
    {
        private string contr = "server=localhost;user=root;pwd=31119524;database=mydb;port=3306";
        
        private string connectionString = @"Data Source=LAPTOP-KP432QPH\SQLEXPRESS02;Initial Catalog=HRM;Integrated Security=True";
        public Add_Employee()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Validate input
                    if (!decimal.TryParse(txt_personalID.Text, out decimal personalID) || !decimal.TryParse(txt_BENEFIT_PLAN_ID.Text, out decimal benefitPlanID))
                    {
                        MessageBox.Show("PersonalID and BenefitPlanID must be decimal values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!DateTime.TryParse(dt_birthday.Text, out DateTime birthday))
                    {
                        MessageBox.Show("Birthday must be a valid date.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = @"INSERT INTO PERSONAL 
                                    VALUES (@PersonalID, @FirstName, @LastName, @MiddleName, @Birthday, @SocialSecurityNumber, @DriversLicense, 
                                    @CurrentAddress1, @CurrentAddress2, @CurrentCity, @CurrentCountry, @CurrentZip, @CurrentGender, 
                                    @CurrentPhoneNumber, @CurrentPersonalEmail, @CurrentMaritalStatus, @Ethnicity, @ShareholderStatus, @BenefitPlanID)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PersonalID", personalID);
                        cmd.Parameters.AddWithValue("@FirstName", txt_firstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txt_lastName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txt_MidName.Text);
                        cmd.Parameters.AddWithValue("@Birthday", birthday);
                        cmd.Parameters.AddWithValue("@SocialSecurityNumber", txt_SOCIAL_SECURITY_NUMBER.Text);
                        cmd.Parameters.AddWithValue("@DriversLicense", txt_DRIVERS_LICENSE.Text);
                        cmd.Parameters.AddWithValue("@CurrentAddress1", txt_CURRENT_ADDRESS_1.Text);
                        cmd.Parameters.AddWithValue("@CurrentAddress2", txt_CURRENT_ADDRESS_2.Text);
                        cmd.Parameters.AddWithValue("@CurrentCity", txt_CURRENT_CITY.Text);
                        cmd.Parameters.AddWithValue("@CurrentCountry", txt_CURRENT_COUNTRY.Text);
                        cmd.Parameters.AddWithValue("@CurrentZip", txt_CURRENT_ZIP.Text);
                        cmd.Parameters.AddWithValue("@CurrentGender", txt_CURRENT_GENDER.Text);
                        cmd.Parameters.AddWithValue("@CurrentPhoneNumber", txt_CURRENT_PHONE_NUMBER.Text);
                        cmd.Parameters.AddWithValue("@CurrentPersonalEmail", txt_CURRENT_PERSONAL_EMAIL.Text);
                        cmd.Parameters.AddWithValue("@CurrentMaritalStatus", txt_CURRENT_MARITAL_STATUS.Text);
                        cmd.Parameters.AddWithValue("@Ethnicity", txt_ETHNICITY.Text);
                        cmd.Parameters.AddWithValue("@ShareholderStatus", short.Parse(txt_SHAREHOLDER_STATUS.Text));
                        cmd.Parameters.AddWithValue("@BenefitPlanID", benefitPlanID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Person added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                    
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
                //// Insert into EMPLOYEE table
                //using (MySqlConnection con = new MySqlConnection(contr))
                //{
                //    try
                //    {
                //        con.Open();

                //        // Validate input
                //        if (!decimal.TryParse(txt_personalID.Text, out decimal personalID) || !decimal.TryParse(txt_BENEFIT_PLAN_ID.Text, out decimal benefitPlanID))
                //        {
                //            MessageBox.Show("PersonalID and BenefitPlanID must be decimal values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }

                //        if (!DateTime.TryParse(dt_birthday.Text, out DateTime birthday))
                //        {
                //            MessageBox.Show("Birthday must be a valid date.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }

                //        string query = @"INSERT INTO employee 
                //                                 VALUES (@EmployeeID, @EmployeeNum, @LastName, @FirstName,5,Null,@Pay_Rates_idPayRates,Null,Null,Null)";
                //        using (MySqlCommand cmd = new MySqlCommand(query, con))
                //        {
                            
                            
                //                cmd.Parameters.AddWithValue("@EmployeeNum", personalID);
                //                cmd.Parameters.AddWithValue("@EmployeeID", personalID);
                //                cmd.Parameters.AddWithValue("@LastName", txt_lastName.Text);
                //                cmd.Parameters.AddWithValue("@FirstName", txt_firstName.Text);
                //                cmd.Parameters.AddWithValue("@Pay_Rates_idPayRates", txt_BENEFIT_PLAN_ID.Text); // Assuming hire date is the current date
                            

                //                cmd.ExecuteNonQuery();

                //                int rowsAffected = cmd.ExecuteNonQuery();

                //            if (rowsAffected > 0)
                //            {
                //                MessageBox.Show("Employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            }
                //            else
                //            {
                //                MessageBox.Show("Failed to add employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //        }
                    
                //    }
                    

                
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

        }
    }
}

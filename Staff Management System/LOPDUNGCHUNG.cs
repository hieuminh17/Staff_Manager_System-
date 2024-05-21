using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Staff_Management_System
{
    class LOPDUNGCHUNG
    {
        String conectString = @"Data Source=LAPTOP-KP432QPH\SQLEXPRESS02;Initial Catalog=HRM;Integrated Security=True";
        SqlConnection con;
        
        public LOPDUNGCHUNG()
        {
            con = new SqlConnection(conectString);
        }
        public DataTable LoadDL(string sql)
        {
            SqlDataAdapter adt = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public object LayGT(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            object kq = cmd.ExecuteScalar();
            con.Close();
            return kq;
        }
        public int ThemXoaSua(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, con);
            con.Open();
            int kq = comm.ExecuteNonQuery();
            con.Close();
            return kq;
        }
    }
}

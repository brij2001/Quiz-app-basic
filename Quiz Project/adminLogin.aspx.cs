using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz_Project
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            string uid = TextBox1.Text;
            string pass = TextBox2.Text;
            string qry = "select * from adminLogin where UserId='" + uid + "' and Password='" + pass + "'";
            SqlCommand cmd = new SqlCommand(qry, sqlconn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Label4.Text = "Login Sucess......!!";
            }
            else
            {
                Label4.Text = "UserId & Password Is not correct Try again..!!";

            }
            Label4.Visible = true;
            sqlconn.Close();
        }

    }
}

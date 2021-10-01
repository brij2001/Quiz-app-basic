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
        string mainconn = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            string uid = TextBox1.Text;
            string pass = TextBox2.Text;
            string qry = "select * from adminLogin where UserId='" + uid + "' and Password='" + pass + "'";
            SqlCommand cmd = new SqlCommand(qry, sqlconn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                sdr.Close();
                LinkButton2.Visible = true;
                
            }
            else
            {
                Label4.Text = "UserId & Password Is not correct Try again..!!";
                Label4.Visible = true;
                sqlconn.Close();

            }
            
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == false)
            {
                GridView1.Visible = true;
                LinkButton2.Text = "Hide Student Score";
            }
            else
            {
                GridView1.Visible = false;
                LinkButton2.Text = "Show Student Score";
            }
        }

       
    }
}

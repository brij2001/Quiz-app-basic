using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace Quiz_Project
{
    public partial class studentLogin : System.Web.UI.Page
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
            string qry = "select * from studentLogin where UserId='" + uid + "' and Password='" + pass + "'";
            SqlCommand cmd = new SqlCommand(qry, sqlconn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                HttpCookie studentname = new HttpCookie("studentname");
                studentname["UserName"] = uid;
                studentname.Expires.Add(new TimeSpan(1, 0, 0));
                Response.Cookies.Add(studentname);
                sqlconn.Close();
                Response.Redirect("exam.aspx");
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
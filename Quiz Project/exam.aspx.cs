using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
namespace Quiz_Project
{
    public partial class exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {               
                string mainconn = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select * from exam";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                sqlconn.Close();

            }
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            int score = 0;

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb1 = (RadioButton)ri.FindControl("RadioButton1");
                Label CorrectAns = (Label)ri.FindControl("CorrectAns");
                CorrectAns.Visible = true;
                if (rb1.Checked == true)
                {
                    if (rb1.Text.Equals(CorrectAns.Text))
                    {
                        Label UserAns = (Label)ri.FindControl("UserAns");
                        score += 1;
                        UserAns.Text = "The answer is <b>" + rb1.Text.ToString() + "</b>";
                        UserAns.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label wrong = (Label)ri.FindControl("UserAns");
                        wrong.Text = "The answer is <b>" + rb1.Text.ToString() + "</b> is WRONG!!";
                        wrong.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb2 = (RadioButton)ri.FindControl("RadioButton2");
                Label CorrectAns = (Label)ri.FindControl("CorrectAns");
                CorrectAns.Visible = true;
                if (rb2.Checked == true)
                {
                    if (rb2.Text.Equals(CorrectAns.Text))
                    {
                        Label UserAns = (Label)ri.FindControl("UserAns");
                        score += 1;
                        UserAns.Text = "The answer is <b>" + rb2.Text.ToString() + "</b>";
                        UserAns.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label wrong = (Label)ri.FindControl("UserAns");
                        wrong.Text = "The answer is <b>" + rb2.Text.ToString() + "</b> is WRONG!!";
                        wrong.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb3 = (RadioButton)ri.FindControl("RadioButton3");
                Label CorrectAns = (Label)ri.FindControl("CorrectAns");
                CorrectAns.Visible = true;
                if (rb3.Checked == true)
                {
                    if (rb3.Text.Equals(CorrectAns.Text))
                    {
                        Label UserAns = (Label)ri.FindControl("UserAns");
                        score += 1;
                        UserAns.Text = "The answer is <b>" + rb3.Text.ToString() + "</b>";
                        UserAns.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label wrong = (Label)ri.FindControl("UserAns");
                        wrong.Text = "The answer is <b>" + rb3.Text.ToString() + "</b> is WRONG!!";
                        wrong.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                RadioButton rb4 = (RadioButton)ri.FindControl("RadioButton4");
                Label CorrectAns = (Label)ri.FindControl("CorrectAns");
                CorrectAns.Visible = true;
                if (rb4.Checked == true)
                {
                    if (rb4.Text.Equals(CorrectAns.Text))
                    {
                        Label UserAns = (Label)ri.FindControl("UserAns");
                        score += 1;
                        UserAns.Text = "The answer is <b>" + rb4.Text.ToString() + "</b>";
                        UserAns.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label wrong = (Label)ri.FindControl("UserAns");
                        wrong.Text = "The answer is <b>" + rb4.Text.ToString() + "</b> is WRONG!!";
                        wrong.ForeColor = System.Drawing.Color.Red;

                    }
                }
            }
            string mainconn = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            HttpCookie cookie = HttpContext.Current.Request.Cookies["studentname"];
            string usr = (!String.IsNullOrEmpty("UserName")) ? cookie["UserName"] : cookie.Value;
            string query = "UPDATE studentLogin set score=@score where UserId=@usr";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@usr", usr);            
            System.Diagnostics.Debug.WriteLine(query);
            sqlconn.Open();
            cmd.ExecuteNonQuery();
            Response.Cookies["studentname"].Expires = DateTime.Now.AddDays(-1);
            Label1.Visible = true;
            Label1.Text = "Your score is " + score + ".";
        }

    }

 
}


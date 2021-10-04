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
        private string mainconn = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void bindrepeater()
        {
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
                Label4.Visible = false;
                loginPanel.Visible = false;
                sdr.Close();
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
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
                Repeater1.Visible = false;
                GridView1.Visible = true;
                LinkButton2.Text = "Hide Student Score";
                LinkButton3.Text = "Edit Questions";
                removebutton.Visible = false;
            }
            else
            {
                GridView1.Visible = false;
                LinkButton2.Text = "Show Student Score";
            }
        }

        public void LinkButton3_Click(object sender, EventArgs e)
        {
            if (Repeater1.Visible == false)
            {
                GridView1.Visible = false;
                
                this.bindrepeater();
                Repeater1.Visible = true;
                LinkButton3.Text = "Hide Questions";
                LinkButton2.Text = "Show Student Score";
                removebutton.Visible = true;
            }
            else
            {
                removebutton.Visible = false;
                Repeater1.Visible = false;
                LinkButton3.Text = "Edit Questions";
            }
        }

        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
        }

        protected void Repeater_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            if (e.CommandName == "update")
            {
                string editId = btnEdit.CommandArgument;
                string qids = ((Label)e.Item.FindControl("Label5")).Text;
                string qs = ((TextBox)e.Item.FindControl("TextBoxqs")).Text;
                string op1 = ((TextBox)e.Item.FindControl("TextBoxop1")).Text;
                string op2 = ((TextBox)e.Item.FindControl("TextBoxop2")).Text;
                string op3 = ((TextBox)e.Item.FindControl("TextBoxop3")).Text;
                string op4 = ((TextBox)e.Item.FindControl("TextBoxop4")).Text;
                string ans = ((TextBox)e.Item.FindControl("TextBoxans")).Text;
                SqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int qid = Convert.ToInt32(qids);
                cmd.CommandText = "UPDATE exam SET question=@question, op1=@op1, op2=@op2, op3=@op3, op4=@op4, correct=@correct WHERE (qid=@qid)";
                cmd.Parameters.AddWithValue("@question", qs);
                cmd.Parameters.AddWithValue("@op1", op1);
                cmd.Parameters.AddWithValue("@op2", op2);
                cmd.Parameters.AddWithValue("@op3", op3);
                cmd.Parameters.AddWithValue("@op4", op4);
                cmd.Parameters.AddWithValue("@correct", ans);
                cmd.Parameters.AddWithValue("@qid", qid);

                cmd.ExecuteNonQuery();
                sqlconn.Close();
                MessageBox(this, "Question Updated!");
                this.bindrepeater();
            }
            if (e.CommandName == "insert")
            {
                SqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into exam (question, op1,op2,op3,op4,correct) values ('question','op1','op2','op3','op4','correct answer')";
                cmd.ExecuteNonQuery();
                sqlconn.Close();
                MessageBox(this, "Question Inserted!!");
                this.bindrepeater();
            }
            if (e.CommandName == "remove")
            {
                SqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string qids = ((Label)e.Item.FindControl("Label5")).Text;
                int qid = Convert.ToInt32(qids);
                cmd.CommandText = "delete from exam WHERE qid=@qid";
                cmd.Parameters.AddWithValue("@qid", qid);
                cmd.ExecuteNonQuery();
                sqlconn.Close();
                MessageBox(this, "Question Deleted!!");
                this.bindrepeater();
            }
        }
        protected void insertRow(object sender,EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand cmd = sqlconn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into exam (question, op1,op2,op3,op4,correct) values ('question','op1','op2','op3','op4','correct answer')";
            cmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox(this, "Question Inserted!!");
            this.bindrepeater();
        }
        protected void Repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
    }
}
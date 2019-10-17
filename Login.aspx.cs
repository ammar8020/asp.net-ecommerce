using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["EMAIL"] != null && Request.Cookies["PASS"] != null)
            {
                txtBoxEmail.Text = Request.Cookies["EMAIL"].Value;
                txtBoxPass.Attributes["value"] = Request.Cookies["PASS"].Value;
                ChkBoxRem.Checked = true;
            } 
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("select * from Users where Email = '"+txtBoxEmail.Text+"' and Password = '"+txtBoxPass.Text+"'", conn);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (ChkBoxRem.Checked)
                {
                    Response.Cookies["EMAIL"].Value = txtBoxEmail.Text;
                    Response.Cookies["PASS"].Value = txtBoxPass.Text;

                    Response.Cookies["EMAIL"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["PASS"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["EMAIL"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["PASS"].Expires = DateTime.Now.AddDays(-1);
                }

                String UserType;
                UserType = dt.Rows[0][6].ToString().Trim();

                if (UserType == "2")
                {
                    Session["EMAIL"] = txtBoxEmail.Text;
                    if (Request.QueryString["requestUrl"] == "cart")
                    {
                        if (Request.QueryString["requestUrl"] == "cart")
                        {
                            Response.Redirect("~/Cart.aspx");
                        }
                    }

                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                if (UserType == "1")
                {
                    Session["EMAIL"] = txtBoxEmail.Text;
                    Response.Redirect("~/AdminDefault.aspx");
                }
                //string userID = dt.Rows[0][0].ToString().Trim();
                //Session["USERID"] = userID;

            }

            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "The Email or Password you entered is not valid !";
            }
        }
    }
}
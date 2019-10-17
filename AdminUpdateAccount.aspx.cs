using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class AdminUpdateAccount : System.Web.UI.Page
{
    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            displayAccDetails();

        }
    }


    public void displayAccDetails()
    {


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("select * from Users where Email = '" + Session["EMAIL"] + "' ", conn);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            tbUname.Text = dt.Rows[0]["UserName"].ToString();
            tbName.Text = dt.Rows[0]["Name"].ToString();
            tbEmail.Text = dt.Rows[0]["Email"].ToString();
            tbPass.Text = dt.Rows[0]["Password"].ToString();
            tbAddress.Text = dt.Rows[0]["Address"].ToString();

        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (tbUname.Text != "" && tbName.Text != "" && tbEmail.Text != "" && tbPass.Text != "" && tbCPass.Text != "" && tbAddress.Text != "")
        {
            if (tbPass.Text == tbCPass.Text)
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update Users SET UserName = '" + tbUname.Text + "', Name = '" + tbName.Text + "', Email =  '" + tbEmail.Text + "', Password = '" + tbPass.Text + "', Address = '" + tbAddress.Text + "' where Email ='" + Session["EMAIL"] + "' ", conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    Session["EMAIL"] = null;
                    Response.Redirect("~/Login.aspx");
                }



            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "The passwords you entered don't match";
            }

        }

        else
        {
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "Please Fill all the required fields";
        }

    }
}
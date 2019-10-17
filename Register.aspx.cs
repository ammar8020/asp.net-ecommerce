using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btSignup_Click(object sender, EventArgs e)
    {
        if (tbUname.Text != "" && tbName.Text != "" && tbEmail.Text != "" && tbPass.Text != "" && tbCPass.Text != "" && tbAddress.Text != "")
        {
            if (tbPass.Text == tbCPass.Text)
            {

                DateTime DateofReg = DateTime.Now;

                String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("insert into Users values('" + tbUname.Text + "', '" + tbName.Text + "', '" + tbEmail.Text + "', '" + tbPass.Text + "', '" + tbAddress.Text + "', '2', '" + DateofReg + "' )", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "You have successfully registered on our Website!";
                    lblMsg.ForeColor = Color.Green;
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
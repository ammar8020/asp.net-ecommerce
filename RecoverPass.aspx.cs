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

public partial class RecoverPass : System.Web.UI.Page
{
    public static String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
    String userGUID;
    DataTable dt = new DataTable();
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            // Getting GUID from query string as passed from the ForgotPass page
            userGUID = Request.QueryString["UserId"];
            if (userGUID != null)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ForgotPassRequests WHERE Id='" + userGUID + "'", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    // storing the id of user so that we can later update his password
                    userId = Convert.ToInt32(dt.Rows[0][1]);
                }
                else
                {
                    lblMsg.Text = "Your Password Reset Link is Expired or Invalid !";
                    lblMsg.ForeColor = Color.Red;
                }

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        if(!IsPostBack) // To avoid loading and showing labels & text Boxes again & again
        {
            if (dt.Rows.Count > 0)
            {
                txtBoxNewPass.Visible = true;
                txtBoxConPass.Visible = true;
                lblPass.Visible = true;
                lblConPass.Visible = true;
                btnResPass.Visible = true;
            }
            else
            {
                lblMsg.Text = "Your Password Reset Link is Expired or Invalid !";
                lblMsg.ForeColor = Color.Red;
            }
        }
    }



    protected void btnResPass_Click(object sender, EventArgs e)
    {
        if (RequiredFieldValidatorNewPass.IsValid && RequiredFieldValidatorConPass.IsValid && CompareValidatorConPass.IsValid)
        {
                using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Password='" + txtBoxNewPass.Text + "' WHERE UserId='" + userId + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                // Deleting Requests of Reset from database after the password has been reset
                SqlCommand cmdDelReq = new SqlCommand("DELETE FROM ForgotPassRequests WHERE UserId='" + userId + "'", conn);
                cmdDelReq.ExecuteNonQuery();
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}
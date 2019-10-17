using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLayout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {

            lblLoggedIn.Text = "Loggedin as: " + Session["EMAIL"].ToString() + "";
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["EMAIL"] = null;
        Response.Redirect("~/Default.aspx");
    }
}

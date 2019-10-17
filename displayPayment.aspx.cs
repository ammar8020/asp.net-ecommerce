using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



public partial class displayPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        rptrBindPayments();

    }


    private void rptrBindPayments()
    {
        String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Payment ", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrPayment.DataSource = dt;
                    rptrPayment.DataBind();
                }

            }
        }
    }
}
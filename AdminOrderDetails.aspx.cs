using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class AdminOrderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["order"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        rptrBindOrders();

    }


    private void rptrBindOrders()
    {
        String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from OrderDetails inner join Products ON OrderDetails.PID = Products.PID where OrderDetails.OrderId = '" + Request.QueryString["order"] + "' ", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrOrderDetails.DataSource = dt;
                    rptrOrderDetails.DataBind();
                }

            }
        }
    }
}
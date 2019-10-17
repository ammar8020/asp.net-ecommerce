using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class AdminDisplayOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        rptrBindOrders();

    }


    private void rptrBindOrders()
    {
        String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Orders inner join Users ON Users.UserId = Orders.UserId", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrOrders.DataSource = dt;
                    rptrOrders.DataBind();
                }

            }
        }
    }


}
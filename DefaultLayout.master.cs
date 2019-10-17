using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



public partial class Layout2 : System.Web.UI.MasterPage
{
    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["EMAIL"] != null)
            {
                if (!IsPostBack)
                {
                    btnLogInOut.Text = "Logout";
                    lblLoggedIn.Text = "Loggedin as: " + Session["EMAIL"].ToString() + "";
                }
            }
            else
            {
                btnLogInOut.Text = "Login";
            }

            if (!IsPostBack)
            {
                dispCategories();
                dispBrands();
            }

            displayTotalItemsInCart();
        }
    }


    protected void btnLogInOut_Click(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select * from Users where Email = '" + Session["EMAIL"] + "' ", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                //}


                int userId = (int)(Convert.ToDouble(dt.Rows[0][0].ToString().Trim()));

                using (SqlCommand cmd2 = new SqlCommand("delete from SelectedQuantity where userId = " + userId + "", conn))
                {
                    cmd2.CommandType = CommandType.Text;
                    //conn.Open();
                    cmd2.ExecuteNonQuery();

                }
            }

            if (Request.Cookies["CartPID"] != null)
            {
                Response.Cookies["CartPID"].Expires = DateTime.Now.AddDays(-1);
            }


            Session["EMAIL"] = null;
            btnLogInOut.Text = "Login";
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }


    public void displayTotalItemsInCart()
    {
        // To empty the cookies
        //Response.Cookies["CartPID"].Expires = DateTime.Now.AddDays(-1);

        if (Request.Cookies["CartPID"] != null)
        {
            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] productArr = CookiePID.Split(',');
            int count = productArr.Length;

            productCount.InnerText = count.ToString();
            
        }
        else
        {
            productCount.InnerText = 0.ToString(); 
        }
    }



    public void dispCategories()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("Select * from Categories", conn))
            {
                
                cmd.CommandType = CommandType.Text;
               
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dlCategories.DataSource = dt;
                    dlCategories.DataBind();
                }
            }
        }
    }


    
    public void dispBrands()
    {

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("Select * from Brands", conn))
            {

                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dlBrands.DataSource = dt;
                    dlBrands.DataBind();
                }
            }
        }
    }

}

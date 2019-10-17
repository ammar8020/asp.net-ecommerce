using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class _Default : System.Web.UI.Page
{

    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!IsPostBack)
            {
                displayProductImages();
                bindProductRepeater();
            }
        }

        else
        {
            Response.Redirect("~/Login.aspx");
        }

    }



    private void displayProductImages()
    {
        


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from SliderImages", conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrImages.DataSource = dt;
                    rptrImages.DataBind();
                }

            }
        }
    }


    // Function called at design page to strip chars in ShortDetail to 35 if they are above 35
    public string limitChars(Object myString)
    {
        string myStr = myString.ToString();
        if (myStr.Length > 35)
        {
            myStr = myStr.Substring(0, 35) + "...";
            return myStr;
        }
        else
            return myStr;
    }


    private void bindProductRepeater()
    {
        
        string queryDispProducts = "procDispAllProducts";


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand(queryDispProducts, conn))
            {

                    cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrProducts.DataSource = dt;
                    rptrProducts.DataBind();
                }
            }
        }
    }





}
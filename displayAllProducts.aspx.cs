using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class displayAllProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!IsPostBack)
            {
                
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        bindProductRepeater();
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
        String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
        string queryDispProducts;

        if (Request.QueryString["search"] == null && Request.QueryString["category"] == null && Request.QueryString["brand"] == null)
        {
            queryDispProducts = "procDispAllProducts";
        }
        
        else if (Request.QueryString["category"] != null && Request.QueryString["search"] == null && Request.QueryString["brand"] == null)
        {
            queryDispProducts = "select Products.*,ProductImages.*,Brands.BrandName from Products inner join Brands on Brands.BrandID = Products.PBrandID cross apply( select top 1 * from ProductImages where ProductImages.PID = Products.PID and PCategoryID = '" + Request.QueryString["category"].ToString() + "' order by ProductImages.PID desc ) ProductImages order by Products.pid desc ";
        }

        else if (Request.QueryString["brand"] != null && Request.QueryString["search"] == null && Request.QueryString["category"] == null)
        {
            queryDispProducts = "select Products.*,ProductImages.*,Brands.BrandName from Products inner join Brands on Brands.BrandID = Products.PBrandID cross apply( select top 1 * from ProductImages where ProductImages.PID = Products.PID and PBrandID = '" + Request.QueryString["brand"].ToString() + "' order by ProductImages.PID desc ) ProductImages order by Products.pid desc ";
        }

        else
        {
            queryDispProducts = "select Products.*,ProductImages.*,Brands.BrandName from Products inner join Brands on Brands.BrandID = Products.PBrandID cross apply( select top 1 * from ProductImages where ProductImages.PID = Products.PID and PName like ('%" + Request.QueryString["search"].ToString() + "%') order by ProductImages.PID desc ) ProductImages order by Products.pid desc ";
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        { 
            using (SqlCommand cmd = new SqlCommand(queryDispProducts, conn))
            {
                if (Request.QueryString["search"] == null && Request.QueryString["category"] == null && Request.QueryString["brand"] == null)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
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
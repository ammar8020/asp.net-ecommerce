using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAddBrand : System.Web.UI.Page
{
    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    string getId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptrBindBrands();

        }

        if (Request.QueryString["editBrand"] != null)
        {
            getId = Request.QueryString["editbrand"].ToString();
            

        }
        if (Request.QueryString["editBrand"] != null)
        {
            editBrands();
        }

        deleteBrands();

    }

    private void rptrBindBrands()
    {
        
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Brands", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrBrands.DataSource = dtBrands;
                    rptrBrands.DataBind();
                }

            }
        }
       
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {


        if (btnAddBrand.Text != "Update Brand")
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("insert into Brands values('" + tbBrandName.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                tbBrandName.Text = string.Empty;
            }

        }

        else
        {




            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Brands SET BrandName = '" + tbBrandName.Text + "' where BrandID ='" + getId + "' ", conn);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                //SqlCommand cmd = new SqlCommand("procAddProducts", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@BrandName", tbBrandName.Text);
                //cmd.Parameters.AddWithValue("@getId", Convert.ToInt64(getId));

            }

            btnAddBrand.Text = "Add Brand";
            tbBrandName.Text = string.Empty;

        }

        Response.Redirect("~/AdminAddBrand.aspx");
    
        rptrBindBrands();

    }



    




    public void editBrands()
    {
            //string getId = Request.QueryString["editbrand"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Brands where BrandID = '" + getId + "' ", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lblSelBrand.Text = dt.Rows[0]["BrandName"].ToString();
                btnAddBrand.Text = "Update Brand";
            }

        
            
    }




    public void deleteBrands()
    {
        if (Request.QueryString["brand"] != null)
        {
            string getId = Request.QueryString["brand"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("delete from Products where PBrandID ='" + getId + "' ", conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd2 = new SqlCommand("delete from Brands where BrandID ='" + getId + "' ", conn))
                {
                    cmd2.CommandType = CommandType.Text;

                    cmd2.ExecuteNonQuery();
                }
            }
        }


        rptrBindBrands();


    }




}
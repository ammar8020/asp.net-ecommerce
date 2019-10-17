using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAddCategory : System.Web.UI.Page
{

    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    string getId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptrBindCategories();

        }
        if (Request.QueryString["editCategory"] != null)
        {
            getId = Request.QueryString["editCategory"].ToString();


        }

        editCategories();
        deleteCategories();

    }

    private void rptrBindCategories()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Categories", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtCategories = new DataTable();
                    sda.Fill(dtCategories);
                    rptrCategories.DataSource = dtCategories;
                    rptrCategories.DataBind();
                }

            }
        }
    }


    protected void btnAddCat_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["editBrand"] == null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("insert into Categories values('" + tbCatName.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                tbCatName.Text = string.Empty;
            }
        }

        else

        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Brands SET CatName = '" + tbCatName.Text + "' where CatID ='" + getId + "' ", conn);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                

            }

            btnAddCat.Text = "Add Category";
            tbCatName.Text = string.Empty;
        }

        Response.Redirect("~/AdminAddCategory.aspx");

        rptrBindCategories();

    }


    public void editCategories()
    {
        if (Request.QueryString["editCategory"] != null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Categories where CatID = '" + getId + "' ", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lblSelCat.Text = dt.Rows[0]["CatName"].ToString();
                btnAddCat.Text = "Update Category";
            }
        }
    }



    public void deleteCategories()
    {
        if (Request.QueryString["category"] != null)
        {
            string getId;
            getId = Request.QueryString["category"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Products where PCategoryID ='" +getId+ "' " , conn))
                {
                    cmd.CommandType = CommandType.Text;
                    
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd2 = new SqlCommand("delete from Categories where CatID ='" + getId + "' ", conn))
                {
                    cmd2.CommandType = CommandType.Text;

                    cmd2.ExecuteNonQuery();
                }
            }
        }


        rptrBindCategories();


    }





}
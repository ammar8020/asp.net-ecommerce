using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAddProduct : System.Web.UI.Page
{
    public static String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlBindCategories();
            ddlBindBrands();
        }
    }

    private void ddlBindCategories()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("select * from Categories", conn);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CatName";      // For displaying specific column in DropDownList
                ddlCategory.DataValueField = "CatID";       // For storing specific column value in DropDownList
                ddlCategory.DataBind();                     // Binding values to ddl
                ddlCategory.Items.Insert(0, new ListItem("Select", "0"));       // Initializing
            }
        }
    }

    private void ddlBindBrands()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("select * from Brands", conn);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ddlBrand.DataSource = dt;
                ddlBrand.DataTextField = "BrandName";      // For displaying specific column in DropDownList
                ddlBrand.DataValueField = "BrandID";       // For storing specific column value in DropDownList
                ddlBrand.DataBind();                     // Binding values to ddl
                ddlBrand.Items.Insert(0, new ListItem("Select", "0"));       // Initializing
            }
        }
    }


    protected void btnAddProd_Click(object sender, EventArgs e)
    {
        // For coverting and rounding price upto 2 decimal places
        double convertedPrice = Convert.ToDouble(tbPrice.Text);
        double roundedPrice = Math.Ceiling(convertedPrice * 100) / 100;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("procAddProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", tbName.Text);
            cmd.Parameters.AddWithValue("@PPrice", roundedPrice);
            cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PShtDet", tbShtDet.Text);
            cmd.Parameters.AddWithValue("@PLngDet", tbShtDet.Text);
            cmd.Parameters.AddWithValue("@Quantity", tbQuantity.Text);
        
            conn.Open();
            Int64 newProductId = Convert.ToInt64(cmd.ExecuteScalar());

        //Int64 newProductId;
        //using (SqlConnection conn = new SqlConnection(connStr))
        //{
        //    SqlCommand cmd = new SqlCommand("insert into Products values('" + tbName.Text + "', '" + tbPrice.Text + "', '" + ddlBrand.SelectedItem.Value + "', '" + ddlCategory.SelectedItem.Value + "', '" + tbShtDet.Text + "', '" + tbLngDet.Text + "', '" + tbQuantity.Text + "' )", conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    newProductId = Convert.ToInt64(cmd.ExecuteScalar());

            // Upload Images and store them in ProductImages Folder

            if (fuImg1.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + newProductId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }

                string Extention = Path.GetExtension(fuImg1.PostedFile.FileName);
                fuImg1.SaveAs(SavePath + "\\" + tbName.Text.ToString().Trim() + "1" + Extention);

                SqlCommand cmd3 = new SqlCommand("insert into ProductImages values('" + newProductId + "','" + tbName.Text.ToString().Trim() + "1" + "','" + Extention + "')", conn);
                cmd3.ExecuteNonQuery();
            }

            if (fuImg2.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + newProductId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fuImg2.PostedFile.FileName);
                fuImg2.SaveAs(SavePath + "\\" + tbName.Text.ToString().Trim() + "2" + Extention);

                SqlCommand cmd4 = new SqlCommand("insert into ProductImages values('" + newProductId + "','" + tbName.Text.ToString().Trim() + "2" + "','" + Extention + "')", conn);
                cmd4.ExecuteNonQuery();
            }

            if (fuImg3.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + newProductId;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fuImg3.PostedFile.FileName);
                fuImg3.SaveAs(SavePath + "\\" + tbName.Text.ToString().Trim() + "3" + Extention);

                SqlCommand cmd5 = new SqlCommand("insert into ProductImages values('" + newProductId + "','" + tbName.Text.ToString().Trim() + "3" + "','" + Extention + "')", conn);
                cmd5.ExecuteNonQuery();
            }

        }

    }

}
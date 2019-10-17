using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class AdminDisplayProducts : System.Web.UI.Page
{
    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    string getId = "";

    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {
            rptrBindProducts();

        }
        if (Request.QueryString["editProduct"] != null)
        {
            getId = Request.QueryString["editProduct"].ToString();


        }

        editProducts();
        deleteProducts();
    }




    private void rptrBindProducts()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Products", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtCategories = new DataTable();
                    sda.Fill(dtCategories);
                    rptrProducts.DataSource = dtCategories;
                    rptrProducts.DataBind();
                }

            }
        }
    }


    protected void btnUpdateProd_Click(object sender, EventArgs e)
    {
        //Int64 newProductId;
        //string newProductId;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Products SET PName = '" + tbName.Text + "' , PPrice = '" + tbPrice.Text + "' , PShtDet = '" + tbShtDet.Text + "' , PLngDet = '" + tbLngDet.Text + "' , Quantity = '" + tbQuantity.Text + "'  where PID ='" + getId + "' ", conn);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            //newProductId = Convert.ToInt64(cmd.ExecuteScalar());
            //newProductId = (string)cmd.ExecuteScalar();

        }

        //btnUpdateProd.Text = string.Empty;






        //Int64 newProductId;
        //using (SqlConnection conn = new SqlConnection(connStr))
        //{
        //    SqlCommand cmd = new SqlCommand("insert into Products values('" + tbName.Text + "', '" + tbPrice.Text + "', '" + ddlBrand.SelectedItem.Value + "', '" + ddlCategory.SelectedItem.Value + "', '" + tbShtDet.Text + "', '" + tbLngDet.Text + "', '" + tbQuantity.Text + "' )", conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    newProductId = Convert.ToInt64(cmd.ExecuteScalar());

        // Upload Images and store them in ProductImages Folder

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();


            //SELECT TOP 1 * FROM Table ORDER BY ID DESC
            //DataTable dt3 = new DataTable();
            //using (SqlCommand cmd3 = new SqlCommand("select TOP 1 * from  ORDER BY OrderId DESC", conn))
            //{
            //    cmd3.CommandType = CommandType.Text;
            //    using (SqlDataAdapter sda2 = new SqlDataAdapter(cmd3))
            //    {
            //        sda2.Fill(dt3);

            //    }

            //}
            //string lastOrderId = dt3.Rows[0]["OrderId"].ToString().Trim();





            if (fuImg1.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + Request.QueryString["editProduct"];
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }

                string Extention = Path.GetExtension(fuImg1.PostedFile.FileName);
                fuImg1.SaveAs(SavePath + "\\" + tbName.Text.ToString().Trim() + "1" + Extention);

                SqlCommand cmd3 = new SqlCommand("update ProductImages set PID = '" + Request.QueryString["editProduct"].ToString() + "', ImgName = '" + tbName.Text.ToString().Trim() + "1" + "', ImgExt = '" + Extention + "' where PID = '" + Request.QueryString["editProduct"] + "' and ImgName LIKE '%1' ", conn);
                cmd3.ExecuteNonQuery();
            }

            if (fuImg2.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + Request.QueryString["editProduct"];
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fuImg2.PostedFile.FileName);
                fuImg2.SaveAs(SavePath + "\\" + tbName.Text.ToString().Trim() + "2" + Extention);


                SqlCommand cmd4 = new SqlCommand("update ProductImages set PID = '" + Request.QueryString["editProduct"].ToString() + "', ImgName = '" + tbName.Text.ToString().Trim() + "2" + "', ImgExt = '" + Extention + "' where PID = '" + Request.QueryString["editProduct"] + "' and ImgName LIKE '%2' ", conn);
                cmd4.ExecuteNonQuery();
            }

            if (fuImg3.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + Request.QueryString["editProduct"];
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                string Extention = Path.GetExtension(fuImg3.PostedFile.FileName);
                fuImg3.SaveAs(SavePath + "\\" + tbName.Text.ToString().Trim() + "3" + Extention);

                SqlCommand cmd5 = new SqlCommand("update ProductImages set PID = '" + Request.QueryString["editProduct"].ToString() + "', ImgName = '" + tbName.Text.ToString().Trim() + "3" + "', ImgExt = '" + Extention + "' where PID = '" + Request.QueryString["editProduct"] + "' and ImgName LIKE '%3' ", conn);
                cmd5.ExecuteNonQuery();
            }

        }


        Response.Redirect("~/AdminDisplayProducts.aspx");

        rptrBindProducts();

        lblMsg.Text = "Updated Successfully";
        lblMsg.ForeColor = Color.Green;
    }



    public void editProducts()
    {
        if (Request.QueryString["editProduct"] != null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Products where PID = '" + getId + "' ", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lblSelName.Text = dt.Rows[0]["PName"].ToString();
                lblSelPrice.Text = dt.Rows[0]["PPrice"].ToString();
                lblSelSht.Text = dt.Rows[0]["PShtDet"].ToString();
                lblSelLng.Text = dt.Rows[0]["PLngDet"].ToString();
                lblSelQuan.Text = dt.Rows[0]["Quantity"].ToString();
            }
        }
    }





    public void deleteProducts()
    {
        if (Request.QueryString["delProduct"] != null)
        {
            string getId;
            getId = Request.QueryString["delProduct"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Products where PID ='" + getId + "' ", conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                }

              
            }
        }


        rptrBindProducts();
        lblMsg.Text = "Deleted Successfully";
        lblMsg.ForeColor = Color.Green;

    }





}
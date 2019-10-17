using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ProductDetails : System.Web.UI.Page
{

    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
    Int64 chkQty;
    bool flagPCookie = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        // To prevent this error from occuring "Invalid postback or callback argument."
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PID"] != null)
            {
                if (!IsPostBack)
                {
                    displayTopProductImage();
                    displayProductImages();
                    displayProductDetails();
                }
            }
            else
            {
                Response.Redirect("~/displayAllProducts.aspx");
            }
        }

        Int64 id = Convert.ToInt64(Request.QueryString["PID"]);
        
        if (getQty(id) <= 0)
        {
            tbQty.Visible = false;
            lblQty.Text = "Sorry! There is no more such product left in the stocks";
            lblQty.ForeColor = System.Drawing.Color.Red;
        }

        if (Request.Cookies["CartPID"] != null)
        {

            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');   // As PID are stored as Comma Seperated Values so splitting and storing in array

            for (int i = 0; i < CookieDataArray.Length; i++)
            {
                string chkCookiePID = CookieDataArray[i].ToString().Split('-')[0];

                if (Convert.ToInt64(chkCookiePID) == Convert.ToInt64(Request.QueryString["PID"]))
                {
                    lblCartMsg.Text = "This product has already been added to Cart! ";
                    lblCartMsg.ForeColor = System.Drawing.Color.Red;

                    flagPCookie = true;
                }
            }
        }

    }


    private void displayTopProductImage()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select top 1 ProductImages.PID,ProductImages.ImgName,ProductImages.ImgExt from ProductImages where ProductImages.PID=" + PID + "", conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrTopImage.DataSource = dt;
                    rptrTopImage.DataBind();
                }

            }
        }
    }


    private void displayProductImages()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from ProductImages where PID=" + PID + "", conn))
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


    private void displayProductDetails()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);


        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Products where PID=" + PID + "", conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    rptrProductDetails.DataSource = dt;
                    rptrProductDetails.DataBind();

                }

            }
        }
    }


    protected void btnAddToCart_Click(object sender, EventArgs e)
    {

        int userId;

        if (Session["EMAIL"] != null)
        {
            if (!flagPCookie)
            { 

                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);

            if (tbQty.Text != "")
            {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        DataTable dt2 = new DataTable();

                        using (SqlCommand cmd2 = new SqlCommand("select * from Users where Email = '" + Session["EMAIL"] + "' ", conn))
                        {
                            conn.Open();
                            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);

                            sda2.Fill(dt2);
                        }


                        userId = (int)(Convert.ToDouble(dt2.Rows[0][0].ToString().Trim()));
                    }


                    Int64 selQty = Convert.ToInt64(tbQty.Text);
                Int64 qty = 0;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Products where PID=" + PID + "", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            //lblQtyErr.Text = Convert.ToString(dt.Rows[0][7]);
                            qty = Convert.ToInt64(dt.Rows[0][7]);

                            if (Convert.ToInt64(tbQty.Text) > qty)
                            {
                                lblQtyErr.Text = "The entered quantity exceeds the quantity present in the stocks";
                            }

                            else
                            {
                                lblQtyErr.Text = "";

                                    

                                    using (SqlCommand cmd3 = new SqlCommand("insert into SelectedQuantity values ( '" + PID + "', '" + userId + "','" + Convert.ToInt64(tbQty.Text) + "'  )", conn))
                                        { 
                                    cmd3.CommandType = CommandType.Text;
                                    
                                    conn.Open();
                                    cmd3.ExecuteNonQuery();

                                     //   conn.Close();

                                }


                                // Managing Cookies for storing PID and Product Qty in shopping cart
                                if (Request.Cookies["CartPID"] != null)
                                {
                                    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                                    CookiePID = CookiePID + "," + PID + "-" + selQty;

                                    HttpCookie CartProducts = new HttpCookie("CartPID");
                                    CartProducts.Values["CartPID"] = CookiePID;
                                    CartProducts.Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies.Add(CartProducts);


                                }
                                else
                                {
                                    HttpCookie CartProducts = new HttpCookie("CartPID");
                                    CartProducts.Values["CartPID"] = PID.ToString() + "-" + selQty;
                                    CartProducts.Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies.Add(CartProducts);


                                }
                                //Response.Redirect("~/ProductDetails.aspx?PID=" + PID);

                                //if (Convert.ToInt64(tbQty.Text) > qty)
                                //{
                                //    lblQtyErr.Text = "The entered quantity exceeds the quantity present in the stocks which is currently: " + qty;
                                //}

                                //else
                                //{
                                using (SqlCommand cmd2 = new SqlCommand("UPDATE Products SET Quantity=Quantity - ( '" + Convert.ToInt64(tbQty.Text) + "' ) where PID=( '" + PID + "') ", conn))
                                {
                                    cmd2.CommandType = CommandType.Text;
                                    //conn.Open();
                                    cmd2.ExecuteNonQuery();
                                    //Response.Redirect("~/ProductDetails.aspx?PID=" + PID);

                                }



                                //}

                                Response.Redirect("~/ProductDetails.aspx?PID=" + PID);

                            }
                        }

                    }



                }



                //SqlConnection conn = new SqlConnection(connStr);
                //if (conn.State == ConnectionState.Open)
                //{
                //    conn.Close();
                //}
                //conn.Open();

                //SqlCommand cmd2 = conn.CreateCommand();
                //cmd2.CommandType = CommandType.Text;
                //cmd2.CommandText = "update products set Quantity=Quantity-" + tbQty.Text;
                //cmd2.ExecuteNonQuery();
                //Response.Redirect("~/ProductDetails.aspx?PID=" + PID);


            }

            else
            {
                lblQtyErr.Text = "Please Enter required quantity";
            }
            //Response.Redirect("~/ProductDetails.aspx?PID=" + PID);

                }
            }

            else
            {
                Response.Redirect("~/Login.aspx");
            }
       
    }



    public Int64 getQty(Int64 id)
    {

        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd2 = new SqlCommand("select * from Products where PID=( '" + PID + "') ", conn))
            {
                cmd2.CommandType = CommandType.Text;
                conn.Open();
                cmd2.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                
                foreach (DataRow dr in dt.Rows)
                {
                    chkQty = Convert.ToInt64 (dr["Quantity"].ToString());
                }

                return chkQty;
            }
        }
    }

}



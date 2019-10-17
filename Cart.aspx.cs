using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Cart : System.Web.UI.Page
{
    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
    float cartTotalAmount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!IsPostBack)
            {
                displayCartProducts();
            }
        }
        
        if (Request.Cookies["CartPID"] == null)
        {
            btnBuy.Visible = false;

        }
    }

    private void displayCartProducts()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');   // As PID are stored as Comma Seperated Values so splitting and storing in array

            //string cook = "";

            if (CookieDataArray.Length > 0)
            {
                DataTable dt = new DataTable();
                //DataTable dt2 = new DataTable();

                float cartSubTotalAmount = 0;
                

                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string PID = CookieDataArray[i].ToString().Split('-')[0];
                    string PQty = CookieDataArray[i].ToString().Split('-')[1];
                    //cook = CookieDataArrayQty[i].ToString();

                    
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        //select Products.*,ProductImagesObj.*, SelectedQuantityObj.* from Products cross apply( select top 1 ProductImages.ImgName,ProductImages.ImgExt from ProductImages where ProductImages.PID = Products.PID ) ProductImagesObj where Products.PID =
                        //using (SqlCommand cmd = new SqlCommand("select Products.*,SelectedQuantityObj.* from Products cross apply(select SelQuantity from SelectedQuantity where SelectedQuantity.PID = " + PID + " ) SelectedQuantityObj where Products.PID = " + PID + "", conn))

                        using (SqlCommand cmd = new SqlCommand("select Products.*,ProductImagesObj.*,SelectedQuantityObj.* from Products  cross apply(select top 1 ProductImages.ImgName, ProductImages.ImgExt from ProductImages where ProductImages.PID= " + PID + " ) ProductImagesObj cross apply(select SelQuantity from SelectedQuantity where SelectedQuantity.PID = " + PID + " ) SelectedQuantityObj where Products.PID = " + PID + " ", conn) )
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                            }

                        }


                    }


                    cartSubTotalAmount = (float) (Convert.ToDecimal(PQty) * Convert.ToDecimal(dt.Rows[i]["PPrice"]));

                   
                    cartTotalAmount += (float) Convert.ToDouble(cartSubTotalAmount);
                }
                rptrCartProducts.DataSource = dt;
                rptrCartProducts.DataBind();


                cartTotal.InnerText = cartTotalAmount.ToString();

                //lblcartSubTotal.Text = cartSubTotalAmount.ToString();
        

            }
            else
            {
                
                totalItems.InnerText = "Your Shopping Cart is Empty";
            }

        }
        else
        {
            
            totalItems.InnerText = "Your Shopping Cart is Empty";

        }
    }

    protected void btnRemoveItem_Click(object sender, EventArgs e)
    {
        
        string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
        Button btn = (Button)(sender);
        string PIDQty = btn.CommandArgument;

        

        List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
        CookiePIDList.Remove(PIDQty);
        string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
        if (CookiePIDUpdated == "")
        {
            HttpCookie CartProducts = Request.Cookies["CartPID"];
            CartProducts.Values["CartPID"] = null;
            CartProducts.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(CartProducts);

        }
        else
        {
            HttpCookie CartProducts = Request.Cookies["CartPID"];
            CartProducts.Values["CartPID"] = CookiePIDUpdated;
            CartProducts.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(CartProducts);

        }


        string remPID = PIDQty.ToString().Split('-')[0];
        string remQty = PIDQty.ToString().Split('-')[1];

        using (SqlConnection conn = new SqlConnection(connStr))
        {

            using (SqlCommand cmd2 = new SqlCommand("UPDATE Products SET Quantity=Quantity + ( '" + Convert.ToInt64(remQty) + "' ) where PID=( '" + remPID + "') ", conn))
            {
                cmd2.CommandType = CommandType.Text;
                conn.Open();
                cmd2.ExecuteNonQuery();
                //Response.Redirect("~/ProductDetails.aspx?PID=" + PID);

            }


            using (SqlCommand cmd2 = new SqlCommand("delete from SelectedQuantity where PID = " + remPID + "", conn))
            {
                cmd2.CommandType = CommandType.Text;
                //conn.Open();
                cmd2.ExecuteNonQuery();

            }


            


        }


        



        Response.Redirect("~/Cart.aspx");
    }


    protected void btnBuy_Click(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {

            DateTime DateofOrder = DateTime.Now;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Users where Email = '" + Session["EMAIL"] + "' ", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                //}


                int userId = (int)(Convert.ToDouble(dt.Rows[0][0].ToString().Trim()));

                //using (SqlConnection conn = new SqlConnection(connStr))
                //{
                SqlCommand cmd2 = new SqlCommand("insert into Orders values('" + userId + "', '" + cartTotal.InnerText + "', '" + DateofOrder + "'  )", conn);
                //conn.Open();
                //cmd2.ExecuteNonQuery();
                //Int64 OrderId = Convert.ToInt64(cmd2.ExecuteScalar());

                //int lastOrderId = (int)OrderId;

                //SELECT TOP 1 * FROM Table ORDER BY ID DESC
                DataTable dt3 = new DataTable();
                using (SqlCommand cmd3 = new SqlCommand("select TOP 1 * from Orders ORDER BY OrderId DESC", conn))
                {
                    cmd3.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda2 = new SqlDataAdapter(cmd3))
                    {
                        sda2.Fill(dt3);

                    }

                }
                string lastOrderId = dt3.Rows[0]["OrderId"].ToString().Trim();


                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');   // As PID are stored as Comma Seperated Values so splitting and storing in array

                //string cook = "";

                if (CookieDataArray.Length > 0)
                {
                    DataTable dt2 = new DataTable();
                    //DataTable dt2 = new DataTable();

                    //float cartSubTotalAmount = 0;


                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string PID = CookieDataArray[i].ToString().Split('-')[0];
                        string PQty = CookieDataArray[i].ToString().Split('-')[1];


                        //using (SqlCommand cmd3 = new SqlCommand("select * from Products where Products.PID = " + PID + " ", conn))
                        //{
                        //    cmd3.CommandType = CommandType.Text;
                        //    using (SqlDataAdapter sda2 = new SqlDataAdapter(cmd3))
                        //    {
                        //        sda2.Fill(dt2);

                        //    }

                        //}
                        //string price = dt2.Rows[i]["PPrice"].ToString().Trim();





                        SqlCommand cmd4 = new SqlCommand("insert into OrderDetails values('" + lastOrderId + "', '" + PID + "', '" + PQty + "'  )", conn);
                        cmd4.ExecuteNonQuery();
                    }




                    Response.Redirect("~/Payment.aspx?order=" + lastOrderId);
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx?requestUrl=cart");
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null && Request.QueryString["order"] != null)
        {
            if (!IsPostBack)
            {
                displayPriceDetails();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }



    public void displayPriceDetails()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');
            if (CookieDataArray.Length > 0)
            {
                DataTable dt = new DataTable();
                double cartTotalAmount = 0;
                double cartSubTotalAmount = 0;
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string PID = CookieDataArray[i].ToString().Split('-')[0];
                    

                    //if (hdPID.Value != null && hdPID.Value != "")
                    //{
                    //    hdPID.Value += "," + PID;
                    //}
                    //else
                    //{
                    //    hdPID.Value = PID;
                    //}

                    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

                    string PQty;

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        // using (SqlCommand cmd = new SqlCommand("select Products.*,ProductImagesObj.* from Products cross apply( select top 1 ProductImages.ImgName,ProductImages.ImgExt from ProductImages where ProductImages.PID=Products.PID ) ProductImagesObj where Products.PID=" + PID + "", conn))
                        using (SqlCommand cmd = new SqlCommand("select Products.*,ProductImagesObj.*,SelectedQuantityObj.* from Products  cross apply(select top 1 ProductImages.ImgName, ProductImages.ImgExt from ProductImages where ProductImages.PID= " + PID + " ) ProductImagesObj cross apply(select SelQuantity from SelectedQuantity where SelectedQuantity.PID = " + PID + " ) SelectedQuantityObj where Products.PID = " + PID + " ", conn))

                        //using (SqlCommand cmd = new SqlCommand("select * from SelectedQuantity", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                                PQty = dt.Rows[i]["SelQuantity"].ToString().Trim();
                            }

                        }
                    }

                    //foreach (DataRow row in dt.Rows)
                    //{
                      //  PQty = dt.Rows[0]["SelQuantity"].ToString().Trim();

                        cartSubTotalAmount = (Convert.ToDouble(PQty) * Convert.ToDouble(dt.Rows[i]["PPrice"]));

                        cartTotalAmount += cartSubTotalAmount;
                    //}
                }


                cartTotal.InnerText = cartTotalAmount.ToString();
                

                hdCartAmount.Value = cartTotalAmount.ToString();
                
                hdTotalPayed.Value = "";
            }
            else
            {
                
                Response.Redirect("~/displayAllroducts.aspx");
            }
        }
        else
        {
            Response.Redirect("~/displayAllroducts.aspx");
        }
    }


    protected void btnPay_Click(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            string userID;

            String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Users where Email = '" + Session["EMAIL"] + "'", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                userID = dt.Rows[0][0].ToString().Trim();
            }

                
                string PaymentType = "Paypal";
                string PaymentStatus = "NotPaid";
                DateTime DateofPurchase = DateTime.Now;
                string userEmail = Session["EMAIL"].ToString();
                //string CallbackURL = "http://www.callback.aspx";

                //Insert Data to Payment table
                //String connStr = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("insert into Payment values('" + userID + "','"
                        + Request.QueryString["order"] + "','" + hdCartAmount.Value + "','"
                        + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "','" + DateofPurchase + "','"
                        + tbName.Text + "','" + tbAddress.Text + "','" + tbMobileNumber.Text + "') select SCOPE_IDENTITY()", conn); // bcz we need ID of the last purchase as SCOPE_IDENTITY returns the last identity value generated for any table in the current session and the current scope

                    conn.Open();
                    Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar()); // The ExecuteScalar() executes SQL statements as well as Stored Procedure and returned a scalar value on first column of first row in the returned Result Set.

                    
                }
            }
        
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class AdminDisplayPayment : System.Web.UI.Page
{
    String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    string getId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            rptrBindPayments();

        }
        if (Request.QueryString["editPayment"] != null)
        {
            getId = Request.QueryString["editPayment"].ToString();


        }
        if (Request.QueryString["editPayment"] == null)
        {

            lblPayedAmount.Visible = false;
            lblPayStatus.Visible = false;
            tbPayedAmount.Visible = false;
            tbPayStatus.Visible = false;
            btnUpdatePay.Visible = false;
        }
            editPayments();

    }


    private void rptrBindPayments()
    {
        String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Payment ", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrPayment.DataSource = dt;
                    rptrPayment.DataBind();
                }

            }
        }
    }


    protected void btnUpdatePay_Click(object sender, EventArgs e)
    {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Payment SET TotalPayed = '" + tbPayedAmount.Text + "' , PaymentStatus = '" + tbPayStatus.Text + "' where PaymentID ='" + getId + "' ", conn);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();


            }
            tbPayedAmount.Text = string.Empty;
            tbPayStatus.Text = string.Empty;
    

        Response.Redirect("~/AdminDisplayPayment.aspx");

        rptrBindPayments();

    }


    public void editPayments()
    {
        if (Request.QueryString["editPayment"] != null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Payment where PaymentID = '" + getId + "' ", conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lblSelPayed.Text = dt.Rows[0]["TotalPayed"].ToString();
                lblSelPayStatus.Text = dt.Rows[0]["PaymentStatus"].ToString();
                
            }
        }
    }




}
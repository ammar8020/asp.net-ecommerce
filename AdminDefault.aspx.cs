using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class AdminDefault : System.Web.UI.Page
{

    string connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getSalesChart();
            getSalesChartTypes();

            getRevenueChart();
            getRevenueChartTypes();

            getUsersChart();
            getUsersChartTypes();
        }
    }

    private void getSalesChart()
    {

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            // Query to retrieve database data for the chart control
            SqlCommand cmd = new SqlCommand
                ("SELECT COUNT(Payment.PaymentID) AS C, MONTH(Payment.DateOfPurchase) AS P FROM Payment Group BY MONTH(Payment.DateOfPurchase)", conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            // Specify the column name that contains values for X-Axis
            Chart1.Series["Series1"].XValueMember = "P";
            // Specify the column name that contains values for Y-Axis
            Chart1.Series["Series1"].YValueMembers = "C";
            // Set the datasource
            Chart1.DataSource = rdr;
            // Finally call DataBind()
            Chart1.DataBind();

        }
    }



    private void getSalesChartTypes()
    {
        // 
        foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
        {
            ListItem li = new ListItem(Enum.GetName(
                typeof(SeriesChartType), chartType), chartType.ToString());
            DropDownList1.Items.Add(li);
        }

    }




    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSalesChart();
        getRevenueChart();
        getUsersChart();

        this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList1.SelectedValue);
        this.Chart2.Series["Series2"].ChartType = (SeriesChartType)Enum.Parse(
        typeof(SeriesChartType), DropDownList2.SelectedValue);
        this.Chart3.Series["Series3"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList3.SelectedValue);

    }





    private void getRevenueChart()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd2 = new SqlCommand
            ("SELECT SUM(Payment.TotalPayed) AS Revenue, MONTH(Payment.DateOfPurchase) AS Monthly FROM Payment Group BY MONTH(Payment.DateOfPurchase)", conn);

            conn.Open();
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            // Specify the column name that contains values for X-Axis
            Chart2.Series["Series2"].XValueMember = "Monthly";
            // Specify the column name that contains values for Y-Axis
            Chart2.Series["Series2"].YValueMembers = "Revenue";
            // Set the datasource
            Chart2.DataSource = rdr2;
            // Finally call DataBind()
            Chart2.DataBind();
        }
    }



    

    private void getRevenueChartTypes()
    {
        foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
        {
            ListItem li = new ListItem(Enum.GetName(
                typeof(SeriesChartType), chartType), chartType.ToString());
            DropDownList2.Items.Add(li);
        }
    }



    


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSalesChart();
        getRevenueChart();
        getUsersChart();

        this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(
                typeof(SeriesChartType), DropDownList1.SelectedValue);
        this.Chart2.Series["Series2"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList2.SelectedValue);
        this.Chart3.Series["Series3"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList3.SelectedValue);
    }





    private void getUsersChart()
    {

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            // Query to retrieve database data for the chart control
            SqlCommand cmd = new SqlCommand
                ("SELECT COUNT(UserId) AS Users, MONTH(RegDate) AS Monthly FROM Users WHERE UserType = 2 Group BY MONTH(RegDate)", conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            // Specify the column name that contains values for X-Axis
            Chart3.Series["Series3"].XValueMember = "Monthly";
            // Specify the column name that contains values for Y-Axis
            Chart3.Series["Series3"].YValueMembers = "Users";
            // Set the datasource
            Chart3.DataSource = rdr;
            // Finally call DataBind()
            Chart3.DataBind();

        }
    }



    private void getUsersChartTypes()
    {
        // 
        foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
        {
            ListItem li = new ListItem(Enum.GetName(
                typeof(SeriesChartType), chartType), chartType.ToString());
            DropDownList3.Items.Add(li);
        }

    }




    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSalesChart();
        getRevenueChart();
        getUsersChart();

        this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList1.SelectedValue);
        this.Chart2.Series["Series2"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList2.SelectedValue);
        this.Chart3.Series["Series3"].ChartType = (SeriesChartType)Enum.Parse(
            typeof(SeriesChartType), DropDownList3.SelectedValue);

    }



}
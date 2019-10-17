<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeFile="AdminDefault.aspx.cs" Inherits="AdminDefault" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div class="row">
                    <div class="col-md-4">
                        <div class="card">

                            <div class="header">
                                <h4 class="title">Total no. of sales by month</h4>
                                <p class="category">24 Hours performance</p>
                            </div>
                            <div class="content">
                                <div id="chartPreferences" class="ct-chart ct-perfect-fourth">



                                    <table style="font-family: Arial; width:100px; height:100px; " >
                                        <tr>
                                            <td>
                                                <b>Select Chart Type:</b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server"
                                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">


                                    <asp:Chart ID="Chart1" runat="server">
                                        <Titles>
                                            <asp:Title Text="Total no. of sales by month">
                                            </asp:Title>
                                        </Titles>
                                        <Series>
                                            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Column">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                                <AxisX Title="Months">
                                                </AxisX>
                                                <AxisY Title="Total no. of sales">
                                                </AxisY>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>



                                                 </td>
</tr>
</table>

                                </div>

                              
                                    <br>
                                    <div class="stats">
                                        <i class="fa fa-history"></i> Updated dynamically
                                    </div>
                                </div>
                          
                        </div>
                    </div>



        <div class="col-md-8">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Monthly total revenue from sales</h4>
                                <p class="category">24 Hours performance</p>
                            </div>
                            <div class="content">
                                <div id="chartHours" class="ct-chart">


                                    <table style="font-family: Arial; width:500px; height:100px; " >
                                        <tr>
                                            <td>
                                                <b>Select Chart Type:</b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server"
                                                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" >


                                    <asp:Chart ID="Chart2" runat="server">
                                        <Titles>
                                            <asp:Title Text="Monthly total revenue from sales">
                                            </asp:Title>
                                        </Titles>
                                        <Series>
                                            <asp:Series Name="Series2" ChartArea="ChartArea2" ChartType="Area">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea2">
                                                <AxisX Title="Months">
                                                </AxisX>
                                                <AxisY Title="Total revenue from sales">
                                                </AxisY>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>



                                                 </td>
</tr>
</table>



                                </div>

                                
                                    <br>
                                    <br />
                                    <%--<div class="stats">
                                        <i class="fa fa-history"></i> Updated dynamically
                                    </div>--%>
                                </div>
                            
                        </div>
                    </div>



        </div>



    

    <div class="row">
                    <div class="col-md-6">
                        <div class="card ">
                            <div class="header">
                                <h4 class="title">Total no. of Users Registered Monthly</h4>
                                <p class="category">24 Hours performance</p>
                            </div>
                            <div class="content">
                                <div id="chartActivity" class="ct-chart">




                                    <table style="font-family: Arial; width:400px; height:100px; " >
                                        <tr>
                                            <td>
                                                <b>Select Chart Type:</b>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList3" AutoPostBack="true" runat="server"
                                                    OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" >


                                    <asp:Chart ID="Chart3" runat="server">
                                        <Titles>
                                            <asp:Title Text="Total no. of Users Registered Monthly">
                                            </asp:Title>
                                        </Titles>
                                        <Series>
                                            <asp:Series Name="Series3" ChartArea="ChartArea3" ChartType="StackedBar">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea3">
                                                <AxisX Title="Months">
                                                </AxisX>
                                                <AxisY Title="Total Users Registered">
                                                </AxisY>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>



                                                 </td>
</tr>
</table>





                                </div>

                                <div class="footer">
                                    <div class="legend">
                                        
                                    </div>
                                    <br>
                                    <%--<div class="stats">
                                        <i class="fa fa-history"></i> Updated dynamically
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>









        </div>





</asp:Content>





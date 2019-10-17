<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="displayPayment.aspx.cs" Inherits="displayPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="span9">
        

    <h1>Payment</h1>
        <hr />
        <div class="well">
            <div class="form-horizontal">
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Shipping Details</div>

            <asp:Repeater ID="rptrPayment" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>User ID</th>
                                <th>Recipient Name</th>
                                <th>Address</th>
                                <th>Mobile No.</th>
                                <th>Order ID</th>
                                <th>Total Amount</th>
                                <th>Payed Amount</th>
                                <th>Payment Type</th>
                                <th>Payment Status</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("PaymentID") %></th>
                        <td><%# Eval("UserId") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Address") %></td>
                        <td><%# Eval("MobileNumber") %></td>
                        <td><%# Eval("OrderId") %></td>
                        <td><%# Eval("CartTotal") %></td>
                        <td><%# Eval("TotalPayed") %></td>
                        <td><%# Eval("PaymentType") %></td>
                        <td><%# Eval("PaymentStatus") %></td>
                        
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

    </div>
 </div>

        </div>



</asp:Content>


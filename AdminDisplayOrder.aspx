<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeFile="AdminDisplayOrder.aspx.cs" Inherits="AdminDisplayOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Orders</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Orders</div>

            <asp:Repeater ID="rptrOrders" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>User Name</th>
                                <th>Full Name</th>
                                <th>Email</th>
                                <th>Total Amount</th>
                                <th>Date of Order</th>
                                <th>Order Details</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("orderID") %></th>
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("CartTotal") %></td>
                        <td><%# Eval("DateOfOrder") %></td>
                        <td> <a href="AdminOrderDetails.aspx?order=<%# Eval("orderID") %>"> Order Details </a> </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

</asp:Content>


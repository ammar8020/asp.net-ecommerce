<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="displayOrders.aspx.cs" Inherits="displayOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="span9">
    <h1>Orders</h1>
        <hr />
        <div class="well">
            <div class="form-horizontal">
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
                        <td> <a href="OrderDetails.aspx?order=<%# Eval("orderID") %>"> Order Details </a> </td>
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


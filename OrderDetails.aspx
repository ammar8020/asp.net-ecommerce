<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="span9">
        

    <h1>Order Details</h1>
        <hr />
        <div class="well">
            <div class="form-horizontal">
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Order Details</div>

            <asp:Repeater ID="rptrOrderDetails" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Order ID</th>
                                <th>Product ID</th>
                                <th>Product Name</th>
                                <th>Product Price</th>
                                <th>Quantity Bought</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("Id") %></th>
                        <td><%# Eval("OrderId") %></td>
                        <td><%# Eval("PID") %></td>
                        <td><%# Eval("PName") %></td>
                        <td><%# Eval("PPrice") %></td>
                        <td><%# Eval("SelQuantity") %></td>
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


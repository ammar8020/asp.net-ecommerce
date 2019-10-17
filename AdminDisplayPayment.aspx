<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeFile="AdminDisplayPayment.aspx.cs" Inherits="AdminDisplayPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div class="form-horizontal">
            <h2>Update Payment Details</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="lblPayedAmount" runat="server" CssClass="col-md-2 control-label" Text="Payed Amount"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbPayedAmount" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPayedAmount" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbPayedAmount"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblSelPayed" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
                </div>
                
            </div>
            <div class="form-group">
                <asp:Label ID="lblPayStatus" runat="server" CssClass="col-md-2 control-label" Text="Payment Status"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbPayStatus" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbPayStatus"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblSelPayStatus" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
                </div>
                
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnUpdatePay" runat="server" Text="Update Payment" CssClass="btn btn-default" OnClick="btnUpdatePay_Click" />
                </div>
            </div>
        </div>


    <h1>Payment</h1>
        <hr />

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
                                <th>Edit</th>
                                
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
                        <td> <a href="AdminDisplayPayment.aspx?editPayment=<%# Eval("PaymentID") %>"> Edit </a> </td>
                        
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

</asp:Content>


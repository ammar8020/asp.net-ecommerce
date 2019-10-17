<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeFile="AdminAddBrand.aspx.cs" Inherits="AdminAddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="form-horizontal">
            <h2>Add Brand</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="lblBrandName" runat="server" CssClass="col-md-2 control-label" Text="Brand Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbBrandName"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblSelBrand" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnAddBrand" runat="server" Text="Add Brand" CssClass="btn btn-default" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>

        <h1>Brands</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Brands</div>

            <asp:Repeater ID="rptrBrands" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Brand</th>
                                <th>Edit</th>
                                <th>Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("BrandID") %></th>
                        <td><%# Eval("BrandName") %></td>
                        <td> <a href="AdminAddBrand.aspx?editBrand=<%#Eval("BrandID") %>"> Edit </a> </td>
                        <td> <a href="AdminAddBrand.aspx?brand=<%#Eval("BrandID") %>"> Delete </a> </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

</asp:Content>


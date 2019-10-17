<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeFile="AdminAddCategory.aspx.cs" Inherits="AdminAddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <div class="form-horizontal">
            <h2>Add Category</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="lblCatName" runat="server" CssClass="col-md-2 control-label" Text="Category Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbCatName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCatName" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbCatName"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblSelCat" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnAddCat" runat="server" Text="Add Category" CssClass="btn btn-default" OnClick="btnAddCat_Click" />
                </div>
            </div>
        </div>
        <h1>Categories</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Categories</div>

            <asp:Repeater ID="rptrCategories" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Category</th>
                                <th>Edit</th>
                                <th>Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("CatID") %></th>
                        <td><%# Eval("CatName") %></td>
                        <td> <a href="AdminAddCategory.aspx?editCategory=<%#Eval("CatID") %>"> Edit </a> </td>
                        <td> <a href="AdminAddCategory.aspx?category=<%#Eval("CatID") %>"> Delete </a> </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>


</asp:Content>


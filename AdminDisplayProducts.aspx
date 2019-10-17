<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeFile="AdminDisplayProducts.aspx.cs" Inherits="AdminDisplayProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="form-horizontal">
            <h2>Update Product</h2>
            
            <hr />
            <div class="form-group">
                
                <asp:Label ID="lblName" runat="server" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                
                </div>
                <asp:Label ID="lblSelName" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
                <asp:Label ID="lblMsg" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPrice" runat="server" CssClass="col-md-2 control-label" Text="Price"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbPrice" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbPrice"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblSelPrice" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            
            </div>
            <%--<div class="form-group">
                <asp:Label ID="lblBrand" runat="server" CssClass="col-md-2 control-label" Text="Brand"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlBrand" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblSelBrand" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            
            </div>
            <div class="form-group">
                <asp:Label ID="lblCategory" runat="server" CssClass="col-md-2 control-label" Text="Category"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlCategory" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>--%>
                
            <div class="form-group">
                <asp:Label ID="lblShtDet" runat="server" CssClass="col-md-2 control-label" Text="Short Detail"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbShtDet" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShtDet" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbShtDet"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblSelSht" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblLngDet" runat="server" CssClass="col-md-2 control-label" Text="Long Detail"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbLngDet" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLngDet" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbLngDet"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblSelLng" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblQuantity" runat="server" CssClass="col-md-2 control-label" Text="Quantity"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuantity" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbQuantity"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblSelQuan" runat="server" CssClass="col-md-2 control-label" Text=""></asp:Label>
            </div>
            
            <div class="form-group">
                <asp:Label ID="lblImg1" runat="server" CssClass="col-md-2 control-label" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg1" CssClass="form-control" runat="server" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorImg1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg1"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblImg2" runat="server" CssClass="col-md-2 control-label" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg2" CssClass="form-control" runat="server" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorImg2" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg2"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblImg3" runat="server" CssClass="col-md-2 control-label" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg3" CssClass="form-control" runat="server" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorlblImg3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg3"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnUpdateProd" runat="server" Text="Update Product" CssClass="btn btn-default" OnClick="btnUpdateProd_Click" />
                </div>
            </div>
        </div>






    <h1>Products</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Products</div>

            <asp:Repeater ID="rptrProducts" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Name</th>
                                <th>Price</th>
                                <th>Short Detail</th>
                                <th>Long Detail</th>
                                <th>Quantity</th>
                                <th>Edit</th>
                                <th>Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("PID") %></th>
                        <td><%# Eval("PName") %></td>
                        <td><%# Eval("PPrice") %></td>
                        <td><%# Eval("PShtDet") %></td>
                        <td><%# Eval("PLngDet") %></td>
                        <td><%# Eval("Quantity") %></td>
                        <td> <a href="AdminDisplayProducts.aspx?editProduct=<%#Eval("PID") %>"> Edit </a> </td>
                        <td> <a href="AdminDisplayProducts.aspx?delProduct=<%#Eval("PID") %>"> Delete </a> </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>


</asp:Content>


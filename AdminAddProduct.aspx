<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeFile="AdminAddProduct.aspx.cs" Inherits="AdminAddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
        <div class="form-horizontal">
            <h2>Add Product</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="lblName" runat="server" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPrice" runat="server" CssClass="col-md-2 control-label" Text="Price"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbPrice" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbPrice"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblBrand" runat="server" CssClass="col-md-2 control-label" Text="Brand"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlBrand" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblCategory" runat="server" CssClass="col-md-2 control-label" Text="Category"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlCategory" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
                
            <div class="form-group">
                <asp:Label ID="lblShtDet" runat="server" CssClass="col-md-2 control-label" Text="Short Detail"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbShtDet" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShtDet" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbShtDet"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblLngDet" runat="server" CssClass="col-md-2 control-label" Text="Long Detail"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbLngDet" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLngDet" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbLngDet"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblQuantity" runat="server" CssClass="col-md-2 control-label" Text="Quantity"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuantity" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbQuantity"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="form-group">
                <asp:Label ID="lblImg1" runat="server" CssClass="col-md-2 control-label" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg1" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorImg1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg1"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblImg2" runat="server" CssClass="col-md-2 control-label" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg2" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorImg2" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg2"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblImg3" runat="server" CssClass="col-md-2 control-label" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg3" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorlblImg3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg3"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnAddProd" runat="server" Text="Add Product" CssClass="btn btn-default" OnClick="btnAddProd_Click" />
                </div>
            </div>
        </div>
    
</asp:Content>


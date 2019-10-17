<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="span9">
        

    <div class="span1"> &nbsp;</div>
		<div class="span4">

            <h3>Login</h3>
			<div class="well">
			

                <div class="control-group">
                    <asp:Label ID="lblEmail" runat="server" CssClass="control-label" Text="Email"></asp:Label>
                    <div class="controls">
                        <asp:TextBox ID="txtBoxEmail" CssClass="span3" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClass="text-danger" runat="server" ErrorMessage="The Email field is Required !" ControlToValidate="txtBoxEmail"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="control-group">
                    <asp:Label ID="lblPass" runat="server" CssClass="control-label" Text="Password"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtBoxPass" CssClass="span3" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" ErrorMessage="The Password field is Required !" ControlToValidate="txtBoxPass"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:CheckBox ID="ChkBoxRem" runat="server" />
                        <asp:Label ID="lblRem" runat="server" CssClass="control-label" Text="Remember me ?"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-default" OnClick="btnLogin_Click" />
                        <asp:LinkButton ID="LnkBtnSignUp" runat="server" PostBackUrl="~/Register.aspx">Sign Up</asp:LinkButton>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:LinkButton ID="lblForgotPass" runat="server" PostBackUrl="~/ForgotPass.aspx">Forgot Password !</asp:LinkButton>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
           
        
			
		</div>
		</div>
	</div>
</asp:Content>


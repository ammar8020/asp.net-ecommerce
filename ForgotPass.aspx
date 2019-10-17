<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="ForgotPass.aspx.cs" Inherits="ForgetPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="span9">
    <ul class="breadcrumb">
		<li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
		<li class="active">Forget password?</li>
    </ul>
	<h3> FORGET YOUR PASSWORD?</h3>	
	<hr class="soft"/>
	
	<div class="row">
		<div class="span9" style="min-height:900px">
			<div class="well">
			<h5>Reset your password</h5><br/>
			Please enter the email address for your account. A verification code will be sent to you. Once you have received the verification code, you will be able to choose a new password for your account.<br/><br/><br/>
			
			  <div class="control-group">

                  <asp:Label ID="lblEmail" runat="server" CssClass="control-label" Text="Email Address"></asp:Label>
				<div class="controls">
                    <asp:TextBox ID="txtBoxEmail" CssClass="span3" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClass="text-danger" runat="server" ErrorMessage="Email Address is required!" ControlToValidate="txtBoxEmail"></asp:RequiredFieldValidator>
				</div>
			  </div>
			  <div class="controls">
                  <asp:Button ID="btnSubEmail" CssClass="btn block" runat="server" Text="Submit" OnClick="btnSubEmail_Click" />
			      <asp:Label ID="lblPassReq" runat="server" Text=""></asp:Label>
              </div>
			
		</div>
		</div>
	</div>	
	
</div>


</asp:Content>


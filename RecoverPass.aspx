<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="RecoverPass.aspx.cs" Inherits="RecoverPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Recover Password
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="span9">
    <ul class="breadcrumb">
		<li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
		<li class="active">Reset password</li>
    </ul>
	<h3> Reset your Password </h3>	
	<hr class="soft"/>
	
	<div class="row">
		<div class="span9" style="min-height:900px">
			<div class="well">
			
			  <div class="control-group">

                  <asp:Label ID="lblMsg" runat="server" CssClass="control-label" Font-Size="Large" Font-Bold="True"></asp:Label>
                    </div>

				<div class="controls">
                    <asp:Label ID="lblPass" runat="server" CssClass="control-label" Text="New Password" Visible="False"></asp:Label>
                   
				    <div class="col-md-3">
                        <asp:TextBox ID="txtBoxNewPass" CssClass="span3" TextMode="Password" runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPass" CssClass="text-danger" runat="server" ErrorMessage="Please enter your new Password !" ControlToValidate="txtBoxNewPass"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="controls">
                    <asp:Label ID="lblConPass" runat="server" CssClass="control-label" Text="Confirm Password" Visible="False"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtBoxConPass" CssClass="span3" TextMode="Password" runat="server" Visible="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConPass" CssClass="text-danger" runat="server" ErrorMessage="Please Confirm your new Password !" ControlToValidate="txtBoxConPass"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorConPass" runat="server" CssClass="text-danger" ErrorMessage="Both Password must be same !" ControlToCompare="txtBoxConPass" ControlToValidate="txtBoxNewPass"></asp:CompareValidator>
                        </div>
                    </div>

			  <div class="controls">
                  <asp:Button ID="btnResPass" CssClass="btn block" runat="server" Text="Reset" Visible="False" OnClick="btnResPass_Click"/>
              </div>
			
		</div>
		</div>
	</div>	

</div>
	

</asp:Content>


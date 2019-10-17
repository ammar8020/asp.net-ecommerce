<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Sign Up -->

    <div class="span9">
    <h3> Registration </h3>
        <div class="well">
            <div class="form-horizontal">
        
                    <div class="control-group">
                    <label class="control-label">Username</label>
                    <div class="controls">
                        <asp:TextBox ID="tbUname" runat="server" placeholder="Usename"></asp:TextBox>
                    </div>
                    </div>
                    
                    <div class="control-group">
                    <label class="control-label">Name</label>
                    <div class="controls">
                        <asp:TextBox ID="tbName" runat="server" placeholder="Name"></asp:TextBox>
                    </div>
                    </div>
                    
                    <div class="control-group">
                    <label class="control-label">Email</label>
                    <div class="controls">
                        <asp:TextBox ID="tbEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                    </div>
                    </div>
                    
                    <div class="control-group">
                    <label class="control-label">Password</label>
                    <div class="controls">
                        <asp:TextBox ID="tbPass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                    </div>
                    
                    <div class="control-group">
                    <label class="control-label">Confirm Password</label>
                    <div class="controls">
                        <asp:TextBox ID="tbCPass" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                    </div>
                    </div>
                    
                    <div class="control-group">
                    <label class="control-label">Address</label>
                    <div class="controls">
                        <asp:TextBox ID="tbAddress" runat="server" placeholder="Address" ></asp:TextBox>
                    </div>
                    </div>
                    
                    <div class="control-group">
                    <div class="controls">
                        <asp:Button ID="btSignup" runat="server" Class="btn btn-large btn-success" Text="Sign Up" OnClick="btSignup_Click"  />
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    </div>

            </div>
        </div>
    </div>
	
        <!-- Sign Up -->

</asp:Content>
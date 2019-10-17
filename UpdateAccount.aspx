<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="UpdateAccount.aspx.cs" Inherits="UpdateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="span9">
    <h3> Update Account </h3>
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
                        <asp:Button ID="btnUpdate" runat="server" Class="btn btn-large btn-success" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    </div>

            </div>
        </div>
    </div>

</asp:Content>


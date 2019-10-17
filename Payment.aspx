<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="span9">
    <ul class="breadcrumb">
		<li><a href="index.html">Home</a> <span class="divider">/</span></li>
		<li class="active"> SHOPPING CART</li>
    </ul>


        <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hdPID" runat="server" />


        <div>
                    <label>Cart Total = <span class="label label-important" id="cartTotal" runat="server"></span></label>
                    
                </div>
        <br />

    <table class="table table-bordered">
			 <tbody><tr><th>ESTIMATE YOUR SHIPPING </th></tr>
			 <tr> 
			 <td>
				<div class="form-horizontal">
				  <div class="control-group">
                      <asp:Label ID="Label5" runat="server" CssClass="control-label" Text="Name"></asp:Label>
					
					<div class="controls">
                        <asp:TextBox ID="tbName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbName"></asp:RequiredFieldValidator>
					  
					</div>
				  </div>
				  <div class="control-group">

                      <asp:Label ID="Label6" runat="server" CssClass="control-label" Text="Address"></asp:Label>
                      <div class="controls">
                        <asp:TextBox ID="tbAddress" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbAddress"></asp:RequiredFieldValidator>
					</div>
				  </div>


                    <div class="control-group">

                      <asp:Label ID="Label7" runat="server" CssClass="control-label" Text="Mobile Number"></asp:Label>
					
					<div class="controls">
                        <asp:TextBox ID="tbMobileNumber" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="tbMobileNumber"></asp:RequiredFieldValidator>
					  
					</div>
				  </div>


				  <div class="control-group">
					<div class="controls">
					  
					</div>
				  </div>
				</div>				  
			  </td>
			  </tr>
            </tbody>

    </table>


        <div class="col-md-12">
            <h3>Choose Payment Mode</h3>
            <hr />
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#wallets">Paypal</a></li>
                <li><a data-toggle="tab" href="#cards">CREDIT/DEBIT CARDS</a></li>
            </ul>

            <div class="tab-content">
                <div id="wallets" class="tab-pane fade in active">
                    <asp:Button ID="Button1" OnClick="btnPay_Click" CssClass="btn" runat="server"  Text="Pay with Paypal" />
                </div>
                <div id="cards" class="tab-pane fade">
                    <p>Pay with Credit/Debit Card</p>
                </div>
            </div>
        </div>


        </div>




         
   

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   


    <div class="span9">

    <ul class="breadcrumb">
		<li><a href="index.html">Home</a> <span class="divider">/</span></li>
		<li class="active"> SHOPPING CART</li>
    </ul>
	<h3> SHOPPING CART <a href="products.html" id="totalItems" class="btn btn-large pull-right" runat="server"><i class="icon-arrow-left"></i> Continue Shopping </a></h3>	
	<hr class="soft"/>
	
			
	<table class="table table-bordered">
              <thead>
                <tr>
                  <th>Product</th>
                  <th>Description</th>
                  <th>Quantity</th>
				  <th>Price</th>
                  <th>Remove</th>
				</tr>
              </thead>





        <asp:Repeater ID="rptrCartProducts" runat="server">
                <ItemTemplate>

              <tbody>
                <tr style="height: 60px;">
                  <td> <img width="60" style="height: 60px;" src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("imgName") %><%#Eval("imgExt") %>" alt="<%#Eval("imgName") %>" onerror="this.src='images/noimage.jpg'" /></td>
                  <td><%#Eval("PName") %></td>
				  <td>
                      <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                      <%--<asp:Label ID="lblReqQty" runat="server" Text=""></asp:Label>--%>

                     <%#Eval("SelQuantity") %>
			
				  </td>
                  <td>$<%#Eval("PPrice") %></td>

                  <td><asp:Button CommandArgument='<%#Eval("PID")+"-"+ Eval("SelQuantity") %> '  ID="btnRemoveItem" CssClass="removeButton" OnClick="btnRemoveItem_Click" runat="server" Text="REMOVE" /></td>
               
              </tr>
				
                


                  <br />

				</tbody>

                     </ItemTemplate>
            </asp:Repeater>


            </table>

                   
        <br />
        

        <div>


                <%--<asp:Label ID="lblcartSubTotal" runat="server" Text="Label"></asp:Label>--%>

                    <label>Cart Total = <span class="label label-important" id="cartTotal" runat="server"></span></label>
                    
                </div>


        <br />


        
		
		
	<a href="Default.aspx" class="btn btn-large"><i class="icon-arrow-left"></i> Continue Shopping </a>
    <asp:Button ID="btnBuy" OnClick="btnBuy_Click" CssClass="btn btn-large pull-right" runat="server" Text="CheckOut" />
	
	
</div>

<!-- MainBody End ============================= -->


</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultLayout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    


<div id="carouselBlk" >
	<div id="myCarousel" class="carousel slide"> 
		<div class="carousel-inner">



            <asp:Repeater ID="rptrImages" runat="server">
                <ItemTemplate>

		  <div class="item">
		  <div class="container" >

              

			<a href="Images/SliderImages/<%#Eval("SImgName") %><%#Eval("SImgExt") %>" title="<%#Eval("SImgName") %>" > 
                <img style="width:1170px; height:480px" src="Images/SliderImages/<%#Eval("SImgName") %><%#Eval("SImgExt") %>" alt="<%#Eval("SImgName") %>" />

			</a>

			<div class="carousel-caption">
				  
				</div>

		  </div>
		  </div>

		  </ItemTemplate>

                </asp:Repeater>


		</div>
		<a class="left carousel-control" href="#myCarousel" data-slide="prev">&lsaquo;</a>
		<a class="right carousel-control" href="#myCarousel" data-slide="next">&rsaquo;</a>
	  </div> 
</div>

    </asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    


    <div class="span9">



        

    <ul class="breadcrumb">
    </ul>
	
	  
<div id="myTab" class="pull-right">

</div>

<div class="tab-content">
	<div class="tab-pane" id="listView">
		
	</div>

	<div class="tab-pane  active" id="blockView">
		<ul class="thumbnails">

            <asp:Repeater ID="rptrProducts" runat="server">
            <ItemTemplate>

			<li class="span3">
			  <div class="thumbnail">
				<a href="ProductDetails.aspx?PID=<%#Eval("PID") %>"><img src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("ImgName") %><%#Eval("ImgExt") %>" alt="<%#Eval("ImgName") %>" width="160" height="160"></a>
				<div class="caption">
				  <h5><%#Eval("BrandName") %> &nbsp | &nbsp <%#Eval("PName") %> </h5>
				  <p> 
					<%#limitChars(Eval("PShtDet")) %>
				  </p>
				   <h4 style="text-align:center"><a class="btn" href="product_details.html"> <i class="icon-zoom-in"></i></a> <a class="btn" href="#">Add to <i class="icon-shopping-cart"></i></a> <a class="btn btn-primary" href="#"><%#Eval("PPrice") %> $ </a></h4>
				</div>
			  </div>
			</li>


                </ItemTemplate>
        </asp:Repeater>

			
		  </ul>
	<hr class="soft">
	</div>
</div>

	<a href="compair.html" class="btn btn-large pull-right">Compair Product</a>
	<div class="pagination">
			<ul>
			<li><a href="#">‹</a></li>
			<li><a href="#">1</a></li>
			<li><a href="#">2</a></li>
			<li><a href="#">3</a></li>
			<li><a href="#">4</a></li>
			<li><a href="#">...</a></li>
			<li><a href="#">›</a></li>
			</ul>
			</div>
			<br class="clr">
</div> 




</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Odev1.Categories.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Categories.js"> </script>
    <title>Ürün Listele</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div class="bg-secondary">   
    <h2 class="ml-2 text-white ">Urünler</h2>
    <div id="container-products" class="row">
        <%=ProductTable %>

    </div>

    <h2 class="ml-2 text-white">Kategoriler</h2>
    <div id="container-categories" class="row">
        <%=CategoryTable %>
    </div>
        <br />
        <br />
        <br />
    </div>
</asp:Content>

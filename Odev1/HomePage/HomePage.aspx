<%@ Page Language="C#" MasterPageFile="/Master.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Odev1.HomePage.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="HomePage.js"> </script>
    <title>Ürün Listele</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-secondary text-white">
        <div class="bg-secondary text-white" style="padding: 15px;">
            <div>
                <h3>Kategoriler</h3>
            </div>
            <div id="category-container" class="row" style="">
            </div>
        </div>
        <div class="bg-secondary text-white" style="padding: 15px;">
            <div>
                <h3>Ürünler</h3>
            </div>
            <div class="product-filter">
                <input type="hidden" name="CategoryID" value="0" />
                <div class="form-row">
                    <div class="form-group col-4">
                        <label>Ürün Adı</label>
                        <input type="text" class="ml-2 mr-2" style="width: 240px;" name="ProductName">
                        <button class="btn btn-danger" id="search">ARA</button>
                    </div>
                    <%-- <div class="form-group col-md-6">
                    <label for="inputPassword4">Password</label>
                    <input type="password" class="form-control" id="inputPassword4">
                </div>--%>
                </div>
                <button onclick="Page.ClearFilter()" class="btn btn-warning ml-2">Filtreleri Temizle</button>
            </div>
            <div id="product-container" class="row">
            </div>
        </div>
    </div>
</asp:Content>

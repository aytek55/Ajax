<%@ Page Language="C#" MasterPageFile="/Master.Master" AutoEventWireup="true" CodeBehind="PDefault1.aspx.cs" Inherits="Odev1.ProductStuff.PDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ProductTransactions.js"> </script>
    <title>Ürün Listele</title>
    <style>
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-secondary text-white">
        <div class="row">
            <div class="col-3 mt-4 ml-4">
                <label class="yazi" for="pID">ProductID :</label>
                <input class="tbox" type="text" id="IPI" disabled ="disabled" /><br />
                <label class="yazi" for="pName">ProductName :</label>
                <input class="tbox" type="text" id="IPN" /><br />
                <label class="yazi" for="SupplierID">SupplierID :</label>
                <select class="SupplierSelector" style="width: 210px;" id="ISI">
                </select><br />
                <label class="yazi" for="CategoryID">CategoryID :</label>
                <select style="width: 210px;" class="ICI" id="ICI">
                </select><br />
                <label class="yazi" for="QuantityPerUnit">QuantityPerUnit :</label>
                <input class="tbox" type="text" id="IQPU" /><br />
                <label class="yazi" for="UnitPrice">UnitPrice :</label>
                <input class="tbox" type="text" id="IUP" /><br />
                <label class="yazi" for="UnitsInStock">UnitsInStock :</label>
                <input class="tbox" type="text" id="IUIS" /><br />
                <label class="yazi" for="UnitsOnOrder">UnitsOnOrder :</label>
                <input class="tbox" type="text" id="IUOO" /><br />
                <label class="yazi" for="ReorderLevel">ReorderLevel :</label>
                <input class="tbox" type="text" id="IRL" /><br />
                <label class="yazi" for="Discontinued">Discontinued :</label>
                <input type="checkbox" id="cxb_discontinued" checked="checked" />
                <br />
                <input type="button" class="btn btn-primary mt-2 mb-3" id="add" value="Add" />
                <input type="button" class="btn btn-info mt-2 mb-3" id="update" value="Update" />
                <button class="btn btn-success mt-2 mb-3" id="btn1">Get List Product</button>

            </div>
            <br />
            <div class="col-2" style="margin-top:15px;">
                <input type="text" style="width: 140px;" placeholder="Enter ID" id="IGPBI" />
                <br />
                <button class="btn btn-danger" id="getProductById">GetProductByID</button>

            </div>
            <div class="col-3 mt-4 filter-container">
                <input class="tbox" type="text" placeholder="ProductID" id="IPI2" /><br />
                <input class="tbox" type="text" placeholder="ProductName" id="IPN2" /><br />
                <input class="tbox" type="text" placeholder="UnitsInStock" id="IUIS2" /><br />
                <select style="width: 210px;" class="ICI" id="selectorCategory">
                </select><br />
                <button class="btn btn-danger mt-2" id="getProductFilter">Filter</button>
                <button class="btn btn-danger mt-2" id="btnClear">Clear</button>
            </div>
        </div>
    </div>
    <h2 class="ml-2">Product List</h2>

    <table class="table-info" id="Table">
        <thead>
            <tr>
                <th>Id</th>
                <th>ProductName</th>
                <th>SupplierID</th>
                <th>CategoryID</th>
                <th>QuantityPerUnit</th>
                <th>UnitPrice</th>
                <th>UnitsInstock</th>
                <th>UnitsOnOrder</th>
                <th>ReorderLevel</th>
                <th>Discontinued</th>
                <th></th>
            </tr>
        </thead>
        <tbody class="table-warning" id="div_Loader">
        </tbody>

    </table>
    <br />
</asp:Content>

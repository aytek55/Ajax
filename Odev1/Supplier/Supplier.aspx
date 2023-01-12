<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="Odev1.Supplier.Supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="SupplierTransactions.js?v=1.2"> </script>
    <title>Ürün Listele</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-secondary text-white">
        <div id="AddProduct" style="">
            <div class="row">
                <div class="col-3 ml-3 txtbox-container" id="">
                    <br />
                    <label class="yazi" for="SupplierID">SupplierID :</label>
                    <input class="tbox" type="text" id="txtSupID" disabled="disabled" /><br />
                    <label class="yazi" for="CompanyName">CompanyName :</label>
                    <input class="tbox" type="text" id="txtComName" /><br />
                    <label class="yazi" for="ContactName">ContactName :</label>
                    <input class="tbox" type="text" id="txtConName" /><br />
                    <label class="yazi" for="Adress">Adress :</label>
                    <input class="tbox" type="text" id="txtAddress" /><br />
                    <label class="yazi" for="City">City :</label>
                    <select class="citySelector" style="width: 210px;" id="selectorCity">
                    </select><br />
                    <label class="yazi" for="Region">Region :</label>
                    <input class="tbox" type="text" id="txtRegion" /><br />
                    <label class="yazi" for="PostalCode">PostalCode :</label>
                    <input class="tbox" type="text" id="txtPostalCode" /><br />
                    <label class="yazi" for="Country">Country :</label>
                    <select class="countrySelector" style="width: 210px;" id="txtCountrySelector">
                    </select><br />
                    <label class="yazi" for="Phone">Phone :</label>
                    <input class="tbox" type="text" id="txtPhone" /><br />
                    <label class="yazi" for="Fax">Fax :</label>
                    <input class="tbox" type="text" id="txtFax" /><br />
                    <label class="yazi" for="HomePage">HomePage :</label>
                    <input class="tbox" type="text" id="txtHomePage" /><br />
                    <div class="mb-3">   
                    <button class="btn btn-primary mt-2" id="add">Add</button>
                    <button class="btn btn-info mt-2" id="update">Update</button>
                    <button class="btn btn-success mt-2" id="btn1">Get List Supplier</button>
                    <button class="btn btn-danger mt-2" id="btnClear" onclick="Page.Clear()">Clear</button>
                    </div>

                </div>
                <div class="col-2">
                    <br />
                    <input type="text" placeholder="Enter ID" id="txtGetbyID" />
                    <br />
                    <button class="btn btn-danger mt-2" id="getSupplierById">GetSupplierByID</button>

                </div>
                <div class="col-3 filter-container">
                    <br />
                    <label class="yazi" for="SupplierID">CompanyName :</label>
                    <input class="tbox" type="text" placeholder="CompanyName" id="filterCompanyName" /><br />
                    <label class="yazi" for="SupplierID">ContactName :</label>
                    <input class="tbox" type="text" placeholder="ContactName" id="filterContactName" /><br />
                    <label class="yazi" for="SupplierID">City :</label>
                    <select class="citySelector" style="width: 210px;" id="filterCity">
                    </select><br />
                    <label class="yazi" for="SupplierID">Country :</label>
                    <select class="countrySelector" style="width: 210px;" id="filterCountry">
                    </select><br />

                    <button class="btn btn-danger mt-2" id="getSupplierFilter">Filter</button>

                </div>
            </div>
        </div>
    </div>

    <h2 class="ml-2 mt-2">Supplier List</h2>

    <table class="table-info" id="Table">
        <thead>
            <tr>
                <th>Id</th>
                <th>CompanyName</th>
                <th>ContactName</th>
                <th>Adress</th>
                <th>City</th>
                <th>Region</th>
                <th>PostalCode</th>
                <th>Country</th>
                <th>Phone</th>
                <th>Fax</th>
                <th>HomePage</th>
                <th></th>
            </tr>
        </thead>
        <tbody class="table-warning" id="div_Loader">
        </tbody>

    </table>
    <br />
</asp:Content>

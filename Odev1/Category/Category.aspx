<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Odev1.Category.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CategoryTransactions.js"> </script>
    <title>Kategori Listele</title>

    <style>
        /* table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
        }

        #btn_up {
            width: 100px;
        }

        #btn_delete {
            margin-bottom: 5px;
            width: 100px;
        }

        #IGPBI {
            width: 129px;
            margin-bottom: 7px;
            margin-top: 10px;
        }

        #selectsearch {
            margin-top: 7px;
        }

        .tbox {
            margin-bottom: 7px;
            width: 210px;
        }

        .col-3 {
            margin-left: 10px;
            margin-top: 10px;
            width: auto;
        }

        .yazi {
            width: 130px;
        }

        #btnClear {
            margin-left: 85px;
        }*/
    </style>

    <%--head bölümünü alıyoruz--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-secondary text-white">
        <div id="AddProduct" style="">
            <div class="row">
                <div class="col-3 ml-3 mt-4">
                    <label class="yazi" for="">CategoryID :</label>
                    <input class="tbox" type="text" id="txtboxCI" disabled="disabled" /><br />
                    <label class="yazi" for="">CategoryName :</label>
                    <input class="tbox" type="text" id="txtboxCN" /><br />
                    <label class="yazi" for="">Description :</label>
                    <input class="tbox" type="text" id="txtboxD" /><br />
                    <div class="mb-3">
                    <input type="button" class="btn btn-primary mt-2" id="add" value="Add" />
                    <input type="button" class="btn btn-info mt-2" id="update" value="Update" />
                    <button class="btn btn-success mt-2" id="btn1">Get List Category</button>
                    </div>

                </div>
                <div class="col-3 mt-4 filter-container">
                    <input class="tbox" type="text" placeholder="CategoryID" id="filterCID" /><br />
                    <input class="tbox" type="text" placeholder="CategoryName" id="filterCN" /><br />
                    <input class="tbox" type="text" placeholder="Description" id="filterD" /><br />
                    <button class="btn btn-danger mt-2" id="getCategoryFilter">Filter</button>
                    <button class="btn btn-danger mt-2" id="btnClear">Clear</button>
                </div>
            </div>
        </div>
    </div>
    <h2 class="mt-2 ml-2">Category List</h2>
    <table class="table-info" id="Table">
        <thead>
            <tr>
                <th>CategoryID</th>
                <th>CategoryName</th>
                <th>Description</th>
                <th></th>
            </tr>
        </thead>
        <tbody class="table-warning" id="div_Loader">
        </tbody>

    </table>
    <br />

    <%--body bölümünü alıyoruz--%>
</asp:Content>

$(document).ready(function () {
    Page.Init();
});

var Page = {

    Init: function () {
        Page.Event();
        Page.GetListbyLastSuppliers();
        Page.GetCountrySelector();
    },

    Event: function () {
        $("#btn1").click(function () {
            Page.GetListbyLastSuppliers()
        });

        $("#add").click(function () {
            Page.AddSupplier()
        });
        $("#update").click(function () {
            Page.UpdateSupplier()
        });
        $("#getSupplierById").click(function () {
            Page.GetById($("#txtGetbyID").val());
        });
        $("#getSupplierFilter").click(function () {
            Page.GetSupplierByFilter()
        });
        //$("#btnClear").click(function () {
        //    Page.Clear()
        //});
        $("#getSupplierById").keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                Page.GetById($("#txtGetbyID").val())
            }
        });
    },

    supplier: {
        SupplierID: 0,
        CompanyName: "",
        ContactName: "",
        Address: "",
        City: "",
        Region: "",
        PostalCode: "",
        Country: "",
        Phone: "",
        Fax: "",
        HomePage: ""
    },

    Printing: function (suppliers) {
        var table = "";
        for (var i in suppliers) {
            var supplier = suppliers[i];
            table += `
        <tr>
            <td>` + supplier.SupplierID + `</td>
            <td>` + supplier.CompanyName + `</td>
            <td>` + supplier.ContactName + `</td>
            <td>` + supplier.Address + `</td>
            <td>` + supplier.City + `</td>
            <td>` + supplier.Region + `</td>
            <td>` + supplier.PostalCode + `</td>
            <td>` + supplier.Country + `</td>
            <td>` + supplier.Phone + `</td>
            <td>` + supplier.Fax + `</td>
            <td>` + supplier.HomePage + `</td>` +
                `<td><button onclick="Page.DeleteConfirmDialog(` + supplier.SupplierID + `)" class="btn btn-danger mr-2 mt-1 mb-2" id="btn_delete" style="float:right;"> Delete </button><br/>`  +
                `<button onclick="Page.GetById(` + supplier.SupplierID + `)" class="btn btn-primary mr-2 mb-1" id="btn_up" style="float: right; "> Update</button>` + `</td> 
        </tr>
`
            if (table != "") {
                $("#div_Loader").html(table);
            }
        }
    },

    InsideTheTextBox: function (supplier) {
        $("#txtSupID").val(supplier.SupplierID);
        $("#txtComName").val(supplier.CompanyName);
        $("#txtConName").val(supplier.ContactName);
        $("#txtAddress").val(supplier.Address);
        $("#selectorCity").val(supplier.City);
        $("#txtRegion").val(supplier.Region);
        $("#txtPostalCode").val(supplier.PostalCode);
        $("#txtCountrySelector").val(supplier.Country);
        $("#txtPhone").val(supplier.Phone);
        $("#txtFax").val(supplier.Fax);
        $("#txtHomePage").val(supplier.HomePage);
        
    },

    GetListbyLastSuppliers: function () {
        var data = {}
        $.ajax({
            url: "Supplier.aspx/GetListSupplier",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var suppliers = $.parseJSON(result.d)
                Page.Printing(suppliers);
            },
            error: function (hata, ajaxOptions, thrownError) {
                alert(hata.status);
                alert(thrownError);
                alert(hata.responseText);
            }
        });
    },

    GetCountrySelector: function () {
        var data = {

        }
        $.ajax({
            url: "Supplier.aspx/GetCountrySelector",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var suppliers = $.parseJSON(result.d)
                Page.CountrySelectorPrint(suppliers);
                Page.CitySelectorPrint(suppliers);

            },

        });
    },

    CountrySelectorPrint: function (suppliers) {
        var table = `<option value="">...</option>`;
        for (var i in suppliers) {
            var supplier = suppliers[i];
            table += `
                <option value="${supplier.Country}">${supplier.Country}</option>
            `;
            if (table != "") {
                $(".countrySelector").html(table);
            }
        }
    },

    CitySelectorPrint: function (suppliers) {
        var table = `<option value="">...</option>`;
        for (var i in suppliers) {
            var supplier = suppliers[i];
            table += `
                <option value="${supplier.City}">${supplier.City}</option>
            `;
            if (table != "") {
                $(".citySelector").html(table);
            }
        }
    },

    AddSupplier: function () {
        var supplier = Page.supplier;
       // supplier.SupplierID = 0;//$("#txtSupID").val();
        supplier.CompanyName = $("#txtComName").val();
        supplier.ContactName = $("#txtConName").val();
        supplier.Address = $("#txtAddress").val();
        supplier.City = $("#selectorCity").val();
        supplier.Region = $("#txtRegion").val();
        supplier.PostalCode = $("#txtPostalCode").val();
        supplier.Country = $("#txtCountrySelector").val();
        supplier.Phone = $("#txtPhone").val();
        supplier.Fax = $("#txtFax").val();
        supplier.HomePage = $("#txtHomePage").val();

        var data = {
            supplier: supplier
        }
        $.ajax({
            url: "Supplier.aspx/AddSupplier",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var suppliers = $.parseJSON(result.d);
                if (suppliers != null) {
                    alert("Ekleme ıslemı basarı ıle yapılmıstır");
                    Page.GetListbyLastSuppliers(suppliers);
                }
                else {
                    alert("Ekleme ıslemı basarısız oldu");
                }
            },
        });
    },

    UpdateSupplier: function () {
        var supplier = Page.supplier;
        supplier.SupplierID = $("#txtSupID").val();
        supplier.CompanyName = $("#txtComName").val();
        supplier.ContactName = $("#txtConName").val();
        supplier.Address = $("#txtAddress").val();
        supplier.City = $("#selectorCity").val();
        supplier.Region = $("#txtRegion").val();
        supplier.PostalCode = $("#txtPostalCode").val();
        supplier.Country = $("#txtCountrySelector").val();
        supplier.Phone = $("#txtPhone").val();
        supplier.Fax = $("#txtFax").val();
        supplier.HomePage = $("#txtHomePage").val();
        var data = {
            supplier: supplier
        }
        $.ajax({
            url: "Supplier.aspx/UpdateSupplier",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function () {

                Page.GetListbyLastSuppliers();
                alert("Güncelleme işlemi Başarı ile gerçekleştirildi")
            }
        });
    },

    GetById: function (id) {
        var data = {
            id: id
        }

        $.ajax({
            url: "Supplier.aspx/GetSupById",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var supplier = $.parseJSON(result.d)
                Page.InsideTheTextBox(supplier);
            },
        })
    },

    DeleteSupplier: function (id) {

        var data = {
            id: id
        }
        $.ajax({
            url: "Supplier.aspx/DeleteSupplier",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function () {

                Page.GetListbyLastSuppliers();
                alert("silme ıslemı basarı ıle yapılmıstır");
            },
        });
    },

    DeleteConfirmDialog: function (id) {

        if (confirm("Are you sure you want to delete this?")) {
            Page.DeleteSupplier(id);
        }
        else {
            return false;
        }
    },

    GetSupplierByFilter: function () {
        var supplier = {

            CompanyName: $("#filterCompanyName").val() ,
            ContactName: $("#filterContactName").val(),
            City: $("#filterCity").val(),
            Country: $("#filterCountry").val()

        }
        var data = {
            supplier: supplier
        }
        $.ajax({
            url: "Supplier.aspx/GetSupplierByFilter",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var suppliers = $.parseJSON(result.d)
                if (suppliers != 0) {
                    Page.Printing(suppliers);
                } else {
                    alert("Sonuç Bulunamadı");
                }
            },
            error: function (error) {
                var a = error
            }

        });
    },

    Clear: function () {
        $(".filter-container :input").val('');
        $(".txtbox-container :input").val('');
        $("#txtGetbyID").val('');


    },


}
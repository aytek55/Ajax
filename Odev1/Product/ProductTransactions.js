$(document).ready(function () {
    Page.Init();
});

var Page = {

    Init: function () {
        Page.Event();
        Page.GetListbyLast10Products();
        Page.GetAllCategories();
        Page.GetAllSuppliers();
    },

    Event: function () {
        $("#btn1").click(function () {
            Page.GetListbyLast10Products()
        });

        $("#add").click(function () {
            Page.AddProduct()
        });
        $("#update").click(function () {
            Page.UpdateProduct()
        });
        $("#getProductById").on("click", function () {
            Page.GetById($("#IGPBI").val())
        });
        $("#getProductFilter").click(function () {
            Page.GetProductByFilter()
        });
        $("#IGPBI").keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                Page.GetById($("#IGPBI").val())
            }
        });
  
  
        $(".filter-container input[type=text]").keypress(function (event) {
            if (event.keyCode == '13') {
                Page.GetProductByFilter()
             
            }
        });
        $("#btnClear").click(function () {
            Page.Clear()
        });
    },

    product: {
        ProductID: 0,
        ProductName: "",
        SupplierID: 0,
        CategoryID: 0,
        QuantityPerUnit: "",
        UnitPrice: 0.00,
        UnitsOnOrder: 0,
        ReorderLevel: 0,
        Discontinued: true,
        UnitsInStock: 0
    },

    category: {
        CategoryID: 0,
        CategoryName: "",
        Description: ""
    },

    InsideTheTextBox: function (product) {
        $("#IPI").val(product.ProductID);
        $("#IPN").val(product.ProductName);
        $("#IUP").val(product.UnitPrice);
        $("#ICI").val(product.CategoryID);
        $("#IQPU").val(product.QuantityPerUnit);
        $("#ID").val(product.Discontinued);
        $("#IRL").val(product.ReorderLevel);
        $("#ISI").val(product.SupplierID);
        $("#IUIS").val(product.UnitsInStock);
        $("#IUOO").val(product.UnitsOnOrder);
    },

    Printing: function (products) {
        var table = "";
        for (var i in products) {
            var product = products[i];
            table += `
        <tr>
            <td>`+ product.ProductID + `</td>
            <td>` + product.ProductName + `</td>
            <td>` + product.SupplierID + `</td>
            <td>` + product.CategoryID + `</td>
            <td>` + product.QuantityPerUnit + `</td>
            <td>` + product.UnitPrice + `</td>
            <td>` + product.UnitsInStock + `</td>
            <td>` + product.UnitsOnOrder + `</td>
            <td>` + product.ReorderLevel + `</td>
            <td>` + product.Discontinued + `</td>` +
                `<td><button onclick="Page.DeleteConfirmDialog(` + product.ProductID + `)" class="btn btn-danger mr-2 mt-1 mb-2" id="btn_delete" style="float:right;"> Delete </button></br></br>` +
                `<button onclick="Page.GetById(` + product.ProductID + `)" class="btn btn-primary mr-2 mb-1" id="btn_up" style="float: right;"> Update</button>` + `</td>
        </tr>
`
            if (table != "") {
                $("#div_Loader").html(table);
            }
        }
    },

    GetListbyLast10Products: function () {
        var data = {
        }
        $.ajax({
            url: document.location.origin + "/Product/PDefault.aspx/GetListProduct",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var products = $.parseJSON(result.d)
                Page.Printing(products);
            },
            error: function (hata, ajaxOptions, thrownError) {
                alert(hata.status);
                alert(thrownError);
                alert(hata.responseText);
            }
        });
    },

    AddProduct: function () {
        var product = Page.product;
   /*     product.ProductID = $("#IPI").val();*/
        product.ProductName = $("#IPN").val();
        product.UnitPrice = $("#IUP").val();
        product.CategoryID = $("#ICI").val();
        product.QuantityPerUnit = $("#IQPU").val();
        product.Discontinued = $("#cxb_discontinued").prop("checked");
        product.ReorderLevel = $("#IRL").val();
        product.SupplierID = $("#ISI").val();
        product.UnitsInStock = $("#IUIS").val();
        product.UnitsOnOrder = $("#IUOO").val();

        var data = {
            productADO: product
        }
        $.ajax({
            url: "PDefault.aspx/AddProduct",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var productsADO = $.parseJSON(result.d);
                if (productsADO != null) {
                    alert("Ekleme ıslemı basarı ıle yapılmıstır");
                    Page.GetListbyLast10Products(productsADO);
                }
                else {
                    alert("Ekleme ıslemı basarısız oldu");
                }
            },
        });
    },

    GetById: function (id) {
        var data = {
            id: id
        }

        $.ajax({
            url: "PDefault.aspx/GetProductById",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var product = $.parseJSON(result.d)
                Page.InsideTheTextBox(product);
            },
        })
    },

    UpdateProduct: function () {
        var product = Page.product;
        product.ProductID = $("#IPI").val();
        product.ProductName = $("#IPN").val();
        product.UnitPrice = $("#IUP").val();
        product.CategoryID = $("#ICI").val();
        product.QuantityPerUnit = $("#IQPU").val();
        product.Discontinued = $("#cxb_discontinued").prop("checked");
        product.ReorderLevel = $("#IRL").val();
        product.SupplierID = $("#ISI").val();
        product.UnitsInStock = $("#IUIS").val();
        product.UnitsOnOrder = $("#IUOO").val();
        var data = {
            product: product
        }
        $.ajax({
            url: "PDefault.aspx/UpdateProductWM",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function () {

                Page.GetListbyLast10Products();
                alert("Güncelleme işlemi Başarı ile gerçekleştirildi")
            }
        });
    },

    DeleteProduct: function (id) {

        var data = {
            id: id
        }
        $.ajax({
            url: "PDefault.aspx/DeleteProduct",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function () {

                Page.GetListbyLast10Products();
                alert("silme ıslemı basarı ıle yapılmıstır");
            },
        });
    },

    CategoryPrint: function (categories) {
        var table = `<option value="">...</option>`;
        for (var i in categories) {
            var category = categories[i];
            table += `
                <option value="${category.CategoryID}">${category.CategoryName}</option>
            `;
            if (table != "") {
                $(".ICI").html(table);
            }
        }
    },

    GetAllCategories: function () {
        var data = {
        }
        $.ajax({
            url: "PDefault.aspx/GetCategory",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var categories = $.parseJSON(result.d)
                Page.CategoryPrint(categories);
            },

        });
    },

    SupplierPrint: function (suppliers) {
        var table = `<option value="">...</option>`;
        for (var i in suppliers) {
            var supplier = suppliers[i];
            table += `
                <option value="${supplier.SupplierID}">${supplier.CompanyName}</option>
            `;
            if (table != "") {
                $("#ISI").html(table);
            }
        }
    },

    GetAllSuppliers: function () {
        var data = {

        }
        $.ajax({
            url: "PDefault.aspx/GetSuppliers",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var suppliers = $.parseJSON(result.d)
                Page.SupplierPrint(suppliers);
            },

        });
    },

    //GetProductByName: function (text) {
    //    text = $("#IPN2").val();
    //    var data = {
    //        text: text
    //    }

    //    $.ajax({
    //        url: "PDefault.aspx/GetProductByNameWM",
    //        data: JSON.stringify(data),
    //        type: 'POST',
    //        contentType: 'application/json',
    //        dataType: 'json',
    //        success: function (result) {
    //            var products = $.parseJSON(result.d)
    //            /*Page.InsideTheTextBox(product);*/
    //            Page.Printing(products);

    //        },
    //    })
    //},

    DeleteConfirmDialog: function (id) {

        if (confirm("Are you sure you want to delete this?")) {
            Page.DeleteProduct(id);
        }
        else {
            return false;
        }
    },

    GetProductByFilter: function () {
        var product={

            ProductID: $("#IPI2").val() == '' ? 0 : $("#IPI2").val(),
            ProductName : $("#IPN2").val(),
            UnitsInStock: $("#IUIS2").val() == '' ? 0 : $("#IUIS2").val(),
            CategoryID: $("#selectorCategory").val() == '' ? 0 : $("#selectorCategory").val(),

        }
        var data = {
            product: product
        }
        $.ajax({
            url: "PDefault.aspx/GetProductByFilter",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var products = $.parseJSON(result.d)
                if (products != 0) {
                    Page.Printing(products);
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
        $("#IPI").val('');
        $("#IPN").val('');
        $("#IUP").val('');
        $("#IQPU").val('');
        $("#ID").val('');
        $("#IRL").val('');
        $("#IUIS").val('');
        $("#IUOO").val('');
        $("#IPI2").val('');
        $("#IPN2").val('');
        $("#IUIS2").val('');
        $("#IGPBI").val('');
        $("#IGPBI").val('');
    },


}
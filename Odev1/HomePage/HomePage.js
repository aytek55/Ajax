$(document).ready(function () {
    Page.Init();
});

var Page = {

    Init: function () {
        Page.Event();
        Page.GetProductList();
        Page.GetCategories()

    },

    Event: function () {
        
        $(".product-filter").keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                Page.Filter()
            }
        });

        $("#search").click(function () {
            var e = $.Event("keypress", { which: 13 });
            $(this).trigger(e);
        });
    },

    GetProductList: function () {
        var product = {

            ProductID:0,
            ProductName: $(`.product-filter`).find(`[name="ProductName"]`).val(),
            UnitsInStock: 0,
            CategoryID: $(`.product-filter`).find(`[name="CategoryID"]`).val()

        }
        var data = {
            product: product
        }
        $.ajax({
            url: document.location.origin + "/Product/PDefault.aspx/GetProductByFilter",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var products = $.parseJSON(result.d)
                if (products != 0) {
                    Page.PrintProducts(products);
                } else {
                    alert("Sonuç Bulunamadı");
                }
            },
            error: function (error) {
                var a = error
            }

        });
    },

    PrintProducts: function (products) {
        var table = "";
        for (var i in products) {
            var product = products[i];
            table += `
            <div class="col-2" style="margin-top:10px;">
                <div class="card bg-dark" >
                
                     <div class="card-body" style="min-height:230px;">
                        <h5 class="card-title">${product.ProductName}</h5>
                        <p class="card-text">Fiyat=${product.UnitPrice}$</p>
                        <a href="#" class="btn btn-primary">Sepete Ekle</a>
                     </div>
                </div>
            </div>
            `;
        }
        $(table).appendTo($("#product-container"));
    },
   //  < img src = "ordek.jpg" class="card-img-top" alt = "..." >

    GetCategories: function () {
        var data = {
        }
        $.ajax({
            url: document.location.origin + "/Category/Category.aspx/GetListCategories",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var categories = $.parseJSON(result.d)
                Page.PrintCategories(categories);
            },
            error: function (hata, ajaxOptions, thrownError) {
                alert(hata.status);
                alert(thrownError);
                alert(hata.responseText);
            }
        });
    },
    
    PrintCategories: function (categories) {
        var table = "";
        for (var i in categories) {
            var category = categories[i];
            table += `<div class="col-2 col-xs-6" style="margin-top:10px;">
                <div class="card bg-dark" >
                <img src="photon2.png" class="card-img-top" alt="...">
                 <div class="card-body" style=" min-height:200px;">
                     <h5 class="card-title">${category.CategoryName}</h5>
                        <p class="card-text">Açıklama:${category.Description}</p>
                           <a href="/Categories/Categories.aspx?categoryID=${category.CategoryID}" type="button" class="btn btn-light">Getir</a>

                 </div>
           </div>
        </div>
            `;
//            table += `<div class="col-2 col-xs-6" style="margin-top:10px;">
//                <div class="card bg-dark" >
//                <img src="photon2.png" class="card-img-top" alt="...">
//                 <div class="card-body" style=" min-height:200px;">
//                     <h5 class="card-title">${category.CategoryName}</h5>
//                        <p class="card-text">Açıklama:${category.Description}</p>
//                           <button onclick="Page.SetFilter(${category.CategoryID})" type="button" class="btn btn-light">Getir</button>

//         </div>
//     </div>
//</div>
//            `;
        }
        $(table).appendTo($("#category-container"));
    },
    //   < img src = "photon2.png" class="card-img-top" alt = "..." >
    //aspx dosyasındaki default değeri sıfır olan category id value sünü click eventinden gelen id ile set ettiğimiz kod 
    SetFilter: function (id) {
        $(`.product-filter > [name="CategoryID"]`).val(id)
        //GetProductList yerine Page Filter ı çalıştırmamızın nedeni oradaki işlemlerin de yapılmasını sağlamak. örneğin html i temizlemesi.
        //daha sonra filter getProductList i çağırıyor.
        Page.Filter();
    },

    Filter: function () {
        $("#product-container").html("");
        Page.GetProductList();
    },

    //Filtreleri boşaltıp filtreyi default haliyle çalıştırıyor.
    ClearFilter: function () {
        $(`.product-filter`).find(`[name="ProductName"]`).val("");
        $(`.product-filter`).find(`[name="CategoryID"]`).val(0);
            Page.Filter();
    },
}
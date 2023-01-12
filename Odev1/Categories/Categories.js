$(document).ready(function () {
    Page.Init()
});

var Page = {


    Init: function () {
        Page.GetCategories();
    },

    GetCategories: function () {
        var data = {}
        $.ajax({
            url: document.location.origin + "/Category/Category.aspx/GetListCategories",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var categories = $.parseJSON(result.d)
                Page.PrintingCategories(categories);
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
                <div class="card bg-dark" style=" min-height:220px;" >
                <img src="photon2.png" class="card-img-top" alt="...">
                 <div class="card-body" >
                     <h5 class="card-title">${category.CategoryName}</h5>
                        <p class="card-text">Açıklama:${category.Description}</p>
                           <button onclick="Page.SetFilter(${category.CategoryID})" type="button" class="btn btn-light">Getir</button>

         </div>
     </div>
</div>
            `;
        }
        $(table).appendTo($("#container-categories"));
    },
}

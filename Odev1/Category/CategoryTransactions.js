$(document).ready(function () {
    Page.Init();
});

var Page = {

    Init: function(){
        Page.Event();
        Page.GetListbyLastCategories();
    },

    Event: function () {
        $("#btn1").click(function () {
            Page.GetListbyLastCategories()
        });
        $("#add").click(function () {
            Page.AddCategory()
        });
        $("#update").click(function () {
            Page.UpdateCategory()
        });
        $("#getCategoryFilter").click(function () {
            Page.GetCategoryByFilter()
        });
        $(".filter-container input[type=text]").keypress(function (event) {
            if (event.keyCode == '13') {
                Page.GetCategoryByFilter()

            }
        });
        $("#btnClear").click(function () {
            Page.Clear()
        });
    },

    category: {
        CategoryID: 0,
        CategoryName: "",
        Description: ""
    },

    Printing: function (categories) {
        var table = "";
        for (var i in categories) {
            var category = categories[i];
            table += `
        <tr>

            <td>` + category.CategoryID + `</td>
            <td>` + category.CategoryName + `</td>
            <td>` + category.Description + `</td>` +
                `<td><button onclick="Page.DeleteConfirmDialog(` + category.CategoryID + `)" class="btn btn-danger mr-2" id="btn_delete" style="float:right;"> Delete </button></br></br>` +
                `<button onclick="Page.GetById(` + category.CategoryID + `)" class="btn btn-primary mr-2" id="btn_up" style="float: right; "> Update</button>` + `</td> 
        </tr>
`
            if (table != "") {
                $("#div_Loader").html(table);
            }
        }
    },

    InsideTheTextBox: function (category) {
        $("#txtboxCI").val(category.CategoryID);
        $("#txtboxCN").val(category.CategoryName);
        $("#txtboxD").val(category.Description);
    },

    GetListbyLastCategories: function () {
        var data = {}
        $.ajax({
            url: "Category.aspx/GetListCategories",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var categories = $.parseJSON(result.d)
                Page.Printing(categories);
            },
            error: function (hata, ajaxOptions, thrownError) {
                alert(hata.status);
                alert(thrownError);
                alert(hata.responseText);
            }
        });
    },

    AddCategory: function () {
        var category = Page.category;
      /*  category.CategoryID = $("#txtboxCI").val();*/
        category.CategoryName = $("#txtboxCN").val();
        category.Description = $("#txtboxD").val();

        var data = { category : category }
        $.ajax({
            url: "Category.aspx/AddCategory",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var categories = $.parseJSON(result.d);
                if (categories != null) {
                    alert("Ekleme ıslemı basarı ıle yapılmıstır");
                    Page.GetListbyLastCategories(categories);
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
            url: "Category.aspx/GetCategoryById",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var category = $.parseJSON(result.d)
                Page.InsideTheTextBox(category);
            },
        })
    },

    UpdateCategory: function () {
        var category = Page.category;
        category.CategoryID = $("#txtboxCI").val();
        category.CategoryName = $("#txtboxCN").val();
        category.Description = $("#txtboxD").val();
        var data = {
            category: category
        }
        $.ajax({
            url: "Category.aspx/UpdateCategory",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function () {

                Page.GetListbyLastCategories();
                alert("Güncelleme işlemi Başarı ile gerçekleştirildi")
            }
        });
    },

    DeleteCategory: function (id) {
        var data = {
            id: id
        }
        $.ajax({
            url: "Category.aspx/DeleteCategory",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function () {

                Page.GetListbyLastCategories();
                alert("silme ıslemı basarı ıle yapılmıstır");
            },
        });
    },

    DeleteConfirmDialog: function (id) {

        if (confirm("Are you sure you want to delete this?")) {
            Page.DeleteCategory(id);
        }
        else {
            alert("silme işlemi iptal edildi");
            return false;
        }
    },

    GetCategoryByFilter: function () {
        var category = {

            CategoryID: $("#filterCID").val() == '' ? 0 : $("#filterCID").val(),
            CategoryName: $("#filterCN").val(),
            Description: $("#filterD").val() 

        }
        var data = {
            category: category
        }
        $.ajax({
            url: "Category.aspx/GetCategorytByFilter",
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                var categories = $.parseJSON(result.d)
                if (categories != 0) {
                    Page.Printing(categories);
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
        $("#txtboxCI").val('');
        $("#txtboxCN").val('');
        $("#txtboxD").val('');
        $("#filterCID").val('');
        $("#filterCN").val('');
        $("#filterD").val('');
    },

}
using ADO.Entity;
using Odev1.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Odev1.Categories
{
    public partial class Categories : System.Web.UI.Page
    {
        public int CategoryID = 0;
        public string ProductTable = "";
        public string CategoryTable = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ReadStringQuery();
            CreateProductTable();
            CreateCategoryTable();
        }

        void ReadStringQuery()
        {
            int value;
            if (Request.QueryString["categoryID"] != null)
            {
                if (int.TryParse(Request.QueryString["categoryID"], out value))
                {
                    CategoryID = Convert.ToInt32(Request.QueryString["categoryID"]);
                }
            }
        }

        void CreateProductTable()
        {
            //need a cantegoryId condition
            if (CategoryID > 0)
            {
                List<Product> products = new ProductManager().GetFilter(new Product() { CategoryID = CategoryID });
                foreach (Product product in products)
                {
                    ProductTable += $@"
                               <div class=""col-2"" style=""margin-top:8px;"">
                <div class=""card bg-dark text-white"" >
                
                     <div class=""card-body"" style="" min-height:240px;"">
                        <h5 class=""card-title"">{product.ProductName}</h5>
                        <p class=""card-text"">Fiyat={product.UnitPrice}$</p>
                        <a href=""#"" class=""btn btn-primary"">Sepete Ekle</a>
                     </div>
                </div>
            </div>
                    ";
            
                }
            }
        }
        void CreateCategoryTable()
        {
            if (CategoryID > 0)
            {
                List<ADO.Entity.Category> categories = new CategoryManager().GetTenCategories();
                foreach (ADO.Entity.Category category  in categories)
                {
                    CategoryTable += $@"<div class=""col-2 col-xs-6"" style=""margin-top:10px;"">
                <div class=""card bg-dark text-white""  >
                 <div class=""card-body"" style="" min-height:240px;"">
                     <h5 class=""card-title"">{category.CategoryName}</h5>
                        <p class=""card-text"">Açıklama:{category.Description}</p>
                           <a href=""/Categories/Categories.aspx?categoryID={category.CategoryID}"" type=""button"" class=""btn btn-warning"">Getir</a>

         </div>
     </div>
</div> ";
                }
            }
        }
    }
}
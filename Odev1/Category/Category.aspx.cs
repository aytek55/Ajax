using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Odev1.Category
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string GetListCategories()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategoryManager categoryManager = new CategoryManager();
            List<ADO.Entity.Category> categories = new List<ADO.Entity.Category>();
            categories = categoryManager.GetTenCategories();


            return serializer.Serialize(categories);
        }

        [WebMethod]
        public static string AddCategory(ADO.Entity.Category category)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategoryManager categoryManager = new CategoryManager();
            bool result = categoryManager.AddCategory(category);
            List<ADO.Entity.Category> categories = new List<ADO.Entity.Category>();

            if (result)
            {
                categories.Add(category);
                //productsADO = productmanager.GetProduct();
            }

            return serializer.Serialize(categories);
        }
        [WebMethod]
        public static string GetCategoryById(int id)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategoryManager categoryManager = new CategoryManager();
            ADO.Entity.Category category = new ADO.Entity.Category();
            category = categoryManager.GetByID(id);
            return serializer.Serialize(category);
        }
        [WebMethod]
        public static string UpdateCategory(ADO.Entity.Category category)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategoryManager updatemanager = new CategoryManager();

            var result= updatemanager.UpdateCategory(category);

            return serializer.Serialize(result);
        }
        [WebMethod]
        public static string DeleteCategory(int id)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategoryManager categoryManager = new CategoryManager();


            var result = categoryManager.Delete(id);

            return serializer.Serialize(result);
        }

        [WebMethod]
        public static string GetCategorytByFilter(ADO.Entity.Category category)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategoryManager categoryManager=  new CategoryManager();
            List<ADO.Entity.Category> categories = categoryManager.GetCategoryByFilter(category);
            return serializer.Serialize(categories);
        }
    }
}
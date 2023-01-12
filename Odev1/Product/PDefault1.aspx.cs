using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Runtime.Serialization;
using Odev1.Category;
using Odev1.Supplier;

namespace Odev1.ProductStuff
{
    public partial class PDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string GetProductById(int id)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductManager postmanager = new ProductManager();
            ADO.Entity.Product productsADO = postmanager.GetProductByID(id);

            return serializer.Serialize(productsADO);
        }

        [WebMethod]
        public static string AddProduct(ADO.Entity.Product productADO)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductManager productmanager = new ProductManager();
            bool result = productmanager.AddProduct(productADO);
            List<ADO.Entity.Product> productsADO = new List<ADO.Entity.Product>();
           
            if (result)
            {
                productsADO.Add(productADO);
                //productsADO = productmanager.GetProduct();
            }

            return serializer.Serialize(productsADO);
        }
        [WebMethod]
        public static string GetListProduct()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<ADO.Entity.Product> products = new List<ADO.Entity.Product>();
            ProductManager productmanager = new ProductManager();
            products = productmanager.GetTenProducts();

            return serializer.Serialize(products);
        }

        [WebMethod]
        public static string UpdateProductWM(ADO.Entity.Product product)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductManager updatemanager = new ProductManager();

            updatemanager.UpdateProduct(product);

            return serializer.Serialize(product);
        }

        [WebMethod]
        public static string DeleteProduct(int id)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductManager productmanager = new ProductManager();
           
            
            bool result = productmanager.Delete(id);
          
            return serializer.Serialize(result);
        }

        [WebMethod]
        public static string GetProductByNameWM(string text)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductManager postmanager = new ProductManager();
            List<ADO.Entity.Product> products = postmanager.GetProductByName(text);

            return serializer.Serialize(products);
        }

        [WebMethod]
        public static string GetProductByFilter(ADO.Entity.Product product)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductManager postmanager = new ProductManager();
            List<ADO.Entity.Product> products = postmanager.GetFilter(product);

            return serializer.Serialize(products);
        }


        //CATEGORY WEB METHODS
        //-------------------------------------------------------------------
        [WebMethod]
        public static string GetCategory()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<ADO.Entity.Category> categories = new List<ADO.Entity.Category>();
            CategoryManager categoryManager= new CategoryManager();

            categories = categoryManager.GetCategorySelect();

            return serializer.Serialize(categories);
        }

        //SUPPLİER WEB METHODS
        //--------------------------------------------------------------------
        [WebMethod]
        public static string GetSuppliers()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            SupplierManager suppliermanager = new SupplierManager();

            suppliers = suppliermanager.GetAllSup();

            return serializer.Serialize(suppliers);
        }
        //DENEME WEB METHODS
        // --------------------------------------------------------------------
    }
}
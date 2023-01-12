using Odev1.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Odev1.Supplier
{
    public partial class Supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetListSupplier()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SupplierManager manager = new SupplierManager();
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            suppliers=manager.GetListSupplier();


            return serializer.Serialize(suppliers);
        }
        [WebMethod]
        public static string GetCountrySelector()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            SupplierManager suppliermanager = new SupplierManager();

            suppliers = suppliermanager.GetCountrySelector();

            return serializer.Serialize(suppliers);
        }

        [WebMethod]
        public static string AddSupplier(ADO.Entity.Supplier supplier)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SupplierManager supplierManager = new SupplierManager();
            bool result = supplierManager.AddSupplier(supplier);
            List<ADO.Entity.Supplier>  suppliers= new List<ADO.Entity.Supplier>();

            if (result)
            {
                suppliers.Add(supplier);
               
            }

            return serializer.Serialize(suppliers);
        }
        [WebMethod]
        public static string GetSupById(int id)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SupplierManager supplierManager = new SupplierManager();
            ADO.Entity.Supplier supplier = supplierManager.GetSupById(id);

            return serializer.Serialize(supplier);
        }
        [WebMethod]
        public static string UpdateSupplier(ADO.Entity.Supplier supplier)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SupplierManager supplierManager = new SupplierManager();
            bool result = supplierManager.UpdateSupplier(supplier);

            return serializer.Serialize(result);
        }
        [WebMethod]
        public static string DeleteSupplier(int id)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SupplierManager supplierManager = new SupplierManager();
            bool result = supplierManager.DeleteSupplier(id);

            return serializer.Serialize(result);
        }
        [WebMethod]
        public static string GetSupplierByFilter(ADO.Entity.Supplier supplier)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SupplierManager supplierManager = new SupplierManager();
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            suppliers = supplierManager.GetSupplierByFilter(supplier);

            return serializer.Serialize(suppliers);
        }


    }
}
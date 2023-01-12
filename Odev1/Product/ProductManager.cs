using ADO.Facade;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;

namespace Odev1
{
    public class ProductManager
    {
        public static List<ADO.Entity.Product> productsADO = new List<ADO.Entity.Product>();


        public ADO.Entity.Product GetProductByID(int id)
        {
            string msg;
            //ADO.Facade.Products.GetByProductID(1, out msg);
            ADO.Entity.Product productADO = new ADO.Entity.Product();
            productADO = ADO.Facade.Products.GetByProductID(id, out msg);
            return productADO;

        }
        public List<ADO.Entity.Product> GetProductByName(string text)
        {
            string msg;
            //ADO.Facade.Products.GetByProductID(1, out msg);
            List<ADO.Entity.Product> products = new List<ADO.Entity.Product>();
            products = ADO.Facade.Products.GetProductByName(text, out msg);
            return products;

        }
      
        public bool AddProduct(ADO.Entity.Product productADO)
        {
            bool result = true;
            try
            {
                string msg;
                ADO.Facade.Products.Add(productADO, out msg);
            }
            catch 
            {
                result = false;
            }
            return result;
        }
        public bool UpdateProduct(ADO.Entity.Product productADO)
        {
            bool result = true;
            try
            {
                string msg;
                ADO.Facade.Products.Update(productADO, out msg);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public List<ADO.Entity.Product> GetTenProducts()
        {
            List<ADO.Entity.Product> products = new List<ADO.Entity.Product>();

            string msg;
            products = ADO.Facade.Products.GetLastAdded10Products(out msg);
            return products;


        }
        public bool Delete(int id)
        {
            bool result = true;
            try
            {

                string msg;
                ADO.Facade.Products.DELETE(id, out msg);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public List<ADO.Entity.Product> GetFilter(ADO.Entity.Product product)
        {
            string msg;
            //ADO.Entity.Product filteredproduct = new ADO.Entity.Product();      
            List<ADO.Entity.Product> products = new List<ADO.Entity.Product>();
            products = ADO.Facade.Products.GetProductByFilter(product, out msg);
            return products;

        }
    }
}

using ADO.Entity;
using ADO.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odev1.Supplier
{
    public class SupplierManager
    {
        public List<ADO.Entity.Supplier> GetListSupplier()
        {
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            string msg;
            suppliers = ADO.Facade.Suppliers.GetListSupplier(out msg);

            return suppliers;
        }

        public List<ADO.Entity.Supplier> GetCountrySelector()
        {
            {
                List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();

                string msg;
                suppliers = ADO.Facade.Suppliers.GetCountrySelector(out msg);
                return suppliers;


            }

        }
        public List<ADO.Entity.Supplier> GetAllSup()
        {
            {
                List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();

                string msg;
                suppliers = ADO.Facade.Suppliers.GetAllSuppliers(out msg);
                return suppliers;


            }
        }

        public bool AddSupplier(ADO.Entity.Supplier supplier)
        {
            bool result = true;
            try
            {
                string msg;
                object value = ADO.Facade.Suppliers.AddSupplier(supplier, out msg);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public ADO.Entity.Supplier GetSupById(int id)
        {
            string msg;
            ADO.Entity.Supplier supplier = ADO.Facade.Suppliers.GetSupById(id,out msg);
            return supplier;
        }

        public bool UpdateSupplier(ADO.Entity.Supplier supplier)
        {
           bool result= true;
            try
            {
                string msg;
                ADO.Facade.Suppliers.UpdateSupplier(supplier, out msg);
            }
            catch
            {
                result= false;
            }
            return result;
        }

        public bool DeleteSupplier(int id)
        {
            bool result = true;
            try
            {
                string msg;
                ADO.Facade.Suppliers.DeleteSupplier(id, out msg);
            }
            catch
            {
                result = false;
            }
            return result;

        }

        public List<ADO.Entity.Supplier> GetSupplierByFilter(ADO.Entity.Supplier supplier)
        {
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            string msg;
            suppliers= ADO.Facade.Suppliers.GetSupplierByFilter(supplier,out msg);
            return suppliers;
        }
    }
}
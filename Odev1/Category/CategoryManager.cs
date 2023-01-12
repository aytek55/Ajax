using ADO.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Odev1.Category
{
    public class CategoryManager
    {
      public List<ADO.Entity.Category> GetCategorySelect()
       {
            List<ADO.Entity.Category> categories = new List<ADO.Entity.Category>();
            string msg;
            categories = ADO.Facade.Categories.GetAllCategories(out msg);

            return categories;

       }

        public bool AddCategory(ADO.Entity.Category category)
        {
            bool result = true;
            try
            {
                string msg;
                ADO.Facade.Categories.Add(category, out msg);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public List<ADO.Entity.Category> GetTenCategories()
        {
            List<ADO.Entity.Category> categories = new List<ADO.Entity.Category>();

            string msg;
            categories = ADO.Facade.Categories.GetLastAdded10Categories(out msg);
            return categories;


        }
        public ADO.Entity.Category GetByID(int id)
        {
            ADO.Entity.Category category = new ADO.Entity.Category();
            string msg; 
            category = ADO.Facade.Categories.GetById(id ,out msg);
            return category;
        }
        public bool UpdateCategory(ADO.Entity.Category category)
        {
            bool result = true;
            try
            {
                string msg;
                ADO.Facade.Categories.Update(category, out msg);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = true;
            try
            {

                string msg;
                ADO.Facade.Categories.DELETE(id, out msg);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public List<ADO.Entity.Category> GetCategoryByFilter(ADO.Entity.Category category)
        {
            List<ADO.Entity.Category> categories=new List<ADO.Entity.Category>();
            string msg;

            categories= ADO.Facade.Categories.GetCategoryByFilter(category,out msg);

            return categories;
        }
    }
}
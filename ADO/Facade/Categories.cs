using ADO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Facade
{
    public class Categories
    {
        public static int Add(Category category, out string msg)
        {
            msg = "";

            int
              id = 0;

            string
              strSQL = "";

            strSQL = strSQL = @"
     

                   
                                INSERT INTO 
                                    Categories(
                                        CategoryName,
                                        Description
                                    )
                                    VALUES(
                                        @CategoryName,
                                        @Description
                                    )
                                SELECT @@IDENTITY
            
            ";
            //eklenenin id si dönüyor
            Tools tool = new Tools();

            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.Parameters.AddWithValue("@Description", category.Description);
            try
            {
                cnn.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cnn.Close();
            }

            return id;
        }
        public static List<Category> GetAllCategories(out string msg)
        {
            msg = "";
            List<ADO.Entity.Category> categories = new List<ADO.Entity.Category>();
            ADO.Entity.Category category = new ADO.Entity.Category();

            string
            strSQL = @"
                            SELECT   *
                            FROM    Categories

                                   
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);


            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        category = new Category();
                        category.CategoryID= Convert.ToInt32(dr["CategoryID"]);
                        category.CategoryName = dr["CategoryName"].ToString();
                        category.Description = dr["Description"].ToString();
                     
                        categories.Add(category);
                    }
                }
                finally
                {
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cn.Close();
            }


            return categories;

        }

        public static List<Category> GetLastAdded10Categories(out string msg)
        {
            msg = "";

            List<Category> categories = new List<Category>();

            string
              strSQL = @"
                            SELECT    *
                            FROM    Categories
                            ORDER BY CategoryID DESC
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        Category category = new Category();
                        
                        category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        category.CategoryName = dr["CategoryName"].ToString();
                        category.Description = dr["Description"].ToString();
                       
                        categories.Add(category);
                    }
                }
                finally
                {
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cn.Close();
            }


            return categories;
        }

        public static Category GetById(int id, out string msg)
        {
            msg = "";

            Category category = new Category();

            string
              strSQL = @"
                            SELECT    *
                            FROM    Categories
                            WHERE   CategoryID = @CategoryID
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            cmd.Parameters.AddWithValue("@CategoryID", id);
         

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        category.CategoryName = dr["CategoryName"].ToString();
                        category.Description = dr["Description"].ToString();
                    
                    }
                }
                finally
                {
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cn.Close();
            }


            return category;
        }

        public static bool Update(Category category, out string msg)
        {
            msg = "";

            bool
              rtn = true;

            string
              strSQL = @"
                            UPDATE Categories
                            SET
                               CategoryName=@CategoryName,
                               Description=@Description

                            WHERE    CategoryID = @CategoryID
            ";


            Tools tool = new Tools();
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.Parameters.AddWithValue("@Description",category.Description);
            
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                rtn = false;
            }

            return rtn;
        }

        public static bool DELETE(int id, out string msg)
        {
            Category category = new Category();
           

            msg = "";

            bool
              rtn = true;

            string
              strSQL = @"
                          DELETE FROM Categories 
                            
                          WHERE CategoryID = @CategoryID
            ";


            Tools tool = new Tools();
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@CategoryID", id );

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                rtn = false;
            }

            return rtn;
        }

        public static List<Category> GetCategoryByFilter(Category category , out string msg)
        {
            msg = "";
            List<Category> categories = new List<Category>();
            
            string filter = "";
            if (!string.IsNullOrEmpty(category.CategoryName))
            {
                filter += " AND CategoryName LIKE @CategoryName";
            }
            if (category.CategoryID > 0)
            {
                filter += " AND CategoryID = @CategoryID";
            }
            if (!string.IsNullOrEmpty(category.Description))
            {
                filter += " AND Description = @Description";
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = "WHERE " + filter.Remove(0, 4);
            }
            string
              strSQL = $@"
                    SELECT * 
                    FROM Categories 
                    {filter}
                           
                         
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            cmd.Parameters.AddWithValue("@CategoryName", "%" +category.CategoryName + "%");
            cmd.Parameters.AddWithValue("@Description", category.Description);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        category = new Category();

                        category.CategoryName = dr["CategoryName"].ToString();
                        category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        category.Description = dr["Description"].ToString();

                        categories.Add(category);
                    }
                }
                finally
                {
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return categories;
        }
    }
}

               


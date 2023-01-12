using ADO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Facade
{
    public class Products
    {
        public static int Add(Product product, out string msg)
        {
            msg = "";

            int
              id = 0;

            string
              strSQL = "";

            strSQL = strSQL = @"
     

                   
                                INSERT INTO 
                                    Products(
                                        ProductName,
                                        SupplierID,
                                        CategoryID,
                                        QuantityPerUnit,
                                        UnitPrice,
                                        UnitsInStock,
                                        UnitsOnOrder,
                                        ReorderLevel,
                                        Discontinued
                                    )
                                    VALUES(
                                        @ProductName,
                                        @SupplierID,
                                        @CategoryID,
                                        @QuantityPerUnit,
                                        @UnitPrice,
                                        @UnitsInStock,
                                        @UnitsOnOrder,
                                        @ReorderLevel,
                                        @Discontinued
                                    )
                                SELECT @@IDENTITY
            
            ";
            //eklenenin id si dönüyor
            Tools tool = new Tools();

            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@SupplierID", product.SupplierID);
            cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", product.UnitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
            cmd.Parameters.AddWithValue("@Discontinued", product.Discontinued);
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
        public static bool Update(Product product, out string msg)
        {
            msg = "";

            bool
              rtn = true;

            string
              strSQL = @"
                            UPDATE Products
                            SET
                               ProductName=@ProductName,
                               SupplierID=@SupplierID,
                               CategoryID=@CategoryID,
                               QuantityPerUnit=@QuantityPerUnit,                
                               UnitPrice=@UnitPrice,
                               UnitsInStock=@UnitsInStock,
                               UnitsOnOrder=@UnitsOnOrder,
                               ReorderLevel=@ReorderLevel,
                               Discontinued=@Discontinued

                            WHERE    ProductID = @ProductID
            ";


            Tools tool = new Tools();
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@SupplierID", product.SupplierID);
            cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", product.UnitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
            cmd.Parameters.AddWithValue("@Discontinued", product.Discontinued);
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
            Product product = new Product();
            product.ProductID = id;

            msg = "";

            bool
              rtn = true;

            string
              strSQL = @"
                          DELETE FROM Products 
                            
                          WHERE ProductID = @ProductID
            ";


            Tools tool = new Tools();
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@ProductID", product.ProductID);

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
        public static Product GetByProductID(int ProductID, out string msg)
        {
            msg = "";

            Product product = new Product();

            string
              strSQL = @"
                            SELECT    *
                            FROM    Products
                            WHERE   ProductID = @ProductID
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            cmd.Parameters.AddWithValue("@ProductID", ProductID);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        product.ProductID = Convert.ToInt32(dr["ProductID"]);
                        product.ProductName = dr["ProductName"].ToString();
                        product.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        product.QuantityPerUnit = dr["QuantityPerUnit"].ToString();
                        product.UnitsOnOrder = Convert.ToInt32(dr["UnitsOnOrder"]);
                        product.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                        product.UnitsInStock = Convert.ToInt32(dr["UnitsInStock"]);
                        product.ReorderLevel = Convert.ToInt32(dr["ReorderLevel"]);
                        product.Discontinued = Convert.ToBoolean(dr["Discontinued"]);
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


            return product;
        }

        public static List<Product> GetLastAdded10Products(out string msg)
        {
            msg = "";

            List<Product> products = new List<Product>();

            string
              strSQL = @"
                            SELECT    *
                            FROM    Products
                            ORDER BY ProductID DESC
            ";
            //TOP 10 
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
                        Product product = new Product();
                        product.ProductID = Convert.ToInt32(dr["ProductID"]);
                        product.ProductName = dr["ProductName"].ToString();
                        product.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        product.QuantityPerUnit = dr["QuantityPerUnit"].ToString();
                        product.UnitsOnOrder = Convert.ToInt32(dr["UnitsOnOrder"]);
                        product.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                        product.UnitsInStock = Convert.ToInt32(dr["UnitsInStock"]);
                        product.ReorderLevel = Convert.ToInt32(dr["ReorderLevel"]);
                        product.Discontinued = Convert.ToBoolean(dr["Discontinued"]);

                        products.Add(product);
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


            return products;
        }

        public static List<Product> GetProductByName(string text, out string msg)
        {
            msg = "";
            List<Product> products = new List<Product>();

            Product product = new Product();

            string
              strSQL = $@"
                    
                                
                          SELECT * FROM Products WHERE ProductName LIKE @ProductName
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            cmd.Parameters.AddWithValue("@ProductName", "%" + text + "%");

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {   
                        product = new Product();

                        product.ProductID = Convert.ToInt32(dr["ProductID"]);
                        product.ProductName = dr["ProductName"].ToString();
                        product.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        product.QuantityPerUnit = dr["QuantityPerUnit"].ToString();
                        product.UnitsOnOrder = Convert.ToInt32(dr["UnitsOnOrder"]);
                        product.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                        product.UnitsInStock = Convert.ToInt32(dr["UnitsInStock"]);
                        product.ReorderLevel = Convert.ToInt32(dr["ReorderLevel"]);
                        product.Discontinued = Convert.ToBoolean(dr["Discontinued"]);

                        products.Add(product);
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


            return products;
        }

        public static List<Product> GetProductByFilter(Product product, out string msg)
        {
            msg = "";
            List<Product> products = new List<Product>();

            string filter = "";
            if (!string.IsNullOrEmpty(product.ProductName))
            {
                filter += " AND ProductName LIKE @ProductName";
            }
            //if (!string.IsNullOrEmpty(product.QuantityPerUnit))
            //{
            //    filter = "QuantityPerUnit LIKE '%@QuantityPerUnit%'";
            //}
            if (product.ProductID > 0)
            {
                filter += " AND ProductID = @ProductID";
            }
            if (product.CategoryID > 0)
            {
                filter += " AND CategoryID = @CategoryID";
            }
            if (product.UnitsInStock > 0)
            {
                filter += " AND UnitsInStock = @UnitsInStock";
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = "WHERE " + filter.Remove(0, 4);
            }
            string
              strSQL = $@"
                    SELECT * 
                    FROM Products 
                    {filter}
                           
                         
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            cmd.Parameters.AddWithValue("@ProductID", product.ProductID );
            cmd.Parameters.AddWithValue("@ProductName", "%" + product.ProductName + "%");
            cmd.Parameters.AddWithValue("@CategoryID",  product.CategoryID );
            cmd.Parameters.AddWithValue("@UnitsInStock",  product.UnitsInStock);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        product = new Product();

                        product.ProductID = Convert.ToInt32(dr["ProductID"]);
                        product.ProductName = dr["ProductName"].ToString();
                        product.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        product.QuantityPerUnit = dr["QuantityPerUnit"].ToString();
                        product.UnitsOnOrder = Convert.ToInt32(dr["UnitsOnOrder"]);
                        product.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                        product.UnitsInStock = Convert.ToInt32(dr["UnitsInStock"]);
                        product.ReorderLevel = Convert.ToInt32(dr["ReorderLevel"]);
                        product.Discontinued = Convert.ToBoolean(dr["Discontinued"]);

                        products.Add(product);
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
            return products;

        }
    }
}

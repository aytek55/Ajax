using ADO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Facade
{
    public class Suppliers
    {
        public static int AddSupplier(Supplier supplier, out string msg)
        {

            msg = "";

            int
              id = 0;

            string
              strSQL = "";

            strSQL = strSQL = @"
     

                   
                                INSERT INTO 
                                    Suppliers(
                                        CompanyName, 
                                        ContactName,
                                        Address,
                                        City,
                                        Region,
                                        PostalCode,
                                        Country,
                                        Phone,
                                        Fax,
                                        HomePage
                                    )
                                    VALUES(
                                        @CompanyName, 
                                        @ContactName,
                                        @Address,
                                        @City,
                                        @Region,
                                        @PostalCode,
                                        @Country,
                                        @Phone,
                                        @Fax,
                                        @HomePage
                                    )
                                SELECT @@IDENTITY
            
            ";
            //eklenenin id si dönüyor
            Tools tool = new Tools();

            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", supplier.ContactName);
            cmd.Parameters.AddWithValue("@Address", supplier.Address);
            cmd.Parameters.AddWithValue("@City", supplier.City);
            cmd.Parameters.AddWithValue("@Region", supplier.Region);
            cmd.Parameters.AddWithValue("@PostalCode", supplier.PostalCode);
            cmd.Parameters.AddWithValue("@Country", supplier.Country);
            cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
            cmd.Parameters.AddWithValue("@Fax", supplier.Fax);
            cmd.Parameters.AddWithValue("@HomePage", supplier.HomePage);
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

        public static bool DeleteSupplier(int id, out string msg)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierID = id;

            msg = "";

            bool
              rtn = true;

            string
              strSQL = @"
                          DELETE FROM Suppliers 
                            
                          WHERE SupplierID = @SupplierID
            ";


            Tools tool = new Tools();
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);

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

        public static List<Supplier> GetAllSuppliers(out string msg)
        {
            msg = "";
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            ADO.Entity.Supplier supplier = new ADO.Entity.Supplier();

            string
            strSQL = @"
                            SELECT   *
                            FROM    Suppliers

                                   
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);


            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        supplier = new Supplier();
                        supplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        supplier.CompanyName = dr["CompanyName"].ToString();
                        supplier.ContactName = dr["ContactName"].ToString();
                        supplier.Address = dr["Address"].ToString();
                        supplier.City = dr["City"].ToString();
                        supplier.Region = dr["Region"].ToString();
                        supplier.PostalCode = dr["PostalCode"].ToString();
                        supplier.Country = dr["Country"].ToString();
                        supplier.Phone = dr["Phone"].ToString();
                        supplier.Fax = dr["Fax"].ToString();
                        supplier.HomePage = dr["HomePage"].ToString();

                        suppliers.Add(supplier);
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


            return suppliers;

        }

        public static List<Supplier> GetCountrySelector(out string msg)
        {
            msg = "";
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();
            ADO.Entity.Supplier supplier = new ADO.Entity.Supplier();

            string
            strSQL = @"
                            SELECT   *
                            FROM    Suppliers

                                   
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);


            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        supplier = new Supplier();
                        supplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        supplier.CompanyName = dr["CompanyName"].ToString();
                        supplier.ContactName = dr["ContactName"].ToString();
                        supplier.Address = dr["Address"].ToString();
                        supplier.City = dr["City"].ToString();
                        supplier.Region = dr["Region"].ToString();
                        supplier.PostalCode = dr["PostalCode"].ToString();
                        supplier.Country = dr["Country"].ToString();
                        supplier.Phone = dr["Phone"].ToString();
                        supplier.Fax = dr["Fax"].ToString();
                        supplier.HomePage = dr["HomePage"].ToString();

                        suppliers.Add(supplier);
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


            return suppliers;
        }

        public static List<ADO.Entity.Supplier> GetListSupplier( out string msg)
        {
            msg = "";
            List<ADO.Entity.Supplier> suppliers = new List<ADO.Entity.Supplier>();

            string
              strSQL = @"
                            SELECT  TOP 10  *
                            FROM    Suppliers
                            ORDER BY SupplierID DESC
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
                        Supplier supplier = new Supplier();

                        supplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        supplier.CompanyName = dr["CompanyName"].ToString();
                        supplier.ContactName = dr["ContactName"].ToString();
                        supplier.Address = dr["Address"].ToString();
                        supplier.City = dr["City"].ToString();
                        supplier.Region = dr["Region"].ToString();
                        supplier.PostalCode = dr["PostalCode"].ToString();
                        supplier.Country = dr["Country"].ToString();
                        supplier.Phone = dr["Phone"].ToString();
                        supplier.Fax = dr["Fax"].ToString();
                        supplier.HomePage = dr["HomePage"].ToString();

                        suppliers.Add(supplier);
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


            return suppliers;
        }

        public static Supplier GetSupById(int id, out string msg)
        {
            msg = "";

            Supplier supplier = new Supplier();   

            string
              strSQL = @"
                            SELECT    *
                            FROM    Suppliers
                            WHERE   SupplierID = @SupplierID
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            cmd.Parameters.AddWithValue("@SupplierID", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        supplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        supplier.CompanyName = dr["CompanyName"].ToString();
                        supplier.ContactName= dr["ContactName"].ToString();
                        supplier.Address= dr["Address"].ToString();
                        supplier.City = dr["City"].ToString();
                        supplier.Region = dr["Region"].ToString();
                        supplier.PostalCode = dr["PostalCode"].ToString();
                        supplier.Country = dr["Country"].ToString();
                        supplier.Phone = dr["Phone"].ToString();
                        supplier.Fax = dr["Fax"].ToString();
                        supplier.HomePage = dr["HomePage"].ToString();
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


            return supplier;
        }

        public static List<Supplier> GetSupplierByFilter(Supplier supplier, out string msg)
        {
            msg = "";
            List<Supplier> suppliers = new List<Supplier>();

            string filter = "";
            if (!string.IsNullOrEmpty(supplier.CompanyName))
            {
                filter += " AND CompanyName LIKE @CompanyName";
            }
            if (!string.IsNullOrEmpty(supplier.ContactName))
            {
                filter += " AND ContactName LIKE @ContactName";
            }
            if (!string.IsNullOrEmpty(supplier.City))
            {
                filter += " AND City LIKE @City";
            }
            if (!string.IsNullOrEmpty(supplier.Country))
            {
                filter += " AND Country LIKE @Country";
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = "WHERE " + filter.Remove(0, 4);
            }
            string
              strSQL = $@"
                    SELECT * 
                    FROM Suppliers 
                    {filter}
                           
                         
            ";

            Tools tool = new Tools();
            SqlConnection cn = tool.Connection;
            SqlCommand cmd = new SqlCommand(strSQL, cn);

            cmd.Parameters.AddWithValue("@CompanyName", "%" + supplier.CompanyName + "%");
            cmd.Parameters.AddWithValue("@ContactName", "%" + supplier.ContactName + "%");
            cmd.Parameters.AddWithValue("@City", "%" + supplier.City + "%");
            cmd.Parameters.AddWithValue("@Country", "%" + supplier.Country + "%");

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        supplier = new Supplier();
                        supplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        supplier.CompanyName = dr["CompanyName"].ToString();
                        supplier.ContactName = dr["ContactName"].ToString();
                        supplier.Address = dr["Address"].ToString();
                        supplier.City = dr["City"].ToString();
                        supplier.Region = dr["Region"].ToString();
                        supplier.PostalCode = dr["PostalCode"].ToString();
                        supplier.Country = dr["Country"].ToString();
                        supplier.Phone = dr["Phone"].ToString();
                        supplier.Fax = dr["Fax"].ToString();
                        supplier.HomePage = dr["HomePage"].ToString();

                        suppliers.Add(supplier);
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
            return suppliers;

        }

        public static bool UpdateSupplier(Supplier supplier, out string msg)
        {
            msg = "";

            bool
              rtn = true;

            string
              strSQL = @"
                            UPDATE Suppliers
                            SET
                               CompanyName=@CompanyName,
                               ContactName=@ContactName,
                               Address=@Address,
                               City=@City,                
                               Region=@Region,
                               PostalCode=@PostalCode,
                               Country=@Country,
                               Phone=@Phone,
                               Fax=@Fax,
                               HomePage=@HomePage

                            WHERE    SupplierID = @SupplierID
            ";


            Tools tool = new Tools();
            SqlConnection cnn = tool.Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
            cmd.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", supplier.ContactName);
            cmd.Parameters.AddWithValue("@Address", supplier.Address);
            cmd.Parameters.AddWithValue("@City", supplier.City);
            cmd.Parameters.AddWithValue("@Region", supplier.Region);
            cmd.Parameters.AddWithValue("@PostalCode", supplier.PostalCode);
            cmd.Parameters.AddWithValue("@Country", supplier.Country);
            cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
            cmd.Parameters.AddWithValue("@Fax", supplier.Fax);
            cmd.Parameters.AddWithValue("@HomePage", supplier.HomePage);
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
    }
}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    internal class Tools
    {
		private SqlConnection connection;

		public SqlConnection Connection
		{
			get { return connection; }
		}

		public Tools()
		{
			connection = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;");
            

        }
	}
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLib
{
    public static class Connection
    {
        public static SqlConnection CreateConnection()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "PrototypeDB",
                IntegratedSecurity = true
            };
            var db = new SqlConnection(builder.ToString());

            return db;
        }
    }
}

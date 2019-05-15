using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace blogDAO
{
    public class ConnectionDAO : IDisposable
    {
        public SqlConnection conn { get; set; }
        public ConnectionDAO()
        {
            ConnectionStringSettings connectionSql = ConfigurationManager.ConnectionStrings["connectionSql"];
            conn = new SqlConnection(connectionSql.ConnectionString);
            conn.Open();
            Console.WriteLine("Connect");
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
            Console.WriteLine("Disconnect");
        }
    }
}

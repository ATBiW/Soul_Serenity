using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Serenity
{
    internal class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=LAPTOP-KACN2F83\\LKSDATABASE;Initial Catalog=DbSoulSerenity;Integrated Security=True";
            return conn;
        }
    }
}

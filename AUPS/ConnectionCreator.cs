using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders
{
    public class ConnectionCreator
    {
        private static string connString = "Server=localhost;Port=5432;User Id=postgres;Password=St.Cyprian5;Database=AUPSprojekat";
        public static NpgsqlConnection createConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}

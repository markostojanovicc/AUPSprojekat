using AUPS.SqlProviders.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders
{
    public class OperacijaSqlProvider : IOperacijaSqlProvider
    {
        #region Queries
        private const string GET_ALL_RECORDS_FROM_OPERACIJA =
            @"
                  SELECT * FROM operacija;
            ";
        #endregion

        public void GetAllFromOperacija(ref DataTable dataTable) 
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_OPERACIJA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }
        }
    }
}

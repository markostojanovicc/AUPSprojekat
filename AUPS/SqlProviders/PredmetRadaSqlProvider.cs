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
    public class PredmetRadaSqlProvider : IPredmetRadaSqlProvider
    {
        #region Queries
        private const string GET_ALL_RECORDS_FROM_PREDMET_RADA =
            @"
                  SELECT * FROM predmetrada;
            ";
        #endregion

        public void GetAllFromPredmetRada(ref DataTable dataTable)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_PREDMET_RADA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }
        }
    }
}

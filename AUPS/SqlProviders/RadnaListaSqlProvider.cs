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
    public class RadnaListaSqlProvider : IRadnaListaSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_RADNA_LISTA =
            @"
                  SELECT * FROM radnalista;
            ";
        #endregion

        public void GetAllFromRadnaLista(ref DataTable dataTable)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNA_LISTA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }
        }
    }
}

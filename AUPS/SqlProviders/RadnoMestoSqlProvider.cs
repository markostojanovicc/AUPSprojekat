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
    public class RadnoMestoSqlProvider : IRadnoMestoSqlProvider
    {
        #region Queries
        private const string GET_ALL_RECORDS_FROM_RADNO_MESTO =
            @"
                  SELECT * FROM radnomesto;
            ";
        #endregion

        public void GetAllFromRadnoMesto(ref DataTable dataTable)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNO_MESTO, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }
        }
    }
}
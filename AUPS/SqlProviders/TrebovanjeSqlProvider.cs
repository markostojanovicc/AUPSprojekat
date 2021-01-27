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
    public class TrebovanjeSqlProvider : ITrebovanjeSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_TREBOVANJE =
            @"
                  SELECT * FROM trebovanje;
            ";

        public bool DeleteFromTrebovanjeById(int iDTehPostupak)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void GetAllFromTrebovanje(ref DataTable dataTable)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TREBOVANJE, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }
        }
    }
}

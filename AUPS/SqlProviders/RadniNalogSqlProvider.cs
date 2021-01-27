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
    public class RadniNalogSqlProvider : IRadniNalogSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_RADNI_NALOG =
            @"
                  SELECT * FROM radninalog;
            ";

        
        #endregion

        public void GetAllFromRadniNalog(ref DataTable dataTable)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNI_NALOG, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }
        }

        public bool DeleteFromRadniNalogById(int iDRadniNalog)
        {
            throw new NotImplementedException();
        }
    }
}

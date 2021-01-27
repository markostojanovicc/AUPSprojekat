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
    public class TehnoloskiPostupakSqlProvider : ITehnoloskiPostupakSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK =
            @"
                  SELECT * FROM tehnoloskipostupak;
            ";

        
        #endregion

        public void GetAllFromTehnoloskiPostupak(ref DataTable dataTable) 
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

        }

        public bool DeleteFromTehnoloskiPostupakById(int iDTehPostupak)
        {
            throw new NotImplementedException();
        }
    }
}

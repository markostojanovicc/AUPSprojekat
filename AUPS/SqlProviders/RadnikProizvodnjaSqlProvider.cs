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
    public class RadnikProizvodnjaSqlProvider : IRadnikProizvodnjaSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_RADNIK_PROIZVODNJA =
            @"
                  SELECT * FROM radnikproizvodnja;
            ";

        
        #endregion

        public void GetAllFromRadnikProizvodnja(ref DataTable dataTable)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNIK_PROIZVODNJA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }
        }

        public bool DeleteFromRadnikProizvodnjaById(int iDRadnik)
        {
            throw new NotImplementedException();
        }
    }
}

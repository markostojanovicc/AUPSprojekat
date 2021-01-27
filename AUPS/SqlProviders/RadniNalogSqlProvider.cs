using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<RadniNalog> GetAllFromRadniNalog()
        {
            ObservableCollection<RadniNalog> radniNalogList = new ObservableCollection<RadniNalog>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNI_NALOG, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    RadniNalog radniNalog = new RadniNalog();
                    radniNalog.IDRadniNalog = rdr.GetInt32(0);
                    radniNalog.DatumUlaz = rdr.GetDateTime(1);
                    radniNalog.DatumIzlaz = rdr.GetDateTime(2);
                    radniNalog.KolicinaProizvoda = rdr.GetInt32(3);
                    radniNalog.IDPredmetRada = rdr.GetInt32(4);
                    radniNalogList.Add(radniNalog);
                }
            }

            return radniNalogList;
        }

        public bool DeleteFromRadniNalogById(int iDRadniNalog)
        {
            throw new NotImplementedException();
        }
    }
}

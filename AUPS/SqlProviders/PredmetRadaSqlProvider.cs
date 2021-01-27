using AUPS.SqlProviders.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUPS.Models;
using System.Collections.ObjectModel;

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

        public ObservableCollection<PredmetRada> GetAllFromPredmetRada()
        {
            ObservableCollection<PredmetRada> predmetRadaList = new ObservableCollection<PredmetRada>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_PREDMET_RADA, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PredmetRada predmetRada = new PredmetRada();
                    predmetRada.IDPredmetRada = rdr.GetInt32(0);
                    predmetRada.TipPredmetRada = rdr.GetString(1);
                    predmetRada.NazivPR = rdr.GetString(2);
                    predmetRada.JedMerePR = rdr.GetString(3);
                    predmetRada.Cena = rdr.GetInt32(4);
                    predmetRadaList.Add(predmetRada);
                }
            }

            return predmetRadaList;

        }

    }
}

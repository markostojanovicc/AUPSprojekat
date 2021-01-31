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
using NpgsqlTypes;

namespace AUPS.SqlProviders
{
    public class PredmetRadaSqlProvider : IPredmetRadaSqlProvider
    {
        #region Queries
        private const string GET_ALL_RECORDS_FROM_PREDMET_RADA =
            @"
                  SELECT * FROM predmetrada;
            ";

        private const string DELETE_FROM_PREDMET_RADA_BY_ID =
            @"
                  DELETE FROM predmetrada WHERE idpredmetrada = @Id
            ";

        private const string UPDATE_PREDMET_RADA_BY_ID =
            @"
                  UPDATE predmetrada SET tippredmetrada = @TipPredmetRada, nazivpr = @NazivPR, jedmerepr = @JedMerePR, cena = @Cena
                  WHERE idpredmetrada = @Id
            ";

        private const string CREATE_PREDMET_RADA =
            @"
                  INSERT INTO predmetrada VALUES (nextval('predmetRadaSeq'), @TipPredmetRada, @NazivPR, @JedMerePR, @Cena);
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

        public bool DeleteFromPredmetRadaById(int iDPredmetRada)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_PREDMET_RADA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDPredmetRada);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdatePredmetRadaById(PredmetRada predmetRadaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_PREDMET_RADA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, predmetRadaNew.IDPredmetRada);
                cmd.Parameters.AddWithValue("@TipPredmetRada", NpgsqlDbType.Varchar, predmetRadaNew.TipPredmetRada);
                cmd.Parameters.AddWithValue("@NazivPR", NpgsqlDbType.Varchar, predmetRadaNew.NazivPR);
                cmd.Parameters.AddWithValue("@JedMerePR", NpgsqlDbType.Varchar, predmetRadaNew.JedMerePR);
                cmd.Parameters.AddWithValue("@Cena", NpgsqlDbType.Varchar, predmetRadaNew.Cena);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreatePredmetRadaById(PredmetRada predmetRadaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_PREDMET_RADA, sqlConnection);

                cmd.Parameters.AddWithValue("@TipPredmetRada", NpgsqlDbType.Varchar, predmetRadaNew.TipPredmetRada);
                cmd.Parameters.AddWithValue("@NazivPR", NpgsqlDbType.Varchar, predmetRadaNew.NazivPR);
                cmd.Parameters.AddWithValue("@JedMerePR", NpgsqlDbType.Varchar, predmetRadaNew.JedMerePR);
                cmd.Parameters.AddWithValue("@Cena", NpgsqlDbType.Varchar, predmetRadaNew.Cena);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

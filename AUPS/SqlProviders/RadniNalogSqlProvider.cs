using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using Npgsql;
using NpgsqlTypes;
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
                  SELECT rn.*, pr.nazivpr
                    FROM radninalog rn
                    LEFT JOIN predmetrada pr
                    ON rn.idpredmetrada = pr.idpredmetrada
            ";
        private const string DELETE_FROM_RADNI_NALOG_BY_ID =
            @"
                  DELETE FROM radninalog WHERE idradninalog = @Id
            ";

        private const string UPDATE_RADNI_NALOG_BY_ID =
            @"
                  UPDATE radninalog SET datumulaz = @DatumUlaz, datumizlaz = @DatumIzlaz, kolicinaproizvoda = @KolicinaProizvoda, idpredmetrada= @IDPredmetRada
                  WHERE idradninalog = @Id
            ";

        private const string CREATE_RADNI_NALOG =
            @"
                  INSERT INTO radninalog VALUES (nextval('radniNalogSeq'), @DatumUlaz, @DatumIzlaz, @KolicinaProizvoda, @IDPredmetRada);
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
                    radniNalog.PredmetRada = new PredmetRada();
                    radniNalog.PredmetRada.NazivPR = rdr.GetString(5);
                    radniNalogList.Add(radniNalog);
                }
            }

            return radniNalogList;
        }

        public bool DeleteFromRadniNalogById(int iDRadniNalog)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_RADNI_NALOG_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDRadniNalog);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateRadniNalogById(RadniNalog radniNalogNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_RADNI_NALOG_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, radniNalogNew.IDRadniNalog);
                cmd.Parameters.AddWithValue("@DatumUlaz", NpgsqlDbType.Date, radniNalogNew.DatumUlaz);
                cmd.Parameters.AddWithValue("@DatumIzlaz", NpgsqlDbType.Date, radniNalogNew.DatumIzlaz);
                cmd.Parameters.AddWithValue("@KolicinaProizvoda", NpgsqlDbType.Integer, radniNalogNew.KolicinaProizvoda);
                cmd.Parameters.AddWithValue("@IDPredmetRada", NpgsqlDbType.Integer, radniNalogNew.PredmetRada.IDPredmetRada);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreateRadniNalogById(RadniNalog radniNalogNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_RADNI_NALOG, sqlConnection);

                cmd.Parameters.AddWithValue("@DatumUlaz", NpgsqlDbType.Date, radniNalogNew.DatumUlaz);
                cmd.Parameters.AddWithValue("@DatumIzlaz", NpgsqlDbType.Date, radniNalogNew.DatumIzlaz);
                cmd.Parameters.AddWithValue("@KolicinaProizvoda", NpgsqlDbType.Integer, radniNalogNew.KolicinaProizvoda);
                cmd.Parameters.AddWithValue("@IDPredmetRada", NpgsqlDbType.Integer, radniNalogNew.PredmetRada.IDPredmetRada);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

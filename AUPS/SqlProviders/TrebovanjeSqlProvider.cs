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
    public class TrebovanjeSqlProvider : ITrebovanjeSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_TREBOVANJE =
            @"
                  SELECT * FROM trebovanje;
            ";
        private const string DELETE_FROM_TREBOVANJE_BY_ID =
           @"
                  DELETE FROM trebovanje WHERE idtrebovanje = @Id
            ";

        private const string UPDATE_TREBOVANJE_BY_ID =
            @"
                  UPDATE trebovanje SET tiptrebovanja = @TipTrebovanja, jedmere = @JedMere, kolicinarobe = @KolicinaRobe, idradninalog = @IDRadniNalog
                  WHERE idtrebovanje = @Id
            ";

        private const string CREATE_TEHNOLOSKI_POSTUPAK =
            @"
                  INSERT INTO trebovanje VALUES (nextval('trebovanjeSeq'), @TipTrebovanja @JedMere, @KolicinaRobe, @IDRadniNalog);
            ";
        #endregion

        public ObservableCollection<Trebovanje> GetAllFromTrebovanje()
        {
            ObservableCollection<Trebovanje> trebovanjeList = new ObservableCollection<Trebovanje>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TREBOVANJE, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Trebovanje trebovanje = new Trebovanje();
                    trebovanje.IDTrebovanje = rdr.GetInt32(0);
                    trebovanje.TipTrebovanja = rdr.GetString(1);
                    trebovanje.JedMere = rdr.GetString(2);
                    trebovanje.KolicinaRobe = rdr.GetInt32(3);
                    trebovanje.RadniNalog = new RadniNalog();
                    trebovanje.RadniNalog.IDRadniNalog = rdr.GetInt32(4);
                    trebovanjeList.Add(trebovanje);
                }
            }

            return trebovanjeList;
        }

        public bool DeleteFromTrebovanjeById(int iDTrebovanje)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_TREBOVANJE_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDTrebovanje);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateTrebovanjeById(Trebovanje trebovanjeNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_TREBOVANJE_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, trebovanjeNew.IDTrebovanje);
                cmd.Parameters.AddWithValue("@TipTrebovanja", NpgsqlDbType.Varchar, trebovanjeNew.TipTrebovanja);
                cmd.Parameters.AddWithValue("@JedMere", NpgsqlDbType.Varchar, trebovanjeNew.JedMere);
                cmd.Parameters.AddWithValue("@KolicinaRobe", NpgsqlDbType.Varchar, trebovanjeNew.KolicinaRobe);
                //cmd.Parameters.AddWithValue("@IDRadniNalog", NpgsqlDbType.Varchar, trebovanjeNew.IDRadniNalog);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreateTrebovanjeById(Trebovanje trebovanjeNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_TEHNOLOSKI_POSTUPAK, sqlConnection);

                cmd.Parameters.AddWithValue("@TipTrebovanja", NpgsqlDbType.Varchar, trebovanjeNew.TipTrebovanja);
                cmd.Parameters.AddWithValue("@JedMere", NpgsqlDbType.Varchar, trebovanjeNew.JedMere);
                cmd.Parameters.AddWithValue("@KolicinaRobe", NpgsqlDbType.Varchar, trebovanjeNew.KolicinaRobe);
                cmd.Parameters.AddWithValue("@IDRadniNalog", NpgsqlDbType.Varchar, trebovanjeNew.RadniNalog.IDRadniNalog);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

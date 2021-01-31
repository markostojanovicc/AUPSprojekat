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
    public class TehnoloskiPostupakSqlProvider : ITehnoloskiPostupakSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK =
            @"
                  SELECT tp.*,o.nazivoperacije
                FROM tehnoloskipostupak tp
                LEFT JOIN operacija o
                ON tp.idoperacija = o.idoperacija
            ";
        private const string DELETE_FROM_TEHNOLOSKI_POSTUPAK_BY_ID =
            @"
                  DELETE FROM tehnoloskipostupak WHERE idtehpostupak = @Id
            ";

        private const string UPDATE_TEHNOLOSKI_POSTUPAK_BY_ID =
            @"
                  UPDATE tehnoloskipostupak SET tiptehpostupak = @TipTehPostupak, vremeizrade = @VremeIzrade, serijakom = @SerijaKom, brKomada= @BrKomada, idoperacija = @IDOperacija
                  WHERE idtehpostupak = @Id
            ";

        private const string CREATE_TEHNOLOSKI_POSTUPAK =
            @"
                  INSERT INTO tehnoloskipostupak VALUES (nextval('tehPostupakSeq'), @TipTehPostupak, @VremeIzrade, @SerijaKom, @BrKomada, @IDOperacija);
            ";

        #endregion

        public ObservableCollection<TehnoloskiPostupak> GetAllFromTehnoloskiPostupak() 
        {
            ObservableCollection<TehnoloskiPostupak> tehnoloskiPostupakList = new ObservableCollection<TehnoloskiPostupak>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TehnoloskiPostupak tehnoloskiPostupak = new TehnoloskiPostupak();
                    tehnoloskiPostupak.IDTehPostupak = rdr.GetInt32(0);
                    tehnoloskiPostupak.TipTehPostupak = rdr.GetString(1);
                    tehnoloskiPostupak.VremeIzrade = rdr.GetInt32(2);
                    tehnoloskiPostupak.SerijaKom = rdr.GetInt32(3);
                    tehnoloskiPostupak.BrKomada = rdr.GetInt32(4);
                    tehnoloskiPostupak.Operacija = new Operacija();
                    tehnoloskiPostupak.Operacija.NazivOperacije = rdr.GetString(6);
                    tehnoloskiPostupakList.Add(tehnoloskiPostupak);
                }
            }

            return tehnoloskiPostupakList;

        }

        public bool DeleteFromTehnoloskiPostupakById(int iDTehPostupak)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_TEHNOLOSKI_POSTUPAK_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDTehPostupak);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateTehnoloskiPostupakById(TehnoloskiPostupak tehnoloskiPostupakNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_TEHNOLOSKI_POSTUPAK_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, tehnoloskiPostupakNew.IDTehPostupak);
                cmd.Parameters.AddWithValue("@TipTehPostupak", NpgsqlDbType.Varchar, tehnoloskiPostupakNew.TipTehPostupak);
                cmd.Parameters.AddWithValue("@VremeIzrade", NpgsqlDbType.Integer, tehnoloskiPostupakNew.VremeIzrade);
                cmd.Parameters.AddWithValue("@SerijaKom", NpgsqlDbType.Integer, tehnoloskiPostupakNew.SerijaKom);
                cmd.Parameters.AddWithValue("@BrKomada", NpgsqlDbType.Integer, tehnoloskiPostupakNew.BrKomada);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Integer, tehnoloskiPostupakNew.Operacija.IDOperacija);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreateTehnoloskiPostupakById(TehnoloskiPostupak tehnoloskiPostupakNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_TEHNOLOSKI_POSTUPAK, sqlConnection);

                cmd.Parameters.AddWithValue("@TipTehPostupak", NpgsqlDbType.Varchar, tehnoloskiPostupakNew.TipTehPostupak);
                cmd.Parameters.AddWithValue("@VremeIzrade", NpgsqlDbType.Integer, tehnoloskiPostupakNew.VremeIzrade);
                cmd.Parameters.AddWithValue("@SerijaKom", NpgsqlDbType.Integer, tehnoloskiPostupakNew.SerijaKom);
                cmd.Parameters.AddWithValue("@BrKomada", NpgsqlDbType.Integer, tehnoloskiPostupakNew.BrKomada);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Integer, tehnoloskiPostupakNew.Operacija.IDOperacija);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

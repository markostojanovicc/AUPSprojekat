using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders
{
    class TehnPostupakOperacijaSqlProvider : ITehnPostupakOperacijaSqlProvider
    {

        #region Queries
        private const string GET_ALL_RECORDS_FROM_TEHN_POSTUPAK_OPERACIJA =
            @"
                SELECT * FROM tehnpostupakoperacija
            ";
        private const string DELETE_FROM_TEHN_POSTUPAK_OPERACIJA_BY_ID =
            @"
                DELETE FROM tehnpostupakoperacija WHERE idtehnpostupakoperacija = @Id
            ";

        private const string UPDATE_TEHN_POSTUPAK_OPERACIJA_BY_ID =
            @"
                UPDATE tehnpostupakoperacija SET idtehpostupak = @IDTehPostupak, idoperacija =@IDOperacija, rbroperacije= @RbrOperacije
                WHERE idtehnpostupakoperacija = @Id
            ";

        private const string CREATE_TEHN_POSTUPAK_OPERACIJA =
            @"
                INSERT INTO tehnpostupakoperacija VALUES (nextval('tehnpostupakOperacijaSeq'), @TipTehPostupak, @VremeIzrade, @SerijaKom, @BrKomada);
            ";
        #endregion


        public ObservableCollection<TehnPostupakOperacija> GetAllFromTehnPostupakOperacija()
        {
            ObservableCollection<TehnPostupakOperacija> tehnPostupakOperacijaList = new ObservableCollection<TehnPostupakOperacija>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TEHN_POSTUPAK_OPERACIJA, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TehnPostupakOperacija tehnPostupakOperacija = new TehnPostupakOperacija();
                    tehnPostupakOperacija.IDTehnPostupakOperacija = rdr.GetInt32(0);
                    tehnPostupakOperacija.IDTehPostupak = rdr.GetInt32(0);
                    tehnPostupakOperacija.IDOperacija = rdr.GetInt32(2);
                    tehnPostupakOperacija.RbrOperacije = rdr.GetInt32(3);
                    tehnPostupakOperacijaList.Add(tehnPostupakOperacija);
                }
            }

            return tehnPostupakOperacijaList;
        }

        public bool CreateTehnPostupakOperacijaById(TehnPostupakOperacija tehnPostupakOperacijaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_TEHN_POSTUPAK_OPERACIJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@IDTehPostupak", NpgsqlDbType.Integer, tehnPostupakOperacijaNew.IDTehPostupak);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Integer, tehnPostupakOperacijaNew.IDOperacija);
                cmd.Parameters.AddWithValue("@RbrOperacije", NpgsqlDbType.Integer, tehnPostupakOperacijaNew.RbrOperacije);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateTehnPostupakOperacijaById(TehnPostupakOperacija tehnPostupakOperacija)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_TEHN_POSTUPAK_OPERACIJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, tehnPostupakOperacija.IDTehnPostupakOperacija);
                cmd.Parameters.AddWithValue("@IDTehPostupak", NpgsqlDbType.Integer, tehnPostupakOperacija.IDTehPostupak);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Integer, tehnPostupakOperacija.IDOperacija);
                cmd.Parameters.AddWithValue("@RbrOperacije", NpgsqlDbType.Integer, tehnPostupakOperacija.RbrOperacije);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool DeleteFromTehnPostupakOperacijaById(int iDTehnPostupakOperacija)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_TEHN_POSTUPAK_OPERACIJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDTehnPostupakOperacija);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

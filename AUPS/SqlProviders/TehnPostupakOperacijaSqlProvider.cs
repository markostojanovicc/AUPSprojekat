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
    public class TehnPostupakOperacijaSqlProvider : ITehnPostupakOperacijaSqlProvider
    {

        #region Queries
        private const string GET_ALL_RECORDS_FROM_TEHN_POSTUPAK_OPERACIJA =
            @"
                SELECT tpo.*, o.nazivoperacije, tp.tiptehpostupak 
                FROM tehnpostupakoperacija tpo
                INNER JOIN operacija o
                ON tpo.idoperacija = o.idoperacija
                INNER JOIN tehnoloskipostupak tp
                ON tp.idtehpostupak = tpo.idtehpostupak
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

        private const string UPDATE_RBROPERACIJE_FROM_TEHN_POSTUPAK_OPERACIJA_BY_ID =
            @"
                UPDATE tehnpostupakoperacija SET rbroperacije= @RbrOperacije
                WHERE idtehnpostupakoperacija = @Id
            ";

        private const string CREATE_TEHN_POSTUPAK_OPERACIJA =
            @"
                INSERT INTO tehnpostupakoperacija VALUES (nextval('tehnpostupakOperacijaSeq'), @IDTehPostupak, @IDOperacija, @RbrOperacije);
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
                    tehnPostupakOperacija.TehnoloskiPostupak = new TehnoloskiPostupak
                    {
                        IDTehPostupak = rdr.GetInt32(1),
                        TipTehPostupak = rdr.GetString(5)
                    };
                    tehnPostupakOperacija.Operacija = new Operacija
                    {
                        IDOperacija = rdr.GetInt32(2),
                        NazivOperacije = rdr.GetString(4)
                    };
                    tehnPostupakOperacija.RBrOperacije = rdr.GetInt32(3);
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

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_TEHN_POSTUPAK_OPERACIJA, sqlConnection);

                cmd.Parameters.AddWithValue("@IDTehPostupak", NpgsqlDbType.Integer, tehnPostupakOperacijaNew.TehnoloskiPostupak.IDTehPostupak);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Integer, tehnPostupakOperacijaNew.Operacija.IDOperacija);
                cmd.Parameters.AddWithValue("@RbrOperacije", NpgsqlDbType.Integer, tehnPostupakOperacijaNew.RBrOperacije);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateTehnPostupakOperacija(TehnPostupakOperacija tehnPostupakOperacija)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_TEHN_POSTUPAK_OPERACIJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, tehnPostupakOperacija.IDTehnPostupakOperacija);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Integer, tehnPostupakOperacija.Operacija.IDOperacija);
                cmd.Parameters.AddWithValue("@RBrOperacije", NpgsqlDbType.Integer, tehnPostupakOperacija.RBrOperacije);
                cmd.Parameters.AddWithValue("@IDTehPostupak", NpgsqlDbType.Integer, tehnPostupakOperacija.TehnoloskiPostupak.IDTehPostupak);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateRBrOperacijaFromTehnPostupakOperacija(TehnPostupakOperacija tehnPostupakOperacija)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_RBROPERACIJE_FROM_TEHN_POSTUPAK_OPERACIJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, tehnPostupakOperacija.IDTehnPostupakOperacija);
                cmd.Parameters.AddWithValue("@RBrOperacije", NpgsqlDbType.Integer, tehnPostupakOperacija.RBrOperacije);

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

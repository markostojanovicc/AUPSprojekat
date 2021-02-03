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
    public class OperacijaSqlProvider : IOperacijaSqlProvider
    {
        #region Queries
        private const string GET_ALL_RECORDS_FROM_OPERACIJA =
            @"
                  SELECT * FROM operacija;
            ";

        private const string DELETE_FROM_OPERACIJA_BY_ID =
            @"
                  DELETE FROM operacija WHERE idoperacija = @Id
            ";

        private const string UPDATE_OPERACIJA_BY_ID =
            @"
                  UPDATE operacija SET nazivoperacije = @NazivOperacije, osnovnovreme = @OsnovnoVreme, pomocnovreme = @PomocnoVreme, dodatnovreme = @DodatnoVreme, oznakamasine = @OznakaMasine
                  WHERE idoperacija = @Id
            ";

        private const string CREATE_OPERACIJA =
            @"
                  INSERT INTO operacija VALUES (nextval('operacijaSeq'), @NazivOperacije, @OsnovnoVreme, @PomocnoVreme, @DodatnoVreme, @OznakaMasine);
            ";
        #endregion

        public ObservableCollection<Operacija> GetAllFromOperacija() 
        {
            ObservableCollection<Operacija> operacijaList = new ObservableCollection<Operacija>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_OPERACIJA, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Operacija operacija = new Operacija();
                    operacija.IDOperacija = rdr.GetInt32(0);
                    operacija.NazivOperacije = rdr.GetString(1);
                    operacija.OsnovnoVreme = rdr.GetInt32(2);
                    operacija.PomocnoVreme = rdr.GetInt32(3);
                    operacija.DodatnoVreme = rdr.GetInt32(4);
                    operacija.OznakaMasine = rdr.GetString(5);
                    operacijaList.Add(operacija);
                }
            }

            return operacijaList;
        }

        public bool DeleteFromOperacijaById(int iDOperacija)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_OPERACIJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDOperacija);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateOperacijaById(Operacija operacijaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_OPERACIJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, operacijaNew.IDOperacija);
                cmd.Parameters.AddWithValue("@NazivOperacije", NpgsqlDbType.Varchar, operacijaNew.NazivOperacije);
                cmd.Parameters.AddWithValue("@OsnovnoVreme", NpgsqlDbType.Integer, operacijaNew.OsnovnoVreme);
                cmd.Parameters.AddWithValue("@PomocnoVreme", NpgsqlDbType.Integer, operacijaNew.PomocnoVreme);
                cmd.Parameters.AddWithValue("@DodatnoVreme", NpgsqlDbType.Integer, operacijaNew.DodatnoVreme);
                cmd.Parameters.AddWithValue("@OznakaMasine", NpgsqlDbType.Varchar, operacijaNew.OznakaMasine);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreateOperacijaById(Operacija operacijaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_OPERACIJA, sqlConnection);

                cmd.Parameters.AddWithValue("@NazivOperacije", NpgsqlDbType.Varchar, operacijaNew.NazivOperacije);
                cmd.Parameters.AddWithValue("@OsnovnoVreme", NpgsqlDbType.Integer, operacijaNew.OsnovnoVreme);
                cmd.Parameters.AddWithValue("@PomocnoVreme", NpgsqlDbType.Integer, operacijaNew.PomocnoVreme);
                cmd.Parameters.AddWithValue("@DodatnoVreme", NpgsqlDbType.Integer, operacijaNew.DodatnoVreme);
                cmd.Parameters.AddWithValue("@OznakaMasine", NpgsqlDbType.Varchar, operacijaNew.OznakaMasine);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

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
    public class RadnoMestoSqlProvider : IRadnoMestoSqlProvider
    {
        #region Queries
        private const string GET_ALL_RECORDS_FROM_RADNO_MESTO =
            @"
                  SELECT * FROM radnomesto;
            ";

        private const string DELETE_FROM_RADNO_MESTO_BY_ID =
            @"
                  DELETE FROM radnomesto WHERE idradnomesto = @Id
            ";

        private const string UPDATE_RADNO_MESTO_BY_ID =
            @"
                  UPDATE radnomesto SET nazivradnomesto = @NazivRadnogMesta, strucnasprema = @StrucnaSprema
                  WHERE idradnomesto = @Id
            ";

        private const string CREATE_RADNO_MESTO =
            @"
                  INSERT INTO radnomesto VALUES (nextval('radnomestoseq'), @NazivRadnogMesta, @StrucnaSprema );
            ";


        #endregion

        public ObservableCollection<RadnoMesto> GetAllFromRadnoMesto()
        {
            ObservableCollection<RadnoMesto> radnoMestoList = new ObservableCollection<RadnoMesto>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNO_MESTO, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    RadnoMesto radnoMesto = new RadnoMesto();
                    radnoMesto.IDRadnoMesto = rdr.GetInt32(0);
                    radnoMesto.NazivRadnoMesto = rdr.GetString(1);
                    radnoMesto.StrucnaSprema = rdr.GetString(2);
                    radnoMestoList.Add(radnoMesto);
                }
            }

            return radnoMestoList;
        }

        public bool DeleteFromRadnoMestoById(int iDRadnoMesto)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_RADNO_MESTO_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDRadnoMesto);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateRadnoMestoById(RadnoMesto radnoMestoNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_RADNO_MESTO_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, radnoMestoNew.IDRadnoMesto);
                cmd.Parameters.AddWithValue("@NazivRadnogMesta", NpgsqlDbType.Varchar, radnoMestoNew.NazivRadnoMesto);
                cmd.Parameters.AddWithValue("@StrucnaSprema", NpgsqlDbType.Varchar, radnoMestoNew.StrucnaSprema);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreateRadnoMestoById(RadnoMesto radnoMestoNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_RADNO_MESTO, sqlConnection);

                cmd.Parameters.AddWithValue("@NazivRadnogMesta", NpgsqlDbType.Varchar, radnoMestoNew.NazivRadnoMesto);
                cmd.Parameters.AddWithValue("@StrucnaSprema", NpgsqlDbType.Varchar, radnoMestoNew.StrucnaSprema);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}
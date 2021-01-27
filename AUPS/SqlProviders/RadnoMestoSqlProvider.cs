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
    }
}
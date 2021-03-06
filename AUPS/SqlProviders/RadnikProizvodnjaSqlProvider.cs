﻿using AUPS.Models;
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
    public class RadnikProizvodnjaSqlProvider : IRadnikProizvodnjaSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_RADNIK_PROIZVODNJA =
            @"
                    SELECT rp.*, rm.nazivradnomesto 
                    FROM radnikproizvodnja rp
                    LEFT JOIN radnomesto rm
                    ON rp.idradnomesto = rm.idradnomesto
            ";

        private const string DELETE_FROM_RADNIK_PROIZVODNJA_BY_ID =
           @"
                  DELETE FROM radnikproizvodnja WHERE idradnik = @Id
            ";

        private const string UPDATE_RADNIK_PROIZVODNJA_BY_ID =
            @"
                  UPDATE radnikproizvodnja SET imeradnika = @ImeRadnika, prezimeradnika = @PrezimeRadnika, pol = @Pol, idradnomesto = @IDRadnoMesto
                  WHERE idradnik= @Id
            ";

        private const string CREATE_RADNIK_PROIZVODNJA =
            @"
                  INSERT INTO radnikproizvodnja VALUES (nextval('radnikSeq'), @ImeRadnika, @PrezimeRadnika, @Pol, @IDRadnoMesto);
            ";

        #endregion

        public ObservableCollection<RadnikProizvodnja> GetAllFromRadnikProizvodnja()
        {
            ObservableCollection<RadnikProizvodnja> radnikProizvodnjaList = new ObservableCollection<RadnikProizvodnja>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNIK_PROIZVODNJA, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    RadnikProizvodnja radnikProizvodnja = new RadnikProizvodnja();
                    radnikProizvodnja.IDRadnik = rdr.GetInt32(0);
                    radnikProizvodnja.ImeRadnika = rdr.GetString(1);
                    radnikProizvodnja.PrezimeRadnika = rdr.GetString(2);
                    radnikProizvodnja.Pol = rdr.GetString(3);
                    radnikProizvodnja.RadnoMesto = new RadnoMesto();
                    radnikProizvodnja.RadnoMesto.IDRadnoMesto = rdr.GetInt32(4);
                    radnikProizvodnja.RadnoMesto.NazivRadnoMesto = rdr.GetString(5);
                    radnikProizvodnjaList.Add(radnikProizvodnja);
                }
            }

            return radnikProizvodnjaList;
        }

        public bool DeleteFromRadnikProizvodnjaById(int iDRadnik)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_RADNIK_PROIZVODNJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDRadnik);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateRadnikProizvodnjaById(RadnikProizvodnja radnikProizvodnjaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_RADNIK_PROIZVODNJA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, radnikProizvodnjaNew.IDRadnik);
                cmd.Parameters.AddWithValue("@ImeRadnika", NpgsqlDbType.Varchar, radnikProizvodnjaNew.ImeRadnika);
                cmd.Parameters.AddWithValue("@PrezimeRadnika", NpgsqlDbType.Varchar, radnikProizvodnjaNew.PrezimeRadnika);
                cmd.Parameters.AddWithValue("@Pol", NpgsqlDbType.Varchar, radnikProizvodnjaNew.Pol);
                cmd.Parameters.AddWithValue("@IDRadnoMesto", NpgsqlDbType.Integer, radnikProizvodnjaNew.RadnoMesto.IDRadnoMesto);
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreateRadnikProizvodnjaById(RadnikProizvodnja radnikProizvodnjaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_RADNIK_PROIZVODNJA, sqlConnection);

                cmd.Parameters.AddWithValue("@ImeRadnika", NpgsqlDbType.Varchar, radnikProizvodnjaNew.ImeRadnika);
                cmd.Parameters.AddWithValue("@PrezimeRadnika", NpgsqlDbType.Varchar, radnikProizvodnjaNew.PrezimeRadnika);
                cmd.Parameters.AddWithValue("@Pol", NpgsqlDbType.Varchar, radnikProizvodnjaNew.Pol);
                cmd.Parameters.AddWithValue("@IDRadnoMesto", NpgsqlDbType.Integer, radnikProizvodnjaNew.RadnoMesto.IDRadnoMesto);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using Npgsql;
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
                  SELECT * FROM radnikproizvodnja;
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
                    radnikProizvodnja.IDRadnoMesto = rdr.GetInt32(4);
                    radnikProizvodnjaList.Add(radnikProizvodnja);
                }
            }

            return radnikProizvodnjaList;
        }

        public bool DeleteFromRadnikProizvodnjaById(int iDRadnik)
        {
            throw new NotImplementedException();
        }
    }
}

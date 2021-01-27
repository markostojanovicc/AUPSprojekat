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
    public class RadnaListaSqlProvider : IRadnaListaSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_RADNA_LISTA =
            @"
                  SELECT * FROM radnalista;
            ";
        #endregion

        public ObservableCollection<RadnaLista> GetAllFromRadnaLista()
        {

            ObservableCollection<RadnaLista> radnaListaList = new ObservableCollection<RadnaLista>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNA_LISTA, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    RadnaLista radnaLista = new RadnaLista();
                    radnaLista.IDRadnaLista = rdr.GetInt32(0);
                    radnaLista.Datum = rdr.GetDateTime(1);
                    radnaLista.Kolicina = rdr.GetInt32(2);
                    radnaLista.IDRadnik = rdr.GetInt32(3);
                    radnaLista.IDRadniNalog = rdr.GetInt32(4);
                    radnaLista.IDOperacija = rdr.GetInt32(5);
                    radnaListaList.Add(radnaLista);
                }
            }

            return radnaListaList;
        }
    }
}

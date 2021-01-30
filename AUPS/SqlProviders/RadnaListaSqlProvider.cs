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
    public class RadnaListaSqlProvider : IRadnaListaSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_RADNA_LISTA =
            @"
                  SELECT * FROM radnalista;
            ";

        private const string DELETE_FROM_RADNA_LISTA_BY_ID =
            @"
                  DELETE FROM radnalista WHERE idradnalista = @Id
            ";

        private const string UPDATE_RADNA_LISTA_BY_ID =
            @"
                  UPDATE radnalista SET datum = @Datum, kolicina = @Kolicina, idradnik = @IDRadnik, idradninalog = @IDRadniNalog, idoperacija = @IDOperacija
                  WHERE idradnalista = @Id
            ";

        private const string CREATE_RADNA_LISTA =
            @"
                  INSERT INTO radnalista VALUES (nextval('radnaListaSeq'), @Datum, @Kolicina, @IDRadnik, @IDRadniNalog, @IDOperacija);
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

        public bool DeleteFromRadnaListaById(int iDRadnaLista)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(DELETE_FROM_RADNA_LISTA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, iDRadnaLista);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool UpdateRadnaListaById(RadnaLista radnaListaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(UPDATE_RADNA_LISTA_BY_ID, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer, radnaListaNew.IDRadnaLista);
                cmd.Parameters.AddWithValue("@Datum", NpgsqlDbType.Varchar, radnaListaNew.Datum);
                cmd.Parameters.AddWithValue("@Kolicina", NpgsqlDbType.Varchar, radnaListaNew.Kolicina);
                cmd.Parameters.AddWithValue("@IDRadnik", NpgsqlDbType.Integer, radnaListaNew.IDRadnik);
                cmd.Parameters.AddWithValue("@IDRadniNalog", NpgsqlDbType.Varchar, radnaListaNew.IDRadniNalog);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Varchar, radnaListaNew.IDOperacija);
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }

        public bool CreateRadnaListaById(RadnaLista radnaListaNew)
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(CREATE_RADNA_LISTA, sqlConnection);

                cmd.Parameters.AddWithValue("@Datum", NpgsqlDbType.Varchar, radnaListaNew.Datum);
                cmd.Parameters.AddWithValue("@Kolicina", NpgsqlDbType.Varchar, radnaListaNew.Kolicina);
                cmd.Parameters.AddWithValue("@IDRadnik", NpgsqlDbType.Integer, radnaListaNew.IDRadnik);
                cmd.Parameters.AddWithValue("@IDRadniNalog", NpgsqlDbType.Varchar, radnaListaNew.IDRadniNalog);
                cmd.Parameters.AddWithValue("@IDOperacija", NpgsqlDbType.Varchar, radnaListaNew.IDOperacija);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected == 1;
            }
        }
    }
}

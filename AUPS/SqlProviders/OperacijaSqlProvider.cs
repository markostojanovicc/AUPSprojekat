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
    public class OperacijaSqlProvider : IOperacijaSqlProvider
    {
        #region Queries
        private const string GET_ALL_RECORDS_FROM_OPERACIJA =
            @"
                  SELECT * FROM operacija;
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
    }
}

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
    public class TehnoloskiPostupakSqlProvider : ITehnoloskiPostupakSqlProvider
    {
        #region Queries

        private const string GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK =
            @"
                  SELECT * FROM tehnoloskipostupak;
            ";

        
        #endregion

        public ObservableCollection<TehnoloskiPostupak> GetAllFromTehnoloskiPostupak() 
        {
            ObservableCollection<TehnoloskiPostupak> tehnoloskiPostupakList = new ObservableCollection<TehnoloskiPostupak>();

            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK, sqlConnection);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TehnoloskiPostupak tehnoloskiPostupak = new TehnoloskiPostupak();
                    tehnoloskiPostupak.IDTehPostupak = rdr.GetInt32(0);
                    tehnoloskiPostupak.TipTehPostupak = rdr.GetString(1);
                    tehnoloskiPostupak.VremeIzrade = rdr.GetInt32(2);
                    tehnoloskiPostupak.SerijaKom = rdr.GetInt32(3);
                    tehnoloskiPostupak.BrKomada = rdr.GetInt32(4);
                    tehnoloskiPostupak.IDOperacija = rdr.GetInt32(5);
                    tehnoloskiPostupakList.Add(tehnoloskiPostupak);
                }
            }

            return tehnoloskiPostupakList;

        }

        public bool DeleteFromTehnoloskiPostupakById(int iDTehPostupak)
        {
            throw new NotImplementedException();
        }
    }
}

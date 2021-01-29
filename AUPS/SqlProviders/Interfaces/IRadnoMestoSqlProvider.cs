using AUPS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders.Interfaces
{
    public interface IRadnoMestoSqlProvider
    {
        ObservableCollection<RadnoMesto> GetAllFromRadnoMesto();
        bool DeleteFromRadnoMestoById(int iDRadnoMesto);
        bool UpdateRadnoMestoById(RadnoMesto radnoMestoNew);
        bool CreateRadnoMestoById(RadnoMesto radnoMestoNew);
    }
}

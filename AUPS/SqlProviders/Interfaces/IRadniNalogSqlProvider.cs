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
    public interface IRadniNalogSqlProvider
    {
        ObservableCollection<RadniNalog> GetAllFromRadniNalog();
        bool DeleteFromRadniNalogById(int iDRadniNalog);

        bool UpdateRadniNalogById(RadniNalog radniNalog);
    }
}

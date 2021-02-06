using AUPS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders.Interfaces
{
    interface ITehnPostupakOperacijaSqlProvider
    {
        ObservableCollection<TehnPostupakOperacija> GetAllFromTehnPostupakOperacija();
        bool DeleteFromTehnPostupakOperacijaById(int iDTehnPostupakOperacija);

        bool UpdateTehnPostupakOperacijaById(TehnPostupakOperacija tehnPostupakOperacija);

        bool CreateTehnPostupakOperacijaById(TehnPostupakOperacija tehnPostupakOperacijaNew);
    }
}

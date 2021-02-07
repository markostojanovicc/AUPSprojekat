using AUPS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders.Interfaces
{
    public interface ITehnPostupakOperacijaSqlProvider
    {
        ObservableCollection<TehnPostupakOperacija> GetAllFromTehnPostupakOperacija();

        bool DeleteFromTehnPostupakOperacijaById(int iDTehnPostupakOperacija);

        bool UpdateTehnPostupakOperacija(TehnPostupakOperacija tehnPostupakOperacija);

        bool UpdateRBrOperacijaFromTehnPostupakOperacija(TehnPostupakOperacija tehnPostupakOperacija);

        bool CreateTehnPostupakOperacijaById(TehnPostupakOperacija tehnPostupakOperacijaNew);
    }
}

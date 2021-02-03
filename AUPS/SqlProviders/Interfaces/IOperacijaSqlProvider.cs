using AUPS.Models;
using System.Collections.ObjectModel;
using System.Data;

namespace AUPS.SqlProviders.Interfaces
{
    public interface IOperacijaSqlProvider
    {
        ObservableCollection<Operacija> GetAllFromOperacija();
        bool DeleteFromOperacijaById(int iDOperacija);

        bool UpdateOperacijaById(Operacija operacija);

        bool CreateOperacijaById(Operacija operacijaNew);
    }
}

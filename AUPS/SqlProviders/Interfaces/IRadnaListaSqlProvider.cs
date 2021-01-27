using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders.Interfaces
{
    public interface IRadnaListaSqlProvider
    {
        void GetAllFromRadnaLista(ref DataTable dataTable);
        bool DeleteFromRadnaListaById(int iDRadnaLista);
    }
}

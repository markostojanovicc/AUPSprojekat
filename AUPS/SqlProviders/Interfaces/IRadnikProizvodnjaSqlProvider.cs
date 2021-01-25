using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders.Interfaces
{
    public interface IRadnikProizvodnjaSqlProvider
    {
        void GetAllFromRadnikProizvodnja(ref DataTable dataTable);
    }
}

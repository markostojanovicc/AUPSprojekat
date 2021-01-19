using System.Data;

namespace AUPS.SqlProviders.Interfaces
{
    public interface IOperacijaSqlProvider
    {
        void GetAllFromOperacija(ref DataTable dataTable);
    }
}

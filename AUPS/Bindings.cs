using Ninject.Modules;
using System.Data.SqlClient;

namespace AUPS
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<SqlConnection>().ToSelf().InSingletonScope();
        }
    }
}

using AUPS.SqlProviders;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AUPS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ShowAppWindow();
        }

        private void ShowAppWindow()
        {
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Current.MainWindow = this.container.Get<ApplicationMainWindow>();
            Current.MainWindow.ResizeMode = ResizeMode.NoResize;
            (Current.MainWindow.DataContext as ApplictionMainWindowViewModel).Init();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();

            container.Bind<IRadnoMestoSqlProvider>().To<RadnoMestoSqlProvider>();
            container.Bind<IOperacijaSqlProvider>().To<OperacijaSqlProvider>();
            container.Bind<IPredmetRadaSqlProvider>().To<PredmetRadaSqlProvider>();
            container.Bind<IRadnaListaSqlProvider>().To<RadnaListaSqlProvider>();
            container.Bind<IRadnikProizvodnjaSqlProvider>().To<RadnikProizvodnjaSqlProvider>();
            container.Bind<IRadniNalogSqlProvider>().To<RadniNalogSqlProvider>();
            container.Bind<ITehnoloskiPostupakSqlProvider>().To<TehnoloskiPostupakSqlProvider>();
            container.Bind<ITrebovanjeSqlProvider>().To<TrebovanjeSqlProvider>();
            container.Bind<IUserSqlProvider>().To<UserSqlProvider>();

        }
    }
}

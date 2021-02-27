using AUPS.SqlProviders;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WPFLocalizeExtension.Engine;
using Application = System.Windows.Application;

namespace AUPS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        public App()
        {
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = new CultureInfo("fr-FR");
        }

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

            Screen notPrimaryScreen = Screen.AllScreens.Where(x => !x.Primary).FirstOrDefault();
            if (notPrimaryScreen != null)
            {
                SecondaryWindow secondaryWindow = new SecondaryWindow();
                secondaryWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                secondaryWindow.WindowState = WindowState.Normal;
                secondaryWindow.Left = notPrimaryScreen.WorkingArea.Left;
                secondaryWindow.Top = notPrimaryScreen.WorkingArea.Top;
                secondaryWindow.Width = notPrimaryScreen.WorkingArea.Width;
                secondaryWindow.Height = notPrimaryScreen.WorkingArea.Height;
                secondaryWindow.Show();
                secondaryWindow.WindowState = WindowState.Maximized;
            }

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
            container.Bind<ITehnPostupakOperacijaSqlProvider>().To<TehnPostupakOperacijaSqlProvider>();


        }
    }
}

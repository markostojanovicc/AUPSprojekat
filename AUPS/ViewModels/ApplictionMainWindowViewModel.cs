using AUPS.Event;
using AUPS.SqlProviders;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.MainContentViewModels;
using ChatApp;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace AUPS.ViewModels
{
    public class ApplictionMainWindowViewModel : BaseViewModel
    {
        private object _contentMainScreen;
        private IUserSqlProvider _userSqlProvider;
        private readonly RadnoMestoViewModel radnoMestoViewModel;
        private readonly OperacijaViewModel operacijaViewModel;
        private readonly PredmetRadaViewModel predmetRadaViewModel;
        private readonly RadnaListaViewModel radnaListaViewModel;
        private readonly RadnikProizvodnjaViewModel radnikProizvodnjaViewModel;
        private readonly RadniNalogViewModel radniNalogViewModel;
        private readonly TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel;
        private readonly TrebovanjeViewModel trebovanjeViewModel;
        private readonly TehnPostupakOperacijaViewModel tehnPostupakOperacijaViewModel;
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;
        private IOperacijaSqlProvider _operacijaSqlProvider;
        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;
        private IRadnaListaSqlProvider _radnaListaSqlProvider;
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;
        private ITrebovanjeSqlProvider _trebovanjeSqlProvider;
        private readonly ITehnPostupakOperacijaSqlProvider tehnPostupakOperacijaSqlProvider;

        public Object ContentMainScreen
        {
            get
            {
                return _contentMainScreen;
            }
            set
            {
                _contentMainScreen = value;
                OnPropertyChanged(nameof(ContentMainScreen));
            }
        }

        public ApplictionMainWindowViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider, IOperacijaSqlProvider operacijaSqlProvider
                                    , IPredmetRadaSqlProvider predmetRadaSqlProvider, IRadnaListaSqlProvider radnaListaSqlProvider
                                    , IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, IRadniNalogSqlProvider radniNalogSqlProvider
                                    , ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ITrebovanjeSqlProvider trebovanjeSqlProvider,
                                    ITehnPostupakOperacijaSqlProvider tehnPostupakOperacijaSqlProvider
                                    , IUserSqlProvider userSqlProvider, RadnoMestoViewModel radnoMestoViewModel, OperacijaViewModel operacijaViewModel, PredmetRadaViewModel predmetRadaViewModel,
                                    RadnaListaViewModel radnaListaViewModel, RadnikProizvodnjaViewModel radnikProizvodnjaViewModel, RadniNalogViewModel radniNalogViewModel,
                                    TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel, TrebovanjeViewModel trebovanjeViewModel,
                                    TehnPostupakOperacijaViewModel tehnPostupakOperacijaViewModel)
        {
            _userSqlProvider = userSqlProvider;
            this.radnoMestoViewModel = radnoMestoViewModel;
            this.operacijaViewModel = operacijaViewModel;
            this.predmetRadaViewModel = predmetRadaViewModel;
            this.radnaListaViewModel = radnaListaViewModel;
            this.radnikProizvodnjaViewModel = radnikProizvodnjaViewModel;
            this.radniNalogViewModel = radniNalogViewModel;
            this.tehnoloskiPostupakViewModel = tehnoloskiPostupakViewModel;
            this.trebovanjeViewModel = trebovanjeViewModel;
            this.tehnPostupakOperacijaViewModel = tehnPostupakOperacijaViewModel;
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            _operacijaSqlProvider = operacijaSqlProvider;
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            _radniNalogSqlProvider = radniNalogSqlProvider;
            _radnaListaSqlProvider = radnaListaSqlProvider;
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
            this.tehnPostupakOperacijaSqlProvider = tehnPostupakOperacijaSqlProvider;
                     
            
        }

        public void Init()
        {
            LogInViewModel logInViewModel = new LogInViewModel(_userSqlProvider);
            logInViewModel.LogInSucceded += LogInViewModel_LogInSucceded;
            ContentMainScreen = logInViewModel;
        }

        private void LogInViewModel_LogInSucceded(object source, UserEventArgs args)
        {
            App.Current.MainWindow.WindowState = WindowState.Maximized;
            ContentMainScreen = new MainContentViewModel(_radnoMestoSqlProvider, _operacijaSqlProvider, _predmetRadaSqlProvider,
                _radnaListaSqlProvider, _radnikProizvodnjaSqlProvider, _radniNalogSqlProvider, _tehnoloskiPostupakSqlProvider
                , _trebovanjeSqlProvider, radnoMestoViewModel, operacijaViewModel, predmetRadaViewModel, radnaListaViewModel
                , radnikProizvodnjaViewModel, radniNalogViewModel, tehnoloskiPostupakViewModel,
                trebovanjeViewModel, tehnPostupakOperacijaViewModel, tehnPostupakOperacijaSqlProvider, args.loggedUser);
        }
    }
}

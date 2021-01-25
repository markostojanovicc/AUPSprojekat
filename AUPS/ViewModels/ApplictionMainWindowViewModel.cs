using AUPS.SqlProviders;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AUPS.ViewModels
{
    public class ApplictionMainWindowViewModel : BaseViewModel
    {
        private object _contentMainScreen;
        private IUserSqlProvider _userSqlProvider;
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;
        private IOperacijaSqlProvider _operacijaSqlProvider;
        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;
        private IRadnaListaSqlProvider _radnaListaSqlProvider;
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;
        private ITrebovanjeSqlProvider _trebovanjeSqlProvider;

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
                                    , ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ITrebovanjeSqlProvider trebovanjeSqlProvider
                                    , IUserSqlProvider userSqlProvider)
        {
            _userSqlProvider = userSqlProvider;
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            _operacijaSqlProvider = operacijaSqlProvider;
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            _radniNalogSqlProvider = radniNalogSqlProvider;
            _radnaListaSqlProvider = radnaListaSqlProvider;
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
        }

        public void Init()
        {
            LogInViewModel logInViewModel = new LogInViewModel(_userSqlProvider);
            logInViewModel.LogInSucceded += LogInViewModel_LogInSucceded;
            ContentMainScreen = logInViewModel;
        }

        private void LogInViewModel_LogInSucceded(object source, EventArgs args)
        {
            ContentMainScreen = new MainContentViewModel(_radnoMestoSqlProvider, _operacijaSqlProvider, _predmetRadaSqlProvider,
                _radnaListaSqlProvider, _radnikProizvodnjaSqlProvider, _radniNalogSqlProvider, _tehnoloskiPostupakSqlProvider,
                _trebovanjeSqlProvider);
        }
    }
}

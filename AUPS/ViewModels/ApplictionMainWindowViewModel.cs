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

        public ApplictionMainWindowViewModel(IUserSqlProvider userSqlProvider, IRadnoMestoSqlProvider radnoMestoSqlProvider)
        {
            _userSqlProvider = userSqlProvider;
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
        }

        public void Init()
        {
            LogInViewModel logInViewModel = new LogInViewModel(_userSqlProvider);
            logInViewModel.LogInSucceded += LogInViewModel_LogInSucceded;
            ContentMainScreen = logInViewModel;
        }

        private void LogInViewModel_LogInSucceded(object source, EventArgs args)
        {
            ContentMainScreen = new RadnoMestoViewModel(_radnoMestoSqlProvider);
        }
    }
}

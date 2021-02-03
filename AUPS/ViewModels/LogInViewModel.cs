using AUPS.Commands;
using AUPS.Helpers;
using AUPS.Models;
using AUPS.SqlProviders;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AUPS.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        private ICommand loginButtonCommand;
        private ICommand registrationButtonCommand;
        private IUserSqlProvider _userSqlProvider;
        private bool _dialogResult;
        private string _email;
        private string _password;

        public delegate void LogInSuccededEventHandler(object source, EventArgs args);
        public event LogInSuccededEventHandler LogInSucceded; 

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string Password
        {
            get
            {
                return _password;
            } set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public bool CanLogIn
        {
            get
            {
                return !(string.IsNullOrEmpty(Password)||string.IsNullOrEmpty(Email));
            }
        }

        public bool DialogResult
        {
            get
            {
                return _dialogResult;
            }
            set
            {
                if (_dialogResult != value)
                {
                    _dialogResult = value;
                    OnPropertyChanged(nameof(DialogResult));
                }
            }
        }

        public bool ShowPasswordTextBlock
        {
            get
            {
                return string.IsNullOrEmpty(Password);
            }
        }

        public ICommand LogInButtonCommand
        {
            get
            {
                if (loginButtonCommand == null)
                {
                    this.loginButtonCommand = new RelayCommand(
                        param => LoginButtonCommandExecute(param));                        
                }

                return loginButtonCommand;
            }
        }

        public ICommand RegistrationButtonCommand
        {
            get
            {
                if (registrationButtonCommand == null)
                {
                    this.registrationButtonCommand = new RelayCommand(
                        param => RegistrationButtonCommandExecute(param));
                }

                return registrationButtonCommand;
            }
        }

        public LogInViewModel(IUserSqlProvider userSqlProvider)
        {
            _userSqlProvider = userSqlProvider;
        }

        private void RegistrationButtonCommandExecute(object param)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(_userSqlProvider);
            registrationWindow.ShowDialog();
        }

        private bool CanExecuteLoginButtonCommand()
        {
            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoginButtonCommandExecute(object param)
        {
            User user =_userSqlProvider.FindUserByEmailAndPassword(Email, Password);

            if(user != null)
            {
                DialogResult = true;
                OnLogInSucceded();
            }
            else
            {
                //AlertHelper.ShowErrorDialog("InvalidUserData", false, false, "LoginError");
                Email = string.Empty;
                Password = string.Empty;
            }
        }

        protected virtual void OnLogInSucceded()
        {
            if (LogInSucceded != null)
                LogInSucceded(this, EventArgs.Empty);
        }
    }
}

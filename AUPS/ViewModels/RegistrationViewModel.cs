using AUPS.Commands;
using AUPS.Dialogs.ErrorDialogs;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using ChatApp;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AUPS.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        #region private
        private string _email;
        private string _password;
        private string _name;
        private string _lastName;
        private string _username;
        private string _filePath;
        private ICommand submitButtonCommand;
        private ICommand selectFileCommand;
        IUserSqlProvider _userSqlProvider;
        #endregion

        #region public
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }
        public string UserName { get { return _username; } set { _username = value; OnPropertyChanged(nameof(UserName)); } }
        #endregion

        public bool CanSubmit
        {
            get
            {
                return (!string.IsNullOrEmpty(_email) && !string.IsNullOrEmpty(_password) && !string.IsNullOrEmpty(_name)
                    && !string.IsNullOrEmpty(_lastName) && !string.IsNullOrEmpty(_username));
            }
        }

        public bool ShowPasswordTextBlock
        {
            get
            {
                return string.IsNullOrEmpty(Password);
            }
        }

        public ICommand SubmitButtonCommand
        {
            get
            {
                if (submitButtonCommand == null)
                {
                    this.submitButtonCommand = new RelayCommand(
                        param => SubmitButtonCommandExecute(param));
                }

                return submitButtonCommand;
            }
        }

        public ICommand SelectFileCmd
        {
            get
            {
                if (selectFileCommand == null)
                {
                    this.selectFileCommand = new RelayCommand(
                        param => SelectFileCommandExecute(param));
                }

                return selectFileCommand;
            }
        }

        private void SelectFileCommandExecute(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? response = openFileDialog.ShowDialog();
            if(response == true)
            {
                _filePath = openFileDialog.FileName;
            }
        }

        private void SubmitButtonCommandExecute(object param)
        {
            if (!Email.Contains("@"))
                ShowErrorDialog("Email mora sadržati @ simbol. Pokušajte ponovo");
            else if (Password.Length < 8)
                ShowErrorDialog("Lozinka mora imati najmanje 6 karaktera. Pokušajte ponovo");
            else
            {
                bool userExists = _userSqlProvider.FindIfUserExistsByEmail(_email);

                if (!userExists)
                {
                    User newUser = new User
                    {
                        Ime = _name,
                        Prezime = _lastName,
                        Email = _email,
                        Password = _password,
                        Username = _username,
                        ImagePath = _filePath
                    };

                    bool isUserCreated = _userSqlProvider.CreateUser(newUser);

                    if (isUserCreated)
                    {
                        Window curWindow = (Window)param;
                        curWindow.Close();
                    }
                    else
                    {
                        ShowErrorDialog("Nalog nije napravljen. Pokušajte ponovo");
                    }
                }
                else
                    ShowErrorDialog("Korisnik sa datim email-om već postoji, Pokušajte ponovo");
            }
        }

        public RegistrationViewModel(IUserSqlProvider userSqlProvider)
        {
            _userSqlProvider = userSqlProvider;
        }
        private void ShowErrorDialog(string message)
        {
            ErrorDialog errorDialog = new ErrorDialog();
            ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
            errorDialog.Title = "Greška";
            errorDialogViewModel.ErrorMessage = message;
            errorDialog.ShowDialog();
            Email = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            UserName = string.Empty;
        }
    }
}

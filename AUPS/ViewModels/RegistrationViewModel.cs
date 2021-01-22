﻿using AUPS.Commands;
using AUPS.Models;
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
    public class RegistrationViewModel : BaseViewModel
    {
        #region private
        private string _email;
        private string _password;
        private string _name;
        private string _lastName;
        private string _username;
        private ICommand submitButtonCommand;
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

        private void SubmitButtonCommandExecute(object param)
        {
            User newUser = new User
            {
                Ime = _name,
                Prezime = _lastName,
                Email = _email,
                Password = _password,
                Username = _username
            };

            bool isUserCreated = _userSqlProvider.CreateUser(newUser);

            if (isUserCreated)
            {
                
            }
            else
            {
                
            }
        }

        public RegistrationViewModel(IUserSqlProvider userSqlProvider)
        {
            _userSqlProvider = userSqlProvider;
        }
    }
}

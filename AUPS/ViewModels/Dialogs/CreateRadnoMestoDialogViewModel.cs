using AUPS.Commands;
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

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadnoMestoDialogViewModel : BaseViewModel
    {
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;
        private readonly MainContentViewModel mainContentViewModel;
        private string _title = "Dijalog za kreiranje radnog mesta";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _nazivRadnogMesta;
        private string _strucnaSprema;
        private int _idRadnogMesta;
        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(NazivRadnogMesta) || string.IsNullOrEmpty(StrucnaSprema));
            }
        }
        public int IdRadnogMesta
        {
            get { return _idRadnogMesta; }
            set { _idRadnogMesta = value; }
        }


        public string StrucnaSprema
        {
            get { return _strucnaSprema; }
            set { _strucnaSprema = value; }
        }


        public string NazivRadnogMesta
        {
            get { return _nazivRadnogMesta; }
            set { _nazivRadnogMesta = value; }
        }     

        public bool IsUpdateBtnVisible
        {
            get { return _isUpdateBtnVisible; }
            set 
            { 
                _isUpdateBtnVisible = value;
                OnPropertyChanged(nameof(IsUpdateBtnVisible));
            }
        }

        public bool IsCreateBtnVisible
        {
            get { return _isCreateBtnVisible; }
            set 
            { 
                _isCreateBtnVisible = value;
                OnPropertyChanged(nameof(IsCreateBtnVisible));
            }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public CreateRadnoMestoDialogViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider,
            MainContentViewModel mainContentViewModel)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            this.mainContentViewModel = mainContentViewModel;
        }

        public CreateRadnoMestoDialogViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider, RadnoMesto radnoMesto,
            MainContentViewModel mainContentViewModel)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            _idRadnogMesta = radnoMesto.IDRadnoMesto;
            _nazivRadnogMesta = radnoMesto.NazivRadnoMesto;
            _strucnaSprema = radnoMesto.StrucnaSprema;
            this.mainContentViewModel = mainContentViewModel;
        }

        public ICommand AddButtonCommand
        {
            get
            {
                if (_createButtonCommand == null)
                {
                    this._createButtonCommand = new RelayCommand(
                        param => CreateButtonCommandExecute(param));
                }

                return _createButtonCommand;
            }
        }

        public ICommand UpdateButtonCommand
        {
            get
            {
                if (_updateButtonCommand == null)
                {
                    this._updateButtonCommand = new RelayCommand(
                        param => UpdateButtonCommandExecute(param));
                }

                return _updateButtonCommand;
            }
        }

        private void UpdateButtonCommandExecute(object param)
        {
            RadnoMesto radnoMesto = new RadnoMesto
            {
                IDRadnoMesto = _idRadnogMesta,
                NazivRadnoMesto = _nazivRadnogMesta,
                StrucnaSprema = _strucnaSprema
            };
            bool isUpdated = _radnoMestoSqlProvider.UpdateRadnoMestoById(radnoMesto);
            if (isUpdated)
            {
                Window curWindow = (Window)param;
                curWindow.Close();
                mainContentViewModel.RefreshData();
            }
            else
            {

            }
        }

        private void CreateButtonCommandExecute(object param)
        {
            RadnoMesto radnoMesto = new RadnoMesto
            {
                NazivRadnoMesto = _nazivRadnogMesta,
                StrucnaSprema = _strucnaSprema
            };
            bool isCreated = _radnoMestoSqlProvider.CreateRadnoMestoById(radnoMesto);
            if (isCreated)
            {
                Window curWindow = (Window)param;
                curWindow.Close();
                mainContentViewModel.RefreshData();
            }
            else
            {

            }
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radnog mesta";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

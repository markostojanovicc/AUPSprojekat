﻿using AUPS.Commands;
using AUPS.Dialogs.ErrorDialogs;
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
    public class CreatePredmetRadaDialogViewModel : BaseViewModel
    {
        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;
        private readonly MainContentViewModel mainContentViewModel;
        private string _title = "Dijalog za kreiranje predmeta rada";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _tipPredmetaRada;
        private string _nazivPR;
        private string _jedMere;
        private string _cena;
        private int _idPredmetaRada;
        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;

        public int IdPredmetaRada
        {
            get { return _idPredmetaRada; }
            set { _idPredmetaRada = value; }
        }


        public string Cena
        {
            get { return _cena; }
            set { _cena = value; }
        }


        public string JedMere
        {
            get { return _jedMere; }
            set { _jedMere = value; }
        }


        public string NazivPR
        {
            get { return _nazivPR; }
            set { _nazivPR = value; }
        }


        public string TipPredmetaRada
        {
            get { return _tipPredmetaRada; }
            set { _tipPredmetaRada = value; }
        }


        public bool IsUpdateBtnVisible
        {
            get { return _isUpdateBtnVisible; }
            set { _isUpdateBtnVisible = value; }
        }

        public bool IsCreateBtnVisible
        {
            get { return _isCreateBtnVisible; }
            set { _isCreateBtnVisible = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public CreatePredmetRadaDialogViewModel(IPredmetRadaSqlProvider predmetRadaSqlProvider,
            MainContentViewModel mainContentViewModel)
        {
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
            this.mainContentViewModel = mainContentViewModel;
        }

        public CreatePredmetRadaDialogViewModel(IPredmetRadaSqlProvider predmetRadaSqlProvider, PredmetRada predmetRada,
            MainContentViewModel mainContentViewModel)
        {
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
            IdPredmetaRada = predmetRada.IDPredmetRada;
            TipPredmetaRada = predmetRada.TipPredmetRada;
            NazivPR = predmetRada.NazivPR;
            JedMere = predmetRada.JedMerePR;
            Cena = predmetRada.Cena.ToString();
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

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(TipPredmetaRada) || string.IsNullOrEmpty(NazivPR) || string.IsNullOrEmpty(JedMere)
                     || string.IsNullOrEmpty(Cena));
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
            PredmetRada predmetRada = new PredmetRada
            {
                IDPredmetRada = IdPredmetaRada,
                Cena = Int32.Parse(_cena),
                JedMerePR = _jedMere,
                NazivPR = _nazivPR,
                TipPredmetRada = _tipPredmetaRada
            };
            bool isUpdated = _predmetRadaSqlProvider.UpdatePredmetRadaById(predmetRada);
            if (isUpdated)
            {
                Window curWindow = (Window)param;
                curWindow.Close();
                mainContentViewModel.RefreshData();
            }
            else
            {
                ErrorDialog errorDialog = new ErrorDialog();
                ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
                errorDialog.Title = "Greška";
                errorDialogViewModel.ErrorMessage = "Došlo je do greške. Pokušajte ponovo";
                errorDialog.ShowDialog();
            }
        }

        private void CreateButtonCommandExecute(object param)
        {
            PredmetRada udpatedPredmetRada = new PredmetRada
            {
                Cena = Int32.Parse(_cena),
                JedMerePR = _jedMere,
                NazivPR = _nazivPR,
                TipPredmetRada = _tipPredmetaRada
            };
            bool isCreated = _predmetRadaSqlProvider.CreatePredmetRadaById(udpatedPredmetRada);
            if (isCreated)
            {
                Window curWindow = (Window)param;
                curWindow.Close();
                mainContentViewModel.RefreshData();
            }
            else
            {
                ErrorDialog errorDialog = new ErrorDialog();
                ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
                errorDialog.Title = "Greška";
                errorDialogViewModel.ErrorMessage = "Došlo je do greške. Pokušajte ponovo";
                errorDialog.ShowDialog();
            }

        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu predmeta rada";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

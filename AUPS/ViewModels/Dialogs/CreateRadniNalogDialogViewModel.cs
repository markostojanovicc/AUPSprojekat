using AUPS.Commands;
using AUPS.Dialogs.ErrorDialogs;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadniNalogDialogViewModel : BaseViewModel
    {
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        private readonly MainContentViewModel mainContentViewModel;
        private string _title = "Dijalog za kreiranje radnog naloga";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private DateTime _datumIzlaza = DateTime.UtcNow;
        private DateTime _datumUlaza = DateTime.UtcNow;
        private string _kolicinaProizvoda;
        private int _idPredmetaRada;
        private int _idRadniNalog;
        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;
        private ObservableCollection<PredmetRada> _predmetRadaList;
        private int _selectedIndexPredmetRada;

        public int SelectedIndexPredmetRada
        {
            get { return _selectedIndexPredmetRada; }
            set { _selectedIndexPredmetRada = value; }
        }

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(KolicinaProizvoda));
            }
        }

        public List<string> NaziviPredmetaRada 
        {
            get { return PredmetRadaList.Select(x => x.NazivPR).ToList(); }
        }


        public ObservableCollection<PredmetRada> PredmetRadaList
        {
            get { return _predmetRadaList; }
            set { _predmetRadaList = value; }
        }


        public int IdRadniNalog
        {
            get { return _idRadniNalog; }
            set { _idRadniNalog = value; }
        }


        public int IdPredmetaRada
        {
            get { return _idPredmetaRada; }
            set { _idPredmetaRada = value; }
        }

        public string KolicinaProizvoda
        {
            get { return _kolicinaProizvoda; }
            set { _kolicinaProizvoda = value; }
        }


        public DateTime DatumUlaza
        {
            get { return _datumUlaza; }
            set { _datumUlaza = value; }
        }


        public DateTime DatumIzlaza
        {
            get { return _datumIzlaza; }
            set { _datumIzlaza = value; }
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


        public CreateRadniNalogDialogViewModel(IRadniNalogSqlProvider radniNalogSqlProvider, ObservableCollection<PredmetRada> predmetRadaList,
            MainContentViewModel mainContentViewModel)
        {
            _radniNalogSqlProvider = radniNalogSqlProvider;
            PredmetRadaList = predmetRadaList;
            this.mainContentViewModel = mainContentViewModel;
            _selectedIndexPredmetRada = 0;
        }

        public CreateRadniNalogDialogViewModel(IRadniNalogSqlProvider radniNalogSqlProvider, ObservableCollection<PredmetRada> predmetRadaList, RadniNalog radniNalog,
            MainContentViewModel mainContentViewModel)
        {
            _radniNalogSqlProvider = radniNalogSqlProvider;
            IdRadniNalog = radniNalog.IDRadniNalog;
            DatumUlaza = radniNalog.DatumUlaz;
            DatumIzlaza = radniNalog.DatumIzlaz;
            KolicinaProizvoda = radniNalog.KolicinaProizvoda.ToString();
            IdPredmetaRada = radniNalog.PredmetRada.IDPredmetRada;
            PredmetRadaList = predmetRadaList;
            _selectedIndexPredmetRada = PredmetRadaList.IndexOf(predmetRadaList.FirstOrDefault(x => x.IDPredmetRada == radniNalog.PredmetRada.IDPredmetRada));
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
            if (_datumIzlaza >= _datumUlaza)
            {
                RadniNalog radniNalog = new RadniNalog
                {
                    IDRadniNalog = _idRadniNalog,
                    DatumIzlaz = _datumIzlaza,
                    DatumUlaz = _datumUlaza,
                    KolicinaProizvoda = Int32.Parse(_kolicinaProizvoda),
                    PredmetRada = PredmetRadaList[SelectedIndexPredmetRada]
                };
                bool isCreated = _radniNalogSqlProvider.UpdateRadniNalogById(radniNalog);
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
            else
            {
                ErrorDialog errorDialog = new ErrorDialog();
                ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
                errorDialog.Title = "Greška";
                errorDialogViewModel.ErrorMessage = "Datum izlaza je manji od datuma ulaza. Pokušajte ponovo.";
                errorDialog.ShowDialog();
            }            
        }

        private void CreateButtonCommandExecute(object param)
        {
            if (_datumIzlaza >= _datumUlaza)
            {
                RadniNalog radniNalog = new RadniNalog
                {
                    DatumIzlaz = _datumIzlaza,
                    DatumUlaz = _datumUlaza,
                    KolicinaProizvoda = Int32.Parse(_kolicinaProizvoda),
                    PredmetRada = PredmetRadaList[SelectedIndexPredmetRada]
                };
                _radniNalogSqlProvider.CreateRadniNalogById(radniNalog);
                Window curWindow = (Window)param;
                curWindow.Close();
                mainContentViewModel.RefreshData();
            }            
            else
            {
                ErrorDialog errorDialog = new ErrorDialog();
                ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
                errorDialog.Title = "Greška";
                errorDialogViewModel.ErrorMessage = "Datum izlaza je manji od datuma ulaza. Pokušajte ponovo.";
                errorDialog.ShowDialog();
            }
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radni nalog";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

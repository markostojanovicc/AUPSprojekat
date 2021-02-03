using AUPS.Commands;
using AUPS.Dialogs.ErrorDialogs;
using AUPS.Enums;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadnikProizvodnjaDialogViewModel : BaseViewModel
    {
        private List<Pol> _polovi = new List<Pol>() { Pol.muški, Pol.ženski };
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;
        private readonly MainContentViewModel mainContentViewModel;
        private string _title = "Dijalog za kreiranje radnika";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _imeRadnika;
        private string _prezimeRadnika;
        private string _idRadnoMesto;
        private int _idRadnika;
        private int _selectedIndexRadnoMesto;
        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;
        private ObservableCollection<RadnoMesto> _radnoMestoList;

        public List<string> NaziviRadnihMesta
        {
            get { return _radnoMestoList.Select(x => x.NazivRadnoMesto).ToList(); }
        }

        public int SelectedIndexRadnoMesto
        {
            get { return _selectedIndexRadnoMesto; }
            set { _selectedIndexRadnoMesto = value; }
        }

        public int IdRadnika
        {
            get { return _idRadnika; }
            set { _idRadnika = value; }
        }


        public string IdRadnoMesto
        {
            get { return _idRadnoMesto; }
            set { _idRadnoMesto = value; }
        }

        private ObservableCollection<RadnoMesto> RadnoMestoList
        {
            get { return _radnoMestoList; }
            set { _radnoMestoList = value; }
        }

        public string PrezimeRadnika
        {
            get { return _prezimeRadnika; }
            set { _prezimeRadnika = value; }
        }

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(ImeRadnika) || string.IsNullOrEmpty(PrezimeRadnika));
            }
        }


        public string ImeRadnika
        {
            get { return _imeRadnika; }
            set { _imeRadnika = value; }
        }


        public List<Pol> Polovi
        {
            get { return _polovi; }
            set { }
        }

        private Pol _selectedType;

        public Pol SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(Polovi));
            }
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


        public CreateRadnikProizvodnjaDialogViewModel(IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, ObservableCollection<RadnoMesto> radnoMestoList,
            MainContentViewModel mainContentViewModel)
        {
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            RadnoMestoList = radnoMestoList;
            SelectedIndexRadnoMesto = 0;
            mainContentViewModel.RefreshData();
        }

        public CreateRadnikProizvodnjaDialogViewModel(IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, ObservableCollection<RadnoMesto> radnoMestoList, RadnikProizvodnja radnikProizvodnja,
            MainContentViewModel mainContentViewModel)
        {
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            IdRadnika = radnikProizvodnja.IDRadnik;
            ImeRadnika = radnikProizvodnja.ImeRadnika;
            PrezimeRadnika = radnikProizvodnja.PrezimeRadnika;
            Enum.TryParse(radnikProizvodnja.Pol, out Pol pol);
            SelectedType = pol;
            IdRadnoMesto = radnikProizvodnja.RadnoMesto.IDRadnoMesto.ToString();
            RadnoMestoList = radnoMestoList;
            this.mainContentViewModel = mainContentViewModel;
            SelectedIndexRadnoMesto = radnoMestoList.IndexOf(radnoMestoList.First(x => x.IDRadnoMesto == radnikProizvodnja.RadnoMesto.IDRadnoMesto));
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
            RadnikProizvodnja radnikProizvodnja = new RadnikProizvodnja
            {
                IDRadnik = _idRadnika,
                ImeRadnika = _imeRadnika,
                PrezimeRadnika = _prezimeRadnika,
                Pol = SelectedType.ToString(),
                RadnoMesto = RadnoMestoList[SelectedIndexRadnoMesto]
            };
            bool isUpdated = _radnikProizvodnjaSqlProvider.UpdateRadnikProizvodnjaById(radnikProizvodnja);
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
            RadnikProizvodnja radnikProizvodnja = new RadnikProizvodnja
            {
                ImeRadnika = _imeRadnika,
                PrezimeRadnika = _prezimeRadnika,
                Pol = SelectedType.ToString(),
                RadnoMesto = RadnoMestoList[SelectedIndexRadnoMesto]
            };
            bool isCreated = _radnikProizvodnjaSqlProvider.CreateRadnikProizvodnjaById(radnikProizvodnja);
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
            Title = "Dijalog za izmenu radnika";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }

    }
}

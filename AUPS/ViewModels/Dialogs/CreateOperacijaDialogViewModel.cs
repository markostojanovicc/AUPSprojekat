using AUPS.Commands;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateOperacijaDialogViewModel : BaseViewModel
    {
        private IOperacijaSqlProvider _operacijaSqlProvider;
        private string _title = "Dijalog za kreiranje operacije";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _nazivOperacije;
        private string _osnovnoVreme;
        private string _pomocnoVreme;
        private string _dodatnoVreme;
        private string _oznakaMasine;
        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;
        private int _idOperacija;

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(NazivOperacije) || string.IsNullOrEmpty(OsnovnoVreme) || string.IsNullOrEmpty(PomocnoVreme)
                     || string.IsNullOrEmpty(DodatnoVreme) || string.IsNullOrEmpty(OznakaMasine));
            }
        }

        public int IdOperacije
        {
            get { return _idOperacija; }
            set { _idOperacija = value; }
        }

        public string OznakaMasine
        {
            get { return _oznakaMasine; }
            set
            {
                _oznakaMasine = value;
                OnPropertyChanged(nameof(OznakaMasine));
            }
        }

        public string DodatnoVreme
        {
            get { return _dodatnoVreme; }
            set
            {
                _dodatnoVreme = value;
                OnPropertyChanged(nameof(DodatnoVreme));
            }
        }

        public string PomocnoVreme
        {
            get { return _pomocnoVreme; }
            set
            {
                _pomocnoVreme = value;
                OnPropertyChanged(nameof(PomocnoVreme));
            }
        }

        public string OsnovnoVreme
        {
            get { return _osnovnoVreme; }
            set
            {
                _osnovnoVreme = value;
                OnPropertyChanged(nameof(OsnovnoVreme));
            }
        }


        public string NazivOperacije
        {
            get { return _nazivOperacije; }
            set 
            { 
                _nazivOperacije = value;
                OnPropertyChanged(nameof(NazivOperacije));
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

        public ICommand AddButtonCommand
        {
            get
            {
                if (_createButtonCommand == null)
                {
                    this._createButtonCommand= new RelayCommand(
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
            Operacija operacija = new Operacija
            {
                IDOperacija = IdOperacije,
                DodatnoVreme = Int32.Parse(DodatnoVreme),
                PomocnoVreme = Int32.Parse(PomocnoVreme),
                OsnovnoVreme = Int32.Parse(OsnovnoVreme),
                NazivOperacije = NazivOperacije,
                OznakaMasine = OznakaMasine
            };
            _operacijaSqlProvider.UpdateOperacijaById(operacija);
        }

        private void CreateButtonCommandExecute(object param)
        {
            Operacija operacija = new Operacija
            {
                DodatnoVreme = Int32.Parse(DodatnoVreme),
                PomocnoVreme = Int32.Parse(PomocnoVreme),
                OsnovnoVreme = Int32.Parse(OsnovnoVreme),
                NazivOperacije = NazivOperacije,
                OznakaMasine = OznakaMasine
            };
            _operacijaSqlProvider.CreateOperacijaById(operacija);
        }

        public CreateOperacijaDialogViewModel(IOperacijaSqlProvider operacijaSqlProvider)
        {
            _operacijaSqlProvider = operacijaSqlProvider;
        }

        public CreateOperacijaDialogViewModel(IOperacijaSqlProvider operacijaSqlProvider, Operacija operacija)
        {
            _operacijaSqlProvider = operacijaSqlProvider;
            IdOperacije = operacija.IDOperacija;
            NazivOperacije = operacija.NazivOperacije;
            OsnovnoVreme = operacija.OsnovnoVreme.ToString();
            DodatnoVreme = operacija.DodatnoVreme.ToString();
            PomocnoVreme = operacija.PomocnoVreme.ToString();
            OznakaMasine = operacija.OznakaMasine;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu operacije";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

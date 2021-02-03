using AUPS.Commands;
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
    public class CreateTehnoloskiPostupakViewModel : BaseViewModel
    {
        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;
        private readonly MainContentViewModel mainContentViewModel;
        private string _title = "Dijalog za kreiranje tehnoloskog postupka";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _tipTehnoloskogPostupka;
        private string _vremeIzrade;
        private string _serijaKom;
        private string _brKom;
        private int _idOperacije;
        private int _idTehnoloskogPostupka;
        private ObservableCollection<Operacija> _operacijaList;
        private int _selectedIndexOperacija;
        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;

        public int SelectedIndexOperacija
        {
            get { return _selectedIndexOperacija; }
            set { _selectedIndexOperacija = value; }
        }

        public List<string> NaziviOperacija
        {
            get { return OperacijaList.Select(x => x.NazivOperacije).ToList(); }
        }

        public ObservableCollection<Operacija> OperacijaList
        {
            get { return _operacijaList; }
            set { _operacijaList = value; }
        }

        public int IdTehnoloskogPostupka
        {
            get { return _idTehnoloskogPostupka; }
            set { _idTehnoloskogPostupka = value; }
        }


        public int IdOperacije
        {
            get { return _idOperacije; }
            set { _idOperacije = value; }
        }


        public string BrKom
        {
            get { return _brKom; }
            set { _brKom = value; }
        }


        public string SerijaKom
        {
            get { return _serijaKom; }
            set { _serijaKom = value; }
        }


        public string VremeIzrade
        {
            get { return _vremeIzrade; }
            set { _vremeIzrade = value; }
        }


        public string TipTehnoloskogPostupka
        {
            get { return _tipTehnoloskogPostupka; }
            set { _tipTehnoloskogPostupka = value; }
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


        public CreateTehnoloskiPostupakViewModel(ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ObservableCollection<Operacija> operacijaList,
            MainContentViewModel mainContentViewModel)
        {
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            OperacijaList = operacijaList;
            _selectedIndexOperacija = 0;
            this.mainContentViewModel = mainContentViewModel;
        }

        public CreateTehnoloskiPostupakViewModel(ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ObservableCollection<Operacija> operacijaList, TehnoloskiPostupak tehnoloskiPostupak,
            MainContentViewModel mainContentViewModel)
        {
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            IdTehnoloskogPostupka = tehnoloskiPostupak.IDTehPostupak;
            TipTehnoloskogPostupka = tehnoloskiPostupak.TipTehPostupak;
            VremeIzrade = tehnoloskiPostupak.VremeIzrade.ToString();
            SerijaKom = tehnoloskiPostupak.SerijaKom.ToString();
            BrKom = tehnoloskiPostupak.BrKomada.ToString();
            IdOperacije = tehnoloskiPostupak.Operacija.IDOperacija;
            OperacijaList = operacijaList;
            this.mainContentViewModel = mainContentViewModel;
            _selectedIndexOperacija = operacijaList.IndexOf(operacijaList.First(x => x.IDOperacija == tehnoloskiPostupak.Operacija.IDOperacija));
        }

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(TipTehnoloskogPostupka) || string.IsNullOrEmpty(VremeIzrade) || string.IsNullOrEmpty(SerijaKom)
                     || string.IsNullOrEmpty(BrKom));
            }
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
            TehnoloskiPostupak tehnoloskiPostupak = new TehnoloskiPostupak
            {
                IDTehPostupak = _idTehnoloskogPostupka,
                SerijaKom = Int32.Parse(_serijaKom),
                BrKomada = Int32.Parse(_brKom),
                TipTehPostupak = _tipTehnoloskogPostupka,
                VremeIzrade = Int32.Parse(_vremeIzrade),
                Operacija = OperacijaList[SelectedIndexOperacija]
            };
            bool isUpdated = _tehnoloskiPostupakSqlProvider.UpdateTehnoloskiPostupakById(tehnoloskiPostupak);
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
            TehnoloskiPostupak tehnoloskiPostupak = new TehnoloskiPostupak
            {
                SerijaKom = Int32.Parse(_serijaKom),
                BrKomada = Int32.Parse(_brKom),
                TipTehPostupak = _tipTehnoloskogPostupka,
                VremeIzrade = Int32.Parse(_vremeIzrade),
                Operacija = OperacijaList[SelectedIndexOperacija]
            };
            bool isCreated = _tehnoloskiPostupakSqlProvider.CreateTehnoloskiPostupakById(tehnoloskiPostupak);
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
            Title = "Dijalog za izmenu tehnoloski postupak";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

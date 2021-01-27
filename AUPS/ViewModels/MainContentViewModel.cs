using AUPS.Commands;
using AUPS.Dialogs.RadnoMesto;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels;
using AUPS.ViewModels.MainContentViewModels;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AUPS
{
    public class MainContentViewModel : BaseViewModel
    {
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;
        private IOperacijaSqlProvider _operacijaSqlProvider;
        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;
        private IRadnaListaSqlProvider _radnaListaSqlProvider;
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;
        private ITrebovanjeSqlProvider _trebovanjeSqlProvider;
        private object _contentMainScreen;
        private ICommand _addButtonCommand;
        private ICommand _deleteButtonCommand;

        private int _selectedTabIndex = 0;

        public ICommand AddButtonCommand
        {
            get
            {
                if (_addButtonCommand == null)
                {
                    this._addButtonCommand = new RelayCommand(
                        param => AddButtonCommandExecute(param));
                }

                return _addButtonCommand;
            }
        }

        public ICommand DeleteButtonCommand
        {
            get
            {
                if (_deleteButtonCommand == null)
                {
                    this._deleteButtonCommand = new RelayCommand(
                        param => DeleteButtonCommandExecute(param));
                }

                return _deleteButtonCommand;
            }
        }

        private void AddButtonCommandExecute(object param)
        {
            switch (_selectedTabIndex)
            {
                case 0:
                    CreateRadnoMestoDialog createRadnoMestoDialog = new CreateRadnoMestoDialog();
                    createRadnoMestoDialog.Show();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }
        }

        private void DeleteButtonCommandExecute(object param)
        {
            {
                bool succeded = false;
                switch (_selectedTabIndex)
                {
                    case 0:
                        RadnoMestoViewModel radnoMestoViewModel = (RadnoMestoViewModel)ContentMainScreen;
                        RadnoMesto selected = radnoMestoViewModel.ItemSelected;
                        //todo error dialog
                        if(selected != null)
                        {
                            succeded = _radnoMestoSqlProvider.DeleteFromRadnoMestoById(selected.IDRadnoMesto);
                            if (succeded)
                                radnoMestoViewModel.RadnoMestoList.Remove(selected);
                        }
                        break;
                    case 1:
                        OperacijaViewModel operacijaViewModel = (OperacijaViewModel)ContentMainScreen;
                        Operacija selectedOperacija = operacijaViewModel.ItemSelected;
                        //todo error dialog
                        if(selectedOperacija != null)
                        {
                            succeded = _operacijaSqlProvider.DeleteFromOperacijaById(selectedOperacija.IDOperacija);
                            if (succeded)
                                operacijaViewModel.OperacijaList.Remove(selectedOperacija);
                        }
                        break;
                    case 2:
                        PredmetRadaViewModel predmetRadaViewModel = (PredmetRadaViewModel)ContentMainScreen;
                        PredmetRada predmetRadaSelected = predmetRadaViewModel.ItemSelected;
                        //todo error dialog
                        if(predmetRadaSelected != null)
                        {
                            succeded = _predmetRadaSqlProvider.DeleteFromPredmetRadaById(predmetRadaSelected.IDPredmetRada);
                            if (succeded)
                                predmetRadaViewModel.PredmetRadaList.Remove(predmetRadaSelected);
                        }                        
                        break;
                    case 3:
                        RadnaListaViewModel radnaListaViewModel = (RadnaListaViewModel)ContentMainScreen;
                        RadnaLista radnaListaSelected = radnaListaViewModel.ItemSelected;
                        //todo error dialog
                        if (radnaListaSelected != null)
                        {
                            succeded = _radnaListaSqlProvider.DeleteFromRadnaListaById(radnaListaSelected.IDRadnaLista);
                            if (succeded)
                                radnaListaViewModel.RadnaListaList.Remove(radnaListaSelected);
                        }
                        break;
                    case 4:
                        RadnikProizvodnjaViewModel radnikProizvodnjaViewModel = (RadnikProizvodnjaViewModel)ContentMainScreen;
                        RadnikProizvodnja radnikProizvodnjaSelected = radnikProizvodnjaViewModel.ItemSelected;
                        //todo error dialog
                        if (radnikProizvodnjaSelected != null)
                        {
                            succeded = _radnikProizvodnjaSqlProvider.DeleteFromRadnikProizvodnjaById(radnikProizvodnjaSelected.IDRadnik);
                            if (succeded)
                                radnikProizvodnjaViewModel.RadnikProizvodnjaList.Remove(radnikProizvodnjaSelected);
                        }
                        break;
                    case 5:
                        RadniNalogViewModel radniNalogViewModel = (RadniNalogViewModel)ContentMainScreen;
                        RadniNalog radniNalogSelected = radniNalogViewModel.ItemSelected;
                        //todo error dialog
                        if (radniNalogSelected != null)
                        {
                            succeded = _radniNalogSqlProvider.DeleteFromRadniNalogById(radniNalogSelected.IDRadniNalog);
                            if (succeded)
                                radniNalogViewModel.RadniNalogList.Remove(radniNalogSelected);
                        }
                        break;
                    case 6:
                        TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel = (TehnoloskiPostupakViewModel)ContentMainScreen;
                        TehnoloskiPostupak tehnoloskiPostupakSelected = tehnoloskiPostupakViewModel.ItemSelected;
                        //todo error dialog
                        if (tehnoloskiPostupakSelected != null)
                        {
                            succeded = _tehnoloskiPostupakSqlProvider.DeleteFromTehnoloskiPostupakById(tehnoloskiPostupakSelected.IDTehPostupak);
                            if (succeded)
                                tehnoloskiPostupakViewModel.TehnoloskiPostupakList.Remove(tehnoloskiPostupakSelected);
                        }
                        break;
                    case 7:
                        TrebovanjeViewModel trebovanjeViewModel = (TrebovanjeViewModel)ContentMainScreen;
                        Trebovanje trebovanjeSelected = trebovanjeViewModel.ItemSelected;
                        //todo error dialog
                        if (trebovanjeSelected != null)
                        {
                            succeded = _trebovanjeSqlProvider.DeleteFromTrebovanjeById(trebovanjeSelected.IDTrebovanje);
                            if (succeded)
                                trebovanjeViewModel.TrebovanjeList.Remove(trebovanjeSelected);
                        }
                        break;
                }
            }
        }

        public object ContentMainScreen
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

        private DataTable _dataTable = new DataTable();

        public DataTable DataTable { get { return _dataTable; } }

        

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;
                    switch (value)
                    {
                        case 0:
                            ContentMainScreen = new RadnoMestoViewModel(_radnoMestoSqlProvider);
                            break;
                        case 1:
                            ContentMainScreen = new OperacijaViewModel(_operacijaSqlProvider);
                            break;
                        case 2:
                            ContentMainScreen = new PredmetRadaViewModel(_predmetRadaSqlProvider);
                            break;
                        case 3:
                            ContentMainScreen = new RadnaListaViewModel(_radnaListaSqlProvider);
                            break;
                        case 4:
                            ContentMainScreen = new RadnikProizvodnjaViewModel(_radnikProizvodnjaSqlProvider);
                            break;
                        case 5:
                            ContentMainScreen = new RadniNalogViewModel(_radniNalogSqlProvider);
                            break;
                        case 6:
                            ContentMainScreen = new TehnoloskiPostupakViewModel(_tehnoloskiPostupakSqlProvider);
                            break;
                        case 7:
                            ContentMainScreen = new TrebovanjeViewModel(_trebovanjeSqlProvider);
                            break;
                    }
                }
            }
        }


        public MainContentViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider, IOperacijaSqlProvider operacijaSqlProvider
                                    ,IPredmetRadaSqlProvider predmetRadaSqlProvider, IRadnaListaSqlProvider radnaListaSqlProvider
                                    ,IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, IRadniNalogSqlProvider radniNalogSqlProvider
                                    ,ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ITrebovanjeSqlProvider trebovanjeSqlProvider)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            _operacijaSqlProvider = operacijaSqlProvider;
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            _radniNalogSqlProvider = radniNalogSqlProvider;
            _radnaListaSqlProvider = radnaListaSqlProvider;
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
            ContentMainScreen = new RadnoMestoViewModel(radnoMestoSqlProvider);
        }
    }
}

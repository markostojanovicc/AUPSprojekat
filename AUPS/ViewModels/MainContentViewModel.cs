using AUPS.Commands;
using AUPS.Dialogs.Operacija;
using AUPS.Dialogs.PredmetRada;
using AUPS.Dialogs.RadnaLista;
using AUPS.Dialogs.RadnikProizvodnja;
using AUPS.Dialogs.RadniNalog;
using AUPS.Dialogs.RadnoMesto;
using AUPS.Dialogs.TehnoloskiPostupak;
using AUPS.Dialogs.Trebovanje;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels;
using AUPS.ViewModels.Dialogs;
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
        #region sql providers
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;
        private IOperacijaSqlProvider _operacijaSqlProvider;
        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;
        private IRadnaListaSqlProvider _radnaListaSqlProvider;
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;
        private ITrebovanjeSqlProvider _trebovanjeSqlProvider;
        #endregion

        #region commands
        private ICommand _addButtonCommand;
        private ICommand _deleteButtonCommand;
        private ICommand _updateButtonCommand;
        #endregion

        #region view models
        private readonly RadnoMestoViewModel radnoMestoViewModel;
        private readonly OperacijaViewModel operacijaViewModel;
        private readonly PredmetRadaViewModel predmetRadaViewModel;
        private readonly RadnaListaViewModel radnaListaViewModel;
        private readonly RadnikProizvodnjaViewModel radnikProizvodnjaViewModel;
        private readonly RadniNalogViewModel radniNalogViewModel;
        private readonly TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel;
        private readonly TrebovanjeViewModel trebovanjeViewModel;
        #endregion

        public MainContentViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider, IOperacijaSqlProvider operacijaSqlProvider
                                    , IPredmetRadaSqlProvider predmetRadaSqlProvider, IRadnaListaSqlProvider radnaListaSqlProvider
                                    , IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, IRadniNalogSqlProvider radniNalogSqlProvider
                                    , ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ITrebovanjeSqlProvider trebovanjeSqlProvider,
                                    RadnoMestoViewModel radnoMestoViewModel, OperacijaViewModel operacijaViewModel, PredmetRadaViewModel predmetRadaViewModel,
                                    RadnaListaViewModel radnaListaViewModel, RadnikProizvodnjaViewModel radnikProizvodnjaViewModel, RadniNalogViewModel radniNalogViewModel,
                                    TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel, TrebovanjeViewModel trebovanjeViewModel)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            _operacijaSqlProvider = operacijaSqlProvider;
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            _radniNalogSqlProvider = radniNalogSqlProvider;
            _radnaListaSqlProvider = radnaListaSqlProvider;
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
            this.radnoMestoViewModel = radnoMestoViewModel;
            this.operacijaViewModel = operacijaViewModel;
            this.predmetRadaViewModel = predmetRadaViewModel;
            this.radnaListaViewModel = radnaListaViewModel;
            this.radnikProizvodnjaViewModel = radnikProizvodnjaViewModel;
            this.radniNalogViewModel = radniNalogViewModel;
            this.tehnoloskiPostupakViewModel = tehnoloskiPostupakViewModel;
            this.trebovanjeViewModel = trebovanjeViewModel;
            GetDataFromDb();
        }


        private int _selectedTabIndex = 0;

        private object _contentMainScreen;

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

        private void UpdateButtonCommandExecute(object param)
        {
            switch (_selectedTabIndex)
            {
                case 0:
                    if(radnoMestoViewModel.ItemSelected != null)
                    {
                        CreateRadnoMestoDialog updateRadnoMestoDialog = new CreateRadnoMestoDialog(_radnoMestoSqlProvider, radnoMestoViewModel.ItemSelected);
                        CreateRadnoMestoDialogViewModel viewModelRadnoMesto = (CreateRadnoMestoDialogViewModel)updateRadnoMestoDialog.DataContext;
                        viewModelRadnoMesto.SetViewForUpdateDialog();
                        updateRadnoMestoDialog.Show();
                    }
                    break;
                case 1:
                    if(operacijaViewModel.ItemSelected != null)
                    {
                        CreateOperacijaDialog updateOperacijaDialog = new CreateOperacijaDialog(_operacijaSqlProvider, operacijaViewModel.ItemSelected);
                        CreateOperacijaDialogViewModel viewModelOperacija = (CreateOperacijaDialogViewModel)updateOperacijaDialog.DataContext;
                        viewModelOperacija.SetViewForUpdateDialog();
                        updateOperacijaDialog.Show();
                    }                    
                    break;
                case 2:
                    if(predmetRadaViewModel != null)
                    {
                        CreatePredmetRadaDialog updatePredmetRadaDialog = new CreatePredmetRadaDialog(_predmetRadaSqlProvider, predmetRadaViewModel.ItemSelected);
                        CreatePredmetRadaDialogViewModel viewModelPredmetRada = (CreatePredmetRadaDialogViewModel)updatePredmetRadaDialog.DataContext;
                        viewModelPredmetRada.SetViewForUpdateDialog();
                        updatePredmetRadaDialog.Show();
                    }                    
                    break;
                case 3:
                    if(radnaListaViewModel != null)
                    {
                        CreateRadnaListaDialog updateRadnaListaDialog = new CreateRadnaListaDialog(_radnaListaSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList(), operacijaViewModel.OperacijaList, radnikProizvodnjaViewModel.RadnikProizvodnjaList, radnaListaViewModel.ItemSelected);
                        CreateRadnaListaDialogViewModel viewModelRadnaLista = (CreateRadnaListaDialogViewModel)updateRadnaListaDialog.DataContext;
                        viewModelRadnaLista.SetViewForUpdateDialog();
                        updateRadnaListaDialog.Show();
                    }                    
                    break;
                case 4:
                    if(radnikProizvodnjaViewModel != null)
                    {
                        CreateRadnikProizvodnjaDialog udpateRadnikProizvodnjaDialog = new CreateRadnikProizvodnjaDialog(_radnikProizvodnjaSqlProvider, radnoMestoViewModel.RadnoMestoList, radnikProizvodnjaViewModel.ItemSelected);
                        CreateRadnikProizvodnjaDialogViewModel viewModelRadnik = (CreateRadnikProizvodnjaDialogViewModel)udpateRadnikProizvodnjaDialog.DataContext;
                        viewModelRadnik.SetViewForUpdateDialog();
                        udpateRadnikProizvodnjaDialog.Show();
                    }                    
                    break;
                case 5:
                    if(radniNalogViewModel != null)
                    {
                        CreateRadniNalogDialog updateRadniNalogDialog = new CreateRadniNalogDialog(_radniNalogSqlProvider, predmetRadaViewModel.PredmetRadaList, radniNalogViewModel.ItemSelected);
                        CreateRadniNalogDialogViewModel viewModelRadniNalog = (CreateRadniNalogDialogViewModel)updateRadniNalogDialog.DataContext;
                        viewModelRadniNalog.SetViewForUpdateDialog();
                        updateRadniNalogDialog.Show();
                    }                    
                    break;
                case 6:
                    if(tehnoloskiPostupakViewModel != null)
                    {
                        CreateTehnoloskiPostupakDialog updateTehnoloskiPostupakDialog = new CreateTehnoloskiPostupakDialog(_tehnoloskiPostupakSqlProvider, operacijaViewModel.OperacijaList, tehnoloskiPostupakViewModel.ItemSelected);
                        CreateTehnoloskiPostupakViewModel viewModelTehnoloskiPostupak = (CreateTehnoloskiPostupakViewModel)updateTehnoloskiPostupakDialog.DataContext;
                        viewModelTehnoloskiPostupak.SetViewForUpdateDialog();
                        updateTehnoloskiPostupakDialog.Show();
                    }                    
                    break;
                case 7:
                    if(trebovanjeViewModel != null)
                    {
                        CreateTrebovanjeDialog updateTrebovanjeDialog = new CreateTrebovanjeDialog(_trebovanjeSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList(), trebovanjeViewModel.ItemSelected);
                        CreateTrebovanjeDialogViewModel viewModelTrebovanje = (CreateTrebovanjeDialogViewModel)updateTrebovanjeDialog.DataContext;
                        viewModelTrebovanje.SetViewForUpdateDialog();
                        updateTrebovanjeDialog.Show();
                    }                    
                    break;
            }
        }

        private void AddButtonCommandExecute(object param)
        {
            switch (_selectedTabIndex)
            {
                case 0:
                    CreateRadnoMestoDialog createRadnoMestoDialog = new CreateRadnoMestoDialog(_radnoMestoSqlProvider);
                    createRadnoMestoDialog.Show();
                    break;
                case 1:
                    CreateOperacijaDialog createOperacijaDialog = new CreateOperacijaDialog(_operacijaSqlProvider);
                    createOperacijaDialog.Show();
                    break;
                case 2:
                    CreatePredmetRadaDialog createPredmetRadaDialog = new CreatePredmetRadaDialog(_predmetRadaSqlProvider);
                    createPredmetRadaDialog.Show();
                    break;
                case 3:
                    CreateRadnaListaDialog createRadnaListaDialog = new CreateRadnaListaDialog(_radnaListaSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList(), operacijaViewModel.OperacijaList, radnikProizvodnjaViewModel.RadnikProizvodnjaList);
                    createRadnaListaDialog.Show();
                    break;
                case 4:
                    CreateRadnikProizvodnjaDialog createRadnikProizvodnjaDialog = new CreateRadnikProizvodnjaDialog(_radnikProizvodnjaSqlProvider, radnoMestoViewModel.RadnoMestoList);
                    createRadnikProizvodnjaDialog.Show();
                    break;
                case 5:
                    CreateRadniNalogDialog createRadniNalogDialog = new CreateRadniNalogDialog(_radniNalogSqlProvider, predmetRadaViewModel.PredmetRadaList);
                    createRadniNalogDialog.Show();
                    break;
                case 6:
                    CreateTehnoloskiPostupakDialog createTehnoloskiPostupakDialog = new CreateTehnoloskiPostupakDialog(_tehnoloskiPostupakSqlProvider, operacijaViewModel.OperacijaList);
                    createTehnoloskiPostupakDialog.Show();
                    break;
                case 7:
                    CreateTrebovanjeDialog createTrebovanjeDialog = new CreateTrebovanjeDialog(_trebovanjeSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList());
                    createTrebovanjeDialog.Show();
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
                            ContentMainScreen = radnoMestoViewModel;
                            break;
                        case 1:
                            ContentMainScreen = operacijaViewModel;
                            break;
                        case 2:
                            ContentMainScreen = predmetRadaViewModel;
                            break;
                        case 3:
                            ContentMainScreen = radnaListaViewModel;
                            break;
                        case 4:
                            ContentMainScreen = radnikProizvodnjaViewModel;
                            break;
                        case 5:
                            ContentMainScreen = radniNalogViewModel;
                            break;
                        case 6:
                            ContentMainScreen = tehnoloskiPostupakViewModel;
                            break;
                        case 7:
                            ContentMainScreen = trebovanjeViewModel;
                            break;
                    }
                }
            }
        }

        private void GetDataFromDb()
        {
            operacijaViewModel.OperacijaList = _operacijaSqlProvider.GetAllFromOperacija();
            predmetRadaViewModel.PredmetRadaList = _predmetRadaSqlProvider.GetAllFromPredmetRada();
            radnaListaViewModel.RadnaListaList = _radnaListaSqlProvider.GetAllFromRadnaLista();
            radnikProizvodnjaViewModel.RadnikProizvodnjaList = _radnikProizvodnjaSqlProvider.GetAllFromRadnikProizvodnja();
            radniNalogViewModel.RadniNalogList = _radniNalogSqlProvider.GetAllFromRadniNalog();
            radnoMestoViewModel.RadnoMestoList = _radnoMestoSqlProvider.GetAllFromRadnoMesto();
            tehnoloskiPostupakViewModel.TehnoloskiPostupakList = _tehnoloskiPostupakSqlProvider.GetAllFromTehnoloskiPostupak();
            trebovanjeViewModel.TrebovanjeList = _trebovanjeSqlProvider.GetAllFromTrebovanje();

            ContentMainScreen = radnoMestoViewModel;
        }
    }
}

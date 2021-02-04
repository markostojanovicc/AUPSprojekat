using AUPS.Commands;
using AUPS.Dialogs.ErrorDialogs;
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
using System.IO;
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

        private string _imageSource;
        private string _userName;
        private string _userLastName;

        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserLastName
        {
            get { return _userLastName; }
            set { _userLastName = value; }
        }

        #region view models
        private RadnoMestoViewModel radnoMestoViewModel = new RadnoMestoViewModel();
        private OperacijaViewModel operacijaViewModel;
        private PredmetRadaViewModel predmetRadaViewModel;
        private RadnaListaViewModel radnaListaViewModel;
        private RadnikProizvodnjaViewModel radnikProizvodnjaViewModel;
        private RadniNalogViewModel radniNalogViewModel;
        private TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel;
        private TrebovanjeViewModel trebovanjeViewModel;
        #endregion

        public MainContentViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider, IOperacijaSqlProvider operacijaSqlProvider
                                    , IPredmetRadaSqlProvider predmetRadaSqlProvider, IRadnaListaSqlProvider radnaListaSqlProvider
                                    , IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, IRadniNalogSqlProvider radniNalogSqlProvider
                                    , ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ITrebovanjeSqlProvider trebovanjeSqlProvider,
                                    RadnoMestoViewModel radnoMestoViewModel, OperacijaViewModel operacijaViewModel, PredmetRadaViewModel predmetRadaViewModel,
                                    RadnaListaViewModel radnaListaViewModel, RadnikProizvodnjaViewModel radnikProizvodnjaViewModel, RadniNalogViewModel radniNalogViewModel,
                                    TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel, TrebovanjeViewModel trebovanjeViewModel, User loggedUser)
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
            _userName = loggedUser.Ime;
            _userLastName = loggedUser.Prezime;
            SetImage(loggedUser.ImagePath);
        }

        private void SetImage(string imagePath)
        {
            _imageSource = imagePath;
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
                        CreateRadnoMestoDialog updateRadnoMestoDialog = new CreateRadnoMestoDialog(_radnoMestoSqlProvider, radnoMestoViewModel.ItemSelected, this);
                        CreateRadnoMestoDialogViewModel viewModelRadnoMesto = (CreateRadnoMestoDialogViewModel)updateRadnoMestoDialog.DataContext;
                        viewModelRadnoMesto.SetViewForUpdateDialog();
                        updateRadnoMestoDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);
                    break;
                case 1:
                    if(operacijaViewModel.ItemSelected != null)
                    {
                        CreateOperacijaDialog updateOperacijaDialog = new CreateOperacijaDialog(_operacijaSqlProvider, operacijaViewModel.ItemSelected, this);
                        CreateOperacijaDialogViewModel viewModelOperacija = (CreateOperacijaDialogViewModel)updateOperacijaDialog.DataContext;
                        viewModelOperacija.SetViewForUpdateDialog();
                        updateOperacijaDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);                    
                    break;
                case 2:
                    if(predmetRadaViewModel.ItemSelected != null)
                    {
                        CreatePredmetRadaDialog updatePredmetRadaDialog = new CreatePredmetRadaDialog(_predmetRadaSqlProvider, predmetRadaViewModel.ItemSelected, this);
                        CreatePredmetRadaDialogViewModel viewModelPredmetRada = (CreatePredmetRadaDialogViewModel)updatePredmetRadaDialog.DataContext;
                        viewModelPredmetRada.SetViewForUpdateDialog();
                        updatePredmetRadaDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);                    
                    break;
                case 3:
                    if(radnaListaViewModel.ItemSelected != null)
                    {
                        CreateRadnaListaDialog updateRadnaListaDialog = new CreateRadnaListaDialog(_radnaListaSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList(), operacijaViewModel.OperacijaList, radnikProizvodnjaViewModel.RadnikProizvodnjaList, radnaListaViewModel.ItemSelected,this);
                        CreateRadnaListaDialogViewModel viewModelRadnaLista = (CreateRadnaListaDialogViewModel)updateRadnaListaDialog.DataContext;
                        viewModelRadnaLista.SetViewForUpdateDialog();
                        updateRadnaListaDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);                    
                    break;
                case 4:
                    if(radnikProizvodnjaViewModel.ItemSelected != null)
                    {
                        CreateRadnikProizvodnjaDialog udpateRadnikProizvodnjaDialog = new CreateRadnikProizvodnjaDialog(_radnikProizvodnjaSqlProvider, radnoMestoViewModel.RadnoMestoList, radnikProizvodnjaViewModel.ItemSelected, this);
                        CreateRadnikProizvodnjaDialogViewModel viewModelRadnik = (CreateRadnikProizvodnjaDialogViewModel)udpateRadnikProizvodnjaDialog.DataContext;
                        viewModelRadnik.SetViewForUpdateDialog();
                        udpateRadnikProizvodnjaDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);                    
                    break;
                case 5:
                    if(radniNalogViewModel.ItemSelected != null)
                    {
                        CreateRadniNalogDialog updateRadniNalogDialog = new CreateRadniNalogDialog(_radniNalogSqlProvider, predmetRadaViewModel.PredmetRadaList, radniNalogViewModel.ItemSelected, this);
                        CreateRadniNalogDialogViewModel viewModelRadniNalog = (CreateRadniNalogDialogViewModel)updateRadniNalogDialog.DataContext;
                        viewModelRadniNalog.SetViewForUpdateDialog();
                        updateRadniNalogDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);
                    break;
                case 6:
                    if(tehnoloskiPostupakViewModel.ItemSelected != null)
                    {
                        CreateTehnoloskiPostupakDialog updateTehnoloskiPostupakDialog = new CreateTehnoloskiPostupakDialog(_tehnoloskiPostupakSqlProvider, operacijaViewModel.OperacijaList, tehnoloskiPostupakViewModel.ItemSelected, this);
                        CreateTehnoloskiPostupakViewModel viewModelTehnoloskiPostupak = (CreateTehnoloskiPostupakViewModel)updateTehnoloskiPostupakDialog.DataContext;
                        viewModelTehnoloskiPostupak.SetViewForUpdateDialog();
                        updateTehnoloskiPostupakDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);                   
                    break;
                case 7:
                    if(trebovanjeViewModel.ItemSelected != null)
                    {
                        CreateTrebovanjeDialog updateTrebovanjeDialog = new CreateTrebovanjeDialog(_trebovanjeSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList(), trebovanjeViewModel.ItemSelected, this);
                        CreateTrebovanjeDialogViewModel viewModelTrebovanje = (CreateTrebovanjeDialogViewModel)updateTrebovanjeDialog.DataContext;
                        viewModelTrebovanje.SetViewForUpdateDialog();
                        updateTrebovanjeDialog.ShowDialog();
                    }else
                        ShowNotSelectedErrorDialog(false);
                    break;
            }
        }

        private void ShowNotSelectedErrorDialog(bool isDelete)
        {
            ErrorDialog errorDialog = new ErrorDialog();
            ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
            errorDialog.Title = "Greška";
            errorDialogViewModel.ErrorMessage = isDelete ? "Niste selektovali red koji želite da obrišete. Pokušajte ponovo." : "Niste selektovali red koji želite da izmenite. Pokušajte ponovo.";
            errorDialog.ShowDialog();
        }

        private void ShowCantDeleteErrorDialog()
        {
            ErrorDialog errorDialog = new ErrorDialog();
            ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
            errorDialog.Title = "Greška";
            errorDialogViewModel.ErrorMessage = "Nije dozvoljeno obrisati radno mesto koje sadrži radnike.";
            errorDialog.ShowDialog();
        }

        private void AddButtonCommandExecute(object param)
        {
            switch (_selectedTabIndex)
            {
                case 0:
                    CreateRadnoMestoDialog createRadnoMestoDialog = new CreateRadnoMestoDialog(_radnoMestoSqlProvider, this);
                    createRadnoMestoDialog.ShowDialog();
                    break;
                case 1:
                    CreateOperacijaDialog createOperacijaDialog = new CreateOperacijaDialog(_operacijaSqlProvider, this);
                    createOperacijaDialog.ShowDialog();
                    break;
                case 2:
                    CreatePredmetRadaDialog createPredmetRadaDialog = new CreatePredmetRadaDialog(_predmetRadaSqlProvider, this);
                    createPredmetRadaDialog.ShowDialog();
                    break;
                case 3:
                    CreateRadnaListaDialog createRadnaListaDialog = new CreateRadnaListaDialog(_radnaListaSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList(), operacijaViewModel.OperacijaList, radnikProizvodnjaViewModel.RadnikProizvodnjaList, this);
                    createRadnaListaDialog.ShowDialog();
                    break;
                case 4:
                    CreateRadnikProizvodnjaDialog createRadnikProizvodnjaDialog = new CreateRadnikProizvodnjaDialog(_radnikProizvodnjaSqlProvider, radnoMestoViewModel.RadnoMestoList, this);
                    createRadnikProizvodnjaDialog.ShowDialog();
                    break;
                case 5:
                    CreateRadniNalogDialog createRadniNalogDialog = new CreateRadniNalogDialog(_radniNalogSqlProvider, predmetRadaViewModel.PredmetRadaList, this);
                    createRadniNalogDialog.ShowDialog();
                    break;
                case 6:
                    CreateTehnoloskiPostupakDialog createTehnoloskiPostupakDialog = new CreateTehnoloskiPostupakDialog(_tehnoloskiPostupakSqlProvider, operacijaViewModel.OperacijaList, this);
                    createTehnoloskiPostupakDialog.ShowDialog();
                    break;
                case 7:
                    CreateTrebovanjeDialog createTrebovanjeDialog = new CreateTrebovanjeDialog(_trebovanjeSqlProvider, radniNalogViewModel.RadniNalogList.Select(x => x.IDRadniNalog).ToList(), this);
                    createTrebovanjeDialog.ShowDialog();
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
                        if(selected != null)
                        {
                            if (!DoesRadnikProizvodnjaContainsRadnoMestoId(selected.IDRadnoMesto))
                            {
                                succeded = _radnoMestoSqlProvider.DeleteFromRadnoMestoById(selected.IDRadnoMesto);
                                if (succeded)
                                    radnoMestoViewModel.RadnoMestoList.Remove(selected);
                            }
                            else
                                ShowCantDeleteErrorDialog();                            
                        }else
                            ShowNotSelectedErrorDialog(true);
                        break;
                    case 1:
                        OperacijaViewModel operacijaViewModel = (OperacijaViewModel)ContentMainScreen;
                        Operacija selectedOperacija = operacijaViewModel.ItemSelected;
                        if(selectedOperacija != null)
                        {
                            succeded = _operacijaSqlProvider.DeleteFromOperacijaById(selectedOperacija.IDOperacija);
                            if (succeded)
                                operacijaViewModel.OperacijaList.Remove(selectedOperacija);
                        }else
                            ShowNotSelectedErrorDialog(true);
                        break;
                    case 2:
                        PredmetRadaViewModel predmetRadaViewModel = (PredmetRadaViewModel)ContentMainScreen;
                        PredmetRada predmetRadaSelected = predmetRadaViewModel.ItemSelected;
                        if(predmetRadaSelected != null)
                        {
                            succeded = _predmetRadaSqlProvider.DeleteFromPredmetRadaById(predmetRadaSelected.IDPredmetRada);
                            if (succeded)
                                predmetRadaViewModel.PredmetRadaList.Remove(predmetRadaSelected);
                        }else
                            ShowNotSelectedErrorDialog(true);                        
                        break;
                    case 3:
                        RadnaListaViewModel radnaListaViewModel = (RadnaListaViewModel)ContentMainScreen;
                        RadnaLista radnaListaSelected = radnaListaViewModel.ItemSelected;
                        if (radnaListaSelected != null)
                        {
                            succeded = _radnaListaSqlProvider.DeleteFromRadnaListaById(radnaListaSelected.IDRadnaLista);
                            if (succeded)
                                radnaListaViewModel.RadnaListaList.Remove(radnaListaSelected);
                        }else
                            ShowNotSelectedErrorDialog(true);
                        break;
                    case 4:
                        RadnikProizvodnjaViewModel radnikProizvodnjaViewModel = (RadnikProizvodnjaViewModel)ContentMainScreen;
                        RadnikProizvodnja radnikProizvodnjaSelected = radnikProizvodnjaViewModel.ItemSelected;
                        if (radnikProizvodnjaSelected != null)
                        {
                            succeded = _radnikProizvodnjaSqlProvider.DeleteFromRadnikProizvodnjaById(radnikProizvodnjaSelected.IDRadnik);
                            if (succeded)
                                radnikProizvodnjaViewModel.RadnikProizvodnjaList.Remove(radnikProizvodnjaSelected);
                        }else
                            ShowNotSelectedErrorDialog(true);
                        break;
                    case 5:
                        RadniNalogViewModel radniNalogViewModel = (RadniNalogViewModel)ContentMainScreen;
                        RadniNalog radniNalogSelected = radniNalogViewModel.ItemSelected;
                        if (radniNalogSelected != null)
                        {
                            succeded = _radniNalogSqlProvider.DeleteFromRadniNalogById(radniNalogSelected.IDRadniNalog);
                            if (succeded)
                                radniNalogViewModel.RadniNalogList.Remove(radniNalogSelected);
                        }else
                            ShowNotSelectedErrorDialog(true);
                        break;
                    case 6:
                        TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel = (TehnoloskiPostupakViewModel)ContentMainScreen;
                        TehnoloskiPostupak tehnoloskiPostupakSelected = tehnoloskiPostupakViewModel.ItemSelected;
                        if (tehnoloskiPostupakSelected != null)
                        {
                            succeded = _tehnoloskiPostupakSqlProvider.DeleteFromTehnoloskiPostupakById(tehnoloskiPostupakSelected.IDTehPostupak);
                            if (succeded)
                                tehnoloskiPostupakViewModel.TehnoloskiPostupakList.Remove(tehnoloskiPostupakSelected);
                        }else
                            ShowNotSelectedErrorDialog(true);
                        break;
                    case 7:
                        TrebovanjeViewModel trebovanjeViewModel = (TrebovanjeViewModel)ContentMainScreen;
                        Trebovanje trebovanjeSelected = trebovanjeViewModel.ItemSelected;
                        if (trebovanjeSelected != null)
                        {
                            succeded = _trebovanjeSqlProvider.DeleteFromTrebovanjeById(trebovanjeSelected.IDTrebovanje);
                            if (succeded)
                                trebovanjeViewModel.TrebovanjeList.Remove(trebovanjeSelected);
                        }else
                            ShowNotSelectedErrorDialog(true);
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

        private bool DoesRadnikProizvodnjaContainsRadnoMestoId(int idRadnoMesto)
        {
            RadnikProizvodnja radnikProizvodnja = radnikProizvodnjaViewModel.RadnikProizvodnjaList.FirstOrDefault(x => x.RadnoMesto?.IDRadnoMesto == idRadnoMesto);

            return radnikProizvodnja != null;
        }

        public void RefreshData()
        {
            operacijaViewModel.OperacijaList = _operacijaSqlProvider.GetAllFromOperacija();
            predmetRadaViewModel.PredmetRadaList = _predmetRadaSqlProvider.GetAllFromPredmetRada();
            radnaListaViewModel.RadnaListaList = _radnaListaSqlProvider.GetAllFromRadnaLista();
            radnikProizvodnjaViewModel.RadnikProizvodnjaList = _radnikProizvodnjaSqlProvider.GetAllFromRadnikProizvodnja();
            radniNalogViewModel.RadniNalogList = _radniNalogSqlProvider.GetAllFromRadniNalog();
            radnoMestoViewModel.RadnoMestoList = _radnoMestoSqlProvider.GetAllFromRadnoMesto();
            tehnoloskiPostupakViewModel.TehnoloskiPostupakList = _tehnoloskiPostupakSqlProvider.GetAllFromTehnoloskiPostupak();
            trebovanjeViewModel.TrebovanjeList = _trebovanjeSqlProvider.GetAllFromTrebovanje();
        }
    }
}

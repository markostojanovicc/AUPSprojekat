using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.MainContentViewModels;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int _selectedTabIndex = 0;

        public Object ContentMainScreen
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
                            ContentMainScreen = new PredmetRadaViewModel();
                            break;
                        case 3:
                            ContentMainScreen = new RadnaListaViewModel();
                            break;
                        case 4:
                            ContentMainScreen = new RadnikProizvodnjaViewModel();
                            break;
                        case 5:
                            ContentMainScreen = new RadniNalogViewModel();
                            break;
                        case 6:
                            ContentMainScreen = new TehnoloskiPostupakViewModel();
                            break;
                        case 7:
                            ContentMainScreen = new TehnoloskiPostupakViewModel();
                            break;
                        case 8:
                            ContentMainScreen = new TrebovanjeViewModel();
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

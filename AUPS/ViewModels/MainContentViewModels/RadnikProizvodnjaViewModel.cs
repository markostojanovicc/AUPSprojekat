using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class RadnikProizvodnjaViewModel : BaseViewModel
    {
        private ObservableCollection<RadnikProizvodnja> _radnikProizvodnjaList;
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;

        public ObservableCollection<RadnikProizvodnja> RadnikProizvodnjaList
        {
            get { return _radnikProizvodnjaList; }
            set
            {
                _radnikProizvodnjaList = value;
                OnPropertyChanged(nameof(RadnikProizvodnjaList));
            }
        }

        private RadnikProizvodnja _itemSelected;

        public RadnikProizvodnja ItemSelected
        {
            get { return _itemSelected; }
            set { _itemSelected = value; }
        }

        public RadnikProizvodnjaViewModel(IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider)
        {
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            FillTableWithData();
        }

        private void FillTableWithData()
        {
            RadnikProizvodnjaList = _radnikProizvodnjaSqlProvider.GetAllFromRadnikProizvodnja();
        }
    }
}

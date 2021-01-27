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
    public class RadnaListaViewModel : BaseViewModel
    {
        private ObservableCollection<RadnaLista> _radnaListaList;
        private IRadnaListaSqlProvider _radnaListaSqlProvider;
        public ObservableCollection<RadnaLista> RadnaListaList
        {
            get { return _radnaListaList; }
            set
            {
                _radnaListaList = value;
                OnPropertyChanged(nameof(RadnaListaList));
            }
        }

        private RadnaLista _itemSelected;

        public RadnaLista ItemSelected
        {
            get { return _itemSelected; }
            set { _itemSelected = value; }
        }

        private IRadnaListaSqlProvider _radnaListaSqlProvider;

        public RadnaListaViewModel(IRadnaListaSqlProvider radnaListaSqlProvider)
        {
            _radnaListaSqlProvider = radnaListaSqlProvider;
            FillTableWithData();
        }

        private void FillTableWithData()
        {
            RadnaListaList = _radnaListaSqlProvider.GetAllFromRadnaLista();
        }
    }
}

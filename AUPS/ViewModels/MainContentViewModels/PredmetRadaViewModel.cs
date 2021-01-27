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
    public class PredmetRadaViewModel : BaseViewModel
    {
        private ObservableCollection<PredmetRada> _predmetRadaList;
        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;
        public ObservableCollection<PredmetRada> PredmetRadaList
        {
            get { return _predmetRadaList; }
            set
            {
                _predmetRadaList = value;
                OnPropertyChanged(nameof(PredmetRada));
            }
        }

        private PredmetRada _itemSelected;

        public PredmetRada ItemSelected
        {
            get { return _itemSelected; }
            set { _itemSelected = value; }
        }

        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;

        public PredmetRadaViewModel(IPredmetRadaSqlProvider predmetRadaSqlProvider)
        {
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
            FillTableWithData();
        }

        private void FillTableWithData()
        {
            PredmetRadaList = _predmetRadaSqlProvider.GetAllFromPredmetRada();
        }
    }
}

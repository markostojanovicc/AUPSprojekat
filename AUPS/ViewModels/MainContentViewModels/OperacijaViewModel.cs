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
    public class OperacijaViewModel : BaseViewModel
    {
        private ObservableCollection<Operacija> _operacijaList;
        private IOperacijaSqlProvider _operacijaSqlProvider;
        public ObservableCollection<Operacija> OperacijaList
        {
            get { return _operacijaList; }
            set
            {
                _operacijaList = value;
                OnPropertyChanged(nameof(Operacija));
            }
        }

        public OperacijaViewModel(IOperacijaSqlProvider operacijaSqlProvider)
        {
            _operacijaSqlProvider = operacijaSqlProvider;
            FillTableWithData();
        }

        private void FillTableWithData()
        {
            OperacijaList = _operacijaSqlProvider.GetAllFromOperacija();
        }
    }
}

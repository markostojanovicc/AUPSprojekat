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
    public class RadniNalogViewModel : BaseViewModel
    {
        private ObservableCollection<RadniNalog> _radniNalogList;
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        public ObservableCollection<RadniNalog> RadniNalogList
        {
            get { return _radniNalogList; }
            set
            {
                _radniNalogList = value;
                OnPropertyChanged(nameof(RadniNalogList));
            }
        }

        public RadniNalogViewModel(IRadniNalogSqlProvider radniNalogSqlProvider)
        {
            _radniNalogSqlProvider = radniNalogSqlProvider;
            FillTableWithData();
        }

        private void FillTableWithData()
        {
            RadniNalogList = _radniNalogSqlProvider.GetAllFromRadniNalog();
        }
    }
}

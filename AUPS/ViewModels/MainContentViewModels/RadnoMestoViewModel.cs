using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.ObjectModel;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class RadnoMestoViewModel : BaseViewModel
    {
        private ObservableCollection<RadnoMesto> _radnoMestoList;
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;

        public ObservableCollection<RadnoMesto> RadnoMestoList
        {
            get { return _radnoMestoList; }
            set
            {
                _radnoMestoList = value;
                OnPropertyChanged(nameof(RadnoMestoList));
            }
        }

        public RadnoMestoViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            FillTableWithData();
        }

        private void FillTableWithData()
        {
            RadnoMestoList = _radnoMestoSqlProvider.GetAllFromRadnoMesto();
        }
    }
}

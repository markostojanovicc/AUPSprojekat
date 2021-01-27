using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System.Collections.ObjectModel;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class TrebovanjeViewModel : BaseViewModel
    {
        private ITrebovanjeSqlProvider _trebovanjeSqlProvider;
        private ObservableCollection<Trebovanje> _trebovanjeList;
        public ObservableCollection<Trebovanje> TrebovanjeList
        {
            get { return _trebovanjeList; }
            set
            {
                _trebovanjeList = value;
                OnPropertyChanged(nameof(TrebovanjeList));
            }
        }

        private Trebovanje _itemSelected;

        public Trebovanje ItemSelected
        {
            get { return _itemSelected; }
            set { _itemSelected = value; }
        }

        public TrebovanjeViewModel(ITrebovanjeSqlProvider trebovanjeSqlProvider)
        {
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
        }
    }
}

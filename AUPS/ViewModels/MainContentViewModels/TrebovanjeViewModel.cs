using AUPS.Models;
using ChatApp;
using System.Collections.ObjectModel;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class TrebovanjeViewModel : BaseViewModel
    {
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
    }
}

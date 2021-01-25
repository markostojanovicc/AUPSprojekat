using AUPS.Models;
using ChatApp;
using System.Collections.ObjectModel;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class TehnoloskiPostupakViewModel : BaseViewModel
    {
        private ObservableCollection<TehnoloskiPostupak> _tehnoloskiPostupakList;
        public ObservableCollection<TehnoloskiPostupak> TehnoloskiPostupakList
        {
            get { return _tehnoloskiPostupakList; }
            set
            {
                _tehnoloskiPostupakList= value;
                OnPropertyChanged(nameof(TehnoloskiPostupak));
            }
        }

        public TehnoloskiPostupakViewModel()
        {

        }
    }
}

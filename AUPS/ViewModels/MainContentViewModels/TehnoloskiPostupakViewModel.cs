using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
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

        private TehnoloskiPostupak _itemSelected;

        public TehnoloskiPostupak ItemSelected
        {
            get { return _itemSelected; }
            set { _itemSelected = value; }
        }

        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;

        public TehnoloskiPostupakViewModel(ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider)
        {
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
        }
    }
}

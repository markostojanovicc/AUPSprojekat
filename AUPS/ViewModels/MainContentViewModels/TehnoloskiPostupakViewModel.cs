using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System.Collections.ObjectModel;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class TehnoloskiPostupakViewModel : BaseViewModel
    {
        private ObservableCollection<TehnoloskiPostupak> _tehnoloskiPostupakList;
        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;
        public ObservableCollection<TehnoloskiPostupak> TehnoloskiPostupakList
        {
            get { return _tehnoloskiPostupakList; }
            set
            {
                _tehnoloskiPostupakList= value;
                OnPropertyChanged(nameof(TehnoloskiPostupak));
            }
        }

        public TehnoloskiPostupakViewModel(ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider)
        {
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            FillTableWithData();
        }

        private void FillTableWithData()
        {
            TehnoloskiPostupakList = _tehnoloskiPostupakSqlProvider.GetAllFromTehnoloskiPostupak();
        }
    }
}

using AUPS.Models;
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
        public ObservableCollection<RadniNalog> RadniNalogList
        {
            get { return _radniNalogList; }
            set
            {
                _radniNalogList = value;
                OnPropertyChanged(nameof(RadniNalogList));
            }
        }

        public RadniNalogViewModel()
        {

        }
    }
}

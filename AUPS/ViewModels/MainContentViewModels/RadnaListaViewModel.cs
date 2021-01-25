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
    public class RadnaListaViewModel : BaseViewModel
    {
        private ObservableCollection<RadnaLista> _radnaListaList;
        public ObservableCollection<RadnaLista> RadnaListaList
        {
            get { return _radnaListaList; }
            set
            {
                _radnaListaList = value;
                OnPropertyChanged(nameof(RadnaListaList));
            }
        }

        public RadnaListaViewModel()
        {

        }
    }
}

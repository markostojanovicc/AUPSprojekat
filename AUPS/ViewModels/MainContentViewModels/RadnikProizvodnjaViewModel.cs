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
    public class RadnikProizvodnjaViewModel : BaseViewModel
    {
        private ObservableCollection<RadnikProizvodnja> _radnikProizvodnjaList;
        public ObservableCollection<RadnikProizvodnja> RadnikProizvodnjaList
        {
            get { return _radnikProizvodnjaList; }
            set
            {
                _radnikProizvodnjaList = value;
                OnPropertyChanged(nameof(RadnikProizvodnjaList));
            }
        }

        public RadnikProizvodnjaViewModel()
        {

        }
    }
}

using AUPS.Enums;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadnikProizvodnjaDialogViewModel : BaseViewModel
    {
        private List<Pol> _polovi = new List<Pol>() { Pol.Musko, Pol.Zensko };

        public List<Pol> Polovi
        {
            get { return _polovi; }
            set { }
        }

        private Pol _selectedType;

        public Pol SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(Polovi));
            }
        }

    }
}

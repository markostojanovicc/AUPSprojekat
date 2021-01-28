using AUPS.Enums;
using AUPS.SqlProviders.Interfaces;
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
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;
        private string _title = "Dijalog za kreiranje radnika";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _imeRadnika;
        private string _prezimeRadnika;
        private string _idRadnoMesto;

        public string IdRadnoMesto
        {
            get { return _idRadnoMesto; }
            set { _idRadnoMesto = value; }
        }

        public string PrezimeRadnika
        {
            get { return _prezimeRadnika; }
            set { _prezimeRadnika = value; }
        }


        public string ImeRadnika
        {
            get { return _imeRadnika; }
            set { _imeRadnika = value; }
        }


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

        public bool IsUpdateBtnVisible
        {
            get { return _isUpdateBtnVisible = false; }
            set { _isUpdateBtnVisible = value; }
        }

        public bool IsCreateBtnVisible
        {
            get { return _isCreateBtnVisible = true; }
            set { _isCreateBtnVisible = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public CreateRadnikProizvodnjaDialogViewModel(IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider)
        {
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radnika";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }

    }
}

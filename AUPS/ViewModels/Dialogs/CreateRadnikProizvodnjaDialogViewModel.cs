using AUPS.Enums;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int _idRadnika;
        private string _selectedRadnoMesto;
        private ObservableCollection<RadnoMesto> _radnoMestoList;

        public List<string> NaziviRadnihMesta
        {
            get { return _radnoMestoList.Select(x => x.NazivRadnoMesto).ToList(); }
        }

        public string SelectedRadnoMesto
        {
            get { return _selectedRadnoMesto; }
            set { _selectedRadnoMesto = value; }
        }

        public int IdRadnika
        {
            get { return _idRadnika; }
            set { _idRadnika = value; }
        }


        public string IdRadnoMesto
        {
            get { return _idRadnoMesto; }
            set { _idRadnoMesto = value; }
        }

        private ObservableCollection<RadnoMesto> RadnoMestoList
        {
            get { return _radnoMestoList; }
            set { _radnoMestoList = value; }
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
            get { return _isUpdateBtnVisible; }
            set { _isUpdateBtnVisible = value; }
        }

        public bool IsCreateBtnVisible
        {
            get { return _isCreateBtnVisible; }
            set { _isCreateBtnVisible = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public CreateRadnikProizvodnjaDialogViewModel(IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, ObservableCollection<RadnoMesto> radnoMestoList)
        {
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            RadnoMestoList = radnoMestoList;
            SelectedRadnoMesto = radnoMestoList[0].NazivRadnoMesto;

        }

        public CreateRadnikProizvodnjaDialogViewModel(IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, ObservableCollection<RadnoMesto> radnoMestoList, RadnikProizvodnja radnikProizvodnja)
        {
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
            IdRadnika = radnikProizvodnja.IDRadnik;
            ImeRadnika = radnikProizvodnja.ImeRadnika;
            PrezimeRadnika = radnikProizvodnja.PrezimeRadnika;
            Enum.TryParse(radnikProizvodnja.Pol, out Pol pol);
            SelectedType = pol;
            IdRadnoMesto = radnikProizvodnja.RadnoMesto.IDRadnoMesto.ToString();
            RadnoMestoList = radnoMestoList;
            SelectedRadnoMesto = radnikProizvodnja.RadnoMesto.NazivRadnoMesto;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radnika";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }

    }
}

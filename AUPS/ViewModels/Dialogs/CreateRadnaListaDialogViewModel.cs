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
    public class CreateRadnaListaDialogViewModel : BaseViewModel
    {
        private IRadnaListaSqlProvider _radnaListaSqlProvider;
        private string _title = "Dijalog za kreiranje radna lista";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private DateTime _datum;
        private string _kolicina;
        private int _idRadnika;
        private int _idRadniNalog;
        private int _idOperacija;
        private int _idRadneListe;
        private List<int> _radniNalogIds;
        private ObservableCollection<Operacija> _operacijaList;
        private ObservableCollection<RadnikProizvodnja> _radnikProizvodnjaList;

        public ObservableCollection<RadnikProizvodnja> RadnikProizvodnjaList
        {
            get { return _radnikProizvodnjaList; }
            set { _radnikProizvodnjaList = value; }
        }

        public String RadnikProizvodnjaSelected { get; set; }

        public List<string> RadnikProizvodnjaNazivi
        {
            get
            {
                List<string> nls = new List<string>();
                foreach(RadnikProizvodnja rp in RadnikProizvodnjaList)
                {
                    string nl = rp.ImeRadnika + ' ' + rp.PrezimeRadnika;
                    nls.Add(nl);
                }
                return nls;
            }
        }

        public ObservableCollection<Operacija> OperacijaList
        {
            get { return _operacijaList; }
            set { _operacijaList = value; }
        }

        public string SelectedOperacija { get; set; }

        public List<string> OperacijaNazivi
        {
            get { return OperacijaList.Select(x => x.NazivOperacije).ToList(); }
        }


        public List<int> RadniNalogIds
        {
            get { return _radniNalogIds; }
            set { _radniNalogIds = value; }
        }

        public int IdRadneListe
        {
            get { return _idRadneListe; }
            set { _idRadneListe = value; }
        }


        public int IdOperacija
        {
            get { return _idOperacija; }
            set { _idOperacija = value; }
        }


        public int SelectedIdRadniNalog
        {
            get { return _idRadniNalog; }
            set { _idRadniNalog = value; }
        }


        public int IdRadnika
        {
            get { return _idRadnika; }
            set { _idRadnika = value; }
        }


        public string Kolicina
        {
            get { return _kolicina; }
            set { _kolicina = value; }
        }


        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
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


        public CreateRadnaListaDialogViewModel(IRadnaListaSqlProvider radnaListaSqlProvider, List<int> radniNalogIds, ObservableCollection<Operacija> operacijaList, ObservableCollection<AUPS.Models.RadnikProizvodnja> radnikProizvodnjaList)
        {
            _radnaListaSqlProvider = radnaListaSqlProvider;
            SelectedIdRadniNalog = radniNalogIds.First();
            RadniNalogIds = radniNalogIds;
            _operacijaList = operacijaList;
            SelectedOperacija = operacijaList.First().NazivOperacije;
            RadnikProizvodnjaList = radnikProizvodnjaList;
            RadnikProizvodnjaSelected = RadnikProizvodnjaNazivi.First();
        }

        public CreateRadnaListaDialogViewModel(IRadnaListaSqlProvider radnaListaSqlProvider, List<int> radniNalogIds, ObservableCollection<Operacija> operacijaList, ObservableCollection<AUPS.Models.RadnikProizvodnja> radnikProizvodnjaList, RadnaLista radnaLista)
        {
            _radnaListaSqlProvider = radnaListaSqlProvider;
            IdRadneListe = radnaLista.IDRadnaLista;
            IdRadnika = radnaLista.Radnik.IDRadnik;
            SelectedIdRadniNalog = radnaLista.RadniNalog.IDRadniNalog;
            RadniNalogIds = radniNalogIds;
            Kolicina = radnaLista.Kolicina.ToString();
            Datum = radnaLista.Datum;
            IdOperacija = radnaLista.Operacija.IDOperacija;
            _operacijaList = operacijaList;
            SelectedOperacija = radnaLista.Operacija.NazivOperacije;
            RadnikProizvodnjaList = radnikProizvodnjaList;
            RadnikProizvodnjaSelected = RadnikProizvodnjaNazivi.First();
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radne liste";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

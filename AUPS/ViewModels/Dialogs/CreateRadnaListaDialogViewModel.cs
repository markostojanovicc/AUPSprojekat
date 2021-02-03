using AUPS.Commands;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadnaListaDialogViewModel : BaseViewModel
    {
        private IRadnaListaSqlProvider _radnaListaSqlProvider;
        private ICommand addButtonCommand;
        private ICommand updateButtonCommand;
        private string _title = "Dijalog za kreiranje radna lista";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private DateTime _datum = DateTime.UtcNow;
        private string _kolicina;
        private int _idRadniNalog;
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
                nls.Add(" ");
                return nls;
            }
        }

        public ObservableCollection<Operacija> OperacijaList
        {
            get { return _operacijaList; }
            set { _operacijaList = value; }
        }

        public int SelectedIndexOperacija { get; set; }
        public int SelectedIndexRadnikProizvodnja { get; set; }
        public int SelectedIndexRadniNalog { get; set; }

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
            get
            {
                return OperacijaList[SelectedIndexOperacija].IDOperacija;
            }
            set
            {
                IdOperacija = value;
            }
        }


        public int SelectedIdRadniNalog
        {
            get { return _idRadniNalog; }
            set { _idRadniNalog = value; }
        }


        public int IdRadnika
        {
            get
            {
                return RadnikProizvodnjaList.Count - 1 > SelectedIndexRadnikProizvodnja ? 
                    RadnikProizvodnjaList[SelectedIndexRadnikProizvodnja].IDRadnik : 0;
            }
            set { }
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

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(Kolicina) );
            }
        }

        public ICommand AddButtonCommand
        {
            get
            {
                if (addButtonCommand == null)
                {
                    this.addButtonCommand = new RelayCommand(
                        param => AddButtonCommandExecute(param));
                }

                return addButtonCommand;
            }
        }

        private void AddButtonCommandExecute(object param)
        {
            RadnaLista radnaLista = new RadnaLista()
            {
                Datum = _datum,
                Kolicina = Int32.Parse(_kolicina),
                Operacija = new Operacija { IDOperacija = IdOperacija },
                Radnik = IdRadnika == 0 ? null : new RadnikProizvodnja { IDRadnik = IdRadnika },
                RadniNalog = new RadniNalog { IDRadniNalog = _idRadniNalog }
            };

            _radnaListaSqlProvider.CreateRadnaListaById(radnaLista);
        }

        public ICommand UpdateButtonCommand
        {
            get
            {
                if (updateButtonCommand == null)
                {
                    this.updateButtonCommand = new RelayCommand(
                        param => UpdateButtonCommandExecute(param));
                }

                return updateButtonCommand;
            }
        }

        private void UpdateButtonCommandExecute(object param)
        {
            RadnaLista updatedRadnaLista = new RadnaLista()
            {
                IDRadnaLista = IdRadneListe,
                Datum = _datum,
                Kolicina = Int32.Parse(_kolicina),
                Operacija = new Operacija { IDOperacija = IdOperacija },
                Radnik = new RadnikProizvodnja { IDRadnik = IdRadnika },
                RadniNalog = new RadniNalog {IDRadniNalog = _idRadniNalog }
            };

            _radnaListaSqlProvider.UpdateRadnaListaById(updatedRadnaLista);
        }

        public CreateRadnaListaDialogViewModel(IRadnaListaSqlProvider radnaListaSqlProvider, List<int> radniNalogIds, ObservableCollection<Operacija> operacijaList, ObservableCollection<AUPS.Models.RadnikProizvodnja> radnikProizvodnjaList)
        {
            _radnaListaSqlProvider = radnaListaSqlProvider;
            SelectedIdRadniNalog = radniNalogIds.First();
            RadniNalogIds = radniNalogIds;
            _operacijaList = operacijaList;
            SelectedIndexOperacija = 0;
            RadnikProizvodnjaList = radnikProizvodnjaList;
            SelectedIndexRadnikProizvodnja = radnikProizvodnjaList.Count;
        }

        public CreateRadnaListaDialogViewModel(IRadnaListaSqlProvider radnaListaSqlProvider, List<int> radniNalogIds, ObservableCollection<Operacija> operacijaList, ObservableCollection<AUPS.Models.RadnikProizvodnja> radnikProizvodnjaList, RadnaLista radnaLista)
        {
            _radnaListaSqlProvider = radnaListaSqlProvider;
            IdRadneListe = radnaLista.IDRadnaLista;
            SelectedIdRadniNalog = radnaLista.RadniNalog.IDRadniNalog;
            RadniNalogIds = radniNalogIds;
            Kolicina = radnaLista.Kolicina.ToString();
            Datum = radnaLista.Datum;
            _operacijaList = operacijaList;
            SelectedIndexOperacija = operacijaList.IndexOf(operacijaList.First(x=> x.IDOperacija==radnaLista.Operacija.IDOperacija));
            RadnikProizvodnjaList = radnikProizvodnjaList;
            SelectedIndexRadnikProizvodnja = radnikProizvodnjaList.IndexOf(radnikProizvodnjaList.FirstOrDefault(x => x.IDRadnik == radnaLista.Radnik?.IDRadnik));
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radne liste";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

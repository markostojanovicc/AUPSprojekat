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
    public class CreateTehnoloskiPostupakViewModel : BaseViewModel
    {
        private ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider;
        private string _title = "Dijalog za kreiranje tehnoloskog postupka";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _tipTehnoloskogPostupka;
        private string _vremeIzrade;
        private string _serijaKom;
        private string _brKom;
        private int _idOperacije;
        private int _idTehnoloskogPostupka;
        private ObservableCollection<Operacija> _operacijaList;
        private string _selectedOperacija;

        public string SelectedOperacija
        {
            get { return _selectedOperacija; }
            set { _selectedOperacija = value; }
        }

        public List<string> NaziviOperacija
        {
            get { return OperacijaList.Select(x => x.NazivOperacije).ToList(); }
        }

        public ObservableCollection<Operacija> OperacijaList
        {
            get { return _operacijaList; }
            set { _operacijaList = value; }
        }

        public int IdTehnoloskogPostupka
        {
            get { return _idTehnoloskogPostupka; }
            set { _idTehnoloskogPostupka = value; }
        }


        public int IdOperacije
        {
            get { return _idOperacije; }
            set { _idOperacije = value; }
        }


        public string BrKom
        {
            get { return _brKom; }
            set { _brKom = value; }
        }


        public string SerijaKom
        {
            get { return _serijaKom; }
            set { _serijaKom = value; }
        }


        public string VremeIzrade
        {
            get { return _vremeIzrade; }
            set { _vremeIzrade = value; }
        }


        public string TipTehnoloskogPostupka
        {
            get { return _tipTehnoloskogPostupka; }
            set { _tipTehnoloskogPostupka = value; }
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


        public CreateTehnoloskiPostupakViewModel(ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ObservableCollection<Operacija> operacijaList)
        {
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            OperacijaList = operacijaList;
            SelectedOperacija = operacijaList.First().NazivOperacije;
        }

        public CreateTehnoloskiPostupakViewModel(ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ObservableCollection<Operacija> operacijaList, TehnoloskiPostupak tehnoloskiPostupak)
        {
            _tehnoloskiPostupakSqlProvider = tehnoloskiPostupakSqlProvider;
            IdTehnoloskogPostupka = tehnoloskiPostupak.IDTehPostupak;
            TipTehnoloskogPostupka = tehnoloskiPostupak.TipTehPostupak;
            VremeIzrade = tehnoloskiPostupak.VremeIzrade.ToString();
            SerijaKom = tehnoloskiPostupak.SerijaKom.ToString();
            BrKom = tehnoloskiPostupak.BrKomada.ToString();
            IdOperacije = tehnoloskiPostupak.Operacija.IDOperacija;
            OperacijaList = operacijaList;
            SelectedOperacija = tehnoloskiPostupak.Operacija.NazivOperacije;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu tehnoloski postupak";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

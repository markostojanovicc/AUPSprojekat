using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
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
        private string _idRadnika;
        private string _idRadniNalog;
        private string _idOperacija;

        public string IdOperacija
        {
            get { return _idOperacija; }
            set { _idOperacija = value; }
        }


        public string IdRadniNalog
        {
            get { return _idRadniNalog; }
            set { _idRadniNalog = value; }
        }


        public string IdRadnika
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


        public CreateRadnaListaDialogViewModel(IRadnaListaSqlProvider radnaListaSqlProvider)
        {
            _radnaListaSqlProvider = radnaListaSqlProvider;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radne liste";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

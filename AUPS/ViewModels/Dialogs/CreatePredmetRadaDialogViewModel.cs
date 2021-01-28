using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.Dialogs
{
    public class CreatePredmetRadaDialogViewModel : BaseViewModel
    {
        private IPredmetRadaSqlProvider _predmetRadaSqlProvider;
        private string _title = "Dijalog za kreiranje predmeta rada";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _tipPredmetaRada;
        private string _nazivPR;
        private string _jedMere;
        private string _cena;

        public string Cena
        {
            get { return _cena; }
            set { _cena = value; }
        }


        public string JedMere
        {
            get { return _jedMere; }
            set { _jedMere = value; }
        }


        public string NazivPR
        {
            get { return _nazivPR; }
            set { _nazivPR = value; }
        }


        public string TipPredmetaRada
        {
            get { return _tipPredmetaRada; }
            set { _tipPredmetaRada = value; }
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


        public CreatePredmetRadaDialogViewModel(IPredmetRadaSqlProvider predmetRadaSqlProvider)
        {
            _predmetRadaSqlProvider = predmetRadaSqlProvider;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu predmeta rada";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

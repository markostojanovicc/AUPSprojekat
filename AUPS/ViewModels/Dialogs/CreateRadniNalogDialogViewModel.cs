using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadniNalogDialogViewModel : BaseViewModel
    {
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        private string _title = "Dijalog za kreiranje radnog naloga";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private DateTime _datumIzlaza;
        private DateTime _datumUlaza;
        private string _kolicinaProizvoda;
        private string _idPredmetaRada;
        private int _idRadniNalog;

        public int IdRadniNalog
        {
            get { return _idRadniNalog; }
            set { _idRadniNalog = value; }
        }


        public string IdPredmetaRada
        {
            get { return _idPredmetaRada; }
            set { _idPredmetaRada = value; }
        }

        public string KolicinaProizvoda
        {
            get { return _kolicinaProizvoda; }
            set { _kolicinaProizvoda = value; }
        }


        public DateTime DatumUlaza
        {
            get { return _datumUlaza; }
            set { _datumUlaza = value; }
        }


        public DateTime DatumIzlaza
        {
            get { return _datumIzlaza; }
            set { _datumIzlaza = value; }
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


        public CreateRadniNalogDialogViewModel(IRadniNalogSqlProvider radniNalogSqlProvider)
        {
            _radniNalogSqlProvider = radniNalogSqlProvider;
        }

        public CreateRadniNalogDialogViewModel(IRadniNalogSqlProvider radniNalogSqlProvider, RadniNalog radniNalog)
        {
            _radniNalogSqlProvider = radniNalogSqlProvider;
            IdRadniNalog = radniNalog.IDRadniNalog;
            DatumUlaza = radniNalog.DatumUlaz;
            DatumIzlaza = radniNalog.DatumIzlaz;
            KolicinaProizvoda = radniNalog.KolicinaProizvoda.ToString();
            IdPredmetaRada = radniNalog.IDPredmetRada.ToString();
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radni nalog";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

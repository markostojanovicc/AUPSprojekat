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
    public class CreateRadniNalogDialogViewModel : BaseViewModel
    {
        private IRadniNalogSqlProvider _radniNalogSqlProvider;
        private string _title = "Dijalog za kreiranje radnog naloga";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private DateTime _datumIzlaza;
        private DateTime _datumUlaza;
        private string _kolicinaProizvoda;
        private int _idPredmetaRada;
        private int _idRadniNalog;
        private ObservableCollection<PredmetRada> _predmetRadaList;
        private string _selectedPredmetRada;

        public string SelectedPredmetRada
        {
            get { return _selectedPredmetRada; }
            set { _selectedPredmetRada = value; }
        }

        public List<string> NaziviPredmetaRada 
        {
            get { return PredmetRadaList.Select(x => x.NazivPR).ToList(); }
        }


        public ObservableCollection<PredmetRada> PredmetRadaList
        {
            get { return _predmetRadaList; }
            set { _predmetRadaList = value; }
        }


        public int IdRadniNalog
        {
            get { return _idRadniNalog; }
            set { _idRadniNalog = value; }
        }


        public int IdPredmetaRada
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


        public CreateRadniNalogDialogViewModel(IRadniNalogSqlProvider radniNalogSqlProvider, ObservableCollection<PredmetRada> predmetRadaList)
        {
            _radniNalogSqlProvider = radniNalogSqlProvider;
            PredmetRadaList = predmetRadaList;
            SelectedPredmetRada = predmetRadaList[0].NazivPR;
        }

        public CreateRadniNalogDialogViewModel(IRadniNalogSqlProvider radniNalogSqlProvider, ObservableCollection<PredmetRada> predmetRadaList, RadniNalog radniNalog)
        {
            _radniNalogSqlProvider = radniNalogSqlProvider;
            IdRadniNalog = radniNalog.IDRadniNalog;
            DatumUlaza = radniNalog.DatumUlaz;
            DatumIzlaza = radniNalog.DatumIzlaz;
            KolicinaProizvoda = radniNalog.KolicinaProizvoda.ToString();
            IdPredmetaRada = radniNalog.PredmetRada.IDPredmetRada;
            PredmetRadaList = predmetRadaList;
            SelectedPredmetRada = radniNalog.PredmetRada.NazivPR;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radni nalog";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

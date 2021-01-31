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
    public class CreateTrebovanjeDialogViewModel : BaseViewModel
    {
        private ITrebovanjeSqlProvider _trebovanjeSqlProvider;
        private string _title = "Dijalog za kreiranje trebovanje";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private string _tipTrebovanja;
        private string _jedMere;
        private string _kolicinaRobe;
        private string _idRadniNalog;
        private int _idTrebovanje;
        List<int> _radniNalogIds;

        public List<string> IdRadnihNaloga
        {
            get { return _radniNalogIds.Select(x => x.ToString()).ToList(); }
        }

        public int IdTrebovanja
        {
            get { return _idTrebovanje; }
            set { _idTrebovanje = value; }
        }


        public string SelectedRadniNalog
        {
            get { return _idRadniNalog; }
            set { _idRadniNalog = value; }
        }


        public string KolicinaRobe
        {
            get { return _kolicinaRobe; }
            set { _kolicinaRobe = value; }
        }


        public string JedinicaMere
        {
            get { return _jedMere; }
            set { _jedMere = value; }
        }


        public string TipTrebovanja
        {
            get { return _tipTrebovanja; }
            set { _tipTrebovanja = value; }
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

        public CreateTrebovanjeDialogViewModel(ITrebovanjeSqlProvider trebovanjeSqlProvider, List<int> radniNalogIds)
        {
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
            _radniNalogIds = radniNalogIds;
            SelectedRadniNalog = _radniNalogIds.First().ToString();
        }

        public CreateTrebovanjeDialogViewModel(ITrebovanjeSqlProvider trebovanjeSqlProvider, List<int> radniNalogIds, Trebovanje trebovanje)
        {
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
            IdTrebovanja = trebovanje.IDTrebovanje;
            TipTrebovanja = trebovanje.TipTrebovanja;
            JedinicaMere = trebovanje.JedMere;
            KolicinaRobe = trebovanje.KolicinaRobe.ToString();
            _radniNalogIds = radniNalogIds;
            SelectedRadniNalog = trebovanje.RadniNalog.IDRadniNalog.ToString();
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu trebovanja";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

using AUPS.Commands;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        private int _idRadniNalog;
        private int _idTrebovanje;
        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;
        List<int> _radniNalogIds;

        public List<string> IdRadnihNaloga
        {
            get { return _radniNalogIds.Select(x => x.ToString()).ToList(); }
        }

        public bool CanExecuteBtnCommand
        {
            get
            {
                return !(string.IsNullOrEmpty(TipTrebovanja) || string.IsNullOrEmpty(JedinicaMere) || string.IsNullOrEmpty(KolicinaRobe));
            }
        }

        public int IdTrebovanja
        {
            get { return _idTrebovanje; }
            set { _idTrebovanje = value; }
        }


        public int SelectedRadniNalog
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
        }

        public CreateTrebovanjeDialogViewModel(ITrebovanjeSqlProvider trebovanjeSqlProvider, List<int> radniNalogIds, Trebovanje trebovanje)
        {
            _trebovanjeSqlProvider = trebovanjeSqlProvider;
            IdTrebovanja = trebovanje.IDTrebovanje;
            TipTrebovanja = trebovanje.TipTrebovanja;
            JedinicaMere = trebovanje.JedMere;
            KolicinaRobe = trebovanje.KolicinaRobe.ToString();
            _radniNalogIds = radniNalogIds;
            SelectedRadniNalog = trebovanje.RadniNalog.IDRadniNalog;
        }

        public ICommand AddButtonCommand
        {
            get
            {
                if (_createButtonCommand == null)
                {
                    this._createButtonCommand = new RelayCommand(
                        param => CreateButtonCommandExecute(param));
                }

                return _createButtonCommand;
            }
        }

        public ICommand UpdateButtonCommand
        {
            get
            {
                if (_updateButtonCommand == null)
                {
                    this._updateButtonCommand = new RelayCommand(
                        param => UpdateButtonCommandExecute(param));
                }

                return _updateButtonCommand;
            }
        }

        private void UpdateButtonCommandExecute(object param)
        {
            Trebovanje trebovanje = new Trebovanje
            {
                IDTrebovanje = _idTrebovanje,
                JedMere = _jedMere,
                KolicinaRobe = Int32.Parse(_kolicinaRobe),
                TipTrebovanja = _tipTrebovanja,
                RadniNalog = new RadniNalog { IDRadniNalog = SelectedRadniNalog }
            };
            _trebovanjeSqlProvider.UpdateTrebovanjeById(trebovanje);
        }

        private void CreateButtonCommandExecute(object param)
        {
            Trebovanje trebovanje = new Trebovanje
            {
                JedMere = _jedMere,
                KolicinaRobe = Int32.Parse(_kolicinaRobe),
                TipTrebovanja = _tipTrebovanja,
                RadniNalog = new RadniNalog { IDRadniNalog = SelectedRadniNalog }
            };
            _trebovanjeSqlProvider.CreateTrebovanjeById(trebovanje);
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu trebovanja";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

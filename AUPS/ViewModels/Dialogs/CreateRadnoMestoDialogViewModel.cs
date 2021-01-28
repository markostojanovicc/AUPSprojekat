using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadnoMestoDialogViewModel : BaseViewModel
    {
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;
        private string _title = "Dijalog za kreiranje radnog mesta";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;

        public bool IsUpdateBtnVisible
        {
            get { return _isUpdateBtnVisible = false; }
            set { _isUpdateBtnVisible = value; }
        }

        public bool IsCreateButtonVisible
        {
            get { return _isCreateBtnVisible = true; }
            set { _isCreateBtnVisible = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public CreateRadnoMestoDialogViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radnog mesta";
            IsCreateButtonVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

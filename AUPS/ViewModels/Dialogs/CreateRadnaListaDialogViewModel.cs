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


        public CreateRadnaListaDialogViewModel(IRadnaListaSqlProvider radnaListaSqlProvider)
        {
            _radnaListaSqlProvider = radnaListaSqlProvider;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radne liste";
            IsCreateButtonVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

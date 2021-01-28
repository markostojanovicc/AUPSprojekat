using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateOperacijaDialogViewModel : BaseViewModel
    {
        private IOperacijaSqlProvider _operacijaSqlProvider;
        private string _title = "Dijalog za kreiranje operacije";
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


        public CreateOperacijaDialogViewModel(IOperacijaSqlProvider operacijaSqlProvider)
        {
            _operacijaSqlProvider = operacijaSqlProvider;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu operacije";
            IsCreateButtonVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

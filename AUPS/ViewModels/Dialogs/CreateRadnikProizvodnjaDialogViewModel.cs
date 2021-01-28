﻿using AUPS.Enums;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateRadnikProizvodnjaDialogViewModel : BaseViewModel
    {
        private List<Pol> _polovi = new List<Pol>() { Pol.Musko, Pol.Zensko };
        private IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider;
        private string _title = "Dijalog za kreiranje radnika";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;

        public List<Pol> Polovi
        {
            get { return _polovi; }
            set { }
        }

        private Pol _selectedType;

        public Pol SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(Polovi));
            }
        }

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


        public CreateRadnikProizvodnjaDialogViewModel(IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider)
        {
            _radnikProizvodnjaSqlProvider = radnikProizvodnjaSqlProvider;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radnika";
            IsCreateButtonVisible = false;
            IsUpdateBtnVisible = true;
        }

    }
}

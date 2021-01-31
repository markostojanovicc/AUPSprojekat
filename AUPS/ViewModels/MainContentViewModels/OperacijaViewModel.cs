﻿using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class OperacijaViewModel : BaseViewModel
    {
        private Operacija _itemSelected;

        public Operacija ItemSelected
        {
            get { return _itemSelected; }
            set { _itemSelected = value; }
        }

        private ObservableCollection<Operacija> _operacijaList;
        private IOperacijaSqlProvider _operacijaSqlProvider;

        public ObservableCollection<Operacija> OperacijaList
        {
            get { return _operacijaList; }
            set
            {
                _operacijaList = value;
                OnPropertyChanged(nameof(Operacija));
            }
        }

        public OperacijaViewModel()
        {
        }
    }
}

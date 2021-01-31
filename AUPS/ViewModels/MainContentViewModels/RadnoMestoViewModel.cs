﻿using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.ObjectModel;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class RadnoMestoViewModel : BaseViewModel
    {
        private RadnoMesto _itemSelected;

        public RadnoMesto ItemSelected
        {
            get { return _itemSelected; }
            set { _itemSelected = value; }
        }

        private ObservableCollection<RadnoMesto> _radnoMestoList;
        public ObservableCollection<RadnoMesto> RadnoMestoList
        {
            get { return _radnoMestoList; }
            set
            {
                _radnoMestoList = value;
                OnPropertyChanged(nameof(RadnoMestoList));
            }
        }

        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;

       

        public RadnoMestoViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider, ObservableCollection<RadnoMesto> _radnoMestoList)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            RadnoMestoList = _radnoMestoList;
        }
    }
}

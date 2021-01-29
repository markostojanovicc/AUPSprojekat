﻿using AUPS.Models;
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
        private string _nazivRadnogMesta;
        private string _strucnaSprema;
        private int _idRadnogMesta;

        public int IdRadnogMesta
        {
            get { return _idRadnogMesta; }
            set { _idRadnogMesta = value; }
        }


        public string StrucnaSprema
        {
            get { return _strucnaSprema; }
            set { _strucnaSprema = value; }
        }


        public string NazivRadnogMesta
        {
            get { return _nazivRadnogMesta; }
            set { _nazivRadnogMesta = value; }
        }     

        public bool IsUpdateBtnVisible
        {
            get { return _isUpdateBtnVisible = false; }
            set { _isUpdateBtnVisible = value; }
        }

        public bool IsCreateBtnVisible
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

        public CreateRadnoMestoDialogViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider, RadnoMesto radnoMesto)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            _idRadnogMesta = radnoMesto.IDRadnoMesto;
            _nazivRadnogMesta = radnoMesto.NazivRadnoMesto;
            _strucnaSprema = radnoMesto.StrucnaSprema;
        }

        public void SetViewForUpdateDialog()
        {
            Title = "Dijalog za izmenu radnog mesta";
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
        }
    }
}

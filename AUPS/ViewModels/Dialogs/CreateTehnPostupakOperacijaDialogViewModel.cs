using AUPS.Commands;
using AUPS.Event;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AUPS.ViewModels.Dialogs
{
    public class CreateTehnPostupakOperacijaDialogViewModel : BaseViewModel
    {
        private string _title = "Dijalog za izmenu strukture tehnoloskog postupka";
        private bool _isCreateBtnVisible = true;
        private bool _isUpdateBtnVisible = false;
        private int _rbrSelected;
        private int _idTehnPostupakOperacija;

        private ICommand _updateButtonCommand;
        private ICommand _createButtonCommand;

        private readonly ITehnPostupakOperacijaSqlProvider _tehnPostupakOperacijaSqlProvider;

        public delegate void ChangeOperationSuccededEventHandler(object source, TehPostupakOperacijaEventArgs args);
        public event ChangeOperationSuccededEventHandler ChangeOperationSucceded;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
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

        public ObservableCollection<Operacija> OperacijaList { get; set; }
        public ObservableCollection<TehnoloskiPostupak> TehnoloskiPostupakList { get; set; }
        public List<int> RBrOperacijeList { get; set; }
        public int RBrSelected 
        {
            get { return _rbrSelected; }
            set { _rbrSelected = value; OnPropertyChanged(nameof(RBrSelected)); } 
        }

        public Operacija SelectedOperacija { get; set; }
        public TehnoloskiPostupak SelectedTehnoloskiPostupak { get; set; }

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

        private void CreateButtonCommandExecute(object param)
        {
            TehnPostupakOperacija tehnPostupakOperacija = new TehnPostupakOperacija
            {
                Operacija = new Operacija { IDOperacija = SelectedOperacija.IDOperacija},
                TehnoloskiPostupak = new TehnoloskiPostupak { IDTehPostupak = SelectedTehnoloskiPostupak.IDTehPostupak},
                RBrOperacije = RBrSelected
            };

            _tehnPostupakOperacijaSqlProvider.CreateTehnPostupakOperacijaById(tehnPostupakOperacija);

            if (ChangeOperationSucceded != null)
                ChangeOperationSucceded(this, new TehPostupakOperacijaEventArgs { TehnPostupakOperacija = tehnPostupakOperacija, isCreated = true });

            Window curWindow = (Window)param;
            curWindow.Close();
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
            TehnPostupakOperacija tehnPostupakOperacija = new TehnPostupakOperacija
            {
                IDTehnPostupakOperacija = _idTehnPostupakOperacija,
                Operacija = new Operacija { IDOperacija = SelectedOperacija.IDOperacija },
                TehnoloskiPostupak = new TehnoloskiPostupak { IDTehPostupak = SelectedTehnoloskiPostupak.IDTehPostupak },
                RBrOperacije = RBrSelected
            };

            _tehnPostupakOperacijaSqlProvider.UpdateTehnPostupakOperacija(tehnPostupakOperacija);

            if (ChangeOperationSucceded != null)
                ChangeOperationSucceded(this, new TehPostupakOperacijaEventArgs { TehnPostupakOperacija = tehnPostupakOperacija, isCreated = false });

            Window curWindow = (Window)param;
            curWindow.Close();
        }

        public CreateTehnPostupakOperacijaDialogViewModel(ITehnPostupakOperacijaSqlProvider tehnPostupakOperacijaSqlProvider,
             ObservableCollection<Operacija> operacijaList,
             ObservableCollection<TehnoloskiPostupak> tehnoloskiPostupakList, int maxRBr, TehnPostupakOperacija selected)
        {
            _tehnPostupakOperacijaSqlProvider = tehnPostupakOperacijaSqlProvider;
            OperacijaList = operacijaList;
            TehnoloskiPostupakList = tehnoloskiPostupakList;
            if (selected != null)
            {
                SetViewForUpdateDialog(selected);
                maxRBr--;
            } 
            CreateRBrList(maxRBr);
        }

        public void SetViewForUpdateDialog(TehnPostupakOperacija selected)
        {
            IsCreateBtnVisible = false;
            IsUpdateBtnVisible = true;
            RBrSelected = selected.RBrOperacije;
            SelectedOperacija = OperacijaList.First(x => x.IDOperacija == selected.Operacija.IDOperacija);
            SelectedTehnoloskiPostupak = TehnoloskiPostupakList.First(x => x.IDTehPostupak == selected.TehnoloskiPostupak.IDTehPostupak);
            _idTehnPostupakOperacija = selected.IDTehnPostupakOperacija;
        }

        private void CreateRBrList(int maxRb)
        {
            RBrOperacijeList = new List<int>();
            for (int i = 1; i <= maxRb; i++)
            {
                RBrOperacijeList.Add(i);
            }
        }

    }
}

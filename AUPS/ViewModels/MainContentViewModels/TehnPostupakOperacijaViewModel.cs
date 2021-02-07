using AUPS.Dialogs.ErrorDialogs;
using AUPS.Dialogs.TehnPostupakOperacija;
using AUPS.Event;
using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AUPS.ViewModels.MainContentViewModels
{
    public class TehnPostupakOperacijaViewModel : BaseViewModel
    {
        private readonly ITehnPostupakOperacijaSqlProvider _tehnPostupakOperacijaSqlProvider;
        private int _tehnPostupakSelected = 0;
        private List<TehnPostupakOperacija> _tehnPostupakOperacijas;
        private ObservableCollection<TehnPostupakOperacija> tpoList;

        public delegate void DataShouldBeRefreshedEventHandler(object source, EventArgs args);
        public event DataShouldBeRefreshedEventHandler DataShouldBeRefreshed;

        public TehnPostupakOperacijaViewModel(ITehnPostupakOperacijaSqlProvider tehnPostupakOperacijaSqlProvider
            ,ObservableCollection<TehnoloskiPostupak> tehnoloskiPostupakList)
        {
            _tehnPostupakOperacijaSqlProvider = tehnPostupakOperacijaSqlProvider;
            TehnoloskiPostupakList = tehnoloskiPostupakList;
        }

        public ObservableCollection<TehnPostupakOperacija> TpoList { get { return tpoList; } 
            set 
            {
                tpoList = value;
                OnPropertyChanged(nameof(TpoListFilterd)); 
            } 
        }

        public TehnPostupakOperacija ItemSelected { get; set; }

        public List<string> TipTehPostupkaList
        {
            get { return TehnoloskiPostupakList.Select(x => x.TipTehPostupak).ToList(); }
        }

        public List<TehnPostupakOperacija> TpoListFilterd
        {
            get 
            { 
                return TpoList.Where(x => x.TehnoloskiPostupak.IDTehPostupak == TehnoloskiPostupakList[TehnPostupakSelectedIndex].IDTehPostupak).ToList();
            }
            
        }
        public ObservableCollection<TehnoloskiPostupak> TehnoloskiPostupakList { get; set; }

        public int TehnPostupakSelectedIndex
        {
            get { return _tehnPostupakSelected; }
            set { _tehnPostupakSelected = value; }
        }

        public void AddValueForRbrOperacije(List<TehnPostupakOperacija> listForUpdate)
        {
            foreach (TehnPostupakOperacija tpo in listForUpdate)
            {
                tpo.RBrOperacije++;
                _tehnPostupakOperacijaSqlProvider.UpdateRBrOperacijaFromTehnPostupakOperacija(tpo);
            }            
        }

        public void SubtractValueForRbrOperacije(List<TehnPostupakOperacija> listForUpdate)
        {
            foreach (TehnPostupakOperacija tpo in listForUpdate)
            {
                tpo.RBrOperacije--;
                _tehnPostupakOperacijaSqlProvider.UpdateRBrOperacijaFromTehnPostupakOperacija(tpo);
            }
        }

        public void DeleteSelected()
        {
            bool isDeleted = _tehnPostupakOperacijaSqlProvider.DeleteFromTehnPostupakOperacijaById(ItemSelected.IDTehnPostupakOperacija);

            SubtractValueForRbrOperacije(TpoListFilterd.Where(x => x.RBrOperacije > ItemSelected.RBrOperacije).ToList());

            if (isDeleted)
            {
                TpoList.Remove(ItemSelected);
                OnPropertyChanged(nameof(TpoListFilterd));
            }
            else
            {
                ErrorDialog errorDialog = new ErrorDialog();
                ErrorDialogViewModel errorDialogViewModel = (ErrorDialogViewModel)errorDialog.DataContext;
                errorDialog.Title = "Greška";
                errorDialogViewModel.ErrorMessage = "Pokusaj brisanja selektovanog reda nije uspeo.";
                errorDialog.ShowDialog();
            }
        }

        public void OpenDialog(ObservableCollection<AUPS.Models.Operacija> operacijaList,
             ObservableCollection<AUPS.Models.TehnoloskiPostupak> tehnoloskiPostupakList, bool isCreate)
        {
            CreateTehnPostupakOperacijaDialog createTehnPostupakOperacijaDialog = new CreateTehnPostupakOperacijaDialog(_tehnPostupakOperacijaSqlProvider,
                operacijaList, tehnoloskiPostupakList, TpoListFilterd.Count>0 ? TpoListFilterd.Max(x => x.RBrOperacije)+1 : 1, isCreate ? null : ItemSelected);
            CreateTehnPostupakOperacijaDialogViewModel viewmodel = (CreateTehnPostupakOperacijaDialogViewModel) createTehnPostupakOperacijaDialog.DataContext;
            viewmodel.ChangeOperationSucceded += CreateTehnPostupakOperacijaDialogViewModel_ChangeOperationSucceded;
            createTehnPostupakOperacijaDialog.ShowDialog();
            
        }

        private void CreateTehnPostupakOperacijaDialogViewModel_ChangeOperationSucceded(object source, TehPostupakOperacijaEventArgs args)
        {
            if (args.isCreated && args.TehnPostupakOperacija.RBrOperacije<TpoListFilterd.Count-1)
            {
                AddValueForRbrOperacije(TpoListFilterd.Where(x => x.RBrOperacije >= args.TehnPostupakOperacija.RBrOperacije).ToList());
            }
            else if(!args.isCreated && args.TehnPostupakOperacija.RBrOperacije != ItemSelected.RBrOperacije)
            {
                if (args.TehnPostupakOperacija.RBrOperacije > ItemSelected.RBrOperacije)
                {
                    SubtractValueForRbrOperacije(TpoListFilterd.Where(x => x.RBrOperacije <= args.TehnPostupakOperacija.RBrOperacije && x.RBrOperacije > ItemSelected.RBrOperacije).ToList());
                }
                else
                {
                    AddValueForRbrOperacije(TpoListFilterd.Where(x => x.RBrOperacije >= args.TehnPostupakOperacija.RBrOperacije && x.RBrOperacije < ItemSelected.RBrOperacije).ToList());
                }
            }
            if(DataShouldBeRefreshed != null)
                DataShouldBeRefreshed(this, EventArgs.Empty);
        }
    }
}

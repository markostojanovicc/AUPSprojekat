using AUPS.Models;
using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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

        public ObservableCollection<Operacija> OperacijaList
        {
            get { return _operacijaList; }
            set
            {
                _operacijaList = value;
                SetView();
                OnPropertyChanged(nameof(Operacija));
            }
        }

        private void SetView()
        {
            OperacijaCollectionView = CollectionViewSource.GetDefaultView(OperacijaList);

            OperacijaCollectionView.Filter = FilterOperacija;
        }

        private string _filter = string.Empty;

        public string Filter
        {
            get { return _filter; }
            set 
            { 
                _filter = value;
                SetView();
            }
        }


        public ICollectionView OperacijaCollectionView;

        public OperacijaViewModel()
        {
            
        }

        private bool FilterOperacija(object obj)
        {
            if(obj is Operacija operacija)
            {
                return operacija.NazivOperacije.Contains(Filter);
            }
            return false;
        }
    }
}

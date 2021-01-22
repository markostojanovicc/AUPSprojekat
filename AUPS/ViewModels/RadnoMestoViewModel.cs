using AUPS.SqlProviders.Interfaces;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS
{
    public class RadnoMestoViewModel : BaseViewModel
    {
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;
        private int _selectedTabIndex;

        private DataTable _dataTable = new DataTable();

        public DataTable DataTable { get { return _dataTable; } }

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { _selectedTabIndex = value; }
        }


        public RadnoMestoViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider)
        {
            _radnoMestoSqlProvider = radnoMestoSqlProvider;
            FillTableWithData();
            
        }

        private void FillTableWithData()
        {
            _radnoMestoSqlProvider.GetAllFromRadnoMesto(ref _dataTable);
        }
    }
}

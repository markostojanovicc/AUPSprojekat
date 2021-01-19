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
    public class MainWindowViewModel : BaseViewModel
    {
        private IRadnoMestoSqlProvider _radnoMestoSqlProvider;

        private DataTable _dataTable = new DataTable();

        public DataTable DataTable { get { return _dataTable; } }

        public MainWindowViewModel(IRadnoMestoSqlProvider radnoMestoSqlProvider)
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

using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AUPS.Dialogs.RadniNalog
{
    /// <summary>
    /// Interaction logic for CreateRadniNalogDialog.xaml
    /// </summary>
    public partial class CreateRadniNalogDialog : Window
    {
        public CreateRadniNalogDialog(IRadniNalogSqlProvider _radniNalogSqlProvider
            , ObservableCollection<AUPS.Models.PredmetRada> predmetRadaList, MainContentViewModel main)
        {
            InitializeComponent();
            DataContext = new CreateRadniNalogDialogViewModel(_radniNalogSqlProvider, predmetRadaList, main);
        }

        public CreateRadniNalogDialog(IRadniNalogSqlProvider _radniNalogSqlProvider, ObservableCollection<AUPS.Models.PredmetRada> predmetRadaList, AUPS.Models.RadniNalog radniNalog
            , MainContentViewModel main)
        {
            InitializeComponent();
            DataContext = new CreateRadniNalogDialogViewModel(_radniNalogSqlProvider, predmetRadaList, radniNalog, main);
        }
    }
}

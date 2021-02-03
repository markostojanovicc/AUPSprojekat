using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;

namespace AUPS.Dialogs.TehnoloskiPostupak
{
    /// <summary>
    /// Interaction logic for CreateTehnoloskiPostupakDialog.xaml
    /// </summary>
    public partial class CreateTehnoloskiPostupakDialog : Window
    {
        public CreateTehnoloskiPostupakDialog(ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider, ObservableCollection<AUPS.Models.Operacija> operacijaList)
        {
            InitializeComponent();
            DataContext = new CreateTehnoloskiPostupakViewModel(_tehnoloskiPostupakSqlProvider, operacijaList);
        }

        public CreateTehnoloskiPostupakDialog(ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider, ObservableCollection<AUPS.Models.Operacija> operacijaList, AUPS.Models.TehnoloskiPostupak tehnoloskiPostupak)
        {
            InitializeComponent();
            DataContext = new CreateTehnoloskiPostupakViewModel(_tehnoloskiPostupakSqlProvider, operacijaList, tehnoloskiPostupak);
        }
    }
}

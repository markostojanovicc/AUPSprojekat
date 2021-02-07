using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;

namespace AUPS.Dialogs.TehnPostupakOperacija
{
    /// <summary>
    /// Interaction logic for CreateTehnPostupakOperacijaDialog.xaml
    /// </summary>
    public partial class CreateTehnPostupakOperacijaDialog : Window
    {
        public CreateTehnPostupakOperacijaDialog(ITehnPostupakOperacijaSqlProvider tehnPostupakOperacijaSqlProvider,
            ObservableCollection<AUPS.Models.Operacija> operacijaList,
             ObservableCollection<AUPS.Models.TehnoloskiPostupak> tehnoloskiPostupakList, int maxRBr)
        {
            InitializeComponent();

            DataContext = new CreateTehnPostupakOperacijaDialogViewModel(tehnPostupakOperacijaSqlProvider,
                operacijaList, tehnoloskiPostupakList, maxRBr);
        }
    }
}

using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Windows;

namespace AUPS.Dialogs.PredmetRada
{
    /// <summary>
    /// Interaction logic for CreatePredmetRadaDialog.xaml
    /// </summary>
    public partial class CreatePredmetRadaDialog : Window
    {
        public CreatePredmetRadaDialog(IPredmetRadaSqlProvider _predmetRadaSqlProvider)
        {
            InitializeComponent();
            DataContext = new CreatePredmetRadaDialogViewModel(_predmetRadaSqlProvider);
        }

        public CreatePredmetRadaDialog(IPredmetRadaSqlProvider _predmetRadaSqlProvider, AUPS.Models.PredmetRada predmetRada)
        {
            InitializeComponent();
            DataContext = new CreatePredmetRadaDialogViewModel(_predmetRadaSqlProvider, predmetRada);
        }
    }
}

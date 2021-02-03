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
        public CreatePredmetRadaDialog(IPredmetRadaSqlProvider _predmetRadaSqlProvider, MainContentViewModel main)
        {
            InitializeComponent();
            DataContext = new CreatePredmetRadaDialogViewModel(_predmetRadaSqlProvider, main);
        }

        public CreatePredmetRadaDialog(IPredmetRadaSqlProvider _predmetRadaSqlProvider, AUPS.Models.PredmetRada predmetRada,
            MainContentViewModel main)
        {
            InitializeComponent();
            DataContext = new CreatePredmetRadaDialogViewModel(_predmetRadaSqlProvider, predmetRada, main);
        }
    }
}

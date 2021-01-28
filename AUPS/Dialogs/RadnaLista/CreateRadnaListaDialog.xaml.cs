using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Windows;

namespace AUPS.Dialogs.RadnaLista
{
    /// <summary>
    /// Interaction logic for CreateRadnaListaDialog.xaml
    /// </summary>
    public partial class CreateRadnaListaDialog : Window
    {
        public CreateRadnaListaDialog(IRadnaListaSqlProvider _radnaListaSqlProvider)
        {
            InitializeComponent();
            DataContext = new CreateRadnaListaDialogViewModel(_radnaListaSqlProvider);
        }
    }
}

using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Windows;

namespace AUPS.Dialogs.Operacija
{
    /// <summary>
    /// Interaction logic for Operacija.xaml
    /// </summary>
    public partial class CreateOperacijaDialog : Window
    {
        public CreateOperacijaDialog(IOperacijaSqlProvider _operacijaSqlProvider)
        {
            InitializeComponent();
            DataContext = new CreateOperacijaDialogViewModel(_operacijaSqlProvider);
        }

        public CreateOperacijaDialog(IOperacijaSqlProvider _operacijaSqlProvider, AUPS.Models.Operacija operacija)
        {
            InitializeComponent();
            DataContext = new CreateOperacijaDialogViewModel(_operacijaSqlProvider, operacija);
        }
    }
}

using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Windows;

namespace AUPS.Dialogs.RadnikProizvodnja
{
    /// <summary>
    /// Interaction logic for CreateRadnikProizvodnjaDialog.xaml
    /// </summary>
    public partial class CreateRadnikProizvodnjaDialog : Window
    {
        public CreateRadnikProizvodnjaDialog(IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider)
        {
            InitializeComponent();
            DataContext = new CreateRadnikProizvodnjaDialogViewModel(_radnikProizvodnjaSqlProvider);
        }
    }
}

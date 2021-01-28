using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Windows;

namespace AUPS.Dialogs.RadnoMesto
{
    /// <summary>
    /// Interaction logic for CreateRadnoMestoDialog.xaml
    /// </summary>
    public partial class CreateRadnoMestoDialog : Window
    {
        public CreateRadnoMestoDialog(IRadnoMestoSqlProvider _radnoMestoSqlProvider)
        {
            InitializeComponent();
            DataContext = new CreateRadnoMestoDialogViewModel(_radnoMestoSqlProvider);
        }
    }
}

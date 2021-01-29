using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Windows;

namespace AUPS.Dialogs.TehnoloskiPostupak
{
    /// <summary>
    /// Interaction logic for CreateTehnoloskiPostupakDialog.xaml
    /// </summary>
    public partial class CreateTehnoloskiPostupakDialog : Window
    {
        public CreateTehnoloskiPostupakDialog(ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider)
        {
            InitializeComponent();
            DataContext = new CreateTehnoloskiPostupakViewModel(_tehnoloskiPostupakSqlProvider);
        }

        public CreateTehnoloskiPostupakDialog(ITehnoloskiPostupakSqlProvider _tehnoloskiPostupakSqlProvider, AUPS.Models.TehnoloskiPostupak tehnoloskiPostupak)
        {
            InitializeComponent();
            DataContext = new CreateTehnoloskiPostupakViewModel(_tehnoloskiPostupakSqlProvider, tehnoloskiPostupak);
        }
    }
}

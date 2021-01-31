using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
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

namespace AUPS.Dialogs.Trebovanje
{
    /// <summary>
    /// Interaction logic for CreateTrebovanjeDialog.xaml
    /// </summary>
    public partial class CreateTrebovanjeDialog : Window
    {
        public CreateTrebovanjeDialog(ITrebovanjeSqlProvider _trebovanjeSqlProvider, List<int> radniNalogIds)
        {
            InitializeComponent();
            DataContext = new CreateTrebovanjeDialogViewModel(_trebovanjeSqlProvider, radniNalogIds);
        }

        public CreateTrebovanjeDialog(ITrebovanjeSqlProvider _trebovanjeSqlProvider, List<int> radniNalogIds, AUPS.Models.Trebovanje trebovanje)
        {
            InitializeComponent();
            DataContext = new CreateTrebovanjeDialogViewModel(_trebovanjeSqlProvider, radniNalogIds, trebovanje);
        }
    }
}

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

namespace AUPS.Dialogs.RadnikProizvodnja
{
    /// <summary>
    /// Interaction logic for CreateRadnikProizvodnjaDialog.xaml
    /// </summary>
    public partial class CreateRadnikProizvodnjaDialog : Window
    {
        public CreateRadnikProizvodnjaDialog()
        {
            InitializeComponent();
            DataContext = new CreateRadnikProizvodnjaDialogViewModel();
        }
    }
}

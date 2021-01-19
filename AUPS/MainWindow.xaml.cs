using AUPS.SqlProviders.Interfaces;
using System.Windows;

namespace AUPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(IRadnoMestoSqlProvider radnoMestoSqlProvider)
        {
            InitializeComponent();

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(radnoMestoSqlProvider);
            DataContext = mainWindowViewModel;
        }
    }
}

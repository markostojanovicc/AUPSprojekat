using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels;
using AUPS.ViewModels.MainContentViewModels;
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

namespace AUPS
{
    /// <summary>
    /// Interaction logic for ApplicationMainWindow.xaml
    /// </summary>
    public partial class ApplicationMainWindow : Window
    {
        public ApplicationMainWindow(IUserSqlProvider userSqlProvider
                                    , IRadnoMestoSqlProvider radnoMestoSqlProvider, IOperacijaSqlProvider operacijaSqlProvider
                                    , IPredmetRadaSqlProvider predmetRadaSqlProvider, IRadnaListaSqlProvider radnaListaSqlProvider
                                    , IRadnikProizvodnjaSqlProvider radnikProizvodnjaSqlProvider, IRadniNalogSqlProvider radniNalogSqlProvider
                                    , ITehnoloskiPostupakSqlProvider tehnoloskiPostupakSqlProvider, ITrebovanjeSqlProvider trebovanjeSqlProvider
                                    , RadnoMestoViewModel radnoMestoViewModel, OperacijaViewModel operacijaViewModel, PredmetRadaViewModel predmetRadaViewModel,
                                    RadnaListaViewModel radnaListaViewModel, RadnikProizvodnjaViewModel radnikProizvodnjaViewModel, RadniNalogViewModel radniNalogViewModel,
                                    TehnoloskiPostupakViewModel tehnoloskiPostupakViewModel, TrebovanjeViewModel trebovanjeViewModel)
        {
            InitializeComponent();

            DataContext = new ApplictionMainWindowViewModel(radnoMestoSqlProvider, operacijaSqlProvider, predmetRadaSqlProvider, radnaListaSqlProvider,
                radnikProizvodnjaSqlProvider, radniNalogSqlProvider, tehnoloskiPostupakSqlProvider, trebovanjeSqlProvider, userSqlProvider,
                radnoMestoViewModel, operacijaViewModel, predmetRadaViewModel, radnaListaViewModel, radnikProizvodnjaViewModel, radniNalogViewModel
                , tehnoloskiPostupakViewModel, trebovanjeViewModel);
        }
    }
}

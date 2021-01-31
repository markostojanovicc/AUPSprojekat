using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace AUPS.Dialogs.RadnaLista
{
    /// <summary>
    /// Interaction logic for CreateRadnaListaDialog.xaml
    /// </summary>
    public partial class CreateRadnaListaDialog : Window
    {
        public CreateRadnaListaDialog(IRadnaListaSqlProvider _radnaListaSqlProvider, List<int> radniNalogIds, ObservableCollection<AUPS.Models.Operacija> operacijaList, ObservableCollection<AUPS.Models.RadnikProizvodnja> radnikProizvodnjaList)
        {
            InitializeComponent();
            DataContext = new CreateRadnaListaDialogViewModel(_radnaListaSqlProvider, radniNalogIds, operacijaList, radnikProizvodnjaList);
        }

        public CreateRadnaListaDialog(IRadnaListaSqlProvider _radnaListaSqlProvider, List<int> radniNalogIds, ObservableCollection<AUPS.Models.Operacija> operacijaList, ObservableCollection<AUPS.Models.RadnikProizvodnja> radnikProizvodnjaList, AUPS.Models.RadnaLista radnaLista)
        {
            InitializeComponent();
            DataContext = new CreateRadnaListaDialogViewModel(_radnaListaSqlProvider, radniNalogIds , operacijaList, radnikProizvodnjaList, radnaLista);
        }
    }
}

using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace AUPS.Dialogs.RadnikProizvodnja
{
    /// <summary>
    /// Interaction logic for CreateRadnikProizvodnjaDialog.xaml
    /// </summary>
    public partial class CreateRadnikProizvodnjaDialog : Window
    {
        public CreateRadnikProizvodnjaDialog(IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider, ObservableCollection<AUPS.Models.RadnoMesto> radnogMestoList
            , MainContentViewModel main)
        {
            InitializeComponent();
            DataContext = new CreateRadnikProizvodnjaDialogViewModel(_radnikProizvodnjaSqlProvider, radnogMestoList, main);
        }

        public CreateRadnikProizvodnjaDialog(IRadnikProizvodnjaSqlProvider _radnikProizvodnjaSqlProvider, ObservableCollection<AUPS.Models.RadnoMesto> radnogMestoList, AUPS.Models.RadnikProizvodnja radnikProizvodnja
            , MainContentViewModel main)
        {
            InitializeComponent();
            DataContext = new CreateRadnikProizvodnjaDialogViewModel(_radnikProizvodnjaSqlProvider, radnogMestoList, radnikProizvodnja, main);
        }
    }
}

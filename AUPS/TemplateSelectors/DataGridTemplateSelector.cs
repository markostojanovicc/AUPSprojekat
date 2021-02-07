using AUPS.ViewModels.MainContentViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AUPS.TemplateSelectors
{
    public class DataGridTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OperacijaContentDataTemplate { get; set; }

        public DataTemplate PredmetRadaContentDataTemplate { get; set; }
        public DataTemplate RadnaListaContentDataTemplate { get; set; }
        public DataTemplate RadnikProizvodnjaContentDataTemplate { get; set; }
        public DataTemplate RadniNalogContentDataTemplate { get; set; }
        public DataTemplate RadnoMestoContentDataTemplate { get; set; }
        public DataTemplate TehnoloskiPostupakContentDataTemplate { get; set; }
        public DataTemplate TrebovanjeContentDataTemplate { get; set; }
        public DataTemplate TehnPostupakOperacijaDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is OperacijaViewModel)
            {
                return OperacijaContentDataTemplate;
            }
            else if (item is PredmetRadaViewModel)
            {
                return PredmetRadaContentDataTemplate;
            }
            else if (item is RadnaListaViewModel)
            {
                return RadnaListaContentDataTemplate;
            }
            else if (item is RadnikProizvodnjaViewModel)
            {
                return RadnikProizvodnjaContentDataTemplate;
            }
            else if (item is RadniNalogViewModel)
            {
                return RadniNalogContentDataTemplate;
            }
            else if (item is RadnoMestoViewModel)
            {
                return RadnoMestoContentDataTemplate;
            }
            else if (item is TehnoloskiPostupakViewModel)
            {
                return TehnoloskiPostupakContentDataTemplate;
            }
            else if (item is TrebovanjeViewModel)
            {
                return TrebovanjeContentDataTemplate;
            }
            else if(item is TehnPostupakOperacijaViewModel)
            {
                return TehnPostupakOperacijaDataTemplate;
            }
            return null;
        }
    }
}

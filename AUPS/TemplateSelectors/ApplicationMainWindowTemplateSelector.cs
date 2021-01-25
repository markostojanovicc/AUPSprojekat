using AUPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AUPS.TemplateSelectors
{
    public class ApplicationMainWindowTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MainContentDataTemplate { get; set; }

        public DataTemplate LogInContentDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is LogInViewModel)
            {
                return LogInContentDataTemplate;
            }
            else if(item is MainContentViewModel)
            {
                return MainContentDataTemplate;
            }
            return null;
        }
    }
}

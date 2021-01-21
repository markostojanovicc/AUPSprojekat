using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AUPS.Converters
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public int val;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            val = (int)value;

            return val > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AUPS.Helpers
{
    public static class DialogCloser
    {
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogCloser),
                new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var window = d as Window;
                if (window != null)
                    if (window.IsModal())
                    {
                        window.DialogResult = e.NewValue as bool?;
                    }
                    else
                    {
                        bool? val = e.NewValue as bool?;

                        if (val.HasValue && val.Value)
                        {
                            window.Close();
                        }
                    }

            }
            catch (System.Exception ex)
            {

            }

        }
        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }


        public static bool IsModal(this Window window)
        {
            var fieldInfo = typeof(Window).GetField("_showingAsDialog", BindingFlags.Instance | BindingFlags.NonPublic);
            return fieldInfo != null && (bool)fieldInfo.GetValue(window);
        }
    }
}

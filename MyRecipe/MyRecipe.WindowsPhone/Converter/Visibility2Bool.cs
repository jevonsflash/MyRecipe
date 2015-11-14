using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MyRecipe.Converter
{
    public class Visibility2Bool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility isVisible = (bool)value ? Visibility.Visible : Visibility.Collapsed;
            return isVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

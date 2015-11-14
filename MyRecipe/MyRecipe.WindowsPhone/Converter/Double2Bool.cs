using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MyRecipe.Converter
{
    public class Double2Bool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double result = (bool)value ? 0.5 : 1;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

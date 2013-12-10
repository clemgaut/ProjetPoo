using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace IHM
{
    //Convert a boolean in its negation
    class NegatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, Object param, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

    }


    //Return a text color depending on the value of selectedIndex
    class SelectedIndexToTextLabelColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (targetType != typeof(System.Windows.Media.Brush))
                throw new InvalidOperationException("The target must be a System.Windows.Media.Brush");

            if (((int)value) == -1)
                return System.Windows.Media.Brushes.Red;
            else
                return System.Windows.Media.Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, Object param, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

    }
}

using System;
using System.Globalization;
using System.Windows.Data;

namespace DBSizer.WPF.UI.Converters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.Equals(value))
                return true;
            else
                return false; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter; 
        }
    }
}
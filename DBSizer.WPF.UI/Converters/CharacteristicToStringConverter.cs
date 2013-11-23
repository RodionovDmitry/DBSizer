using System;
using System.Globalization;
using System.Windows.Data;
using DBSizer.Data;

namespace DBSizer.WPF.UI.Converters
{
    public class CharacteristicToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            var param = (Characteristic)value;
            if (parameter is Characteristic)
            {
                param = (Characteristic)parameter;
            }
            switch (param)
            {
                case Characteristic.DataSize:
                    return "Data size (MB)";
                case Characteristic.IndexSize:
                    return "Index Size (MB)";
                case Characteristic.RowCount:
                    return "Row count";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace UFO.Converters
{
    public class SexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
            {
                return null;
            }
            if (value is string)
            {
                string source = value.ToString().Trim();
                if (source == "F")
                {
                    return "Ж";
                }
                else if (source == "")
                {
                    return "";
                }
                else if (source == "M")
                {
                    return "М";
                }
                else return source;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

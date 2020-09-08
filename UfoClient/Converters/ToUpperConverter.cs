using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace UFO.Converters
    {
        public class ToUpperConverter : IValueConverter
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
                    return ((string)value).ToUpper();
                }
                return false;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
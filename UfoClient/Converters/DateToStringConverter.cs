using System;
using System.Globalization;
using System.Windows.Data;

namespace UFO.Converters
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
            {
                return null;
            }
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                if (date == new DateTime(9999, 1, 1))
                {
                    return "текущее время";
                }
                else if(date == new DateTime())
                {
                    return String.Empty;
                }
                else
                {
                    //return date.ToUniversalTime();
                    return date.ToString("dd.MM.yyyy HH:mm");
                }
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            if (null == value)
            {
                return null;
            }
            DateTime resultDateTime = new DateTime();
            if (value is String)
            {
                if(value.ToString() == String.Empty)
                {
                    return resultDateTime;
                }
                if (DateTime.TryParse(value.ToString(), out resultDateTime))
                {
                    return resultDateTime;
                }
            }
            return resultDateTime;
        }
    }
}

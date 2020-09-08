using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace UFO.Converters
{
    
        public class TextComparison : IMultiValueConverter
        {

       public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string one = values[0] as string;
            string two = values[1] as string;


            if (one == two)
            {
                var uri = new Uri("/Icons/Identically.png", UriKind.Relative);
                return new BitmapImage(uri);
            }
            else
            {
                var uri = new Uri("/Icons/No_Similar.png", UriKind.Relative);
                return new BitmapImage(uri);
            }                       
        }

       public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    }

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace UFO.Converters
{

    public class DistanceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string str = values[0] as string;
            int distance = 0;
            
            if (str == "")
            {
                distance = 999;                
            }
            else
            {
              distance=Int32.Parse(str);
            }
            
            switch(distance)
            {
                case 0:
                    var uri = new Uri("Icons/Identically.png", UriKind.Relative);
                    return new BitmapImage(uri);
                case 1:
                   
                    uri = new Uri("Icons/yellow.png", UriKind.Relative);
                    return new BitmapImage(uri);
                case 2:
                   
                    uri = new Uri("Icons/yellow.png", UriKind.Relative);
                    return new BitmapImage(uri);
                default:
                    
                    uri = new Uri("Icons/No_Similar.png", UriKind.Relative);
                    return new BitmapImage(uri);

            }  
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
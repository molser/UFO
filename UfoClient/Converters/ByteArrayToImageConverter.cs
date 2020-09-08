using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using UFO.Utilities;

namespace UFO.Converters
{
    [ValueConversion(typeof(byte[]), typeof(BitmapImage))]
    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
            {
                return null;
            }
            try
            {
                byte[] array = value as byte[];
                BitmapImage bitmap = ImageHelper.GetBitmapImageFromArray(array, 80);
                return bitmap;
            }
            catch (Exception error)
            {
                return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();            
        }
    }
}

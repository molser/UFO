using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UFO.Utilities
{
    public static class ImageHelper
    {
        public static BitmapImage GetImageFromFile(string file_path, int imageWidth = 0, int imageHeight = 0)
        {            
            if (File.Exists(file_path))
            {
                BitmapImage bi = new BitmapImage();
                using (var fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = fs;
                    if(imageWidth != 0) bi.DecodePixelWidth = imageWidth;
                    if (imageHeight != 0) bi.DecodePixelHeight = imageHeight;
                    bi.EndInit();
                }
                return bi;
            }
            return null;           
        }

        public static string GetImageFileExtension(Image image)
        {
            if (image != null)
            {
                //string ext = new ImageFormatConverter().ConvertToString(image.RawFormat);

                if (ImageFormat.Jpeg.Equals(image.RawFormat))
                {
                    return "jpg";
                }
                else if (ImageFormat.Png.Equals(image.RawFormat))
                {
                    return "png";
                }
                else if (ImageFormat.Gif.Equals(image.RawFormat))
                {
                    return "gif";
                }
                else if (ImageFormat.Bmp.Equals(image.RawFormat))
                {
                    return "bmp";
                }
                else if (ImageFormat.Icon.Equals(image.RawFormat))
                {
                    return "ico";
                }
                if (ImageFormat.Tiff.Equals(image.RawFormat))
                {
                    return "tiff";
                }
            }
            return null;
        }

        public static byte[] GetArrayFromFile(string file_path)
        {
            if (File.Exists(file_path))
            {
                using (var fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fs.Length];
                    int numBytesToRead = (int)fs.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;
                    return bytes;
                }
            }
            return null;
        }

        /*
        public static async Task<BitmapImage> GetImageFromFileAsync(string file_path, int imageWidth = 0, int imageHeight = 0)
        {
            if (File.Exists(file_path))
            {
                byte[] result;
                using (var fs = new FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    result = new byte[fs.Length];
                    await fs.ReadAsync(result, 0, (int)fs.Length);
                }

                return GetImageFromArray(result, imageWidth, imageHeight);
            }
            return null;
        }
        */

        public static BitmapImage GetBitmapImageFromArray(byte[] array, int imageWidth = 0, int imageHeight = 0)
        {
            BitmapImage bitmapImage = null;
            if (array != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(array))
                {                   
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    if (imageWidth != 0) bitmapImage.DecodePixelWidth = imageWidth;
                    if (imageHeight != 0) bitmapImage.DecodePixelHeight = imageHeight;

                    bitmapImage.EndInit();
                }
            }
            return bitmapImage;
        }

        public static Image GetImageFromArray(byte[] array)
        {
            Image image = null;
            if (array != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(array))
                {
                    return Image.FromStream(ms);
                }
            }
            return image;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace UfoService.Utilities
{
    public static class ImageHelper
    {

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

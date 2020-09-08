using System;
using System.Text;
using System.Text.RegularExpressions;

namespace UFO.Utilities
{
    public static class StringHelper
    {
        public static String RemoveUnnecessaryChars(String str, string validChars = null)
        {
            if (string.IsNullOrEmpty(str)) return str;

            string result;
                      
            //удаляем пробелы и запятые в начале и конце строки
            char[] charsToTrim = { ' ', ',' };
            result = str.Trim(charsToTrim);
            
            RegexOptions reg_options = RegexOptions.None;

            Regex regex = null;
            if (validChars != null)
            {
                //удаляем символы по паттерну
                regex = new Regex("[^" + validChars +"]+", reg_options);
                result = regex.Replace(result, "");
            }

            //удаляем повторные пробелы
            regex = new Regex("[ ]{2,}", reg_options);
            result = regex.Replace(result, " ");

            //удаляем пробелы около запятой
            regex = new Regex(@"\s*,\s*", reg_options);
            result = regex.Replace(result, ",");

            return result;
        }
    }
}



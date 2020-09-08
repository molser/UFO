using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace UFO.ValidationRules
{
    public class IndexInput : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var regex = new Regex("^[А-Я,]*$");
            if (regex.IsMatch(value.ToString()))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Значение может содержать только заглавные русские буквы и знак ',' ");
        }
    }
}

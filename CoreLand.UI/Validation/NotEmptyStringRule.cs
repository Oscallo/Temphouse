using System;
using System.Globalization;
using System.Windows.Controls;

namespace CoreLand.UI.Validation
{
    /// <summary>
    /// https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/data/how-to-implement-binding-validation?view=netframeworkdesktop-4.8
    /// </summary>
    public class NotEmptyStringRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Trim().Length == 0) { return new ValidationResult(false, $"Can't be empty."); }
            return ValidationResult.ValidResult;
        }
    }
}

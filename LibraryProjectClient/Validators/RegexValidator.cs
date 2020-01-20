using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace LibraryProjectClient.Validators
{
    public class RegexValidator : ValidationRule
    {
        private Regex decimalRegex = new Regex(("[^0-9].?+"));
        private Regex intRegex = new Regex(("[^0-9]+"));
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}

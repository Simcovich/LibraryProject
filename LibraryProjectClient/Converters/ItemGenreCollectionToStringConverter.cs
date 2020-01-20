using Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace LibraryProjectClient.Converters
{
    public class ItemGenreCollectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in (value as ICollection<AbstractItemGenre>))
            {
                builder.Append($"{item.Genre.Name} ");
            }
            return builder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
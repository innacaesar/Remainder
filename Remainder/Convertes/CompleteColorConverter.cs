using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Remainder.Converters
{
    public class CompleteColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCompleted = value is bool b && b;
            return isCompleted ? "#00FF00" : "#FF0000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
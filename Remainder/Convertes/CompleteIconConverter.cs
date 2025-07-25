﻿using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Remainder.Helper;

namespace Remainder.Converters
{
    public class CompleteIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCompleted = value is bool b && b;
            return isCompleted ? FontHelper.COMPLETE_ICON : FontHelper.NOT_COMPLETE_ICON;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
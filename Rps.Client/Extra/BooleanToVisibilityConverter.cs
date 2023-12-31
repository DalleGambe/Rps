﻿using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System;

namespace Rps.Client.Extra
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Won't be used, but needs to be here since IValueConverter requires it
            throw new NotImplementedException();
        }
    }
}

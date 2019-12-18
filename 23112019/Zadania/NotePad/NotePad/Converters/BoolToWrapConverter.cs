﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NotePad.Converters
{
    class BoolToWrapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (TextWrapping)value != TextWrapping.NoWrap;
        }
    }
}

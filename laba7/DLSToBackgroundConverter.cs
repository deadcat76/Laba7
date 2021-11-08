using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using Domain;

namespace laba7
{
    public class DLSToBackgroundConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((string)value) == "Discord")
                return Brushes.Gray;
            if (((string)value) == "Zoom")
                return Brushes.Blue;
            if (((string)value) == "WebinarSFU")
                return Brushes.Orange;
            if (((string)value) == "Skype")
                return Brushes.LightBlue;
            else return Brushes.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

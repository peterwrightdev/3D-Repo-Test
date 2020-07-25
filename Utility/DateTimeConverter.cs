using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ListExample.Utility
{
    class DateTimeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // converts Epoch time to string date
            return values.Select(v => new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds((long)v)).Select(dv => dv.ToString("dd MMM yyyy")).ToList().First();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // not required currently.
            throw new NotImplementedException();
        }
    }
}

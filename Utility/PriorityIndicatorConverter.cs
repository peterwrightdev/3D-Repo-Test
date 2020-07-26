using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ListExample.Utility
{
    class PriorityIndicatorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // determine from values supplied if we are using an Issue's "priority" or a Risks "overall_level_of_risk"
            object key = null;
            if (values[0].GetType() == typeof(string))
            {
                key = values[0];
            }
            else if (values[1].GetType() == typeof(Int32))
            {
                key = values[1];
            }

            ColorMapping.Mapping.TryGetValue(key, out string color);

            if (string.IsNullOrEmpty(color))
            {
                color = ColorMapping.Mapping["default"];
            }

            // Converts from priority to specific color.
            // Find which "Priority" matches our string name and return it's colour.
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // not required currently.
            throw new NotImplementedException();
        }
    }
}

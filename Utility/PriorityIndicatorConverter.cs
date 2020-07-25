using ListExample.Utility.Priorities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            // Converts from priority to specific color.
            // Find which "Priority" matches our string name and return it's colour.
            try
            {
                var priorityType = Type.GetType("ListExample.Utility.Priorities." + values[0]);

                return new SolidColorBrush(((IPriority)Activator.CreateInstance(priorityType)).Colour);
            }
            catch
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // not required currently.
            throw new NotImplementedException();
        }
    }
}

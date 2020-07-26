using ListExample.Utility.Priorities;
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
            // Converts from priority to specific color.
            // Find which "Priority" matches our string name and return it's colour.
            var priorityType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.FullName.ToLower() == "listexample.utility.priorities." + ((string)values[0]).ToLower()).FirstOrDefault();

            if (priorityType != null)
            {
                return new SolidColorBrush(((IPriority)Activator.CreateInstance(priorityType)).Colour);
            }
            else
            {
                // unknown priority. Use default colour.
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4e7496"));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // not required currently.
            throw new NotImplementedException();
        }
    }
}

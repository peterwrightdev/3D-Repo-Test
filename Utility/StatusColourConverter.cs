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
    class StatusColourConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // converts from given status to an icon in unicode
            try
            {
                if (values[0].GetType() == typeof(string))
                {
                    switch (((string)values[0]).ToLower())
                    {
                        case "closed":
                            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7ca687"));
                        default:
                            PriorityIndicatorConverter priorityConverter = new PriorityIndicatorConverter();
                            object[] priorityValues = new object[] { values[1] };
                            return priorityConverter.Convert(priorityValues, targetType, parameter, culture);
                    }
                }
                else if (values[2].GetType() == typeof(string))
                {
                    switch (((string)values[2]).ToLower())
                    {
                        case "agreed_fully":
                            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7ca687"));
                        case "rejected":
                            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8B0000"));
                        default:
                            PriorityIndicatorConverter priorityConverter = new PriorityIndicatorConverter();
                            object[] priorityValues = new object[] { new object(), values[3] };
                            return priorityConverter.Convert(priorityValues, targetType, parameter, culture);
                    }
                }
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ListExample.Utility
{
    class StatusToIconConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // converts from given status to an icon in unicode - better mapping could be used here
            try
            {
                switch (((string)values[0]).ToLower())
                {
                    case "unknown":
                    case "open":
                        return "\uf111";
                    case "in progress":
                        return "\uf056";
                    case "for approval":
                        return "\uf192";
                    case "closed":
                        return "\uf058";
                    default:
                        return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // not required currently.
            throw new NotImplementedException();
        }
    }
}

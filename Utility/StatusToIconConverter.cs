using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ListExample.Utility
{
    class StatusToIconConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // converts from given status to an icon in unicode - better mapping could be used here
            try
            {
                if (values[0].GetType() == typeof(string))
                {
                    switch (((string)values[0]).ToLower())
                    {
                        case "in progress":
                            return "\uf056";
                        case "for approval":
                            return "\uf192";
                        case "closed":
                            return "\uf058";
                        case "open":
                        default:
                            return "\uf111";
                    }
                }
                else if (values[1].GetType() == typeof(string))
                {
                    switch (((string)values[1]).ToLower())
                    {
                        case "proposed":
                            return "\uf056";
                        case "agreed_partial":
                            return "\uf192";
                        case "agreed_fully":
                            return "\uf058";
                        case "rejected":
                            return "\uf057";
                        case "unmitigated":
                        default:
                            return "\uf111";
                    }
                }
                else return string.Empty;
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

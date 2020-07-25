using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ListExample.Utility
{
    class ThumbnailToImageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // convert from URI to an image
            DataManager datamanager = new DataManager();
            BitmapImage image = null;

            // This needs to wait
            datamanager.GetBinaryStream((string)values[0], (stream, exception) => 
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                App.Current.Dispatcher.BeginInvoke((Action)delegate () { image = bitmap; });
            });

            return image;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // not required currently.
            throw new NotImplementedException();
        }
    }
}

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
        AutoResetEvent waitHandle = new AutoResetEvent(false);

        private BitmapImage _image = null;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // convert from URI to an image
            DataManager datamanager = new DataManager();

            // This needs to wait
            datamanager.GetBinaryStream((string)values[0], (stream, exception) =>
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                this._image = bitmap;
                this.waitHandle.Set();
            });
            this.waitHandle.WaitOne();

            return this._image;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // not required currently.
            throw new NotImplementedException();
        }
    }
}

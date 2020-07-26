using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace ListExample.DataStructures
{
    public interface IModel
    {
        string _id { get; set; }

        string name { get; set; }

        string owner { get; set; }
        Int64 created { get; set; }
        string desc { get; set; }
        string thumbnail { get; set; }

        BitmapImage thumbnailImage { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propName);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace ListExample.DataStructures
{
    [Serializable]
    public class Risk : INotifyPropertyChanged, IModel
    {
        public string _id { get; set; } = null;
        public string owner { get; set; } = null;
        public Int64 created { get; set; } = 0;
        public string thumbnail { get; set; } = null;
        public string name { get; set; } = "";
        public string desc { get; set; } = "";
        public string mitigation_status { get; set; } = "";
        public Int32 overall_level_of_risk { get; set; } = -1;
        public string category = "";

        private BitmapImage _thumbnailImage = null;

        public BitmapImage thumbnailImage
        {
            get
            {
                return this._thumbnailImage;
            }
            set
            {
                this._thumbnailImage = value;
                NotifyPropertyChanged("thumbnailImage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    [Serializable]
    public class RiskList
    {
        public List<Risk> risks = null;
    }
}
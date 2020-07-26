using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace ListExample.DataStructures
{
    [Serializable]
    public class IssuesList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Issue> issues = null;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    [Serializable]
    public class Issue : INotifyPropertyChanged, IModel
    {
        public string _id { get; set; } = "";

        private string _name = "";
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                NotifyPropertyChanged("name");
            }
        }

        public string status { get; set; } = "";
        public string owner { get; set; } = "";
        public Int64 created { get; set; } = 0;
        public Int64 due_date { get; set; } = 0;
        public int number { get; set; } = -1;
        public string topic_type { get; set; } = "";
        public string priority { get; set; } = "";
        public string desc { get; set; } = "";
        public string thumbnail { get; set; }

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
}
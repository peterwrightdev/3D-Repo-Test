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

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    [Serializable]
    public class Issue : INotifyPropertyChanged
    {
        public string _id { get; set; } = "";
        public string name { get; set; } = "";
        public string status { get; set; } = "";
        public string owner { get; set; } = "";
        public Int64 created { get; set; } = 0;
        public Int64 due_date { get; set; } = 0;
        public int number { get; set; } = -1;
        public string topic_type { get; set; } = "";
        public string priority { get; set; } = "";
        public string desc { get; set; } = "";
        public string thumbnail { get; set; }
        public BitmapImage thumbnailImage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
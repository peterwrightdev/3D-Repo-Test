

namespace ListExample
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using ListExample.DataStructures;
    using ListExample.Utility;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ticketsList.ItemsSource = IssueList;

            DataManager dataManager = new DataManager();

            dataManager.GetIssueList((newIssues, exception) => {
                foreach (Issue issue in newIssues)
                {
                    App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                    {
                        if (!string.IsNullOrEmpty(issue.thumbnail))
                        {
                            dataManager.GetBinaryStream(issue.thumbnail, (stream, exception1) =>
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.EndInit();
                                issue.thumbnailImage = bitmap;
                            });
                        }
                        this.IssueList.Add(issue);
                    });
                }
            });

        }

        public ObservableCollection<Issue> IssueList = new ObservableCollection<Issue>();
    }
}
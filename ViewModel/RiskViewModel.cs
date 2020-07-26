
using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ListExample.DataStructures;
using ListExample.Utility;

namespace ListExample.ViewModel
{
    public class RiskViewModel : IViewModel<Risk>
    {
        public RiskViewModel()
        {
            this.LoadIssues();
        }

        public ObservableCollection<Risk> IssueList { get; set; } = new ObservableCollection<Risk>();

        public void Refresh(Action callback = null)
        {
            this.IssueList.Clear();
            this.LoadIssues(callback);
        }

        public void Find(string searchterm)
        {
            this.Refresh(() =>
            {
                List<Risk> matchingIssues = this.IssueList.Where(i => i.name.ToUpper().Contains(searchterm.ToUpper()) || i.owner.ToUpper().Contains(searchterm.ToUpper()) || i.desc.ToUpper().Contains(searchterm.ToUpper())).ToList();
                this.IssueList.Clear();

                foreach (Risk issue in matchingIssues)
                {
                    this.IssueList.Add(issue);
                }
            }
            );
        }

        private void LoadIssues(Action callback = null)
        {
            DataManager dataManager = new DataManager();

            dataManager.GetRiskList((newIssues, exception) => {
                foreach (Risk issue in newIssues)
                {
                    App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                    {
                        if (!string.IsNullOrEmpty(issue.thumbnail))
                        {
                            dataManager.GetBinaryStream(issue.thumbnail, (stream, exception1) =>
                            {
                                App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                                {
                                    var bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.StreamSource = stream;
                                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                    bitmap.EndInit();
                                    issue.thumbnailImage = bitmap;
                                });
                            });
                        }
                        this.IssueList.Add(issue);
                        if (callback != null && this.IssueList.Count == newIssues.Count)
                        {
                            callback();
                        }
                    });
                }
            });
        }
    }
}

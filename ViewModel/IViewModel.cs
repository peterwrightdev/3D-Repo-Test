
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
    public interface IViewModel<T> : IBaseViewModel where T:IModel
    {
        ObservableCollection<T> IssueList { get; set; }
    }
}

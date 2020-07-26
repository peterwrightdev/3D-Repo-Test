

namespace ListExample
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using ListExample.DataStructures;
    using ListExample.Utility;
    using ListExample.ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.IssuesChk.IsChecked = true;
        }

        private void FindCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void FindCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((IBaseViewModel)this.DataContext).Find(this.searchText.Text);
        }

        private void RefreshCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RefreshCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((IBaseViewModel)this.DataContext).Refresh();
        }

        private void SelectViewModelChecked(object sender, RoutedEventArgs e)
        {
            if (this.IssuesChk.IsChecked ?? false)
            {
                this.DataContext = new IssueViewModel();
                InitializeComponent();
                this.ticketsList.ItemsSource = ((IssueViewModel)this.DataContext).IssueList;
            }
            else if (this.RisksChk.IsChecked ?? false)
            {
                this.DataContext = new RiskViewModel();
                InitializeComponent();
                this.ticketsList.ItemsSource = ((RiskViewModel)this.DataContext).IssueList;
            }
        }
    }
}
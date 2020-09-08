//using IntellectOPK.Model;
//using IntellectOPK.Utilities;
//using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UFO
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class ListView : Window
    {
        private Timer textChangedTimer = new Timer(400);
        private bool isFindDelayEnabled = false;
        private bool isFindFirstTime = false;
        private int findCount = 0;
        //public bool IsMinimizeButtonHidden { get { return true; } }
        public ListView()
        {
            InitializeComponent();
            //hide Minimize and Maximize buttons
            //this.SourceInitialized += (x, y) =>
            //{
            //    WindowHelper.HideMinimizeButton(this);
            //};            
        }        

        public ListViewModelBase ViewModel
        {
            get { return this.DataContext as ListViewModelBase; }
            set
            {
                this.DataContext = value;
            }
        }
        
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if(this.Owner != null)
            {                
                this.Owner.Activate();
            }            
            //this.ViewModel.Dispose();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if(this.ViewModel != null)
            {
                if(this.ViewModel.IsOnlyCheckedShowed)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(this.itemsDataGrig.ItemsSource);
                    if (view != null)
                    {
                        view.Filter= this.ViewModel.FilterOnlyCheckedPredicate;
                        this.dummyCheckAllCheckBox.IsChecked = true;
                        //this.updateRowsCount();
                    }
                }
            }
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void uncheckOnlyCheckedButton()
        {
            if (this.showOnlyCheckedButton.IsChecked == true)
            {
                this.showOnlyCheckedButton.Unchecked -= this.showOnlyCheckedButton_Unchecked;
                this.showOnlyCheckedButton.IsChecked = false;
                this.showOnlyCheckedButton.Unchecked += this.showOnlyCheckedButton_Unchecked;
            }                
        }
        private void selectFirstElementOfFilterListComboBox()
        {
            if (this.filterListComboBox.Items.Count != 0
               && this.filterListComboBox.SelectedIndex != 0)
            {
                this.filterListComboBox.SelectionChanged -= this.filterListComboBox_SelectionChanged;
                this.filterListComboBox.SelectedIndex = 0;
                this.filterListComboBox.SelectionChanged += this.filterListComboBox_SelectionChanged;
            }
        }

        private void clearFindTextBox()
        {
            if (!String.IsNullOrEmpty(this.findTextBox.Text))
            {
                this.findTextBox.TextChanged -= this.findTextBox_TextChanged;
                this.findTextBox.Text = String.Empty;
                this.findTextBox.TextChanged += this.findTextBox_TextChanged;
            }
        }

        private void filterListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.dummyCheckAllCheckBox.IsChecked = false;
            if (this.itemsDataGrig.ItemsSource == null)
                return;
            ICollectionView view = CollectionViewSource.GetDefaultView(this.itemsDataGrig.ItemsSource);
            if (view == null)
                return;
            this.uncheckOnlyCheckedButton();
            this.clearFindTextBox();
            Debug.Write("FilterListValue: ");
            Debug.WriteLine(this.ViewModel.FilterListValue);
            if (String.IsNullOrEmpty(this.ViewModel.FilterListValue))
            {
                if (view.Filter != null)
                    view.Filter = null;
            }                
            else
            {
                view.Filter = this.ViewModel.FilterListPredicate;
                Debug.WriteLine("FilterListPredicate applied.");
            }                
        }

        private void showOnlyCheckedButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            if (toggleButton.IsChecked == null)
                toggleButton.IsChecked = true;            
        }

        private void uncheckAllButton_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.UncheckAllItems();
            ICollectionView view = CollectionViewSource.GetDefaultView(this.itemsDataGrig.ItemsSource);
            if (view == null)
                return;
            view.Refresh();
        }

        private void FindCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.ViewModel == null || this.ViewModel.ItemsArray.Count() < 1)
                e.CanExecute = false;            
            
            e.CanExecute = true;
        }

        private void FindCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            applyFind();
        }
        private void FindCancelCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            cancelFind();
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void DataGrid_TargetUpdated(object sender, DataTransferEventArgs e)
        {            
            if (this.showOnlyCheckedButton.IsChecked != null
                && this.showOnlyCheckedButton.IsChecked == true)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(this.itemsDataGrig.ItemsSource);
                if (view == null)
                    return;
                view.Refresh();
            }
        }

        private void applyFind()
        {
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            this.dummyCheckAllCheckBox.IsChecked = false;
            if (this.itemsDataGrig.ItemsSource == null)
                return;            

            ICollectionView view = CollectionViewSource.GetDefaultView(this.itemsDataGrig.ItemsSource);
            if (view == null)
                return;
            this.uncheckOnlyCheckedButton();
            this.selectFirstElementOfFilterListComboBox();
            if (String.IsNullOrEmpty(this.findTextBox.Text))
            {
                if (view.Filter != null)
                {                    
                    view.Filter = null;
                }                    
            }                
            else
                view.Filter = this.ViewModel.FilterFindPredicate;
            //updateRowsCount();
            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0}:{1:000}:{2:0000}",
            //    ts.Seconds, ts.Milliseconds, ts.Ticks);
            //Debug.WriteLine("RunTime: " + elapsedTime);

            this.findCount++;
            Debug.WriteLine("FindCount: " + findCount);
        }
        private void cancelFind()
        {
            this.clearAllFilters();
        }
        private void clearAllFilters()
        {
            this.uncheckOnlyCheckedButton();
            this.selectFirstElementOfFilterListComboBox();
            this.clearFindTextBox();
            ICollectionView view = CollectionViewSource.GetDefaultView(this.itemsDataGrig.ItemsSource);
            if (view == null)
                return;
            if (view.Filter != null)
                view.Filter = null;
        }
        private void findTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!this.isFindDelayEnabled)
            {
                //this.findCount = 0;
                this.isFindDelayEnabled = true;
                this.isFindFirstTime = true;
                this.Dispatcher.Invoke(new Action(()=> { applyFind();}) );
                this.textChangedTimer.Elapsed += FindTextChangedTimer_Elapsed;
                this.textChangedTimer.Start();                              
            }
            else
            {
                this.isFindFirstTime = false;
                this.textChangedTimer.Stop();
                this.textChangedTimer.Start();
            }
        }

        private void FindTextChangedTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.textChangedTimer.Stop();
            this.textChangedTimer.Elapsed -= FindTextChangedTimer_Elapsed;
            if(!this.isFindFirstTime)
            {                
                this.Dispatcher.Invoke(new Action(() => { applyFind(); }));                
            }
            this.isFindDelayEnabled = false;
        }

        private void selectAllTextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                tb.SelectAll();
            }
        }
        private void selectivelyIgnoreMouseButton(object sender,MouseButtonEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }

        private void CheckAllCheckBox_Click(object sender, RoutedEventArgs e)
        {
            //DataGridHelper.CheckUnCheckAll(sender, e);
            CheckBox chkSelectAll = sender as CheckBox;
            if (chkSelectAll == null)
                return;
            DataGrid dg = this.itemsDataGrig;
            if (dg == null)
                return;
            List<AppObjectBase> list = dg.Items.OfType<AppObjectBase>().ToList();
            if (list == null)
                return;

            if (chkSelectAll.IsChecked == false)
                this.changeShowOnlyChecked(false);
            
            foreach (AppObjectBase appObjectBase in list)
            {
                if (chkSelectAll.IsChecked == false)
                {
                    if (appObjectBase.IsChecked == true)
                        appObjectBase.IsChecked = false;
                }
                else
                {
                    if (appObjectBase.IsChecked == false)
                        appObjectBase.IsChecked = true;
                }
            }
            uncheckOnlyCheckedButton();                   

        }
        private void changeShowOnlyChecked(bool isApply)
        {
            this.dummyCheckAllCheckBox.IsChecked = isApply;
            if (this.itemsDataGrig.ItemsSource == null)
                return;
            ICollectionView view = CollectionViewSource.GetDefaultView(this.itemsDataGrig.ItemsSource);
            if (view == null)
                return;
            if(isApply)
            {
                view.Filter = this.ViewModel.FilterOnlyCheckedPredicate;
            }
            else
            {
                if (view.Filter != null)
                    view.Filter = null;
            }
            this.selectFirstElementOfFilterListComboBox();
            this.clearFindTextBox();
        }

        private void showOnlyCheckedButton_Checked(object sender, RoutedEventArgs e)
        {
            this.changeShowOnlyChecked(true);         
        }

        private void showOnlyCheckedButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.changeShowOnlyChecked(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using IntellectOPK.Commands;
//using IntellectOPK.MessageService;
//using IntellectOPK.Model;
//using IntellectOPK.Utilities;
using System.Data;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using UFO.Commands;
using UFO.Utilities;

namespace UFO
{
    public abstract class ListViewModelBase : ViewModelBase
    {
        private ListView view;
        //private IDataAccessService das;
        private string title;
        private bool isSelectableMode = false;
        private bool isExportEnable = false;
        private bool isChecked;
        private bool isOnlyCheckedShowed;
        private bool isStatisticsHidden;
        private string filterFindValue;
        private int selectedItemsCount;
        private PropertySet itemProperties;
        private HashSet<string> columsForExport;
        private RelayCommand confirmCommand;
        //private RelayCommand exportToMSExcelCommand;

        //public ListViewModelBase(ListView view, IDataAccessService das)
        public ListViewModelBase(ListView view)
            : base()
        {
            this.view = view;
            //this.das = das;            
            this.itemProperties = new PropertySet();
        }
        //public abstract ListViewBase View { get; }
        
        //public abstract string Title { get; set; }
        public abstract AppObjectBase[] ItemsArray { get; }
        //public abstract object[] ItemsArray { get; }        
        public string FilterFindValue // значение для фильтра-поиск
        {
            get { return this.filterFindValue; }
            set
            {
                this.filterFindValue = value;
                this.OnPropertyChanged("FilterFindValue");
            }
        }
        public virtual bool FilterFindPredicate(object obj) //предикат для фильтра-поиск
        {
            bool result = false;
            if (String.IsNullOrEmpty(this.FilterFindValue))
                return true;

            AppObjectBase appObjectBase = obj as AppObjectBase;
            if (appObjectBase != null)
            {
                string value = StringHelper.RemoveUnnecessaryChars(appObjectBase.NameBase);
                string search = StringHelper.RemoveUnnecessaryChars(this.FilterFindValue);
                return value.ToUpper().Contains(search.ToUpper());
            }
            return result;
        }
        
        public virtual string FilterListValue { get; set; } // значение для фильтра-список
        public virtual bool FilterListPredicate(object obj) //предикат для фильтра-список
        {
            return true;
        }

        public bool IsFilterListEnable { get; set; }

        public bool IsOnlyCheckedShowed
        {
            get { return this.isOnlyCheckedShowed; }
            set
            {
                this.isOnlyCheckedShowed = value;
                this.OnPropertyChanged("IsOnlyCheckedShowed");
            }
        }

        //public abstract bool CanExecuteFindCommand();

        //public List<AppObjectBase> SelectedItems
        public PropertySet ItemProperties
        {
            get
            {
                return this.itemProperties;
            }

            set
            {
                this.itemProperties = value;
                //this.OnPropertyChanged("ItemProperties");
            }
        }

        public abstract DataTable ExportTable
        {
            get;
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public AppObjectBase[] SelectedItems
        {
            get
            {
                if (this.ItemsArray == null)
                    return null;
                else
                {
                    int index = 0;
                    AppObjectBase[] array = new AppObjectBase[this.SelectedItemsCount];
                    //Mouse.OverrideCursor = Cursors.Wait;
                    for (int i = 0; i< this.ItemsArray.Count(); i++)
                    {
                        AppObjectBase appObjectBase = this.ItemsArray[i];
                        if (appObjectBase.IsChecked == true)
                        {
                            array[index] = appObjectBase;
                            index++;
                        }                            
                    }
                    //Mouse.OverrideCursor = null;
                    return array;
                }
            }            
        }
        public bool CheckedUncheckedAll
        {
            set
            {
                if (this.ItemsArray != null)
                {
                    //Mouse.OverrideCursor = Cursors.Wait;
                    foreach (AppObjectBase appObjectBase in this.ItemsArray)
                    {
                        if (value == false)
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
                    //Mouse.OverrideCursor = null;
                }
            }
        }
        public void CheckItems(AppObjectBase[] itemsToCheck)
        {
            if (this.ItemsArray == null 
                || itemsToCheck == null
                || itemsToCheck.Count() <= 0)
                return;
            //Mouse.OverrideCursor = Cursors.Wait;
            for (int i = 0; i < this.ItemsArray.Count(); i++)
            {
                if(itemsToCheck.Contains(this.ItemsArray[i]))
                {
                    this.ItemsArray[i].IsChecked = true;
                    this.SelectedItemsCount++;
                }
            }
            //Mouse.OverrideCursor = null;
            this.IsOnlyCheckedShowed = true;            
        }
        public bool IsSelectableMode
        {
            get { return this.isSelectableMode; }
            set
            {
                this.isSelectableMode = value;
                this.OnPropertyChanged("IsSelectableMode");
            }
        }
        public bool IsExportEnable
        {
            get { return this.isExportEnable; }
            set
            {
                this.isExportEnable = value;
                this.OnPropertyChanged("IsExportEnable");
            }
        }
        public bool IsStatisticsHidden
        {
            get { return this.isStatisticsHidden; }
            set
            {
                this.isStatisticsHidden = value;
                this.OnPropertyChanged("IsStatisticsHidden");
            }
        }
        public bool FilterOnlyCheckedPredicate(object obj)
        {
            AppObjectBase appObjectBase = obj as AppObjectBase;
            if(appObjectBase != null)
            {
                 return appObjectBase.IsChecked == true;
            }
            return false;
        }
        public void UncheckAllItems()
        {
            if(this.ItemsArray != null)
            {
                //foreach (object obj in this.ItemsArray)
                //{
                //    AppObjectBase appObjectBase = obj as AppObjectBase;
                //    if (appObjectBase?.IsChecked == true)
                //        appObjectBase.IsChecked = false;
                //}
                foreach (AppObjectBase appObjectBase in this.ItemsArray)
                {
                    if (appObjectBase.IsChecked == true)
                        appObjectBase.IsChecked = false;
                }
            }
        }
        public int SelectedItemsCount
        {
            get { return this.selectedItemsCount; }
            set
            {
                this.selectedItemsCount = value;
                this.OnPropertyChanged("SelectedItemsCount");
            }
        }
        public void SubscribeOnItemChanged()
        {
            if (this.ItemsArray == null)
                return;
            foreach (AppObjectBase appObjectBase in this.ItemsArray)
            {
                if(appObjectBase != null)
                {
                    appObjectBase.PropertyChanged += AppObjectBase_PropertyChanged;
                }                
            }
        }        
        public ICommand ConfirmCommand
        {
            get
            {
                if (this.confirmCommand == null)
                {
                    this.confirmCommand = new RelayCommand(executeConfirmCommand, canExecuteConfirmCommand);
                }
                return this.confirmCommand;
            }
        }
        //public ICommand ExportToMSExcelCommand
        //{
        //    get
        //    {
        //        if (this.exportToMSExcelCommand == null)
        //        {
        //            this.exportToMSExcelCommand = new RelayCommand(executeExportToMSExcelCommand, canExecuteExportToMSExcelCommandCommand);
        //        }
        //        return this.exportToMSExcelCommand;
        //    }
        //}

        //private async void logAuditEvent()
        //{
        //    CancellationTokenSource CTS = new CancellationTokenSource();
        //    CancellationToken token = CTS.Token;
        //    string audit_group = "others";
        //    string audit_action = "export_data_to_excel";
        //    string computer_name = System.Environment.MachineName;
        //    string appBuild = null;
        //    string extension = this.Title;
        //    try
        //    {
        //        await this.das.LogAuditEventAsync(token, audit_group, audit_action, computer_name, appBuild, extension);
        //    }
        //    catch (Exception e)
        //    {
        //        if (e is TaskCanceledException)
        //        {
        //        }
        //        else
        //        {
        //            CTS.Cancel();
        //            Message.ShowError(e.Message, e.GetType().ToString(), this.view);
        //        }
        //    }
        //}
        private void AppObjectBase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                AppObjectBase appObjectBase = sender as AppObjectBase;
                if (appObjectBase != null)
                {
                    if (appObjectBase.IsChecked == true)
                        this.SelectedItemsCount++;
                    else
                        this.SelectedItemsCount--;
                    this.isChecked = true;
                }
                this.OnPropertyChanged("Items");
            }

        }
        #region Helper Methods
        private void executeConfirmCommand(object obj)
        {
            if(this.IsSelectableMode)
            {
                this.view.DialogResult = true;
            }                           
        }
        private bool canExecuteConfirmCommand(object obj)
        {
            //return (this.selectedItemsCount > 0);
            //return this.isChecked;
            if (this.IsSelectableMode)
            {
                return true;
            }
            return false;
        }
        //protected bool canExecuteExportToMSExcelCommandCommand(object obj)
        //{
        //    if (this.ItemsArray != null)
        //    {
        //        if (this.ItemsArray.Count() > 0)
        //            return true;
        //    }
        //    return false;
        //}
        //protected void executeExportToMSExcelCommand(object obj)
        //{
        //    SaveFileDialog saveDialog = new SaveFileDialog();
        //    saveDialog.FileName = this.Title;
        //    saveDialog.OverwritePrompt = true;
        //    saveDialog.Filter = "Microsoft Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";
        //    if (saveDialog.ShowDialog() == true)
        //    {
        //        Mouse.OverrideCursor = Cursors.Wait;
        //        this.logAuditEvent();
        //        try
        //        {                    
        //            ExportHelper.GenerateExcelToFile(saveDialog.FileName, this.ExportTable);
        //            Mouse.OverrideCursor = null;                    
        //        }
        //        catch (Exception e)
        //        {
        //            Mouse.OverrideCursor = null;
        //            MessageBox.Show(this.view, e.GetType().ToString() + Environment.NewLine + e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }

        //    return;
        //}
        #endregion
    }
}

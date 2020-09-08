using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UFO
{
    /// <summary>
    /// Interaction logic for DataBaseLink.xaml
    /// </summary>
    public partial class SettingsView : Window, INotifyPropertyChanged
    {
        //private bool isMainWindowShowed;
        //private bool bdConnectionIsOK = false;
        private bool passwordHasChanged = false;
        private bool kaskadPasswordHasChanged = false;
        private Settings settings;
        private DbWorker dbWorker;
        private string indexes;
        private string currentTab = String.Empty;        
        public SettingsView(Settings settings)
        {
            InitializeComponent();
            this.DataContext = this;
            this.settings = settings;
            this.dbWorker = new DbWorker();
            this.dbWorker.CheckDbConnectionComplitted += onCheckDbConnectionComplitted;
            loadMainSettings();
            loadKaskadSettings();
            this.pbPassword.Password = "1234567890123456";
            this.KaskadSqlPasswordPasswordBox.Password = "1234567890123456";
            this.pbPassword.PasswordChanged += PbPassword_PasswordChanged;
            this.KaskadSqlPasswordPasswordBox.PasswordChanged += KaskadSqlPasswordPasswordBox_PasswordChanged;
            this.tbDatabaseName.TextChanged += settingChanged;
            this.tbSqlServer.TextChanged += settingChanged;
            this.tbLogin.TextChanged += settingChanged;
            this.KaskadSqlDatabaseNameTextBox.TextChanged += settingChanged;
            this.KaskadSqlServerTextBox.TextChanged += settingChanged;
            this.KaskadSqlLoginTextBox.TextChanged += settingChanged;
            this.IsKaskadDbUsedCheckBox.Unchecked += IsKaskadDbUsedCheckBox_Changed;
            this.IsKaskadDbUsedCheckBox.Checked += IsKaskadDbUsedCheckBox_Changed;
            //this.tbIndex.TextChanged += settingChanged;
            WindowsLog.LogOpenSettingsWindow();
            this.btSave.IsEnabled = false;
            //this.isMainWindowShowed = isMainWindowShowed;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.Topmost = true;
            this.Topmost = false;
        }

        private void IsKaskadDbUsedCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            this.btSave.IsEnabled = true;
        }

        public string Indexes
        {
            get { return this.indexes; }
            set
            {
                this.indexes = value;
                this.OnPropertyChanged("Indexes");
                this.btSave.IsEnabled = true;
            }
        }

        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.passwordHasChanged = true;
            this.pbPassword.Password = "";
            this.pbPassword.PasswordChanged -= PbPassword_PasswordChanged;
            this.btSave.IsEnabled = true;
            //this.btCheckConnection.IsEnabled = true;
        }

        private void KaskadSqlPasswordPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.kaskadPasswordHasChanged = true;
            this.KaskadSqlPasswordPasswordBox.Password = "";
            this.KaskadSqlPasswordPasswordBox.PasswordChanged -= KaskadSqlPasswordPasswordBox_PasswordChanged;
            this.btSave.IsEnabled = true;
        }

        private void loadMainSettings()
        {
            this.tbSqlServer.Text = settings.SqlServer;
            this.tbDatabaseName.Text = settings.DataBaseName;
            this.tbLogin.Text = settings.Login;
            this.pbPassword.Password = settings.Password;
            //this.tbIndex.Text = settings.Index;
            this.Indexes = settings.Index;
            this.IsKaskadDbUsedCheckBox.IsChecked = settings.IsKaskadDbUsed;
        }

        private void loadKaskadSettings()
        {
            this.KaskadSqlServerTextBox.Text = settings.KaskadSqlServer;
            this.KaskadSqlDatabaseNameTextBox.Text = settings.KaskadDataBaseName;
            this.KaskadSqlLoginTextBox.Text = settings.KaskadLogin;
            this.KaskadSqlPasswordPasswordBox.Password = settings.KaskadPassword;            
        }

        private void setSettings()
        {
            settings.SqlServer = this.tbSqlServer.Text;
            settings.DataBaseName = this.tbDatabaseName.Text;
            settings.Login = this.tbLogin.Text;
            settings.Index = this.indexes;
            if (this.passwordHasChanged) settings.Password = this.pbPassword.Password;

            settings.IsKaskadDbUsed = (bool)this.IsKaskadDbUsedCheckBox.IsChecked;
            settings.KaskadSqlServer = this.KaskadSqlServerTextBox.Text;
            settings.KaskadDataBaseName = this.KaskadSqlDatabaseNameTextBox.Text;
            settings.KaskadLogin = this.KaskadSqlLoginTextBox.Text;
            if (this.kaskadPasswordHasChanged) settings.KaskadPassword = this.KaskadSqlPasswordPasswordBox.Password;            
        }

        //private async Task<bool> checkDB()
        //{
        //    setSettings();
        //    bool result = await DbWorker.CheckDBConnectionVisualAsync(settings,true,this);
        //    return result;
        //}

        private void onCheckDbConnectionComplitted(object sender, DbCheckEventArgs e)
        {
            //bool result = e.Result;
            this.Activate();
        }
        private void BLoadDefaults_Click(object sender, RoutedEventArgs e)
        {
            switch(this.currentTab)
            {
                case "KaskadTabItem":
                    this.KaskadSqlPasswordPasswordBox.PasswordChanged -= KaskadSqlPasswordPasswordBox_PasswordChanged;
                    this.settings.SetKaskadDefaults();
                    this.loadKaskadSettings();                    
                    this.KaskadSqlPasswordPasswordBox.Password = "1234567890123456";
                    this.KaskadSqlPasswordPasswordBox.PasswordChanged += KaskadSqlPasswordPasswordBox_PasswordChanged;
                    break;
                default:
                    this.pbPassword.PasswordChanged -= PbPassword_PasswordChanged;
                    this.settings.SetMainDefaults();
                    this.loadMainSettings();
                    this.pbPassword.Password = "1234567890123456";
                    this.pbPassword.PasswordChanged += PbPassword_PasswordChanged;
                    break;
            }            
            this.btSave.IsEnabled = true;
            //this.btCheckConnection.IsEnabled = true;
        }

        //private async void BCheckConnection_Click(object sender, RoutedEventArgs e)
        //{            
        //    bool result = await checkDB();
        //    this.Activate();
        //}

        private void BCheckConnection_Click(object sender, RoutedEventArgs e)
        {
            setSettings();
            bool isKaskadDbUsed = false;
            if (this.currentTab == "KaskadTabItem")
            {
                isKaskadDbUsed = true;
            }                
            string connectionString = settings.GenerateConnectionString(isKaskadDbUsed);
            this.dbWorker.CheckDBConnectionVisualAsync(connectionString);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            setSettings();            
            if (settings.IsCorrect)
            {
                settings.Save();
                settings.SetGlobal();
                WindowsLog.LogSaveSettings();
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введенные данные некорректны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAbort_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void settingChanged(object sender, TextChangedEventArgs e)
        {
            this.btSave.IsEnabled = true;
            //this.btCheckConnection.IsEnabled = true;
        }

        private void tbIndex_Error(object sender, ValidationErrorEventArgs e)
        {
            this.btSave.IsEnabled = false;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var tc = sender as TabControl; //The sender is a type of TabControl...

                if (tc != null)
                {
                    TabItem item = (TabItem)tc.SelectedItem;
                    this.currentTab = item.Name;                    
                }
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                this.EnsureProperty(propertyName);
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        [Conditional("DEBUG")]
        private void EnsureProperty(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException("Property does not exist.", "propertyName");
            }
        }

        #endregion

    }
}

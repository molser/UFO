using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using UFO.Utilities;
using System.Diagnostics;

namespace UFO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Settings settings;
        private DbWorker dbWorker;
        //private DataRowView currentPerson;
        private Person currentPerson;
        public MainWindow(Settings settings, DbWorker dbWorker)
        {
            InitializeComponent();
            this.settings = settings;
            this.dbWorker = dbWorker;
            loadApplicationTheme();
            date_end.SelectedDate = DateTime.Today;
            date_start.SelectedDate = DateTime.Today.AddDays(-1);
            date_end.DisplayDate = DateTime.Today;
            date_start.DisplayDate = DateTime.Today.AddDays(-1);
            WindowsLog.LogAppStart();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (this.settings != null)
            {
                this.settings.Save();
            }
        }
        private void loadApplicationTheme()
        {
            //string theme = Properties.Settings.Default.ApplicationTheme;
            string theme = this.settings.Theme;
            if (theme != null && theme == "Dark")
            {
                ThemeChangeDark(null,null);
            }
            else
            {
                ThemeChangeLight(null, null);
            }
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime ds,de;
            
            if (!DateTime.TryParse(date_start.Text, out ds))
            {
                MessageBox.Show(date_start.Text+" не является датой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                date_start.Text = Convert.ToString(date_start.SelectedDate);
                return;
            } 
            else
            {
                date_start.SelectedDate = ds;
            }

            if (!DateTime.TryParse(date_end.Text, out de))
            {
                MessageBox.Show(date_end.Text + " не является датой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                date_end.Text = Convert.ToString(date_end.SelectedDate);
                return;
            }
            else
            {
                date_end.SelectedDate = de;
            }


            //MessageBox.Show(date_start.Text+" "+date_start.SelectedDate+" "+date_start.DisplayDate, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            WindowsLog.LogPersonSearch(tbFamily.Text, tbName.Text, date_start.SelectedDate, date_end.SelectedDate);
           

            //DataTable table = DBWork.GetPassengersQuery(date_start.SelectedDate, date_end.SelectedDate, tbFamily.Text, tbName.Text);
            //if(table != null) vGrid.DataContext = table.DefaultView; 
                   
           vGrid.ItemsSource = this.dbWorker.GetPassengersQuery(date_start.SelectedDate, date_end.SelectedDate, tbFamily.Text, tbName.Text, cbNdb.SelectedIndex, settings.Index);
        }

        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            tbFamily.Clear();
            tbName.Clear();
            date_end.SelectedDate = DateTime.Today;
            date_start.SelectedDate = DateTime.Today.AddDays(-1);
            //vGrid.DataContext = null;
        }

        private void vGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(this.currentPerson != null)
            {
                //WindowsLog.LogOpenCompareWindow(this.currentPerson.Row["Fullname"].ToString());
                WindowsLog.LogOpenCompareWindow(this.currentPerson.PassengerFio);
                      
            PersonView personForm = new PersonView(this.currentPerson);
            personForm.Owner = this;
            //personForm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            personForm.ShowDialog();
            }

        /*
        Settings settings = new Settings();
        settings.SqlServer = "UFO\\SQL2008";
        settings.DataBaseName = "ufo";
        settings.Login = "sa";
        settings.Password = "escort";
        try
        {
            byte[] array = DBWork.GetPersonPhotoStatic(17600, settings);
            BitmapImage bitmap = ImageHelper.GetImageFromArray(array);
            personForm.ImgNowCrossing.Source = bitmap;

            array = DBWork.GetPersonPhotoStatic(26565, settings);
            BitmapImage bitmap2 = ImageHelper.GetImageFromArray(array);
            personForm.ImgLastCrossing.Source = bitmap2;

            personForm.ShowDialog();
        }
        catch (Exception error)
        {
            MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        */

    }       

        private void ThemeChangeDark (object sender, RoutedEventArgs e)
        {
            //ResourceDictionary dict = Application.Current.Resources.MergedDictionaries[0];
            //ResourceDictionary dict2 = Application.Current.Resources.MergedDictionaries[1];
            var uri = new Uri("Styles/CustomizedWindow/SharedDark.xaml", UriKind.Relative);
            var uri2 = new Uri("Styles/CustomizedWindow/VS2012WindowStyle.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            ResourceDictionary resourceDict2 = Application.LoadComponent(uri2) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict2);
            WSLightButton.IsChecked = false;
            WSDarkButton.IsChecked = true;
            this.settings.Theme = "Dark";
            //this.settings.Save();
            //Properties.Settings.Default.ApplicationTheme = "Dark";
            //Properties.Settings.Default.Save();
            //dict.Source = uri;
            //dict2.Source = uri2;
            //new Uri("pack://component/Styles/CustomizedWindow/SharedDark.xaml");
        }

        private void ThemeChangeLight(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Styles/CustomizedWindow/Shared.xaml", UriKind.Relative);
            var uri2 = new Uri("Styles/CustomizedWindow/VS2012WindowStyle.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            ResourceDictionary resourceDict2 = Application.LoadComponent(uri2) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict2);
            WSLightButton.IsChecked = true;
            WSDarkButton.IsChecked = false;
            //Properties.Settings.Default.ApplicationTheme = "Light";
            //Properties.Settings.Default.Save();
            this.settings.Theme = "Light";
            //this.settings.Save();
        }

        private void DataBaseLink_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = this.settings.Clone();
            SettingsView settingsWindow = new SettingsView(settings);
            settingsWindow.Owner = this;
            settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (settingsWindow.ShowDialog()==true)
            {
                this.settings = settings;
                if(this.dbWorker != null)
                {
                    this.dbWorker.MainDbConnectionString = Settings.GlobalMainDbConnectionString;
                    this.dbWorker.KaskadDbConnectionString = Settings.GlobalKaskadDbConnectionString;
                }
            }
        }

        private void vGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGrid dg = sender as DataGrid;
            //this.currentPerson = (DataRowView)dg.SelectedItem;
            if(vGrid.SelectedItem != null)
            {
                this.currentPerson = vGrid.SelectedItem as Person;
            }            
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutProject AboutForm = new AboutProject();
            AboutForm.Owner = this;
            AboutForm.ShowDialog();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, "Help/ufohelp.CHM");
        }

        private void ShowPhotoSearchView_Click(object sender, RoutedEventArgs e)
        {
            PhotoSearchView view = new PhotoSearchView();
            view.ViewModel = new PhotoSearchViewModel(view, this.settings);
            view.Owner = this;
            //view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            view.Show();
        }
    }   
}

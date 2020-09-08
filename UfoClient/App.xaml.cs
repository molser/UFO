using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace UFO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Settings settings;
        private DbWorker dbWorker;
        private MainWindow mainWindow;
               
        public App()
        {
            //InitializeComponent();
            this.Exit += App_Exit;
        }

        //глобальный обработчик ошибок
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            MessageBox.Show(e.Exception.Message, e.Exception.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            // Prevent default unhandled exception processing
            e.Handled = true;
        }

        private void onCheckDbConnectionComplitted(object sender, DbCheckEventArgs e)
        {
            bool connectionIsOk = e.Result;

            if (connectionIsOk)
            {
                //если проверка настроек успешна, запускаем программу
                dbWorker.MainDbConnectionString = Settings.GlobalMainDbConnectionString;
                this.dbWorker.CheckDbConnectionComplitted -= onCheckDbConnectionComplitted;                
                mainWindow.Show();
            }
            else 
            {
                //иначе, показываем окно настроек
                if (this.changeSettings() == true)
                {
                    //если настройки были изменены, проверяем их
                    dbWorker.CheckDBConnectionVisualAsync(Settings.GlobalMainDbConnectionString, false);
                }
                else
                {
                    //иначе, выходим из программы
                    //Application.Current.Shutdown();
                    if (this.mainWindow != null)
                    {
                        this.mainWindow.Close();
                    }                        
                }
            }
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            WindowsLog.LogAppExit();
        }        

        private bool changeSettings()
        {
            bool result = false;
            SettingsView settingsWindow = new SettingsView(this.settings);
            settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (settingsWindow.ShowDialog() == true)
            {
                result = true;
            }
            return result;            
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //this.mainWindow = new MainWindow(settings);
            //mainWindow.Show();
            this.settings = new Settings();
            this.settings.Load();

            if (!settings.IsCorrect)
            {
                settings.SetMainDefaults();
                settings.Save();
            }

            settings.SetGlobal();
            this.dbWorker = new DbWorker();
            this.mainWindow = new MainWindow(this.settings, this.dbWorker);
            this.dbWorker.CheckDbConnectionComplitted += onCheckDbConnectionComplitted;
            dbWorker.CheckDBConnectionVisualAsync(Settings.GlobalMainDbConnectionString, false);
        }
    }
}

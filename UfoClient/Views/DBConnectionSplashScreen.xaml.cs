using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DBConnectionSplashScreen.xaml
    /// </summary>
    public partial class DBConnectionSplashScreen : Window
    {
        //private CancellationTokenSource connectionCTS;
        //public DBConnectionSplashScreen(CancellationTokenSource cts)
        //{
        //    this.connectionCTS = cts;
        //    InitializeComponent();
        //}

        //protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        //{
        //    if (this.connectionCTS != null)
        //    {
        //        this.connectionCTS.Cancel();                
        //    }            
        //}

        Action cancelAction;
        public DBConnectionSplashScreen(Action cancelAction)
        {
            this.cancelAction = cancelAction;
            InitializeComponent();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (this.cancelAction != null)
            {
                this.cancelAction();
            }
        }
    }
}

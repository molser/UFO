using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for PhotoFromDbView.xaml
    /// </summary>
    public partial class PhotoFromDbView : Window
    {
        public PhotoFromDbView()
        {
            InitializeComponent();
        }
        public PhotoFromDbViewModel ViewModel
        {
            get { return this.DataContext as PhotoFromDbViewModel; }
            set
            {
                this.DataContext = value;
            }
        }

        private void namesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

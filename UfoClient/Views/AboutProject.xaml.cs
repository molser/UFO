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
using System.Windows.Shapes;

namespace UFO
{
    /// <summary>
    /// Interaction logic for AboutProject.xaml
    /// </summary>
    public partial class AboutProject : Window
    {
        public bool IsMinimizeButtonHidden { get { return true; } }
        public bool IsNoResizable { get { return true; } }
        public AboutProject()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string AppVersionInfo { get { return "Версия: " + Utilities.AssemlyInfoHelper.AssemblyVersion; } }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

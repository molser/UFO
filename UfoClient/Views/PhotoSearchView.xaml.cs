using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UFO.PhotoSearchServiceReference;
using UFO.Utilities;
using System.Drawing;
//using MahApps.Metro.Controls;

namespace UFO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PhotoSearchView : Window
    {
        public PhotoSearchView()
        {
            InitializeComponent();
            //this.DataContext = this;
            // Вешаем обработчик на событие перед закрытием окна.
            Closing += new CancelEventHandler(Window_Closing);
            // Восстанавливаем позицию на экране.
            Left = Properties.Settings.Default.PhotoSearchWindowPosition.Left;
            Top = Properties.Settings.Default.PhotoSearchWindowPosition.Top;
            // Востанавливаем размеры окна.
            Width = Properties.Settings.Default.PhotoSearchWindowPosition.Width;
            Height = Properties.Settings.Default.PhotoSearchWindowPosition.Height;
        }
        public PhotoSearchViewModel ViewModel
        {
            get { return this.DataContext as PhotoSearchViewModel; }
            set { this.DataContext = value; }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // RestoreBounds - Возвращает размер и расположение окна перед тем как оно было свернуто или развернуто.
            Properties.Settings.Default.PhotoSearchWindowPosition = this.RestoreBounds;
            // Сохранение настроек.
            Properties.Settings.Default.Save();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.ViewModel.Dispose();
            if (this.Owner != null)
            {
                this.Owner.Activate();
            }
        }

        private void PhotoImage_Drop(object sender, DragEventArgs e)
        {
            string file = getImageFilePathByDrag(e);
            if(file != null) this.ViewModel.LoadImageFromFile(file);            
        }

        private string getImageFilePathByDrag(DragEventArgs e)
        {
            string file = null;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Count() == 1)
                {
                    file = files[0];
                    if (this.ViewModel.ValidateImageFileType(file))
                    {
                        return file;
                    }
                    else
                    {
                        file = null;
                    }
                }
            }
            return file;
        }

        //private void PhotoImage_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        //{
        //    if(e.Effects == DragDropEffects.None)
        //    {
        //        Mouse.SetCursor(Cursors.None);
        //    }
        //    else
        //    {
        //        e.UseDefaultCursors = true;
        //    }
        //    e.Handled = true;
        //}

        private void PhotoImage_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
            string file = getImageFilePathByDrag(e);
            if (file != null) e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }
    }
}

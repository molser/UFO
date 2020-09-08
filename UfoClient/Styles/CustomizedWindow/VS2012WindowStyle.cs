using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Collections;
using System.Reflection;

namespace UFO.Styles.CustomizedWindow
{
    internal static class LocalExtensions
    {
        public static void ForWindowFromChild(this object childDependencyObject, Action<Window> action)
        {
            var element = childDependencyObject as DependencyObject;
            while (element != null)
            {
                element = VisualTreeHelper.GetParent(element);
                if (element is Window) { action(element as Window); break; }
            }
        }

        public static void ForWindowFromTemplate(this object templateFrameworkElement, Action<Window> action)
        {
            Window window = ((FrameworkElement)templateFrameworkElement).TemplatedParent as Window;
            if (window != null) action(window);
        }

        public static IntPtr GetWindowHandle(this Window window)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            return helper.Handle;
        }
    }

    public partial class VS2012WindowStyle
    {
        void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((Window)sender).StateChanged += WindowStateChanged;
        }

        void WindowStateChanged(object sender, EventArgs e)
        {

            var w = ((Window)sender);
            var handle = w.GetWindowHandle();
            Border containerBorder = null;
            if (w.AllowsTransparency == true)
            {
                containerBorder = (Border)w.Template.FindName("PART_Container", w);
            }
            else
            {
                containerBorder = (Border)w.Template.FindName("PART_Border", w);
            }
            //var containerBorder = (Border)w.Template.FindName("PART_Border", w);
            
            if (w.WindowState == WindowState.Maximized)
            {
                // Make sure window doesn't overlap with the taskbar.
                var screen = System.Windows.Forms.Screen.FromHandle(handle);

                if (screen.Primary)
                {
                    if(containerBorder.Name== "PART_Container")
                    {
                        containerBorder.Padding = new Thickness(
                        SystemParameters.WorkArea.Left + 7,
                        SystemParameters.WorkArea.Top + 7,
                        (SystemParameters.PrimaryScreenWidth - SystemParameters.WorkArea.Right) + 7,
                        (SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Bottom) + 5);
                    }
                    else if(containerBorder.Name == "PART_Border")
                    {
                        //containerBorder.Margin = new Thickness(7, 7, 7, 5);
                        containerBorder.Padding = new Thickness(7, 7, 7, 5);
                    }
                }
            }
            else
            {
                //containerBorder.Padding = new Thickness(7, 7, 7, 5);
                if (containerBorder.Name == "PART_Container")
                {
                    containerBorder.Padding = new Thickness(0, 0, 0, 0);
                }
                else if (containerBorder.Name == "PART_Border")
                {
                    //containerBorder.Margin = new Thickness(0, 0, 0, 0);
                    containerBorder.Padding = new Thickness(0, 0, 0, 0);
                }
            }           
        }

        #region sizing event handlers

        void OnSizeSouth(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.South); }
        void OnSizeNorth(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.North); }
        void OnSizeEast(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.East); }
        void OnSizeWest(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.West); }
        void OnSizeNorthWest(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.NorthWest); }
        void OnSizeNorthEast(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.NorthEast); }
        void OnSizeSouthEast(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.SouthEast); }
        void OnSizeSouthWest(object sender, MouseButtonEventArgs e) { OnSize(sender, SizingAction.SouthWest); }

        void OnSize(object sender, SizingAction action)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                sender.ForWindowFromTemplate(w =>
                {
                    if (w.WindowState == WindowState.Normal)
                        DragSize(w.GetWindowHandle(), action);
                });
            }
        }

        void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                sender.ForWindowFromTemplate(w => w.Close());
            }
            else
            {
                sender.ForWindowFromTemplate(w =>
                    SendMessage(w.GetWindowHandle(), WM_SYSCOMMAND, (IntPtr)SC_KEYMENU, (IntPtr)' '));
            }
        }
        //void IconPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.ClickCount == 2)
        //    {
        //        sender.ForWindowFromTemplate(w => w.Close());
        //    }
        //    //e.Handled = true;
        //}
        //void IconMouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    sender.ForWindowFromTemplate(w =>
        //             SendMessage(w.GetWindowHandle(), WM_SYSCOMMAND, (IntPtr)SC_KEYMENU, (IntPtr)' '));
        //}

        void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => w.Close());
        }

        void MinButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => w.WindowState = WindowState.Minimized);
        }

        void MaxButtonClick(object sender, RoutedEventArgs e)
        {
            //sender.ForWindowFromTemplate(w => w.WindowState = (w.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized);
            Window window = ((FrameworkElement)sender).TemplatedParent as Window;
            if (window != null)
            {
                foreach (PropertyInfo prop in window.GetType().GetProperties())
                {
                    if (prop.Name == "IsNoResizable") return;
                }
                changeWindowState(window);
            }                
        }

        void changeWindowState(Window window)
        {
            if(window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
            }
            else
            {
                //Раскомментировать для нормальной работы стиля VS2012WindowStyle2
                //чтобы при максимизации, окно не закрывало панель задач 
                //if (window.AllowsTransparency == false)
                //{
                //    var screen = System.Windows.Forms.Screen.FromHandle(window.GetWindowHandle());

                //    if (screen.Primary)
                //    {
                //        //window.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                //        //window.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                //        window.MaxHeight = SystemParameters.WorkArea.Height;
                //        window.MaxWidth = SystemParameters.WorkArea.Width;
                //    }                   
                //}
                window.WindowState = WindowState.Maximized;
            }           
        }

        void TitleBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                MaxButtonClick(sender, e);
            }
            else if (e.LeftButton == MouseButtonState.Pressed)
            {
                Window window = ((FrameworkElement)sender).TemplatedParent as Window;
                if (window != null && window.WindowState != WindowState.Maximized)
                {
                    window.DragMove();
                }                    
                //sender.ForWindowFromTemplate(w => w.DragMove());
            }
        }

        void TitleBarMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                sender.ForWindowFromTemplate(w =>
                {
                    if (w.WindowState == WindowState.Maximized)
                    {
                        w.BeginInit();
                        double adjustment = 40.0;
                        var mouse1 = e.MouseDevice.GetPosition(w);
                        var width1 = Math.Max(w.ActualWidth - 2 * adjustment, adjustment);
                        w.WindowState = WindowState.Normal;
                        var width2 = Math.Max(w.ActualWidth - 2 * adjustment, adjustment);
                        w.Left = (mouse1.X - adjustment) * (1 - width2 / width1);
                        w.Top = -7;
                        w.EndInit();
                        w.DragMove();
                    }
                });
            }
        }

        #endregion

        #region P/Invoke

        const int WM_SYSCOMMAND = 0x112;
        const int SC_SIZE = 0xF000;
        const int SC_KEYMENU = 0xF100;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        void DragSize(IntPtr handle, SizingAction sizingAction)
        {
            SendMessage(handle, WM_SYSCOMMAND, (IntPtr)(SC_SIZE + sizingAction), IntPtr.Zero);
            SendMessage(handle, 514, IntPtr.Zero, IntPtr.Zero);
        }

        public enum SizingAction
        {
            North = 3,
            South = 6,
            East = 2,
            West = 1,
            NorthEast = 5,
            NorthWest = 4,
            SouthEast = 8,
            SouthWest = 7
        }

        #endregion
    }
}
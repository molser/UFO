using System;
using System.Windows;
using System.Windows.Data;
using System.Linq;
using System.Diagnostics;

namespace UFO.Styles.CustomizedWindow
{
    class WindowsStyleToVisibilityMultiConverter :  IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(System.Windows.Visibility))
                throw new InvalidOperationException("The target must be a Visibility");

            //bool isMinimizeButton = false;
            bool isMaximizeButton = false;
            bool isCloseButton = false;
            bool isResizeBorder = false;
            if (parameter!= null)
            {
                switch (parameter.ToString())
                {
                    //case "MinimizeButton":
                    //    isMinimizeButton = true;
                    //    break;
                    case "MaximizeButton":
                        isMaximizeButton = true;
                        break;
                    case "CloseButton":
                        isCloseButton = true;
                        break;
                    case "ResizeBorder":
                        isResizeBorder = true;
                        break;
                }                
            }

            if (values != null)
            {
                bool isHidden = false;
                for (int i = 0; i < values.Count(); i++)
                {
                    if (values[i] is ResizeMode)
                    {
                        if ((ResizeMode)values[i] == ResizeMode.NoResize)
                        {
                            if(isCloseButton != true)
                                return Visibility.Collapsed;
                        }
                        else if ((ResizeMode)values[i] == ResizeMode.CanMinimize)
                        {
                            if(isMaximizeButton == true)
                                return Visibility.Collapsed;
                        }
                    }
                    if (isResizeBorder)
                    {
                        Debug.WriteLine("TypeOf(values[i]): " + values[i].GetType());
                    }
                    if (values[i] is WindowState)
                    {
                        if(isResizeBorder)
                        {
                            WindowState windowState = (WindowState)values[i];
                            if (windowState == WindowState.Maximized)
                            {
                                return Visibility.Collapsed;
                            }
                        }
                    }
                    if (values[i] is Boolean)
                    {
                        if ((bool)values[i] == true)
                        {
                            isHidden = true;
                            //return Visibility.Collapsed;
                        }
                    }
                    if(isHidden) return Visibility.Collapsed;
                }
            }
            return Visibility.Visible;
            
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

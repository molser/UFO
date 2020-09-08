using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UFO
{
    public static class WindowsLog
    {
        private static string appSourseName = "UFO";
        private static string appLogName = "UFO Log";
        public static void Write(string message, 
                                 int eventID = 0, 
                                 EventLogEntryType type = EventLogEntryType.Information, 
                                 string sourceName = null, 
                                 string logName = null)
        {
            if (sourceName == null) sourceName = WindowsLog.appSourseName;
            if (logName == null) logName = WindowsLog.appLogName;
            
            if(!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }
            //using (EventLog appLog = new EventLog())
            EventLog appLog = new EventLog();
            appLog.Source = sourceName;
            appLog.Log = logName;
            try
            {
                appLog.WriteEntry(message, type, eventID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                appLog.Dispose();
            }
        }
        public static void LogAppStart()
        {
            string message = "Событие: запуск приложения UFO." + Environment.NewLine;
            message += "Пользователь: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "." + Environment.NewLine; 
            Write(message,1);
        }

        public static void LogAppExit()
        {
            string message = "Событие: завершение работы приложения UFO." + Environment.NewLine;
            message += "Пользователь: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "." + Environment.NewLine;
            Write(message,255);
        }
        public static void LogPersonSearch(string personFamily, string personName, DateTime? dateStart, DateTime? dateEnd)
        {
            if (dateStart == null) dateStart = DateTime.Now;
            if (dateEnd == null) dateStart = DateTime.Now;
            string message = "Событие: поиск лиц." + Environment.NewLine;
            message += "Фамилия: " + personFamily + ", имя: " + personName + "." + Environment.NewLine;
            message += "Начальная дата: " + dateStart + ", конечная дата: " + dateEnd + "." + Environment.NewLine;
            message += "Пользователь: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + ".";
            Write(message,2);
        }
        public static void LogOpenCompareWindow(string fullName)
        {
            string message = "Событие: открытие окна сравнения лиц." + Environment.NewLine;
            message += "Именные компоненты лица: " + fullName + "." + Environment.NewLine;
            message += "Пользователь: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "." + Environment.NewLine;
            Write(message,3);
        }
        public static void LogOpenSettingsWindow()
        {
            string message = "Событие: открытие окна настроек приложения." + Environment.NewLine;
            message += "Пользователь: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "." + Environment.NewLine; 
            Write(message, 4);
        }
        public static void LogSaveSettings()
        {
            string message = "Событие: изменение настроек приложения." + Environment.NewLine;
            message += "Пользователь: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "." + Environment.NewLine;
            Write(message, 5);
        }
    }    
}

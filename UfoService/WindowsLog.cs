using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfoService
{
    public static class WindowsLog
    {
        private static string appSourseName = "UfoPhotoSearch";
        private static string appLogName = "UfoPhotoSearch Log";
        public static void Write(string message,
                                 int eventID = 0,
                                 EventLogEntryType type = EventLogEntryType.Information,
                                 //string mashineName = ".",
                                 string sourceName = null, 
                                 string logName = null)
        {
            if (sourceName == null) sourceName = WindowsLog.appSourseName;
            if (logName == null) logName = WindowsLog.appLogName;
            
            if(!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }
            using (EventLog appLog = new EventLog())
            {
                //EventLog appLog = new EventLog();
                //appLog.MachineName = mashineName;
                appLog.Source = sourceName;
                appLog.Log = logName;
                appLog.WriteEntry(message, type, eventID);                
            }
        }

        private static void addMainInfoToLogString(string mashineName, string userName, ref string logString)
        {
            logString += "Компьютер: " + mashineName + "." + Environment.NewLine;
            logString += "Пользователь: " + userName + "." + Environment.NewLine;
        }

        public static void LogAppStart()
        {
            string message = "Событие: запуск приложения UFO." + Environment.NewLine;
            message += "Пользователь: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "." + Environment.NewLine; 
            Write(message, 1);
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
        public static void LogSuccessAudit(string mashineName, string userName)
        {
            string message = "Событие: успешная авторизация пользователя." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            Write(message, 6, EventLogEntryType.SuccessAudit);
        }
        public static void LogFailureAudit(string mashineName, string userName)
        {
            string message = "Событие: ошибка авторизации пользователя." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            Write(message, 7, EventLogEntryType.FailureAudit);
        }
        public static void LogPhotoSearchStart(string mashineName, string userName, Guid jobId, string jobParams)
        {
            string message = "Событие: начало поиска по фотографии." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            message += "Идентификатор задачи: " + jobId.ToString() + "." + Environment.NewLine;
            message += "Параметры задачи: " + jobParams + "." + Environment.NewLine;
            Write(message, 8, EventLogEntryType.Information);
        }
        public static void LogPhotoSearchCancel(string mashineName, string userName, Guid jobId)
        {
            string message = "Событие: поиск по фотографии прерван пользователем." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            message += "Идентификатор задачи: " + jobId.ToString() + "." + Environment.NewLine;
            Write(message, 9, EventLogEntryType.Warning);
        }
        public static void LogPhotoSearchEnd(string mashineName, string userName, Guid jobId)
        {
            string message = "Событие: поиск по фотографии завершен успешно." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            message += "Идентификатор задачи: " + jobId.ToString() + "." + Environment.NewLine;
            Write(message, 10, EventLogEntryType.Information);
        }
        public static void LogJobCountOverflow(string mashineName, string userName)
        {
            string message = "Событие: превышено максимально допустимое количество запросов на поиск по фотографии." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            Write(message, 11, EventLogEntryType.Warning);
        }
        public static void LogError(string mashineName, string userName, string error)
        {
            string message = "Событие: ошибка в работе." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            message += "Описание ошибки: " + error + "." + Environment.NewLine;
            Write(message, 12, EventLogEntryType.Error);
        }
        public static void LogSessionEndAudit(string mashineName, string userName)
        {
            string message = "Событие: завершение сеанса пользователя." + Environment.NewLine;
            message += "Компьютер: " + mashineName + "." + Environment.NewLine;
            message += "Пользователь: " + userName + "." + Environment.NewLine;
            Write(message, 13, EventLogEntryType.SuccessAudit);
        }

        public static void LogGetFhotoFromKaskad(string mashineName, string userName, GetPhotoFromKaskadParams jobParams)
        {
            string message = "Событие: получение фото из базы данных Каскад." + Environment.NewLine;
            addMainInfoToLogString(mashineName, userName, ref message);
            message += "Фамилия: " + jobParams.Family + "." + Environment.NewLine;
            message += "Имя Отчество: " + jobParams.Name + "." + Environment.NewLine;
            if(jobParams.Birthday != new DateTime())
            {
                message += "Дата рождения: " + jobParams.Birthday.ToShortDateString() + "." + Environment.NewLine;
            }
            message += "Дата операции с " + jobParams.OperationDateStart.ToString("dd.MM.yyyy HH:mm");
            message += " по " + jobParams.OperationDateEnd.ToString("dd.MM.yyyy HH:mm") + "." + Environment.NewLine;
            Write(message, 14, EventLogEntryType.Information);
        }
    }    
}

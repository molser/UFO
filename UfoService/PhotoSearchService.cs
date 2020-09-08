using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace UfoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
                     ConcurrencyMode = ConcurrencyMode.Reentrant)]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [ErrorBehavior(typeof(PhotoSearchServiceErrorHandler))]
    public class PhotoSearchService : IPhotoSearchService, IDisposable
    {
        public static int RunningJobsCount = 0;
        private Process script;
        private bool isJobCancelled=false;
        private bool isJobRunning = false;
        private bool isUserAuthorized = false;
        private int CONCURRENT_JOBS_COUNT = Properties.Settings.Default.ConcurrentJobsCount;
        private Guid guid;
        private IPhotoSearchServiceCallback callback;
        private string userName;
        private string mashineName;
        private string scriptPath;
        private string resultFolderPath;
        private string serviceLogFilePath;
        public PhotoSearchService()
        {
            this.setParams();
            this.writeLogLine("Builded UfoSevice");
            Console.WriteLine("Builded UfoSevice:   " + this.GetHashCode().ToString());            
        }

        private void setParams()
        {
            string currentDirPath = Environment.CurrentDirectory;

            this.scriptPath = currentDirPath + "\\TestScript.vbs";
            this.resultFolderPath = currentDirPath;
            this.serviceLogFilePath = currentDirPath + "\\UfoService.log";

            Console.WriteLine("scriptPath:   " + this.scriptPath);
            Console.WriteLine("this.resultFolderPath:   " + this.resultFolderPath);
            Console.WriteLine("this.serviceLogFilePath:   " + this.serviceLogFilePath);

            if (File.Exists(Properties.Settings.Default.ScriptPath))
                this.scriptPath = Properties.Settings.Default.ScriptPath;
            if (Directory.Exists(Properties.Settings.Default.ResultFolderPath))
                this.resultFolderPath = Properties.Settings.Default.ResultFolderPath;
            if (File.Exists(Properties.Settings.Default.ServiceLogFilePath))
                this.serviceLogFilePath = Properties.Settings.Default.ServiceLogFilePath;
            Console.WriteLine("scriptPath:   " + this.scriptPath);
            Console.WriteLine("this.resultFolderPath:   " + this.resultFolderPath);
            Console.WriteLine("this.serviceLogFilePath:   " + this.serviceLogFilePath);

        }

        public bool IsJobRunning
        {
            get { return this.isJobRunning; }
            set { this.isJobRunning = value; }
        }

        private bool validateUser(string mashineName)
        {
            this.mashineName = mashineName;
            if (this.isUserAuthorized) return true;
            bool result = false;
            IPrincipal principal = Thread.CurrentPrincipal;
            this.userName = principal.Identity.Name;
            if (principal.Identity.IsAuthenticated)
            {
                if (principal.IsInRole("Администраторы")) result = true;
                if ((!result) && principal.IsInRole(Properties.Settings.Default.GrantedUserRole)) result = true;
            }
            if(result)
            {
                this.isUserAuthorized = true;
                this.writeLogLine("Successful access. Mashine name: " + this.mashineName + ", user name: " + this.userName);
                Console.WriteLine("Successful access. Mashine name: " + this.mashineName + ", user name: " + this.userName);
                WindowsLog.LogSuccessAudit(this.mashineName, this.userName);
            }
            else
            {
                this.isUserAuthorized = false;
                this.writeLogLine("Access is denied. Mashine name: " + this.mashineName + ", user name: " + this.userName);
                Console.WriteLine("Access is denied. Mashine name: " + this.mashineName + ", user name: " + this.userName);
                WindowsLog.LogFailureAudit(this.mashineName, this.userName);
            }
            return result;
        }


        //[PrincipalPermission(SecurityAction.Demand, Role = "Администраторы")]
        //[PrincipalPermission(SecurityAction.Demand, Role = "ufo")]
        public void SearchPersonByPhoto(SearchPersonByPhotoParams jobParams)
        {
            this.callback = OperationContext.Current.GetCallbackChannel<IPhotoSearchServiceCallback>();
            PhotoSearchServiceResult result = new PhotoSearchServiceResult();

            if (!this.isUserAuthorized)
            {
                if (!validateUser(jobParams.MashineName))
                {
                    result.Type = PhotoSearchServiceResultType.Error;
                    result.Data = "Доступ запрещен";
                    this.callback.PhotoSearchServiceCallback(result);
                    return;
                }
            }

            /*
            if (!jobParams.IsSupressed && String.IsNullOrEmpty(jobParams.Natinality))
            {
                //this.callback.Result("Confirmation", "Вы не выбрали параметр 'Гражданство'."
                //                                        + Environment.NewLine + "Запрос может занять продолжительное время.");

                result.ResultType = SearchPersonByPhotoResultType.Confirmation;
                result.Result = "Вы не выбрали параметр 'Гражданство'."
                                + Environment.NewLine + "Запрос может занять продолжительное время.";
                this.callback.PhotoSearchServiceCallback(result);

                return;
            }
            */

            int runningJobsCount = Interlocked.CompareExchange(ref PhotoSearchService.RunningJobsCount, CONCURRENT_JOBS_COUNT, CONCURRENT_JOBS_COUNT);
            if (runningJobsCount >= CONCURRENT_JOBS_COUNT)
            {
                //this.callback.Result("Error","В данный момент служба обрабатывает другие запросы, попробуйте повторить запрос позже");

                result.Type = PhotoSearchServiceResultType.Error;
                result.Data = "В данный момент служба обрабатывает другие запросы, попробуйте повторить запрос позже";
                this.callback.PhotoSearchServiceCallback(result);

                this.writeLogLine("Error max jobs count overload, count: " + runningJobsCount.ToString());
                Console.WriteLine("Error max jobs count overload, count: " + runningJobsCount.ToString());
                WindowsLog.LogJobCountOverflow(this.mashineName, this.userName);
                return;
            }
            Interlocked.Increment(ref PhotoSearchService.RunningJobsCount);
            this.isJobRunning = true;            
            this.guid = Guid.NewGuid();
            string imagePath = this.resultFolderPath + "\\" + this.guid.ToString();
            if(!String.IsNullOrEmpty(jobParams.PhotoFileExtention))
            {
                imagePath += "." + jobParams.PhotoFileExtention;
            }

            try
            {
                File.WriteAllBytes(imagePath, jobParams.PhotoArray);

                Process script = new Process();
                this.script = script;
                script.StartInfo.UseShellExecute = false;
                script.StartInfo.FileName = Properties.Settings.Default.ScriptEngine;
                //script.StartInfo.FileName = "cscript";
                //script.StartInfo.Arguments = Properties.Settings.Default.ScriptPath + " " + imagePath + " -s " + sex + " -y " + year + " -n " + natinality;

                StringBuilder args = new StringBuilder();
                args.Append(this.scriptPath).Append(" ").Append(imagePath);
                if (!String.IsNullOrEmpty(jobParams.Sex)) args.Append(" -s ").Append(jobParams.Sex);
                if (!String.IsNullOrEmpty(jobParams.Years)) args.Append(" -y ").Append(jobParams.Years);
                if (!String.IsNullOrEmpty(jobParams.Natinality)) args.Append(" -n ").Append(jobParams.Natinality);
#if DEBUG
                //args.Append(" -g ").Append(this.guid.ToString());
#endif
                script.StartInfo.Arguments = args.ToString();

                this.writeLogLine(script.StartInfo.FileName + " " + script.StartInfo.Arguments);
                Console.WriteLine(script.StartInfo.FileName + " " + script.StartInfo.Arguments);
                script.StartInfo.UseShellExecute = false;
                script.StartInfo.CreateNoWindow = true;
                script.StartInfo.RedirectStandardError = true;
                script.StartInfo.StandardErrorEncoding = Encoding.GetEncoding(Properties.Settings.Default.ErrorCharSet);
                script.EnableRaisingEvents = true;
                script.Exited += Script_Exited;
                this.writeLogLine("Job " + this.guid + " started");
                Console.WriteLine("Job " + this.guid + " started");
                WindowsLog.LogPhotoSearchStart(this.mashineName, this.userName, this.guid, script.StartInfo.Arguments);
                script.Start();
                //script.WaitForExit();


            }
            catch (Exception ex)
            {
                this.writeLogLine("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
                WindowsLog.LogError(this.mashineName, this.userName, ex.Message);
                //this.callback.Result("Error: ", ex.Message);
                result.Type = PhotoSearchServiceResultType.Error;
                result.Data = ex.Message;
                this.callback.PhotoSearchServiceCallback(result);
                //runningJobsCount = Interlocked.CompareExchange(ref UfoService.RunningJobsCount, 0, 0);
                //this.writeLogLine("Jobs count: " + runningJobsCount);
                //Console.WriteLine("Jobs count: " + runningJobsCount);                                
            }          
            
        }

        public PhotoSearchServiceResult GetFhotoFromKaskad(GetPhotoFromKaskadParams jobParams)
        {
            //throw new FaultException<string>("Доступ запрещен!", new FaultReason("Доступ запрещен!!"));
            PhotoSearchServiceResult result = new PhotoSearchServiceResult();
            if (!this.isUserAuthorized)
            {
                if (!validateUser(jobParams.MashineName))
                {
                    result.Type = PhotoSearchServiceResultType.Error;
                    result.Data = "Доступ запрещен";
                    return result;
                }
            }
            result.Type = PhotoSearchServiceResultType.OK;

            string message = "Get photo from Kaskad.";
            message += " Family: " + jobParams.Family + ".";
            message += " Name: " + jobParams.Name + ".";
            if (jobParams.Birthday != new DateTime())
            {
                message += " Birthday: " + jobParams.Birthday.ToShortDateString() + ".";
            }
            message += " Operation date from " + jobParams.OperationDateStart.ToString("dd.MM.yyyy HH:mm");
            message += " to " + jobParams.OperationDateEnd.ToString("dd.MM.yyyy HH:mm") + ".";

            this.writeLogLine(message);
            Console.WriteLine(message);
            WindowsLog.LogGetFhotoFromKaskad(this.mashineName, this.userName, jobParams);
            
            return result;
        }

        private void Script_Exited(object sender, EventArgs e)
        {
            this.script.Exited -= this.Script_Exited;
            PhotoSearchServiceResult result = new PhotoSearchServiceResult();
            string html = String.Empty;
            int exitCod = this.script.ExitCode;
            if (exitCod != 0 && this.isJobCancelled == false)
            {
                this.writeLogLine("Script has abnormally exited with cod: " + exitCod);
                Console.WriteLine("Script has abnormally exited with cod: " + exitCod);
                WindowsLog.LogError(this.mashineName, this.userName, "Выплнение скрипта завершилось неудачно. Код выхода: " + exitCod);
            }
            if (this.isJobCancelled == true)
            {
                //this.Callback.Result("Cancel", "Выполнение задачи прервано");
                this.writeLogLine("Job " + this.guid + " cancelled");
                Console.WriteLine("Job " + this.guid + " cancelled");
                WindowsLog.LogPhotoSearchCancel(this.mashineName, this.userName, this.guid);
                this.isJobCancelled = false;
            }
            else
            {
                string stderr = this.script.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                if (!String.IsNullOrEmpty(stderr))
                {
                    stderr = stderr.Replace(Environment.NewLine, " ");
                    this.writeLogLine("Error: " + stderr);
                    Console.WriteLine("Error: " + stderr);
                    WindowsLog.LogError(this.mashineName, this.userName, stderr);
                    //FaultReason reason = new FaultReason(stderr);
                    //throw new FaultException<ScriptExecutionFault>(new ScriptExecutionFault(stderr), reason);
                    //this.callback.Result("Error: ", stderr);
                    result.Type = PhotoSearchServiceResultType.Error;
                    result.Data = stderr;
                    this.callback.PhotoSearchServiceCallback(result);

                }
                else
                {
                    this.writeLogLine("Job " + this.guid + " reading html");
                    Console.WriteLine("Job " + this.guid + " reading html");
                    try
                    {
                        html = File.ReadAllText(this.resultFolderPath + "\\" + this.guid.ToString() + ".html", Encoding.UTF8);
                        //result = File.ReadAllText(Properties.Settings.Default.ResultFolderPath + "\\" + "528671ff-b90b-487e-a725-02af54775657.html", Encoding.UTF8);
                        //result = File.ReadAllText(Properties.Settings.Default.ResultFolderPath + "\\" + "ufo3.html", Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        this.writeLogLine("Error: " + ex.Message);
                        Console.WriteLine("Error: " + ex.Message);
                        WindowsLog.LogError(this.mashineName, this.userName, stderr);
                        //this.callback.Result("Error: ", ex.Message);
                        result.Type = PhotoSearchServiceResultType.Error;
                        result.Data = ex.Message;
                        this.callback.PhotoSearchServiceCallback(result);
                    }

                }
            }
            if (!String.IsNullOrEmpty(html))
            {
                try
                {
                    this.writeLogLine("Job " + this.guid + " sending html to client");
                    Console.WriteLine("Job " + this.guid + " sending html to client");
                    //this.callback.Result("OK", html);
                    result.Type = PhotoSearchServiceResultType.OK;
                    result.Data = html;
                    this.callback.PhotoSearchServiceCallback(result);
                    this.writeLogLine("Job " + this.guid + " completed");
                    Console.WriteLine("Job " + this.guid + " completed");
                    WindowsLog.LogPhotoSearchEnd(this.mashineName, this.userName, this.guid);
                }
                catch (Exception ex)
                {
                    this.writeLogLine("Error: " + ex.Message);
                    Console.WriteLine("Error: " + ex.Message);
                    WindowsLog.LogError(this.mashineName, this.userName, ex.Message);
                }
            }

            //this.disposeScript();
            if (this.isJobRunning == true)
            {
                Interlocked.Decrement(ref PhotoSearchService.RunningJobsCount);
                this.isJobRunning = false;
            }
        }

        public void CancelSearchPersonByPhoto()
        {
            if (!this.isJobRunning || this.script == null)
            {
                return;
                //throw new Exception("There is not job to cancel");
            }
            this.writeLogLine("Job " + this.guid + " cancelling");
            Console.WriteLine("Job " + this.guid + " cancelling");
            this.isJobCancelled = true;
            if (!this.script.HasExited) this.script.Kill();
        }

        private void writeLogLine(string line)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            sb.Append(now.ToString("dd.MM.yyyy HH:mm:ss.fff"));
            sb.Append(" - ").Append(this.GetHashCode()).Append(" - ");
            sb.Append(" ").Append(line).Append(Environment.NewLine);
            //string lineResult = now.ToString("dd.MM.yyyy HH:mm:ss") + " - " + " - " + " " + line + Environment.NewLine;
            File.AppendAllText(this.serviceLogFilePath, sb.ToString());            
        }
        public void Dispose()
        {
            this.writeLogLine("Disposing UfoSevice");
            Console.WriteLine("Disposing UfoSevice:   " + this.GetHashCode().ToString());
            if (this.isJobRunning == true)
            {
                if(this.script != null)
                {
                    if(!this.script.HasExited)
                    {
                        this.script.Exited -= this.Script_Exited;
                        this.writeLogLine("Killing script " + this.GetHashCode().ToString());
                        Console.WriteLine("Killing script   " + this.GetHashCode().ToString());
                        if(!this.script.HasExited) this.script.Kill();
                        this.script.Dispose();
                    }                    
                }
                this.writeLogLine("Decrementing jobCount " + this.GetHashCode().ToString());
                Console.WriteLine("Decrementing jobCount   " + this.GetHashCode().ToString());
                if (this.isJobRunning == true)
                {
                    Interlocked.Decrement(ref PhotoSearchService.RunningJobsCount);
                    this.isJobRunning = false;
                }
            }            
            this.writeLogLine("Closed UfoSevice");
            Console.WriteLine("Closed UfoSevice:   " + this.GetHashCode().ToString());
            WindowsLog.LogSessionEndAudit(this.mashineName, this.userName);
        }
    }
}

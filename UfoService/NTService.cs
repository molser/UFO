using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;

namespace UfoService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            service = new ServiceInstaller();
            service.ServiceName = "UfoPhotoSearchService";
            service.Description = "Служба поиска лиц по фотографии в комплексе Ufo";
            service.StartType = ServiceStartMode.Automatic;

            Installers.Add(process);
            Installers.Add(service);
        }
    }
    public partial class NTService : ServiceBase
    {
        internal static ServiceHost ufoServiceHost = null;
        public NTService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (ufoServiceHost != null)
            {
                ufoServiceHost.Close();
            }
            ufoServiceHost = new ServiceHost(typeof(PhotoSearchService));
            ufoServiceHost.Open();
            this.writeLogLine("UfoPhotoSearchService is running...");
        }

        protected override void OnStop()
        {
            if (ufoServiceHost != null)
            {
                this.writeLogLine("Stopping service...");                
                ufoServiceHost.Close();                        
                ufoServiceHost = null;
            }
        }

        private void writeLogLine(string line)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            sb.Append(now.ToString("dd.MM.yyyy HH:mm:ss.fff"));
            sb.Append(" - ").Append(this.GetHashCode()).Append(" - ");
            sb.Append(" ").Append(line).Append(Environment.NewLine);
            System.IO.File.AppendAllText(Properties.Settings.Default.ServiceLogFilePath, sb.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceProcess;
using System.Text;

namespace UfoService
{
    class Program
    {
        internal static ServiceHost ufoServiceHost = null;
        static void Main(string[] args)
        {

#if DEBUG
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            if (ufoServiceHost != null)
            {
                ufoServiceHost.Close();
            }

            ufoServiceHost = new ServiceHost(typeof(PhotoSearchService));
            ufoServiceHost.Open();

            Console.WriteLine("UfoService is running...");
            Console.WriteLine("Press any key to stop service.");
            Console.ReadKey();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new NTService()
            };
            ServiceBase.Run(ServicesToRun);
#endif


        }
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            if (ufoServiceHost != null)
            {
                Console.WriteLine("Stopping service...");

                //foreach (ChannelDispatcherBase channelDispatcherBase in ufoServiceHost.ChannelDispatchers)
                //{
                //    ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                //    channelDispatcher.Endpoints;
                //}
                ufoServiceHost.Close();
                //((IDisposable)ufoServiceHost).Dispose();                
                ufoServiceHost = null;
            }
        }
    }
}

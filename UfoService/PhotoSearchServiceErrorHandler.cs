using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;

namespace UfoService
{
    public class PhotoSearchServiceErrorHandler : IErrorHandler
    {
        // Provide a fault. The Message fault parameter can be replaced, or set to
        // null to suppress reporting a fault.
        private string serviceLogFilePath;
        public PhotoSearchServiceErrorHandler()
        {
            string currentDirPath = Environment.CurrentDirectory;
            this.serviceLogFilePath = currentDirPath + "\\UfoService.log";
            if (File.Exists(Properties.Settings.Default.ServiceLogFilePath))
                this.serviceLogFilePath = Properties.Settings.Default.ServiceLogFilePath;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        { 
            FaultException<string> faultException = new FaultException<string>(error.Message, new FaultReason(error.Message));
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, faultException.Action);            

        }

        // HandleError. Log an error, then allow the error to be handled as usual.
        // Return true if the error is considered as already handled

        public bool HandleError(Exception error)
        { 
            using (TextWriter tw = File.AppendText(this.serviceLogFilePath))
            {
                if (error != null)
                {                   

                    string errorText = error.GetType().Name + " - " + error.Message;
                    if (error.InnerException != null)
                    {
                        errorText += Environment.NewLine + " " + error.InnerException.Message;
                    }
                    //if (error.StackTrace != null)
                    //{
                    //    errorText += Environment.NewLine + error.StackTrace;
                    //}

                    tw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")
                                //+ OperationContext.Current.Channel.GetHashCode()
                                + " - HandleError: - " + error.GetType().Name
                                + " - " + error.Message
                                //+ " - extentionInfo: " + extentionInfo);
                                );
                    Console.WriteLine(//DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")
                                "HandleError: - " + errorText);
                }
                tw.Close();
            }
            

            //if (service != null)
            //{
            //    if (service.IsJobRunning == true)
            //    {
            //        Interlocked.Decrement(ref UfoService.RunningJobsCount);
            //        service.IsJobRunning = false;                   
            //    }
            //}            
            return true;
        }
    }

    // This attribute can be used to install a custom error handler for a service
    public sealed class ErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        Type errorHandlerType;

        public ErrorBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        public Type ErrorHandlerType
        {
            get { return this.errorHandlerType; }
        }

        void IServiceBehavior.Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
        }

        void IServiceBehavior.AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
        {
        }

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
        {
            IErrorHandler errorHandler;

            try
            {
                errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
            }
            catch (MissingMethodException e)
            {
                throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must have a public empty constructor.", e);
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must implement System.ServiceModel.Dispatcher.IErrorHandler.", e);
            }

            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }

}

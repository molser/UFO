using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using UFO.PhotoSearchServiceReference;

namespace UFO
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class PhotoSearchServiceContext : IPhotoSearchServiceCallback
    {
        public event EventHandler<PhotoSearchServiceCallBackEventArgs> OnServiceCallBack;
        public void PhotoSearchServiceCallback(PhotoSearchServiceResult photoSearchServiceResult)
        {
            //this.writeLogLine("status: " + status + " result: " + result);
            if (this.OnServiceCallBack != null)
            {
                PhotoSearchServiceCallBackEventArgs args = new PhotoSearchServiceCallBackEventArgs()
                {
                    Result = photoSearchServiceResult
                };
                this.OnServiceCallBack(this, args);
            }
        }
        private void writeLogLine(string line)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            sb.Append(now.ToString("dd.MM.yyyy HH:mm:ss.fff"));
            //sb.Append(" - ").Append(this.GetHashCode()).Append(" - ");
            sb.Append(" ").Append(line).Append(Environment.NewLine);            
            File.AppendAllText("UfoClient.log", sb.ToString());
        }
    }

}

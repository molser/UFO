using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFO.PhotoSearchServiceReference;

namespace UFO
{
    public class PhotoSearchServiceCallBackEventArgs : EventArgs
    {
        //public string Status { get; set; }
        //public string Result { get; set; }
        public PhotoSearchServiceResult Result { get; set; }
    }
}

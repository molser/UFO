using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO
{
    public class AppObjectBase : INotifyPropertyChanged
    {
        private bool isChecked;        
        public bool IsChecked
        {
            get { return this.isChecked; }
            set
            {
                this.isChecked = value;
                this.OnPropertyChanged("IsChecked");
            }
        }
        public virtual string NameBase
        {
            get { return "BaseAppObject"; }
        }
        public virtual string Id
        {
            get { return "0"; }
            set { }
        }
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                this.EnsureProperty(propertyName);
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Conditional("DEBUG")]
        private void EnsureProperty(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException("Property does not exist.", "propertyName");
            }
        }
        #endregion
    }
}

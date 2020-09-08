using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO
{
    public class PropertySet
    {
        private HashSet<String> properties = new HashSet<String>();
        public bool Add(string permission)
        {
            return properties.Add(permission);
        }

        public bool this[string property]
        {
            get
            {
                return properties.Contains(property);
            }            
        }
    }
}

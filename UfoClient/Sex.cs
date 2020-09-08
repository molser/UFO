using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFO
{
    public enum SexName
    {
        мужской,
        женский,
        неопределенный
    }
    public class Sex : IEquatable<Sex>
    {
        private SexName name;
        private string id;
        public SexName Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                switch (value)
                {
                    case SexName.мужской:
                        this.id = "M";
                        break;
                    case SexName.женский:
                        this.id = "F";
                        break;
                    default:
                        this.id = String.Empty;
                        break;
                }                
            }
        }
        public string Id
        {
            get { return this.id; }
            set
            {
                if(value == null)
                {
                    value = String.Empty;
                }
                switch (value)
                {
                    case "M":
                        this.id = value;
                        this.name = SexName.мужской;                        
                        break;
                    case "F":
                        this.id = value;
                        this.name = SexName.женский;
                        break;
                    default:
                        this.id = String.Empty;
                        this.name = SexName.неопределенный;
                        break;
                }
            }
        }
        public Sex()
        {
            this.Name = SexName.неопределенный;
        }

        public Sex(SexName name)
        {            
            this.Name = name;            
        }
        public Sex(string id)
        {           
            this.Id = id;
        }

        public static List<Sex> GetSexs()
        {
            List<Sex> list = new List<Sex>();
            //list.Add(new Sex() { Name = String.Empty, Id = String.Empty });
            list.Add(new Sex(SexName.мужской));
            list.Add(new Sex(SexName.женский));
            return list;
        }

        #region IEquatable<Sex>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Sex objAsPart = obj as Sex;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
        public bool Equals(Sex other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
        #endregion
    }
}

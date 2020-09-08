using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UFO
{
    public class Nationality : AppObjectBase,  IEquatable<Nationality>
    {
        #region Private Members
        private string id;
        private string name;
        private const string NAME_ERROR = @"Значение может содержать только буквы, цифры, пробел и знаки: ._ /\()-";

        #endregion

        #region Constructor
        public Nationality()
        {
            id = String.Empty;
            name = String.Empty;            
        }

        public Nationality(string id,                     
                           string name)
        {
           
            this.id = id;
            this.name = name;
        }
        #endregion
        
        #region Properties

        public override string NameBase
        {
            get
            {
                return this.name;
            }
        }

        public override string Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.OnPropertyChanged("Id");
            }
        }
        public static string ValidCharsForName
        {
            get { return @"а-яА-Яa-zA-Z0-9() _\-./\\"; }
        }

     
        public string Name
        {
            get { return this.name; }
            set
            {
                //IsNameValid(value);
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        #endregion

        #region Validation

        //public bool IsNameValid(string value)
        //{
        //    bool isValid = true;


        //    var regex = new Regex("^[а-яА-Яa-zA-Z0-9 _ /\\.]*$");
        //    if (!regex.IsMatch(value))
        //    {
        //        AddError("Name", NAME_ERROR, false);
        //        isValid = false;
        //    }
        //    else RemoveError("Name", NAME_ERROR);


        //    return isValid;
        //}

        #endregion

        #region IEquatable<Nationality>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Nationality objAsPart = obj as Nationality;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
        public bool Equals(Nationality other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }


        #endregion

    }
}

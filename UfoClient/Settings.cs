using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace UFO
{
    public class Settings
    {
        private static string mainDbConnectionString;
        private static string kaskadDbConnectionString;
        
        private string sqlServer;
        private string dataBaseName;
        private string login;
        private string password;

        private string kaskadSqlServer;
        private string kaskadDataBaseName;
        private string kaskadLogin;
        private string kaskadPassword;

        private string index;
        private string theme;
        private byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        //private bool passwordHasChanged = false;

        bool isKaskadDbUsed = false;

        public Settings()
        {            
            //this.Load();
        }

        public string GenerateConnectionString(bool isKaskadDbUsed = false)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            
            if(!isKaskadDbUsed)
            {
                builder["Data Source"] = this.SqlServer;
                builder["Initial Catalog"] = this.DataBaseName;
                builder["Integrated Security"] = false;
                builder["User ID"] = this.Login;
                builder["Password"] = this.Password;
                builder["Asynchronous Processing"] = true;
            }
            else
            {
                builder["Data Source"] = this.KaskadSqlServer;
                builder["Initial Catalog"] = this.KaskadDataBaseName;
                builder["Integrated Security"] = false;
                builder["User ID"] = this.KaskadLogin;
                builder["Password"] = this.KaskadPassword;
                builder["Asynchronous Processing"] = true;
            }
            return builder.ConnectionString;
        }

        public static string GlobalMainDbConnectionString
        {
            get { return mainDbConnectionString; }
            private set { Interlocked.Exchange(ref mainDbConnectionString, value); }
        }
        public static string GlobalKaskadDbConnectionString
        {
            get { return kaskadDbConnectionString; }
            private set { Interlocked.Exchange(ref kaskadDbConnectionString, value); }
        }


        public string Crypt(string text)
        {
            if (text == null) return null;
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public string Decrypt(string text)
        {
            if (text == null) return null;
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        public void SetGlobal()
        {
            GlobalMainDbConnectionString = this.GenerateConnectionString();
            GlobalKaskadDbConnectionString = this.GenerateConnectionString(true);
        }

        public void Load()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.CreateSubKey("Software\\UFO");

                if (regKey.GetValue("SqlServer") != null) this.sqlServer = regKey.GetValue("SqlServer").ToString();
                if(regKey.GetValue("DatabaseName") != null) this.dataBaseName = regKey.GetValue("DatabaseName").ToString();
                if(regKey.GetValue("Login") != null) this.login = regKey.GetValue("Login").ToString();
                if(regKey.GetValue("Password") != null) this.password = this.Decrypt(regKey.GetValue("Password").ToString());

                if (regKey.GetValue("KaskadSqlServer") != null) this.kaskadSqlServer = regKey.GetValue("KaskadSqlServer").ToString();
                if (regKey.GetValue("KaskadDatabaseName") != null) this.kaskadDataBaseName = regKey.GetValue("KaskadDatabaseName").ToString();
                if (regKey.GetValue("KaskadLogin") != null) this.kaskadLogin = regKey.GetValue("KaskadLogin").ToString();
                if (regKey.GetValue("KaskadPassword") != null) this.kaskadPassword = this.Decrypt(regKey.GetValue("KaskadPassword").ToString());

                if (regKey.GetValue("IsKaskadDbUsed") != null) this.IsKaskadDbUsed = Convert.ToBoolean(regKey.GetValue("IsKaskadDbUsed"));

                if (regKey.GetValue("Index") != null) index = regKey.GetValue("Index").ToString();
                if (regKey.GetValue("Theme") != null) theme = regKey.GetValue("Theme").ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Ошибка");
            }

        }

        public void SetMainDefaults()
        {            
            this.sqlServer = "Ufo\\SQL2008";
            this.dataBaseName = "ufo";
            this.login = "admin";
            this.password = "1";
            this.index = "Р,К,П";            

        }

        public void SetKaskadDefaults()
        {
            this.kaskadSqlServer = "KaskadSRV";
            this.kaskadDataBaseName = "kaskad";
            this.kaskadLogin = "admin";
            this.kaskadPassword = "1";
        }

        public void Save()
        {            
            string encPwd = null;
            string kaskadEncPwd = null;
            if (this.password != null) encPwd = this.Crypt(this.password);
            if (this.kaskadPassword != null) kaskadEncPwd = this.Crypt(this.kaskadPassword);
            try
            {
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.CreateSubKey("Software\\UFO");

                regKey.SetValue("SqlServer", this.sqlServer);
                regKey.SetValue("DatabaseName", this.dataBaseName);
                regKey.SetValue("Login", this.login);
                if(encPwd != null) regKey.SetValue("Password", encPwd);

                if(this.kaskadSqlServer != null) regKey.SetValue("KaskadSqlServer", this.kaskadSqlServer);
                if (this.kaskadDataBaseName != null) regKey.SetValue("KaskadDatabaseName", this.kaskadDataBaseName);
                if (this.kaskadLogin != null) regKey.SetValue("KaskadLogin", this.kaskadLogin);
                if (kaskadEncPwd != null) regKey.SetValue("KaskadPassword", kaskadEncPwd);

                regKey.SetValue("IsKaskadDbUsed", this.IsKaskadDbUsed);                

                if(this.index != null) regKey.SetValue("Index", this.index);
                if(this.theme != null) regKey.SetValue("Theme", this.theme);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }

        }
        public bool IsCorrect
        {
            get
            {
                return !String.IsNullOrEmpty(sqlServer)
                    && !String.IsNullOrEmpty(dataBaseName)
                    && !String.IsNullOrEmpty(login)
                    && !(this.password == null);
            }
        }

        public string SqlServer
        {
            get { return sqlServer; }
            set { this.sqlServer = value; }
        }
        public string DataBaseName
        {
            get { return dataBaseName; }
            set { this.dataBaseName = value; }
        }
        public string Login
        {
            get { return login; }
            set { this.login = value; }
        }
        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        public string KaskadSqlServer
        {
            get { return this.kaskadSqlServer; }
            set { this.kaskadSqlServer = value; }
        }
        public string KaskadDataBaseName
        {
            get { return this.kaskadDataBaseName; }
            set { this.kaskadDataBaseName = value; }
        }
        public string KaskadLogin
        {
            get { return this.kaskadLogin; }
            set { this.kaskadLogin = value; }
        }
        public string KaskadPassword
        {
            get { return this.kaskadPassword; }
            set { this.kaskadPassword = value; }
        }

        //public bool PasswordHasChanged
        //{
        //    get { return this.passwordHasChanged; }
        //    set { this.passwordHasChanged = value; }
        //}

        public string Index
        {
            get { return index; }
            set { this.index = value; }
        }
        public string Theme
        {
            get { return this.theme; }
            set { this.theme = value; }
        }

        public bool IsKaskadDbUsed
        {
            get { return this.isKaskadDbUsed; }
            set { this.isKaskadDbUsed = value; }
        }
        public Settings Clone()
        {
            Settings newSettings = new Settings();
            newSettings.SqlServer = this.sqlServer;
            newSettings.DataBaseName = this.dataBaseName;
            newSettings.Login = this.login;
            newSettings.Password = this.password;
            newSettings.Index = this.index;
            newSettings.Theme = this.theme;
            newSettings.IsKaskadDbUsed = this.isKaskadDbUsed;
            newSettings.KaskadSqlServer = this.kaskadSqlServer;
            newSettings.KaskadDataBaseName = this.kaskadDataBaseName;
            newSettings.KaskadLogin = this.kaskadLogin;
            newSettings.KaskadPassword = this.kaskadPassword;
            return newSettings;
        }
    }
}

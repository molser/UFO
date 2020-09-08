using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
//using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.ComponentModel;

namespace UFO
{
    public class DbCheckEventArgs: EventArgs
    {
        public bool Result;
    }
    public class DbWorker
    {
        private string mainDbConnectionString;
        private string kaskadDbConnectionString;
        private DBConnectionSplashScreen splashScreen;
        private bool isDbConnectionOkMessageRequired;
        private BackgroundWorker backgroundWorker;        

        public  EventHandler<DbCheckEventArgs> CheckDbConnectionComplitted;

        public DbWorker()
            :this(Settings.GlobalMainDbConnectionString,
                 Settings.GlobalKaskadDbConnectionString)
        {            
        }
        public DbWorker(string defaultConnectionString,
                        string kaskadConnectionString)
        {
            this.mainDbConnectionString = defaultConnectionString;
            this.kaskadDbConnectionString = kaskadConnectionString;
            this.backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        public string MainDbConnectionString
        {
            get { return this.mainDbConnectionString; }
            set { this.mainDbConnectionString = value; }
        }
        public string KaskadDbConnectionString
        {
            get { return this.kaskadDbConnectionString; }
            set { this.kaskadDbConnectionString = value; }
        }
        private  DataTable RunQuery(string sqlquery)
        {
            string connectionString = this.mainDbConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }

        private string RunQueryScalar(string sqlquery)
        {
            string result = "";
            string connectionString = this.mainDbConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlquery, connection);
                    connection.Open();
                    result = command.ExecuteScalar().ToString();
                    return result;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }

        private object exequteScalar(SqlCommand command, string connectionStr = null)
        {
            if (connectionStr == null) connectionStr = this.mainDbConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {                
                conn.Open();
                command.Connection = conn;
                return command.ExecuteScalar();                
            }
        }

        private static object exequteScalarStatic(SqlCommand command, string connectionStr)
        {
            //if (connectionStr == null) connectionStr = this.getConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                command.Connection = conn;
                return command.ExecuteScalar();
            }
        }

        private void exequteReader(SqlCommand command, Action<SqlDataReader> action, string connectionStr = null)
        {
            if (connectionStr == null) connectionStr = this.mainDbConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                command.Connection = conn;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        action(reader);
                    }
                }
            }          
        }

        /*
        private async static Task<object> exequteScalarStaticAsync(CancellationToken token, 
                                                                   SqlCommand command, 
                                                                   string connectionStr = null)
        {
            if (connectionStr == null) connectionStr = connectionString;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                await conn.OpenAsync(token).ConfigureAwait(false);
                command.Connection = conn;
                return await command.ExecuteScalarAsync(token).ConfigureAwait(false);
            }
        }
        */

        public List<Person> GetPassengersQuery(DateTime? startDate, DateTime? endDate, string ufoFamily, string ufoName, int ndb, string index)
        {
            DateTime updatedStartDate = startDate ?? DateTime.Now;
            DateTime updatedEndDate = endDate ?? DateTime.Now;
            string strDateStart = updatedStartDate.ToString("yyyy'-'MM'-'dd' 00:00:00.000'");
            string strDateEnd = updatedEndDate.ToString("yyyy'-'MM'-'dd' 23:59:59.999'");
            string[] mass = index.Split(','); //переводим строку в массив
            
            mass[0] = "REPLACE([Jobs], '" +mass[0]+ "', '')"; //оборачиваем все в REPLACE
            for (int i = 1; i < mass.Length; i++)
            {
                mass[i] = "REPLACE("+mass[i - 1]+", '" +mass[i]+"', '')";
            }

            string query = @"Select * From 	(SELECT  [PersonID]
                              ,[XMLInsertTime]
                              ,[BRID]
                              ,[BRName]
                              ,[Surname]
                              ,[GivenNames]
                              ,[PersonFIO]
                              ,[DateOfBirth]
                              ,[PersonCountry]
                              ,[Document]
                              ,[DateOfExpiry]
                              ,[PersonalNumber]
                              ,[Jobs]      
                              ,
                              CASE
		                        LTRIM( REPLACE(";
                   query += mass[mass.Length - 1];
                   query += @" , ' ', ''))
	                        WHEN '' THEN '0'
	                        ELSE '1'
	                        END as 'ViewFlag'
                            FROM [VPersonRevealWithJobs]
                            WHERE XMLInsertTime > '" + strDateStart + "'  AND XMLInsertTime < '" + strDateEnd + " '";

            if (ufoFamily != "")
            {
                query += " AND Surname like '%" + ufoFamily + "%' ";
            }
            if (ufoName != "")
            {
                query += " AND GivenNames like '%" + ufoName + "%' ";
            }

            if (ndb != 0)
            {
                query += " AND BRID = " + ndb;
            } 
            query += @")  
                [T1] Where T1.ViewFlag=1";
   
            List<Person> list = new List<Person>();
            using (SqlConnection connection = new SqlConnection(this.mainDbConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person()
                            {
                                ID = Convert.ToInt32(reader["PersonID"]),
                                ChecklTime = Convert.ToDateTime(reader["XMLInsertTime"]),
                                PasBR = reader["BRName"].ToString(),
                                PassengerFio = reader["PersonFIO"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Citizenship = reader["PersonCountry"].ToString(),
                                DocValidity = Convert.ToDateTime(reader["DateOfExpiry"]),
                                DocumentNum = reader["DocumentNumber"].ToString(),
                                PersonalNumber = reader["PersonalNumber"].ToString(),
                            };
                            list.Add(person);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    list = null;
                }
                return list;
            }
        }


        public List<Ressemblance>GetPersons(DateTime XmlTime, string PersonID)
        {
            
            string strXmlTime = XmlTime.ToString("yyyy'-'MM'-'dd' 'HH:mm:ss'.'fff");
            string query = @"SELECT DISTINCT
                              [BioDocumentID]
                             ,[FIOLat]
                             ,[DocumentNumber]
                             ,[CountryName]
                             ,[DateOfExpiry]
                             ,[FIORus]
                             ,[DateOfBirth]
                             ,[PersonalNumber]
                            FROM VRevealFull
                            WHERE XMLInsertTime= '"+strXmlTime+"' and PersonID="+PersonID+"";
            
                    List<Ressemblance> RessemblanceList = new List<Ressemblance>();
            using (SqlConnection connection = new SqlConnection(this.mainDbConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ressemblance ressemblance = new Ressemblance()
                            {

                                PersonID = Convert.ToInt32(reader["BioDocumentID"]),
                                FioLat = reader["FIOLat"].ToString(),
                                DocumentNumber = reader["DocumentNumber"].ToString(),
                                NationalityCode = reader["CountryName"].ToString(),
                                DocValidity = Convert.ToDateTime(reader["DateOfExpiry"]),
                                FioRus = reader["FIORus"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                PersonalNumber = reader["PersonalNumber"].ToString(),
                            };
                            RessemblanceList.Add(ressemblance);
                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    RessemblanceList = null;
                }
                return RessemblanceList;
            }
        }

        public List<OUDump>GetOUDump(DateTime XmlTime, string PersonID)
        {
            string strXmlTime = XmlTime.ToString("yyyy'-'MM'-'dd' 'HH:mm:ss'.'fff");
            string query = @"SELECT
                             [BioDocumentID] 
                            ,[OUDumpID]
                            ,[FIO]
                            ,[BirthDate]
                            ,[OUDumpCountryName]
                            ,[Job]
                            ,[Comment]
                            ,[LevensteinDistanceOU]
                             FROM VRevealFull 
                             WHERE XMLInsertTime= '" + strXmlTime + "' and PersonID=" + PersonID; 

            List<OUDump> OUDumpList = new List<OUDump>();
            using (SqlConnection connection = new SqlConnection(this.mainDbConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OUDump oudump = new OUDump()
                            {
                                OUPersonID = Convert.ToInt32(reader["BioDocumentID"]),
                                OUID = Convert.ToInt32(reader["OUDumpID"]),
                                FIO = reader["FIO"].ToString(),
                                OU_BirthDate = reader["BirthDate"].ToString(),
                                OU_NationalityCode = reader["OUDumpCountryName"].ToString(),
                                SpecialMark = reader["Job"].ToString(),
                                OUTask = reader["Comment"].ToString(),
                                LevensteinDistance = Convert.ToInt32(reader["LevensteinDistanceOU"]),
                            };
                            OUDumpList.Add(oudump);
                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    OUDumpList = null;
                }
                return OUDumpList;
            }
        }


        public string CheckConnQuery()
        {
           string query = "SELECT 1";
            return RunQueryScalar(query);
        }


        public  void CheckDBConnectionVisualAsync(string connectionString, 
                                                    bool isDbConnectionOkMessageRequired = true, 
                                                    Window owner = null)
        {            
            this.isDbConnectionOkMessageRequired = isDbConnectionOkMessageRequired;
            //SqlCommand command = new SqlCommand();
            splashScreen = new DBConnectionSplashScreen(this.cancelCheckDbConnection);
            splashScreen.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            splashScreen.Topmost = true;
            if (owner != null)
            {
                splashScreen.Owner = owner;
                splashScreen.ShowInTaskbar = false;
                splashScreen.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            splashScreen.Show();

            Debug.WriteLine("backgroundWorker(" + backgroundWorker.GetHashCode() + ").RunWorkerAsync(command)");
            this.backgroundWorker.RunWorkerAsync(connectionString);
        }



        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //bool isKaskadDbUsed = (bool)e.Argument;
            string connectionString = (string)e.Argument;
            //SqlCommand command = e.Argument as SqlCommand;
            SqlCommand command = new SqlCommand();            
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT 1";
            //bool isComplited = false;
                        
            //string connectionString = this.GetConnectionString(isKaskadDbUsed);
            var executeDelegate = new Func<SqlCommand,String, object>(this.exequteScalar);
            IAsyncResult asyncResult = executeDelegate.BeginInvoke(command, connectionString, null,null);
            while (!asyncResult.IsCompleted)
            {
                if(this.backgroundWorker.CancellationPending == true)
                {
                    Debug.WriteLine("backgroundWorker(" + backgroundWorker.GetHashCode() + ").CancellationPending == true");
                    e.Cancel = true;                    
                    command.Dispose();                    
                    break;
                }
                else
                {
                    Debug.Write(".");
                    Thread.Sleep(100);
                }                
            }
            e.Result = executeDelegate.EndInvoke(asyncResult);
        }

        private void cancelCheckDbConnection()
        {
            if (this.backgroundWorker != null && this.backgroundWorker.WorkerSupportsCancellation)
            {
                Debug.WriteLine("backgroundWorker(" + backgroundWorker.GetHashCode() + ").CancelAsync()");
                this.backgroundWorker.CancelAsync();
            }

        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = false;
            if (splashScreen != null || splashScreen.IsVisible)
            {
                splashScreen.Hide();
            }
            if(e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                MessageBox.Show(splashScreen, e.Error.Message, "Ошибка подключения к базе данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                result = true;
                if (isDbConnectionOkMessageRequired)
                {                    
                    MessageBox.Show(splashScreen, "Связь с БД установлена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            if (splashScreen != null)
            {                
                splashScreen.Close();
            }

            if (CheckDbConnectionComplitted != null)
            {
                DbCheckEventArgs args = new DbCheckEventArgs();
                args.Result = result;
                CheckDbConnectionComplitted(this, args);
            }
        }

        public List<Nationality> GetNationalities()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT Name, ICAOCod 
                                    FROM [dbo].[Country]
                                    WHERE DeleteFlag <> 1";
            //command.Parameters.AddWithValue("@valid_date", accessPointsParams.StartDate);            
            //command.CommandTimeout = 4 * 60; //240 seconds

            List<Nationality> items = new List<Nationality>();
            this.exequteReader
                (command, reader =>
                {
                    Nationality item = new Nationality()
                    {
                        //Nc32kKey = Convert.ToInt32(reader["nc32k_key"]),
                        Id = reader["ICAOCod"].ToString(),
                        Name = reader["Name"].ToString(),
                        //Guid = new Guid(reader["guid"].ToString())
                    };
                    items.Add(item);
                }
                );
            return items;
        }

        public List<Person> GetBorderCrossedPersons(string family, string name, int top)
        {
            if (family == null)
            {
                throw new Exception("Фамилия не может быть пустой.");
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT TOP (" + top + ")";
            command.CommandText += @" Family 
                                     ,Name
                                     ,Birthday
                                     ,PhotoID 
                                     FROM dbo.Ins
                                     WHERE 1=1 
                                     AND Family LIKE '" + family + "%'";
            if (!String.IsNullOrEmpty(name))
            {
                command.CommandText += " AND Name LIKE '" + name + "%'";
            }
            command.CommandText += " AND PhotoID IS NOT NULL";
            //command.Parameters.AddWithValue("@valid_date", accessPointsParams.StartDate);            
            //command.CommandTimeout = 4 * 60; //240 seconds

            List<Person> items = new List<Person>();
            string connectionString = this.kaskadDbConnectionString;
            this.exequteReader
                (command, reader =>
                        {
                            Person item = new Person()
                            {
                                Name = reader["Name"].ToString(),
                                Family = reader["Family"].ToString(),
                                //PhotoID = Convert.ToInt64(reader["PhotoID"]),
                                DateOfBirth = Convert.ToDateTime(reader["Birthday"])
                                //Guid = new Guid(reader["guid"].ToString())
                            };
                            items.Add(item);
                        }
                    ,connectionString
                );
            return items;
        }

        public List<Person> GetBorderCrossedPersons(string family,
                                                    string name,
                                                    DateTime birthday, 
                                                    DateTime operationDateStart, 
                                                    DateTime operationDateEnd, int top = 100)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT TOP (" + top + ")";
            command.CommandText += @" 
                                	i.Family
                                	,i.Name
                                	,i.Birthday
                                	,i.Sex
                                	,c.ICAOCod AS [NationalityID]
                                	,c.Name as [NationalityName]
                                	,bd.ImageData AS [ImageData]
                                FROM
                                (
                                	SELECT
                                	DISTINCT 
                                	[IDID]
                                	,[InsID]
                                	--,[OperationTime]
                                	FROM
                                	(    	
                                        SELECT 
                                		  --DISTINCT 
                                		  TOP (10000)
                                		  pd.IDID AS [IDID]
                                		  ,pd.InsID AS [InsID]
                                        --,[OperationTime]  AS [OperationTime]
                                	    FROM [dbo].[Operation] o with (nolock)
                                	    JOIN  dbo.BC bc on bc.BCID = o.BCID
                                	    JOIN dbo.Document pd on pd.BCID = o.BCID
                                	    JOIN dbo.Ins i on i.IDID = pd.IDID 
                                	    WHERE 1=1";
            command.CommandText += @" 
		                                AND o.OperationTime BETWEEN '" + operationDateStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + operationDateEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            if(birthday != new DateTime())
            {
                command.CommandText += @"
                                        AND i.Birthday = '" + birthday.ToString("yyyy-MM-dd") + "'";
            }
            if(!String.IsNullOrEmpty(family))
            {
                command.CommandText += @"
                                        AND i.Family LIKE '" + family.Trim()  + "%'";
            }
            if (!String.IsNullOrEmpty(name))
            {
                command.CommandText += @"
                                        AND i.Name LIKE '" + name.Trim() + "%'";
            }
            command.CommandText += @"
    	                                ORDER BY o.OperationTime desc
                                    	) AS Table2 
                                    ) AS Table1
                                    JOIN dbo.Ins i on i.IDID = Table1.IDID AND i.InsID = Table1.InsID
                                    JOIN dbo.Country c ON c.CountryID = i.NationalityID
                                    JOIN [dbo].[Data] bd ON bd.IDID = Table1.IDID AND bd.InsID = Table1.InsID
                                    
                                    WHERE 1=1 
                                    	AND	bd.DataTypeID = 1	
                                    --ORDER BY Family, Name";
         
            //command.CommandTimeout = 4 * 60; //240 seconds

            List<Person> items = new List<Person>();
            string connectionString = this.kaskadDbConnectionString;
            this.exequteReader
                (command, reader =>
                        {
                            Person item = new Person()
                            {
                                Name = reader["Name"].ToString(),
                                Family = reader["Family"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["Birthday"]),
                                Sex = reader["Sex"].ToString(),
                                NationalityId = reader["NationalityID"].ToString(),
                                NationalityName = reader["NationalityName"].ToString(),
                                ImageArray = reader["ImageData"] as byte[]
                                //PhotoID = Convert.ToInt64(reader["PhotoID"]),
                                //Guid = new Guid(reader["guid"].ToString())
                            };
                            items.Add(item);
                        }
                    ,connectionString
                );
            return items;
        }


        public static byte[] GetPersonPhotoStatic(uint photoID, string kaskadConnectionString)
        {            
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT
                                      io.[ImageSource]
                                    FROM
                                        [dbo].[ImageObject] io
                                    WHERE
                                      io.[ImageObjectID] = (SELECT
                                                               [ImageObjectID]
                                                            FROM [dbo].[Photo]
                                                            WHERE [PhotoID] = " + photoID + ")";
            
            //command.Parameters.AddWithValue("@valid_date", accessPointsParams.StartDate);            
            //command.CommandTimeout = 4 * 60; //240 seconds
            List<Person> items = new List<Person>();
            object sqlResult = exequteScalarStatic(command, kaskadConnectionString);
            return sqlResult as byte[];
        }


        public byte[] GetPersonPhoto(int person_key)
        {
            string connString = this.mainDbConnectionString;            
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT FaceImage FROM VRevealFull WHERE PersonID = '" + person_key.ToString() + "'";
            command.Parameters.AddWithValue("@person_key", person_key);

            return (byte[])exequteScalar(command, connString);
        }
        public byte[] GetRessemblancePhoto(int person_key)
        {
            string connString = this.mainDbConnectionString;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT ResemblanceFaceImage FROM VRevealFull WHERE ResemblanceBioDocumentID = '" + person_key.ToString() + "'";
            command.Parameters.AddWithValue("@person_key", person_key);

            return (byte[])exequteScalar(command, connString);
        }

    }

}

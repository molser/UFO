using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UFO.Commands;
using UFO.PhotoSearchServiceReference;

namespace UFO
{
    public class PhotoFromDbViewModel : ViewModelBase
    {
        private PhotoFromDbView view;
        PhotoSearchServiceClient proxy;
        //private List<Person> personNames;
        private List<Person> persons;
        private Person selectedPerson;
        private string family;
        private string name;
        private DateTime birthday;
        private DateTime operationDateStart;
        private DateTime operationDateEnd;
        private DbWorker dbWorker;
        RelayCommand getPersonsCommand;
        RelayCommand confirmationCommand;
        private const int MAX_PERSONS_COUNT = 100;
        public PhotoFromDbViewModel(PhotoFromDbView view, PhotoSearchServiceClient proxy)
        {
            this.view = view;
            this.proxy = proxy;
            this.dbWorker = new DbWorker();
            //this.birthday = new DateTime();
            this.operationDateStart = DateTime.Now.Date;
            this.operationDateEnd = this.operationDateStart.Add(new TimeSpan(23,59,59));
            //this.personNames = getPersonNamesList();
            //this.personNames.Add("Иванов Петр Петрович");
            //this.personNames.Add("Сидоров Иван Евгеньевич");
            //this.personNames.Add("Петров Петр Петрович");

        }
        //private PhotoSearchServiceClient getProxy()
        //{
        //    if (this.proxy == null || this.proxy.State != CommunicationState.Opened)
        //    {
        //        InstanceContext instanceContext = new InstanceContext(new PhotoSearchServiceContext());
        //        PhotoSearchServiceClient proxy = new PhotoSearchServiceClient(instanceContext);
        //        this.proxy = proxy;
        //        return proxy;
        //    }
        //    else
        //    {
        //        return this.proxy;
        //    }
        //}
        public List<Person> Persons
        {
            get { return this.persons; }
            set
            {
                if (value != null && value.Count < 1) value = null;
                this.persons = value;
                base.OnPropertyChanged("Persons");
            }
        }
        public Person SelectedPerson
        {
            get { return this.selectedPerson; }
            set
            {
                this.selectedPerson = value;
                base.OnPropertyChanged("SelectedPerson");
            }
        }
        //public List<Person> PersonNames
        //{
        //    get { return this.personNames; }
        //    set
        //    {
        //        this.personNames = value;
        //        base.OnPropertyChanged("PersonNames");
        //    }
        //}
        //public string CurrentPersonName
        //{
        //    get { return this.currentPersonName; }
        //    set
        //    {
        //        this.currentPersonName = value;
        //        base.OnPropertyChanged("CurrentPersonName");
        //    }
        //}
        //private List<Person> getPersonNamesList()
        //{
        //    List<Person> list = dbWorker.GetBorderCrossedPersons(true);
        //    if(list != null)
        //    {
        //        list.Sort((x, y) => x.FullName.CompareTo(y.FullName));
        //    }
        //    return list;
        //}
        public string Family
        {
            get { return this.family; }
            set
            {
                this.family = value.ToUpper();
                base.OnPropertyChanged("Family");
                //Debug.WriteLine("this.family: " + this.family);
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value.ToUpper();
                base.OnPropertyChanged("Name");
            }
        }
        public DateTime Birthday
        {
            get { return this.birthday; }
            set
            {
                this.birthday = value;
                base.OnPropertyChanged("Birthday");
            }
        }
        public DateTime OperationDateStart
        {
            get { return this.operationDateStart; }
            set
            {
                this.operationDateStart = value;
                base.OnPropertyChanged("OperationDateStart");
            }
        }
        public DateTime OperationDateEnd
        {
            get { return this.operationDateEnd; }
            set
            {
                this.operationDateEnd = value;
                base.OnPropertyChanged("OperationDateEnd");
            }
        }
        public ICommand GetPersonsCommand
        {
            get
            {
                if (this.getPersonsCommand == null)
                {
                    this.getPersonsCommand = new RelayCommand(executeGetPersonsCommand, canExecuteGetPersonsCommand);
                }
                return this.getPersonsCommand;
            }
        }

        public ICommand ConfirmationCommand
        {
            get
            {
                if (this.confirmationCommand == null)
                {
                    this.confirmationCommand = new RelayCommand(executeConfirmationCommand, canExecuteConfirmationCommand);
                }
                return this.confirmationCommand;
            }
        }

        private bool canExecuteConfirmationCommand(object obj)
        {
            return this.selectedPerson != null;
        }

        private void executeConfirmationCommand(object obj)
        {
            this.view.DialogResult = true;
        }

        private bool canExecuteGetPersonsCommand(object obj)
        {
            //bool result = false;
            //if(!String.IsNullOrEmpty(this.family))
            //{
            //    //Debug.WriteLine("this.family.Trim().Length: " + this.family.Trim().Length);
            //    if (this.family.Trim().Length > 5) result = true;
            //}
            return true;
        }

        private void executeGetPersonsCommand(object obj)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                
                if (this.family != null) this.family = this.family.Trim();
                if (this.name != null) this.name = this.name.Trim();

                GetPhotoFromKaskadParams jobParams = new GetPhotoFromKaskadParams();
                jobParams.Family = this.family;
                jobParams.Name = this.name;
                jobParams.Birthday = this.birthday;
                jobParams.OperationDateStart = this.operationDateStart;
                jobParams.OperationDateEnd = operationDateEnd;
                jobParams.MashineName = Environment.MachineName;
                PhotoSearchServiceResult serviceResult = this.proxy.GetFhotoFromKaskad(jobParams);
                if(serviceResult.Type == PhotoSearchServiceResultType.Error)
                {
                    Mouse.OverrideCursor = null;
                    MessageBox.Show(this.view,
                                            serviceResult.Data.ToString(),
                                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //int count = dbWorker.GetBorderCrossedPersonsCount(this.family, this.name);
                //List<Person> list = dbWorker.GetBorderCrossedPersons(this.family, this.name, MAX_PERSONS_COUNT);
                List<Person> list = dbWorker.GetBorderCrossedPersons(this.family
                                                                    ,this.name
                                                                    ,this.birthday
                                                                    ,this.operationDateStart
                                                                    ,this.operationDateEnd
                                                                    ,MAX_PERSONS_COUNT);

                if (list!=null) list.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                this.Persons = list;
                Mouse.OverrideCursor = null;

                if(list.Count == MAX_PERSONS_COUNT)
                {
                    MessageBox.Show(this.view,
                                        "Превышено допустимое количество записей." 
                                        + " Чтобы получить точный результат, пожалуйста, скорректируйте параметры запроса.",
                                        "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

            }
            catch (FaultException<string> exception)
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show(this.view,
                                        exception.Message,
                                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception error)
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show(this.view,
                                        error.Message,
                                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);               
            }
        }
    }
}

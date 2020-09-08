using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using UFO.Commands;
using UFO.PhotoSearchServiceReference;
using UFO.Utilities;

namespace UFO
{
    //internal struct JobParams
    //{
    //    public string Years;
    //    public bool IsSupressed;
    //}
    public class PhotoSearchViewModel : ViewModelBase
    {
        PhotoSearchView view;
        PhotoSearchServiceClient proxy = null;
        PhotoSearchServiceContext context;
        BitmapImage personPhoto;
        Settings appSettings;
        byte[] personPhotoArray;
        string personPhotoExt;
        bool isJobRunning;
        bool canExecuteJob;
        //bool isLoadPhotoFromDbEnabled;
        string yearStart;
        string yearEnd;
        string nationality;
        string photoFileName;
        string resultHtml;
        readonly string[] supportedImageFileExtensions = { ".BMP", ".JPG", ".GIF", ".PNG", ".TIFF" };    
        List<string> years;
        List<Nationality> nationalities;
        List<Sex> sexs;
        Sex sex;
        RelayCommand loadPhotoCommand;
        RelayCommand getPersonsFromDbCommand;
        RelayCommand startJobCommand;
        RelayCommand cancelJobCommand;
        RelayCommand showNationalityViewCommand;
        RelayCommand savePhotoSearchResultCommand;

        public PhotoSearchViewModel(PhotoSearchView view, Settings appSettings)
        {
            this.view = view;
            this.appSettings = appSettings;
            this.context = new PhotoSearchServiceContext();
            context.OnServiceCallBack += Context_OnServiceCallBack;
            this.years = new List<string>();
            for (int i = 1900; i < DateTime.Now.Year; i++)
            {
                this.years.Add(i.ToString());
            }
            this.YearStart = (DateTime.Now.Year - 35).ToString();
            this.YearEnd = (DateTime.Now.Year - 35).ToString();
            this.nationalities = new List<Nationality>();
            this.sexs = Sex.GetSexs();
            this.view.webBrowser.NavigateToString("<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'><body style='background-color:#c6c6c6;'> </body></html>");
        }

        private void raiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public List<string> Years
        {
            get { return this.years; }
            set
            {
                this.years = value;
                this.OnPropertyChanged("Years");
            }
        }

        public List<Nationality> Nationalities
        {
            get { return this.nationalities; }
            set
            {
                this.nationalities = value;
                this.OnPropertyChanged("Nationalities");
            }
        }

        public BitmapImage PersonPhoto
        {
            get { return this.personPhoto; }
            private set
            {
                this.personPhoto = value;
                this.OnPropertyChanged("PersonPhoto");
            }
        }

        public string YearStart
        {
            get { return this.yearStart; }
            set
            {
                this.yearStart = value;
                this.OnPropertyChanged("YearStart");
            }
        }
        public string YearEnd
        {
            get { return this.yearEnd; }
            set
            {
                this.yearEnd = value;
                this.OnPropertyChanged("YearEnd");
            }
        }

        public string PhotoFileName
        {
            get { return this.photoFileName; }
            set
            {
                this.photoFileName = value;
                this.OnPropertyChanged("PhotoFileName");
            }
        }

        public List<Sex> Sexs
        {
            get { return this.sexs; }
            set
            {
                this.sexs = value;
                this.OnPropertyChanged("Sexs");
            }
        }

        public Sex Sex
        {
            get { return this.sex; }
            set
            {
                this.sex = value;
                this.OnPropertyChanged("Sex");
            }
        }
        //public string Nationality
        //{
        //    get { return this.nationality; }
        //    set
        //    {
        //        this.nationality = value;
        //        this.OnPropertyChanged("Nationality");
        //    }
        //}

        public bool IsJobRunning
        {
            get { return this.isJobRunning; }
            set
            {
                this.isJobRunning = value;
                this.OnPropertyChanged("IsJobRunning");
            }
        }
        
        public bool IsLoadPhotoFromDbEnabled
        {
            get
            {
                if (this.appSettings == null) return false;
                return this.appSettings.IsKaskadDbUsed;
            }
            //private set
            //{
            //    this.isLoadPhotoFromDbEnabled = value;
            //    this.OnPropertyChanged("IsLoadPhotoFromDbEnabled");
            //}
        }
        public bool CanExecuteJob
        {
            get { return this.canExecuteJob; }
            set
            {
                this.canExecuteJob = value;
                this.OnPropertyChanged("CanExecuteJob");
            }
        }

        private PhotoSearchServiceClient getProxy()
        {
            if (this.proxy == null || this.proxy.State != CommunicationState.Opened)
            {
                InstanceContext instanceContext = new InstanceContext(context);
                PhotoSearchServiceClient proxy = new PhotoSearchServiceClient(instanceContext);
                this.proxy = proxy;
                return proxy;
            }
            else
            {
                return this.proxy;
            }
        }

        //проверка на полноту заполненности фильтра запроса
        private bool checkSearchParamsCompleteness()
        {
            bool result = false;
            if(!String.IsNullOrEmpty(this.nationality))
            {
                result = true;
            }
            return result;
        }

        private void Context_OnServiceCallBack(object sender, PhotoSearchServiceCallBackEventArgs e)
        {
            this.IsJobRunning = false;

            PhotoSearchServiceResult serviceResult = e.Result;

            if (serviceResult.Type == PhotoSearchServiceResultType.OK)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action( () => this.view.webBrowser.NavigateToString(serviceResult.Data.ToString())));
                Application.Current.Dispatcher.BeginInvoke(new Action(() => this.resultHtml = serviceResult.Data.ToString()));
            }
            else if (serviceResult.Type == PhotoSearchServiceResultType.Cancel)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        MessageBox.Show(this.view, 
                                        "Выполнение задачи прервано", 
                                        "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation)));
            }
            else if (serviceResult.Type == PhotoSearchServiceResultType.Confirmation)
            {
                MessageBoxResult dialogResult = MessageBoxResult.No;
                Application.Current.Dispatcher.Invoke(new Action(() =>
                   dialogResult =  MessageBox.Show(serviceResult.Data.ToString() + Environment.NewLine + "Продолжить?",
                                            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No)));
                if(dialogResult == MessageBoxResult.Yes)
                {
                    this.startJob(true);
                }
            }
            else
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                        MessageBox.Show(this.view, serviceResult.Data.ToString(), 
                                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error)));
            }
            this.raiseCanExecuteChanged();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.context.OnServiceCallBack -= Context_OnServiceCallBack;
            if (   this.proxy != null 
                && this.proxy.State == CommunicationState.Opened)
            {
                if (this.isJobRunning)
                {
                    this.proxy.CancelSearchPersonByPhoto();
                }
                this.proxy.Close();
            }            
        }
        
        public void LoadImageFromFile(string filePath)
        {
            try
            {
                byte[] array = ImageHelper.GetArrayFromFile(filePath);
                System.Drawing.Image image = ImageHelper.GetImageFromArray(array);
                string ext = ImageHelper.GetImageFileExtension(image);
                if (String.IsNullOrEmpty(ext))
                    ext = "";
                this.personPhotoArray = array;
                this.personPhotoExt = ext;
                this.PersonPhoto = ImageHelper.GetBitmapImageFromArray(array, 300);
                this.PhotoFileName = Path.GetFileName(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.view, ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadImageFromArray(byte[] array, string photoName)
        {
            try
            {
                //byte[] array = ImageHelper.GetArrayFromFile(filePath);
                System.Drawing.Image image = ImageHelper.GetImageFromArray(array);
                string ext = ImageHelper.GetImageFileExtension(image);
                if (String.IsNullOrEmpty(ext))
                    ext = "";
                this.personPhotoArray = array;
                this.personPhotoExt = ext;
                this.PersonPhoto = ImageHelper.GetBitmapImageFromArray(array, 300);
                this.PhotoFileName = photoName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.view, ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool ValidateImageFileType(string filePath)
        {
            if (filePath == null) return false;
            string extension = Path.GetExtension(filePath);
            if (this.supportedImageFileExtensions.Contains(extension.ToUpper())) return true;
            return false;
        }

        private void startJob(bool isSupressed = false)
        {
            this.IsJobRunning = true;
            int yearStartInt = Convert.ToInt16(this.yearStart);
            int yearEndInt = Convert.ToInt16(this.yearEnd);
            if (yearEndInt < yearStartInt)
            {
                yearEndInt = yearStartInt;
                this.YearEnd = this.yearStart;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = yearStartInt; i <= yearEndInt; i++)
            {
                sb.Append(i.ToString()).Append(" ");
            }

            //JobParams jobParams;
            SearchPersonByPhotoParams jobParams = new SearchPersonByPhotoParams();
            jobParams.PhotoArray = this.personPhotoArray;
            jobParams.PhotoFileExtention = this.personPhotoExt;
            jobParams.Sex = this.sex.Id;
            jobParams.Years = sb.ToString().Trim();
            jobParams.Natinality = this.nationality;
            jobParams.MashineName = Environment.MachineName;
            jobParams.IsSupressed = isSupressed;


            //jobParams.Years = sb.ToString().Trim();
            //jobParams.IsSupressed = isSupressed;

            BackgroundWorker worker = new BackgroundWorker();
            //worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_GetPhotoSearchResult;
            worker.RunWorkerCompleted += Worker_GetPhotoSerachResultCompleted;
            worker.RunWorkerAsync(jobParams);
        }

        public ICommand LoadPhotoCommand
        {
            get
            {
                if (this.loadPhotoCommand == null)
                {
                    this.loadPhotoCommand = new RelayCommand(executeLoadPhotoCommand);

                }
                return this.loadPhotoCommand;
            }
        }
        public ICommand GetPersonsFromDbCommand
        {
            get
            {
                if (this.getPersonsFromDbCommand == null)
                {
                    this.getPersonsFromDbCommand = new RelayCommand(executeGetPersonsFromDbCommand);

                }
                return this.getPersonsFromDbCommand;
            }
        }
        public ICommand StartJobCommand
        {
            get
            {
                if (this.startJobCommand == null)
                {
                    this.startJobCommand = new RelayCommand(executeStartJobCommand, canExecuteStartJobCommand);
                }
                return this.startJobCommand;
            }
        }
        public ICommand CancelJobCommand
        {
            get
            {
                if (this.cancelJobCommand == null)
                {
                    this.cancelJobCommand = new RelayCommand(executeCancelJobCommand, canExecuteCancelJobCommand);
                }
                return this.cancelJobCommand;
            }
        }

        public ICommand ShowNationalitiesViewCommand
        {
            get
            {
                if (this.showNationalityViewCommand == null)
                {
                    this.showNationalityViewCommand = new RelayCommand(executeShowNationalitiesViewCommand);
                }
                return this.showNationalityViewCommand;
            }
        }

        public ICommand SavePhotoSearchResultCommand
        {
            get
            {
                if (this.savePhotoSearchResultCommand == null)
                {
                    this.savePhotoSearchResultCommand = new RelayCommand(executeSavePhotoSearchResultCommand, canExecuteSavePhotoSearchResultCommand);
                }
                return this.savePhotoSearchResultCommand;
            }
        }

        private bool canExecuteSavePhotoSearchResultCommand(object obj)
        {
            if (this.isJobRunning) return false;
            return !String.IsNullOrEmpty(this.resultHtml);
        }

        private void executeSavePhotoSearchResultCommand(object obj)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Сохранение результатов поиска";
            //if(ext != "")
            //{
            //    saveDialog.DefaultExt = ext;
            //    saveDialog.AddExtension = true;
            //}
            saveDialog.FileName = Path.GetFileNameWithoutExtension(this.photoFileName);
            saveDialog.OverwritePrompt = true;
            //saveDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveDialog.Filter = "(*.html)|*.html|Все файлы(*.*)|*.*";
            if (saveDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveDialog.FileName, this.resultHtml);
                
                //Message.ShowMessage(ext, "Тип картинки", this.view);
                //Message.ShowMessage("Файл успешно сохранен", "Информация", this.view);                            
            }
        }

        private void executeShowNationalitiesViewCommand(object obj)
        {
            ListView view = new ListView();
            AppObjectBase[] selectedItems = null;
            if (this.nationalities != null) selectedItems = this.nationalities.ToArray();
            view.ViewModel = new NationalitiesViewModel(view, selectedItems);
            view.ViewModel.IsSelectableMode = true;
            view.Owner = this.view;
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            view.ShowInTaskbar = false;
            if(view.ShowDialog() == true)
            {
                selectedItems = view.ViewModel.SelectedItems;
                List<Nationality> list = new List<Nationality>();
                StringBuilder sb = new StringBuilder();
                foreach (Nationality nationality in selectedItems)
                {
                    list.Add(nationality);
                    sb.Append(nationality.Id).Append(" ");
                }
                this.nationality = sb.ToString().Trim();
                list.Sort((x, y) => x.Name.CompareTo(y.Name));
                this.Nationalities = list;
            }
        }

        private bool canExecuteCancelJobCommand(object obj)
        {
            return true;
        }

        private void executeCancelJobCommand(object obj)
        {
            try
            {
                this.proxy.CancelSearchPersonByPhoto();
                this.IsJobRunning = false;                
            }
            catch (Exception ex)
            {
                this.IsJobRunning = false;
                MessageBox.Show(this.view, ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool canExecuteStartJobCommand(object obj)
        {
            if (this.isJobRunning) return false;
            return this.personPhotoArray != null;
        }


        private void executeStartJobCommand(object obj)
        {
            
            if (!this.checkSearchParamsCompleteness())
            {                
                string message = "Вы не выбрали параметр 'Гражданство'."
                                + Environment.NewLine + "Запрос может занять продолжительное время.";
               
                MessageBoxResult dialogResult = MessageBoxResult.No;
                dialogResult = MessageBox.Show(message + Environment.NewLine + "Продолжить?",
                                            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (dialogResult == MessageBoxResult.No)
                {
                    return;
                }
            }
            this.startJob();
        }

        private void Worker_GetPhotoSerachResultCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {

            }
            else if (e.Error != null)
            {
                this.IsJobRunning = false;
                MessageBox.Show(this.view, e.Error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Worker_GetPhotoSearchResult(object sender, DoWorkEventArgs e)
        {
            SearchPersonByPhotoParams jobParams = (SearchPersonByPhotoParams)e.Argument;
            //JobParams jobParams = (JobParams)e.Argument;
            //this.getProxy().GetDataDuplex(this.personPhotoArray,
            //                 this.personPhotoExt,
            //                 this.sex.Id,
            //                 jobParams.Years,
            //                 this.nationality,
            //                 Environment.MachineName,
            //                 jobParams.IsSupressed);
            this.getProxy().SearchPersonByPhoto(jobParams);
        }

        private void executeLoadPhotoCommand(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.FileName = "Оповещения"; // Default file name
            //dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Изображения (*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|Все файлы(*.*)|*.*";

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                this.LoadImageFromFile(dlg.FileName);
            }
        }
        private void executeGetPersonsFromDbCommand(object obj)
        {
            PhotoFromDbView view = new PhotoFromDbView();
            PhotoFromDbViewModel photoFromDbViewModel = new PhotoFromDbViewModel(view, this.getProxy());
            view.ViewModel = photoFromDbViewModel;
            view.Owner = this.view;
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            view.ShowInTaskbar = false;
            if (view.ShowDialog() == true)
            {
                Person person = photoFromDbViewModel.SelectedPerson;

                this.YearStart = person.DateOfBirth.Year.ToString();
                this.YearEnd = this.YearStart;
                this.nationality = person.NationalityId;
                UFO.Nationality nationality = new UFO.Nationality(person.NationalityId, person.NationalityName);
                List<UFO.Nationality> list = new List<UFO.Nationality>();
                list.Add(nationality);
                this.Nationalities = list;
                Sex sex = new Sex(person.Sex);
                this.Sex = sex;
                this.LoadImageFromArray(person.ImageArray, person.FullName);
            }
        }        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UFO;
using UFO.Utilities;

namespace UFO
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>

    public partial class PersonView : Window
    {
        public bool IsMinimizeButtonHidden { get { return true; } }
        private DbWorker dbWorker;
        //private Settings settings;
        private Person currentPerson = null;
       // private Settings settings;
        private BitmapImage currentPersonPhoto = null;
        private BitmapImage currentBasePhoto = null;
        private List<OUDump> OUPersons = null;
        private List<OUDump> OUPersons2 = null;
        public PersonView(Person currentPerson)
        {
            InitializeComponent();
            //this.settings = settings;
            this.dbWorker = new DbWorker();
            // Вешаем обработчик на событие перед закрытием окна.
            Closing += new CancelEventHandler(Window_Closing);
            // Восстанавливаем позицию на экране.
            Left = Properties.Settings.Default.PersonWindowPosition.Left;
            Top = Properties.Settings.Default.PersonWindowPosition.Top;
            // Востанавливаем размеры окна.
            Width = Properties.Settings.Default.PersonWindowPosition.Width;
            Height = Properties.Settings.Default.PersonWindowPosition.Height;

            this.currentPerson = currentPerson;
            this.loadData();
        }

        private void loadData()
        {
            this.spCurrentPerson.DataContext = this.currentPerson;
            if (this.currentPerson != null)
            {
                try
                {
                    byte[] array = this.dbWorker.GetPersonPhoto(this.currentPerson.PassengerID);
                    BitmapImage bitmap = ImageHelper.GetBitmapImageFromArray(array);
                    currentPersonPhoto = bitmap;
                    this.imgCurrentPhoto.Source = bitmap;
                    if (bitmap != null)
                    {
                        this.imgCurrentPhotoBack.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        this.imgCurrentPhotoBack.Visibility = Visibility.Visible;
                    }                    
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            List<Ressemblance> basePersons = null;
            //List<OUDump> OUPersons = null;
            try
            {
                basePersons = this.dbWorker.GetPersons(this.currentPerson.ChecklTime,this.currentPerson.PassengerID.ToString());
                OUPersons = this.dbWorker.GetOUDump(this.currentPerson.ChecklTime,this.currentPerson.PassengerID.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.dgBasePersons.ItemsSource = basePersons;
            if (basePersons!= null && basePersons.Count > 0) this.dgBasePersons.SelectedIndex = 0;

            //this.dgOUPersons.ItemsSource = OUPersons2;
            //if (OUPersons != null && OUPersons.Count > 0) this.dgOUPersons.SelectedIndex = 0;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // RestoreBounds - Возвращает размер и расположение окна перед тем как оно было свернуто или развернуто.
            Properties.Settings.Default.PersonWindowPosition = this.RestoreBounds;
            // Сохранение настроек.
            Properties.Settings.Default.Save();
        }

        private void dgBasePersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (dgBasePersons.SelectedItem != null)
            {
                Ressemblance ressemblance = dgBasePersons.SelectedItem as Ressemblance;
                try
                {
                    byte[] array = this.dbWorker.GetRessemblancePhoto(ressemblance.RessemblancePersonID);
                    BitmapImage bitmap = ImageHelper.GetBitmapImageFromArray(array);
                    currentBasePhoto = bitmap;
                    this.imgBasePhoto.Source = bitmap;
                    if (bitmap != null)
                    {
                        this.imgBasePhotoBack.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        this.imgBasePhotoBack.Visibility = Visibility.Visible;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            
                spBasePerson.DataContext = dgBasePersons.SelectedItem as Ressemblance;

              
                OUPersons2 =
                    (from People in OUPersons
                     where People.OUPersonID == ressemblance.RessemblancePersonID
                     select People).ToList();

                this.dgOUPersons.ItemsSource = null;
                this.dgOUPersons.ItemsSource = OUPersons2;
                if (OUPersons != null && OUPersons.Count > 0) this.dgOUPersons.SelectedIndex = 0;

            }
        }

    

        private void dgOUPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgOUPersons.SelectedItem != null)
            {
                spOUPerson.DataContext = dgOUPersons.SelectedItem as OUDump;
            }
        }

        private void bDetailPhotoView_Click(object sender, RoutedEventArgs e)
        {
           
            DetailPhotoView DetailView = new DetailPhotoView(currentPersonPhoto, currentBasePhoto);
            DetailView.Owner = this;
            DetailView.ShowDialog();
    }
    }
}

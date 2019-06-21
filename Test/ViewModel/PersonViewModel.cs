using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Test.Models;
using Test.View;
using Xamarin.Forms;

namespace Test.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        #region Properties
        private ObservableCollection<PersonModel> _lstPersons = new ObservableCollection<PersonModel>();

        public ObservableCollection<PersonModel> lstPersons
        {
            get { return _lstPersons; }

            set
            {
                _lstPersons = value;
                OnPropertyChanged("lstPersons");
            }
        }

        private PersonModel _CurrentPerson = new PersonModel();

        public PersonModel CurrentPerson
        {
            get
            {
                return _CurrentPerson;
            }

            set
            {
                _CurrentPerson = value;
                OnPropertyChanged("CurrentPerson");
            }
        }

        public ICommand GuardarPersonaCommand { get; set; }
        public ICommand EnterAgregarPersonaCommand { get; set; }
        public ICommand EnterEditarPersonaCommand { get; set; }

        #endregion

        #region Singleton
        private static PersonViewModel instance = null;

        private PersonViewModel()
        {
            InitCommands();
            InitClass();
        }

        public static PersonViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PersonViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        #endregion

        #region Methods
        private async void InitClass()
        {
            try
            {
                lstPersons = await PersonModel.GetAllPersons();
            }
            catch
            {

            }

        }

        private void InitCommands()
        {
            GuardarPersonaCommand = new Command(GuardarPersonaAsync);
            EnterAgregarPersonaCommand = new Command(EnterAgregarPersona);
            EnterEditarPersonaCommand = new Command<int>(EnterEditarPersona);
        }

        public void EnterEditarPersona(int id)
        {

            CurrentPerson = lstPersons.FirstOrDefault(x => x.Id == id);

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new AgregarPersonView());
        }

        public void EnterAgregarPersona()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new AgregarPersonView());
        }

        public async void GuardarPersonaAsync()
        {
            //lstPersons.Add(CurrentPerson);

            _ = PersonModel.AddPersons(CurrentPerson);

            CurrentPerson = null;

            lstPersons = await PersonModel.GetAllPersons();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
        }

        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

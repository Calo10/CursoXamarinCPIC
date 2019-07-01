using System;
using System.ComponentModel;
using System.Windows.Input;
using Plugin.Fingerprint;
using Test.View;
using Xamarin.Forms;

namespace Test.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Properties

        private string _User = "";

        public string User
        {
            get
            {
                return _User;
            }

            set
            {
                _User = value;
                OnPropertyChanged("User");
            }
        }

        private string _Pass = "";

        public string Pass
        {
            get
            {
                return _Pass;
            }

            set
            {
                _Pass = value;
                OnPropertyChanged("Pass");
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand FingerAuthCommand { get; set; }

        #endregion


        #region Singleton
        private static LoginViewModel instance = null;

        private LoginViewModel()
        {
            InitCommands();
            InitClass();
        }

        public static LoginViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginViewModel();
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

        public async void Login()
        {
            if (User == "Carlos" && Pass == "123")
            {
                CreateAppStructure();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Credenciales Invalidas", "Ok");
            }
        }

        private void CreateAppStructure()
        {
            NavigationPage navigation = new NavigationPage(new PersonView());

            App.Current.MainPage = new MasterDetailPage
            {
                Master = new MenuView(),
                Detail = navigation
            };
        }

        private async void FingerAuthAsync()
        {
            var result = await CrossFingerprint.Current.AuthenticateAsync("Prove you have fingers!");
            if (result.Authenticated)
            {
                CreateAppStructure();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Huella No valida", "Ok");
            }
        }

        private void InitClass()
        {

        }

        private void InitCommands()
        {
            LoginCommand = new Command(Login);
            FingerAuthCommand = new Command(FingerAuthAsync);
        }

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

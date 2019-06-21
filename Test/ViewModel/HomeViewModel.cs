using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Test.Models;
using Test.View;
using Xamarin.Forms;

namespace Test.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        #region Properties
        private ObservableCollection<MenuModel> _lstMenu = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> lstMenu
        {
            get { return _lstMenu; }

            set
            {
                _lstMenu = value;
                OnPropertyChanged("lstMenu");
            }
        }

        public ICommand EnterMenuCommand { get; set; }

        #endregion

        #region Methods

        public HomeViewModel()
        {
            lstMenu = MenuModel.GetAllMenu();

            EnterMenuCommand = new Command<int>(EnterMenu);
        }

        private void EnterMenu(int opc)
        {
            switch (opc)
            {
                case 1:

                    ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new OperacionesTabbedPageView());
                    break;

                case 2:

                    ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MapView());
                    break;
                default:
                    break;
            }

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

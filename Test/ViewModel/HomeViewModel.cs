using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Test.Models;

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

        #endregion

        #region Methods

        public HomeViewModel()
        {
            lstMenu = MenuModel.GetAllMenu();
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

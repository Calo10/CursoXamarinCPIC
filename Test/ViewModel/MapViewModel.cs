using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Test.Models;

namespace Test.ViewModel
{
    public class MapViewModel : INotifyPropertyChanged
    {

        #region Properties
        private ObservableCollection<LocationModel> _lstLocations = new ObservableCollection<LocationModel>();

        public ObservableCollection<LocationModel> lstLocations
        {
            get { return _lstLocations; }

            set
            {
                _lstLocations = value;
                OnPropertyChanged("lstLocations");
            }
        }
        #endregion


        #region Singleton
        private static MapViewModel instance = null;

        private MapViewModel()
        {
            InitCommands();
            InitClass();
        }

        public static MapViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MapViewModel();
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

        public void InitClass()
        {

            foreach (var item in PersonViewModel.GetInstance().lstPersons)
            {
                lstLocations.Add(new LocationModel
                {
                    Latitude = item.Direction.Latitude,
                    Longitude = item.Direction.Longitude,
                    Description = item.Name
                });
            }
        }

        public void InitCommands()
        {

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

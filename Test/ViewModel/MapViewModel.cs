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
            LocationModel locationA = new LocationModel
            {
                Latitude = 9.9280884,
                Longitude = -84.0667962,
                Description = "Location A"
            };
            LocationModel locationB = new LocationModel
            {
                Latitude = 9.9380884,
                Longitude = -84.0767962,
                Description = "Location B"
            };

            lstLocations.Add(locationA);
            lstLocations.Add(locationB);
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

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Test.Models;

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

        #endregion

        public PersonViewModel()
        {
            lstPersons = PersonModel.GetAllPersons();
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

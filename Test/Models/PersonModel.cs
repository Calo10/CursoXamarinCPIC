using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Realms;

namespace Test.Models
{
    public class PersonModel : RealmObject, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }
        private LocationModel _Direction = new LocationModel();
        public LocationModel Direction
        {
            get
            {
                return _Direction;
            }
            set
            {
                _Direction = value;
                OnPropertyChanged("Direction");
            }
        }

        public const string Server = "localhost";

        public async static Task<ObservableCollection<PersonModel>> GetAllPersons()
        {
            var online = false;

            if (online)
            {
                using (HttpClient client = new HttpClient())
                {

                    var uri = new Uri(Server + "/Person/GetAllPersons");

                    HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();

                    var lstPersons = JsonConvert.DeserializeObject<ObservableCollection<PersonModel>>(ans);

                    return lstPersons;
                }

            }
            else
            {
                var realm = Realm.GetInstance();

                var lstPersons = realm.All<PersonModel>();

                return null;

            }


        }


        public async static Task<bool> AddPersons(PersonModel person)
        {
            var online = false;

            if (online)
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = new Uri(Server + "/Person/AddPerson");

                    var json = JsonConvert.SerializeObject(new
                    {
                        Name = person.Name,
                        LastName = person.LastName
                    }
                    );

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string ans = await response.Content.ReadAsStringAsync();

                    bool respuesta = JsonConvert.DeserializeObject<bool>(ans);

                    return respuesta;
                }
            }
            else
            {
                var realm = Realm.GetInstance();

                realm.Write(() =>
                {
                    realm.Add(person);
                });

                return true;
            }
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

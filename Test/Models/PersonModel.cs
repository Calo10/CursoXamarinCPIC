using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }

        public const string Server = "localhost";

        public async static Task<ObservableCollection<PersonModel>> GetAllPersons()
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


        public async static Task<bool> AddPersons(PersonModel person)
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
    }
}

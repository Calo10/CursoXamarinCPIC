using System;
using System.Collections.ObjectModel;

namespace Test.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }

        public static ObservableCollection<PersonModel> GetAllPersons()
        {
            ObservableCollection<PersonModel> lstPersons = new ObservableCollection<PersonModel>
            {
                new PersonModel { Id = 1, Name = "Carlos", LastName = "Mendez", Age=31 },
                new PersonModel { Id = 1, Name = "Daniel", LastName = "Mendez", Age=13 },
                new PersonModel { Id = 1, Name = "Natasha", LastName = "Mendez", Age=7 },
                new PersonModel { Id = 1, Name = "Sofia", LastName = "Mendez", Age=5 },
            };

            return lstPersons;
        }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVC_PartialView.Models.Repository
{
    public class PersonRepository
    {

        //Using Singleton design pattern 
        private static PersonRepository _ins;
        private List<Person> _people;

        //Creating a constructor of person repository
        private PersonRepository() { 
        }

        //This will create an object of PersonRepository for the first time we call it
        //but the second time it will return that object. 
        public static PersonRepository GetIns() {
            if (_ins == null) _ins = new PersonRepository();

            return _ins;
        }

        //Get the list of the people
        //Deserializes the JSON to the specified . NET type using a collection of JsonConverter.
        public List<Person> GetAll()
        {
            if (_people != null) return _people;

            string jsonFileText = File.ReadAllText("Models/MockJson/People.json");
            _people = JsonConvert.DeserializeObject<List<Person>>(jsonFileText);
            return _people;
        }

        //Removing selected person from the list _people
        public void Remove(int id) {
            //Predicate
            _people.RemoveAll(a => a.Id == id);
            SaveChanges();
        }

        //Filtering the list by name
        public List<Person> FilterByName(string stringToSearch)
        {
            return _people.Where(item => item.Name.ToLower() == stringToSearch.ToLower()).ToList();
        }


        //Creating a person and add it to the list "_people"
        public void Create(string name,string city,long phoneNumber) {
            Person np = new Person();
            np.City = city;
            np.Name = name;
            np.PhoneNumber = phoneNumber;

            int index = 1;
            var lastPerson = _people.LastOrDefault();
            if (lastPerson != null) index = lastPerson.Id + 1;

            np.Id = index;
            _people.Add(np);
            SaveChanges();
        }

        //Saving all the changes made by the user, t.ex. after filtering or adding a new person  
        public void SaveChanges() {
            string json = JsonConvert.SerializeObject(_people,Formatting.Indented);
            File.WriteAllText("Models/MockJson/People.json",json);
        }
    }
}

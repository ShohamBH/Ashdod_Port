using System.Xml.Linq;

namespace Ashdod_Port.Core.Entities
{
    public class Person
    {
        private string id;
        private string name;
        private string city;
        private string phone;
<<<<<<< HEAD
        private string password;

        public Person() { }
        public Person(string id, string name, string city, string phone, string password)
=======

        public Person() { }
        public Person(string id, string name, string city, string phone)
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        {
            this.id = id;
            this.name = name;
            this.city = city;
            this.phone = phone;
<<<<<<< HEAD
            this.password = password;
=======
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Phone { get => phone; set => phone = value; }
<<<<<<< HEAD
        public string Password { get => password; set => password = value; }
=======
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
    }
}

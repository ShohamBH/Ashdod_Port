using System.Xml.Linq;

namespace Ashdod_Port.Core.Entities
{
    public class Person
    {
        private string id;
        private string name;
        private string city;
        private string phone;
        private string password;

        public Person() { }
        public Person(string id, string name, string city, string phone, string password)
        {
            this.id = id;
            this.name = name;
            this.city = city;
            this.phone = phone;
            this.password = password;
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
    }
}

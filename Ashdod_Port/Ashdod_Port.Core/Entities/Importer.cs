namespace Ashdod_Port.Core.Entities
{
    public class Importer : Person
    {
        private int num;

        public Importer() { }
<<<<<<< HEAD
        public Importer(string name, string id, string city, string phone, int num,string pass)
            : base(name, id, city, phone,pass)
=======
        public Importer(string name, string id, string city, string phone, int num)
            : base(name, id, city, phone)
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        {
            this.num = num;
        }

        public int Num { get => num; set => num = value; }
<<<<<<< HEAD
        public List<Container> ? Containers { get; set; }
=======
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
    }
}

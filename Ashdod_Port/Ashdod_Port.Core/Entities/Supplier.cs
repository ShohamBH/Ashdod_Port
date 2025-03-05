using System.ComponentModel.DataAnnotations;

namespace Ashdod_Port.Core.Entities
{
    public class Supplier : Person
    {
       // [Key]
      //  private int key;
        private int num;
        public Supplier() { }
        public Supplier(string name, string id, string city, string phone, int num,string pass)
            : base(name, id, city, phone,pass)
        {
            this.num = num;
        }

        public int Num { get => num; set => num = value; }
        public List<Container> ? Containers { get; set; }

    }
}

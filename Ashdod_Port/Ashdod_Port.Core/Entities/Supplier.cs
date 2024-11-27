namespace Ashdod_Port.Core.Entities
{
    public class Supplier : Person
    {
        private int num;
        public Supplier() { }
        public Supplier(string name, string id, string city, string phone, int num)
            : base(name, id, city, phone)
        {
            this.num = num;
        }

        public int Num { get => num; set => num = value; }
    }
}
